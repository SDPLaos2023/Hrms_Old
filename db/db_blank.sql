/*
SQLyog Community v13.1.9 (64 bit)
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

/*Table structure for table `__efmigrationshistory` */

DROP TABLE IF EXISTS `__efmigrationshistory`;

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL,
  PRIMARY KEY (`MigrationId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `attlogs_bak` */

DROP TABLE IF EXISTS `attlogs_bak`;

CREATE TABLE `attlogs_bak` (
  `id` varchar(100) NOT NULL,
  `fp_id` varchar(100) DEFAULT NULL,
  `att_date` date DEFAULT NULL,
  `att_time` time DEFAULT NULL,
  `att_code` varchar(100) DEFAULT NULL,
  `fp_user_id` varchar(100) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

/*Table structure for table `auth_user_roles` */

DROP TABLE IF EXISTS `auth_user_roles`;

CREATE TABLE `auth_user_roles` (
  `ID` varchar(100) NOT NULL,
  `user` varchar(100) DEFAULT NULL,
  `role` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `role_tbRolesFk` (`role`),
  KEY `role_user` (`user`),
  CONSTRAINT `role_tbRolesFk` FOREIGN KEY (`role`) REFERENCES `tbroles` (`ID`),
  CONSTRAINT `role_user` FOREIGN KEY (`user`) REFERENCES `auth_users` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `auth_user_rules` */

DROP TABLE IF EXISTS `auth_user_rules`;

CREATE TABLE `auth_user_rules` (
  `id` varchar(100) NOT NULL,
  `user` varchar(100) DEFAULT NULL,
  `rule` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `user_ruleFK` (`rule`),
  KEY `auth_userFK` (`user`),
  CONSTRAINT `auth_userFK` FOREIGN KEY (`user`) REFERENCES `auth_users` (`ID`),
  CONSTRAINT `user_ruleFK` FOREIGN KEY (`rule`) REFERENCES `tbrules` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `auth_users` */

DROP TABLE IF EXISTS `auth_users`;

CREATE TABLE `auth_users` (
  `ID` varchar(100) NOT NULL,
  `username` varchar(250) DEFAULT NULL,
  `password` varchar(500) DEFAULT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  `role` varchar(100) DEFAULT 'ROLE_USERS',
  `rule` varchar(100) DEFAULT 'RU00003',
  `isChangePwd` tinyint(1) DEFAULT 0,
  PRIMARY KEY (`ID`),
  KEY `user_employeeFk` (`employee`),
  KEY `user_role` (`role`),
  KEY `user_rule` (`rule`),
  CONSTRAINT `user_employeeFk` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`),
  CONSTRAINT `user_role` FOREIGN KEY (`role`) REFERENCES `tbroles` (`ID`),
  CONSTRAINT `user_rule` FOREIGN KEY (`rule`) REFERENCES `tbrules` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `numbercontrol` */

DROP TABLE IF EXISTS `numbercontrol`;

