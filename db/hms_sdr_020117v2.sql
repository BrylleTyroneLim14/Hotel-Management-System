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
) ENGINE=InnoDB AUTO_INCREMENT=340 DEFAULT CHARSET=utf8;

/*Data for the table `audit_trail` */

insert  into `audit_trail`(`TrailNo`,`UserID`,`Activity`,`DateTime`) values (2,'0101','Login on Login Module','2017-01-22 00:00:00'),(3,'0101','Login on Login Module','2017-01-22 16:01:31'),(4,'0101','Logged In','2017-01-25 23:53:46'),(5,'0101','Logged In','2017-01-26 00:14:48'),(6,'0101','Added new UnitName','2017-01-26 00:15:16'),(7,'','Added new UnitName','2017-01-26 00:18:27'),(8,'','Updated Unit Name - Unit ID: 1','2017-01-26 00:18:34'),(9,'','Delete Unit Name - Unit ID: 4','2017-01-26 00:18:39'),(10,'','Delete Unit Name - Unit ID: 3','2017-01-26 00:18:43'),(11,'','Updated Unit Name - Unit ID: 1','2017-01-26 00:18:48'),(12,'0101','Logged In','2017-01-26 00:22:21'),(13,'0101','Logged In','2017-01-26 00:22:54'),(14,'0101','Logged In','2017-01-26 00:23:30'),(15,'','Added new UnitName','2017-01-26 00:30:16'),(16,'','Updated Unit Name - Unit ID: 5','2017-01-26 00:30:22'),(17,'','Delete Unit Name - Unit ID: 5','2017-01-26 00:30:26'),(18,'','Added new UnitName','2017-01-26 00:38:42'),(19,'','Updated Unit Name - Unit ID: 6','2017-01-26 00:38:59'),(20,'','Delete Unit Name - Unit ID: 6','2017-01-26 00:39:13'),(21,'','Added new UnitName','2017-01-26 00:39:32'),(22,'','Delete Unit Name - Unit ID: 7','2017-01-26 00:43:14'),(23,'','Added new UnitName','2017-01-26 00:43:34'),(24,'','Added new Staff Name','2017-01-26 01:01:14'),(25,'','Added new Staff Name','2017-01-26 01:02:03'),(26,'','Updated Staff Name - Staff ID: 10001','2017-01-26 01:17:18'),(27,'','Updated Staff Name - Staff ID: 10001','2017-01-26 01:17:27'),(28,'','Updated Staff Name - Staff ID: 10000','2017-01-26 01:25:22'),(29,'','Updated Staff Name - Staff ID: 10000','2017-01-26 01:26:04'),(30,'','Delete Staff Name - Staff ID: 10001','2017-01-26 01:26:14'),(31,'','Delete Staff Name - Staff ID: 10000','2017-01-26 01:26:21'),(32,'','Added new Staff Name','2017-01-26 01:26:25'),(33,'','Updated Staff Name - Staff ID: 10000','2017-01-26 01:26:33'),(34,'','Delete Staff Name - Staff ID: 10000','2017-01-26 01:26:40'),(35,'','Added new Staff Name','2017-01-26 01:26:52'),(36,'','Added new Staff Name','2017-01-26 01:27:00'),(37,'','Delete Supplier Name - Supplier ID: 1','2017-01-26 01:56:08'),(38,'','Added new Supplier Name','2017-01-26 01:57:19'),(39,'','Delete Supplier Name - Supplier ID: 0','2017-01-26 01:58:35'),(40,'','Added new Supplier Name','2017-01-26 01:59:18'),(41,'','Delete Supplier Name - Supplier ID: 0','2017-01-26 01:59:25'),(42,'','Added new Supplier Name','2017-01-26 01:59:30'),(43,'','Added new Supplier Name','2017-01-26 01:59:39'),(44,'','Added new Supplier Name','2017-01-26 01:59:57'),(45,'','Updated Supplier Name - Supplier ID: 1','2017-01-26 02:00:08'),(46,'','Delete Supplier Name - Supplier ID: 2','2017-01-26 02:00:20'),(47,'','Delete Supplier Name - Supplier ID: 0','2017-01-26 02:00:41'),(48,'','Delete Supplier Name - Supplier ID: 1','2017-01-26 02:00:44'),(49,'','Added new Supplier Name','2017-01-26 02:02:08'),(50,'','Added new Supplier Name','2017-01-26 02:02:40'),(51,'','Added new Supplier Name','2017-01-26 02:02:48'),(52,'','Added new Supplier Name','2017-01-26 02:03:49'),(53,'','Added new Supplier Name','2017-01-26 02:03:53'),(54,'','Added new Supplier Name','2017-01-26 02:03:57'),(55,'','Added new Supplier Name','2017-01-26 02:04:01'),(56,'','Delete Supplier Name - Supplier ID: 10','2017-01-26 02:04:08'),(57,'','Delete Supplier Name - Supplier ID: 11','2017-01-26 02:04:14'),(58,'','Delete Supplier Name - Supplier ID: 12','2017-01-26 02:04:17'),(59,'','Updated Supplier Name - Supplier ID: 13','2017-01-26 02:04:21'),(60,'','Updated Supplier Name - Supplier ID: 13','2017-01-26 02:04:28'),(61,'','Delete Supplier Name - Supplier ID: 13','2017-01-26 02:04:35'),(62,'','Added new Supplier Name','2017-01-26 02:06:15'),(63,'','Added new Supplier Name','2017-01-26 02:07:51'),(64,'','Delete Supplier Name - Supplier ID: 11','2017-01-26 02:08:11'),(65,'','Delete Supplier Name - Supplier ID: 10','2017-01-26 02:08:15'),(66,'','Added new Supplier Name','2017-01-26 02:08:29'),(67,'','Delete Unit Name - Unit ID: 8','2017-01-26 02:09:17'),(68,'','Updated Room Name - Room No: 1','2017-01-26 03:35:10'),(69,'','Added new Room Name','2017-01-26 03:48:30'),(70,'','Updated Room Name - Room No: 15','2017-01-26 03:49:03'),(71,'','Delete room name - Room ID: 15','2017-01-26 03:50:00'),(72,'','Added new User ','2017-01-26 04:37:17'),(73,'','Added new User ','2017-01-26 04:59:23'),(74,'','Updated Category Name - Category ID: 102','2017-01-26 05:42:32'),(75,'','Added new Category Name','2017-01-26 05:44:42'),(76,'','Updated Category Name - Category ID: 101','2017-01-26 05:45:49'),(77,'','Updated Category Name - Category ID: 101','2017-01-26 05:46:00'),(78,'','Delete Category Name - Supplier ID: 106','2017-01-26 05:46:06'),(79,'','Added new Category Name','2017-01-26 05:46:19'),(80,'','Added new Category Name','2017-01-26 05:46:27'),(81,'','Delete Category Name - Supplier ID: 106','2017-01-26 05:46:32'),(82,'','Delete Category Name - Supplier ID: 211','2017-01-26 05:46:47'),(83,'','Added new Category Name','2017-01-26 05:49:29'),(84,'','Added new Category Name','2017-01-26 05:50:05'),(85,'','Updated User Name - User ID: 0201','2017-01-26 13:03:11'),(86,'','Added new User ','2017-01-26 13:05:59'),(87,'','Delete User Name - User ID: 0103','2017-01-26 13:06:43'),(88,'','Delete User Name - User ID: 0103','2017-01-26 13:06:56'),(89,'','Delete User Name - User ID: 0103','2017-01-26 13:08:14'),(90,'','Delete User Name - User ID: 0103','2017-01-26 13:08:19'),(91,'','Delete User Name - User ID: 0103','2017-01-26 13:08:25'),(92,'','Updated User Name - User ID: 0202','2017-01-26 13:08:34'),(93,'','Updated User Name - User ID: 0103','2017-01-26 13:08:41'),(94,'','Updated User Name - User ID: 0102','2017-01-26 13:12:59'),(95,'','Updated User Name - User ID: 0102','2017-01-26 13:13:10'),(96,'','Updated User Name - User ID: 0102','2017-01-26 13:13:17'),(97,'','Updated User Name - User ID: 0101','2017-01-26 13:13:25'),(98,'','Delete User Name - User ID: 0102','2017-01-26 13:29:37'),(99,'','Updated User Name - User ID: 0201','2017-01-26 13:29:45'),(100,'','Added new User ','2017-01-26 13:29:59'),(101,'','Added new User ','2017-01-26 13:40:34'),(102,'','Added new User ','2017-01-26 13:44:32'),(103,'','Updated User Name - User ID: 0104','2017-01-26 13:44:59'),(104,'','Updated User Name - User ID: 0102','2017-01-26 13:47:33'),(105,'','Added new User ','2017-01-26 13:47:59'),(106,'','Delete User Name - User ID: 0104','2017-01-26 13:48:12'),(107,'','Delete User Name - User ID: 0103','2017-01-26 13:48:21'),(108,'','Updated User Name - User ID: 0102','2017-01-26 13:50:25'),(109,'','Delete User Name - User ID: 0102','2017-01-26 13:50:47'),(110,'','Delete User Name - User ID: 0202','2017-01-26 13:50:54'),(111,'','Added new Guest Name','2017-01-26 14:38:02'),(112,'','Added new Guest Name','2017-01-26 14:44:38'),(113,'','Delete Guest Name - Guest ID: 1','2017-01-26 14:45:02'),(114,'','Added new Guest Name','2017-01-26 14:47:54'),(115,'','Updated Room Name - Room No: 1','2017-01-26 14:50:04'),(116,'','Delete Guest Name - Guest ID: 2','2017-01-26 14:51:16'),(117,'','Added new Guest Name','2017-01-26 14:56:17'),(118,'','Added new Guest Name','2017-01-26 15:00:21'),(119,'','Delete Guest Name - Guest ID: 3','2017-01-26 15:00:24'),(120,'','Delete Guest Name - Guest ID: 2','2017-01-26 15:02:10'),(121,'','Added new Guest Name','2017-01-26 15:02:36'),(122,'','Updated Guest Name - Supplier ID: 1','2017-01-26 15:02:44'),(123,'','Delete Guest Name - Guest ID: 2','2017-01-26 15:02:47'),(124,'','Delete Guest Name - Guest ID: 1','2017-01-26 15:04:48'),(125,'','Added new Guest Name','2017-01-26 15:04:55'),(126,'','Updated Unit Name - Unit ID: 2','2017-01-26 15:10:00'),(127,'','Added new UnitName','2017-01-26 15:10:08'),(128,'','Delete Unit Name - Unit ID: 3','2017-01-26 15:10:10'),(129,'','Updated Unit Name - Unit ID: 2','2017-01-26 15:10:15'),(130,'','Added new Guest Name','2017-01-26 15:24:57'),(131,'','Updated Guest Name - Supplier ID: 2','2017-01-26 15:25:39'),(132,'','Updated Guest Name - Supplier ID: 2','2017-01-26 15:25:45'),(133,'','Updated Guest Name - Supplier ID: 2','2017-01-26 15:25:50'),(134,'','Delete Guest Name - Guest ID: 2','2017-01-26 15:25:57'),(135,'','Added new Supplier Name','2017-01-26 15:28:18'),(136,'','Delete Supplier Name - Supplier ID: 11','2017-01-26 15:28:39'),(137,'','Updated Supplier Name - Supplier ID: 10','2017-01-26 15:28:55'),(138,'','Added new Supplier Name','2017-01-26 15:29:01'),(139,'','Delete Staff Name - Staff ID: 10001','2017-01-26 15:29:18'),(140,'','Added new Staff Name','2017-01-26 15:29:30'),(141,'','Added new Guest Name','2017-01-26 15:30:35'),(142,'','Updated Guest Name - Supplier ID: 1','2017-01-26 15:30:49'),(143,'','Updated Supplier Name - Supplier ID: 11','2017-01-26 15:32:10'),(144,'','Updated Supplier Name - Supplier ID: 10','2017-01-26 15:32:15'),(145,'','Delete Supplier Name - Supplier ID: 10','2017-01-26 15:32:21'),(146,'','Updated Supplier Name - Supplier ID: 11','2017-01-26 15:32:33'),(147,'','Updated Supplier Name - Supplier ID: 11','2017-01-26 15:32:42'),(148,'','Added new Supplier Name','2017-01-26 15:32:57'),(149,'','Updated Guest Name - Supplier ID: 1','2017-01-26 15:38:57'),(150,'','Updated Guest Name - Supplier ID: 2','2017-01-26 15:39:21'),(151,'','Updated Guest Name - Supplier ID: 1','2017-01-26 15:39:31'),(152,'','Updated Guest Name - Supplier ID: 1','2017-01-26 15:39:36'),(153,'','Added new Guest Name','2017-01-26 15:39:52'),(154,'','Delete Guest Name - Guest ID: 3','2017-01-26 15:39:55'),(155,'','Added new User ','2017-01-26 15:52:27'),(156,'','Updated User Name - User ID: 0102','2017-01-26 15:52:49'),(157,'','Updated Room Name - Room No: 2','2017-01-26 15:54:10'),(158,'','Delete User Name - User ID: 0102','2017-01-26 15:55:49'),(159,'','Updated Room Name - Room No: 1','2017-01-26 15:56:08'),(160,'','Updated Room Name - Room No: 2','2017-01-26 16:04:00'),(161,'','Added new Room Name','2017-01-26 16:30:51'),(162,'','Added new Room Name','2017-01-26 17:45:33'),(163,'','Added new Room Name','2017-01-26 17:45:46'),(164,'','Updated Product Name - Product ID: 0100000003','2017-01-26 17:46:14'),(165,'','Updated Product Name - Product ID: 0100000001','2017-01-26 17:46:30'),(166,'','Delete Product Name - Product ID: 0100000001','2017-01-26 17:46:38'),(167,'','Added new Room Name','2017-01-26 17:47:57'),(168,'','Updated Product Name - Product ID: 0200000001','2017-01-26 17:48:47'),(169,'','Updated Product Name - Product ID: 0200000001','2017-01-26 17:48:58'),(170,'','Delete Product Name - Product ID: 0200000001','2017-01-26 17:50:04'),(171,'','Updated Product Name - Product ID: 0100000002','2017-01-26 17:50:11'),(172,'','Added new Room Name','2017-01-26 17:50:25'),(173,'','Updated Product Name - Product ID: 0200000001','2017-01-26 17:50:34'),(174,'','Updated Product Name - Product ID: 0200000001','2017-01-26 17:50:39'),(175,'','Added new Room Name','2017-01-27 22:55:41'),(176,'','Added new Room Name','2017-01-27 22:56:59'),(177,'0101','Logged In','2017-01-28 04:00:28'),(178,'0101','Logged Out','2017-01-28 04:05:35'),(179,'0101','Logged In','2017-01-28 04:09:04'),(180,'0101','Logged In','2017-01-28 04:09:45'),(181,'0101','Logged In','2017-01-28 04:13:42'),(182,'0101','Logged Out','2017-01-28 04:14:11'),(183,'0101','Logged In','2017-01-30 15:15:04'),(184,'0101','Logged Out','2017-01-30 15:15:38'),(185,'0101','Logged In','2017-01-30 15:16:31'),(186,'0101','Logged In','2017-01-30 15:24:13'),(187,'0101','Logged In','2017-01-30 15:26:30'),(188,'0101','Logged In','2017-01-30 15:28:11'),(189,'0101','Logged In','2017-01-30 15:28:33'),(190,'0101','Logged In','2017-01-30 15:32:14'),(191,'0101','Logged In','2017-01-30 17:31:11'),(192,'0101','Logged In','2017-01-30 17:36:12'),(193,'0101','Logged In','2017-01-30 18:22:13'),(194,'0101','Logged In','2017-01-30 18:44:14'),(195,'0101','Logged In','2017-01-30 18:52:25'),(196,'0101','Logged In','2017-01-30 19:18:27'),(197,'0101','Logged Out','2017-01-30 19:19:29'),(198,'0101','Logged In','2017-01-30 19:49:37'),(199,'0101','Logged In','2017-01-30 19:51:36'),(200,'0101','Logged In','2017-01-30 19:52:20'),(201,'0101','Logged In','2017-01-30 19:53:36'),(202,'0101','Logged In','2017-01-30 19:57:11'),(203,'0101','Logged In','2017-01-30 19:58:13'),(204,'0101','Logged In','2017-01-30 19:59:29'),(205,'0101','Logged In','2017-01-30 20:00:22'),(206,'0101','Logged In','2017-01-30 20:07:33'),(207,'0101','Logged In','2017-01-30 20:13:56'),(208,'0101','Logged In','2017-01-30 20:15:39'),(209,'0101','Logged In','2017-01-30 20:16:17'),(210,'0101','Logged Out','2017-01-30 20:17:07'),(211,'0101','Logged In','2017-01-30 20:27:43'),(212,'0101','Logged Out','2017-01-30 20:27:51'),(213,'0101','Logged In','2017-01-30 20:30:10'),(214,'0101','Logged In','2017-01-30 20:37:21'),(215,'0101','Logged In','2017-01-30 20:38:01'),(216,'0101','Logged In','2017-01-30 20:40:00'),(217,'0101','Logged Out','2017-01-30 20:40:09'),(218,'0101','Logged In','2017-01-30 21:17:25'),(219,'0101','Updated room type - Room Type ID: 3','2017-01-30 21:18:00'),(220,'0101','Updated Room Name - Room No: 1','2017-01-30 21:22:36'),(221,'0101','Updated Room Name - Room No: 2','2017-01-30 21:24:00'),(222,'0101','Logged In','2017-01-30 21:30:05'),(223,'0101','Logged Out','2017-01-30 21:31:07'),(224,'0101','Logged In','2017-01-30 21:47:37'),(225,'0101','Logged In','2017-01-30 21:50:53'),(226,'0101','Logged In','2017-01-30 21:51:44'),(227,'0101','Logged In','2017-01-30 21:52:46'),(228,'0101','Logged In','2017-01-30 21:54:57'),(229,'0101','Logged In','2017-01-30 21:57:20'),(230,'0101','Logged In','2017-01-30 21:59:21'),(231,'0101','Logged Out','2017-01-30 21:59:41'),(232,'0101','Logged In','2017-01-30 22:00:12'),(233,'0101','Logged In','2017-01-30 22:01:29'),(234,'0101','Logged In','2017-01-30 22:15:13'),(235,'0101','Logged In','2017-01-30 22:16:14'),(236,'0101','Logged In','2017-01-30 22:17:10'),(237,'0101','Logged In','2017-01-30 22:18:07'),(238,'0101','Logged In','2017-01-30 22:19:29'),(239,'0101','Logged In','2017-01-30 22:21:48'),(240,'0101','Logged In','2017-01-30 22:27:38'),(241,'0101','Added new room type','2017-01-30 22:28:04'),(242,'0101','Logged In','2017-01-30 22:28:40'),(243,'0101','Logged In','2017-01-30 22:31:10'),(244,'0101','Added new room type','2017-01-30 22:31:30'),(245,'0101','Updated room type - Room Type ID: 5','2017-01-30 22:31:34'),(246,'0101','Logged In','2017-01-30 22:34:10'),(247,'0101','Added new room type','2017-01-30 22:34:43'),(248,'0101','Updated room type - Room Type ID: 6','2017-01-30 22:35:03'),(249,'0101','Updated room type - Room Type ID: 6','2017-01-30 22:35:06'),(250,'0101','Logged In','2017-01-30 22:38:03'),(251,'0101','Logged In','2017-01-30 22:45:01'),(252,'0101','Logged In','2017-01-30 22:46:41'),(253,'0101','Logged Out','2017-01-30 22:47:08'),(254,'0101','Logged In','2017-01-30 22:52:16'),(255,'0101','Logged In','2017-01-30 22:53:31'),(256,'0101','Added new Room Name','2017-01-30 22:54:03'),(257,'0101','Logged In','2017-01-30 22:54:52'),(258,'0101','Delete room name - Room ID: 15','2017-01-30 22:55:12'),(259,'0101','Added new Room Name','2017-01-30 22:55:27'),(260,'0101','Delete room name - Room ID: 15','2017-01-30 22:55:31'),(261,'0101','Logged In','2017-01-30 22:56:42'),(262,'0101','Added new Room Name','2017-01-30 22:57:10'),(263,'0101','Updated Room Name - Room No: 15','2017-01-30 22:57:22'),(264,'0101','Delete room name - Room ID: 15','2017-01-30 22:57:27'),(265,'0101','Logged In','2017-01-30 23:07:37'),(266,'0101','Logged In','2017-01-30 23:09:05'),(267,'0101','Logged In','2017-01-30 23:17:35'),(268,'0101','Logged In','2017-01-30 23:33:18'),(269,'0101','Logged In','2017-01-30 23:41:43'),(270,'0101','Logged In','2017-01-30 23:43:01'),(271,'0101','Logged In','2017-01-30 23:43:38'),(272,'0101','Logged In','2017-01-30 23:44:33'),(273,'0101','Logged Out','2017-01-31 00:01:00'),(274,'0101','Logged In','2017-01-31 00:01:52'),(275,'0101','Logged Out','2017-01-31 00:02:01'),(276,'0101','Logged In','2017-01-31 00:04:37'),(277,'0101','Logged In','2017-02-01 11:04:15'),(278,'0101','Logged In','2017-02-01 11:13:25'),(279,'0101','Logged In','2017-02-01 11:13:53'),(280,'0101','Logged In','2017-02-01 11:16:11'),(281,'0101','Logged In','2017-02-01 11:16:29'),(282,'0101','Logged In','2017-02-01 11:16:52'),(283,'0101','Logged In','2017-02-01 11:20:15'),(284,'0101','Logged In','2017-02-01 11:49:58'),(285,'0101','Logged In','2017-02-01 11:52:24'),(286,'0101','Logged In','2017-02-01 11:56:21'),(287,'0101','Logged In','2017-02-01 12:11:47'),(288,'0101','Logged In','2017-02-01 12:18:55'),(289,'0101','Logged In','2017-02-01 12:21:32'),(290,'0101','Logged In','2017-02-01 12:24:25'),(291,'0101','Logged In','2017-02-01 12:25:52'),(292,'0101','Logged Out','2017-02-01 12:26:14'),(293,'0101','Logged In','2017-02-01 12:26:54'),(294,'0101','Logged In','2017-02-01 12:29:14'),(295,'0101','Logged In','2017-02-01 12:31:12'),(296,'0101','Logged Out','2017-02-01 12:33:15'),(297,'0101','Logged In','2017-02-01 13:17:39'),(298,'0101','Logged In','2017-02-01 13:26:48'),(299,'0101','Logged Out','2017-02-01 13:27:09'),(300,'0101','Logged In','2017-02-01 13:41:24'),(301,'0101','Logged In','2017-02-01 13:52:23'),(302,'0101','Logged In','2017-02-01 13:53:00'),(303,'0101','Logged In','2017-02-01 13:54:04'),(304,'0101','Logged In','2017-02-01 13:55:03'),(305,'0101','Logged In','2017-02-01 13:56:13'),(306,'0101','Logged In','2017-02-01 13:58:42'),(307,'0101','Logged In','2017-02-01 14:01:19'),(308,'0101','Logged In','2017-02-01 14:01:38'),(309,'0101','Logged In','2017-02-01 14:03:40'),(310,'0101','Logged In','2017-02-01 14:06:02'),(311,'0101','Logged In','2017-02-01 14:09:32'),(312,'0101','Logged In','2017-02-01 14:10:35'),(313,'0101','Logged In','2017-02-01 14:11:00'),(314,'0101','Logged In','2017-02-01 14:22:04'),(315,'0101','Logged In','2017-02-01 14:22:30'),(316,'0101','Logged Out','2017-02-01 14:22:43'),(317,'0101','Logged In','2017-02-01 14:30:17'),(318,'0101','Logged In','2017-02-01 14:30:59'),(319,'0101','Logged In','2017-02-01 14:35:51'),(320,'0101','Logged In','2017-02-01 14:36:18'),(321,'0101','Logged In','2017-02-01 14:38:41'),(322,'0101','Logged In','2017-02-01 14:39:43'),(323,'0101','Logged In','2017-02-01 14:39:55'),(324,'0101','Logged In','2017-02-01 14:46:47'),(325,'0101','Logged In','2017-02-01 14:53:17'),(326,'0101','Logged In','2017-02-01 15:08:03'),(327,'0101','Logged Out','2017-02-01 15:08:12'),(328,'0101','Logged In','2017-02-01 15:45:33'),(329,'0101','Logged Out','2017-02-01 15:48:08'),(330,'0101','Logged In','2017-02-01 15:48:17'),(331,'0101','Logged In','2017-02-01 22:40:04'),(332,'0101','Logged In','2017-02-01 22:41:52'),(333,'0101','Logged Out','2017-02-01 22:43:01'),(334,'0101','Logged In','2017-02-01 22:48:05'),(335,'0101','Logged Out','2017-02-01 22:48:21'),(336,'0101','Logged In','2017-02-01 22:53:13'),(337,'0101','Logged Out','2017-02-01 22:56:46'),(338,'0101','Logged In','2017-02-01 23:16:10'),(339,'0101','Logged Out','2017-02-01 23:16:35');

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

