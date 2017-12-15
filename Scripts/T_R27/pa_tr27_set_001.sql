IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tr27_set_001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tr27_set_001;
GO

-- =============================================
-- Author:		Diego.Gomez
-- Create date: 2017.12.14
-- Descripcion : Insertamos el local para de la cotizacion.
-- =============================================
CREATE PROCEDURE pa_tr27_set_001

 @p_TM39_ID varchar(20)
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

,@p_Mensaje varchar(200) output
AS
BEGIN TRY
		INSERT INTO dbo.T_R27
		(
		 TR27_ID
		,TR27_TM39_ID
	    ,TR27_TM27_ID
        ,TR27_TM19_ID
		,TR27_TM2_ID

		,TR27_DESCRIP
		,TR27_UCREA
		,TR27_FCREA
		,TR27_UACTUALIZA
		,TR27_FACTUALIZA)
		VALUES
		(
		 (SELECT ISNULL(MAX(TR27_ID),0)+1 FROM DBO.T_R27),
		 @p_TM39_ID
		,@p_TM27_ID
		,@p_TM19_ID
		,@p_TM2_ID

		,@p_TR27_DESCRIP
		,@p_TR27_UCREA
		,GETDATE()
		,@p_TR27_UCREA
		,GETDATE()
		)

		if (@@ROWCOUNT <= 0)
			BEGIN
				set @p_Mensaje = concat('Ocurrio un error al registrar la el local de la cotizacion ',@p_TM39_ID)
			END
END TRY
BEGIN CATCH
	ROLLBACK TRAN
	--IF @@TRANCOUNT > 0 ROLLBACK;  
			set @p_Mensaje = 'Ocurrio un error al registrar el local para la cotizacion roll'
END CATCH
GO


SELECT * FROM T_R27

EXEC pa_tr27_set_001 'COT00010','51','E134','PIS','DESCRIPCION','USER',''