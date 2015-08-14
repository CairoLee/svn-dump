CREATE TABLE IF NOT EXISTS `login_reg_global` (
  `account_id` int(11) unsigned NOT NULL default '0',
  `str` varchar(255) NOT NULL default '',
  `value` varchar(255) NOT NULL default '0',
  PRIMARY KEY  (`str`,`account_id`),
  KEY `account_id` (`account_id`)
) ENGINE=MyISAM;

CREATE TABLE IF NOT EXISTS `login_reg` (
  `account_id` int(11) unsigned NOT NULL default '0',
  `str` varchar(255) NOT NULL default '',
  `value` varchar(255) NOT NULL default '0',
  PRIMARY KEY  (`str`,`account_id`),
  KEY `account_id` (`account_id`)
) ENGINE=MyISAM;

CREATE TABLE IF NOT EXISTS `char_reg` (
  `char_id` int(11) unsigned NOT NULL default '0',
  `str` varchar(255) NOT NULL default '',
  `value` varchar(255) NOT NULL default '0',
  PRIMARY KEY  (`char_id`,`str`),
  KEY `char_id` (`char_id`)
) ENGINE=MyISAM;

INSERT INTO `login_reg_global` SELECT `g`.`account_id`, `g`.`str`, `g`.`value` FROM `global_reg_value` AS `g` WHERE `g`.`type`=1;
INSERT INTO `login_reg` SELECT `g`.`account_id`, `g`.`str`, `g`.`value` FROM `global_reg_value` AS `g` WHERE `g`.`type`=2;
INSERT INTO `char_reg` SELECT `g`.`char_id`, `g`.`str`, `g`.`value` FROM `global_reg_value` AS `g` WHERE `g`.`type`=3;

DROP TABLE `global_reg_value`;