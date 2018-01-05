IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tr30_set002]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tr30_set002;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2018.02.01
-- Descripcion : actualizamos los registros de conceptos remunerativos para un cargo especifico
-- =============================================
CREATE PROCEDURE pa_tr30_set002

 @p_TR30_TR29_ID int -- tr_29 id cargo registrado
,@p_TR30_ID int
,@p_TR30_TM40_ID varchar(10) -- tm_40 id concepto remunerativo
,@p_TR30_IMPORTE decimal(10,2) 
,@p_TR30_FLG_ELIMINADO int
,@p_TR30_TM2_ID varchar(10) --pis
,@p_TR30_UACTUALIZA varchar(20)
,@P_MENSAJE_RESPUESTA varchar(200) output
AS

BEGIN TRY
	
SET NOCOUNT ON;

UPDATE DBO.T_R30
	SET
		TR30_IMPORTE = @p_TR30_IMPORTE,
		TR30_FLG_ELIMINADO = @p_TR30_FLG_ELIMINADO,
		TR30_FACTUALIZA = GETDATE(),
		TR30_UACTUALIZA = @p_TR30_UACTUALIZA
	WHERE
		TR30_TM2_ID = @p_TR30_TM2_ID
		AND
		TR30_ID = @p_TR30_ID
		AND
		TR30_TR29_ID = @p_TR30_TR29_ID
		AND
		TR30_TM40_ID = @p_TR30_TM40_ID

		IF @@ROWCOUNT = 0  
			SET @P_MENSAJE_RESPUESTA = 'ERROR'
END TRY
BEGIN CATCH
	ROLLBACK TRAN
		SET @P_MENSAJE_RESPUESTA = 'ERROR'
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *
