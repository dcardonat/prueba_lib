IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID('dbo.ConsultarDocumentosSoportePorRolSeleccionados') AND type in ('P', 'PC'))
	DROP PROCEDURE dbo.ConsultarDocumentosSoportePorRolSeleccionados
GO

-- ==============================================================================================================================
-- Author:		<José Manuel Gómez López>
-- Create date: <13/07/2015>
-- Description:	<Consulta los documentos de soporte a un rol asociado estableciendo los que fueron recibidos y los que no.>
-- ==============================================================================================================================
CREATE PROCEDURE dbo.ConsultarDocumentosSoportePorRolSeleccionados
	@idRolInstitucional AS INT,
	@idSede AS INT,
	@annio AS SMALLINT,
	@idDocente AS INT
AS
BEGIN
	
	SET NOCOUNT ON;

	SELECT d.Id 'IdDocenteDocumentoSoporte',
		   b.Id 'IdSoportePorRolDocumento',
		   c.Descripcion 'Documento',
		   CAST(ISNULL(d.Id, 0) AS BIT) 'Recibido'
	FROM dbo.SoportePorRoles a
	INNER JOIN dbo.SoportePorRolesDocumentos b
			ON a.Id = b.IdSoportePorRoles
	INNER JOIN dbo.Maestros c
			ON b.IdTipoDocumentoSoporte = c.Id
	LEFT JOIN dbo.DocentesDocumentosSoporte d
		   ON b.Id = d.IdDocumento
	WHERE (@idDocente IS NULL OR d.IdDocente = @idDocente) AND
	      a.IdRolInstitucional = @idRolInstitucional AND
		  a.IdSede = @idSede AND
		  a.AnioEscolar = @annio

END
GO