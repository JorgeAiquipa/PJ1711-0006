IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tr30_sel001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tr30_sel001;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.26
-- Descripcion : Obtiene una lista de los conceptos remunarativos que posee un cargo
-- =============================================
CREATE PROCEDURE pa_tr30_sel001
	@p_TR29_ID INT,
	--@p_TM40_ID VARCHAR(20),
	@p_TM2_ID VARCHAR(10)
AS

BEGIN TRY
	
	SET NOCOUNT ON;


		SELECT 

			 TR30_ID
			,TR30_TR29_ID
			,TR30_TM40_ID
			,TR30_IMPORTE
			--,TR30_DESCRIP
			,TR30_TM2_ID
			,TR30_ST
			,TR30_FLG_ELIMINADO
			,TR30_UCREA
			,TR30_FCREA
			,TR30_UACTUALIZA
			,TR30_FACTUALIZA
			,m40.TM40_DESCRIP as TM40_DESCRIP
		FROM

			DBO.T_R30 as R30 JOIN DBO.T_M40 AS M40
			ON R30.TR30_TM40_ID = M40.TM40_ID

		WHERE
			TR30_FLG_ELIMINADO = 0
			AND
			TR30_TM2_ID = @p_TM2_ID
			AND
			TR30_TR29_ID = @p_TR29_ID


END TRY
BEGIN CATCH
	ROLLBACK TRAN
	
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *
