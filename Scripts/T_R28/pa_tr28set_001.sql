IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tr28set_001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tr28set_001;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.15
-- Descripcion : Insertamos el servicio padre asociado a una cotizacion
-- =============================================
CREATE PROCEDURE pa_tr28set_001
		 @p_TR28_PADRE int OUTPUT-- ID SERVICIO PADRE EL PRINCIPAL
		,@P_MENSAJE_RESPUESTA VARCHAR(200) OUTPUT

		,@p_TR28_TM39_ID varchar(20) -- ID COTIZACION
		,@p_TR28_TM41_ID int -- ID SERVICIO
		,@p_TR28_PERIODO int 
		,@p_TR28_DESCRIP varchar(3000)
		--,@p_TR28_ST smallint  -- 1
		--,@p_TR28_FLG_ELIMINADO smallint -- 0
		,@p_TR28_UCREA varchar(20)
		--,@p_TR28_FCREA datetime
		--,@p_TR28_UACTUALIZA varchar
		--,@p_TR28_FACTUALIZA datetime
		,@p_TR28_TM2_ID varchar(50) -- PIS
AS

BEGIN TRY
	
SET NOCOUNT ON;

		DECLARE @L_TR28_ID INT

		SET @L_TR28_ID = (SELECT CAST((ISNULL(MAX(TR28_ID),0)+1) AS int) FROM DBO.T_R28)

		INSERT INTO DBO.T_R28
		(
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
		)

		VALUES

		(
			 @L_TR28_ID
			,@L_TR28_ID
			,@p_TR28_TM39_ID
			,@p_TR28_TM41_ID
			,@p_TR28_PERIODO
			,@p_TR28_DESCRIP
			,1
			,0
			,@p_TR28_UCREA
			,GETDATE()
			,@p_TR28_UCREA
			,GETDATE()
			,@p_TR28_TM2_ID
		)

		SET @p_TR28_PADRE = @L_TR28_ID
		


		IF @@ROWCOUNT <= 0  
			SET @P_MENSAJE_RESPUESTA = 'ERROR'
END TRY
BEGIN CATCH
	ROLLBACK TRAN
		SET @P_MENSAJE_RESPUESTA = 'ERROR'
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *

