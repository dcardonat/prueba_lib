ALTER TABLE AspectosEvaluativos
add IdAnioLectivo int  NULL;

ALTER TABLE AspectosEvaluativos
DROP CONSTRAINT UQ_AspectosEvaluativos;

UPDATE AspectosEvaluativos
SET AspectosEvaluativos.IdAnioLectivo = AnioLectivo.Id
FROM AspectosEvaluativos
INNER JOIN AnioLectivo ON AspectosEvaluativos.Anio = AnioLectivo.Anio

ALTER TABLE AspectosEvaluativos
DROP COLUMN Anio;

ALTER TABLE AspectosEvaluativos ADD CONSTRAINT FK_AspectosEvaluativos_AnioLectivo
FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo (Id)

ALTER TABLE AspectosEvaluativos
ALTER COLUMN IdAnioLectivo int  NOT NULL;

-----------------------------------------------------------------------
ALTER TABLE AspectosEvaluativos
add IdIntensidadHoraria int  NULL;

UPDATE AspectosEvaluativos
   SET IdIntensidadHoraria = (select top 1 id from Maestros where IdTipoMaestro = 20)
GO

ALTER TABLE AspectosEvaluativos
drop CONSTRAINT UQ_AspectosEvaluativos

ALTER TABLE AspectosEvaluativos
DROP COLUMN IntensidadHoraria;

ALTER TABLE AspectosEvaluativos
ALTER COLUMN IdIntensidadHoraria int  NOT NULL;

ALTER TABLE AspectosEvaluativos
ADD CONSTRAINT UQ_AspectosEvaluativos UNIQUE(IdAnioLectivo, IdAspectoEvaluativo, IdIntensidadHoraria, IdSede)

ALTER TABLE AspectosEvaluativos
DROP COLUMN IntensidadHoraria

ALTER TABLE AspectosEvaluativos ADD CONSTRAINT FK_AspectosEvaluativos_MaestrosIntensidadHoraria 
	FOREIGN KEY (IdIntensidadHoraria) REFERENCES Maestros (Id)
;

