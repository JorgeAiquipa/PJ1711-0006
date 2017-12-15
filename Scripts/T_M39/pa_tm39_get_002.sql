IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tm39_get_002]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tm39_get_002;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.15
-- Descripcion : Procedimiento para leer las cotizaciones.
-- =============================================
CREATE PROCEDURE pa_tm39get_002
 @p_TM39_TM2_ID VARCHAR(10)-- PIS
,@p_tm19_filtro varchar(50)
,@p_Fecha_Inicio DATETIME
,@p_Fecha_Fin DATETIME
AS

BEGIN TRY
	
	SET NOCOUNT ON;


			SELECT 
			 TM39_ID
			,TM39_DESCRIP
			,TM39_ST
			,TM39_FLG_ELIMINADO
			,TM39_UCREA
			,TM39_FCREA
			,TM39_UACTUALIZA
			,TM39_FACTUALIZA
			,TM39_TM19_ID
			,TM39_TM2_ID
			,_tm_19.TM19_DESCRIP1 --RUC
			,_tm_19.TM19_DESCRIP2 --RAZON SOCIAL
			,_tm_19.TM19_ID --ID ENTIDAD (CLIENTE)
			FROM

			DBO.T_M39 as _t_m39 join 
			( 
				select TM19_ID,TM19_DESCRIP1,TM19_DESCRIP2  from DBO.T_M19 as child_table 
				where child_table.tm19_tm2_id = @p_TM39_TM2_ID
			) AS _tm_19
			on
			_t_m39.TM39_TM19_ID = _tm_19.TM19_ID

			WHERE
			TM39_TM2_ID = @p_TM39_TM2_ID
			and 
			(
			_tm_19.TM19_DESCRIP1 like concat('%',@p_tm19_filtro,'%') or
			_tm_19.TM19_DESCRIP2 like concat('%',@p_tm19_filtro,'%')
			)
			and
			(
			_t_m39.TM39_FCREA between @p_Fecha_Inicio and @p_Fecha_Fin
			)

END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *
