-- ---
-- Globals
-- ---

-- SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
-- SET FOREIGN_KEY_CHECKS=0;

-- ---
-- Table 'Offerings'
-- This is the table for vazhipads.
-- ---

DROP TABLE IF EXISTS `Offerings`;
		
CREATE TABLE `Offerings` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT COMMENT 'Offering',
  `TempleId` INTEGER NOT NULL,
  `Offering Name` VARCHAR(100) NOT NULL,
  `Price` DECIMAL NOT NULL,
  `MaxPerDay` INTEGER NOT NULL,
  `DietyId` INTEGER NULL DEFAULT NULL,
  `IsBookable` bit NOT NULL DEFAULT false,
  `OfferingCode` VARCHAR(4) NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  PRIMARY KEY (`Id`)
) COMMENT 'This is the table for vazhipads.';

-- ---
-- Table 'OfferingTransactions'
-- This is the entries where people make offerings.
-- ---

DROP TABLE IF EXISTS `OfferingTransactions`;
		
CREATE TABLE `OfferingTransactions` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `TempleId` INTEGER NOT NULL,
  `OfferingId` INTEGER NOT NULL,
  `StarSignId` INTEGER NOT NULL,
  `Name` VARCHAR(50) NULL DEFAULT NULL,
  `Remarks` VARCHAR(200) NULL DEFAULT NULL,
  `Date` DATETIME NOT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  PRIMARY KEY (`Id`)
) COMMENT 'This is the entries where people make offerings.';

-- ---
-- Table 'StarSigns'
-- This has all the star signs in malayalam calendar.
-- ---

DROP TABLE IF EXISTS `StarSigns`;
		
CREATE TABLE `StarSigns` (
  `Id` INTEGER NOT NULL,
  `StarSignName` VARCHAR(50) NOT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  PRIMARY KEY (`Id`)
) COMMENT 'This has all the star signs in malayalam calendar.';

-- ---
-- Table 'Deitys'
-- The prathistas in the temple.
-- ---

DROP TABLE IF EXISTS `Deitys`;
		
CREATE TABLE `Deitys` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `TempleId` INTEGER NULL DEFAULT NULL,
  `DeityName` VARCHAR(70) NULL DEFAULT NULL,
  `IsMain` bit NOT NULL DEFAULT 0,
  `Description` VARCHAR(200) NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  PRIMARY KEY (`Id`)
) COMMENT 'The prathistas in the temple.';

-- ---
-- Table 'OfferingPreBookings'
-- To store the booking information for various offering
-- ---

DROP TABLE IF EXISTS `OfferingPreBookings`;
		
CREATE TABLE `OfferingPreBookings` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `TempleId` INTEGER NOT NULL,
  `OfferingId` INTEGER NOT NULL,
  `DateOfBooking` DATETIME NOT NULL,
  `DateOfOffering` DATETIME NOT NULL,
  `ContactNumber` VARCHAR(12) NULL DEFAULT NULL,
  `ContactName` VARCHAR(50) NOT NULL,
  `Remarks` VARCHAR(200) NULL DEFAULT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  PRIMARY KEY (`Id`)
) COMMENT 'To store the booking information for various offering';

-- ---
-- Table 'Temples'
-- 
-- ---

DROP TABLE IF EXISTS `Temples`;
		
CREATE TABLE `Temples` (
  `Id` INTEGER NULL AUTO_INCREMENT DEFAULT NULL,
  `AdminId` INTEGER NULL DEFAULT NULL,
  `TempleName` VARCHAR(300) NOT NULL,
  `ContactPerson` VARCHAR(200) NOT NULL,
  `ContactNumber` VARCHAR(30) NOT NULL,
  `Address` VARCHAR(500) NOT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Table 'Users'
-- The Users table
-- ---

DROP TABLE IF EXISTS `Users`;
		
CREATE TABLE `Users` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT,
  `TempleId` INTEGER NULL DEFAULT NULL,
  `Email` VARCHAR(200) NOT NULL,
  `Password` VARCHAR(1000) NOT NULL,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  PRIMARY KEY (`Id`)
) COMMENT 'The Users table';

-- ---
-- Table 'OfferingCounts'
-- 
-- ---

DROP TABLE IF EXISTS `OfferingCounts`;
		
CREATE TABLE `OfferingCounts` (
  `Id` INTEGER NOT NULL AUTO_INCREMENT DEFAULT NULL,
  `TempleId` INTEGER NOT NULL,
  `OfferingId` INTEGER NOT NULL,
  `Count` INTEGER NOT NULL DEFAULT 0,
  `CreatedDate` DATETIME NOT NULL,
  `UpdatedDate` DATETIME NOT NULL,
  `CreatedBy` INTEGER NULL DEFAULT NULL,
  `UpdatedBy` INTEGER NULL DEFAULT NULL,
  PRIMARY KEY (`Id`)
);

-- ---
-- Foreign Keys 
-- ---

ALTER TABLE `Offerings` ADD FOREIGN KEY (TempleId) REFERENCES `Temples` (`Id`);
ALTER TABLE `Offerings` ADD FOREIGN KEY (DietyId) REFERENCES `Deitys` (`Id`);
ALTER TABLE `Offerings` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Offerings` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `OfferingTransactions` ADD FOREIGN KEY (TempleId) REFERENCES `Temples` (`Id`);
ALTER TABLE `OfferingTransactions` ADD FOREIGN KEY (OfferingId) REFERENCES `Offerings` (`Id`);
ALTER TABLE `OfferingTransactions` ADD FOREIGN KEY (StarSignId) REFERENCES `StarSigns` (`Id`);
ALTER TABLE `OfferingTransactions` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `OfferingTransactions` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `StarSigns` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `StarSigns` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Deitys` ADD FOREIGN KEY (TempleId) REFERENCES `Temples` (`Id`);
ALTER TABLE `Deitys` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Deitys` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `OfferingPreBookings` ADD FOREIGN KEY (TempleId) REFERENCES `Temples` (`Id`);
ALTER TABLE `OfferingPreBookings` ADD FOREIGN KEY (OfferingId) REFERENCES `Offerings` (`Id`);
ALTER TABLE `OfferingPreBookings` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `OfferingPreBookings` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Temples` ADD FOREIGN KEY (AdminId) REFERENCES `Users` (`Id`);
ALTER TABLE `Temples` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Temples` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Users` ADD FOREIGN KEY (CreatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `Users` ADD FOREIGN KEY (UpdatedBy) REFERENCES `Users` (`Id`);
ALTER TABLE `OfferingCounts` ADD FOREIGN KEY (TempleId) REFERENCES `Temples` (`Id`);
ALTER TABLE `OfferingCounts` ADD FOREIGN KEY (OfferingId) REFERENCES `Offerings` (`Id`);

-- ---
-- Table Properties
-- ---

-- ALTER TABLE `Offerings` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `OfferingTransactions` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `StarSigns` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Deitys` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `OfferingPreBookings` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Temples` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `Users` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
-- ALTER TABLE `OfferingCounts` ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;

-- ---
-- Test Data
-- ---

-- INSERT INTO `Offerings` (`Id`,`TempleId`,`Offering Name`,`Price`,`MaxPerDay`,`DietyId`,`IsBookable`,`OfferingCode`,`CreatedDate`,`UpdatedDate`,`CreatedBy`,`UpdatedBy`) VALUES
-- ('','','','','','','','','','','','');
-- INSERT INTO `OfferingTransactions` (`Id`,`TempleId`,`OfferingId`,`StarSignId`,`Name`,`Remarks`,`Date`,`CreatedDate`,`UpdatedDate`,`CreatedBy`,`UpdatedBy`) VALUES
-- ('','','','','','','','','','','');
-- INSERT INTO `StarSigns` (`Id`,`StarSignName`,`CreatedDate`,`UpdatedDate`,`CreatedBy`,`UpdatedBy`) VALUES
-- ('','','','','','');
-- INSERT INTO `Deitys` (`Id`,`TempleId`,`DeityName`,`IsMain`,`Description`,`CreatedDate`,`UpdatedDate`,`CreatedBy`,`UpdatedBy`) VALUES
-- ('','','','','','','','','');
-- INSERT INTO `OfferingPreBookings` (`Id`,`TempleId`,`OfferingId`,`DateOfBooking`,`DateOfOffering`,`ContactNumber`,`ContactName`,`Remarks`,`CreatedDate`,`UpdatedDate`,`CreatedBy`,`UpdatedBy`) VALUES
-- ('','','','','','','','','','','','');
-- INSERT INTO `Temples` (`Id`,`AdminId`,`TempleName`,`ContactPerson`,`ContactNumber`,`Address`,`CreatedDate`,`UpdatedDate`,`CreatedBy`,`UpdatedBy`) VALUES
-- ('','','','','','','','','','');
-- INSERT INTO `Users` (`Id`,`TempleId`,`Email`,`Password`,`CreatedDate`,`UpdatedDate`,`CreatedBy`,`UpdatedBy`) VALUES
-- ('','','','','','','','');
-- INSERT INTO `OfferingCounts` (`Id`,`TempleId`,`OfferingId`,`Count`,`CreatedDate`,`UpdatedDate`,`CreatedBy`,`UpdatedBy`) VALUES
-- ('','','','','','','','');