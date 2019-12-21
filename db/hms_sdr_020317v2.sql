/*
SQLyog Ultimate v11.11 (32 bit)
MySQL - 5.0.7-beta-nt : Database - hms_sdr
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
  `TrailNo` int(3) NOT NULL auto_increment,
  `UserID` varchar(4) default NULL,
  `Activity` varchar(100) default NULL,
  `DateTime` datetime default NULL,
  PRIMARY KEY  (`TrailNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `audit_trail` */

insert  into `audit_trail`(`TrailNo`,`UserID`,`Activity`,`DateTime`) values (30,'0101','Logged In','2017-02-03 12:58:25'),(31,'0101','Logged In','2017-02-03 13:10:48'),(32,'0101','Logged In','2017-02-03 13:16:18'),(33,'0101','Logged In','2017-02-03 13:17:00'),(34,'0101','Logged Out','2017-02-03 13:17:11'),(35,'0101','Logged In','2017-02-03 13:18:08'),(36,'0101','Logged In','2017-02-03 13:19:22'),(37,'0101','Logged In','2017-02-03 13:24:22'),(38,'0101','Logged Out','2017-02-03 13:25:13'),(39,'0101','Logged In','2017-02-03 13:27:37'),(40,'0101','Logged In','2017-02-03 13:28:48'),(41,'0101','Logged In','2017-02-03 13:30:15'),(42,'0101','Logged In','2017-02-03 13:31:11'),(43,'0101','Logged In','2017-02-03 13:32:58'),(44,'0101','Logged In','2017-02-03 13:33:26'),(45,'0101','Logged In','2017-02-03 13:35:47'),(46,'0101','Logged Out','2017-02-03 13:36:04'),(47,'0101','Logged In','2017-02-03 14:20:44'),(48,'0101','Logged In','2017-02-03 14:24:21');

/*Table structure for table `category` */

DROP TABLE IF EXISTS `category`;

CREATE TABLE `category` (
  `CategoryID` varchar(3) NOT NULL,
  `Type` int(2) default NULL,
  `Name` varchar(45) default NULL,
  PRIMARY KEY  (`CategoryID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `category` */

insert  into `category`(`CategoryID`,`Type`,`Name`) values ('101',1,'Ala Carte'),('102',1,'Combo Meals'),('103',1,'Sandwiches'),('104',1,'Pancakes'),('105',1,'Additional Charges'),('201',2,'Cup Noodles'),('202',2,'Snacks-Chips and Biscuits'),('203',2,'Candies'),('204',2,'Hot Drinks'),('205',2,'Beers'),('206',2,'Juice and Soda'),('207',2,'Shampoo and Conditioner'),('208',2,'Bath Soap'),('209',2,'Cigarettes'),('210',2,'Other Items');

/*Table structure for table `constorekitchensales` */

DROP TABLE IF EXISTS `constorekitchensales`;

CREATE TABLE `constorekitchensales` (
  `CSKS_Code` varchar(10) NOT NULL,
  `TransactionNo` varchar(10) default NULL,
  `DateOfSale` datetime default NULL,
  `ProductCode` varchar(10) default NULL,
  `Quantity` int(3) default NULL,
  `TotalAmount` double(10,2) default NULL,
  `Remarks` varchar(45) default NULL,
  PRIMARY KEY  (`CSKS_Code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `constorekitchensales` */

/*Table structure for table `dailyinventorylisting` */

DROP TABLE IF EXISTS `dailyinventorylisting`;

CREATE TABLE `dailyinventorylisting` (
  `DIL_ID` varchar(10) NOT NULL,
  `Date` date default NULL,
  `ProductCode` varchar(10) default NULL,
  `QtyOnHand` int(3) default NULL,
  PRIMARY KEY  (`DIL_ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `dailyinventorylisting` */

/*Table structure for table `guest` */

DROP TABLE IF EXISTS `guest`;

CREATE TABLE `guest` (
  `GuestID` varchar(10) NOT NULL,
  `FirstName` varchar(25) default NULL,
  `LastName` varchar(25) default NULL,
  `Address` varchar(100) default NULL,
  `Company` varchar(25) default NULL,
  `MobileNo` varchar(11) default NULL,
  PRIMARY KEY  (`GuestID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `guest` */

insert  into `guest`(`GuestID`,`FirstName`,`LastName`,`Address`,`Company`,`MobileNo`) values ('0000000001','ERWIN','PLAZA','FAIRVIEW, QUEZON CITY','MOSCONI TOURS INC.','09155510223'),('0000000002','ERWIN','PLAZA','FAIRVIEW, QUEZON CITY','MOSCONI TOURS INC','09155510223');

/*Table structure for table `inventory` */

DROP TABLE IF EXISTS `inventory`;

CREATE TABLE `inventory` (
  `InventoryID` varchar(10) NOT NULL,
  `ProductCode` varchar(10) default NULL,
  `QtyOnHand` int(3) default NULL,
  `Status` varchar(25) default NULL,
  PRIMARY KEY  (`InventoryID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `inventory` */

/*Table structure for table `product` */

DROP TABLE IF EXISTS `product`;

CREATE TABLE `product` (
  `ProductCode` varchar(10) NOT NULL,
  `SupplierID` varchar(2) default NULL,
  `CategoryID` varchar(3) default NULL,
  `UnitID` int(3) default NULL,
  `Name` varchar(25) default NULL,
  `SupplierPrice` double(10,2) default NULL,
  `SellingPrice` double(10,2) default NULL,
  `CriticalLevel` int(3) default NULL,
  PRIMARY KEY  (`ProductCode`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `product` */

insert  into `product`(`ProductCode`,`SupplierID`,`CategoryID`,`UnitID`,`Name`,`SupplierPrice`,`SellingPrice`,`CriticalLevel`) values ('0100000001','01','101',1,'ADOBO',90.00,99.00,23),('0100000002','01','101',1,'BACON',70.00,80.00,20),('0100000003','01','101',1,'BEEF STEAK',90.00,99.00,20),('0100000004','01','101',1,'CHICKEN KATSU',90.00,99.00,20),('0100000005','01','101',1,'CORNED BEEF',70.00,80.00,10),('0100000006','01','101',1,'HAM',50.00,80.00,20),('0100000007','01','101',1,'HUNGARIAN SAUSAGE',60.00,85.00,20),('0100000008','01','101',1,'LUMPIANG SHANGHAI',70.00,80.00,20),('0100000009','01','101',1,'LUNCHEON MEAT',70.00,80.00,20),('0100000010','01','101',1,'PANCIT BIHON',70.00,100.00,20),('0100000011','01','101',1,'SINIGANG NA BABOY',70.00,99.00,20),('0100000012','01','101',1,'TAPA',70.00,99.00,20),('0100000013','01','101',1,'TOCINO',60.00,80.00,20),('0100000014','01','102',1,'ADOBO',130.00,130.00,20),('0100000015','01','102',1,'BACON',110.00,110.00,20),('0100000016','01','102',1,'BEEF STEAK',130.00,130.00,20),('0100000017','01','102',1,'CHICKEN KATSU',130.00,130.00,20),('0100000018','01','102',1,'CORNED BEEF',110.00,110.00,20),('0100000019','01','102',1,'DAING NA BANGUS',130.00,130.00,20),('0100000020','01','102',1,'HAM',110.00,110.00,20),('0100000021','01','102',1,'HUNGARIAN SAUSAGE',110.00,120.00,20),('0100000022','01','102',1,'LUMPIANG SHANGHAI',110.00,120.00,20),('0100000023','01','102',1,'LUNCHEON MEAT',100.00,110.00,20),('0100000024','01','102',1,'SINIGANG NA BABOY',120.00,130.00,20),('0100000025','01','102',1,'TAPA',120.00,130.00,20),('0100000026','01','102',1,'TOCINO',100.00,110.00,20),('0100000027','01','102',1,'FRIED RICE IN COMBO',5.00,10.00,20),('0100000028','01','103',1,'BACON SANDWICH',70.00,85.00,20),('0100000029','01','103',1,'BACON W/ CHEESE AND EGG S',70.00,95.00,20),('0100000030','01','103',1,'HAM & CHEESE SANDWICH',75.00,85.00,20),('0100000031','01','103',1,'HAM W/ CHEESE AND EGG SAN',85.00,95.00,20),('0100000032','01','103',1,'JOLLYDOG SANDWICH',60.00,75.00,20),('0100000033','01','103',1,'TUNA SANDWICH',60.00,75.00,20),('0100000034','01','103',1,'EGG SANDWICH',40.00,50.00,20),('0100000035','01','104',1,'PLAIN PANCAKE',70.00,75.00,20),('0100000036','01','104',1,'PANCAKE WITH COFFEE',70.00,95.00,20),('0100000037','01','105',2,'PAPER PLATE',5.00,10.00,20),('0100000038','01','105',2,'BOWL',3.00,5.00,20),('0100000039','01','105',4,'ICE BUCKET',10.00,20.00,20),('0100000040','01','105',2,'SPOON AND FORK',5.00,10.00,20),('0100000041','01','105',1,'FRIED RICE',20.00,30.00,20),('0100000042','01','105',1,'PLAIN RICE',20.00,25.00,20),('0100000043','01','105',1,'EGG',10.00,20.00,20),('0200000001','02','201',2,'BATCHOY',30.00,35.00,20),('0200000002','02','201',2,'BEEF',30.00,35.00,20),('0200000003','02','201',2,'BULALO',30.00,35.00,20),('0200000004','02','201',2,'CHICKEN',30.00,35.00,20),('0200000005','02','201',2,'SEAFOOD',30.00,35.00,20),('0200000006','02','201',2,'SPICY BEEF',30.00,35.00,20),('0200000007','02','201',2,'SPICY SEAFOOD',30.00,35.00,20),('0200000008','02','202',2,'POTATO CHIPS V-CUT BBQ',10.00,20.00,20),('0200000009','02','202',2,'PIATTOS CHEESE (85G)',10.00,20.00,20),('0200000010','02','202',2,'PIATTOS SOUR CREAM (85G)',10.00,20.00,20),('0200000011','02','202',2,'NAGARAYA ORIGINAL (YELLOW',15.00,25.00,20),('0200000012','02','202',2,'NAGARAYA GARLIC (HOT AND ',3.00,5.00,20),('0200000013','02','202',2,'NAGARAYA GARLIC (GREEN)',2.00,5.00,20),('0200000014','02','202',2,'CLOUD9 CLASSIC',10.00,15.00,20),('0200000015','02','202',2,'CLOUD 9 WHITE',10.00,15.00,20),('0200000016','02','202',2,'TEMPURA',20.00,30.00,20),('0200000017','02','202',2,'SKYFLAKES',5.00,10.00,20),('0200000018','02','202',2,'FITA',5.00,10.00,20),('0200000019','02','202',2,'OREO',10.00,15.00,20),('0200000020','02','202',2,'FUDGEE BAR',10.00,15.00,20),('0200000021','02','203',2,'MAX',1.00,2.00,20),('0200000022','02','203',2,'FRES CHERRY CANDY',1.00,2.00,20),('0200000023','02','204',2,'NESCAFE Creamy Latte',20.00,25.00,20),('0200000024','02','204',2,'NESCAFE Original',20.00,25.00,20),('0200000025','02','204',2,'NESCAFE Berry Mocha',20.00,25.00,20),('0200000026','02','204',2,'NESCAFE Creamy White',20.00,25.00,20),('0200000027','02','204',2,'MILO',20.00,25.00,20),('0200000028','02','204',2,'LIPTON TEA',20.00,25.00,20),('0200000029','02','205',2,'SAN MIG LIGHT',40.00,50.00,20),('0200000030','02','205',2,'SAN MIG APPLE',40.00,50.00,20),('0200000031','02','205',2,'SAN MIG LEMON',40.00,50.00,20),('0200000032','02','205',2,'EMPERADOR LIGHTS',140.00,155.00,20),('0200000033','02','205',2,'REDHORSE',40.00,50.00,20),('0200000034','02','206',2,'COKE REGULAR',40.00,50.00,20),('0200000035','02','206',2,'COKE ZERO',40.00,50.00,20),('0200000036','02','206',2,'MUG ROOT BEER',40.00,50.00,20),('0200000037','02','206',2,'MOUNTAIN DEW',40.00,50.00,20),('0200000038','02','206',2,'PEPSI BLUE',40.00,50.00,20),('0200000039','02','206',2,'ROYAL',40.00,50.00,20),('0200000040','02','206',2,'SPRITE',40.00,50.00,20),('0200000041','02','206',2,'C2 SOLO APPLE SOLO',20.00,25.00,20),('0200000042','02','206',2,'C2 SOLO LEMON SOLO',20.00,25.00,20),('0200000043','02','206',2,'C2 SOLO APPLE REGULAR',20.00,30.00,20),('0200000044','02','206',2,'C2 SOLO LEMON REGULAR',30.00,40.00,20),('0200000045','02','206',2,'DELMONTE PINEAPPLE JUICE',40.00,50.00,20),('0200000046','02','206',2,'MINUTE MAID FRESH JUICE',30.00,40.00,20),('0200000047','02','206',2,'VIVA WATER',10.00,20.00,20),('0200000048','02','206',2,'REFILL WATER',15.00,20.00,20),('0200000049','02','206',2,'GATORADE',30.00,40.00,20),('0200000050','02','207',2,'DOVE',7.00,10.00,20),('0200000051','02','207',2,'HEAD AND SHOULDERS',6.00,10.00,20),('0200000052','02','207',2,'SUNSILK',7.00,10.00,20),('0200000053','02','207',2,'CREAMSILK GOLD',8.00,12.00,20),('0200000054','02','207',2,'CREAMSILK PINK',8.00,12.00,20),('0200000055','02','208',2,'INTEGRITY BATH SOAP',6.00,10.00,20),('0200000056','02','208',2,'SAFE GUARD',15.00,25.00,20),('0200000057','02','209',3,'MARLBORO (green) PACK',90.00,100.00,20),('0200000058','02','209',3,'MARLBORO (green)1/2 pack',40.00,50.00,20),('0200000059','02','209',3,'MARLBORO (red) PACK',90.00,100.00,20),('0200000060','02','209',3,'MARLBORO (red) 1/2 pack',40.00,50.00,20),('0200000061','02','209',3,'MARLBORO (lights) PACK',90.00,100.00,20),('0200000062','02','209',3,'MARLBORO (lights) 1/2 pac',40.00,50.00,20),('0200000063','02','209',3,'MARLBORO (black) PACK',90.00,100.00,20),('0200000064','02','209',3,'MARLBORO (Black)1/2 pack',40.00,50.00,20),('0200000065','02','209',3,'MARLBORO (Blue) Pack',90.00,100.00,20),('0200000066','02','209',3,'PALL MALL',90.00,100.00,20),('0200000067','02','210',2,'LIGHTER',20.00,30.00,20),('0200000068','02','210',2,'TISSUE',10.00,15.00,20),('0200000069','02','210',2,'MODESS',10.00,12.00,20),('0200000070','02','210',2,'CHARMEE PANTYLINNER',7.00,10.00,20),('0200000071','02','210',2,'COLGATE (SACHET) GREEN',10.00,15.00,20),('0200000072','02','210',2,'FEMININE WASH',10.00,15.00,20),('0200000073','02','210',2,'LUBRICANT JELLY',40.00,50.00,20),('0200000074','02','210',2,'CONDOM',40.00,50.00,20);

/*Table structure for table `reservation` */

DROP TABLE IF EXISTS `reservation`;

CREATE TABLE `reservation` (
  `ReservationNo` varchar(10) NOT NULL,
  `GuestID` varchar(10) default NULL,
  `RoomNo` int(2) default NULL,
  `CheckInDate` date default NULL,
  `Duration` int(3) default NULL,
  `ExpectedCheckOut` datetime default NULL,
  `ArrivalDetails` varchar(100) default NULL,
  PRIMARY KEY  (`ReservationNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `reservation` */

/*Table structure for table `room` */

DROP TABLE IF EXISTS `room`;

CREATE TABLE `room` (
  `RoomNo` int(2) NOT NULL,
  `RoomTypeID` int(2) default NULL,
  `RoomName` varchar(25) default NULL,
  `Floor` varchar(4) default NULL,
  `PhoneNo` varchar(11) default NULL,
  `Status` varchar(25) default NULL,
  `Picture` varchar(100) default NULL,
  PRIMARY KEY  (`RoomNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `room` */

insert  into `room`(`RoomNo`,`RoomTypeID`,`RoomName`,`Floor`,`PhoneNo`,`Status`,`Picture`) values (1,2,'MACAU','1st','101','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(2,2,'BAGUIO','1st','102','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(3,2,'DUBAI','2nd','132','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(4,2,'KUALA LUMPUR','2nd','131','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(5,1,'PUERTO GALERA','3rd','111','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(6,1,'EL NIDO','3rd','112','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(7,1,'LAOAG','4th','187','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(8,1,'ALBAY','4th','186','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(9,2,'BANGKOK','2nd','104','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg'),(10,2,'HONG KONG','2nd','103','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg'),(11,2,'SINGAPORE','2nd','105','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg'),(12,1,'PALAWAN','3rd','108','OCCUPIED','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg'),(13,1,'BORACAY','3rd','110','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg'),(14,1,'CEBU','3rd','109','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg');

/*Table structure for table `roomsales` */

DROP TABLE IF EXISTS `roomsales`;

CREATE TABLE `roomsales` (
  `TransactionNo` varchar(10) NOT NULL,
  `RoomNo` int(2) default NULL,
  `GuestID` varchar(10) default NULL,
  `Pax` int(3) default NULL,
  `CheckInDateTime` datetime default NULL,
  `Duration` int(3) default NULL,
  `ExpectedCheckOut` datetime default NULL,
  `Deposit` double(10,2) default NULL,
  `IsDiscounted` int(1) default NULL,
  `DiscountedRate` int(3) default NULL,
  `RoomCharges` double(10,2) default NULL,
  `OtherCharges` double(10,2) default NULL,
  `TotalCharge` double(10,2) default NULL,
  `TotalPaid` double(10,2) default NULL,
  `Remarks` varchar(10000) default NULL,
  `IsCurrentlyCheckedIn` int(1) default NULL,
  PRIMARY KEY  (`TransactionNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `roomsales` */

insert  into `roomsales`(`TransactionNo`,`RoomNo`,`GuestID`,`Pax`,`CheckInDateTime`,`Duration`,`ExpectedCheckOut`,`Deposit`,`IsDiscounted`,`DiscountedRate`,`RoomCharges`,`OtherCharges`,`TotalCharge`,`TotalPaid`,`Remarks`,`IsCurrentlyCheckedIn`) values ('0000000001',12,'0000000001',2,'2017-02-03 12:58:49',44,'2017-02-05 08:58:49',900.00,1,10,1900.00,0.00,1900.00,1900.00,'Extended 22 hour(s)\r\nTransfered from Room No.: 5',0),('0000000002',12,'0000000002',2,'2017-02-03 13:31:41',22,'2017-02-04 11:31:41',0.00,1,10,1000.00,0.00,1000.00,0.00,'Transfered from Room No. : 6',1);

/*Table structure for table `roomtype` */

DROP TABLE IF EXISTS `roomtype`;

CREATE TABLE `roomtype` (
  `RoomTypeId` int(2) NOT NULL auto_increment,
  `Name` varchar(25) default NULL,
  `MaxCap` int(2) default NULL,
  `Rate_1` double(10,2) default NULL,
  `Rate_2` double(10,2) default NULL,
  `Rate_3` double(10,2) default NULL,
  `ExtensionRate` double(10,2) default NULL,
  PRIMARY KEY  (`RoomTypeId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COMMENT='		';

/*Data for the table `roomtype` */

insert  into `roomtype`(`RoomTypeId`,`Name`,`MaxCap`,`Rate_1`,`Rate_2`,`Rate_3`,`ExtensionRate`) values (1,'Studio Type',2,495.00,700.00,1000.00,200.00),(2,'One Bed Rooms',4,595.00,820.00,1240.00,200.00);

/*Table structure for table `staff` */

DROP TABLE IF EXISTS `staff`;

CREATE TABLE `staff` (
  `StaffID` varchar(5) NOT NULL,
  `Name` varchar(45) default NULL,
  PRIMARY KEY  (`StaffID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `staff` */

insert  into `staff`(`StaffID`,`Name`) values ('10000','Plaza Erwin'),('10001','Bryan Lim');

/*Table structure for table `supplier` */

DROP TABLE IF EXISTS `supplier`;

CREATE TABLE `supplier` (
  `SupplierID` varchar(2) NOT NULL,
  `SupplierName` varchar(25) default NULL,
  `SupplierAddress` varchar(50) default NULL,
  `SupplierContactNo` varchar(11) default NULL,
  PRIMARY KEY  (`SupplierID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `supplier` */

insert  into `supplier`(`SupplierID`,`SupplierName`,`SupplierAddress`,`SupplierContactNo`) values ('01','SUNNY DAY','QC','09465612312'),('02','PUREGOLD','PUREGOLD QC','0914214214');

/*Table structure for table `unit` */

DROP TABLE IF EXISTS `unit`;

CREATE TABLE `unit` (
  `UnitID` int(3) NOT NULL auto_increment,
  `UnitName` varchar(25) default NULL,
  PRIMARY KEY  (`UnitID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `unit` */

insert  into `unit`(`UnitID`,`UnitName`) values (1,'/ order'),(2,'/ pc(s)'),(3,'/ pack'),(4,'/ bucket');

/*Table structure for table `user` */

DROP TABLE IF EXISTS `user`;

CREATE TABLE `user` (
  `UserID` varchar(4) NOT NULL,
  `UserTypeID` varchar(2) default NULL,
  `Username` varchar(25) default NULL,
  `Password` varchar(25) default NULL,
  `FirstName` varchar(25) default NULL,
  `LastName` varchar(25) default NULL,
  PRIMARY KEY  (`UserID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `user` */

insert  into `user`(`UserID`,`UserTypeID`,`Username`,`Password`,`FirstName`,`LastName`) values ('0101','01','admin123','admin123','BRYAN','LIM'),('0201','02','manager123','manager123','JOHN','SMITHs'),('0301','03','frontdesk123','frontdesk123','NINA','WILLIAMSS');

/*Table structure for table `usertype` */

DROP TABLE IF EXISTS `usertype`;

CREATE TABLE `usertype` (
  `UserTypeID` varchar(2) NOT NULL,
  `Description` varchar(25) default NULL,
  `Sales` int(1) default NULL,
  `Reservation` int(1) default NULL,
  `Inventory` int(1) default NULL,
  `Reports` int(1) default NULL,
  `RoomMaintenance` int(1) default NULL,
  `ProductMaintenance` int(1) default NULL,
  `UserMaintenance` int(1) default NULL,
  `GuestMaintenance` int(1) default NULL,
  PRIMARY KEY  (`UserTypeID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `usertype` */

insert  into `usertype`(`UserTypeID`,`Description`,`Sales`,`Reservation`,`Inventory`,`Reports`,`RoomMaintenance`,`ProductMaintenance`,`UserMaintenance`,`GuestMaintenance`) values ('01','Administrator',1,1,1,1,1,1,1,1),('02','Manager',1,1,1,1,1,1,0,1),('03','Front Desk',1,1,0,0,0,0,0,0);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