CREATE TABLE `numbercontrol` (
  `code` varchar(100) NOT NULL,
  `company` varchar(100) DEFAULT NULL,
  `number` int(11) DEFAULT NULL,
  `remark` varchar(200) DEFAULT NULL,
  `strlength` varchar(2) DEFAULT '6',
  PRIMARY KEY (`code`),
  KEY `number_companyFk` (`company`),
  CONSTRAINT `number_companyFk` FOREIGN KEY (`company`) REFERENCES `tbcompanies` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

/*Table structure for table `tbannual_leave_types` */

DROP TABLE IF EXISTS `tbannual_leave_types`;

CREATE TABLE `tbannual_leave_types` (
  `id` varchar(100) NOT NULL,
  `name` varchar(500) DEFAULT NULL,
  `nameEn` varchar(500) DEFAULT NULL,
  `code` varchar(10) DEFAULT NULL,
  `ratio` int(11) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `leave_type` varchar(5) DEFAULT 'WP',
  `company` varchar(100) DEFAULT 'C00001',
  PRIMARY KEY (`id`),
  KEY `lt_company_fk` (`company`),
  CONSTRAINT `lt_company_fk` FOREIGN KEY (`company`) REFERENCES `tbcompanies` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbattcalculated` */

DROP TABLE IF EXISTS `tbattcalculated`;

CREATE TABLE `tbattcalculated` (
  `id` varchar(100) NOT NULL,
  `employeecode` varchar(100) DEFAULT NULL,
  `employeename` varchar(500) DEFAULT NULL,
  `minwork` int(11) DEFAULT NULL,
  `late_in` int(11) DEFAULT NULL,
  `total_late` int(11) DEFAULT NULL,
  `early_out` int(11) DEFAULT NULL,
  `total_early_out` int(11) DEFAULT NULL,
  `totalworkdays` int(11) DEFAULT NULL,
  `totaldays` int(11) DEFAULT NULL,
  `total_hrs` int(11) DEFAULT NULL,
  `totalworkhrs` double DEFAULT NULL,
  `totalmissdays` int(11) DEFAULT NULL,
  `totalleavewp` int(11) DEFAULT NULL,
  `totalleavewop` int(11) DEFAULT NULL,
  `totalleaves` int(11) DEFAULT NULL,
  `sessionid` varchar(250) DEFAULT NULL,
  `created_by` varchar(100) DEFAULT NULL,
  `data_asofdate` date DEFAULT NULL,
  `company` varchar(100) DEFAULT 'C00001',
  PRIMARY KEY (`id`),
  KEY `companypk` (`company`),
  CONSTRAINT `companypk` FOREIGN KEY (`company`) REFERENCES `tbcompanies` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbattendancelogs` */

DROP TABLE IF EXISTS `tbattendancelogs`;

CREATE TABLE `tbattendancelogs` (
  `id` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `att_date` date DEFAULT NULL,
  `att_time` time DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  `fp_id` varchar(100) DEFAULT NULL,
  `fp_user_id` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `attendance_employee` (`employee`),
  KEY `attendance_fp_id` (`fp_id`),
  CONSTRAINT `attendance_employee` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`id`),
  CONSTRAINT `attendance_fp_id` FOREIGN KEY (`fp_id`) REFERENCES `tbfingerprints` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbattlogs` */

DROP TABLE IF EXISTS `tbattlogs`;

CREATE TABLE `tbattlogs` (
  `id` varchar(100) NOT NULL,
  `fp_id` varchar(100) DEFAULT NULL,
  `att_date` date DEFAULT NULL,
  `att_time` time DEFAULT NULL,
  `att_code` varchar(100) DEFAULT NULL,
  `fp_user_id` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fp_user_id` (`fp_user_id`),
  KEY `fp_id` (`fp_id`),
  CONSTRAINT `attlog_fp` FOREIGN KEY (`fp_id`) REFERENCES `tbfingerprints` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbbanks` */

DROP TABLE IF EXISTS `tbbanks`;

CREATE TABLE `tbbanks` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbbloodgroups` */

DROP TABLE IF EXISTS `tbbloodgroups`;

CREATE TABLE `tbbloodgroups` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbcardmappings` */

DROP TABLE IF EXISTS `tbcardmappings`;

CREATE TABLE `tbcardmappings` (
  `id` varchar(100) NOT NULL,
  `fp_id` varchar(100) DEFAULT NULL,
  `card_number` varchar(100) DEFAULT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

/*Table structure for table `tbcontollers` */

DROP TABLE IF EXISTS `tbcontollers`;

CREATE TABLE `tbcontollers` (
  `code` varchar(100) NOT NULL,
  `controller_name` varchar(250) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL COMMENT 'active inactive suspend',
  `keys` varchar(4000) DEFAULT NULL COMMENT 'key generated by keygen',
  PRIMARY KEY (`code`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbcontract_types` */

DROP TABLE IF EXISTS `tbcontract_types`;

CREATE TABLE `tbcontract_types` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbcountries` */

DROP TABLE IF EXISTS `tbcountries`;

CREATE TABLE `tbcountries` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbcurrencies` */

DROP TABLE IF EXISTS `tbcurrencies`;

CREATE TABLE `tbcurrencies` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

/*Table structure for table `tbdistricts` */

DROP TABLE IF EXISTS `tbdistricts`;

CREATE TABLE `tbdistricts` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  `Province` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `District_ProvinceFk` (`Province`),
  CONSTRAINT `District_ProvinceFk` FOREIGN KEY (`Province`) REFERENCES `tbprovinces` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

/*Table structure for table `tbemployee_allowances` */

DROP TABLE IF EXISTS `tbemployee_allowances`;

CREATE TABLE `tbemployee_allowances` (
  `ID` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `allowance` varchar(100) DEFAULT NULL,
  `rate` float DEFAULT NULL COMMENT 'ມູນຄ່າ',
  `status` varchar(10) DEFAULT NULL,
  `created_at` date DEFAULT NULL,
  `created_by` varchar(100) DEFAULT NULL,
  `updated_at` date DEFAULT NULL,
  `updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `empAllowanceTbEmpFK` (`employee`),
  KEY `empAllowanceFK` (`allowance`),
  CONSTRAINT `empAllowanceFK` FOREIGN KEY (`allowance`) REFERENCES `tballowances` (`ID`),
  CONSTRAINT `empAllowanceTbEmpFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_catagories` */

DROP TABLE IF EXISTS `tbemployee_catagories`;

CREATE TABLE `tbemployee_catagories` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_classifications` */

DROP TABLE IF EXISTS `tbemployee_classifications`;

CREATE TABLE `tbemployee_classifications` (
  `id` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `employee_type` varchar(100) DEFAULT NULL,
  `employee_group` varchar(100) DEFAULT NULL,
  `employee_category` varchar(100) DEFAULT NULL,
  `employee_level` varchar(100) DEFAULT NULL,
  `employee_working_type` varchar(100) DEFAULT NULL,
  `created_at` date DEFAULT NULL,
  `created_by` varchar(100) DEFAULT NULL,
  `updated_at` date DEFAULT NULL,
  `updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `class_employeeFK` (`employee`),
  KEY `class_emp_typeFK` (`employee_type`),
  KEY `class_emp_groupFK` (`employee_group`),
  KEY `class_emp_categoryFK` (`employee_category`),
  KEY `class_emp_levelFK` (`employee_level`),
  KEY `class_emp_working_typeFK` (`employee_working_type`),
  CONSTRAINT `class_emp_categoryFK` FOREIGN KEY (`employee_category`) REFERENCES `tbemployee_catagories` (`ID`),
  CONSTRAINT `class_emp_groupFK` FOREIGN KEY (`employee_group`) REFERENCES `tbemployee_groups` (`ID`),
  CONSTRAINT `class_emp_levelFK` FOREIGN KEY (`employee_level`) REFERENCES `tbemployee_levels` (`ID`),
  CONSTRAINT `class_emp_typeFK` FOREIGN KEY (`employee_type`) REFERENCES `tbemployee_types` (`ID`),
  CONSTRAINT `class_emp_working_typeFK` FOREIGN KEY (`employee_working_type`) REFERENCES `tbworking_types` (`ID`),
  CONSTRAINT `class_employeeFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_contacts` */

DROP TABLE IF EXISTS `tbemployee_contacts`;

CREATE TABLE `tbemployee_contacts` (
  `ID` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `mobile` varchar(100) DEFAULT NULL,
  `home` varchar(100) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `wa` varchar(100) DEFAULT NULL,
  `line` varchar(100) DEFAULT NULL,
  `wechat` varchar(100) DEFAULT NULL,
  `facebook` varchar(100) DEFAULT NULL,
  `twitter` varchar(100) DEFAULT NULL,
  `skype` varchar(100) DEFAULT NULL,
  `contact_person` varchar(100) DEFAULT NULL,
  `contact_number` varchar(100) DEFAULT NULL,
  `contact_relation` varchar(100) DEFAULT NULL,
  `created_by` varchar(100) DEFAULT NULL,
  `created_at` date DEFAULT NULL,
  `updated_by` varchar(100) DEFAULT NULL,
  `updated_at` date DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `employeeFK` (`employee`),
  CONSTRAINT `employeeFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_contracts` */

DROP TABLE IF EXISTS `tbemployee_contracts`;

CREATE TABLE `tbemployee_contracts` (
  `id` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `contract_type` varchar(100) DEFAULT NULL,
  `contract_start_at` date DEFAULT NULL,
  `contract_stop_at` date DEFAULT NULL,
  `contract_no` varchar(100) DEFAULT NULL,
  `created_at` date DEFAULT NULL,
  `created_by` varchar(100) DEFAULT NULL,
  `updated_at` date DEFAULT NULL,
  `updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `contract_empFK` (`employee`),
  KEY `contract_typeFK` (`contract_type`),
  CONSTRAINT `contract_empFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`),
  CONSTRAINT `contract_typeFK` FOREIGN KEY (`contract_type`) REFERENCES `tbcontract_types` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_education_histories` */

DROP TABLE IF EXISTS `tbemployee_education_histories`;

CREATE TABLE `tbemployee_education_histories` (
  `ID` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `institution` varchar(500) DEFAULT NULL COMMENT 'graduated from',
  `degree` varchar(100) DEFAULT NULL,
  `year` year(4) DEFAULT NULL,
  `major` varchar(250) DEFAULT NULL,
  `gpa` varchar(10) DEFAULT NULL,
  `sequence` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `educationEmployeeFK` (`employee`),
  KEY `degreeFK` (`degree`),
  KEY `education_institutionFK` (`institution`),
  CONSTRAINT `degreeFK` FOREIGN KEY (`degree`) REFERENCES `tbeducation_degrees` (`ID`) ON DELETE SET NULL ON UPDATE NO ACTION,
  CONSTRAINT `educationEmployeeFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`) ON DELETE SET NULL ON UPDATE NO ACTION,
  CONSTRAINT `education_institutionFK` FOREIGN KEY (`institution`) REFERENCES `tbinstitutions` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_employments` */

DROP TABLE IF EXISTS `tbemployee_employments`;

CREATE TABLE `tbemployee_employments` (
  `id` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `position` varchar(100) DEFAULT NULL,
  `department` varchar(100) DEFAULT NULL,
  `division` varchar(100) DEFAULT NULL,
  `section` varchar(100) DEFAULT NULL,
  `created_at` date DEFAULT NULL,
  `created_by` varchar(100) DEFAULT NULL,
  `updated_at` date DEFAULT NULL,
  `updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `employment_employeeFK` (`employee`),
  KEY `employment_positionFK` (`position`),
  KEY `employment_departmentFK` (`department`),
  KEY `employment_divisionFK` (`division`),
  KEY `employment_sectionFK` (`section`),
  CONSTRAINT `employment_departmentFK` FOREIGN KEY (`department`) REFERENCES `tbdepartments` (`ID`),
  CONSTRAINT `employment_divisionFK` FOREIGN KEY (`division`) REFERENCES `tbdivisions` (`ID`),
  CONSTRAINT `employment_employeeFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`),
  CONSTRAINT `employment_positionFK` FOREIGN KEY (`position`) REFERENCES `tbpostions` (`ID`),
  CONSTRAINT `employment_sectionFK` FOREIGN KEY (`section`) REFERENCES `tbsections` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_family_contacts` */

DROP TABLE IF EXISTS `tbemployee_family_contacts`;

CREATE TABLE `tbemployee_family_contacts` (
  `id` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `father_name` varchar(200) DEFAULT NULL,
  `father_dob` date DEFAULT NULL,
  `father_contact_number` varchar(100) DEFAULT NULL,
  `mother_name` varchar(200) DEFAULT NULL,
  `mother_dob` date DEFAULT NULL,
  `mother_contact_number` varchar(100) DEFAULT NULL,
  `spouse_name` varchar(200) DEFAULT NULL,
  `spouse_dob` date DEFAULT NULL,
  `spouse_contact_number` varchar(100) DEFAULT NULL,
  `no_children` int(11) DEFAULT NULL,
  `no_daughter` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `family_empFK` (`employee`),
  CONSTRAINT `family_empFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_groups` */

DROP TABLE IF EXISTS `tbemployee_groups`;

CREATE TABLE `tbemployee_groups` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_health_histories` */

DROP TABLE IF EXISTS `tbemployee_health_histories`;

CREATE TABLE `tbemployee_health_histories` (
  `id` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `location` varchar(500) DEFAULT NULL,
  `description` varchar(500) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `file_path` varchar(500) DEFAULT NULL,
  `dateLog` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `healthTbEmployeeFK` (`employee`),
  CONSTRAINT `healthTbEmployeeFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_identities` */

DROP TABLE IF EXISTS `tbemployee_identities`;

CREATE TABLE `tbemployee_identities` (
  `id` varchar(100) NOT NULL,
  `id_number` varchar(100) DEFAULT NULL,
  `id_type` varchar(100) DEFAULT NULL,
  `id_expiry_date` date DEFAULT NULL,
  `id_issued_by` varchar(500) DEFAULT NULL,
  `employee` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `identity_employeeFK` (`employee`),
  KEY `identity_typeFk` (`id_type`),
  CONSTRAINT `identity_employeeFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`id`),
  CONSTRAINT `identity_typeFk` FOREIGN KEY (`id_type`) REFERENCES `tbidentity_types` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_insurances` */

DROP TABLE IF EXISTS `tbemployee_insurances`;

CREATE TABLE `tbemployee_insurances` (
  `id` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `ssn` varchar(100) DEFAULT NULL,
  `rate` float DEFAULT NULL COMMENT 'rate pay',
  `insurance_certificate` varchar(100) DEFAULT NULL,
  `insurance_expiry_date` date DEFAULT NULL,
  `created_at` date DEFAULT NULL,
  `created_by` varchar(100) DEFAULT NULL,
  `updated_at` date DEFAULT NULL,
  `updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `insurance_employeeFK` (`employee`),
  CONSTRAINT `insurance_employeeFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_leave_settings` */

DROP TABLE IF EXISTS `tbemployee_leave_settings`;

CREATE TABLE `tbemployee_leave_settings` (
  `id` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `employee_annual_leave` varchar(100) DEFAULT NULL,
  `ratio` int(11) DEFAULT NULL,
  `remain` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `leave_setting_employeeFK` (`employee`),
  KEY `annual_leave_typeFK` (`employee_annual_leave`),
  CONSTRAINT `annual_leave_typeFK` FOREIGN KEY (`employee_annual_leave`) REFERENCES `tbannual_leave_types` (`id`),
  CONSTRAINT `leave_setting_employeeFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_levels` */

DROP TABLE IF EXISTS `tbemployee_levels`;

CREATE TABLE `tbemployee_levels` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  `Seq` int(11) DEFAULT 0,
  `directReport` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_probations` */

DROP TABLE IF EXISTS `tbemployee_probations`;

CREATE TABLE `tbemployee_probations` (
  `id` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `contract_start_at` date DEFAULT NULL,
  `contract_stop_at` date DEFAULT NULL,
  `created_at` date DEFAULT NULL,
  `created_by` varchar(100) DEFAULT NULL,
  `updated_at` date DEFAULT NULL,
  `updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `probation_empFK` (`employee`),
  CONSTRAINT `probation_empFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

/*Table structure for table `tbemployee_salary_histories` */

DROP TABLE IF EXISTS `tbemployee_salary_histories`;

CREATE TABLE `tbemployee_salary_histories` (
  `ID` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `salary` float DEFAULT NULL,
  `contract` varchar(100) DEFAULT NULL,
  `dateFrom` date DEFAULT NULL,
  `dateTo` date DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `salaryEmployeeFk` (`employee`),
  CONSTRAINT `salaryEmployeeFk` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`) ON DELETE SET NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_salary_settings` */

DROP TABLE IF EXISTS `tbemployee_salary_settings`;

CREATE TABLE `tbemployee_salary_settings` (
  `id` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `base_salary` float DEFAULT NULL,
  `salary_type` varchar(100) DEFAULT NULL,
  `salary_pay_type` varchar(100) DEFAULT NULL,
  `bank` varchar(100) DEFAULT NULL,
  `bank_account` varchar(100) DEFAULT NULL,
  `created_at` date DEFAULT NULL,
  `created_by` varchar(100) DEFAULT NULL,
  `updated_at` date DEFAULT NULL,
  `updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `salary_employeeFK` (`employee`),
  KEY `salary_typeFK` (`salary_type`),
  KEY `salary_pay_typeFK` (`salary_pay_type`),
  KEY `salary_bankFK` (`bank`),
  CONSTRAINT `salary_bankFK` FOREIGN KEY (`bank`) REFERENCES `tbbanks` (`ID`),
  CONSTRAINT `salary_employeeFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`),
  CONSTRAINT `salary_pay_typeFK` FOREIGN KEY (`salary_pay_type`) REFERENCES `tbsalary_pay_types` (`ID`),
  CONSTRAINT `salary_typeFK` FOREIGN KEY (`salary_type`) REFERENCES `tbsalary_types` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_schedules` */

DROP TABLE IF EXISTS `tbemployee_schedules`;

CREATE TABLE `tbemployee_schedules` (
  `id` varchar(100) NOT NULL,
  `shift` varchar(100) DEFAULT NULL,
  `fp_user_id` varchar(100) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(100) DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_schedule_shift` (`shift`),
  CONSTRAINT `fk_schedule_shift` FOREIGN KEY (`shift`) REFERENCES `tbshiftmanagements` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_supervisors` */

DROP TABLE IF EXISTS `tbemployee_supervisors`;

CREATE TABLE `tbemployee_supervisors` (
  `ID` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `supervisor` varchar(100) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  `remark` varchar(250) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `employeeMappingFK` (`employee`),
  KEY `employeeSupervisor` (`supervisor`),
  CONSTRAINT `employeeMappingFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`id`),
  CONSTRAINT `employeeSupervisor` FOREIGN KEY (`supervisor`) REFERENCES `tbemployees` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_transactions` */

DROP TABLE IF EXISTS `tbemployee_transactions`;

CREATE TABLE `tbemployee_transactions` (
  `id` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `transaction_type` varchar(100) DEFAULT NULL,
  `effective_date` date DEFAULT NULL,
  `description` varchar(1000) DEFAULT NULL,
  `created_at` date DEFAULT NULL,
  `created_by` varchar(100) DEFAULT NULL,
  `updated_at` date DEFAULT NULL,
  `updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `transaction_empFK` (`employee`),
  KEY `transaction_type` (`transaction_type`),
  CONSTRAINT `tbemployee_transactions_ibfk_1` FOREIGN KEY (`transaction_type`) REFERENCES `tbtransaction_types` (`ID`),
  CONSTRAINT `transaction_empFK` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_types` */

DROP TABLE IF EXISTS `tbemployee_types`;

CREATE TABLE `tbemployee_types` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployee_working_periods` */

DROP TABLE IF EXISTS `tbemployee_working_periods`;

CREATE TABLE `tbemployee_working_periods` (
  `id` varchar(100) NOT NULL,
  `working_period` varchar(100) DEFAULT NULL,
  `fp_user_id` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `pk_working_period` (`working_period`),
  CONSTRAINT `pk_working_period` FOREIGN KEY (`working_period`) REFERENCES `tbworkingperiods` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbemployees` */

DROP TABLE IF EXISTS `tbemployees`;

CREATE TABLE `tbemployees` (
  `id` varchar(100) NOT NULL,
  `code` varchar(10) DEFAULT NULL COMMENT 'attendance id',
  `name` varchar(500) DEFAULT NULL,
  `nameEn` varchar(500) DEFAULT NULL,
  `dob` date DEFAULT NULL,
  `gender` varchar(100) DEFAULT NULL,
  `blood_group` varchar(100) DEFAULT NULL,
  `nationality` varchar(100) DEFAULT NULL,
  `race` varchar(100) DEFAULT NULL,
  `id_card` varchar(100) DEFAULT NULL,
  `id_card_expiry_date` date DEFAULT NULL,
  `id_card_issued_by` varchar(100) DEFAULT NULL,
  `passport_no` varchar(100) DEFAULT NULL,
  `passport_expiry_date` date DEFAULT NULL,
  `passport_issued_by` varchar(250) DEFAULT NULL,
  `address` varchar(500) DEFAULT NULL,
  `province` varchar(100) DEFAULT NULL,
  `district` varchar(100) DEFAULT NULL,
  `country` varchar(100) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `marital_status` varchar(100) DEFAULT NULL,
  `created_by` varchar(100) DEFAULT NULL,
  `created_at` date DEFAULT NULL,
  `updated_by` varchar(100) DEFAULT NULL,
  `updated_at` date DEFAULT NULL,
  `avatar` varchar(500) DEFAULT NULL,
  `company` varchar(100) DEFAULT 'C00001',
  PRIMARY KEY (`id`),
  KEY `emp_nationalityFK` (`nationality`),
  KEY `emp_raceFK` (`race`),
  KEY `emp_bloodGroupFK` (`blood_group`),
  KEY `emp_maritalStatusFK` (`marital_status`),
  KEY `emp_provinceFK` (`province`),
  KEY `emp_districtFK` (`district`),
  KEY `emp_countryFK` (`country`),
  KEY `emp_company_fk` (`company`),
  CONSTRAINT `emp_bloodGroupFK` FOREIGN KEY (`blood_group`) REFERENCES `tbbloodgroups` (`ID`),
  CONSTRAINT `emp_company_fk` FOREIGN KEY (`company`) REFERENCES `tbcompanies` (`ID`),
  CONSTRAINT `emp_countryFK` FOREIGN KEY (`country`) REFERENCES `tbcountries` (`ID`),
  CONSTRAINT `emp_districtFK` FOREIGN KEY (`district`) REFERENCES `tbdistricts` (`ID`),
  CONSTRAINT `emp_maritalStatusFK` FOREIGN KEY (`marital_status`) REFERENCES `tbmarriages` (`ID`),
  CONSTRAINT `emp_nationalityFK` FOREIGN KEY (`Nationality`) REFERENCES `tbnationalities` (`ID`),
  CONSTRAINT `emp_provinceFK` FOREIGN KEY (`province`) REFERENCES `tbprovinces` (`ID`),
  CONSTRAINT `emp_raceFK` FOREIGN KEY (`Race`) REFERENCES `tbraces` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbfiles` */

DROP TABLE IF EXISTS `tbfiles`;

CREATE TABLE `tbfiles` (
  `id` varchar(100) NOT NULL,
  `display_name` varchar(250) DEFAULT NULL,
  `path` varchar(500) DEFAULT NULL,
  `file_name` varchar(500) DEFAULT NULL,
  `file_type` varchar(100) DEFAULT NULL,
  `file_size` int(11) DEFAULT NULL,
  `owner` varchar(100) DEFAULT NULL,
  `created_at` date DEFAULT NULL,
  `updated_at` date DEFAULT NULL,
  `created_by` varchar(100) DEFAULT NULL,
  `updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbfingerprintmappings` */

DROP TABLE IF EXISTS `tbfingerprintmappings`;

CREATE TABLE `tbfingerprintmappings` (
  `id` varchar(100) NOT NULL,
  `finger_user_id` varchar(100) DEFAULT NULL,
  `finger_index` varchar(100) DEFAULT NULL,
  `finger_img` text DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbfingerprints` */

DROP TABLE IF EXISTS `tbfingerprints`;

CREATE TABLE `tbfingerprints` (
  `id` varchar(100) NOT NULL,
  `name` varchar(250) DEFAULT NULL,
  `ip_address` varchar(250) DEFAULT NULL,
  `port` varchar(100) DEFAULT NULL,
  `sn` varchar(250) DEFAULT NULL,
  `mac` varchar(250) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbfpusers` */

DROP TABLE IF EXISTS `tbfpusers`;

CREATE TABLE `tbfpusers` (
  `id` varchar(100) NOT NULL,
  `fp_id` varchar(100) DEFAULT NULL,
  `fp_user_name` varchar(100) DEFAULT NULL,
  `fp_user_id` varchar(100) DEFAULT NULL,
  `fp_role` varchar(100) DEFAULT NULL,
  `employee` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbholiday_settings` */

DROP TABLE IF EXISTS `tbholiday_settings`;

CREATE TABLE `tbholiday_settings` (
  `id` varchar(100) NOT NULL,
  `date` date DEFAULT NULL,
  `name` varchar(250) DEFAULT NULL,
  `description` varchar(500) DEFAULT NULL,
  `isDraft` tinyint(1) DEFAULT 0,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbidentity_types` */

DROP TABLE IF EXISTS `tbidentity_types`;

CREATE TABLE `tbidentity_types` (
  `ID` varchar(100) NOT NULL,
  `name` varchar(500) DEFAULT NULL,
  `nameEn` varchar(500) DEFAULT NULL,
  `code` varchar(10) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbinstitutions` */

DROP TABLE IF EXISTS `tbinstitutions`;

CREATE TABLE `tbinstitutions` (
  `ID` varchar(100) NOT NULL,
  `name` varchar(500) DEFAULT NULL,
  `nameEn` varchar(500) DEFAULT NULL,
  `code` varchar(10) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

/*Table structure for table `tbleave_requests` */

DROP TABLE IF EXISTS `tbleave_requests`;

CREATE TABLE `tbleave_requests` (
  `id` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `leave_type` varchar(100) DEFAULT NULL,
  `datefrom` datetime DEFAULT NULL,
  `dateto` datetime DEFAULT NULL,
  `total` float DEFAULT 0,
  `need_approval` tinyint(1) DEFAULT 1,
  `need_hr_approval` tinyint(1) DEFAULT 1,
  `approved_by` varchar(100) DEFAULT NULL,
  `hr_approved_by` varchar(100) DEFAULT NULL,
  `approval_note` varchar(1000) DEFAULT NULL,
  `hr_approval_note` varchar(1000) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(100) DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `updated_by` varchar(100) DEFAULT NULL,
  `remark` varchar(1000) DEFAULT NULL,
  `fp_user_id` varchar(100) DEFAULT NULL,
  `company` varchar(100) DEFAULT 'C00001',
  `status` varchar(100) DEFAULT 'ACTIVE',
  PRIMARY KEY (`id`),
  KEY `fk_lr_employee` (`employee`),
  KEY `fk_lr_company` (`company`),
  CONSTRAINT `fk_lr_company` FOREIGN KEY (`company`) REFERENCES `tbcompanies` (`ID`),
  CONSTRAINT `fk_lr_employee` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbleavelogs` */

DROP TABLE IF EXISTS `tbleavelogs`;

CREATE TABLE `tbleavelogs` (
  `id` varchar(100) NOT NULL,
  `leave_day` date DEFAULT NULL,
  `leave_id` varchar(100) DEFAULT NULL,
  `fp_user_id` varchar(100) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `status` varchar(5) DEFAULT 'WP' COMMENT 'WP WOP',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbmarriages` */

DROP TABLE IF EXISTS `tbmarriages`;

CREATE TABLE `tbmarriages` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbnationalities` */

DROP TABLE IF EXISTS `tbnationalities`;

CREATE TABLE `tbnationalities` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tborganizationcharts` */

DROP TABLE IF EXISTS `tborganizationcharts`;

CREATE TABLE `tborganizationcharts` (
  `ID` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `reportsTo` varchar(100) DEFAULT NULL,
  `jobtitle` varchar(100) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbot` */

DROP TABLE IF EXISTS `tbot`;

CREATE TABLE `tbot` (
  `id` varchar(100) NOT NULL,
  `ot_date` date DEFAULT NULL,
  `ot_in` time DEFAULT NULL,
  `ot_out` time DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `employee` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbotrequests` */

DROP TABLE IF EXISTS `tbotrequests`;

CREATE TABLE `tbotrequests` (
  `id` varchar(100) NOT NULL,
  `ot_date` date DEFAULT NULL,
  `ot_in` time DEFAULT NULL,
  `ot_out` time DEFAULT NULL,
  `authorizer_id` varchar(100) DEFAULT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbpage_masters` */

DROP TABLE IF EXISTS `tbpage_masters`;

CREATE TABLE `tbpage_masters` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(500) DEFAULT NULL,
  `uri` varchar(250) DEFAULT NULL,
  `description` varchar(500) DEFAULT NULL,
  `page_group` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=41 DEFAULT CHARSET=utf8;

/*Table structure for table `tbpage_uri` */

DROP TABLE IF EXISTS `tbpage_uri`;

CREATE TABLE `tbpage_uri` (
  `id` varchar(100) NOT NULL,
  `name` varchar(250) DEFAULT NULL,
  `uri` varchar(250) DEFAULT NULL,
  `active` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbpostions` */

DROP TABLE IF EXISTS `tbpostions`;

CREATE TABLE `tbpostions` (
  `ID` varchar(100) NOT NULL,
  `name` varchar(500) DEFAULT NULL,
  `nameEn` varchar(500) DEFAULT NULL,
  `code` varchar(10) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `Level` varchar(100) DEFAULT 'EL',
  PRIMARY KEY (`ID`),
  KEY `posi_fk_level` (`Level`),
  CONSTRAINT `posi_fk_level` FOREIGN KEY (`Level`) REFERENCES `tbemployee_levels` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbprovinces` */

DROP TABLE IF EXISTS `tbprovinces`;

CREATE TABLE `tbprovinces` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  `Country` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  KEY `Province_CountryFK` (`Country`),
  CONSTRAINT `Province_CountryFK` FOREIGN KEY (`Country`) REFERENCES `tbcountries` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbraces` */

DROP TABLE IF EXISTS `tbraces`;

CREATE TABLE `tbraces` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

/*Table structure for table `tbresignationreasons` */

DROP TABLE IF EXISTS `tbresignationreasons`;

CREATE TABLE `tbresignationreasons` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

/*Table structure for table `tbrule_items` */

DROP TABLE IF EXISTS `tbrule_items`;

CREATE TABLE `tbrule_items` (
  `ID` varchar(100) NOT NULL,
  `rule` varchar(100) DEFAULT NULL,
  `page_name` varchar(500) DEFAULT NULL,
  `uri` varchar(250) DEFAULT NULL,
  `page_id` int(11) DEFAULT NULL,
  `seq` int(11) DEFAULT 0,
  PRIMARY KEY (`ID`),
  KEY `rule_master` (`rule`),
  KEY `page_master_fk` (`page_id`),
  CONSTRAINT `page_master_fk` FOREIGN KEY (`page_id`) REFERENCES `tbpage_masters` (`id`),
  CONSTRAINT `rule_master` FOREIGN KEY (`rule`) REFERENCES `tbrules` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbrules` */

DROP TABLE IF EXISTS `tbrules`;

CREATE TABLE `tbrules` (
  `ID` varchar(100) NOT NULL,
  `name` varchar(250) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbsalary_pay_types` */

DROP TABLE IF EXISTS `tbsalary_pay_types`;

CREATE TABLE `tbsalary_pay_types` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbsalary_types` */

DROP TABLE IF EXISTS `tbsalary_types`;

CREATE TABLE `tbsalary_types` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

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

/*Table structure for table `tbshiftdetails` */

DROP TABLE IF EXISTS `tbshiftdetails`;

CREATE TABLE `tbshiftdetails` (
  `id` varchar(100) NOT NULL,
  `shift` varchar(100) DEFAULT NULL,
  `weekday` int(1) DEFAULT 0,
  `timetable` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_shift` (`shift`),
  KEY `fk_timetable` (`timetable`),
  CONSTRAINT `fk_shift` FOREIGN KEY (`shift`) REFERENCES `tbshiftmanagements` (`id`),
  CONSTRAINT `fk_timetable` FOREIGN KEY (`timetable`) REFERENCES `tbtimetables` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbshiftmanagements` */

DROP TABLE IF EXISTS `tbshiftmanagements`;

CREATE TABLE `tbshiftmanagements` (
  `id` varchar(100) NOT NULL,
  `shiftname` varchar(500) DEFAULT NULL,
  `workingday` varchar(100) DEFAULT '012345',
  `status` varchar(100) DEFAULT 'ACTIVE',
  `company` varchar(100) DEFAULT NULL,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(100) DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `updated_by` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `fk_company` (`company`),
  CONSTRAINT `fk_company` FOREIGN KEY (`company`) REFERENCES `tbcompanies` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbtime_assigments` */

DROP TABLE IF EXISTS `tbtime_assigments`;

CREATE TABLE `tbtime_assigments` (
  `id` varchar(100) NOT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `timetable` varchar(100) DEFAULT NULL,
  `started_at` date DEFAULT NULL,
  `ended_at` date DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `assignment_employee` (`employee`),
  CONSTRAINT `assignment_employee` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbtimesheets` */

DROP TABLE IF EXISTS `tbtimesheets`;

CREATE TABLE `tbtimesheets` (
  `id` varchar(100) NOT NULL,
  `att_date` date DEFAULT NULL,
  `clock_in` time DEFAULT NULL,
  `clock_out` time DEFAULT NULL,
  `raw_in` time DEFAULT NULL,
  `raw_out` time DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `employee` varchar(100) DEFAULT NULL,
  `late_min` int(11) DEFAULT NULL,
  `early_min` int(11) DEFAULT NULL,
  `clock_status` varchar(500) DEFAULT NULL COMMENT 'clock state',
  PRIMARY KEY (`id`),
  KEY `timsheet_employee` (`employee`),
  CONSTRAINT `timsheet_employee` FOREIGN KEY (`employee`) REFERENCES `tbemployees` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbtimetables` */

DROP TABLE IF EXISTS `tbtimetables`;

CREATE TABLE `tbtimetables` (
  `id` varchar(100) NOT NULL,
  `name` varchar(500) DEFAULT NULL,
  `start_in` time DEFAULT NULL,
  `break_out` time DEFAULT NULL,
  `break_in` time DEFAULT NULL,
  `start_out` time DEFAULT NULL,
  `late_in` int(11) DEFAULT NULL COMMENT 'minute',
  `early_out` int(11) DEFAULT NULL COMMENT 'minute',
  `day_of_week` varchar(100) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  `late_at` time DEFAULT NULL,
  `early_out_at` time DEFAULT NULL,
  `working_hour_ratio` int(11) DEFAULT NULL,
  `company` varchar(100) DEFAULT 'C00001',
  PRIMARY KEY (`id`),
  KEY `fk_tt_company` (`company`),
  CONSTRAINT `fk_tt_company` FOREIGN KEY (`company`) REFERENCES `tbcompanies` (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbtransaction_types` */

DROP TABLE IF EXISTS `tbtransaction_types`;

CREATE TABLE `tbtransaction_types` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbworking_types` */

DROP TABLE IF EXISTS `tbworking_types`;

CREATE TABLE `tbworking_types` (
  `ID` varchar(100) NOT NULL,
  `Name` varchar(250) DEFAULT NULL,
  `NameEn` varchar(250) DEFAULT NULL,
  `Code` varchar(10) DEFAULT NULL,
  `Status` varchar(10) DEFAULT NULL,
  PRIMARY KEY (`ID`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `tbworkingperiods` */

DROP TABLE IF EXISTS `tbworkingperiods`;

CREATE TABLE `tbworkingperiods` (
  `id` varchar(100) NOT NULL,
  `company` varchar(100) DEFAULT NULL,
  `name` varchar(250) DEFAULT NULL,
  `started_at` date DEFAULT NULL,
  `ended_at` date DEFAULT NULL,
  `total` int(11) DEFAULT NULL,
  `working_hrs` int(11) DEFAULT 8,
  `created_at` datetime DEFAULT NULL,
  `created_by` varchar(100) DEFAULT NULL,
  `updated_at` datetime DEFAULT NULL,
  `updated_by` varchar(100) DEFAULT NULL,
  `status` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/* Procedure structure for procedure `calculateAttendance` */

/*!50003 DROP PROCEDURE IF EXISTS  `calculateAttendance` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `calculateAttendance`(
  IN ids LONGBLOB,
  IN creator varchar(100),
  in asofdate date,
  in company varchar(100)
  
)
BEGIN

  set @randid :=  MD5(RAND());
  set @asofdate := asofdate;
  set @creator  := creator;
  

	
  DROP TEMPORARY TABLE IF EXISTS temp_string;
  CREATE TEMPORARY TABLE temp_string(fpuser varchar(100)); 
  WHILE LOCATE(',',ids) > 1 DO
    INSERT INTO temp_string SELECT SUBSTRING_INDEX(ids,',',1);
    SET ids = REPLACE(ids, (SELECT LEFT(ids, LOCATE(',', ids))),'');
  END WHILE;
  INSERT INTO temp_string(fpuser) VALUES(ids);
  
  
  
  
  SELECT 
  employeecode, 
  employeename, 
  SUM(minwork) AS minwork, 
  SUM(late_in) AS late_in, 
  SUM(islate) AS total_late, 
  SUM(early_out) AS early_out, 
  SUM(isearlyout) AS total_early_out, 
  COUNT(att_date) AS totalworkdays, 
  totaldays, 
  total_hrs, 
  (
    SUM(minwork)-(
      SUM(late_in) + SUM(early_out)
    )
  )/ 60 AS totalworkhrs, 
  (
    totaldays - COUNT(att_date)
  ) AS totalmissdays, 
  (
    SELECT 
      COUNT(`leave_day`) * temp.working_hrs 
    FROM 
      `tbleavelogs` l 
    WHERE 
      `fp_user_id` = fp_user 
      AND l.status = 'WP'
  ) AS totalleavewp, 
  (
    SELECT 
      COUNT(`leave_day`) 
    FROM 
      `tbleavelogs` l 
    WHERE 
      `fp_user_id` = fp_user 
      AND l.status = 'WOP'
  ) AS totalleavewop, 
  (
    SELECT 
      COUNT(`leave_day`) 
    FROM 
      `tbleavelogs` l 
    WHERE 
      `fp_user_id` = fp_user
  ) AS totalleaves ,
  @randid as sessionid,
  creator as created_by,
  asofdate as data_asofdate
FROM 
  (
    SELECT 
      f.fp_user_id AS fp_user, 
      e.id AS employeecode, 
      e.name AS employeename, 
      
      /**/
      l.att_date, 
      WEEKDAY(l.att_date) AS dow, 
      ADDTIME(
        att_date, 
        MIN(att_time)
      ) AS date_in, 
      ADDTIME(
        att_date, 
        MAX(att_time)
      ) AS date_out, 
      CASE WHEN (
        TIMESTAMPDIFF(
          MINUTE, 
          ADDTIME(
            att_date, 
            MIN(att_time)
          ), 
          ADDTIME(
            att_date, 
            MAX(att_time)
          )
        ) - TIMESTAMPDIFF(
          MINUTE, 
          ADDTIME(
            att_date, 
            MIN(break_out)
          ), 
          ADDTIME(
            att_date, 
            MAX(break_in)
          )
        )
      ) < 0 THEN 0 ELSE (
        TIMESTAMPDIFF(
          MINUTE, 
          ADDTIME(
            att_date, 
            MIN(att_time)
          ), 
          ADDTIME(
            att_date, 
            MAX(att_time)
          )
        ) - TIMESTAMPDIFF(
          MINUTE, 
          ADDTIME(
            att_date, 
            MIN(break_out)
          ), 
          ADDTIME(
            att_date, 
            MAX(break_in)
          )
        )
      ) END AS minwork, 
      CASE WHEN MIN(
        CAST(
          ADDTIME(att_date, att_time) AS DATETIME
        )
      ) > CAST(
        ADDTIME(att_date, late_at) AS DATETIME
      ) THEN TIMESTAMPDIFF(
        MINUTE, 
        CAST(
          ADDTIME(att_date, start_in) AS DATETIME
        ), 
        MIN(
          CAST(
            ADDTIME(att_date, att_time) AS DATETIME
          )
        )
      ) - late_in ELSE 0 END AS late_in, 
      CASE WHEN MAX(
        CAST(
          ADDTIME(att_date, att_time) AS DATETIME
        )
      ) > CAST(
        ADDTIME(att_date, early_out_at) AS DATETIME
      ) THEN 0 ELSE (
        (
          TIMESTAMPDIFF(
            MINUTE, 
            CAST(
              ADDTIME(att_date, start_out) AS DATETIME
            ), 
            MAX(
              CAST(
                ADDTIME(att_date, att_time) AS DATETIME
              )
            )
          )-1
        ) *-1
      ) END AS early_out, 
      w.total AS totaldays, 
      working_hrs, 
      (w.total * working_hrs) AS total_hrs, 
      CASE WHEN MIN(
        CAST(
          ADDTIME(att_date, att_time) AS DATETIME
        )
      ) > CAST(
        ADDTIME(att_date, late_at) AS DATETIME
      ) THEN 1 ELSE 0 END AS islate, 
      CASE WHEN MAX(
        CAST(
          ADDTIME(att_date, att_time) AS DATETIME
        )
      ) > CAST(
        ADDTIME(att_date, early_out_at) AS DATETIME
      ) THEN 0 ELSE 1 END AS isearlyout 
    FROM 
      tbemployee_working_periods p 
      INNER JOIN tbworkingperiods w ON p.working_period = w.id 
      INNER JOIN tbfpusers f ON f.fp_user_id = p.fp_user_id 
      INNER JOIN tbemployees e ON e.id = f.employee 
      INNER JOIN tbtime_assigments ta ON e.id = ta.employee 
      INNER JOIN tbtimetables tt ON ta.timetable = tt.id 
      INNER JOIN tbattlogs l ON f.fp_user_id = l.fp_user_id 
    WHERE 
      w.company =company 
      AND w.status = 'ACTIVE' 
      AND e.company = company
      AND e.status = 'ACTIVE' 
      AND f.fp_user_id IN (SELECT TRIM(fpuser) FROM temp_string)
      AND l.att_date >= w.started_at 
      AND l.att_date <= w.ended_at 
    GROUP BY 
      l.att_date, 
      e.id, 
      e.name, 
      w.total, 
      working_hrs, 
      f.fp_user_id
  ) AS temp 
GROUP BY 
  employeecode, 
  employeename, 
  totaldays, 
  total_hrs;
   
  
  DROP TEMPORARY TABLE IF EXISTS temp_string;
  
  
END */$$
DELIMITER ;

/* Procedure structure for procedure `departmenttimesheetmonthly` */

/*!50003 DROP PROCEDURE IF EXISTS  `departmenttimesheetmonthly` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `departmenttimesheetmonthly`(
	IN date_from varchar(100),
	IN date_to varchar(100),
	in dept nvarchar(50)
	
)
BEGIN
	SELECT emp.id as employee, emp.name AS employee_name,
	dv.name AS division,
	s.name AS section,
	d.name AS department,
	l.fp_user_id,att_date,
	MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)) AS c_in,
	MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)) AS c_out,
	CASE 
		WHEN MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)) > CAST( ADDTIME(att_date,`late_at`) AS DATETIME)
		THEN 	
		TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,`start_in`) AS DATETIME) ,MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)))	
		ELSE 0	
		END AS late_in,

	CASE 
		WHEN MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)) > CAST( ADDTIME(att_date,`early_out_at`) AS DATETIME)
		THEN 	0
		ELSE 
		(TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,`start_out`) AS DATETIME) ,MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)))-1)	*-1
		END AS early_out,
	CASE  
		WHEN MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)) = MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME))
		THEN 0
		
		WHEN MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)) < CAST( ADDTIME(att_date,`break_out`) AS DATETIME) && MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)) > CAST( ADDTIME(att_date,`break_in`) AS DATETIME)
		THEN /*-60 whole day*/
		(TIMESTAMPDIFF(MINUTE,MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)), MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)))-60)
		
		WHEN MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)) < CAST( ADDTIME(att_date,`break_out`) AS DATETIME) && MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)) < CAST( ADDTIME(att_date,`break_in`) AS DATETIME)
		THEN /*AM*/
		
		TIMESTAMPDIFF(MINUTE,MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)), MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)))
		-TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,`break_out`) AS DATETIME),MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)))
		
		WHEN MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)) >= CAST( ADDTIME(att_date,`break_out`) AS DATETIME) && MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)) >= CAST( ADDTIME(att_date,`break_in`) AS DATETIME)
		THEN  /*PM*/	
		TIMESTAMPDIFF(MINUTE,MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)), MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)))
		
		/*999*/
		ELSE 
		TIMESTAMPDIFF(MINUTE,MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)), MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)))
		- TIMESTAMPDIFF(MINUTE,MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)),CAST( ADDTIME(att_date,`break_in`) AS DATETIME))
		
		END workmin
	FROM tbattlogs l
	INNER JOIN tbfpusers f ON l.fp_user_id = f.fp_user_id
	LEFT JOIN tbemployee_employments e ON f.employee = e.employee
	LEFT JOIN tbemployees emp ON emp.id = e.employee
	LEFT JOIN `tbdepartments` d ON d.id = e.department
	LEFT JOIN `tbdivisions` dv ON dv.id = e.division
	LEFT JOIN `tbsections` s ON s.id = e.section 
	LEFT JOIN `tbtime_assigments` ts ON ts.employee = e.employee
	LEFT JOIN `tbtimetables` tt ON tt.id = ts.timetable
	WHERE att_date between date_from and date_to AND e.department like dept 
	GROUP BY att_date,emp.id,emp.name,dv.name ,s.name,d.name,att_date,f.fp_user_id 
	ORDER BY emp.name,att_date ASC
	;

	END */$$
DELIMITER ;

/* Procedure structure for procedure `employeetimesheetmonthly` */

/*!50003 DROP PROCEDURE IF EXISTS  `employeetimesheetmonthly` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `employeetimesheetmonthly`(
	IN date_from DATE,
	IN date_to DATE,
	in _emp nvarchar(50)
	
)
BEGIN
	SELECT  emp.id AS employee, emp.name AS employee_name,
	dv.name AS division,
	s.name AS section,
	d.name AS department,
	l.fp_user_id,att_date,
	MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)) AS c_in,
	MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)) AS c_out,
	CASE 
		WHEN MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)) > CAST( ADDTIME(att_date,`late_at`) AS DATETIME)
		THEN 	
		TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,`start_in`) AS DATETIME) ,MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)))	
		ELSE 0	
		END AS late_in,

	CASE 
		WHEN MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)) > CAST( ADDTIME(att_date,`early_out_at`) AS DATETIME)
		THEN 	0
		ELSE 
		(TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,`start_out`) AS DATETIME) ,MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)))-1)	*-1
		END AS early_out,
	CASE  
		WHEN MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)) = MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME))
		THEN 0
		
		WHEN MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)) < CAST( ADDTIME(att_date,`break_out`) AS DATETIME) && MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)) > CAST( ADDTIME(att_date,`break_in`) AS DATETIME)
		THEN /*-60 whole day*/
		(TIMESTAMPDIFF(MINUTE,MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)), MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)))-60)
		
		WHEN MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)) < CAST( ADDTIME(att_date,`break_out`) AS DATETIME) && MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)) < CAST( ADDTIME(att_date,`break_in`) AS DATETIME)
		THEN /*AM*/
		
		TIMESTAMPDIFF(MINUTE,MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)), MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)))
		-TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,`break_out`) AS DATETIME),MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)))
		
		WHEN MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)) >= CAST( ADDTIME(att_date,`break_out`) AS DATETIME) && MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)) >= CAST( ADDTIME(att_date,`break_in`) AS DATETIME)
		THEN  /*PM*/	
		TIMESTAMPDIFF(MINUTE,MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)), MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)))
		
		/*999*/
		ELSE 
		TIMESTAMPDIFF(MINUTE,MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)), MAX(CAST( ADDTIME(att_date,att_time) AS DATETIME)))
		- TIMESTAMPDIFF(MINUTE,MIN(CAST( ADDTIME(att_date,att_time) AS DATETIME)),CAST( ADDTIME(att_date,`break_in`) AS DATETIME))
		
		END workmin
	FROM tbattlogs l
	INNER JOIN tbfpusers f ON l.fp_user_id = f.fp_user_id
	INNER JOIN tbemployee_employments e ON f.employee = e.employee
	INNER JOIN tbemployees emp ON emp.id = e.employee
	INNER JOIN `tbdepartments` d ON d.id = e.department
	LEFT JOIN `tbdivisions` dv ON dv.id = e.division
	LEFT JOIN `tbsections` s ON s.id = e.section 
	INNER JOIN `tbtime_assigments` ts ON ts.employee = e.employee
	INNER JOIN `tbtimetables` tt ON tt.id = ts.timetable
	WHERE e.employee= _emp and date(att_date) between date(date_from) and DATE(date_to) 
	GROUP BY att_date,emp.id,emp.name,dv.name ,s.name,d.name,att_date,f.fp_user_id 
	ORDER BY emp.name,att_date ASC
	;

	END */$$
DELIMITER ;

/* Procedure structure for procedure `getalltimesheetmonthly` */

/*!50003 DROP PROCEDURE IF EXISTS  `getalltimesheetmonthly` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `getalltimesheetmonthly`(
	IN date_from DATE,
	IN date_to DATE,
	in dept_id nvarchar(50)
	
)
BEGIN
	DECLARE xstart_work VARCHAR(50);	
	declare xstart_in varchar(50);
	declare xlate_in int(11);
	declare xstart_out VARCHAR(50);
	declare xearly_out int(11);
	select addtime(start_in,late_in*100),
	ADDTIME(start_out,early_out*100*-1),
	late_in,
	early_out,
	start_in into xstart_in,xstart_out,xlate_in,xearly_out,xstart_work from tbtimetables where id ='TT00001';
	
	
	
	SELECT /*t.id,t.employee,att_date,clock_in,clock_out, */
	
	t.id,e.code,e.id AS employee,e.name AS employee_name,ee.department,d.name AS department_name,ee.division,
	v.name AS division_name,ee.section,s.name AS section_name,
	t.clock_in,t.clock_out,t.raw_in,t.raw_out,t.remark,t.att_date,
	case when (TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,xstart_in) AS DATETIME) , CAST(CONCAT(att_date, ' ',clock_in ) AS DATETIME)) ) <=0 then 0 else
	(TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,xstart_in) AS DATETIME) , CAST(CONCAT(att_date, ' ',clock_in ) AS DATETIME)) ) end as late_in_min,
	case when
	(TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,xstart_out) AS DATETIME) , CAST(CONCAT(att_date, ' ',clock_out ) AS DATETIME))*-1) <=0 then 0 else
	(TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,xstart_out) AS DATETIME) , CAST(CONCAT(att_date, ' ',clock_out ) AS DATETIME))*-1) end as early_out_min,
	case when (TIMESTAMPDIFF(MINUTE,ADDTIME(att_date,clock_in), ADDTIME(att_date,clock_out))-60) <=0 then 0 else
	(TIMESTAMPDIFF(MINUTE,ADDTIME(att_date,clock_in), ADDTIME(att_date,clock_out))-60) end as workmin
	FROM tbtimesheets t 
	INNER JOIN tbemployees e ON t.employee = e.id
	INNER JOIN tbemployee_employments ee ON t.employee = ee.employee
	INNER JOIN tbdepartments d ON ee.department = d.id
	INNER JOIN tbdivisions v ON ee.division = v.id
	INNER JOIN tbsections s ON ee.section = s.id

	where (att_date BETWEEN date_from AND date_to ) and ee.department = dept_id
	ORDER BY att_date DESC;
	

	

	END */$$
DELIMITER ;

/* Procedure structure for procedure `getallworkingperiod` */

/*!50003 DROP PROCEDURE IF EXISTS  `getallworkingperiod` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `getallworkingperiod`(	
	IN company NVARCHAR(100)
)
BEGIN

select *
from tbworkingperiods e 
where e.status = 'ACTIVE' and e.company = company;

end */$$
DELIMITER ;

/* Procedure structure for procedure `getemployeebydepartment` */

/*!50003 DROP PROCEDURE IF EXISTS  `getemployeebydepartment` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `getemployeebydepartment`(	
	IN department NVARCHAR(100)
)
BEGIN

select e.id as employeecode,e.name as employeename,e.code as fp_user_id
,t.department ,d.name as departmentname 
,t.division,v.name as divisionname
,t.section ,s.name as sectionname
from tbemployees e 
inner join `tbemployee_employments` t on e.id  =  t.employee
INNER JOIN `tbdepartments` d ON  d.id =  t.department
INNER JOIN `tbdivisions` v ON  v.id =  t.division
INNER JOIN tbsections s ON  s.id =  t.section
where e.status = 'ACTIVE'
and t.department = department;

end */$$
DELIMITER ;

/* Procedure structure for procedure `getsummarytimesheetbydate` */

/*!50003 DROP PROCEDURE IF EXISTS  `getsummarytimesheetbydate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `getsummarytimesheetbydate`(
    IN date_from DATE, 
    IN date_to DATE, 
    IN dept_id NVARCHAR(50)
  )
BEGIN DECLARE xstart_work VARCHAR(50);
DECLARE xstart_in VARCHAR(50);
DECLARE xlate_in INT(11);
DECLARE xstart_out VARCHAR(50);
DECLARE xearly_out INT(11);
SELECT 
  ADDTIME(start_in, late_in * 100), 
  ADDTIME(start_out, early_out * 100 *-1), 
  late_in, 
  early_out, 
  start_in INTO xstart_in, 
  xstart_out, 
  xlate_in, 
  xearly_out, 
  xstart_work 
FROM 
  tbtimetables 
WHERE 
  id = 'TT00001';
SELECT 
  fp_user_id, 
  
  /*addtime(att_date,time_in) as date_in,ADDTIME(att_date,time_out) AS date_out ,*/
  SUM(
    TIMESTAMPDIFF(
      MINUTE, 
      ADDTIME(att_date, time_in), 
      ADDTIME(att_date, time_out)
    )
  ) AS mins, 
  SUM(
    TIMESTAMPDIFF(
      MINUTE, 
      ADDTIME(att_date, time_in), 
      ADDTIME(att_date, time_out)
    )
  )/(60) AS hours, 
  COUNT(att_date) AS days 
FROM 
  (
    SELECT 
      att_date, 
      MIN(att_time) AS time_in, 
      MAX(att_time) AS time_out, 
      fp_user_id 
    FROM 
      tbattlogs 
    WHERE 
      att_date >= date_from 
      AND att_date <= date_to 
    GROUP BY 
      att_date, 
      fp_user_id
  ) AS temp 
GROUP BY 
  fp_user_id;
END */$$
DELIMITER ;

/* Procedure structure for procedure `gettimesheetbydate` */

/*!50003 DROP PROCEDURE IF EXISTS  `gettimesheetbydate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `gettimesheetbydate`(
    in date_from date,
    in date_to date,
    in emp nvarchar(50)    
    )
BEGIN
		SELECT * FROM tbtimesheets 
		WHERE (att_date BETWEEN date_from AND date_to )
		AND employee = emp ORDER BY att_date DESC;
	END */$$
DELIMITER ;

/* Procedure structure for procedure `getusertimesheetbydate` */

/*!50003 DROP PROCEDURE IF EXISTS  `getusertimesheetbydate` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `getusertimesheetbydate`(
	IN date_from DATE,
	IN date_to DATE,
	in emp nvarchar(50),
	IN department NVARCHAR(50)
	
)
BEGIN
	DECLARE xstart_work VARCHAR(50);	
	declare xstart_in varchar(50);
	declare xlate_in int(11);
	declare xstart_out VARCHAR(50);
	declare xearly_out int(11);
	select addtime(start_in,late_in*100),
	ADDTIME(start_out,early_out*100*-1),
	late_in,
	early_out,
	start_in into xstart_in,xstart_out,xlate_in,xearly_out,xstart_work from tbtimetables where id ='TT00001';
	
	
	
	SELECT /*t.id,t.employee,att_date,clock_in,clock_out, */
	
	t.id,e.code,e.id AS employee,e.name AS employee_name,ee.department,d.name AS department_name,ee.division,
	v.name AS division_name,ee.section,s.name AS section_name,
	t.clock_in,t.clock_out,t.raw_in,t.raw_out,t.remark,t.att_date,
	case when (TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,xstart_in) AS DATETIME) , CAST(CONCAT(att_date, ' ',clock_in ) AS DATETIME)) ) <=0 then 0 else
	(TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,xstart_in) AS DATETIME) , CAST(CONCAT(att_date, ' ',clock_in ) AS DATETIME)) ) end as late_in_min,
	case when
	(TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,xstart_out) AS DATETIME) , CAST(CONCAT(att_date, ' ',clock_out ) AS DATETIME))*-1) <=0 then 0 else
	(TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,xstart_out) AS DATETIME) , CAST(CONCAT(att_date, ' ',clock_out ) AS DATETIME))*-1) end as early_out_min,
	case when (TIMESTAMPDIFF(MINUTE,ADDTIME(att_date,clock_in), ADDTIME(att_date,clock_out))-60) <=0 then 0 else
	(TIMESTAMPDIFF(MINUTE,ADDTIME(att_date,clock_in), ADDTIME(att_date,clock_out))-60) end as workmin
	FROM tbtimesheets t 
	left JOIN tbemployees e ON t.employee = e.id
	LEFT JOIN tbemployee_employments ee ON t.employee = ee.employee
	LEFT JOIN tbdepartments d ON ee.department = d.id
	LEFT JOIN tbdivisions v ON ee.division = v.id
	LEFT JOIN tbsections s ON ee.section = s.id

	where (att_date BETWEEN date_from AND date_to ) and ee.employee = emp and ee.department = department
	ORDER BY att_date DESC;
	

	

	END */$$
DELIMITER ;

/* Procedure structure for procedure `getusertimesheetmonthly` */

/*!50003 DROP PROCEDURE IF EXISTS  `getusertimesheetmonthly` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `getusertimesheetmonthly`(
	IN date_from DATE,
	IN date_to DATE,
	in emp nvarchar(50)
	
)
BEGIN
	DECLARE xstart_work VARCHAR(50);	
	declare xstart_in varchar(50);
	declare xlate_in int(11);
	declare xstart_out VARCHAR(50);
	declare xearly_out int(11);
	select addtime(start_in,late_in*100),
	ADDTIME(start_out,early_out*100*-1),
	late_in,
	early_out,
	start_in into xstart_in,xstart_out,xlate_in,xearly_out,xstart_work from tbtimetables where id ='TT00001';
	
	
	
	SELECT /*t.id,t.employee,att_date,clock_in,clock_out, */
	
	t.id,e.code,e.id AS employee,e.name AS employee_name,ee.department,d.name AS department_name,ee.division,
	v.name AS division_name,ee.section,s.name AS section_name,
	t.clock_in,t.clock_out,t.raw_in,t.raw_out,t.remark,t.att_date,
	case when (TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,xstart_in) AS DATETIME) , CAST(CONCAT(att_date, ' ',clock_in ) AS DATETIME)) ) <=0 then 0 else
	(TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,xstart_in) AS DATETIME) , CAST(CONCAT(att_date, ' ',clock_in ) AS DATETIME)) ) end as late_in_min,
	case when
	(TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,xstart_out) AS DATETIME) , CAST(CONCAT(att_date, ' ',clock_out ) AS DATETIME))*-1) <=0 then 0 else
	(TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,xstart_out) AS DATETIME) , CAST(CONCAT(att_date, ' ',clock_out ) AS DATETIME))*-1) end as early_out_min,
	case when (TIMESTAMPDIFF(MINUTE,ADDTIME(att_date,clock_in), ADDTIME(att_date,clock_out))-60) <=0 then 0 else
	(TIMESTAMPDIFF(MINUTE,ADDTIME(att_date,clock_in), ADDTIME(att_date,clock_out))-60) end as workmin
	FROM tbtimesheets t 
	INNER JOIN tbemployees e ON t.employee = e.id
	INNER JOIN tbemployee_employments ee ON t.employee = ee.employee
	INNER JOIN tbdepartments d ON ee.department = d.id
	INNER JOIN tbdivisions v ON ee.division = v.id
	INNER JOIN tbsections s ON ee.section = s.id

	where (att_date BETWEEN date_from AND date_to ) and ee.employee = emp
	ORDER BY att_date DESC;
	

	

	END */$$
DELIMITER ;

/* Procedure structure for procedure `SpEmployeeGetLeaveHistories` */

/*!50003 DROP PROCEDURE IF EXISTS  `SpEmployeeGetLeaveHistories` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `SpEmployeeGetLeaveHistories`( 
  IN employee VARCHAR(100),
  IN company VARCHAR(100)  
)
BEGIN

  SELECT e.name
	,l.*
	,d.id AS department,d.name AS department_name
	,v.id AS division ,v.name AS division_name
	,s.id AS section ,s.name AS section_name
	,lt.name AS leave_type_name
	
	FROM `tbleave_requests` l
	INNER JOIN tbemployees e ON l.`employee` = e.id 
	left JOIN `tbemployee_employments` em ON em.employee = e.id
	left JOIN `tbdepartments` d ON em.department  = d.id
	left JOIN `tbdivisions` v ON em.division  = v.id
	left JOIN `tbsections` s ON em.section  = s.id
	left JOIN `tbannual_leave_types` lt ON l.leave_type  = lt.id
	WHERE l.status !='DELETED'
	-- AND l.company = company
	AND l.employee = employee		
	ORDER BY l.datefrom DESC;
  
END */$$
DELIMITER ;

/* Procedure structure for procedure `SpEmployeeGetLeaveRequest` */

/*!50003 DROP PROCEDURE IF EXISTS  `SpEmployeeGetLeaveRequest` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `SpEmployeeGetLeaveRequest`( 
  IN employee VARCHAR(100),
  IN company VARCHAR(100)  
)
BEGIN

  SELECT e.name
	,l.*
	,d.id AS department,d.name AS department_name
	,v.id AS division ,v.name AS division_name
	,s.id AS section ,s.name AS section_name
	,lt.name AS leave_type_name
	
	FROM `tbleave_requests` l
	INNER JOIN tbemployees e ON l.`employee` = e.id 
	left JOIN `tbemployee_employments` em ON em.employee = e.id
	left JOIN `tbdepartments` d ON em.department  = d.id
	left JOIN `tbdivisions` v ON em.division  = v.id
	left JOIN `tbsections` s ON em.section  = s.id
	left JOIN `tbannual_leave_types` lt ON l.leave_type  = lt.id
	WHERE l.status  in ('ACTIVE') -- ,'S-APPROVED'
	-- AND l.company = company
	AND l.employee = employee		
	ORDER BY l.datefrom DESC;
  
END */$$
DELIMITER ;

/* Procedure structure for procedure `SpEmployeeGetLeaveSummary` */

/*!50003 DROP PROCEDURE IF EXISTS  `SpEmployeeGetLeaveSummary` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `SpEmployeeGetLeaveSummary`( 
  IN _employee VARCHAR(100)
    
)
BEGIN

	SELECT e.id AS employee, e.code AS fp_user_id,e.name AS employee_name,
	l.created_at,l.datefrom, l.dateto,l.total,l.leave_type,al.name AS leave_name,
	l.remark, YEAR(l.datefrom) AS period_year,
	hr.name AS hr_approval_name,
	sp.name AS sp_approval_name
	FROM `tbleave_requests` l
	INNER JOIN `tbemployees` e ON  e.id =l.employee 
	LEFT JOIN `tbemployees` hr ON  hr.id =l.`hr_approved_by` 
	LEFT JOIN `tbemployees` sp ON  sp.id =l.`approved_by` 
	left JOIN `tbannual_leave_types` al ON  al.id = l.`leave_type`
	left JOIN `tbemployee_working_periods` wp ON wp.fp_user_id = l.fp_user_id
	left JOIN `tbworkingperiods` w ON w.id = wp.`working_period`
	WHERE e.id = _employee
	AND YEAR(l.datefrom) = YEAR(w.started_at) AND l.status='SUCCESS'
	AND l.approved_by != '' AND l.hr_approved_by != ''
	ORDER BY created_at ASC;
  
END */$$
DELIMITER ;

