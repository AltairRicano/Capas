USE [master];
GO

-- 1. CREAR LA BASE DE DATOS
IF NOT EXISTS (SELECT name FROM sys.databases WHERE name = N'DBMarina')
BEGIN
    CREATE DATABASE [DBMarina];
END
GO

USE [DBMarina];
GO

-- 2. CREAR TABLA: Personas
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Personas]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Personas] (
        [IdPersona] INT IDENTITY(1,1) NOT NULL,
        [Nombre] NVARCHAR(100) NOT NULL,
        [Direccion] NVARCHAR(255) NULL,
        [Telefono] NVARCHAR(20) NULL,
        [Correo] NVARCHAR(100) NULL,
        [Cargo] INT NULL DEFAULT 0, -- 0=Socio, 1=Capitán, etc.
        [Disponibilidad] BIT NULL DEFAULT 1,
        [UrlFoto] NVARCHAR(500) NULL,
        CONSTRAINT [PK_Personas] PRIMARY KEY CLUSTERED ([IdPersona] ASC)
    );
END
GO

-- 3. CREAR TABLA: Barcos
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Barcos]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Barcos] (
        [IdBarco] INT IDENTITY(1,1) NOT NULL,
        [Matricula] NVARCHAR(50) NOT NULL,
        [NoAmarre] NVARCHAR(50) NULL,
        [Nombre] NVARCHAR(100) NOT NULL,
        [Cuota] DECIMAL(18,2) NULL,
        [IdOwner] INT NULL,
        [Disponibilidad] BIT NULL DEFAULT 1,
        [UrlFoto] NVARCHAR(500) NULL,
        CONSTRAINT [PK_Barcos] PRIMARY KEY CLUSTERED ([IdBarco] ASC),
        CONSTRAINT [FK_Barcos_Personas] FOREIGN KEY ([IdOwner]) REFERENCES [dbo].[Personas] ([IdPersona])
    );
END
GO

-- 4. CREAR TABLA: Salidas
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Salidas]') AND type in (N'U'))
BEGIN
    CREATE TABLE [dbo].[Salidas] (
        [IdSalida] INT IDENTITY(1,1) NOT NULL,
        [FechaHoraSalida] DATETIME NOT NULL,
        [Destino] NVARCHAR(200) NOT NULL,
        [Estado] NVARCHAR(50) NOT NULL DEFAULT 'En Viaje', -- "En Viaje" o "Terminada"
        [IdBarco] INT NOT NULL,
        [IdPersona] INT NOT NULL, -- Capitán
        CONSTRAINT [PK_Salidas] PRIMARY KEY CLUSTERED ([IdSalida] ASC),
        CONSTRAINT [FK_Salidas_Barcos] FOREIGN KEY ([IdBarco]) REFERENCES [dbo].[Barcos] ([IdBarco]),
        CONSTRAINT [FK_Salidas_Personas] FOREIGN KEY ([IdPersona]) REFERENCES [dbo].[Personas] ([IdPersona])
    );
END
GO


-- ==========================================================
-- 5. PROCEDIMIENTOS ALMACENADOS
-- ==========================================================

-- SP: SP_InsertarSalida
-- Este es el procedimiento modificado que asegura que cuando un barco
-- sale, automáticamente marca al Barco y al Capitán como NO DISPONIBLES (Disponibilidad = 0).
CREATE OR ALTER PROCEDURE [dbo].[SP_InsertarSalida]
    @FechaHoraSalida DATETIME,
    @Destino NVARCHAR(200),
    @Estado NVARCHAR(50),
    @IdBarco INT,
    @IdPersona INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- 1. Registrar la salida
        INSERT INTO [dbo].[Salidas] (FechaHoraSalida, Destino, Estado, IdBarco, IdPersona)
        VALUES (@FechaHoraSalida, @Destino, @Estado, @IdBarco, @IdPersona);

        -- 2. Marcar al Barco como NO DISPONIBLE (en viaje)
        UPDATE [dbo].[Barcos]
        SET Disponibilidad = 0
        WHERE IdBarco = @IdBarco;

        -- 3. Marcar al Capitán como NO DISPONIBLE (en viaje)
        UPDATE [dbo].[Personas]
        SET Disponibilidad = 0
        WHERE IdPersona = @IdPersona;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO

-- SP: SP_TerminarSalida
-- Procedimiento para finalizar un viaje y volver a poner disponibles al Barco y al Capitán
CREATE OR ALTER PROCEDURE [dbo].[SP_TerminarSalida]
    @IdSalida INT
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @IdBarco INT, @IdCapitan INT;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Obtener los IDs del barco y del capitán involucrados en la salida
        SELECT @IdBarco = IdBarco, @IdCapitan = IdPersona
        FROM [dbo].[Salidas]
        WHERE IdSalida = @IdSalida;

        IF @IdBarco IS NOT NULL
        BEGIN
            -- 1. Actualizar el estado de la salida a Terminada
            UPDATE [dbo].[Salidas]
            SET Estado = 'Terminada'
            WHERE IdSalida = @IdSalida;

            -- 2. Volver a marcar el Barco como DISPONIBLE
            UPDATE [dbo].[Barcos]
            SET Disponibilidad = 1
            WHERE IdBarco = @IdBarco;

            -- 3. Volver a marcar al Capitán como DISPONIBLE
            UPDATE [dbo].[Personas]
            SET Disponibilidad = 1
            WHERE IdPersona = @IdCapitan;
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        THROW;
    END CATCH
END
GO
