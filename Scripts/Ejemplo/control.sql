SELECT 

--CONCAT('dgv_mano_de_obra.Columns["_',COLUMN_NAME,'"].Visible = false;')
--CONCAT(',',COLUMN_NAME)
--CONCAT('public string _',COLUMN_NAME,'{get; set;}') 
--concat(',@p_',COLUMN_NAME,' ',DATA_TYPE)
--concat(COLUMN_NAME,' ',DATA_TYPE,',')
--concat(',@p_',COLUMN_NAME)
CONCAT('_et_r30._',COLUMN_NAME,'= fila["',COLUMN_NAME,'"].ToString();')
FROM INFORMATION_SCHEMA.COLUMNS

WHERE TABLE_NAME = 'T_r30'

-- CREAMOS UN CODIGO PARA LA COTIZACION 


select * from T_r30


select * from T_M40




t_m31 -- produ
t_m33 --marca
t_m34 --categor
t_m35 --clase
t_m36 --linea
t_m37 --sublinea
t_m72 -- unidad de medida



select * from t_r31



-- pis
-- tr29_tr28_id 
select * from dbo.T_R29

SELECT * FROM DBO.T_R28 WHERE TR28_ID = 61



select * from T_M38


insert into dbo.T_M40 (TM40_ID,TM40_DESCRIP,TM40_ST)
values('P1','Transporte',1)
insert into dbo.T_M40 (TM40_ID,TM40_DESCRIP,TM40_ST)
values('P2','Movilidad',1)
insert into dbo.T_M40 (TM40_ID,TM40_DESCRIP,TM40_ST)
values('P3','Asignación Familiar',1)
insert into dbo.T_M40 (TM40_ID,TM40_DESCRIP,TM40_ST)
values('P4','Alimentación',1)
insert into dbo.T_M40 (TM40_ID,TM40_DESCRIP,TM40_ST)
values('P5','Bonif.Afecta',1)







select * from T_R30


-- cot 109

select * from T_R29

where

TR29_TR28_ID = 130