/* Procedure structure for procedure `SpGetLeaveHistoryByEmpId` */

/*!50003 DROP PROCEDURE IF EXISTS  `SpGetLeaveHistoryByEmpId` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `SpGetLeaveHistoryByEmpId`( 
  IN employee varchar(100),
  in company varchar(100)  
)
BEGIN

  SELECT e.name
	,l.*
	,d.id AS department,d.name AS department_name
	,v.id AS division ,v.name AS division_name
	,s.id AS section ,s.name AS section_name
	,lt.name AS leave_type_name
	
	FROM `tbleave_requests` l
	INNER JOIN tbemployees e ON l.`employee` = e.id 
	left JOIN `tbemployee_employments` em ON em.employee = e.id
	left JOIN `tbdepartments` d ON em.department  = d.id
	left JOIN `tbdivisions` v ON em.division  = v.id
	left JOIN `tbsections` s ON em.section  = s.id
	left JOIN `tbannual_leave_types` lt ON l.leave_type  = lt.id
	WHERE l.status = 'SUCCESS' 
	-- and l.company = company
	AND l.employee = employee
	
	
	order by l.datefrom desc;
  
END */$$
DELIMITER ;

/* Procedure structure for procedure `SpGetLeaveRequestByEmpId` */

/*!50003 DROP PROCEDURE IF EXISTS  `SpGetLeaveRequestByEmpId` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `SpGetLeaveRequestByEmpId`( 
  IN employee varchar(100),
  in company varchar(100)  
)
BEGIN

  SELECT e.name
	,l.*
	,d.id AS department,d.name AS department_name
	,v.id AS division ,v.name AS division_name
	,s.id AS section ,s.name AS section_name
	,lt.name AS leave_type_name
	
	FROM `tbleave_requests` l
	INNER JOIN tbemployees e ON l.`employee` = e.id 
	left JOIN `tbemployee_employments` em ON em.employee = e.id
	left JOIN `tbdepartments` d ON em.department  = d.id
	left JOIN `tbdivisions` v ON em.division  = v.id
	left JOIN `tbsections` s ON em.section  = s.id
	left JOIN `tbannual_leave_types` lt ON l.leave_type  = lt.id
	WHERE l.status not in ('SUCCESS', 'DELETED' )
	-- and l.company = company
	AND l.employee = employee
	
	
	order by l.datefrom desc;
  
END */$$
DELIMITER ;

