IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tr27_set_001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tr27_set_001;
GO

-- =============================================
-- Author:		Diego.Gomez
-- Create date: 2017.12.14
-- Descripcion : Insertamos el local para de la cotizacion.
-- =============================================
CREATE PROCEDURE pa_tr27_set_001

		 @P_MENSAJE_RESPUESTA varchar(200) output
		,@p_TM39_ID varchar(20)
		,@p_TM27_ID varchar(20)
		,@p_TM19_ID varchar(10)
		,@p_TM2_ID varchar(10)

		,@p_TR27_DESCRIP varchar(3000)
		--,@p_TR27_ST int
		--,@p_TR27_FLG_ELIMINADO char(18)
		,@p_TR27_UCREA varchar(20)
		--,@p_TR27_FCREA 
		--,@p_TR27_UACTUALIZA
		--,@p_TR27_FACTUALIZA

AS
BEGIN
		DECLARE @L_ID_LOCAL INT

		SET @L_ID_LOCAL = (SELECT CAST((ISNULL(MAX(TR27_ID),0)+1) AS INT) FROM DBO.T_R27)
		
		INSERT INTO dbo.T_R27
		(
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
		)
		VALUES
		(
			 @L_ID_LOCAL
			,@p_TM39_ID
			,@p_TM27_ID
			,@p_TR27_DESCRIP
			,1
			,0
			,@p_TR27_UCREA
			,GETDATE()
			,@p_TR27_UCREA
			,GETDATE()
			,@p_TM19_ID
			,@p_TM2_ID
		)

		IF @@ROWCOUNT <= 0
			SET @P_MENSAJE_RESPUESTA = 'ERROR TR27'
END
GO


SELECT * FROM T_M27

SELECT * FROM T_R27

--EXEC pa_tr27_set_001 'COT00010','51','E134','PIS','DESCRIPCION','USER',''
