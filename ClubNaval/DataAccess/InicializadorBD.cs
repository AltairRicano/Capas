using System;
using System.Data.SqlClient;

namespace DataAccess
{
    public class InicializadorBD
    {
        private string cadena;

        public InicializadorBD()
        {
            cadena = new Conexion().CadenaConexion;
        }

        public void InicializarTodo()
        {
            CrearTablas();
            CrearStoredProcedures();
        }

        private void Ejecutar(string sql)
        {
            using (SqlConnection cnn = new SqlConnection(cadena))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(sql, cnn);
                cmd.ExecuteNonQuery();
            }
        }

        private bool ExisteTabla(string nombre)
        {
            using (SqlConnection cnn = new SqlConnection(cadena))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(
                    $"SELECT COUNT(*) FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_NAME = '{nombre}'", cnn);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private bool ExisteSP(string nombre)
        {
            using (SqlConnection cnn = new SqlConnection(cadena))
            {
                cnn.Open();
                SqlCommand cmd = new SqlCommand(
                    $"SELECT COUNT(*) FROM sys.procedures WHERE name = '{nombre}'", cnn);
                return (int)cmd.ExecuteScalar() > 0;
            }
        }

        private void CrearTablas()
        {
            if (!ExisteTabla("Personas"))
                Ejecutar(@"CREATE TABLE Personas (
                    IdPersona     INT IDENTITY(1,1) PRIMARY KEY,
                    Nombre        VARCHAR(50)  NOT NULL,
                    Telefono      NVARCHAR(20) NOT NULL,
                    Direccion     VARCHAR(100) NOT NULL,
                    Correo        VARCHAR(100) NOT NULL,
                    Cargo         INT          NOT NULL,
                    Disponibilidad BIT         NOT NULL DEFAULT 1,
                    UrlFoto       VARCHAR(MAX) NOT NULL DEFAULT '')");

            if (!ExisteTabla("Barcos"))
                Ejecutar(@"CREATE TABLE Barcos (
                    IdBarco       INT IDENTITY(1,1) PRIMARY KEY,
                    Matricula     VARCHAR(10)    NOT NULL,
                    NoAmarre      VARCHAR(5)     NOT NULL,
                    Nombre        VARCHAR(25)    NOT NULL,
                    Cuota         DECIMAL(10,2)  NOT NULL,
                    IdOwner       INT            NOT NULL,
                    Disponibilidad BIT           NOT NULL DEFAULT 1,
                    UrlFoto       VARCHAR(MAX)   NOT NULL DEFAULT '',
                    CONSTRAINT FK_Barcos_Personas FOREIGN KEY (IdOwner)
                        REFERENCES Personas(IdPersona))");

            if (!ExisteTabla("Salidas"))
                Ejecutar(@"CREATE TABLE Salidas (
                    IdSalida        INT IDENTITY(1,1) PRIMARY KEY,
                    FechaHoraSalida DATETIME     NOT NULL,
                    Destino         VARCHAR(MAX) NOT NULL,
                    Estado          VARCHAR(25)  NOT NULL,
                    IdBarco         INT          NULL,
                    IdPersona       INT          NULL,
                    CONSTRAINT FK_Salidas_Barcos   FOREIGN KEY (IdBarco)
                        REFERENCES Barcos(IdBarco),
                    CONSTRAINT FK_Salidas_Personas FOREIGN KEY (IdPersona)
                        REFERENCES Personas(IdPersona))");
        }

        private void CrearStoredProcedures()
        {
            if (!ExisteSP("SP_InsertarPersona"))
                Ejecutar(@"CREATE PROCEDURE SP_InsertarPersona
                    @Nombre VARCHAR(50), @Direccion VARCHAR(100),
                    @Telefono NVARCHAR(20), @Correo VARCHAR(100),
                    @Cargo INT, @UrlFoto VARCHAR(MAX)
                AS BEGIN
                    INSERT INTO Personas(Nombre,Direccion,Telefono,Correo,Cargo,Disponibilidad,UrlFoto)
                    VALUES(@Nombre,@Direccion,@Telefono,@Correo,@Cargo,1,@UrlFoto)
                END");

            if (!ExisteSP("SP_ActualizarPersona"))
                Ejecutar(@"CREATE PROCEDURE SP_ActualizarPersona
                    @IdPersona INT, @Nombre VARCHAR(50), @Direccion VARCHAR(100),
                    @Telefono NVARCHAR(20), @Correo VARCHAR(100),
                    @Cargo INT, @UrlFoto VARCHAR(MAX), @Disponibilidad BIT
                AS BEGIN
                    UPDATE Personas SET Nombre=@Nombre, Direccion=@Direccion,
                    Telefono=@Telefono, Correo=@Correo, Cargo=@Cargo,
                    UrlFoto=@UrlFoto, Disponibilidad=@Disponibilidad
                    WHERE IdPersona=@IdPersona
                END");

            if (!ExisteSP("SP_EliminarPersona"))
                Ejecutar(@"CREATE PROCEDURE SP_EliminarPersona @IdPersona INT
                AS BEGIN
                    UPDATE Personas SET Disponibilidad=0 WHERE IdPersona=@IdPersona
                END");

            if (!ExisteSP("SP_ConsultarPersonaPorId"))
                Ejecutar(@"CREATE PROCEDURE SP_ConsultarPersonaPorId @IdPersona INT
                AS BEGIN
                    SELECT IdPersona,Nombre,Direccion,Telefono,Correo,Cargo,Disponibilidad,UrlFoto
                    FROM Personas WHERE IdPersona=@IdPersona
                END");

            if (!ExisteSP("SP_ConsultarPersonas"))
                Ejecutar(@"CREATE PROCEDURE SP_ConsultarPersonas @Disponibilidad BIT
                AS BEGIN
                    SELECT IdPersona,Nombre,Direccion,Telefono,Correo,Cargo,Disponibilidad,UrlFoto
                    FROM Personas
                    WHERE (@Disponibilidad IS NULL OR Disponibilidad=@Disponibilidad)
                END");

            if (!ExisteSP("SP_ConsultarPersonasPorCargo"))
                Ejecutar(@"CREATE PROCEDURE SP_ConsultarPersonasPorCargo
                    @Cargo INT, @Disponibilidad BIT
                AS BEGIN
                    SELECT IdPersona,Nombre,Direccion,Telefono,Correo,Cargo,Disponibilidad,UrlFoto
                    FROM Personas
                    WHERE Cargo=@Cargo
                    AND (@Disponibilidad IS NULL OR Disponibilidad=@Disponibilidad)
                END");

            if (!ExisteSP("SP_InsertarBarco"))
                Ejecutar(@"CREATE PROCEDURE SP_InsertarBarco
                    @Matricula VARCHAR(10), @NoAmarre VARCHAR(5),
                    @Nombre VARCHAR(25), @Cuota DECIMAL(10,2),
                    @IdOwner INT, @UrlFoto VARCHAR(MAX)
                AS BEGIN
                    INSERT INTO Barcos(Matricula,NoAmarre,Nombre,Cuota,IdOwner,Disponibilidad,UrlFoto)
                    VALUES(@Matricula,@NoAmarre,@Nombre,@Cuota,@IdOwner,1,@UrlFoto)
                END");

            if (!ExisteSP("SP_ActualizarBarco"))
                Ejecutar(@"CREATE PROCEDURE SP_ActualizarBarco
                    @IdBarco INT, @Matricula VARCHAR(10), @NoAmarre VARCHAR(5),
                    @Nombre VARCHAR(25), @Cuota DECIMAL(10,2),
                    @IdOwner INT, @UrlFoto VARCHAR(MAX), @Disponibilidad BIT
                AS BEGIN
                    UPDATE Barcos SET Matricula=@Matricula, NoAmarre=@NoAmarre,
                    Nombre=@Nombre, Cuota=@Cuota, IdOwner=@IdOwner,
                    UrlFoto=@UrlFoto, Disponibilidad=@Disponibilidad
                    WHERE IdBarco=@IdBarco
                END");

            if (!ExisteSP("SP_EliminarBarco"))
                Ejecutar(@"CREATE PROCEDURE SP_EliminarBarco @IdBarco INT
                AS BEGIN
                    UPDATE Barcos SET Disponibilidad=0 WHERE IdBarco=@IdBarco
                END");

            if (!ExisteSP("SP_ConsultarBarcos"))
                Ejecutar(@"CREATE PROCEDURE SP_ConsultarBarcos @Disponibilidad BIT
                AS BEGIN
                    SELECT IdBarco,Matricula,NoAmarre,Nombre,Cuota,
                           IdOwner AS IdPersona,Disponibilidad,UrlFoto
                    FROM Barcos
                    WHERE (@Disponibilidad IS NULL OR Disponibilidad=@Disponibilidad)
                END");

            if (!ExisteSP("SP_ConsultarBarcoPorId"))
                Ejecutar(@"CREATE PROCEDURE SP_ConsultarBarcoPorId @IdBarco INT
                AS BEGIN
                    SELECT IdBarco,Matricula,NoAmarre,Nombre,Cuota,
                           IdOwner AS IdPersona,Disponibilidad,UrlFoto
                    FROM Barcos WHERE IdBarco=@IdBarco
                END");

            if (!ExisteSP("SP_InsertarSalida"))
                Ejecutar(@"CREATE PROCEDURE SP_InsertarSalida
                    @FechaHoraSalida DATETIME, @Destino VARCHAR(MAX),
                    @Estado VARCHAR(25), @IdBarco INT, @IdCapitan INT
                AS BEGIN
                    SET NOCOUNT ON;
                    BEGIN TRY
                        BEGIN TRANSACTION;

                        INSERT INTO Salidas(FechaHoraSalida,Destino,Estado,IdBarco,IdPersona)
                        VALUES(@FechaHoraSalida,@Destino,@Estado,@IdBarco,@IdCapitan);

                        UPDATE Barcos SET Disponibilidad = 0 WHERE IdBarco = @IdBarco;
                        UPDATE Personas SET Disponibilidad = 0 WHERE IdPersona = @IdCapitan;

                        COMMIT TRANSACTION;
                    END TRY
                    BEGIN CATCH
                        ROLLBACK TRANSACTION;
                        THROW;
                    END CATCH
                END");

            if (!ExisteSP("SP_FinalizarSalida"))
                Ejecutar(@"CREATE PROCEDURE SP_FinalizarSalida
                    @IdSalida INT, @Estado VARCHAR(25)
                AS BEGIN
                    SET NOCOUNT ON;
                    DECLARE @IdBarco INT, @IdCapitan INT;

                    BEGIN TRY
                        BEGIN TRANSACTION;

                        SELECT @IdBarco = IdBarco, @IdCapitan = IdPersona
                        FROM Salidas WHERE IdSalida = @IdSalida;

                        IF @IdBarco IS NOT NULL
                        BEGIN
                            UPDATE Salidas SET Estado=@Estado WHERE IdSalida=@IdSalida;
                            UPDATE Barcos SET Disponibilidad = 1 WHERE IdBarco = @IdBarco;
                            UPDATE Personas SET Disponibilidad = 1 WHERE IdPersona = @IdCapitan;
                        END

                        COMMIT TRANSACTION;
                    END TRY
                    BEGIN CATCH
                        ROLLBACK TRANSACTION;
                        THROW;
                    END CATCH
                END");

            if (!ExisteSP("SP_EliminarSalida"))
                Ejecutar(@"CREATE PROCEDURE SP_EliminarSalida @IdSalida INT
                AS BEGIN
                    UPDATE Salidas SET Estado='ELIMINADA' WHERE IdSalida=@IdSalida
                END");

            if (!ExisteSP("SP_ConsultarSalidasPorEstadoExtendida"))
                Ejecutar(@"CREATE PROCEDURE SP_ConsultarSalidasPorEstadoExtendida
                    @Estado VARCHAR(25) = NULL
                AS BEGIN
                    SELECT s.IdSalida, s.FechaHoraSalida, s.Destino, s.Estado,
                           s.IdBarco,
                           s.IdPersona AS IdCapitan,
                           p.Nombre AS NombreCapitan, p.UrlFoto AS UrlFotoCapitan,
                           b.Nombre AS NombreBarco, b.UrlFoto AS UrlFotoBarco
                    FROM Salidas s
                    INNER JOIN Personas p ON s.IdPersona=p.IdPersona
                    INNER JOIN Barcos b ON s.IdBarco=b.IdBarco
                    WHERE (@Estado IS NULL OR s.Estado=@Estado)
                END");

            if (!ExisteSP("SP_ConsultarSalidasPorIdExtendida"))
                Ejecutar(@"CREATE PROCEDURE SP_ConsultarSalidasPorIdExtendida
                    @IdSalida INT
                AS BEGIN
                    SELECT s.IdSalida, s.FechaHoraSalida, s.Destino, s.Estado,
                           s.IdBarco,
                           s.IdPersona AS IdCapitan,
                           p.Nombre AS NombreCapitan, p.UrlFoto AS UrlFotoCapitan,
                           b.Nombre AS NombreBarco, b.UrlFoto AS UrlFotoBarco
                    FROM Salidas s
                    INNER JOIN Personas p ON s.IdPersona=p.IdPersona
                    INNER JOIN Barcos b ON s.IdBarco=b.IdBarco
                    WHERE s.IdSalida=@IdSalida
                END");
        }
    }
}