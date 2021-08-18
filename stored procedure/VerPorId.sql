CREATE PROCEDURE `VerPorId` (
_iddisco int)
BEGIN
SELECT * 
FROM discos
WHERE iddisco=_iddisco;
END