/* Procedure structure for procedure `SpHrGetEmployeeLeaveRequest` */

/*!50003 DROP PROCEDURE IF EXISTS  `SpHrGetEmployeeLeaveRequest` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `SpHrGetEmployeeLeaveRequest`( 
  IN _company VARCHAR(100)
)
BEGIN

	SELECT e.name
	,l.*
	,d.id AS department,d.name AS department_name
	,v.id AS division ,v.name AS division_name
	,s.id AS section ,s.name AS section_name
	,lt.name AS leave_type_name
	
	FROM `tbleave_requests` l
	INNER JOIN tbemployees e ON l.`employee` = e.id 
	left JOIN `tbemployee_employments` em ON em.employee = e.id
	left JOIN `tbdepartments` d ON em.department  = d.id
	left JOIN `tbdivisions` v ON em.division  = v.id
	left JOIN `tbsections` s ON em.section  = s.id
	left JOIN `tbannual_leave_types` lt ON l.leave_type  = lt.id
	WHERE l.status NOT IN ('SUCCESS','CANCELED','REJECTED','S-REJECTED','H-REJECTED','H-APPROVED')
	-- AND l.company = _company	
	ORDER BY l.datefrom DESC;
  
END */$$
DELIMITER ;

/* Procedure structure for procedure `SpHrGetEmployeeLeaveRequestApproved` */

