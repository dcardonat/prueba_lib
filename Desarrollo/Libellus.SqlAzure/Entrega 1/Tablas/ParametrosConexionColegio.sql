/*
	<Summary>Almacena la información de los parametros para conectarse al colego.<Summary>
*/

IF OBJECT_ID('dbo.ParametrosConexionColegio', 'U') IS NOT NULL
 DROP TABLE dbo.ParametrosConexionColegio
GO

CREATE TABLE ParametrosConexionColegio
(
	CodigoColegio varchar(4) NOT NULL,
	Servidor varchar(50) NOT NULL,
	NombreUsuario varchar(50) NOT NULL,
	Contrasena varchar(50) NOT NULL,
	BaseDatos varchar(50) NOT NULL,
	Puerto varchar(4) NOT NULL,
	HostRedisCache varchar(50) NOT NULL,
	ContrasenaRedisCache varchar(50) NOT NULL
	CONSTRAINT PK_ParametrosConexionColegio PRIMARY KEY (CodigoColegio)
)
GO