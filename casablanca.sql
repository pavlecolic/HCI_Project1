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
CREATE SCHEMA IF NOT EXISTS `casablanca` DEFAULT CHARACTER SET utf8mb3 ;
USE `casablanca` ;

-- -----------------------------------------------------
-- Table `casablanca`.`city`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`city` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `post_code` VARCHAR(5) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `casablanca`.`address`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`address` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `number` INT NOT NULL,
  `city_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Address_City1_idx` (`city_id` ASC) VISIBLE,
  CONSTRAINT `fk_Address_City1`
    FOREIGN KEY (`city_id`)
    REFERENCES `casablanca`.`city` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `casablanca`.`user`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`user` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `username` VARCHAR(45) NOT NULL,
  `password` VARCHAR(64) NOT NULL,
  `first_name` VARCHAR(45) NOT NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `theme` VARCHAR(45) NOT NULL,
  `language` VARCHAR(45) NOT NULL,
  `salary` DECIMAL(5) NOT NULL,
  `is_admin` TINYINT NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `casablanca`.`article_type`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`article_type` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `type_name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `casablanca`.`supplier`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`supplier` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(45) NOT NULL,
  `contact` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `casablanca`.`invoice`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`invoice` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `price` DECIMAL(5,2) NOT NULL,
  `date` DATETIME NOT NULL,
  `user_id` INT NOT NULL,
  `supplier_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Invoice_User1_idx` (`user_id` ASC) VISIBLE,
  INDEX `fk_Invoice_Supplier1_idx` (`supplier_id` ASC) VISIBLE,
  CONSTRAINT `fk_Invoice_Supplier1`
    FOREIGN KEY (`supplier_id`)
    REFERENCES `casablanca`.`supplier` (`id`),
  CONSTRAINT `fk_Invoice_User1`
    FOREIGN KEY (`user_id`)
    REFERENCES `casablanca`.`user` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `casablanca`.`publisher`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`publisher` (
  `id` INT NOT NULL,
  `name` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `casablanca`.`article`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`article` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `name` VARCHAR(100) NOT NULL,
  `image` VARCHAR(100) NOT NULL,
  `type_id` INT NOT NULL,
  `is_rented` TINYINT NOT NULL,
  `price` DECIMAL(5,2) NOT NULL,
  `publisher_id` INT NOT NULL,
  `invoice_id` INT NOT NULL,
  `is_for_sale` TINYINT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Article_ArticleType_idx` (`type_id` ASC) VISIBLE,
  INDEX `fk_Article_Publisher1_idx` (`publisher_id` ASC) VISIBLE,
  INDEX `fk_Article_Invoice1_idx` (`invoice_id` ASC) VISIBLE,
  CONSTRAINT `fk_Article_ArticleType`
    FOREIGN KEY (`type_id`)
    REFERENCES `casablanca`.`article_type` (`id`),
  CONSTRAINT `fk_Article_Invoice1`
    FOREIGN KEY (`invoice_id`)
    REFERENCES `casablanca`.`invoice` (`id`),
  CONSTRAINT `fk_Article_Publisher1`
    FOREIGN KEY (`publisher_id`)
    REFERENCES `casablanca`.`publisher` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `casablanca`.`customer`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`customer` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `first_name` VARCHAR(45) NOT NULL,
  `last_name` VARCHAR(45) NOT NULL,
  `JMB` VARCHAR(13) NOT NULL,
  `address_id` INT NOT NULL,
  `phone_number` VARCHAR(15) NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Customer_Address1_idx` (`address_id` ASC) VISIBLE,
  CONSTRAINT `fk_Customer_Address1`
    FOREIGN KEY (`address_id`)
    REFERENCES `casablanca`.`address` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `casablanca`.`rental`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`rental` (
  `id` INT NOT NULL AUTO_INCREMENT,
  `rent_date` DATETIME NOT NULL,
  `due_date` DATETIME NOT NULL,
  `return_date` DATETIME NULL DEFAULT NULL,
  `price` DECIMAL(5,2) NOT NULL,
  `cutomer_id` INT NOT NULL,
  PRIMARY KEY (`id`),
  INDEX `fk_Rental_Customer1_idx` (`cutomer_id` ASC) VISIBLE,
  CONSTRAINT `fk_Rental_Customer1`
    FOREIGN KEY (`cutomer_id`)
    REFERENCES `casablanca`.`customer` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


-- -----------------------------------------------------
-- Table `casablanca`.`rented_article`
-- -----------------------------------------------------
CREATE TABLE IF NOT EXISTS `casablanca`.`rented_article` (
  `article_id` INT NOT NULL,
  `rental_id` INT NOT NULL,
  `price` DECIMAL(5,2) NOT NULL,
  PRIMARY KEY (`article_id`, `rental_id`),
  INDEX `fk_Article_has_Rental_Rental1_idx` (`rental_id` ASC) VISIBLE,
  INDEX `fk_Article_has_Rental_Article1_idx` (`article_id` ASC) VISIBLE,
  CONSTRAINT `fk_Article_has_Rental_Article1`
    FOREIGN KEY (`article_id`)
    REFERENCES `casablanca`.`article` (`id`),
  CONSTRAINT `fk_Article_has_Rental_Rental1`
    FOREIGN KEY (`rental_id`)
    REFERENCES `casablanca`.`rental` (`id`))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8mb3;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
