ALTER TABLE ParametrizacionInstitucional
DROP CONSTRAINT UQ_ParametrizacionInstitucional_AnoEscolar_Horario_NivelEducativo
GO

sp_RENAME 'ParametrizacionInstitucional.AnoEscolar' , 'IdAnioLectivo', 'COLUMN'
GO

ALTER TABLE ParametrizacionInstitucional
ALTER COLUMN IdAnioLectivo INT NOT NULL
GO

UPDATE ParametrizacionInstitucional
SET IdAnioLectivo = (SELECT TOP(1) Id FROM AnioLectivo)
GO

ALTER TABLE ParametrizacionInstitucional
ADD CONSTRAINT FK_ParametrizacionInstitucional_AnioLectivo FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo(Id)
GO

ALTER TABLE ParametrizacionInstitucional 
ADD CONSTRAINT UQ_ParametrizacionInstitucional_IdAnioLectivo_Horario_NivelEducativo UNIQUE (IdAnioLectivo, IdHorario, IdNivelEducativo)
GO