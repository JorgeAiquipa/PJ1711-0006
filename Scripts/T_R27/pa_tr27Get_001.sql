IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tr27Get_001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tr27Get_001;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.16
-- Descripcion : Procedimiento Obtener los locales asociados a una cotizacón.
-- =============================================
CREATE PROCEDURE pa_tr27Get_001
 @P_TR27_TM39_ID VARCHAR(20)
,@p_TR27_TM19_ID VARCHAR(50)
,@p_TR27_TM2_ID VARCHAR(50)
AS

BEGIN TRY
	
	SET NOCOUNT ON;

	SELECT

		 TR27_ID
		,TR27_TM39_ID
		,TR27_TM27_ID
		,TR27_DESCRIP
		,TR27_ST
		,TR27_FLG_ELIMINADO
		,TR27_UCREA
		,TR27_FCREA
		,TR27_UACTUALIZA
		,TR27_FACTUALIZA
		,TR27_TM19_ID
		,TR27_TM2_ID
		,M27.TM27_DIRECCION AS TR27_TM27_DIRECCION
	FROM

		DBO.T_R27 as R27 inner join DBO.T_M27 AS M27
		ON
		R27.TR27_TM27_ID = M27.TM27_ID
	WHERE
		
		R27.TR27_TM39_ID = @P_TR27_TM39_ID
		AND
		R27.TR27_TM19_ID = @p_TR27_TM19_ID
		AND
		R27.TR27_TM2_ID = @p_TR27_TM2_ID
		AND
		R27.TR27_TM27_ID = M27.TM27_ID

END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *
