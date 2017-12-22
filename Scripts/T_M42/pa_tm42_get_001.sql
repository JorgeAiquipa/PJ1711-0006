IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tm42_get_001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tm42_get_001;
GO

-- =============================================
-- Author:		diego.gomez
-- Create date: 2017.12.22
-- Descripcion : Obtiene una lista de los tipo de servicio registrados de acuerdo
-- a una condicion establecida.
-- =============================================
CREATE PROCEDURE pa_tm42_get_001	
	--@p_TM42_ID varchar(50)
AS

BEGIN TRY
	
	SET NOCOUNT ON;


		SELECT 

		TM42_ID
		,TM42_DESCRIP
		,TM42_ST
		,TM42_FLG_ELIMINADO
		,TM42_UCREA
		,TM42_FCREA
		,TM42_UACTUALIZA
		,TM42_FACTUALIZA

		FROM

		T_M42

		--WHERE 
		--TM42_ID like @p_TM42_ID
		 

END TRY
BEGIN CATCH
	ROLLBACK TRAN
	
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *

