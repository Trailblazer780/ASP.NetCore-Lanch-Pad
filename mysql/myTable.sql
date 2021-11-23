-- Host: localhost:3306
-- Generation Time: Sep 25, 2016 at 10:48 PM
-- Server version: 5.6.33
-- PHP Version: 5.6.20

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";
DROP TABLE IF EXISTS `tblUsers`;
DROP TABLE IF EXISTS `tblCategory`;
DROP TABLE IF EXISTS `tblLinks`;

CREATE TABLE IF NOT EXISTS `tblUsers` (
  `username` varchar(45) NOT NULL,
  `password` varchar(200) NOT NULL,
  `salt` varchar(200) NOT NULL,
  Primary Key (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `tblCategory` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `categoryName` varchar(50) NOT NULL,
  Primary Key (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

CREATE TABLE IF NOT EXISTS `tblLinks` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `linkName` varchar(50) NOT NULL,
  `linkURL` varchar(200) NOT NULL,
  `favourite` varchar(5) NOT NULL,
  `categoryID` int(10) NOT NULL,
  Primary Key (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

INSERT INTO `tblUsers` (`username`, `password`, `salt`) VALUES
('Ethan', 'J8KyEuRtSyN3eZuhwKpa9Ob/6ZGVT2ki1z4lxL3tuM0=', 'HAsTR1XIUynLxYCIwA2zdg==');

INSERT INTO `tblCategory` (`id`, `categoryName`) VALUES
('1', 'Technology'),
('2', 'School'),
('3', 'Play'),
('4', 'Social Media');

INSERT INTO `tblLinks` (`id`, `linkName`, `linkURL`, `favourite`, `categoryID`) VALUES
(1,	'Google',	'https://www.google.ca',	'true',	1),
(2,	'Facebook',	'https://www.facebook.com',	'false',	4),
(3,	'YouTube',	'https://www.youtube.com',	'true',	3),
(4,	'Reddit',	'https://www.reddit.com',	'false',	4),
(7,	'Twitter',	'https://www.twitter.com',	'false',	4),
(8,	'LinkedIn',	'https://www.linkedin.com',	'false',	4),
(9,	'Brightspace',	'https://nscconline.desire2learn.com/d2l/home',	'true',	2),
(14,	'NSCC',	'https://www.nscc.ca/',	'true',	2),
(16,	'Netflix',	'https://www.netflix.com/ca/',	'true',	3),
(17,	'Crave',	'https://www.crave.ca/en/',	'true',	3);


