IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tm38get_001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tm38get_001;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.13
-- Descripcion : Obtiene una lista de los cargos registrados de acuerdo
-- a una condicion establecida.
-- =============================================
CREATE PROCEDURE pa_tm38get_001
	@p_TM38_TM2_ID varchar(50),
	@p_filtro varchar(50)
AS

BEGIN TRY
	
	SET NOCOUNT ON;


		SELECT 
			 TM38_ID
			,TM38_TM2_ID
			,TM38_DESCRIP
			--,TM38_UCREA
			--,TM38_FCREA
			--,TM38_UACTUALIZA
			--,TM38_FACTUALIZA

		FROM

		T_M38

		WHERE 
		TM38_TM2_ID like @p_TM38_TM2_ID  and TM38_DESCRIP like concat(@p_filtro,'%')

END TRY
BEGIN CATCH
	ROLLBACK TRAN
	
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *
