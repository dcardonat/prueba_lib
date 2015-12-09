ALTER TABLE [dbo].[RangosDesempenio]
add [IdAnioLectivo] int  NULL;

ALTER TABLE [dbo].[RangosDesempenio]
DROP CONSTRAINT UQ_RangosDesempenio;

UPDATE RangosDesempenio
SET RangosDesempenio.IdAnioLectivo = AnioLectivo.Id
FROM RangosDesempenio
INNER JOIN AnioLectivo ON RangosDesempenio.Anio = AnioLectivo.Anio

ALTER TABLE [dbo].[RangosDesempenio]
DROP COLUMN [Anio];

ALTER TABLE RangosDesempenio ADD CONSTRAINT FK_RangosDesempenio_AnioLectivo
FOREIGN KEY (IdAnioLectivo) REFERENCES AnioLectivo (Id)

ALTER TABLE [dbo].[RangosDesempenio]
ALTER COLUMN [IdAnioLectivo] int  NOT NULL;

ALTER TABLE [dbo].[RangosDesempenio]
ADD CONSTRAINT UQ_RangosDesempenio UNIQUE(IdAnioLectivo, IdDesempenio, IdSede);

alter table [dbo].[RangosDesempenio] drop column Estado

alter table [dbo].[RangosDesempenio] alter column NotaMinima numeric(5,2) NOT NULL
alter table [dbo].[RangosDesempenio] alter  column NotaMaxima numeric(5,2) NOT NULL