--Muestra los detalles de la tabla de productos indicando una categoría.

select 
nIdProduct as 'Codigo de Producto',
cNombProdu as 'Nombre del Producto',
nPrecioProd as 'Precio',
cNombCateg as 'Categoria de Producto'

from coProducto

inner join coCategoria
on coProducto.nIdCategori
= coCategoria.nIdCategori

where coCategoria.nIdCategori = 1;

--realizamos la misma operación pero utilizando el procedimiento almacenado
exec Usp_Sel_Co_Produtos 1;

exec Usp_Ins_Co_Categoria 5, 'Bebes', 1, 0;