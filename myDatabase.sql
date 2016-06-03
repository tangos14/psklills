# SQL Manager 2010 for MySQL 4.5.0.9
# ---------------------------------------
# Host     : localhost
# Port     : 3306
# Database : myDatabase


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

SET FOREIGN_KEY_CHECKS=0;

CREATE DATABASE `myDatabase`
    CHARACTER SET 'utf8'
    COLLATE 'utf8_general_ci';

USE `mydatabase`;

#
# Structure for the `tbl_items` table : 
#

CREATE TABLE `tbl_items` (
  `ItemID` int(11) NOT NULL AUTO_INCREMENT,
  `ItemName` varchar(45) NOT NULL,
  `ItemQuantity` int(11) NOT NULL,
  `UOM` varchar(24) DEFAULT NULL,
  PRIMARY KEY (`ItemID`),
  UNIQUE KEY `ItemID_UNIQUE` (`ItemID`),
  UNIQUE KEY `Itemname_UNIQUE` (`ItemName`),
  UNIQUE KEY `UOM_UNIQUE` (`UOM`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

#
# Structure for the `tbl_purchasedorder` table : 
#

CREATE TABLE `tbl_purchasedorder` (
  `POID` int(11) NOT NULL AUTO_INCREMENT,
  `Item` varchar(20) NOT NULL,
  `UOM` varchar(45) DEFAULT NULL,
  `Supplier` varchar(20) NOT NULL,
  `PON` int(11) NOT NULL,
  `Quantity` int(11) NOT NULL,
  PRIMARY KEY (`POID`),
  KEY `ItemID` (`Item`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8;

#
# Structure for the `tbl_supplier` table : 
#

CREATE TABLE `tbl_supplier` (
  `SupplierID` int(11) NOT NULL AUTO_INCREMENT,
  `Supplier` varchar(45) NOT NULL,
  PRIMARY KEY (`SupplierID`),
  UNIQUE KEY `SupplierID_UNIQUE` (`SupplierID`),
  UNIQUE KEY `Supplier_UNIQUE` (`Supplier`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

#
# Data for the `tbl_items` table  (LIMIT 0,500)
#

INSERT INTO `tbl_items` (`ItemID`, `ItemName`, `ItemQuantity`, `UOM`) VALUES 
  (1,'manga',10,'kilo'),
  (2,'apple',5,'dozen');
COMMIT;

#
# Data for the `tbl_purchasedorder` table  (LIMIT 0,500)
#

INSERT INTO `tbl_purchasedorder` (`POID`, `Item`, `UOM`, `Supplier`, `PON`, `Quantity`) VALUES 
  (5,'apple','kilo','KCC',3,100),
  (6,'manga','kilo','Gaisano',3,100);
COMMIT;

#
# Data for the `tbl_supplier` table  (LIMIT 0,500)
#

INSERT INTO `tbl_supplier` (`SupplierID`, `Supplier`) VALUES 
  (1,'KCC');
COMMIT;



/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;