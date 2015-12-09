ALTER TABLE dbo.DocentesEstados DROP COLUMN Estado;
ALTER TABLE dbo.DocentesEstados ADD IdEstado INT NOT NULL;

ALTER TABLE dbo.DocentesEstados ADD CONSTRAINT FK_DocentesEstados_Maestros_EstadoDocente 
	FOREIGN KEY (IdEstado) REFERENCES Maestros (Id)
;