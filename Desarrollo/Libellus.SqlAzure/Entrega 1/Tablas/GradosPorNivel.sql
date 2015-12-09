/*
	<Summary>Almacena los grados asociados a un nivel.<Summary>
*/

CREATE TABLE dbo.GradosPorNivel
(
	Id INT NOT NULL IDENTITY(1, 1),
	IdNivel INT NOT NULL,
	IdGrado INT NOT NULL,
    CONSTRAINT PK_Id_GradosPorNivel PRIMARY KEY (Id)
)
GO

ALTER TABLE dbo.GradosPorNivel ADD CONSTRAINT FK_Maestros_IdNivel FOREIGN KEY (IdNivel) REFERENCES dbo.Maestros(Id);
ALTER TABLE dbo.GradosPorNivel ADD CONSTRAINT FK_Maestros_IdGrado FOREIGN KEY (IdGrado) REFERENCES dbo.Maestros(Id);