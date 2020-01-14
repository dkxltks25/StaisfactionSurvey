-- MySQL dump 10.13  Distrib 5.7.12, for Win32 (AMD64)
--
-- Host: 127.0.0.1    Database: survey
-- ------------------------------------------------------
-- Server version	8.0.18

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `sasu_suv`
--

DROP TABLE IF EXISTS `sasu_suv`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `sasu_suv` (
  `SUV_SUVID` int(11) NOT NULL AUTO_INCREMENT,
  `adm_id` varchar(20) DEFAULT NULL,
  `dept_name` varchar(20) DEFAULT NULL,
  `suv_name` varchar(50) DEFAULT NULL,
  `suv_descrip` varchar(50) DEFAULT NULL,
  `suv_stime` datetime DEFAULT NULL,
  `suv_ftime` datetime DEFAULT NULL,
  `datasys1` datetime DEFAULT NULL,
  `datasys2` varchar(1) DEFAULT NULL,
  `datasys3` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`SUV_SUVID`)
) ENGINE=InnoDB AUTO_INCREMENT=6 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `sasu_suv`
--

LOCK TABLES `sasu_suv` WRITE;
/*!40000 ALTER TABLE `sasu_suv` DISABLE KEYS */;
INSERT INTO `sasu_suv` VALUES (3,'dkxltks25',NULL,'2020학년도 신입생 만족도조사','신입생을 대상으로 실시하는 간단한 설문조사입니다.','2020-01-16 00:00:00','2020-01-25 00:00:00','2020-01-14 15:37:24','U','dkxltks25 박재홍');
/*!40000 ALTER TABLE `sasu_suv` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-01-14 16:45:53
