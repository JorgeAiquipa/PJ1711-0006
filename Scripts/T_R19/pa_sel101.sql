IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_sel101]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_sel101;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.13
-- Descripcion : Obtiene una lista de los servicios registrados de acuerdo
-- a una condicion establecida.
-- =============================================
CREATE PROCEDURE pa_sel101
	 @p_TR19_TM2_ID varchar(50) -- pis
	 --,@p_TR19_R19_ID int
	,@p_TR19_TM42_ID int -- id tipo de servicio
AS

BEGIN TRY
	
	SET NOCOUNT ON;

		SELECT 
			T_R19_TM2_ID
			,TR19_TM41_ID
			,TR19_TM42_ID
			,TR19_VALOR
			,TR19_UCREA
			,TR19_FCREA
			,TR19_UACTUALIZA
			,TR19_FACTUALIZA
		FROM
			DBO.T_R19
		WHERE 
			T_R19_TM2_ID LIKE @p_TR19_TM2_ID 
			AND
			TR19_TM42_ID LIKE @p_TR19_TM42_ID
			--AND
			--TM42_FLG_ELIMINADO = 0
		 

END TRY
BEGIN CATCH
	ROLLBACK TRAN
	
END CATCH
GO

exec pa_sel101 'PIS', '4'



--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *

SELECT * FROM T_R19