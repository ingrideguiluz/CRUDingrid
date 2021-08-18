CREATE PROCEDURE `Eliminar` (
_iddisco int)
BEGIN
DELETE FROM discos
WHERE iddisco = _iddisco;
END
