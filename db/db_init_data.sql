CREATE DATABASE  `hrm_project`;

USE `hrm_project`;

insert  into `auth_users`(`ID`,`username`,`password`,`employee`,`status`,`role`,`rule`,`isChangePwd`) values 
('U0001','admin','o98hokyPpI+reQU0V/pkfg==','admin','ACTIVE','ROLE_SUPERUSERS','RU00001',0);

insert  into `numbercontrol`(`code`,`company`,`number`,`remark`,`strlength`) values 
('AL','C00001',1,'master allowance types','8'),
('AT','C00001',1,'Raw Finger Scan Attendance Log','8'),
('B','C00001',1,'master banks info','8'),
('BG','C00001',1,'master blood groups','8'),
('C','C00001',1,'master countries','8'),
('CM','C00001',1,'master company info','8'),
('CT','C00001',1,'master contract types','8'),
('CX','C00001',1,'card mapping','8'),
('CY','C00001',1,'master currencies','8'),
('D','C00001',1,'master departments','8'),
('DG','C00001',1,'master education degrees','8'),
('DI','C00001',1,'master distritcts','8'),
('DV','C00001',1,'master divisions','8'),
('E','C00001',1,'employee info','8'),
('EA','C00001',1,'employee allowance','8'),
('EB','C00001',1,'employee probations info','8'),
('EC','C00001',1,'employee contacts','8'),
('ECA','C00001',1,'master employee categories','8'),
('ECF','C00001',1,'employee classifications','8'),
('EE','C00001',1,'employee educations','8'),
('EFC','C00001',1,'employee family contact','8'),
('EG','C00001',1,'master employee groups','8'),
('EHS','C00001',1,'employee heath histories','8'),
('EI','C00001',1,'employee Insurances','8'),
('EL','C00001',1,'master employee levels','8'),
('ELS','C00001',1,'employee leave settings','8'),
('EM','C00001',1,'employee employments','8'),
('EP','C00001',1,'master employee types','8'),
('ES','C00001',1,'employee salary setting','8'),
('ESH','C00001',1,'shift detail','8'),
('ET','C00001',1,'employee contract info','8'),
('ETS','C00001',1,'employee transactions','8'),
('EWP','C00001',1,'employees working period','8'),
('F','C00001',1,'File Upload','8'),
('FM','C00001',1,'Fingerprint Machine','8'),
('FU','C00001',1,'Fingerprint users','8'),
('FX','C00001',1,'Fingerprint mapping','8'),
('HS','C00001',1,'Holiday Setting','8'),
('I','C00001',1,'master education institutions','8'),
('IDN','C00001',1,'employee identity card and passport','8'),
('IDT','C00001',1,'master identity types','8'),
('LL','C00001',1,'leave log','8'),
('LP','C00001',1,'master leave types','8'),
('LR','C00001',1,'Leave Request','8'),
('MR','C00001',1,'master marital status','8'),
('N','C00001',1,'master nationalities','8'),
('OG','C00001',1,'Organization Chart','8'),
('OR','C00001',1,'OT Request','8'),
('OT','C00001',1,'OT Table','8'),
('P','C00001',1,'master positions','8'),
('PM','C00001',1,'fingerprint mapping','8'),
('PR','C00001',1,'master provinces','8'),
('PU','C00001',1,'Page master items','8'),
('R','C00001',1,'master races','8'),
('RI','C00001',1,'Rule items','8'),
('RP','C00001',1,'master resignation reason types','8'),
('RU','C00001',1,'RULES','8'),
('S','C00001',1,'master sections','8'),
('SA','C00001',1,'master salary types','8'),
('SHD','C00001',1,'shift detail','8'),
('SHF','C00001',1,'shift management','8'),
('ST','C00001',1,'master salary pay types','8'),
('TP','C00001',1,'master transaction type','8'),
('TS','C00001',1,'timesheet','8'),
('TT','C00001',1,'Time table','8'),
('UE','C00001',1,'Users','8'),
('UO','C00001',1,'User Rule Mapping','8'),
('UR','C00001',1,'User Role Mappping','8'),
('WA','C00001',1,'Time Assigment','8'),
('WKP','C00001',1,'working period ','8'),
('WP','C00001',1,'master working types','8');

insert  into `tbcompanies`(`ID`,`name`,`nameEn`,`code`,`homebranch`,`controller`,`status`,`address`) values 
('C00001','Sitthi Logistic Lao Co., Ltd....','Sitthi Logistic Lao Co., Ltd.','STL','C00001','LA','ACTIVE','ນະຄອນຫລວງວຽງຈັນ ນະຄອນຫລວງວຽງຈັນຫ');

insert  into `tbcountries`(`ID`,`Name`,`NameEn`,`Code`,`Status`) values 
('C','ເລືອກ',NULL,NULL,'ACTIVE'),
('C00001','ລາວ','LAO','LAO','ACTIVE');

insert  into `tbemployees`(`id`,`code`,`name`,`nameEn`,`dob`,`gender`,`blood_group`,`nationality`,`race`,`id_card`,`id_card_expiry_date`,`id_card_issued_by`,`passport_no`,`passport_expiry_date`,`passport_issued_by`,`address`,`province`,`district`,`country`,`status`,`marital_status`,`created_by`,`created_at`,`updated_by`,`updated_at`,`avatar`,`company`) values 
('admin','1103','admin','admin','2021-10-31','M','BG','N','R',NULL,NULL,NULL,NULL,NULL,NULL,NULL,'PR','DI','C','ACTIVE','MR','admin','2021-08-29','admin','2021-08-29','storage\\avatar\\admin.jpg','C00001');

insert  into `tbroles`(`ID`,`name`,`nameEn`,`code`,`status`) values 
('ROLE_ADMINISTRATORS','ROLE_ADMINISTRATOR','ADMINISTRATOR','ADMINISTRA','ACTIVE'),
('ROLE_HR','ROLE_HR','HR','HR','ACTIVE'),
('ROLE_IT','ROLE_IT','IT','IT','ACTIVE'),
('ROLE_MANAGERS','ROLE_MANAGER','MANAGER','MANAGERS','ACTIVE'),
('ROLE_SUPERUSERS','ROLE_SUPER USER','SUPER USER','SUPERUSERS','ACTIVE'),
('ROLE_SUPERVISORS','ROLE_SUPERVISOR','SUPERVISOR','SUPERVISOR','ACTIVE'),
('ROLE_USERS','ROLE_USER','USER','USERS','ACTIVE');