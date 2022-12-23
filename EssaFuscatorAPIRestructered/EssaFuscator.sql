/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

# ------------------------------------------------------------
# SCHEMA DUMP FOR TABLE: downloadlinks
# ------------------------------------------------------------

CREATE TABLE IF NOT EXISTS `downloadlinks` (
  `userid` mediumtext DEFAULT NULL,
  `userhash` mediumtext DEFAULT NULL,
  `realname` mediumtext DEFAULT NULL,
  `epoch` bigint(20) DEFAULT NULL,
  `timesopened` smallint(6) DEFAULT NULL
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb3;

# ------------------------------------------------------------
# SCHEMA DUMP FOR TABLE: keys
# ------------------------------------------------------------

CREATE TABLE IF NOT EXISTS `keys` (
  `sha512` longtext DEFAULT NULL,
  `user_id` char(50) DEFAULT NULL,
  `datecreated` char(100) DEFAULT NULL
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb4;

# ------------------------------------------------------------
# SCHEMA DUMP FOR TABLE: owners
# ------------------------------------------------------------

CREATE TABLE IF NOT EXISTS `owners` (
  `script_id` tinytext NOT NULL,
  `user_id` longtext NOT NULL,
  `date` text NOT NULL,
  `epoch` bigint(20) DEFAULT 69
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb3;

# ------------------------------------------------------------
# SCHEMA DUMP FOR TABLE: premium
# ------------------------------------------------------------

CREATE TABLE IF NOT EXISTS `premium` (
  `userid` text DEFAULT NULL,
  `apikey` text DEFAULT NULL,
  `createdepoch` text DEFAULT NULL,
  `latestrenewal` text DEFAULT NULL,
  `warningnum` tinyint(4) DEFAULT 0,
  `notes` text DEFAULT 'none',
  `admingiver` text DEFAULT NULL,
  `email` text DEFAULT 'none@efx.fyi',
  `disabled` tinyint(4) DEFAULT 0
) ENGINE = InnoDB DEFAULT CHARSET = utf8mb3;
