-- MySQL dump 10.13  Distrib 5.5.28, for debian-linux-gnu (i686)
--
-- Host: localhost    Database: SchoolAlert
-- ------------------------------------------------------
-- Server version	5.5.28-0ubuntu0.12.04.2

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
-- Table structure for table `AlumnoGrupo`
--

DROP TABLE IF EXISTS `AlumnoGrupo`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `AlumnoGrupo` (
  `idAlumno` int(11) NOT NULL,
  `idGrupo` varchar(12) NOT NULL,
  PRIMARY KEY (`idAlumno`,`idGrupo`),
  KEY `idGrupo` (`idGrupo`),
  CONSTRAINT `AlumnoGrupo_ibfk_1` FOREIGN KEY (`idAlumno`) REFERENCES `Alumnos` (`idAlumno`),
  CONSTRAINT `AlumnoGrupo_ibfk_2` FOREIGN KEY (`idGrupo`) REFERENCES `Grupos` (`idGrupo`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AlumnoGrupo`
--

LOCK TABLES `AlumnoGrupo` WRITE;
/*!40000 ALTER TABLE `AlumnoGrupo` DISABLE KEYS */;
/*!40000 ALTER TABLE `AlumnoGrupo` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Alumnos`
--

DROP TABLE IF EXISTS `Alumnos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Alumnos` (
  `idAlumno` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `apellidoPaterno` varchar(50) DEFAULT NULL,
  `apellidoMaterno` varchar(50) DEFAULT NULL,
  `direccionCalle` varchar(60) DEFAULT NULL,
  `direccionColonia` varchar(60) DEFAULT NULL,
  `municipio` varchar(25) DEFAULT NULL,
  `estado` varchar(15) DEFAULT NULL,
  `telefono` int(11) DEFAULT NULL,
  `correo` varchar(40) DEFAULT NULL,
  `codigoPostal` int(11) DEFAULT NULL,
  `semestre` int(11) NOT NULL,
  `fechaAlta` date NOT NULL,
  PRIMARY KEY (`idAlumno`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Alumnos`
--

LOCK TABLES `Alumnos` WRITE;
/*!40000 ALTER TABLE `Alumnos` DISABLE KEYS */;
INSERT INTO `Alumnos` VALUES (13,'Hernán ','Gallardo','López','Andalucía 23389','Villa Fontana','Tijuana','Baja California',3007791,'gallardolopezhernan@gmail.com',22205,0,'2012-12-01'),(14,'','','','','','','',0,'',0,1,'2012-12-01');
/*!40000 ALTER TABLE `Alumnos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Avisos`
--

DROP TABLE IF EXISTS `Avisos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Avisos` (
  `idGrupo` varchar(11) NOT NULL,
  `aviso` varchar(200) NOT NULL,
  `fechaExpiracion` datetime NOT NULL,
  `titulo` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Avisos`
--

LOCK TABLES `Avisos` WRITE;
/*!40000 ALTER TABLE `Avisos` DISABLE KEYS */;
INSERT INTO `Avisos` VALUES ('7W7','Se acabó el papel','2012-12-01 00:00:00','URGENTE!'),('7W7','lololololol','2012-12-08 14:30:00','Prueba1'),('7w7','jbuhyvkgv kh','2012-12-25 15:35:00','bla!');
/*!40000 ALTER TABLE `Avisos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Calificaciones`
--

DROP TABLE IF EXISTS `Calificaciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Calificaciones` (
  `idGrupo` varchar(12) NOT NULL,
  `idAlumno` int(11) NOT NULL,
  `tipo` varchar(15) NOT NULL,
  `unidad` int(11) NOT NULL,
  KEY `idGrupo` (`idGrupo`),
  KEY `idAlumno` (`idAlumno`),
  CONSTRAINT `Calificaciones_ibfk_1` FOREIGN KEY (`idGrupo`) REFERENCES `Grupos` (`idGrupo`),
  CONSTRAINT `Calificaciones_ibfk_2` FOREIGN KEY (`idAlumno`) REFERENCES `Alumnos` (`idAlumno`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Calificaciones`
--

LOCK TABLES `Calificaciones` WRITE;
/*!40000 ALTER TABLE `Calificaciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `Calificaciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Depto`
--

DROP TABLE IF EXISTS `Depto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Depto` (
  `idDepto` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `telefono` int(11) NOT NULL,
  `correo` varchar(40) NOT NULL,
  `idEncargado` int(11) NOT NULL,
  PRIMARY KEY (`idDepto`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Depto`
--

LOCK TABLES `Depto` WRITE;
/*!40000 ALTER TABLE `Depto` DISABLE KEYS */;
INSERT INTO `Depto` VALUES (1,'Sistemas y Computación',3008574,'sistemas@itt.com.mx',0),(2,'Ciencias de la Tierra',3657894,'cdlt@itt.com.mx',0);
/*!40000 ALTER TABLE `Depto` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Docentes`
--

DROP TABLE IF EXISTS `Docentes`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Docentes` (
  `idDocente` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `apellidoPaterno` varchar(50) DEFAULT NULL,
  `apellidoMaterno` varchar(50) DEFAULT NULL,
  `direccionCalle` varchar(60) DEFAULT NULL,
  `direccionColonia` varchar(60) DEFAULT NULL,
  `municipio` varchar(25) DEFAULT NULL,
  `estado` varchar(15) DEFAULT NULL,
  `telefono` int(11) DEFAULT NULL,
  `correo` varchar(40) DEFAULT NULL,
  `codigoPostal` int(11) DEFAULT NULL,
  `titulo` varchar(50) DEFAULT NULL,
  `grado` varchar(15) DEFAULT NULL,
  `fechaAlta` date NOT NULL,
  PRIMARY KEY (`idDocente`)
) ENGINE=InnoDB AUTO_INCREMENT=555053 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Docentes`
--

LOCK TABLES `Docentes` WRITE;
/*!40000 ALTER TABLE `Docentes` DISABLE KEYS */;
INSERT INTO `Docentes` VALUES (555052,'Juan','Montiel','Garza','Calle Florido No. 233','Col. Falderas del Cerro','Tijuana','Baja California',8457981,'montiel.juan@gmail.com',22548,'Maestro en Sistemas Digitales','Maestría','2012-12-01');
/*!40000 ALTER TABLE `Docentes` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Grupos`
--

DROP TABLE IF EXISTS `Grupos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Grupos` (
  `idGrupo` varchar(12) NOT NULL,
  `grupo` char(3) DEFAULT NULL,
  `aula` varchar(10) DEFAULT NULL,
  `idDocente` int(11) NOT NULL,
  `idMateria` int(11) NOT NULL,
  `cupoDisponible` int(11) NOT NULL,
  `horaInicio` time DEFAULT NULL,
  `horaTermino` time DEFAULT NULL,
  PRIMARY KEY (`idGrupo`),
  KEY `idDocente` (`idDocente`),
  KEY `idMateria` (`idMateria`),
  CONSTRAINT `Grupos_ibfk_1` FOREIGN KEY (`idDocente`) REFERENCES `Docentes` (`idDocente`),
  CONSTRAINT `Grupos_ibfk_2` FOREIGN KEY (`idMateria`) REFERENCES `Materias` (`idMateria`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Grupos`
--

LOCK TABLES `Grupos` WRITE;
/*!40000 ALTER TABLE `Grupos` DISABLE KEYS */;
INSERT INTO `Grupos` VALUES ('7W7','A','309',555052,1,30,'13:00:00','14:00:00');
/*!40000 ALTER TABLE `Grupos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Materias`
--

DROP TABLE IF EXISTS `Materias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Materias` (
  `idMateria` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) NOT NULL,
  `creditos` int(11) NOT NULL,
  `area` varchar(50) DEFAULT NULL,
  `seriada` int(11) NOT NULL,
  PRIMARY KEY (`idMateria`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Materias`
--

LOCK TABLES `Materias` WRITE;
/*!40000 ALTER TABLE `Materias` DISABLE KEYS */;
INSERT INTO `Materias` VALUES (1,'Matemáticas I',8,'Ciencias Básicas',0);
/*!40000 ALTER TABLE `Materias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Personal`
--

DROP TABLE IF EXISTS `Personal`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Personal` (
  `idEmpleado` int(11) NOT NULL AUTO_INCREMENT,
  `nombre` varchar(50) DEFAULT NULL,
  `apellidoPaterno` varchar(50) DEFAULT NULL,
  `apellidoMaterno` varchar(50) DEFAULT NULL,
  `direccionCalle` varchar(60) DEFAULT NULL,
  `direccionColonia` varchar(60) DEFAULT NULL,
  `municipio` varchar(25) DEFAULT NULL,
  `estado` varchar(15) DEFAULT NULL,
  `telefono` int(11) DEFAULT NULL,
  `correo` varchar(40) DEFAULT NULL,
  `codigoPostal` int(11) DEFAULT NULL,
  `puesto` varchar(25) DEFAULT NULL,
  `fechaAlta` date NOT NULL,
  PRIMARY KEY (`idEmpleado`)
) ENGINE=InnoDB AUTO_INCREMENT=8880053 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Personal`
--

LOCK TABLES `Personal` WRITE;
/*!40000 ALTER TABLE `Personal` DISABLE KEYS */;
INSERT INTO `Personal` VALUES (8880050,'Juan','Torres','Mendoza','','','Tijuana','Baja California',3007798,'jtm0912@yahoo.com',22209,'Recursos Humanos','2012-12-01'),(8880051,'Luis','Tapia','Robles','','','Tijuana','Baja California',3007795,'ltr0912@yahoo.com',22209,'Recursos Humanos','2012-12-01'),(8880052,'María','Rodríguez','Torres','dsvfdbdfb','jhvbkjhv','Tijuana','Baja California',6668541,'chona@yahoo.com',22568,'Secretaria','2012-12-01');
/*!40000 ALTER TABLE `Personal` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Reinscripciones`
--

DROP TABLE IF EXISTS `Reinscripciones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Reinscripciones` (
  `idAlumno` int(11) NOT NULL,
  `fecha` date NOT NULL,
  `lugar` varchar(50) DEFAULT NULL,
  KEY `idAlumno` (`idAlumno`),
  CONSTRAINT `Reinscripciones_ibfk_1` FOREIGN KEY (`idAlumno`) REFERENCES `Alumnos` (`idAlumno`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Reinscripciones`
--

LOCK TABLES `Reinscripciones` WRITE;
/*!40000 ALTER TABLE `Reinscripciones` DISABLE KEYS */;
/*!40000 ALTER TABLE `Reinscripciones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Usuarios`
--

DROP TABLE IF EXISTS `Usuarios`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `Usuarios` (
  `idUsuario` int(11) NOT NULL,
  `password` varchar(8) DEFAULT NULL,
  `nivel` int(11) NOT NULL,
  PRIMARY KEY (`idUsuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Usuarios`
--

LOCK TABLES `Usuarios` WRITE;
/*!40000 ALTER TABLE `Usuarios` DISABLE KEYS */;
INSERT INTO `Usuarios` VALUES (13,'12345',0),(14,'Us_fQvWH',0),(555050,'tomatito',0),(555051,'ofEZvUPj',0),(555052,'@y,qa,NW',1),(8880052,'QW3`Vo@g',3);
/*!40000 ALTER TABLE `Usuarios` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2012-12-02  0:11:32
