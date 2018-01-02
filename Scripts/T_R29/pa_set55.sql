IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_set55]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_set55;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.28
-- Descripcion : actualizamos los cargos manipulados desde la solucion
-- =============================================
CREATE PROCEDURE pa_set55
 @p_TR29_TR28_ID int -- codigo servicio _al que pertenece
,@p_TR29_TM38_ID varchar(10) -- id cargo
,@p_TR29_TM2_ID VARCHAR(10) -- PIS

,@p_TR29_HORA_ENTRADA datetime 
,@p_TR29_HORA_SALIDA datetime
,@p_TR29_DIAS_SEMANA int
,@p_TR29_DESCRIP varchar(3000)
,@p_TR29_FLG_ELIMINADO smallint
,@p_TR29_UACTUALIZA varchar(20)
,@p_TR29_REMUNERACION decimal
,@P_MENSAJE_RESPUESTA varchar(200) output
AS

BEGIN
	
	UPDATE DBO.T_R29
		SET		
			 TR29_HORA_ENTRADA = @p_TR29_HORA_ENTRADA
			,TR29_HORA_SALIDA = @p_TR29_HORA_SALIDA
			,TR29_DIAS_SEMANA = @p_TR29_DIAS_SEMANA
			,TR29_DESCRIP = @p_TR29_DESCRIP
			,TR29_FLG_ELIMINADO = @p_TR29_FLG_ELIMINADO
			,TR29_UACTUALIZA = @p_TR29_UACTUALIZA
			,TR29_FACTUALIZA = GETDATE()
			,TR29_REMUNERACION = @p_TR29_REMUNERACION
		WHERE 
			TR29_TM2_ID = @p_TR29_TM2_ID
			AND
			TR29_TR28_ID = @p_TR29_TR28_ID 
			AND
			TR29_TM38_ID = @p_TR29_TM38_ID

		IF @@ROWCOUNT <= 0  
			SET @P_MENSAJE_RESPUESTA = 'ERROR'
END
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *
