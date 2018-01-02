IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tm39sel_001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tm39sel_001;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.16
-- Descripcion : Procedimiento para obtener la cabecera de una cotizacion.
-- =============================================
CREATE PROCEDURE pa_tm39sel_001
 @P_TM39_TM2_ID VARCHAR(10)-- PIS -- CODIGO DE EMPRESA
,@P_TM39_ID VARCHAR(20) -- CODIGO DE COTIZACION
,@P_TM39_TM19_ID VARCHAR(10) -- ID DEL CLIENTE
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
			,(
				select 
					COUNT(*) AS cant_locales 
				from t_R27 where 
					TR27_TM2_ID = TM39_TM2_ID AND
					TR27_TM39_ID = TM39_ID
			) as _TM39_tm27_count
			FROM

			DBO.T_M39 as _t_m39 join 
			( 
				select TM19_ID,TM19_DESCRIP1,TM19_DESCRIP2  from DBO.T_M19 as child_table 
				where child_table.tm19_tm2_id = @p_TM39_TM2_ID
			) AS _tm_19
			on
			_t_m39.TM39_TM19_ID = _tm_19.TM19_ID

			WHERE
			TM39_TM2_ID = @P_TM39_TM2_ID
			AND 
			TM39_ID = @P_TM39_ID
			AND
			TM39_TM19_ID = @P_TM39_TM19_ID

END TRY
BEGIN CATCH
	ROLLBACK TRAN
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *


