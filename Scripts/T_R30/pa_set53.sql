IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_set53]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_set53;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.21
-- Table : T_R30 -> cargo por concepto remunerativo
-- Descripcion : Insertamos los conceptos remunerativos que posee un tipo de operario
-- =============================================
CREATE PROCEDURE pa_set53
 --@p_TR30_ID int 
 @p_TR30_TR29_ID int -- tr_29 id cargo registrado
,@p_TR30_TM40_ID varchar(10) -- tm_40 id concepto remunerativo
--,@p_TR30_IMPORTE decimal(10,2) 
--,@p_TR30_DESCRIP varchar(3000) --
,@p_TR30_TM2_ID varchar(10) --pis
--,@p_TR30_ST smallint
--,@p_TR30_FLG_ELIMINADO smallint
,@p_TR30_UCREA varchar(20)
--,@p_TR30_FCREA datetime
--,@p_TR30_UACTUALIZA varchar(20)
--,@p_TR30_FACTUALIZA datetime
,@P_MENSAJE_RESPUESTA varchar(200) output
AS

BEGIN TRY
	
SET NOCOUNT ON;

		DECLARE @L_TR30_ID INT

		SET @L_TR30_ID = (SELECT CAST((ISNULL(MAX(TR30_ID),0)+1) AS int) FROM DBO.T_R30)

		INSERT INTO DBO.T_R30
		(
			 TR30_ID
			,TR30_TR29_ID
			,TR30_TM40_ID
			--,TR30_IMPORTE
			--,TR30_DESCRIP
			,TR30_TM2_ID
			,TR30_ST
			,TR30_FLG_ELIMINADO
			,TR30_UCREA
			,TR30_FCREA
			,TR30_UACTUALIZA
			,TR30_FACTUALIZA
		)

		VALUES

		(
			 @L_TR30_ID
			,@p_TR30_TR29_ID
			,@p_TR30_TM40_ID
			--,@p_TR30_IMPORTE
			--,@p_TR30_DESCRIP
			,@p_TR30_TM2_ID
			,1
			,0
			,@p_TR30_UCREA
			,GETDATE()
			,@p_TR30_UCREA
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

select * from T_R30