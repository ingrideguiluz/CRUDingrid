CREATE TABLE `dbcrudingrid`.`discos` (
  `iddisco` INT NOT NULL,
  `nombre` VARCHAR(45) NULL,
  `precio` DECIMAL(5,2) NULL,
  `cantidad` INT NULL,
  `descripcion` VARCHAR(100) NULL,
  PRIMARY KEY (`iddisco`));