IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tr29get_001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tr29get_001;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.19
-- Descripcion : Obtiene una lista de los cargos asociados a un servicio que pertenece a una cotizacion.
-- =============================================
CREATE PROCEDURE pa_tr29get_001
	@p_TR29_TR28_ID int,
	@p_TR29_TM2_ID varchar(20)
AS

BEGIN TRY
	
	SET NOCOUNT ON;


		SELECT 

			 TR29_ID
			,TR29_TR28_ID
			,TR29_TM38_ID
			,TR29_HORA_ENTRADA--, CONVERT(VARCHAR(8),TR29_HORA_ENTRADA,108)
			,TR29_HORA_SALIDA--, CONVERT(VARCHAR(8),TR29_HORA_SALIDA,108)
			,TR29_DIAS_SEMANA
			,TR29_DESCRIP
			,TR29_ST
			,TR29_FLG_ELIMINADO
			,TR29_UCREA
			,TR29_FCREA
			,TR29_UACTUALIZA
			,TR29_FACTUALIZA
			,TR29_REMUNERACION
			,TR29_TM2_ID

		FROM

			DBO.T_R29

		WHERE

			TR29_TM2_ID = @p_TR29_TM2_ID
			AND
			TR29_TR28_ID = @p_TR29_TR28_ID

END TRY
BEGIN CATCH
	ROLLBACK TRAN
	
END CATCH
GO