insert  into `constorekitchensales`(`CSKS_Code`,`TransactionNo`,`DateOfSale`,`ProductCode`,`Quantity`,`TotalAmount`,`Remarks`) values ('CK00000001','0000000001','2017-02-01 22:50:00','0100000001',1,99.00,'UNPAID');

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

insert  into `guest`(`GuestID`,`FirstName`,`LastName`,`Address`,`Company`,`MobileNo`) values ('0000000001','Bryan','Lim','CC','STI','0956621412'),('0000000002','ERWIN','PLAZA','QC','SUNNY DAYS','124214'),('0000000003','ERWIN','PLAZA','FAIRVIEW QUEZON CITY','PHILIPPINE EXPLORER','09155510223'),('0000000004','ERWIN','PLAZA','FAIRVIEW QUEZON CITY','PHILIPPINE EXPLORER','09155510223'),('0000000005','ERWIN','PLAZA','FAIRVIEW QC','PHILEX','09155510223'),('0000000006','ERWIN','PLAZA','FAIRVIEW QUEZON CITY','PHILIPPINE EXPLORER','09155510223'),('0000000007','ERWIN','PLAZA','FAIRVIEW QUEZON CITY','PHILIPPINE EXPLORER','09155510223'),('0000000008','Erwin','Plaza','Fairview, Quezon City','Mosconi Tours Inc.','09155510223');

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

insert  into `product`(`ProductCode`,`SupplierID`,`CategoryID`,`UnitID`,`Name`,`SupplierPrice`,`SellingPrice`,`CriticalLevel`) values ('0100000001','01','101',1,'ADOBO',90.00,99.00,23),('0100000002','01','101',1,'BACON',70.00,80.00,20),('0100000003','01','101',1,'BEEF STEAK',90.00,99.00,20),('0100000004','01','101',1,'CHICKEN KATSU',90.00,99.00,20),('0100000005','01','101',1,'CORNED BEEF',70.00,80.00,10),('0100000006','01','101',1,'HAM',50.00,80.00,20),('0100000007','01','101',1,'HUNGARIAN SAUSAGE',60.00,85.00,20),('0100000008','01','101',1,'LUMPIANG SHANGHAI',70.00,80.00,20),('0100000009','01','101',1,'LUNCHEON MEAT',70.00,80.00,20),('0100000010','01','101',1,'PANCIT BIHON',70.00,100.00,20),('0100000011','01','101',1,'SINIGANG NA BABOY',70.00,99.00,20),('0100000012','01','101',1,'TAPA',70.00,99.00,20),('0100000013','01','101',1,'TOCINO',60.00,80.00,20),('0100000014','01','102',1,'ADOBO',130.00,130.00,20),('0100000015','01','102',1,'BACON',110.00,110.00,20),('0100000016','01','102',1,'BEEF STEAK',130.00,130.00,20),('0100000017','01','102',1,'CHICKEN KATSU',130.00,130.00,20),('0100000018','01','102',1,'CORNED BEEF',110.00,110.00,20),('0100000019','01','102',1,'DAING NA BANGUS',130.00,130.00,20),('0100000020','01','102',1,'HAM',110.00,110.00,20),('0100000021','01','102',1,'HUNGARIAN SAUSAGE',110.00,120.00,20),('0100000022','01','102',1,'LUMPIANG SHANGHAI',110.00,120.00,20),('0100000023','01','102',1,'LUNCHEON MEAT',100.00,110.00,20),('0100000024','01','102',1,'SINIGANG NA BABOY',120.00,130.00,20),('0100000025','01','102',1,'TAPA',120.00,130.00,20),('0100000026','01','102',1,'TOCINO',100.00,110.00,20),('0100000027','01','102',1,'FRIED RICE IN COMBO',5.00,10.00,20),('0100000028','01','103',1,'BACON SANDWICH',70.00,85.00,20),('0100000029','01','103',1,'BACON W/ CHEESE AND EGG S',70.00,95.00,20),('0100000030','01','103',1,'HAM & CHEESE SANDWICH',75.00,85.00,20),('0100000031','01','103',1,'HAM W/ CHEESE AND EGG SAN',85.00,95.00,20),('0100000032','01','103',1,'JOLLYDOG SANDWICH',60.00,75.00,20),('0100000033','01','103',1,'TUNA SANDWICH',60.00,75.00,20),('0100000034','01','103',1,'EGG SANDWICH',40.00,50.00,20),('0100000035','01','104',1,'PLAIN PANCAKE',70.00,75.00,20),('0100000036','01','104',1,'PANCAKE WITH COFFEE',70.00,95.00,20),('0100000037','01','105',2,'PAPER PLATE',5.00,10.00,20),('0100000038','01','105',2,'BOWL',3.00,5.00,20),('0100000039','01','105',4,'ICE BUCKET',10.00,20.00,20),('0100000040','01','105',2,'SPOON AND FORK',5.00,10.00,20),('0100000041','01','105',1,'FRIED RICE',20.00,30.00,20),('0100000042','01','105',1,'PLAIN RICE',20.00,25.00,20),('0100000043','01','105',1,'EGG',10.00,20.00,20),('0200000001','02','201',2,'BATCHOY',30.00,35.00,20),('0200000002','02','201',2,'BEEF',30.00,35.00,20),('0200000003','02','201',2,'BULALO',30.00,35.00,20),('0200000004','02','201',2,'CHICKEN',30.00,35.00,20),('0200000005','02','201',2,'SEAFOOD',30.00,35.00,20),('0200000006','02','201',2,'SPICY BEEF',30.00,35.00,20),('0200000007','02','201',2,'SPICY SEAFOOD',30.00,35.00,20),('0200000008','02','202',2,'POTATO CHIPS V-CUT BBQ',10.00,20.00,20),('0200000009','02','202',2,'PIATTOS CHEESE (85G)',10.00,20.00,20),('0200000010','02','202',2,'PIATTOS SOUR CREAM (85G)',10.00,20.00,20),('0200000011','02','202',2,'NAGARAYA ORIGINAL (YELLOW',15.00,25.00,20),('0200000012','02','202',2,'NAGARAYA GARLIC (HOT AND ',3.00,5.00,20),('0200000013','02','202',2,'NAGARAYA GARLIC (GREEN)',2.00,5.00,20),('0200000014','02','202',2,'CLOUD9 CLASSIC',10.00,15.00,20),('0200000015','02','202',2,'CLOUD 9 WHITE',10.00,15.00,20),('0200000016','02','202',2,'TEMPURA',20.00,30.00,20),('0200000017','02','202',2,'SKYFLAKES',5.00,10.00,20),('0200000018','02','202',2,'FITA',5.00,10.00,20),('0200000019','02','202',2,'OREO',10.00,15.00,20),('0200000020','02','202',2,'FUDGEE BAR',10.00,15.00,20),('0200000021','02','203',2,'MAX',1.00,2.00,20),('0200000022','02','203',2,'FRES CHERRY CANDY',1.00,2.00,20),('0200000023','02','204',2,'NESCAFE Creamy Latte',20.00,25.00,20),('0200000024','02','204',2,'NESCAFE Original',20.00,25.00,20),('0200000025','02','204',2,'NESCAFE Berry Mocha',20.00,25.00,20),('0200000026','02','204',2,'NESCAFE Creamy White',20.00,25.00,20),('0200000027','02','204',2,'MILO',20.00,25.00,20),('0200000028','02','204',2,'LIPTON TEA',20.00,25.00,20),('0200000029','02','205',2,'SAN MIG LIGHT',40.00,50.00,20),('0200000030','02','205',2,'SAN MIG APPLE',40.00,50.00,20),('0200000031','02','205',2,'SAN MIG LEMON',40.00,50.00,20),('0200000032','02','205',2,'EMPERADOR LIGHTS',140.00,155.00,20),('0200000033','02','205',2,'REDHORSE',40.00,50.00,20),('0200000034','02','206',2,'COKE REGULAR',40.00,50.00,20),('0200000035','02','206',2,'COKE ZERO',40.00,50.00,20),('0200000036','02','206',2,'MUG ROOT BEER',40.00,50.00,20),('0200000037','02','206',2,'MOUNTAIN DEW',40.00,50.00,20),('0200000038','02','206',2,'PEPSI BLUE',40.00,50.00,20),('0200000039','02','206',2,'ROYAL',40.00,50.00,20),('0200000040','02','206',2,'SPRITE',40.00,50.00,20),('0200000041','02','206',2,'C2 SOLO APPLE SOLO',20.00,25.00,20),('0200000042','02','206',2,'C2 SOLO LEMON SOLO',20.00,25.00,20),('0200000043','02','206',2,'C2 SOLO APPLE REGULAR',20.00,30.00,20),('0200000044','02','206',2,'C2 SOLO LEMON REGULAR',30.00,40.00,20),('0200000045','02','206',2,'DELMONTE PINEAPPLE JUICE',40.00,50.00,20),('0200000046','02','206',2,'MINUTE MAID FRESH JUICE',30.00,40.00,20),('0200000047','02','206',2,'VIVA WATER',10.00,20.00,20),('0200000048','02','206',2,'REFILL WATER',15.00,20.00,20),('0200000049','02','206',2,'GATORADE',30.00,40.00,20),('0200000050','02','207',2,'DOVE',7.00,10.00,20),('0200000051','02','207',2,'HEAD AND SHOULDERS',6.00,10.00,20),('0200000052','02','207',2,'SUNSILK',7.00,10.00,20),('0200000053','02','207',2,'CREAMSILK GOLD',8.00,12.00,20),('0200000054','02','207',2,'CREAMSILK PINK',8.00,12.00,20),('0200000055','02','208',2,'INTEGRITY BATH SOAP',6.00,10.00,20),('0200000056','02','208',2,'SAFE GUARD',15.00,25.00,20),('0200000057','02','209',3,'MARLBORO (green) PACK',90.00,100.00,20),('0200000058','02','209',3,'MARLBORO (green)1/2 pack',40.00,50.00,20),('0200000059','02','209',3,'MARLBORO (red) PACK',90.00,100.00,20),('0200000060','02','209',3,'MARLBORO (red) 1/2 pack',40.00,50.00,20),('0200000061','02','209',3,'MARLBORO (lights) PACK',90.00,100.00,20),('0200000062','02','209',3,'MARLBORO (lights) 1/2 pac',40.00,50.00,20),('0200000063','02','209',3,'MARLBORO (black) PACK',90.00,100.00,20),('0200000064','02','209',3,'MARLBORO (Black)1/2 pack',40.00,50.00,20),('0200000065','02','209',3,'MARLBORO (Blue) Pack',90.00,100.00,20),('0200000066','02','209',3,'PALL MALL',90.00,100.00,20),('0200000067','02','210',2,'LIGHTER',20.00,30.00,20),('0200000068','02','210',2,'TISSUE',10.00,15.00,20),('0200000069','02','210',2,'MODESS',10.00,12.00,20),('0200000070','02','210',2,'CHARMEE PANTYLINNER',7.00,10.00,20),('0200000071','02','210',2,'COLGATE (SACHET) GREEN',10.00,15.00,20),('0200000072','02','210',2,'FEMININE WASH',10.00,15.00,20),('0200000073','02','210',2,'LUBRICANT JELLY',40.00,50.00,20),('0200000074','02','210',2,'CONDOM',40.00,50.00,20);

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

insert  into `room`(`RoomNo`,`RoomTypeID`,`RoomName`,`Floor`,`PhoneNo`,`Status`,`Picture`) values (1,2,'MACAU','1st','101','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(2,2,'BAGUIO','1st','102','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(3,2,'DUBAI','2nd','132','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(4,2,'KUALA LUMPUR','2nd','131','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(5,1,'PUERTO GALERA','3rd','111','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(6,1,'EL NIDO','3rd','112','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(7,1,'LAOAG','4th','187','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(8,1,'ALBAY','4th','186','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/EXUS.jpg'),(9,2,'BANGKOK','2nd','104','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg'),(10,2,'HONG KONG','2nd','103','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg'),(11,2,'SINGAPORE','2nd','105','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg'),(12,1,'PALAWAN','3rd','108','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg'),(13,1,'BORACAY','3rd','110','OCCUPIED','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg'),(14,1,'CEBU','3rd','109','AVAILABLE','C:/Users/Erwin/Desktop/Project_SDR/HMS_SDR_Proto_v1/sample_room_pics/SUPR.jpg');

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
  `DicountedRate` int(3) DEFAULT NULL,
  `RoomCharges` double(10,2) NOT NULL,
  `OtherCharges` double(10,2) DEFAULT NULL,
  `TotalCharge` double(10,2) DEFAULT NULL,
  `Remarks` varchar(100) DEFAULT NULL,
  `IsCurrentlyCheckedIn` int(1) NOT NULL,
  PRIMARY KEY (`TransactionNo`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `roomsales` */

insert  into `roomsales`(`TransactionNo`,`RoomNo`,`GuestID`,`Pax`,`CheckInDateTime`,`Duration`,`ExpectedCheckOut`,`Deposit`,`IsDiscounted`,`DicountedRate`,`RoomCharges`,`OtherCharges`,`TotalCharge`,`Remarks`,`IsCurrentlyCheckedIn`) values ('0000000001',13,'0000000008',2,'2017-02-01 22:42:45',22,'2017-02-02 20:42:45',0.00,0,0,1000.00,0.00,1000.00,'',1);

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
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8 COMMENT='		';

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

insert  into `supplier`(`SupplierID`,`SupplierName`,`SupplierAddress`,`SupplierContactNo`) values ('01','SUNNY DAY','QC','09465612312'),('02','PUREGOLD','PUREGOLD QC','0914214214');

/*Table structure for table `unit` */

DROP TABLE IF EXISTS `unit`;

CREATE TABLE `unit` (
  `UnitID` int(3) NOT NULL AUTO_INCREMENT,
  `UnitName` varchar(25) DEFAULT NULL,
  PRIMARY KEY (`UnitID`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

/*Data for the table `unit` */

insert  into `unit`(`UnitID`,`UnitName`) values (1,'/ order'),(2,'/ pc(s)'),(3,'/ pack'),(4,'/ bucket');

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
