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
	@p_TM41_TM2_ID varchar(50)
	,@p_TM41_TIPO varchar(50)
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

		,T.TM41_TIPO

		FROM

		T_M41 M41 inner join TM41_TIPO T ON M41.TM41_ID=T.TM41_TIPO_ID

		WHERE 
		TM41_TM2_ID like @p_TM41_TM2_ID
		 

END TRY
BEGIN CATCH
	ROLLBACK TRAN
	
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *

