sp_RENAME 'IntensidadHoraria.Anio' , 'IdAnioLectivo', 'COLUMN'
GO

ALTER TABLE IntensidadHoraria
ALTER COLUMN IdAnioLectivo INT NOT NULL
GO

UPDATE IntensidadHoraria
SET IdAnioLectivo = (SELECT TOP(1) Id FROM AnioLectivo)
GO

ALTER TABLE IntensidadHoraria
ADD CONSTRAINT FK_IntensidadHoraria_AnioLectivo FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo(Id)
GO