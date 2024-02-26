-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema casablanca
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema casablanca
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `casablanca` DEFAULT CHARACTER SET utf8 ;
USE `casablanca` ;

-- -----------------------------------------------------
-- Table `casablanca`.`City`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`City` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `postCode` VARCHAR(5) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `casablanca`.`Address`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`Address` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `number` INT NOT NULL,
  `cityId` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Address_City1_idx` (`cityId` ASC) VISIBLE,
  CONSTRAINT `fk_Address_City1`
    FOREIGN KEY (`cityId`)
    REFERENCES `casablanca`.`City` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `casablanca`.`Customer`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`Customer` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `firstName` VARCHAR(45) NOT NULL,
  `lastName` VARCHAR(45) NOT NULL,
  `JMB` VARCHAR(13) NOT NULL,
  `addressId` INT NOT NULL,
  `phoneNumber` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Customer_Address1_idx` (`addressId` ASC) VISIBLE,
  CONSTRAINT `fk_Customer_Address1`
    FOREIGN KEY (`addressId`)
    REFERENCES `casablanca`.`Address` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `casablanca`.`Admin`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`Admin` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  `firstName` VARCHAR(45) NOT NULL,
  `lastName` VARCHAR(45) NOT NULL,
  `theme` VARCHAR(45) NOT NULL,
  `language` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `casablanca`.`Article Type`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`Article Type` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `typeName` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `casablanca`.`Publisher`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`Publisher` (
  `id` INT NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `casablanca`.`Supplier`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`Supplier` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `contact` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `casablanca`.`Invoice`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`Invoice` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `price` DECIMAL(5,2) NOT NULL,
  `date` DATETIME NOT NULL,
  `adminId` INT NOT NULL,
  `supplierId` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Invoice_User1_idx` (`adminId` ASC) VISIBLE,
  INDEX `fk_Invoice_Supplier1_idx` (`supplierId` ASC) VISIBLE,
  CONSTRAINT `fk_Invoice_User1`
    FOREIGN KEY (`adminId`)
    REFERENCES `casablanca`.`Admin` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Invoice_Supplier1`
    FOREIGN KEY (`supplierId`)
    REFERENCES `casablanca`.`Supplier` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `casablanca`.`Article`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`Article` (
  `id` INT NOT NULL,
  `name` VARCHAR(100) NOT NULL,
  `image` VARCHAR(100) NOT NULL,
  `typeId` INT NOT NULL,
  `isRented` TINYINT NOT NULL,
  `price` DECIMAL(5,2) NOT NULL,
  `publisherId` INT NOT NULL,
  `invoiceId` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Article_ArticleType_idx` (`typeId` ASC) VISIBLE,
  INDEX `fk_Article_Publisher1_idx` (`publisherId` ASC) VISIBLE,
  INDEX `fk_Article_Invoice1_idx` (`invoiceId` ASC) VISIBLE,
  CONSTRAINT `fk_Article_ArticleType`
    FOREIGN KEY (`typeId`)
    REFERENCES `casablanca`.`Article Type` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Article_Publisher1`
    FOREIGN KEY (`publisherId`)
    REFERENCES `casablanca`.`Publisher` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Article_Invoice1`
    FOREIGN KEY (`invoiceId`)
    REFERENCES `casablanca`.`Invoice` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `casablanca`.`Rental`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`Rental` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `rentDate` DATETIME NOT NULL,
  `dueDate` DATETIME NOT NULL,
  `returnDate` DATETIME NULL,
  `price` DECIMAL(5,2) NOT NULL,
  `customerId` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Rental_Customer1_idx` (`customerId` ASC) VISIBLE,
  CONSTRAINT `fk_Rental_Customer1`
    FOREIGN KEY (`customerId`)
    REFERENCES `casablanca`.`Customer` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `casablanca`.`Rented Article`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`Rented Article` (
  `articleId` INT NOT NULL,
  `rentalId` INT NOT NULL,
  `price` DECIMAL(5,2) NOT NULL,
  PRIMARY KEY (`articleId`, `rentalId`),
  INDEX `fk_Article_has_Rental_Rental1_idx` (`rentalId` ASC) VISIBLE,
  INDEX `fk_Article_has_Rental_Article1_idx` (`articleId` ASC) VISIBLE,
  CONSTRAINT `fk_Article_has_Rental_Article1`
    FOREIGN KEY (`articleId`)
    REFERENCES `casablanca`.`Article` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_Article_has_Rental_Rental1`
    FOREIGN KEY (`rentalId`)
    REFERENCES `casablanca`.`Rental` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `casablanca`.`User`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`User` (
  `id` INT NOT NULL,
  `username` VARCHAR(45) NOT NULL,
  `password` VARCHAR(45) NOT NULL,
  `firstName` VARCHAR(45) NOT NULL,
  `lastName` VARCHAR(45) NOT NULL,
  `theme` VARCHAR(45) NOT NULL,
  `language` VARCHAR(45) NOT NULL,
  `salary` DECIMAL(5,2) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
