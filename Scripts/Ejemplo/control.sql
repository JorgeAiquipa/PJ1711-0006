SELECT 
*
-- CONCAT(',',COLUMN_NAME)
--CONCAT('public string _',COLUMN_NAME,'{get; set;}') 
--concat(',@p_',COLUMN_NAME,' ',DATA_TYPE)
--CONCAT('_et_r31._',COLUMN_NAME,'= fila["',COLUMN_NAME,'"].ToString();')
FROM INFORMATION_SCHEMA.COLUMNS

WHERE TABLE_NAME = 'T_r31'

-- CREAMOS UN CODIGO PARA LA COTIZACION 


select * from T_m27