IF EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[pa_tm19_get_001]') AND type in (N'P', N'PC')) --#1
Drop procedure [dbo].pa_tm19_get_001;
GO

-- =============================================
-- Author:		cesar.freitas
-- Create date: 2017.12.12
-- Descripcion : Obtiene una lista de clientes de acuerdo a 
-- la condicion de busqueda ruc o razon social.
-- =============================================
CREATE PROCEDURE pa_tm19_get_001
	--@p_mensaje_respuesta varchar(250) output,
	@p_filtro varchar(50)
AS

BEGIN TRY
	
	SET NOCOUNT ON;


	SELECT
		 TM19_ID
		,TM19_TM2_ID
		,TM19_TM75_ID
		,TM19_DESCRIP1
		,TM19_DESCRIP2
		,TM19_TM21_ID
		,TM19_UCREA
		,TM19_FCREA
		,TM19_UACTUALIZA
		,TM19_FACTUALIZA
	FROM 
		T_M19
	WHERE

		TM19_DESCRIP1 LIKE CONCAT('%',@p_filtro,'%') OR
		TM19_DESCRIP2 LIKE CONCAT(@p_filtro,'%')

END TRY
BEGIN CATCH
	ROLLBACK TRAN
	--SET @p_mensaje_respuesta = ERROR_MESSAGE()
END CATCH
GO

--   *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *  *
