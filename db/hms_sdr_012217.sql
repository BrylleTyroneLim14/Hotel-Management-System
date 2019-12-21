/*
SQLyog Ultimate v11.11 (32 bit)
MySQL - 5.6.26-log : Database - hms_sdr
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`hms_sdr` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `hms_sdr`;

/*Table structure for table `audit_trail` */

DROP TABLE IF EXISTS `audit_trail`;

CREATE TABLE `audit_trail` (
  `TrailNo` int(3) NOT NULL AUTO_INCREMENT,
  `UserID` varchar(4) DEFAULT NULL,
  `Activity` varchar(100) DEFAULT NULL,
  `DateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`TrailNo`)
) ENGINE=InnoDB AUTO_INCREMENT=175 DEFAULT CHARSET=utf8;

/*Data for the table `audit_trail` */

insert  into `audit_trail`(`TrailNo`,`UserID`,`Activity`,`DateTime`) values (2,'0101','Login on Login Module','2017-01-22 00:00:00'),(3,'0101','Login on Login Module','2017-01-22 16:01:31'),(4,'0101','Logged In','2017-01-25 23:53:46'),(5,'0101','Logged In','2017-01-26 00:14:48'),(6,'0101','Added new UnitName','2017-01-26 00:15:16'),(7,'','Added new UnitName','2017-01-26 00:18:27'),(8,'','Updated Unit Name - Unit ID: 1','2017-01-26 00:18:34'),(9,'','Delete Unit Name - Unit ID: 4','2017-01-26 00:18:39'),(10,'','Delete Unit Name - Unit ID: 3','2017-01-26 00:18:43'),(11,'','Updated Unit Name - Unit ID: 1','2017-01-26 00:18:48'),(12,'0101','Logged In','2017-01-26 00:22:21'),(13,'0101','Logged In','2017-01-26 00:22:54'),(14,'0101','Logged In','2017-01-26 00:23:30'),(15,'','Added new UnitName','2017-01-26 00:30:16'),(16,'','Updated Unit Name - Unit ID: 5','2017-01-26 00:30:22'),(17,'','Delete Unit Name - Unit ID: 5','2017-01-26 00:30:26'),(18,'','Added new UnitName','2017-01-26 00:38:42'),(19,'','Updated Unit Name - Unit ID: 6','2017-01-26 00:38:59'),(20,'','Delete Unit Name - Unit ID: 6','2017-01-26 00:39:13'),(21,'','Added new UnitName','2017-01-26 00:39:32'),(22,'','Delete Unit Name - Unit ID: 7','2017-01-26 00:43:14'),(23,'','Added new UnitName','2017-01-26 00:43:34'),(24,'','Added new Staff Name','2017-01-26 01:01:14'),(25,'','Added new Staff Name','2017-01-26 01:02:03'),(26,'','Updated Staff Name - Staff ID: 10001','2017-01-26 01:17:18'),(27,'','Updated Staff Name - Staff ID: 10001','2017-01-26 01:17:27'),(28,'','Updated Staff Name - Staff ID: 10000','2017-01-26 01:25:22'),(29,'','Updated Staff Name - Staff ID: 10000','2017-01-26 01:26:04'),(30,'','Delete Staff Name - Staff ID: 10001','2017-01-26 01:26:14'),(31,'','Delete Staff Name - Staff ID: 10000','2017-01-26 01:26:21'),(32,'','Added new Staff Name','2017-01-26 01:26:25'),(33,'','Updated Staff Name - Staff ID: 10000','2017-01-26 01:26:33'),(34,'','Delete Staff Name - Staff ID: 10000','2017-01-26 01:26:40'),(35,'','Added new Staff Name','2017-01-26 01:26:52'),(36,'','Added new Staff Name','2017-01-26 01:27:00'),(37,'','Delete Supplier Name - Supplier ID: 1','2017-01-26 01:56:08'),(38,'','Added new Supplier Name','2017-01-26 01:57:19'),(39,'','Delete Supplier Name - Supplier ID: 0','2017-01-26 01:58:35'),(40,'','Added new Supplier Name','2017-01-26 01:59:18'),(41,'','Delete Supplier Name - Supplier ID: 0','2017-01-26 01:59:25'),(42,'','Added new Supplier Name','2017-01-26 01:59:30'),(43,'','Added new Supplier Name','2017-01-26 01:59:39'),(44,'','Added new Supplier Name','2017-01-26 01:59:57'),(45,'','Updated Supplier Name - Supplier ID: 1','2017-01-26 02:00:08'),(46,'','Delete Supplier Name - Supplier ID: 2','2017-01-26 02:00:20'),(47,'','Delete Supplier Name - Supplier ID: 0','2017-01-26 02:00:41'),(48,'','Delete Supplier Name - Supplier ID: 1','2017-01-26 02:00:44'),(49,'','Added new Supplier Name','2017-01-26 02:02:08'),(50,'','Added new Supplier Name','2017-01-26 02:02:40'),(51,'','Added new Supplier Name','2017-01-26 02:02:48'),(52,'','Added new Supplier Name','2017-01-26 02:03:49'),(53,'','Added new Supplier Name','2017-01-26 02:03:53'),(54,'','Added new Supplier Name','2017-01-26 02:03:57'),(55,'','Added new Supplier Name','2017-01-26 02:04:01'),(56,'','Delete Supplier Name - Supplier ID: 10','2017-01-26 02:04:08'),(57,'','Delete Supplier Name - Supplier ID: 11','2017-01-26 02:04:14'),(58,'','Delete Supplier Name - Supplier ID: 12','2017-01-26 02:04:17'),(59,'','Updated Supplier Name - Supplier ID: 13','2017-01-26 02:04:21'),(60,'','Updated Supplier Name - Supplier ID: 13','2017-01-26 02:04:28'),(61,'','Delete Supplier Name - Supplier ID: 13','2017-01-26 02:04:35'),(62,'','Added new Supplier Name','2017-01-26 02:06:15'),(63,'','Added new Supplier Name','2017-01-26 02:07:51'),(64,'','Delete Supplier Name - Supplier ID: 11','2017-01-26 02:08:11'),(65,'','Delete Supplier Name - Supplier ID: 10','2017-01-26 02:08:15'),(66,'','Added new Supplier Name','2017-01-26 02:08:29'),(67,'','Delete Unit Name - Unit ID: 8','2017-01-26 02:09:17'),(68,'','Updated Room Name - Room No: 1','2017-01-26 03:35:10'),(69,'','Added new Room Name','2017-01-26 03:48:30'),(70,'','Updated Room Name - Room No: 15','2017-01-26 03:49:03'),(71,'','Delete room name - Room ID: 15','2017-01-26 03:50:00'),(72,'','Added new User ','2017-01-26 04:37:17'),(73,'','Added new User ','2017-01-26 04:59:23'),(74,'','Updated Category Name - Category ID: 102','2017-01-26 05:42:32'),(75,'','Added new Category Name','2017-01-26 05:44:42'),(76,'','Updated Category Name - Category ID: 101','2017-01-26 05:45:49'),(77,'','Updated Category Name - Category ID: 101','2017-01-26 05:46:00'),(78,'','Delete Category Name - Supplier ID: 106','2017-01-26 05:46:06'),(79,'','Added new Category Name','2017-01-26 05:46:19'),(80,'','Added new Category Name','2017-01-26 05:46:27'),(81,'','Delete Category Name - Supplier ID: 106','2017-01-26 05:46:32'),(82,'','Delete Category Name - Supplier ID: 211','2017-01-26 05:46:47'),(83,'','Added new Category Name','2017-01-26 05:49:29'),(84,'','Added new Category Name','2017-01-26 05:50:05'),(85,'','Updated User Name - User ID: 0201','2017-01-26 13:03:11'),(86,'','Added new User ','2017-01-26 13:05:59'),(87,'','Delete User Name - User ID: 0103','2017-01-26 13:06:43'),(88,'','Delete User Name - User ID: 0103','2017-01-26 13:06:56'),(89,'','Delete User Name - User ID: 0103','2017-01-26 13:08:14'),(90,'','Delete User Name - User ID: 0103','2017-01-26 13:08:19'),(91,'','Delete User Name - User ID: 0103','2017-01-26 13:08:25'),(92,'','Updated User Name - User ID: 0202','2017-01-26 13:08:34'),(93,'','Updated User Name - User ID: 0103','2017-01-26 13:08:41'),(94,'','Updated User Name - User ID: 0102','2017-01-26 13:12:59'),(95,'','Updated User Name - User ID: 0102','2017-01-26 13:13:10'),(96,'','Updated User Name - User ID: 0102','2017-01-26 13:13:17'),(97,'','Updated User Name - User ID: 0101','2017-01-26 13:13:25'),(98,'','Delete User Name - User ID: 0102','2017-01-26 13:29:37'),(99,'','Updated User Name - User ID: 0201','2017-01-26 13:29:45'),(100,'','Added new User ','2017-01-26 13:29:59'),(101,'','Added new User ','2017-01-26 13:40:34'),(102,'','Added new User ','2017-01-26 13:44:32'),(103,'','Updated User Name - User ID: 0104','2017-01-26 13:44:59'),(104,'','Updated User Name - User ID: 0102','2017-01-26 13:47:33'),(105,'','Added new User ','2017-01-26 13:47:59'),(106,'','Delete User Name - User ID: 0104','2017-01-26 13:48:12'),(107,'','Delete User Name - User ID: 0103','2017-01-26 13:48:21'),(108,'','Updated User Name - User ID: 0102','2017-01-26 13:50:25'),(109,'','Delete User Name - User ID: 0102','2017-01-26 13:50:47'),(110,'','Delete User Name - User ID: 0202','2017-01-26 13:50:54'),(111,'','Added new Guest Name','2017-01-26 14:38:02'),(112,'','Added new Guest Name','2017-01-26 14:44:38'),(113,'','Delete Guest Name - Guest ID: 1','2017-01-26 14:45:02'),(114,'','Added new Guest Name','2017-01-26 14:47:54'),(115,'','Updated Room Name - Room No: 1','2017-01-26 14:50:04'),(116,'','Delete Guest Name - Guest ID: 2','2017-01-26 14:51:16'),(117,'','Added new Guest Name','2017-01-26 14:56:17'),(118,'','Added new Guest Name','2017-01-26 15:00:21'),(119,'','Delete Guest Name - Guest ID: 3','2017-01-26 15:00:24'),(120,'','Delete Guest Name - Guest ID: 2','2017-01-26 15:02:10'),(121,'','Added new Guest Name','2017-01-26 15:02:36'),(122,'','Updated Guest Name - Supplier ID: 1','2017-01-26 15:02:44'),(123,'','Delete Guest Name - Guest ID: 2','2017-01-26 15:02:47'),(124,'','Delete Guest Name - Guest ID: 1','2017-01-26 15:04:48'),(125,'','Added new Guest Name','2017-01-26 15:04:55'),(126,'','Updated Unit Name - Unit ID: 2','2017-01-26 15:10:00'),(127,'','Added new UnitName','2017-01-26 15:10:08'),(128,'','Delete Unit Name - Unit ID: 3','2017-01-26 15:10:10'),(129,'','Updated Unit Name - Unit ID: 2','2017-01-26 15:10:15'),(130,'','Added new Guest Name','2017-01-26 15:24:57'),(131,'','Updated Guest Name - Supplier ID: 2','2017-01-26 15:25:39'),(132,'','Updated Guest Name - Supplier ID: 2','2017-01-26 15:25:45'),(133,'','Updated Guest Name - Supplier ID: 2','2017-01-26 15:25:50'),(134,'','Delete Guest Name - Guest ID: 2','2017-01-26 15:25:57'),(135,'','Added new Supplier Name','2017-01-26 15:28:18'),(136,'','Delete Supplier Name - Supplier ID: 11','2017-01-26 15:28:39'),(137,'','Updated Supplier Name - Supplier ID: 10','2017-01-26 15:28:55'),(138,'','Added new Supplier Name','2017-01-26 15:29:01'),(139,'','Delete Staff Name - Staff ID: 10001','2017-01-26 15:29:18'),(140,'','Added new Staff Name','2017-01-26 15:29:30'),(141,'','Added new Guest Name','2017-01-26 15:30:35'),(142,'','Updated Guest Name - Supplier ID: 1','2017-01-26 15:30:49'),(143,'','Updated Supplier Name - Supplier ID: 11','2017-01-26 15:32:10'),(144,'','Updated Supplier Name - Supplier ID: 10','2017-01-26 15:32:15'),(145,'','Delete Supplier Name - Supplier ID: 10','2017-01-26 15:32:21'),(146,'','Updated Supplier Name - Supplier ID: 11','2017-01-26 15:32:33'),(147,'','Updated Supplier Name - Supplier ID: 11','2017-01-26 15:32:42'),(148,'','Added new Supplier Name','2017-01-26 15:32:57'),(149,'','Updated Guest Name - Supplier ID: 1','2017-01-26 15:38:57'),(150,'','Updated Guest Name - Supplier ID: 2','2017-01-26 15:39:21'),(151,'','Updated Guest Name - Supplier ID: 1','2017-01-26 15:39:31'),(152,'','Updated Guest Name - Supplier ID: 1','2017-01-26 15:39:36'),(153,'','Added new Guest Name','2017-01-26 15:39:52'),(154,'','Delete Guest Name - Guest ID: 3','2017-01-26 15:39:55'),(155,'','Added new User ','2017-01-26 15:52:27'),(156,'','Updated User Name - User ID: 0102','2017-01-26 15:52:49'),(157,'','Updated Room Name - Room No: 2','2017-01-26 15:54:10'),(158,'','Delete User Name - User ID: 0102','2017-01-26 15:55:49'),(159,'','Updated Room Name - Room No: 1','2017-01-26 15:56:08'),(160,'','Updated Room Name - Room No: 2','2017-01-26 16:04:00'),(161,'','Added new Room Name','2017-01-26 16:30:51'),(162,'','Added new Room Name','2017-01-26 17:45:33'),(163,'','Added new Room Name','2017-01-26 17:45:46'),(164,'','Updated Product Name - Product ID: 0100000003','2017-01-26 17:46:14'),(165,'','Updated Product Name - Product ID: 0100000001','2017-01-26 17:46:30'),(166,'','Delete Product Name - Product ID: 0100000001','2017-01-26 17:46:38'),(167,'','Added new Room Name','2017-01-26 17:47:57'),(168,'','Updated Product Name - Product ID: 0200000001','2017-01-26 17:48:47'),(169,'','Updated Product Name - Product ID: 0200000001','2017-01-26 17:48:58'),(170,'','Delete Product Name - Product ID: 0200000001','2017-01-26 17:50:04'),(171,'','Updated Product Name - Product ID: 0100000002','2017-01-26 17:50:11'),(172,'','Added new Room Name','2017-01-26 17:50:25'),(173,'','Updated Product Name - Product ID: 0200000001','2017-01-26 17:50:34'),(174,'','Updated Product Name - Product ID: 0200000001','2017-01-26 17:50:39');

/*Table structure for table `category` */

DROP TABLE IF EXISTS `category`;

CREATE TABLE `category` (
  `CategoryID` varchar(3) NOT NULL,
  `Type` int(2) DEFAULT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`CategoryID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `category` */

insert  into `category`(`CategoryID`,`Type`,`Name`) values ('101',1,'Ala Carte'),('102',1,'Combo Mealss'),('103',1,'Sandwiches'),('104',1,'Pancakes'),('105',1,'Additional Charges'),('201',2,'Cup Noodles'),('202',2,'Snacks-Chips and Biscuits'),('203',2,'Candies'),('204',2,'Hot Drinks'),('205',2,'Beers'),('206',2,'Juice and Soda'),('207',2,'Shampoo and Conditioner'),('208',2,'Bath Soap'),('209',2,'Cigarettes'),('210',2,'Other Items');

/*Table structure for table `constorekitchensales` */

DROP TABLE IF EXISTS `constorekitchensales`;

CREATE TABLE `constorekitchensales` (
  `CSKS_Code` varchar(10) NOT NULL,
  `TransactionNo` varchar(10) DEFAULT NULL,
  `DateOfSale` date DEFAULT NULL,
  `ProductCode` varchar(10) DEFAULT NULL,
  `Quantity` int(3) DEFAULT NULL,
  `TotalAmount` double(10,2) DEFAULT NULL,
  `Remarks` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`CSKS_Code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `constorekitchensales` */

/*Table structure for table `dailyinventorylisting` */

DROP TABLE IF EXISTS `dailyinventorylisting`;

CREATE TABLE `dailyinventorylisting` (
  `DIL_ID` varchar(10) NOT NULL,
  `Date` date DEFAULT NULL,
  `ProductCode` varchar(10) DEFAULT NULL,
  `QtyOnHand` int(3) DEFAULT NULL,
  PRIMARY KEY (`DIL_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `dailyinventorylisting` */

/*Table structure for table `guest` */

DROP TABLE IF EXISTS `guest`;

CREATE TABLE `guest` (
  `GuestID` varchar(10) NOT NULL,
  `FirstName` varchar(25) DEFAULT NULL,
  `LastName` varchar(25) DEFAULT NULL,
  `Address` varchar(100) DEFAULT NULL,
  `Company` varchar(25) DEFAULT NULL,
  `MobileNo` varchar(11) DEFAULT NULL,
  PRIMARY KEY (`GuestID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `guest` */

insert  into `guest`(`GuestID`,`FirstName`,`LastName`,`Address`,`Company`,`MobileNo`) values ('0000000001','Bryan','Lim','CC','STI','0956621412'),('0000000002','ERWIN','PLAZA','QC','SUNNY DAYS','124214');

/*Table structure for table `inventory` */

DROP TABLE IF EXISTS `inventory`;

CREATE TABLE `inventory` (
  `InventoryID` varchar(10) NOT NULL,
  `ProductCode` varchar(10) DEFAULT NULL,
  `QtyOnHand` int(3) DEFAULT NULL,
  `Status` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`InventoryID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `inventory` */

/*Table structure for table `product` */

DROP TABLE IF EXISTS `product`;

CREATE TABLE `product` (
  `ProductCode` varchar(10) NOT NULL,
  `SupplierID` varchar(2) DEFAULT NULL,
  `CategoryID` varchar(3) DEFAULT NULL,
  `UnitID` int(3) DEFAULT NULL,
  `Name` varchar(25) DEFAULT NULL,
  `SupplierPrice` double(10,2) DEFAULT NULL,
  `SellingPrice` double(10,2) DEFAULT NULL,
  `CriticalLevel` int(3) DEFAULT NULL,
  PRIMARY KEY (`ProductCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `product` */

insert  into `product`(`ProductCode`,`SupplierID`,`CategoryID`,`UnitID`,`Name`,`SupplierPrice`,`SellingPrice`,`CriticalLevel`) values ('0100000002','01','103',2,'66',41.00,4.00,4),('0200000001','02','102',2,'6',43333.00,4.00,4);

/*Table structure for table `reservation` */

DROP TABLE IF EXISTS `reservation`;

CREATE TABLE `reservation` (
  `ReservationNo` varchar(10) NOT NULL,
  `GuestID` varchar(10) DEFAULT NULL,
  `RoomNo` int(2) DEFAULT NULL,
  `CheckInDate` date DEFAULT NULL,
  `Duration` int(3) DEFAULT NULL,
  `ExpectedCheckOut` datetime DEFAULT NULL,
  `ArrivalDetails` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ReservationNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `reservation` */

/*Table structure for table `room` */

DROP TABLE IF EXISTS `room`;

CREATE TABLE `room` (
  `RoomNo` int(2) NOT NULL,
  `RoomTypeID` int(2) DEFAULT NULL,
  `RoomName` varchar(25) DEFAULT NULL,
  `Rate_1` double(10,2) DEFAULT NULL,
  `Rate_2` double(10,2) DEFAULT NULL,
  `Rate_3` double(10,2) DEFAULT NULL,
  `ExtensionRate` double(10,2) DEFAULT NULL,
  `Floor` varchar(4) DEFAULT NULL,
  `PhoneNo` varchar(11) DEFAULT NULL,
  `Status` varchar(25) DEFAULT NULL,
  `Picture` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`RoomNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `room` */

insert  into `room`(`RoomNo`,`RoomTypeID`,`RoomName`,`Rate_1`,`Rate_2`,`Rate_3`,`ExtensionRate`,`Floor`,`PhoneNo`,`Status`,`Picture`) values (1,1,'MACAUs',450.00,650.00,950.00,200.00,'1st','101','AVAILABLE',''),(2,1,'BAGUIO',450.00,650.00,950.00,200.00,'1st','102','AVAILABLE',''),(3,2,'DUBAI',450.00,650.00,950.00,200.00,'2nd','132','AVAILABLE',NULL),(4,2,'KUALA LUMPUR',450.00,650.00,950.00,200.00,'2nd','131','AVAILABLE',NULL),(5,1,'PUERTO GALERA',450.00,650.00,950.00,200.00,'3rd','111','AVAILABLE',NULL),(6,1,'EL NIDO',450.00,650.00,950.00,200.00,'3rd','112','AVAILABLE',NULL),(7,1,'LAOAG',450.00,650.00,950.00,200.00,'4th','187','AVAILABLE',NULL),(8,1,'ALBAY',450.00,650.00,950.00,200.00,'4th','186','AVAILABLE',NULL),(9,2,'BANGKOK',450.00,650.00,950.00,200.00,'2nd','104','AVAILABLE',NULL),(10,2,'HONG KONG',450.00,650.00,950.00,200.00,'2nd','103','AVAILABLE',NULL),(11,2,'SINGAPORE',450.00,650.00,950.00,200.00,'2nd','105','AVAILABLE',NULL),(12,1,'PALAWAN',450.00,650.00,950.00,200.00,'3rd','108','AVAILABLE',NULL),(13,1,'BORACAY',450.00,650.00,950.00,200.00,'3rd','110','AVAILABLE',NULL),(14,1,'CEBU',450.00,650.00,950.00,200.00,'3rd','109','AVAILABLE',NULL),(15,2,'america',244.40,224.00,233.00,200.00,'1st','094666','available','');

/*Table structure for table `roomsales` */

DROP TABLE IF EXISTS `roomsales`;

CREATE TABLE `roomsales` (
  `TransactionNo` varchar(10) NOT NULL,
  `RoomNo` int(2) DEFAULT NULL,
  `GuestID` varchar(10) DEFAULT NULL,
  `Pax` int(3) DEFAULT NULL,
  `CheckInDateTime` datetime DEFAULT NULL,
  `Duration` int(3) DEFAULT NULL,
  `ExpectedCheckOut` datetime DEFAULT NULL,
  `Deposit` double(10,2) DEFAULT NULL,
  `OtherCharges` double(10,2) DEFAULT NULL,
  `TotalCharge` double(10,2) DEFAULT NULL,
  `Remarks` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`TransactionNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `roomsales` */

/*Table structure for table `roomtype` */

DROP TABLE IF EXISTS `roomtype`;

CREATE TABLE `roomtype` (
  `RoomTypeId` int(2) NOT NULL AUTO_INCREMENT,
  `Name` varchar(25) DEFAULT NULL,
  `MaxCap` int(2) DEFAULT NULL,
  PRIMARY KEY (`RoomTypeId`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COMMENT='		';

/*Data for the table `roomtype` */

insert  into `roomtype`(`RoomTypeId`,`Name`,`MaxCap`) values (1,'Studio Type',2),(2,'One Bed Rooms',4),(3,'Aircon',6);

/*Table structure for table `staff` */

DROP TABLE IF EXISTS `staff`;

CREATE TABLE `staff` (
  `StaffID` varchar(5) NOT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`StaffID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `staff` */

insert  into `staff`(`StaffID`,`Name`) values ('10000','Plaza Erwin'),('10001','Bryan Lim');

/*Table structure for table `supplier` */

DROP TABLE IF EXISTS `supplier`;

CREATE TABLE `supplier` (
  `SupplierID` varchar(2) NOT NULL,
  `SupplierName` varchar(25) DEFAULT NULL,
  `SupplierAddress` varchar(50) DEFAULT NULL,
  `SupplierContactNo` varchar(11) DEFAULT NULL,
  PRIMARY KEY (`SupplierID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `supplier` */

insert  into `supplier`(`SupplierID`,`SupplierName`,`SupplierAddress`,`SupplierContactNo`) values ('01','SM SUPERMARKET','QC','09465612312'),('02','PUREGOLD','PUREGOLD QC','0914214214');

/*Table structure for table `unit` */

DROP TABLE IF EXISTS `unit`;

CREATE TABLE `unit` (
  `UnitID` int(3) NOT NULL AUTO_INCREMENT,
  `UnitName` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`UnitID`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

/*Data for the table `unit` */

insert  into `unit`(`UnitID`,`UnitName`) values (1,'/ order'),(2,'/ pc(s)');

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `UserID` varchar(4) NOT NULL,
  `UserTypeID` varchar(2) DEFAULT NULL,
  `Username` varchar(25) DEFAULT NULL,
  `Password` varchar(25) DEFAULT NULL,
  `FirstName` varchar(25) DEFAULT NULL,
  `LastName` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `user` */

insert  into `user`(`UserID`,`UserTypeID`,`Username`,`Password`,`FirstName`,`LastName`) values ('0101','01','admin123','admin123','BRYAN','LIM'),('0201','02','manager123','manager123','JOHN','SMITHs'),('0301','03','frontdesk123','frontdesk123','NINA','WILLIAMSS');

/*Table structure for table `usertype` */

DROP TABLE IF EXISTS `usertype`;

CREATE TABLE `usertype` (
  `UserTypeID` varchar(2) NOT NULL,
  `Description` varchar(25) DEFAULT NULL,
  `Sales` int(1) DEFAULT NULL,
  `Reservation` int(1) DEFAULT NULL,
  `Inventory` int(1) DEFAULT NULL,
  `Reports` int(1) DEFAULT NULL,
  `RoomMaintenance` int(1) DEFAULT NULL,
  `ProductMaintenance` int(1) DEFAULT NULL,
  `UserMaintenance` int(1) DEFAULT NULL,
  `GuestMaintenance` int(1) DEFAULT NULL,
  PRIMARY KEY (`UserTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `usertype` */

insert  into `usertype`(`UserTypeID`,`Description`,`Sales`,`Reservation`,`Inventory`,`Reports`,`RoomMaintenance`,`ProductMaintenance`,`UserMaintenance`,`GuestMaintenance`) values ('01','Administrator',1,1,1,1,1,1,1,1),('02','Manager',1,1,1,1,1,1,0,1),('03','Front Desk',1,1,0,0,0,0,0,0);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
