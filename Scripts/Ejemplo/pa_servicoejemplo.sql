IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_servicioejemplo]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_servicioejemplo;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.11
-- =============================================
CREATE PROCEDURE pa_servicioejemplo
	@p_mensaje_respuesta varchar output
AS

BEGIN TRY
	
	SET NOCOUNT ON;

	SELECT 

		C_ID,
		C_NOMBRE,
		C_ESTADO,
		C_DEFAULT

	FROM T_SERVICIOS
	--and a comment in the end
	SET @p_mensaje_respuesta = 'ok'

END TRY
BEGIN CATCH
	ROLLBACK TRAN
	SET @p_mensaje_respuesta = ERROR_MESSAGE()
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *


exec dbo.pa_servicioejemplo ''