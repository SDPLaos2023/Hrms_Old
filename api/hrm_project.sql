/*
SQLyog Community v13.1.2 (64 bit)
MySQL - 10.3.16-MariaDB : Database - hrm_project
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`hrm_project` /*!40100 DEFAULT CHARACTER SET utf8 */;

USE `hrm_project`;

/*Table structure for table `auth_sessions` */

DROP TABLE IF EXISTS `auth_sessions`;

CREATE TABLE `auth_sessions` (
  `ID` varchar(500) NOT NULL,
  `OS` varchar(100) DEFAULT NULL,
  `created_at` date DEFAULT NULL,
  `user` varchar(100) DEFAULT NULL,
  `last_token` varchar(4000) DEFAULT NULL,
  `location` varchar(200) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `session_userFk` (`user`),
  CONSTRAINT `session_userFk` FOREIGN KEY (`user`) REFERENCES `auth_users` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `auth_sessions` */

/*Table structure for table `auth_user_roles` */

DROP TABLE IF EXISTS `auth_user_roles`;

CREATE TABLE `auth_user_roles` (
  `ID` int(11) NOT NULL,
  `user` varchar(100) DEFAULT NULL,
  `role` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `role_tbRolesFk` (`role`),
  KEY `role_user` (`user`),
  CONSTRAINT `role_tbRolesFk` FOREIGN KEY (`role`) REFERENCES `tbroles` (`ID`),
  CONSTRAINT `role_user` FOREIGN KEY (`user`) REFERENCES `auth_users` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `auth_user_roles` */

/*Table structure for table `auth_users` */

DROP TABLE IF EXISTS `auth_users`;

CREATE TABLE `auth_users` (
  `ID` varchar(100) NOT NULL,
  `username` varchar(250) DEFAULT NULL,
  `password` varchar(500) DEFAULT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `user_employeeFk` (`employee`),
  CONSTRAINT `user_employeeFk` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `auth_users` */

insert  into `auth_users`(`ID`,`username`,`password`,`employee`,`status`) values 
('U0001','admin','o98hokyPpI+reQU0V/pkfg==','admin','ACTIVE');

/*Table structure for table `numbercontrol` */

DROP TABLE IF EXISTS `numbercontrol`;

CREATE TABLE `numbercontrol` (
  `code` varchar(100) NOT NULL,
  `company` varchar(100) DEFAULT NULL,
  `number` int(11) DEFAULT NULL,
  PRIMARY KEY (`code`),
  KEY `number_companyFk` (`company`),
  CONSTRAINT `number_companyFk` FOREIGN KEY (`company`) REFERENCES `tbcompanies` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `numbercontrol` */

insert  into `numbercontrol`(`code`,`company`,`number`) values 
('COM','C00001',4),
('DEPT','C00001',16),
('DIVS','C00001',2),
('POSI','C00001',2),
('SECT','C00001',2);

/*Table structure for table `tballowances` */

DROP TABLE IF EXISTS `tballowances`;

CREATE TABLE `tballowances` (
  `ID` varchar(100) NOT NULL,
  `name` varchar(500) DEFAULT NULL,
  `nameEn` varchar(500) DEFAULT NULL,
  `code` varchar(10) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `group` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `group` (`group`),
  CONSTRAINT `tballowances_ibfk_1` FOREIGN KEY (`group`) REFERENCES `tballowances` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tballowances` */

/*Table structure for table `tbcompanies` */

DROP TABLE IF EXISTS `tbcompanies`;

CREATE TABLE `tbcompanies` (
  `ID` varchar(100) NOT NULL,
  `name` varchar(500) DEFAULT NULL COMMENT 'ຊື່ບໍລິສັດ',
  `nameEn` varchar(500) DEFAULT NULL,
  `code` varchar(20) DEFAULT NULL COMMENT 'ຊື່ຫຍໍ້',
  `homebranch` varchar(100) DEFAULT NULL,
  `controller` varchar(100) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `address` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `controllerFK` (`controller`),
  KEY `homeBranchFK` (`homebranch`),
  CONSTRAINT `controllerFK` FOREIGN KEY (`controller`) REFERENCES `tbcontollers` (`code`) ON DELETE SET NULL,
  CONSTRAINT `homeBranchFK` FOREIGN KEY (`homebranch`) REFERENCES `tbcompanies` (`ID`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbcompanies` */

insert  into `tbcompanies`(`ID`,`name`,`nameEn`,`code`,`homebranch`,`controller`,`status`,`address`) values 
('C00001','Sitthi Logistic Lao Co., Ltd.','Sitthi Logistic Lao Co., Ltd.','STL','C00001','LA','ACTIVE','ນະຄອນຫລວງວຽງຈັນ'),
('C00003','Anu Test','Anu Test ກຫກ່ກຮນຫ່ກດ','ANU','C00001','LA','ACTIVE',NULL);

/*Table structure for table `tbcontollers` */

DROP TABLE IF EXISTS `tbcontollers`;

CREATE TABLE `tbcontollers` (
  `code` varchar(100) NOT NULL,
  `controller_name` varchar(250) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL COMMENT 'active inactive suspend',
  `keys` varchar(4000) DEFAULT NULL COMMENT 'key generated by keygen',
  PRIMARY KEY (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbcontollers` */

insert  into `tbcontollers`(`code`,`controller_name`,`status`,`keys`) values 
('LA','LA','active','AnuNiti1');

/*Table structure for table `tbdepartments` */

DROP TABLE IF EXISTS `tbdepartments`;

CREATE TABLE `tbdepartments` (
  `ID` varchar(100) NOT NULL,
  `name` varchar(500) DEFAULT NULL,
  `nameEn` varchar(500) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `code` varchar(10) DEFAULT NULL,
  `company` varchar(100) DEFAULT NULL,
  `parent` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `department_parentFk` (`parent`),
  KEY `department_companyFk` (`company`),
  CONSTRAINT `department_companyFk` FOREIGN KEY (`company`) REFERENCES `tbcompanies` (`ID`),
  CONSTRAINT `department_parentFk` FOREIGN KEY (`parent`) REFERENCES `tbdepartments` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbdepartments` */

insert  into `tbdepartments`(`ID`,`name`,`nameEn`,`status`,`code`,`company`,`parent`) values 
('D00001','HR','HR','ACTIVE','HR','C00001',NULL),
('D00002','IT','IT','ACTIVE','IT','C00001',NULL),
('DEPT00004','Finance','Finance','ACTIVE','FIN','C00001',NULL);

/*Table structure for table `tbdivisions` */

DROP TABLE IF EXISTS `tbdivisions`;

CREATE TABLE `tbdivisions` (
  `ID` varchar(100) NOT NULL,
  `code` varchar(10) DEFAULT NULL,
  `name` varchar(500) DEFAULT NULL,
  `nameEn` varchar(500) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `company` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `division_companyFk` (`company`),
  CONSTRAINT `division_companyFk` FOREIGN KEY (`company`) REFERENCES `tbcompanies` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbdivisions` */

insert  into `tbdivisions`(`ID`,`code`,`name`,`nameEn`,`status`,`company`) values 
('DIVS00001','RECT','ຮັບຕ້ອນແລະປະສານງານ','Reception','ACTIVE','C00001');

/*Table structure for table `tbeducation_degrees` */

DROP TABLE IF EXISTS `tbeducation_degrees`;

CREATE TABLE `tbeducation_degrees` (
  `ID` varchar(100) NOT NULL,
  `name` varchar(100) DEFAULT NULL,
  `nameEn` varchar(100) DEFAULT NULL,
  `code` varchar(100) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbeducation_degrees` */

/*Table structure for table `tbeducations` */

DROP TABLE IF EXISTS `tbeducations`;

CREATE TABLE `tbeducations` (
  `ID` varchar(100) NOT NULL,
  `name` varchar(500) DEFAULT NULL,
  `nameEn` varchar(500) DEFAULT NULL,
  `code` varchar(10) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbeducations` */

/*Table structure for table `tbemployee_allowances` */

DROP TABLE IF EXISTS `tbemployee_allowances`;

CREATE TABLE `tbemployee_allowances` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `employee` varchar(100) DEFAULT NULL,
  `allowance` varchar(100) DEFAULT NULL,
  `rate` float DEFAULT NULL COMMENT 'ມູນຄ່າ',
  `dateFrom` date DEFAULT NULL,
  `dateTo` date DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `empAllowanceTbEmpFK` (`employee`),
  KEY `empAllowanceFK` (`allowance`),
  CONSTRAINT `empAllowanceFK` FOREIGN KEY (`allowance`) REFERENCES `tballowances` (`ID`),
  CONSTRAINT `empAllowanceTbEmpFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbemployee_allowances` */

/*Table structure for table `tbemployee_contacts` */

DROP TABLE IF EXISTS `tbemployee_contacts`;

CREATE TABLE `tbemployee_contacts` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `employee` varchar(100) DEFAULT NULL,
  `home` varchar(100) DEFAULT NULL,
  `mobile1` varchar(100) DEFAULT NULL,
  `mobile2` varchar(100) DEFAULT NULL,
  `mobile3` varchar(100) DEFAULT NULL,
  `wa` varchar(100) DEFAULT NULL,
  `line` varchar(100) DEFAULT NULL,
  `fb` varchar(100) DEFAULT NULL,
  `twitter` varchar(100) DEFAULT NULL,
  `emergency` varchar(100) DEFAULT NULL,
  `email1` varchar(100) DEFAULT NULL,
  `email2` varchar(100) DEFAULT NULL,
  `email3` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `employeeFK` (`employee`),
  CONSTRAINT `employeeFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbemployee_contacts` */

/*Table structure for table `tbemployee_education_histories` */

DROP TABLE IF EXISTS `tbemployee_education_histories`;

CREATE TABLE `tbemployee_education_histories` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `employee` varchar(100) DEFAULT NULL,
  `education` varchar(100) DEFAULT NULL,
  `degree` varchar(100) DEFAULT NULL,
  `sequence` int(11) DEFAULT NULL,
  `year` year(4) DEFAULT NULL,
  `major` varchar(250) DEFAULT NULL,
  `educated` varchar(500) DEFAULT NULL,
  `gpa` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `educationEmployeeFK` (`employee`),
  KEY `educationFK` (`education`),
  KEY `degreeFK` (`degree`),
  CONSTRAINT `degreeFK` FOREIGN KEY (`degree`) REFERENCES `tbeducation_degrees` (`ID`) ON DELETE SET NULL ON UPDATE NO ACTION,
  CONSTRAINT `educationEmployeeFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`) ON DELETE SET NULL ON UPDATE NO ACTION,
  CONSTRAINT `educationFK` FOREIGN KEY (`education`) REFERENCES `tbeducations` (`ID`) ON DELETE SET NULL ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbemployee_education_histories` */

/*Table structure for table `tbemployee_health_histories` */

DROP TABLE IF EXISTS `tbemployee_health_histories`;

CREATE TABLE `tbemployee_health_histories` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `employee` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `healthTbEmployeeFK` (`employee`),
  CONSTRAINT `healthTbEmployeeFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbemployee_health_histories` */

/*Table structure for table `tbemployee_relations` */

DROP TABLE IF EXISTS `tbemployee_relations`;

CREATE TABLE `tbemployee_relations` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(500) DEFAULT NULL,
  `nameEn` varchar(500) DEFAULT NULL,
  `relation` varchar(100) DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `empTbRelationFK` (`relation`),
  CONSTRAINT `empTbRelationFK` FOREIGN KEY (`relation`) REFERENCES `tbrelations` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbemployee_relations` */

/*Table structure for table `tbemployee_salary_histories` */

DROP TABLE IF EXISTS `tbemployee_salary_histories`;

CREATE TABLE `tbemployee_salary_histories` (
  `ID` int(11) NOT NULL AUTO_INCREMENT,
  `employee` varchar(100) DEFAULT NULL,
  `salary` float DEFAULT NULL,
  `contract` varchar(100) DEFAULT NULL,
  `dateFrom` date DEFAULT NULL,
  `dateTo` date DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `salaryEmployeeFk` (`employee`),
  CONSTRAINT `salaryEmployeeFk` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbemployee_salary_histories` */

/*Table structure for table `tbemployees` */

DROP TABLE IF EXISTS `tbemployees`;

CREATE TABLE `tbemployees` (
  `ID` varchar(100) NOT NULL,
  `name` varchar(500) DEFAULT NULL,
  `nameEn` varchar(500) DEFAULT NULL,
  `nickname` varchar(500) DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `hireDate` date DEFAULT NULL,
  `resignDate` date DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `job` varchar(100) DEFAULT NULL,
  `position` varchar(100) DEFAULT NULL,
  `department` varchar(100) DEFAULT NULL,
  `division` varchar(100) DEFAULT NULL,
  `section` varchar(100) DEFAULT NULL,
  `dependent` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `JobFK` (`job`),
  KEY `PositionFK` (`position`),
  KEY `DepartmentFK` (`department`),
  KEY `divisionFK` (`division`),
  KEY `sectionFK` (`section`),
  KEY `dependentFK` (`dependent`),
  CONSTRAINT `DepartmentFK` FOREIGN KEY (`department`) REFERENCES `tbdepartments` (`ID`) ON DELETE SET NULL,
  CONSTRAINT `JobFK` FOREIGN KEY (`job`) REFERENCES `tbjobs` (`ID`) ON DELETE SET NULL,
  CONSTRAINT `PositionFK` FOREIGN KEY (`position`) REFERENCES `tbpostions` (`ID`) ON DELETE SET NULL,
  CONSTRAINT `dependentFK` FOREIGN KEY (`dependent`) REFERENCES `tbemployees` (`ID`) ON DELETE SET NULL,
  CONSTRAINT `divisionFK` FOREIGN KEY (`division`) REFERENCES `tbdivisions` (`ID`) ON DELETE SET NULL,
  CONSTRAINT `sectionFK` FOREIGN KEY (`section`) REFERENCES `tbsections` (`ID`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbemployees` */

insert  into `tbemployees`(`ID`,`name`,`nameEn`,`nickname`,`dob`,`hireDate`,`resignDate`,`status`,`job`,`position`,`department`,`division`,`section`,`dependent`) values 
('admin','admin','admin','admin',NULL,'2020-01-01','2100-12-31','active','admin',NULL,NULL,NULL,NULL,NULL);

/*Table structure for table `tbjobs` */

DROP TABLE IF EXISTS `tbjobs`;

CREATE TABLE `tbjobs` (
  `ID` varchar(100) NOT NULL,
  `name` varchar(500) DEFAULT NULL,
  `nameEn` varchar(500) DEFAULT NULL,
  `code` varchar(10) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbjobs` */

insert  into `tbjobs`(`ID`,`name`,`nameEn`,`code`,`status`) values 
('admin','admin','admin','admin','active');

/*Table structure for table `tbpostions` */

DROP TABLE IF EXISTS `tbpostions`;

CREATE TABLE `tbpostions` (
  `ID` varchar(100) NOT NULL,
  `name` varchar(500) DEFAULT NULL,
  `nameEn` varchar(500) DEFAULT NULL,
  `code` varchar(10) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbpostions` */

insert  into `tbpostions`(`ID`,`name`,`nameEn`,`code`,`status`) values 
('POSI00001','ຄົນຂັບລົດ','Drivers','DRIV','ACTIVE');

/*Table structure for table `tbrelations` */

DROP TABLE IF EXISTS `tbrelations`;

CREATE TABLE `tbrelations` (
  `ID` varchar(100) NOT NULL,
  `name` varchar(500) DEFAULT NULL,
  `nameEn` varchar(500) DEFAULT NULL,
  `code` varchar(10) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbrelations` */

/*Table structure for table `tbroles` */

DROP TABLE IF EXISTS `tbroles`;

CREATE TABLE `tbroles` (
  `ID` varchar(100) NOT NULL,
  `name` varchar(250) DEFAULT NULL,
  `nameEn` varchar(250) DEFAULT NULL,
  `code` varchar(10) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbroles` */

insert  into `tbroles`(`ID`,`name`,`nameEn`,`code`,`status`) values 
('admin','admin','admin','admin','active');

/*Table structure for table `tbrules` */

DROP TABLE IF EXISTS `tbrules`;

CREATE TABLE `tbrules` (
  `ID` varchar(100) NOT NULL,
  `name` varchar(250) DEFAULT NULL,
  `isSuperAdmin` tinyint(1) DEFAULT NULL,
  `canLogin` tinyint(1) DEFAULT NULL,
  `canCreate` tinyint(1) DEFAULT NULL,
  `canUpdate` tinyint(1) DEFAULT NULL,
  `canDelete` tinyint(1) DEFAULT NULL,
  `canApprove` tinyint(1) DEFAULT NULL,
  `canRequest` tinyint(1) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbrules` */

insert  into `tbrules`(`ID`,`name`,`isSuperAdmin`,`canLogin`,`canCreate`,`canUpdate`,`canDelete`,`canApprove`,`canRequest`) values 
('admin','admin',0,0,0,0,0,0,0),
('user1','level1',0,0,0,0,0,0,0);

/*Table structure for table `tbsections` */

DROP TABLE IF EXISTS `tbsections`;

CREATE TABLE `tbsections` (
  `ID` varchar(100) NOT NULL,
  `name` varchar(500) DEFAULT NULL,
  `nameEn` varchar(500) DEFAULT NULL,
  `code` varchar(10) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Data for the table `tbsections` */

insert  into `tbsections`(`ID`,`name`,`nameEn`,`code`,`status`) values 
('SECT00001','ຝ່າຍຂາຍ1','Sale Section','SALE','ACTIVE');

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
