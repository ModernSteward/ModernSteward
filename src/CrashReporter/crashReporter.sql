DROP TABLE IF EXISTS `errorReport`;
CREATE TABLE IF NOT EXISTS `errorReport` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `errormsg` varchar(255) NOT NULL,
  `stacktrace` text NOT NULL,
  PRIMARY KEY  (`id`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8;