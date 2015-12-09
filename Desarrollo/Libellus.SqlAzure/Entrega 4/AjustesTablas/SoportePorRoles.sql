sp_RENAME 'SoportePorRoles.AnioEscolar' , 'IdAnioLectivo', 'COLUMN'
GO

ALTER TABLE SoportePorRoles DROP CONSTRAINT AK_Anio_Rol_Nivel_Sede

ALTER TABLE SoportePorRoles
ALTER COLUMN IdAnioLectivo INT NOT NULL
GO

UPDATE SoportePorRoles
SET IdAnioLectivo = (SELECT TOP(1) Id FROM AnioLectivo)
GO

ALTER TABLE SoportePorRoles
ADD CONSTRAINT FK_SoportePorRoles_AnioLectivo FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo(Id)
GO

ALTER TABLE SoportePorRoles
ADD CONSTRAINT UQ_IdAnioLectivo_Rol_Nivel_Sede UNIQUE (IdAnioLectivo, IdRolInstitucional, IdNivelEducativo, IdSede)