ALTER TABLE dbo.DocentesDatosPersonales ADD IdGradoEscalafon INT NULL;
ALTER TABLE dbo.DocentesDatosPersonales ADD FechaUltimoAscenso DATE NULL;

ALTER TABLE dbo.DocentesDatosPersonales ALTER COLUMN CorreoElectronico VARCHAR(150) NULL;
ALTER TABLE dbo.DocentesDatosPersonales ALTER COLUMN IdEstadoCivil INT NULL;