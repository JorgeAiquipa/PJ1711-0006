IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tm41_get_001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tm41_get_001;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.13
-- Descripcion : Obtiene una lista de los servicios registrados de acuerdo
-- a una condicion establecida.
-- =============================================
CREATE PROCEDURE pa_tm41_get_001
	 @p_TM41_TM2_ID varchar(50) -- pis
	,@p_TM41_TM42_ID int -- id tipo de servicio
AS

BEGIN TRY
	
	SET NOCOUNT ON;

		SELECT 
			 TM41_ID
			,TM41_TM2_ID
			,TM41_DESCRIP
			,TM41_UCREA
			,TM41_FCREA
			,TM41_UACTUALIZA
			,TM41_FACTUALIZA
			,TM41_TM42_ID
		FROM
			DBO.T_M41
		WHERE 
			TM41_TM2_ID LIKE @p_TM41_TM2_ID 
			AND
			TM41_TM42_ID LIKE @p_TM41_TM42_ID
			AND
			TM42_FLG_ELIMINADO = 0
		 

END TRY
BEGIN CATCH
	ROLLBACK TRAN
	
END CATCH
GO

exec pa_tm41_get_001 'PIS', '4'



--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *

SELECT * FROM T_M41