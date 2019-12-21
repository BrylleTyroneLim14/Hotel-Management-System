/*
SQLyog Ultimate v11.11 (64 bit)
MySQL - 5.5.5-10.1.13-MariaDB : Database - hms_sdr
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`hms_sdr` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `hms_sdr`;

/*Table structure for table `audit_trail` */

DROP TABLE IF EXISTS `audit_trail`;

CREATE TABLE `audit_trail` (
  `TrailNo` int(3) NOT NULL AUTO_INCREMENT,
  `UserID` varchar(4) DEFAULT NULL,
  `Activity` varchar(100) DEFAULT NULL,
  `DateTime` datetime DEFAULT NULL,
  PRIMARY KEY (`TrailNo`)
) ENGINE=InnoDB AUTO_INCREMENT=210 DEFAULT CHARSET=utf8;

/*Data for the table `audit_trail` */

insert  into `audit_trail`(`TrailNo`,`UserID`,`Activity`,`DateTime`) values (49,'0101','Logged In','2017-02-04 00:31:21'),(50,'0101','Logged In','2017-02-04 00:34:40'),(51,'0101','Logged In','2017-02-04 00:35:13'),(52,'0101','Logged Out','2017-02-04 00:35:22'),(53,'0101','Logged In','2017-02-04 00:41:28'),(54,'0101','Logged In','2017-02-04 00:47:45'),(55,'0101','Logged In','2017-02-04 00:49:21'),(56,'0101','Logged In','2017-02-04 01:06:56'),(57,'0101','Logged Out','2017-02-04 01:07:04'),(58,'0101','Logged In','2017-02-04 01:17:35'),(59,'0101','Logged In','2017-02-04 01:20:19'),(60,'0101','Logged Out','2017-02-04 01:20:58'),(61,'0101','Logged In','2017-02-04 01:42:37'),(62,'0101','Logged Out','2017-02-04 01:42:54'),(63,'0101','Logged In','2017-02-04 01:42:59'),(64,'0101','Logged In','2017-02-04 01:43:34'),(65,'0101','Logged In','2017-02-04 01:44:22'),(66,'0101','Logged In','2017-02-04 01:46:00'),(67,'0101','Logged Out','2017-02-04 01:46:08'),(68,'0101','Logged In','2017-02-04 01:46:26'),(69,'0101','Logged In','2017-02-04 01:47:25'),(70,'0101','Logged In','2017-02-04 01:49:29'),(71,'0101','Logged Out','2017-02-04 01:49:47'),(72,'0101','Logged In','2017-02-04 01:51:04'),(73,'0101','Logged In','2017-02-04 02:26:43'),(74,'0101','Logged Out','2017-02-04 02:26:59'),(75,'0101','Logged In','2017-02-04 02:27:43'),(76,'0101','Logged Out','2017-02-04 02:28:34'),(77,'0101','Logged In','2017-02-04 02:32:27'),(78,'0101','Logged Out','2017-02-04 02:32:44'),(79,'0101','Logged In','2017-02-04 02:53:31'),(80,'0101','Logged Out','2017-02-04 02:53:43'),(81,'0101','Logged In','2017-02-04 02:54:45'),(82,'0101','Logged In','2017-02-04 02:55:42'),(83,'0101','Logged In','2017-02-04 02:56:52'),(84,'0101','Logged In','2017-02-04 02:58:29'),(85,'0101','Logged In','2017-02-04 02:58:57'),(86,'0101','Logged Out','2017-02-04 02:59:11'),(87,'0101','Logged In','2017-02-04 03:12:40'),(88,'0101','Logged Out','2017-02-04 03:13:13'),(89,'0101','Logged In','2017-02-04 03:13:54'),(90,'0101','Logged Out','2017-02-04 03:14:26'),(91,'0101','Logged In','2017-02-04 03:30:41'),(92,'0101','Logged In','2017-02-04 03:31:51'),(93,'0101','Logged Out','2017-02-04 03:34:34'),(94,'0101','Logged In','2017-02-04 03:36:36'),(95,'0101','Logged Out','2017-02-04 03:36:54'),(96,'0101','Logged In','2017-02-04 03:37:39'),(97,'0101','Logged In','2017-02-04 03:40:11'),(98,'0101','Logged In','2017-02-04 03:40:53'),(99,'0101','Logged In','2017-02-04 03:43:45'),(100,'0101','Logged In','2017-02-04 03:45:59'),(101,'0101','Logged In','2017-02-04 03:47:37'),(102,'0101','Logged Out','2017-02-04 03:49:55'),(103,'0101','Logged In','2017-02-04 03:57:11'),(104,'0101','Logged In','2017-02-04 03:58:25'),(105,'0101','Logged In','2017-02-04 03:58:58'),(106,'0101','Logged In','2017-02-04 04:00:19'),(107,'0101','Logged In','2017-02-04 04:01:17'),(108,'0101','Logged Out','2017-02-04 04:01:53'),(109,'0101','Logged In','2017-02-04 04:06:34'),(110,'0101','Logged Out','2017-02-04 04:07:14'),(111,'0101','Logged In','2017-02-04 04:23:04'),(112,'0101','Logged In','2017-02-04 04:23:37'),(113,'0101','Logged In','2017-02-04 04:25:04'),(114,'0101','Logged In','2017-02-04 04:27:19'),(115,'0101','Logged In','2017-02-04 04:28:44'),(116,'0101','Logged Out','2017-02-04 04:29:10'),(117,'0101','Logged In','2017-02-04 04:38:34'),(118,'0101','Logged In','2017-02-04 04:39:47'),(119,'0101','Logged In','2017-02-04 04:40:32'),(120,'0101','Logged Out','2017-02-04 04:41:11'),(121,'0101','Logged In','2017-02-04 04:41:18'),(122,'0101','Logged In','2017-02-04 04:50:57'),(123,'0101','Updated Supplier Name - Supplier ID: 01','2017-02-04 04:54:30'),(124,'0101','Updated Supplier Name - Supplier ID: 02','2017-02-04 04:54:56'),(125,'0101','Updated Supplier Name - Supplier ID: 01','2017-02-04 04:55:13'),(126,'0101','Logged In','2017-02-04 05:02:14'),(127,'0101','Updated Product Name - Product ID: 0100000014','2017-02-04 05:03:39'),(128,'0101','Updated Product Name - Product ID: 0100000015','2017-02-04 05:03:52'),(129,'0101','Updated Product Name - Product ID: 0100000016','2017-02-04 05:04:11'),(130,'0101','Updated Product Name - Product ID: 0100000017','2017-02-04 05:04:26'),(131,'0101','Updated Product Name - Product ID: 0100000018','2017-02-04 05:04:40'),(132,'0101','Updated Product Name - Product ID: 0100000020','2017-02-04 05:04:59'),(133,'0101','Updated Product Name - Product ID: 0100000021','2017-02-04 05:05:37'),(134,'0101','Updated Product Name - Product ID: 0100000022','2017-02-04 05:05:52'),(135,'0101','Updated Product Name - Product ID: 0100000022','2017-02-04 05:06:02'),(136,'0101','Updated Product Name - Product ID: 0100000023','2017-02-04 05:06:47'),(137,'0101','Updated Product Name - Product ID: 0100000024','2017-02-04 05:07:23'),(138,'0101','Updated Product Name - Product ID: 0100000025','2017-02-04 05:07:34'),(139,'0101','Updated Product Name - Product ID: 0100000026','2017-02-04 05:07:46'),(140,'0101','Logged In','2017-02-04 05:10:52'),(141,'0101','Logged In','2017-02-04 05:29:44'),(142,'0101','Logged In','2017-02-04 05:30:52'),(143,'0101','Logged Out','2017-02-04 05:31:23'),(144,'0101','Logged In','2017-02-04 05:34:34'),(145,'0101','Logged Out','2017-02-04 05:35:51'),(146,'0101','Logged In','2017-02-04 05:41:37'),(147,'0101','Logged Out','2017-02-04 05:41:51'),(148,'0101','Logged In','2017-02-04 05:42:27'),(149,'0101','Logged Out','2017-02-04 05:42:37'),(150,'0101','Logged In','2017-02-04 05:42:58'),(151,'0101','Logged Out','2017-02-04 05:43:11'),(152,'0101','Logged In','2017-02-04 05:43:47'),(153,'0101','Logged Out','2017-02-04 05:44:04'),(154,'0101','Logged In','2017-02-04 05:44:39'),(155,'0101','Logged In','2017-02-04 05:45:39'),(156,'0101','Logged In','2017-02-04 05:47:03'),(157,'0101','Logged Out','2017-02-04 05:47:18'),(158,'0101','Logged In','2017-02-04 05:47:47'),(159,'0101','Logged Out','2017-02-04 05:48:41'),(160,'0101','Logged In','2017-02-04 05:49:25'),(161,'0101','Logged Out','2017-02-04 05:53:10'),(162,'0101','Logged In','2017-02-04 05:53:57'),(163,'0101','Logged Out','2017-02-04 05:55:13'),(164,'0101','Logged In','2017-02-04 05:58:58'),(165,'0101','Logged Out','2017-02-04 05:59:30'),(166,'0101','Logged In','2017-02-04 06:01:12'),(167,'0101','Logged Out','2017-02-04 06:01:49'),(168,'0101','Logged In','2017-02-04 06:10:30'),(169,'0101','Logged In','2017-02-04 06:12:45'),(170,'0101','Logged In','2017-02-04 06:14:51'),(171,'0101','Logged In','2017-02-04 06:15:31'),(172,'0101','Logged Out','2017-02-04 06:16:47'),(173,'0101','Logged In','2017-02-04 06:17:40'),(174,'0101','Logged Out','2017-02-04 06:18:22'),(175,'0101','Logged In','2017-02-04 06:26:41'),(176,'0101','Logged Out','2017-02-04 06:27:14'),(177,'0101','Logged In','2017-02-04 06:57:28'),(178,'0101','Logged Out','2017-02-04 06:57:44'),(179,'0101','Logged In','2017-02-04 07:15:30'),(180,'0101','Logged Out','2017-02-04 07:15:46'),(181,'0101','Logged In','2017-02-04 07:17:04'),(182,'0101','Logged Out','2017-02-04 07:17:19'),(183,'0101','Logged In','2017-02-04 07:19:11'),(184,'0101','Logged In','2017-02-04 07:19:54'),(185,'0101','Logged In','2017-02-04 07:22:40'),(186,'0101','Logged In','2017-02-04 07:23:39'),(187,'0101','Logged In','2017-02-04 07:24:34'),(188,'0101','Logged In','2017-02-04 07:47:37'),(189,'0101','Logged In','2017-02-04 07:48:42'),(190,'0101','Logged Out','2017-02-04 07:50:25'),(191,'0101','Logged In','2017-02-04 07:50:30'),(192,'0101','Logged In','2017-02-04 07:53:41'),(193,'0101','Logged In','2017-02-04 07:55:27'),(194,'0101','Logged In','2017-02-04 07:57:02'),(195,'0101','Logged Out','2017-02-04 08:00:38'),(196,'0101','Logged In','2017-02-04 08:01:14'),(197,'0101','Logged In','2017-02-04 08:06:28'),(198,'0101','Logged In','2017-02-04 08:11:21'),(199,'0101','Logged In','2017-02-04 08:14:08'),(200,'0101','Logged Out','2017-02-04 08:14:52'),(201,'0101','Logged In','2017-02-04 08:16:23'),(202,'0101','Logged In','2017-02-04 08:20:31'),(203,'0101','Logged In','2017-02-04 08:22:24'),(204,'0101','Logged Out','2017-02-04 08:23:31'),(205,'0101','Logged In','2017-02-04 08:25:40'),(206,'0101','Logged In','2017-02-04 08:30:10'),(207,'0101','Logged In','2017-02-04 08:36:50'),(208,'0101','Logged Out','2017-02-04 08:37:02'),(209,'0101','Logged In','2017-02-04 11:56:51');

