IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tr28set_003]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tr28set_003;
GO

-- =============================================
-- Author:		diego.gomez
-- Create date: 2018.1.2
-- Descripcion : Procedimiento para eliminar un servicio.
-- =============================================
CREATE PROCEDURE pa_tr28set_003
 @P_TR28_ID INT
,@P_TR28_TM39_ID VARCHAR(20)
,@P_TR28_TM2_ID VARCHAR(50)
AS

BEGIN TRY
	
	SET NOCOUNT ON;

	UPDATE DBO.T_R28
	SET TR28_FLG_ELIMINADO = 1,
	TR28_FACTUALIZA = GETDATE()

	WHERE

		TR28_ID = @P_TR28_ID
		AND
		TR28_TM39_ID = @P_TR28_TM39_ID
		AND
		TR28_TM2_ID = @P_TR28_TM2_ID

		
	UPDATE DBO.T_R29
	SET TR29_FLG_ELIMINADO = 1,
	TR29_FACTUALIZA = GETDATE()

	WHERE

		TR29_TR28_ID = @P_TR28_ID

	UPDATE DBO.T_R31
	SET TR31_FLG_ELIMINADO = 1,
	TR31_FACTUALIZA = GETDATE()

	WHERE

		TR31_TR28_ID = @P_TR28_ID


END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *

