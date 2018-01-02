IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tm39set_001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tm39set_001;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.14
-- Descripcion : Insertamos los datos de la cotizacion iniciada.
-- =============================================
CREATE PROCEDURE pa_tm39set_001

 @p_TM39_DESCRIP varchar(3000)
--,@p_TM39_ST int
--,@p_TM39_FLG_ELIMINADO char(18)
,@p_TM39_UCREA varchar(20)
--,@p_TM39_FCREA 
--,@p_TM39_UACTUALIZA
--,@p_TM39_FACTUALIZA
,@p_TM39_TM19_ID varchar(10) -- cliente id
,@p_TM39_TM2_ID VARCHAR(10)-- PIS
,@p_CodigoCotizacion varchar(20) output
,@p_Mensaje varchar(200) output

AS

BEGIN TRY
	
	DECLARE @l_codigo_cotizacion varchar(20)

	set @l_codigo_cotizacion = (select CONCAT('COT',RIGHT((concat('000000000',CAST(RIGHT(isnull(max(TM39_ID),0),5) AS int)+1)),5)) from dbo.T_M39)
	SET NOCOUNT ON;


		INSERT INTO dbo.T_M39
		(
		 TM39_ID
		,TM39_DESCRIP
		,TM39_ST
		,TM39_FLG_ELIMINADO
		,TM39_UCREA
		,TM39_FCREA
		,TM39_UACTUALIZA
		,TM39_FACTUALIZA
		,TM39_TM19_ID
		,TM39_TM2_ID)
		VALUES
		(
		 @l_codigo_cotizacion
		,@p_TM39_DESCRIP
		, 1--@p_TM39_ST
		, 0
		,@p_TM39_UCREA
		,GETDATE()
		,@p_TM39_UCREA
		,GETDATE()
		,@p_TM39_TM19_ID
		,@p_TM39_TM2_ID
		)

		set @p_CodigoCotizacion = @l_codigo_cotizacion;

		IF @@ROWCOUNT <= 0  
			SET @p_Mensaje = 'La cotizacion no se registro.'
END TRY
BEGIN CATCH
	ROLLBACK TRAN
		SET @p_Mensaje = 'Error al registrar cotizaci�n.'
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *
