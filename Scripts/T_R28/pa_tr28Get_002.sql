IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tr28Get_002]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tr28Get_002;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.16
-- Descripcion : Procedimiento Obtener los servicios asociados a una cotizacón.
-- =============================================
CREATE PROCEDURE pa_tr28Get_002
 @P_TR28_TM39_ID VARCHAR(20)
,@P_TR28_TM2_ID VARCHAR(50)
AS

BEGIN TRY
	
	SET NOCOUNT ON;

	SELECT

		 TR28_ID
		,TR28_PADRE
		,TR28_TM39_ID
		,TR28_TM41_ID
		,TR28_PERIODO
		,TR28_DESCRIP
		,TR28_ST
		,TR28_FLG_ELIMINADO
		,TR28_UCREA
		,TR28_FCREA
		,TR28_UACTUALIZA
		,TR28_FACTUALIZA
		,TR28_TM2_ID

	FROM

		DBO.T_R28

	WHERE

		TR28_TM39_ID = @P_TR28_TM39_ID
		AND
		TR28_TM2_ID = @P_TR28_TM2_ID
		AND
		TR28_ST > 0
		AND
		TR28_FLG_ELIMINADO = 0

END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *

select * from T_R28

exec pa_tr28Get_002 'COT00030','pis'