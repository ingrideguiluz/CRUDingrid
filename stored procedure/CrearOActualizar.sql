CREATE DEFINER=`root`@`localhost` PROCEDURE `CrearOActualizar`(
_iddisco int,
_nombre varchar(45),
_precio decimal(5,2),
_cantidad int(11),
_descripcion varchar(100)
)
BEGIN
	IF _iddisco=0 then
    INSERT into discos(nombre,precio, cantidad, descripcion)
	values (_nombre,_precio, _cantidad, _descripcion);
    else 
    UPDATE discos
    SET
    nombre=_nombre,
    precio=_precio,
    cantidad=_cantidad,
    descripcion=_descripcion
    WHERE iddisco=_iddisco;
END IF;
END