/*Table structure for table `category` */

DROP TABLE IF EXISTS `category`;

CREATE TABLE `category` (
  `CategoryID` varchar(3) NOT NULL,
  `Type` int(2) DEFAULT NULL,
  `Name` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`CategoryID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `category` */

insert  into `category`(`CategoryID`,`Type`,`Name`) values ('101',1,'Ala Carte'),('102',1,'Combo Meals'),('103',1,'Sandwiches'),('104',1,'Pancakes'),('105',1,'Additional Charges'),('201',2,'Cup Noodles'),('202',2,'Snacks-Chips and Biscuits'),('203',2,'Candies'),('204',2,'Hot Drinks'),('205',2,'Beers'),('206',2,'Juice and Soda'),('207',2,'Shampoo and Conditioner'),('208',2,'Bath Soap'),('209',2,'Cigarettes'),('210',2,'Other Items');

/*Table structure for table `constorekitchensales` */

DROP TABLE IF EXISTS `constorekitchensales`;

CREATE TABLE `constorekitchensales` (
  `CSKS_Code` varchar(10) NOT NULL,
  `TransactionNo` varchar(10) DEFAULT NULL,
  `DateOfSale` datetime DEFAULT NULL,
  `ProductCode` varchar(10) DEFAULT NULL,
  `Quantity` int(3) DEFAULT NULL,
  `TotalAmount` double(10,2) DEFAULT NULL,
  `Remarks` varchar(45) DEFAULT NULL,
  PRIMARY KEY (`CSKS_Code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `constorekitchensales` */

insert  into `constorekitchensales`(`CSKS_Code`,`TransactionNo`,`DateOfSale`,`ProductCode`,`Quantity`,`TotalAmount`,`Remarks`) values ('CK00000000','0000000001','2017-02-04 08:23:11','0100000006',10,800.00,'UNPAID'),('CK00000001','0000000002','2017-02-04 11:57:02','0100000008',1,80.00,'UNPAID'),('CK00000002','0000000002','2017-02-04 11:57:26','0100000008',1,80.00,'UNPAID');

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

insert  into `guest`(`GuestID`,`FirstName`,`LastName`,`Address`,`Company`,`MobileNo`) values ('0000000001','ERWIN','PLAZA','FAIRVIEW, QUEZON CITY','MOSCONI TOURS INC.','09155510223'),('0000000002','ERWIN','PLAZA','FAIRVIEW, QUEZON CITY','MOSCONI TOURS INC','09155510223'),('0000000003','ERWIN','PLAZA','FAIRVIEW QUEZON CITY','MOSCONI TOURS','09155510223'),('0000000004','ERWIN','PLAZA','FAIRVIEW, QUEZON CITY','MOSCONI TOURS INC','09155510223'),('0000000005','ERWIN','PLAZA','FAIRVIEW, QUEZON CITY','MOSCONI TOURS INC','09155510223'),('0000000006','ERWIN','PLAZA','QC','MOSCONI','09155510223'),('0000000007','QWE','QWE','QWE','QWE','123'),('0000000008','qwe','qwe','qwe','qwe','123'),('0000000009','qwe','qwe','qwe','qwe123','123'),('0000000010','qwe','qwe','qwe','qwe123','123'),('0000000011','qwe','qwe','qwe','qwe123','123'),('0000000012','qwe','qwe','qwe','qwe','12'),('0000000013','wqe','qwe','qwe','qwe','12'),('0000000014','qwe','qwe','qwe','qwe','12'),('0000000015','ERWIN','PLAZA','FAIRVIEW, QUEZON CITY','MOSCONI TOURS INC','09155510223'),('0000000016','BRYAN','LIM','CALOOCAN','GOOGLE','09123456666');

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

insert  into `inventory`(`InventoryID`,`ProductCode`,`QtyOnHand`,`Status`) values ('I000000001','0100000001',46,'AVAILABLE'),('I000000002','0100000002',50,'AVAILABLE'),('I000000003','0100000003',50,'AVAILABLE'),('I000000004','0100000004',50,'AVAILABLE'),('I000000005','0100000005',50,'AVAILABLE'),('I000000006','0100000006',38,'AVAILABLE'),('I000000007','0100000007',50,'AVAILABLE'),('I000000008','0100000008',48,'AVAILABLE'),('I000000009','0100000009',0,'OUT OF STOCK'),('I000000010','0100000010',48,'AVAILABLE'),('I000000011','0100000011',50,'AVAILABLE'),('I000000012','0100000012',50,'OUT OF STOCK'),('I000000013','0100000013',50,'AVAILABLE'),('I000000014','0100000014',20,'CRITICAL'),('I000000015','0100000015',20,'CRITICAL'),('I000000016','0100000016',20,'CRITICAL'),('I000000017','0100000017',20,'CRITICAL');

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

insert  into `product`(`ProductCode`,`SupplierID`,`CategoryID`,`UnitID`,`Name`,`SupplierPrice`,`SellingPrice`,`CriticalLevel`) values ('0100000001','01','101',1,'ADOBO',90.00,99.00,23),('0100000002','01','101',1,'BACON',70.00,80.00,20),('0100000003','01','101',1,'BEEF STEAK',90.00,99.00,20),('0100000004','01','101',1,'CHICKEN KATSU',90.00,99.00,20),('0100000005','01','101',1,'CORNED BEEF',70.00,80.00,10),('0100000006','01','101',1,'HAM',50.00,80.00,20),('0100000007','01','101',1,'HUNGARIAN SAUSAGE',60.00,85.00,20),('0100000008','01','101',1,'LUMPIANG SHANGHAI',70.00,80.00,20),('0100000009','01','101',1,'LUNCHEON MEAT',70.00,80.00,20),('0100000010','01','101',1,'PANCIT BIHON',70.00,100.00,20),('0100000011','01','101',1,'SINIGANG NA BABOY',70.00,99.00,20),('0100000012','01','101',1,'TAPA',70.00,99.00,20),('0100000013','01','101',1,'TOCINO',60.00,80.00,20),('0100000014','01','102',1,'ADOBO COMBO MEALS',130.00,130.00,20),('0100000015','01','102',1,'BACON COMBO MEALS',110.00,110.00,20),('0100000016','01','102',1,'BEEF STEAK COMBO MEAL',130.00,130.00,20),('0100000017','01','102',1,'CHICKEN KATSU COMBO MEAL',130.00,130.00,20),('0100000018','01','102',1,'CORNED BEEF COMBO MEAL',110.00,110.00,20),('0100000019','01','102',1,'DAING NA BANGUS',130.00,130.00,20),('0100000020','01','102',1,'HAM COMBO MEALS',110.00,110.00,20),('0100000021','01','102',1,'HUNGARIAN SAUSAGE COMBO M',110.00,120.00,20),('0100000022','01','102',1,'LUMPIANG SHANGHAI COMBO M',110.00,120.00,20),('0100000023','01','102',1,'LUNCHEON MEAT COMBO MEAL',100.00,110.00,20),('0100000024','01','102',1,'SINIGANG NA BABOY COMBO',120.00,130.00,20),('0100000025','01','102',1,'TAPA COMBO',120.00,130.00,20),('0100000026','01','102',1,'TOCINO COMBO',100.00,110.00,20),('0100000027','01','102',1,'FRIED RICE IN COMBO',5.00,10.00,20),('0100000028','01','103',1,'BACON SANDWICH',70.00,85.00,20),('0100000029','01','103',1,'BACON W/ CHEESE AND EGG S',70.00,95.00,20),('0100000030','01','103',1,'HAM & CHEESE SANDWICH',75.00,85.00,20),('0100000031','01','103',1,'HAM W/ CHEESE AND EGG SAN',85.00,95.00,20),('0100000032','01','103',1,'JOLLYDOG SANDWICH',60.00,75.00,20),('0100000033','01','103',1,'TUNA SANDWICH',60.00,75.00,20),('0100000034','01','103',1,'EGG SANDWICH',40.00,50.00,20),('0100000035','01','104',1,'PLAIN PANCAKE',70.00,75.00,20),('0100000036','01','104',1,'PANCAKE WITH COFFEE',70.00,95.00,20),('0100000037','01','105',2,'PAPER PLATE',5.00,10.00,20),('0100000038','01','105',2,'BOWL',3.00,5.00,20),('0100000039','01','105',4,'ICE BUCKET',10.00,20.00,20),('0100000040','01','105',2,'SPOON AND FORK',5.00,10.00,20),('0100000041','01','105',1,'FRIED RICE',20.00,30.00,20),('0100000042','01','105',1,'PLAIN RICE',20.00,25.00,20),('0100000043','01','105',1,'EGG',10.00,20.00,20),('0200000001','02','201',2,'BATCHOY',30.00,35.00,20),('0200000002','02','201',2,'BEEF',30.00,35.00,20),('0200000003','02','201',2,'BULALO',30.00,35.00,20),('0200000004','02','201',2,'CHICKEN',30.00,35.00,20),('0200000005','02','201',2,'SEAFOOD',30.00,35.00,20),('0200000006','02','201',2,'SPICY BEEF',30.00,35.00,20),('0200000007','02','201',2,'SPICY SEAFOOD',30.00,35.00,20),('0200000008','02','202',2,'POTATO CHIPS V-CUT BBQ',10.00,20.00,20),('0200000009','02','202',2,'PIATTOS CHEESE (85G)',10.00,20.00,20),('0200000010','02','202',2,'PIATTOS SOUR CREAM (85G)',10.00,20.00,20),('0200000011','02','202',2,'NAGARAYA ORIGINAL (YELLOW',15.00,25.00,20),('0200000012','02','202',2,'NAGARAYA GARLIC (HOT AND ',3.00,5.00,20),('0200000013','02','202',2,'NAGARAYA GARLIC (GREEN)',2.00,5.00,20),('0200000014','02','202',2,'CLOUD9 CLASSIC',10.00,15.00,20),('0200000015','02','202',2,'CLOUD 9 WHITE',10.00,15.00,20),('0200000016','02','202',2,'TEMPURA',20.00,30.00,20),('0200000017','02','202',2,'SKYFLAKES',5.00,10.00,20),('0200000018','02','202',2,'FITA',5.00,10.00,20),('0200000019','02','202',2,'OREO',10.00,15.00,20),('0200000020','02','202',2,'FUDGEE BAR',10.00,15.00,20),('0200000021','02','203',2,'MAX',1.00,2.00,20),('0200000022','02','203',2,'FRES CHERRY CANDY',1.00,2.00,20),('0200000023','02','204',2,'NESCAFE Creamy Latte',20.00,25.00,20),('0200000024','02','204',2,'NESCAFE Original',20.00,25.00,20),('0200000025','02','204',2,'NESCAFE Berry Mocha',20.00,25.00,20),('0200000026','02','204',2,'NESCAFE Creamy White',20.00,25.00,20),('0200000027','02','204',2,'MILO',20.00,25.00,20),('0200000028','02','204',2,'LIPTON TEA',20.00,25.00,20),('0200000029','02','205',2,'SAN MIG LIGHT',40.00,50.00,20),('0200000030','02','205',2,'SAN MIG APPLE',40.00,50.00,20),('0200000031','02','205',2,'SAN MIG LEMON',40.00,50.00,20),('0200000032','02','205',2,'EMPERADOR LIGHTS',140.00,155.00,20),('0200000033','02','205',2,'REDHORSE',40.00,50.00,20),('0200000034','02','206',2,'COKE REGULAR',40.00,50.00,20),('0200000035','02','206',2,'COKE ZERO',40.00,50.00,20),('0200000036','02','206',2,'MUG ROOT BEER',40.00,50.00,20),('0200000037','02','206',2,'MOUNTAIN DEW',40.00,50.00,20),('0200000038','02','206',2,'PEPSI BLUE',40.00,50.00,20),('0200000039','02','206',2,'ROYAL',40.00,50.00,20),('0200000040','02','206',2,'SPRITE',40.00,50.00,20),('0200000041','02','206',2,'C2 SOLO APPLE SOLO',20.00,25.00,20),('0200000042','02','206',2,'C2 SOLO LEMON SOLO',20.00,25.00,20),('0200000043','02','206',2,'C2 SOLO APPLE REGULAR',20.00,30.00,20),('0200000044','02','206',2,'C2 SOLO LEMON REGULAR',30.00,40.00,20),('0200000045','02','206',2,'DELMONTE PINEAPPLE JUICE',40.00,50.00,20),('0200000046','02','206',2,'MINUTE MAID FRESH JUICE',30.00,40.00,20),('0200000047','02','206',2,'VIVA WATER',10.00,20.00,20),('0200000048','02','206',2,'REFILL WATER',15.00,20.00,20),('0200000049','02','206',2,'GATORADE',30.00,40.00,20),('0200000050','02','207',2,'DOVE',7.00,10.00,20),('0200000051','02','207',2,'HEAD AND SHOULDERS',6.00,10.00,20),('0200000052','02','207',2,'SUNSILK',7.00,10.00,20),('0200000053','02','207',2,'CREAMSILK GOLD',8.00,12.00,20),('0200000054','02','207',2,'CREAMSILK PINK',8.00,12.00,20),('0200000055','02','208',2,'INTEGRITY BATH SOAP',6.00,10.00,20),('0200000056','02','208',2,'SAFE GUARD',15.00,25.00,20),('0200000057','02','209',3,'MARLBORO (green) PACK',90.00,100.00,20),('0200000058','02','209',3,'MARLBORO (green)1/2 pack',40.00,50.00,20),('0200000059','02','209',3,'MARLBORO (red) PACK',90.00,100.00,20),('0200000060','02','209',3,'MARLBORO (red) 1/2 pack',40.00,50.00,20),('0200000061','02','209',3,'MARLBORO (lights) PACK',90.00,100.00,20),('0200000062','02','209',3,'MARLBORO (lights) 1/2 pac',40.00,50.00,20),('0200000063','02','209',3,'MARLBORO (black) PACK',90.00,100.00,20),('0200000064','02','209',3,'MARLBORO (Black)1/2 pack',40.00,50.00,20),('0200000065','02','209',3,'MARLBORO (Blue) Pack',90.00,100.00,20),('0200000066','02','209',3,'PALL MALL',90.00,100.00,20),('0200000067','02','210',2,'LIGHTER',20.00,30.00,20),('0200000068','02','210',2,'TISSUE',10.00,15.00,20),('0200000069','02','210',2,'MODESS',10.00,12.00,20),('0200000070','02','210',2,'CHARMEE PANTYLINNER',7.00,10.00,20),('0200000071','02','210',2,'COLGATE (SACHET) GREEN',10.00,15.00,20),('0200000072','02','210',2,'FEMININE WASH',10.00,15.00,20),('0200000073','02','210',2,'LUBRICANT JELLY',40.00,50.00,20),('0200000074','02','210',2,'CONDOM',40.00,50.00,20);

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
  `Floor` varchar(4) DEFAULT NULL,
  `PhoneNo` varchar(11) DEFAULT NULL,
  `Status` varchar(25) DEFAULT NULL,
  `Picture` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`RoomNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `room` */

insert  into `room`(`RoomNo`,`RoomTypeID`,`RoomName`,`Floor`,`PhoneNo`,`Status`,`Picture`) values (1,2,'MACAU','1st','101','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(2,2,'BAGUIO','1st','102','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(3,2,'DUBAI','2nd','132','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(4,2,'KUALA LUMPUR','2nd','131','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(5,1,'PUERTO GALERA','3rd','111','OCCUPIED','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(6,1,'EL NIDO','3rd','112','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(7,1,'LAOAG','4th','187','OCCUPIED','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(8,1,'ALBAY','4th','186','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(9,2,'BANGKOK','2nd','104','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg'),(10,2,'HONG KONG','2nd','103','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg'),(11,2,'SINGAPORE','2nd','105','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg'),(12,1,'PALAWAN','3rd','108','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg'),(13,1,'BORACAY','3rd','110','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg'),(14,1,'CEBU','3rd','109','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg');

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
  `IsDiscounted` int(1) DEFAULT NULL,
  `DiscountedRate` int(3) DEFAULT NULL,
  `RoomCharges` double(10,2) DEFAULT NULL,
  `OtherCharges` double(10,2) DEFAULT NULL,
  `TotalCharge` double(10,2) DEFAULT NULL,
  `TotalPaid` double(10,2) DEFAULT NULL,
  `Remarks` varchar(10000) DEFAULT NULL,
  `IsCurrentlyCheckedIn` int(1) DEFAULT NULL,
  PRIMARY KEY (`TransactionNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `roomsales` */

insert  into `roomsales`(`TransactionNo`,`RoomNo`,`GuestID`,`Pax`,`CheckInDateTime`,`Duration`,`ExpectedCheckOut`,`Deposit`,`IsDiscounted`,`DiscountedRate`,`RoomCharges`,`OtherCharges`,`TotalCharge`,`TotalPaid`,`Remarks`,`IsCurrentlyCheckedIn`) values ('0000000001',7,'0000000015',2,'2017-02-04 08:22:53',22,'2017-02-05 06:22:53',1000.00,0,0,1000.00,800.00,1800.00,1000.00,'',1),('0000000002',5,'0000000016',2,'2017-02-04 08:26:05',22,'2017-02-05 06:26:05',1000.00,0,0,1000.00,160.00,1160.00,1000.00,'',1);

/*Table structure for table `roomtype` */

DROP TABLE IF EXISTS `roomtype`;

CREATE TABLE `roomtype` (
  `RoomTypeId` int(2) NOT NULL AUTO_INCREMENT,
  `Name` varchar(25) DEFAULT NULL,
  `MaxCap` int(2) DEFAULT NULL,
  `Rate_1` double(10,2) DEFAULT NULL,
  `Rate_2` double(10,2) DEFAULT NULL,
  `Rate_3` double(10,2) DEFAULT NULL,
  `ExtensionRate` double(10,2) DEFAULT NULL,
  PRIMARY KEY (`RoomTypeId`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COMMENT='		';

/*Data for the table `roomtype` */

insert  into `roomtype`(`RoomTypeId`,`Name`,`MaxCap`,`Rate_1`,`Rate_2`,`Rate_3`,`ExtensionRate`) values (1,'Studio Type',2,495.00,700.00,1000.00,200.00),(2,'One Bed Rooms',4,595.00,820.00,1240.00,200.00);

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

insert  into `supplier`(`SupplierID`,`SupplierName`,`SupplierAddress`,`SupplierContactNo`) values ('01','SDR Kitchen','Cainta, Rizal','09465612312'),('02','Pure Gold','Cainta, Rizal','0915510223');

/*Table structure for table `unit` */

DROP TABLE IF EXISTS `unit`;

CREATE TABLE `unit` (
  `UnitID` int(3) NOT NULL AUTO_INCREMENT,
  `UnitName` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`UnitID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

/*Data for the table `unit` */

insert  into `unit`(`UnitID`,`UnitName`) values (1,'per order'),(2,'per piece'),(3,'per pack'),(4,'per bucket');

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
