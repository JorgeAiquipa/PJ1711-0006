IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tm31_get_001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tm31_get_001;
GO

-- =============================================
-- Author:		diego.gomez
-- Create date: 2017.12.18
-- Descripcion : Obtiene una lista de los servicios registrados de acuerdo
-- a una condicion establecida.
-- =============================================
CREATE PROCEDURE pa_tm31_get_001
	@p_TM31_TM2_ID varchar(50),
	@p_filtro varchar(50)
AS

BEGIN TRY
	
	SET NOCOUNT ON;


		SELECT 
			 TM31_ID
			,TM31_TM2_ID
			,TM31_DESCRIP

			,TM31_TM34_ID
			,TM31_TM33_ID
			,TM31_TM72_ID
			,TM31_PRECIO
			--,TM31_UCREA
			--,TM31_FCREA
			--,TM31_UACTUALIZA
			--,TM31_FACTUALIZA

		FROM

		T_M31

		WHERE 
		TM31_TM2_ID like @p_TM31_TM2_ID and TM31_TM34_ID in ('MQ', 'EQ')  and TM31_DESCRIP like concat(@p_filtro,'%')

END TRY
BEGIN CATCH
	ROLLBACK TRAN
	
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *

EXEC pa_tm31_get_001 'pis' , 'l'

SELECT * FROM T_M31 where TM31_TM34_ID in ('MQ', 'EQ') 


INSERT INTO T_M31 VALUES ('PRO04','PIS','EQ','','','','SONNY','KLG','4','TV',4.5,'',1,0,'',GETDATE(),'',GETDATE())


GO


