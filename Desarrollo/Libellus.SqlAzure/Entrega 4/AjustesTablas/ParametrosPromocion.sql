ALTER TABLE [dbo].[ParametrosPromocion]
alter column [PorcentajeInasistencia] decimal(5,2) not null


ALTER TABLE [dbo].[ParametrosPromocion]
alter column [CalificacionMinimaAprobacion] decimal(3,1) not null

ALTER TABLE [dbo].[ParametrosPromocion]
add [IdAnioLectivo] int  NULL;

ALTER TABLE [dbo].[ParametrosPromocion]
DROP CONSTRAINT UQ_ParametrosPromocion;

UPDATE ParametrosPromocion
SET ParametrosPromocion.IdAnioLectivo = AnioLectivo.Id
FROM ParametrosPromocion
INNER JOIN AnioLectivo ON ParametrosPromocion.Anio = AnioLectivo.Anio

ALTER TABLE [dbo].[ParametrosPromocion]
DROP COLUMN [Anio];

ALTER TABLE ParametrosPromocion ADD CONSTRAINT FK_ParametrosPromocion_AnioLectivo
FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo (Id)

ALTER TABLE [dbo].[ParametrosPromocion]
ALTER COLUMN [IdAnioLectivo] int  NOT NULL;

ALTER TABLE [dbo].[ParametrosPromocion]
ADD CONSTRAINT UQ_ParametrosPromocion UNIQUE(IdAnioLectivo, IdSede);