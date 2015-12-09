ALTER TABLE Sedes
	ADD IdInstitucionEducativa INT NOT NULL
GO

ALTER TABLE Sedes
	ADD Seccion VARCHAR(10) NOT NULL
GO

ALTER TABLE Sedes
	ADD CONSTRAINT FK_Sedes_InstitucionEducativa FOREIGN KEY (IdInstitucionEducativa) REFERENCES InstitucionEducativa (Id)
GO