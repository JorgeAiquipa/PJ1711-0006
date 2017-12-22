IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_set54]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_set54;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.18
-- Update date: 2017.12.21 -> devuelve el id del cargo registrado.
-- Table : T_R29
-- Descripcion : Insertamos los cargos, hora entrada, hora salida dias por semana para mano de obra
-- =============================================
CREATE PROCEDURE pa_set54
 @p_TR29_TR28_ID int -- codigo servicio _al que pertenece
,@p_TR29_TM38_ID varchar(10) -- id cargo
,@p_TR29_HORA_ENTRADA datetime 
,@p_TR29_HORA_SALIDA datetime
,@p_TR29_DIAS_SEMANA int
,@p_TR29_DESCRIP varchar(3000)
--,@p_TR29_ST smallint
--,@p_TR29_FLG_ELIMINADO smallint
,@p_TR29_UCREA varchar(20)
--,@p_TR29_FCREA datetime
--,@p_TR29_UACTUALIZA varchar
--,@p_TR29_FACTUALIZA datetime
,@p_TR29_REMUNERACION decimal
,@p_TR29_TM2_ID varchar(10)
,@P_MENSAJE_RESPUESTA varchar(200) output
,@p_TR29_ID int output--id de la tabla
AS

BEGIN
	
		DECLARE @L_TR29_ID INT

		SET @L_TR29_ID = (SELECT CAST((ISNULL(MAX(TR29_ID),0)+1) AS int) FROM DBO.T_R29)

		INSERT INTO DBO.T_R29
		(
			 TR29_ID
			,TR29_TR28_ID
			,TR29_TM38_ID
			,TR29_HORA_ENTRADA
			,TR29_HORA_SALIDA
			,TR29_DIAS_SEMANA
			,TR29_DESCRIP
			,TR29_ST
			,TR29_FLG_ELIMINADO
			,TR29_UCREA
			,TR29_FCREA
			,TR29_UACTUALIZA
			,TR29_FACTUALIZA
			,TR29_REMUNERACION
			,TR29_TM2_ID
		)

		VALUES

		(
			 @L_TR29_ID
			,@p_TR29_TR28_ID
			,@p_TR29_TM38_ID
			,@p_TR29_HORA_ENTRADA
			,@p_TR29_HORA_SALIDA
			,@p_TR29_DIAS_SEMANA
			,@p_TR29_DESCRIP
			,1
			,0
			,@p_TR29_UCREA
			,GETDATE()
			,@p_TR29_UCREA
			,GETDATE()
			,@p_TR29_REMUNERACION
			,@p_TR29_TM2_ID
		)

		SET @p_TR29_ID = @L_TR29_ID

		IF @@ROWCOUNT <= 0  
			SET @P_MENSAJE_RESPUESTA = 'ERROR'
END
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *
