ALTER PROCEDURE [dbo].[SP_ConsultarSalidasPorEstadoExtendida]
@Estado varchar(25) = NULL
AS
BEGIN
	SELECT S.IdSalida,S.FechaHoraSalida,S.Destino,S.Estado,S.IdBarco,S.IdPersona,
	B.Nombre as NombreBarco,B.UrlFoto as UrlFotoBarco,
	P.Nombre as NombreCapitan, P.UrlFoto as UrlFotoCapitan
	FROM Salidas S
	INNER JOIN Barcos B ON S.IdBarco=B.IdBarco
	INNER JOIN Personas P ON S.IdPersona=P.IdPersona
	WHERE (@Estado IS NULL OR S.Estado=@Estado)
END
