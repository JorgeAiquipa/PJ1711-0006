
IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tr31_set_001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tr31_set_001;
GO

-- =============================================
-- Author:		diego.gomez
-- Create date: 2018.1.3
-- Table : T_R31 -> Mano de obra
-- Descripcion : Insertamos los datos de mano de obra
-- =============================================
CREATE PROCEDURE pa_tr31_set_001
 @p_TR31_TR29_ID int --servicio cargo
,@p_TR31_TR27_ID int --cotizacion local
,@p_TR31_TR28_ID int --cotizacion servicio
,@p_TR31_CANT_PERSONAS smallint
,@p_TR31_DESCRIP varchar(3000)
,@p_TR31_TM2_ID varchar(10) --pis
,@p_TR31_UCREA varchar(20)
,@P_MENSAJE_RESPUESTA varchar(200) output
AS

BEGIN TRY
	
SET NOCOUNT ON;

	DECLARE @L_TR31_ID INT

		SET @L_TR31_ID = (SELECT CAST((ISNULL(MAX(TR31_ID),0)+1) AS int) FROM DBO.T_R31)

		INSERT INTO DBO.T_R31
		(
			 TR31_ID
			,TR31_TR29_ID
			,TR31_TR27_ID
			,TR31_TR28_ID
			,TR31_CANT_PERSONAS
			,TR31_DESCRIP
			,TR31_TM2_ID
			,TR31_ST
			,TR31_FLG_ELIMINADO
			,TR31_UCREA
			,TR31_FCREA
			,TR31_UACTUALIZA
			,TR31_FACTUALIZA
			
		)

		VALUES

		(
			 @L_TR31_ID
			,@p_TR31_TR29_ID
			,@p_TR31_TR27_ID
			,@p_TR31_TR28_ID
			,@p_TR31_CANT_PERSONAS
			,@p_TR31_DESCRIP
			,@p_TR31_TM2_ID
			,1
			,0
			,@p_TR31_UCREA
			,GETDATE()
			,@p_TR31_UCREA
			,GETDATE()


		)

		IF @@ROWCOUNT <= 0  
			SET @P_MENSAJE_RESPUESTA = 'ERROR'
END TRY
BEGIN CATCH
	ROLLBACK TRAN
		SET @P_MENSAJE_RESPUESTA = 'ERROR'
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *
