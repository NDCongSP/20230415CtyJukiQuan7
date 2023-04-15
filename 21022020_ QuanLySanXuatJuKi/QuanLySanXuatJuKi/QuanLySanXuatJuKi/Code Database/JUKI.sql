CREATE DATABASE  IF NOT EXISTS `juki_giamsatthoigiankho` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `juki_giamsatthoigiankho`;
-- MySQL dump 10.13  Distrib 5.6.13, for Win32 (x86)
--
-- Host: localhost    Database: juki_giamsatthoigiankho
-- ------------------------------------------------------
-- Server version	5.6.16

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
-- Table structure for table `account`
--

DROP TABLE IF EXISTS `account`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `account` (
  `UserName` varchar(100) NOT NULL,
  `DisplayName` varchar(100) NOT NULL,
  `PassWord` varchar(1000) NOT NULL,
  `Type` int(11) NOT NULL,
  PRIMARY KEY (`UserName`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `account`
--

LOCK TABLES `account` WRITE;
/*!40000 ALTER TABLE `account` DISABLE KEYS */;
INSERT INTO `account` VALUES ('Admin','admin','1962026656160185351301320480154111117132155',1),('Staff','Staff','1962026656160185351301320480154111117132155',0);
/*!40000 ALTER TABLE `account` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `bangnhapsolop`
--

DROP TABLE IF EXISTS `bangnhapsolop`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `bangnhapsolop` (
  `MaBarCodeSanPham` varchar(100) NOT NULL,
  `TenSanPhamTiengViet` varchar(100) DEFAULT NULL,
  `TenSanPhamTiengAnh` varchar(100) DEFAULT NULL,
  `LopNhung` varchar(100) DEFAULT NULL,
  `TongLopNhung` int(11) DEFAULT NULL,
  `Zircon01` int(11) DEFAULT NULL,
  `Zircon02` int(11) DEFAULT NULL,
  `Zircon03` int(11) DEFAULT NULL,
  `Zircon04` int(11) DEFAULT NULL,
  `CatL01` int(11) DEFAULT NULL,
  `CatL02` int(11) DEFAULT NULL,
  `CatL03` int(11) DEFAULT NULL,
  `CatL04` int(11) DEFAULT NULL,
  `CatL05` int(11) DEFAULT NULL,
  `CatL06` int(11) DEFAULT NULL,
  `CatL07` int(11) DEFAULT NULL,
  `CatL08` int(11) DEFAULT NULL,
  `CatL09` int(11) DEFAULT NULL,
  `SIRU` int(11) DEFAULT NULL,
  PRIMARY KEY (`MaBarCodeSanPham`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;


--
-- Table structure for table `dulieuvabaocao`
--

DROP TABLE IF EXISTS `dulieuvabaocao`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `dulieuvabaocao` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `TenSanPhamTiengViet` varchar(100) DEFAULT NULL,
  `TenSanPhamTiengAnh` varchar(100) DEFAULT NULL,
  `MaBarCodeSanPham` varchar(100) DEFAULT NULL,
  `SoLopHienTai` int(11) DEFAULT NULL,
  `SoThoiGianKho` int(11) DEFAULT NULL,
  `SoLopKetThuc` int(11) DEFAULT NULL,
  `MaBarCodeLot` varchar(100) DEFAULT NULL,
  `ThoiGianBatDauNhung` datetime DEFAULT NULL,
  `ThoiGianBatDauPhoi` datetime DEFAULT NULL,
  `ThoiGianKetThucKho` datetime DEFAULT NULL,
  `ThoiGianKetThucQuaTrinh` datetime DEFAULT NULL,
  `MaBarCodeXe` varchar(100) DEFAULT NULL,
  `MaBarCodeCot` varchar(100) DEFAULT NULL,
  `MaBarCodeNguoi` varchar(100) DEFAULT NULL,
  `TenCatNhungHienTai` varchar(100) DEFAULT NULL,
  `TenCatNhungTiepTheo` varchar(100) DEFAULT NULL,
  `TrangThaiDen` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=266 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Table structure for table `locationset`
--

DROP TABLE IF EXISTS `locationset`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `locationset` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(100) NOT NULL,
  `status` varchar(100) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=11 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `locationset`
--

LOCK TABLES `locationset` WRITE;
/*!40000 ALTER TABLE `locationset` DISABLE KEYS */;
INSERT INTO `locationset` VALUES (1,'COT_001','Trống'),(2,'COT_002','Trống'),(3,'COT_003','Trống'),(4,'COT_004','Trống'),(5,'COT_005','Trống'),(6,'COT_006','Trống'),(7,'COT_007','Trống'),(8,'COT_008','Trống'),(9,'COT_009','Trống'),(10,'COT_010','Trống');
/*!40000 ALTER TABLE `locationset` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `mabarcode`
--

DROP TABLE IF EXISTS `mabarcode`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `mabarcode` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `MaBarCodeSanPham` varchar(100) DEFAULT NULL,
  `MaBarCodeLot` varchar(100) DEFAULT NULL,
  `MaBarCodeCot` varchar(100) DEFAULT NULL,
  `MaBarCodeXe` varchar(100) DEFAULT NULL,
  `MaBarCodeNguoi` varchar(100) DEFAULT NULL,
  `TrangThai` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=78 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

DELIMITER $$
USE `juki_giamsatthoigiankho`$$
CREATE DEFINER=`root`@`localhost` PROCEDURE `USP_UpdateAccount`(
p_userName NVARCHAR(100), p_displayName NVARCHAR(100), p_password NVARCHAR(100), p_newPassword NVARCHAR(100))
BEGIN
	DECLARE v_isRightPass INT DEFAULT 0;
	
	SELECT COUNT(*) INTO v_isRightPass FROM Account WHERE USERName = p_userName AND PassWord = p_password;
	
	IF (v_isRightPass = 1)
	THEN
		IF (p_newPassword = NULL OR p_newPassword = '')
		THEN
			UPDATE Account SET DisplayName = p_displayName WHERE UserName = p_userName;
		ELSE
			UPDATE Account SET DisplayName = p_displayName, PassWord = p_newPassword WHERE UserName = p_userName;
		END IF;
	end if;
END$$

DELIMITER ;

/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;
/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-07-08 15:06:10