/*!50003 DROP PROCEDURE IF EXISTS  `SpHrGetEmployeeLeaveRequestApproved` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `SpHrGetEmployeeLeaveRequestApproved`( 
  IN _company VARCHAR(100)
)
BEGIN

	SELECT e.name
	,l.*
	,d.id AS department,d.name AS department_name
	,v.id AS division ,v.name AS division_name
	,s.id AS section ,s.name AS section_name
	,lt.name AS leave_type_name
	
	FROM `tbleave_requests` l
	INNER JOIN tbemployees e ON l.`employee` = e.id 
	left JOIN `tbemployee_employments` em ON em.employee = e.id
	left JOIN `tbdepartments` d ON em.department  = d.id
	left JOIN `tbdivisions` v ON em.division  = v.id
	left JOIN `tbsections` s ON em.section  = s.id
	left JOIN `tbannual_leave_types` lt ON l.leave_type  = lt.id
	WHERE l.status IN ('SUCCESS','H-APPROVED','S-APPROVED')
	-- AND l.company = _company
	and (l.hr_approved_by !=NULL OR l.hr_approved_by !='') 
	ORDER BY l.datefrom DESC;
  
END */$$
DELIMITER ;

/* Procedure structure for procedure `SpHrGetEmployeeLeaveRequestRejected` */

/*!50003 DROP PROCEDURE IF EXISTS  `SpHrGetEmployeeLeaveRequestRejected` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `SpHrGetEmployeeLeaveRequestRejected`( 
  IN _company VARCHAR(100)
)
BEGIN

	SELECT e.name
	,l.*
	,d.id AS department,d.name AS department_name
	,v.id AS division ,v.name AS division_name
	,s.id AS section ,s.name AS section_name
	,lt.name AS leave_type_name
	
	FROM `tbleave_requests` l
	INNER JOIN tbemployees e ON l.`employee` = e.id 
	left JOIN `tbemployee_employments` em ON em.employee = e.id
	left JOIN `tbdepartments` d ON em.department  = d.id
	left JOIN `tbdivisions` v ON em.division  = v.id
	left JOIN `tbsections` s ON em.section  = s.id
	left JOIN `tbannual_leave_types` lt ON l.leave_type  = lt.id
	WHERE l.status IN ('H-REJECTED','S-REJECTED','REJECTED')
	-- AND l.company = _company
	and (l.hr_approved_by !=NULL OR l.hr_approved_by !='') 
	ORDER BY l.datefrom DESC;
  
END */$$
DELIMITER ;

/* Procedure structure for procedure `splitString` */

/*!50003 DROP PROCEDURE IF EXISTS  `splitString` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `splitString`(
  IN inputString text,
  IN delimiterChar CHAR(1)
)
BEGIN
  DROP TEMPORARY TABLE IF EXISTS temp_string;
  CREATE TEMPORARY TABLE temp_string(vals text); 
  WHILE LOCATE(delimiterChar,inputString) > 1 DO
    INSERT INTO temp_string SELECT SUBSTRING_INDEX(inputString,delimiterChar,1);
    SET inputString = REPLACE(inputString, (SELECT LEFT(inputString, LOCATE(delimiterChar, inputString))),'');
  END WHILE;
  INSERT INTO temp_string(vals) VALUES(inputString);
  SELECT TRIM(vals) FROM temp_string;
END */$$
DELIMITER ;

/* Procedure structure for procedure `SpSupervisorGetEmployeeLeaveRequest` */

/*!50003 DROP PROCEDURE IF EXISTS  `SpSupervisorGetEmployeeLeaveRequest` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `SpSupervisorGetEmployeeLeaveRequest`( 
  IN company varchar(100),
  in department varchar(100) ,
  IN division VARCHAR(100)  ,
  IN section VARCHAR(100)  ,
  IN levelid VARCHAR(100)  ,
  IN seq int   
)
BEGIN

	DROP TEMPORARY TABLE IF EXISTS temp_emp_level_0;
	CREATE TEMPORARY TABLE temp_emp_level_0(employee VARCHAR(100)); 

	INSERT INTO temp_emp_level_0(employee) SELECT e.employee FROM `tbemployee_employments` e
	INNER JOIN `tbpostions` p ON e.position = p.id
	INNER JOIN `tbemployee_levels` l ON p.level = l.id
	 WHERE e.department  =department
	 AND e.division = division
	 AND e.section = section
	 AND l.id !=levelid
	 AND l.seq > seq ;

  SELECT e.name
	,l.*
	,d.id AS department,d.name AS department_name
	,v.id AS division ,v.name AS division_name
	,s.id AS section ,s.name AS section_name
	,lt.name AS leave_type_name
	
	FROM `tbleave_requests` l
	INNER JOIN tbemployees e ON l.`employee` = e.id 
	INNER JOIN `tbemployee_employments` em ON em.employee = e.id
	INNER JOIN `tbdepartments` d ON em.department  = d.id
	left JOIN `tbdivisions` v ON em.division  = v.id
	LEFT JOIN `tbsections` s ON em.section  = s.id
	INNER JOIN `tbannual_leave_types` lt ON l.leave_type  = lt.id
	WHERE l.status in  ('ACTIVE','H-REJECTED','H-APPROVED') 
	and l.company = company
	AND l.employee in  (select TRIM(employee) from temp_emp_level_0)
	AND l.approved_by = ''
	
	order by l.datefrom desc;
	DROP TEMPORARY TABLE IF EXISTS temp_emp_level_0;
  
END */$$
DELIMITER ;

/* Procedure structure for procedure `SpSupervisorGetEmployeeLeaveRequestApproved` */

/*!50003 DROP PROCEDURE IF EXISTS  `SpSupervisorGetEmployeeLeaveRequestApproved` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `SpSupervisorGetEmployeeLeaveRequestApproved`( 
  IN company VARCHAR(100),
  IN department VARCHAR(100) ,
  IN division VARCHAR(100)  ,
  IN section VARCHAR(100)  ,
  IN levelid VARCHAR(100)  ,
  IN seq INT,
  IN p_employee VARCHAR(100)
)
BEGIN

	DROP TEMPORARY TABLE IF EXISTS temp_emp_level_1;
	CREATE TEMPORARY TABLE temp_emp_level_1(emp VARCHAR(100)); 

	INSERT INTO temp_emp_level_1(emp) SELECT e.employee FROM `tbemployee_employments` e
	INNER JOIN `tbpostions` p ON e.position = p.id
	INNER JOIN `tbemployee_levels` l ON p.level = l.id
	 WHERE e.department  =department
	 AND e.division = division
	 AND e.section = section
	 AND l.id !=levelid
	 AND l.seq > seq ;

  SELECT e.name
	,l.*
	,d.id AS department,d.name AS department_name
	,v.id AS division ,v.name AS division_name
	,s.id AS section ,s.name AS section_name
	,lt.name AS leave_type_name
	
	FROM `tbleave_requests` l
	INNER JOIN tbemployees e ON l.`employee` = e.id 
	left JOIN `tbemployee_employments` em ON em.employee = e.id
	left JOIN `tbdepartments` d ON em.department  = d.id
	left JOIN `tbdivisions` v ON em.division  = v.id
	left JOIN `tbsections` s ON em.section  = s.id
	left JOIN `tbannual_leave_types` lt ON l.leave_type  = lt.id
	WHERE l.status IN ('SUCCESS','S-APPROVED','H-APPROVED')
	AND l.company = company
	AND l.employee IN (SELECT TRIM(emp) FROM temp_emp_level_1 )
	AND l.approved_by = p_employee
	
	ORDER BY l.datefrom DESC;
	
	/*SELECT  TRIM(employee)  FROM temp_emp_level_1;*/
	DROP TEMPORARY TABLE IF EXISTS temp_emp_level_1;
  
END */$$
DELIMITER ;

/* Procedure structure for procedure `SpSupervisorGetEmployeeLeaveRequestRejected` */

/*!50003 DROP PROCEDURE IF EXISTS  `SpSupervisorGetEmployeeLeaveRequestRejected` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `SpSupervisorGetEmployeeLeaveRequestRejected`( 
  IN company VARCHAR(100),
  IN department VARCHAR(100) ,
  IN division VARCHAR(100)  ,
  IN section VARCHAR(100)  ,
  IN levelid VARCHAR(100)  ,
  IN seq INT,
  IN p_employee VARCHAR(100)
)
BEGIN

	DROP TEMPORARY TABLE IF EXISTS temp_emp_level_2;
	CREATE TEMPORARY TABLE temp_emp_level_2(emp VARCHAR(100)); 

	INSERT INTO temp_emp_level_2(emp) SELECT e.employee FROM `tbemployee_employments` e
	INNER JOIN `tbpostions` p ON e.position = p.id
	INNER JOIN `tbemployee_levels` l ON p.level = l.id
	 WHERE e.department  =department
	 AND e.division = division
	 AND e.section = section
	 AND l.id !=levelid
	 AND l.seq > seq ;

  SELECT e.name
	,l.*
	,d.id AS department,d.name AS department_name
	,v.id AS division ,v.name AS division_name
	,s.id AS section ,s.name AS section_name
	,lt.name AS leave_type_name
	
	FROM `tbleave_requests` l
	INNER JOIN tbemployees e ON l.`employee` = e.id 
	left JOIN `tbemployee_employments` em ON em.employee = e.id
	left JOIN `tbdepartments` d ON em.department  = d.id
	left JOIN `tbdivisions` v ON em.division  = v.id
	left JOIN `tbsections` s ON em.section  = s.id
	left JOIN `tbannual_leave_types` lt ON l.leave_type  = lt.id
	WHERE l.status IN ('REJECTED','S-REJECTED')
	-- AND l.company = company
	AND l.employee IN (SELECT TRIM(emp) FROM temp_emp_level_2 )
	AND l.approved_by = p_employee
	
	ORDER BY l.datefrom DESC;
	
	/*SELECT  TRIM(employee)  FROM temp_emp_level_2;*/
	DROP TEMPORARY TABLE IF EXISTS temp_emp_level_2;
  
END */$$
DELIMITER ;

/* Procedure structure for procedure `testaa` */

/*!50003 DROP PROCEDURE IF EXISTS  `testaa` */;

DELIMITER $$

/*!50003 CREATE DEFINER=`auth`@`%` PROCEDURE `testaa`()
BEGIN
	DECLARE xstart_work VARCHAR(50);	
	declare xstart_in varchar(50);
	declare xlate_in int(11);
	declare xstart_out VARCHAR(50);
	declare xearly_out int(11);
	select addtime(start_in,late_in*100),
	ADDTIME(start_out,early_out*100*-1),
	late_in,
	early_out,
	start_in into xstart_in,xstart_out,xlate_in,xearly_out,xstart_work from tbtimetables where id ='TT00001';
	
	
	
	SELECT id,employee,att_date,clock_in,clock_out, 
	case when (TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,xstart_in) AS DATETIME) , CAST(CONCAT(att_date, ' ',clock_in ) AS DATETIME)) ) <=0 then 0 else
	(TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,xstart_in) AS DATETIME) , CAST(CONCAT(att_date, ' ',clock_in ) AS DATETIME)) ) end as late_in_min,
	case when
	(TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,xstart_out) AS DATETIME) , CAST(CONCAT(att_date, ' ',clock_out ) AS DATETIME))*-1) <=0 then 0 else
	(TIMESTAMPDIFF(MINUTE,CAST( ADDTIME(att_date,xstart_out) AS DATETIME) , CAST(CONCAT(att_date, ' ',clock_out ) AS DATETIME))*-1) end as early_out_min,
	case when (TIMESTAMPDIFF(MINUTE,ADDTIME(att_date,clock_in), ADDTIME(att_date,clock_out))-60) <=0 then 0 else
	(TIMESTAMPDIFF(MINUTE,ADDTIME(att_date,clock_in), ADDTIME(att_date,clock_out))-60) end as workmin
FROM tbtimesheets ;
	

	

	END */$$
DELIMITER ;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
