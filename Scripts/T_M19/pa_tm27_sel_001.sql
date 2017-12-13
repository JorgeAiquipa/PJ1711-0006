IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tm27_sel_001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tm27_sel_001;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.12
-- Descripcion : Obtiene una lista de los locales por cliente seleccionaso
-- =============================================
CREATE PROCEDURE pa_tm27_sel_001
	--@p_mensaje_respuesta varchar(250) output,
	@p_TM27_TM19_ID varchar(10)
AS

BEGIN TRY
	
	SET NOCOUNT ON;
	
	SELECT
		 TM27_ID
		,TM27_TM19_ID
		,TM27_TM2_ID
		,TM27_NOMBRE
		,TM27_DIRECCION
		--,TM27_TM9_DIST_CODIGO
		--,TM27_TM28_ID
		--,TM27_ST
		--,TM27_FLG_ELIMINADO
		--,TM27_CODGREEM
		--,TM27_UCREA
		--,TM27_FCREA
		--,TM27_UACTUALIZA
		--,TM27_FACTUALIZA
	FROM 
		T_M27
	WHERE
		TM27_TM19_ID LIKE @p_TM27_TM19_ID

END TRY
BEGIN CATCH
	ROLLBACK TRAN
	--SET @p_mensaje_respuesta = ERROR_MESSAGE()
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *

select * from T_M27;

exec pa_tm27_sel_001 'E93'


