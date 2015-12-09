ALTER TABLE dbo.DocentesExperienciaLaboral DROP FK_DocenteExperienciaLaboral_Maestros;
ALTER TABLE dbo.DocentesExperienciaLaboral DROP COLUMN IdGradoEscalafon;
ALTER TABLE dbo.DocentesExperienciaLaboral DROP COLUMN FechaUltimoAscenso;

ALTER TABLE dbo.DocentesExperienciaLaboral ALTER COLUMN FechaRetiro DATE NULL;