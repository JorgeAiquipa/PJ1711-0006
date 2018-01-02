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

END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *

select * from T_R28

exec pa_tr28set_003 167 ,'COT00099','pis'

exec pa_tr28Get_002 'COT00099','pis'

