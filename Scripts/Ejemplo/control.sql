SELECT 
-- *
CONCAT('public string _',COLUMN_NAME,'{get; set;}') 
FROM INFORMATION_SCHEMA.COLUMNS

WHERE TABLE_NAME = 'T_M39'

-- CREAMOS UN CODIGO PARA LA COTIZACION 

