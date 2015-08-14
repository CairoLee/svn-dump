<?php
	require_once FRAMEWORK_LIB_ABS . 'Exception/SystemException.class.php';
	require_once FRAMEWORK_LIB_ABS . 'Exception/UserException.class.php';
	require_once FRAMEWORK_LIB_ABS . 'Exception/InputException.class.php';
	require_once FRAMEWORK_LIB_ABS . 'Util.class.php';

	class Framework {
		private static $dbObj = null;
		private static $tplObj = null;

		private static $activePage = 'index';


		public function __construct() {
		}

		public function __destruct() {
			
		}


		public static function loadDb($host, $user, $pass, $db = '') {
			require_once 'Mysql.class.php';
			self::$dbObj = new Mysql($host, $user, $pass, $db);
		}

		public static function loadTpl($baseDir) {
			require_once FRAMEWORK_LIB_ABS . 'Smarty/Smarty.class.php';
			self::$tplObj = new Smarty();

			self::getTpl()->disableSecurity();
			self::getTpl()->template_dir = $baseDir;
			self::getTpl()->config_dir = $baseDir . 'config/';
			self::getTpl()->cache_dir = $baseDir . 'cache/';
			self::getTpl()->compile_dir = $baseDir . 'compiled/';

			self::getTpl()->assign('FRAMEWORK_DIR', FRAMEWORK_DIR);
			self::getTpl()->assign('FRAMEWORK_LIB', FRAMEWORK_LIB);
			self::getTpl()->assign('FRAMEWORK_MODUL', FRAMEWORK_MODUL);
			self::getTpl()->assign('FRAMEWORK_TPL', FRAMEWORK_TPL);
		}

		public static function loadOthers() {
			// active page
			self::FetchActivePage();
		}


		private static function FetchActivePage() {
			self::$activePage = 'index';
			if (isset($_REQUEST['p']) == true) {
				$p = trim($_REQUEST['p']);
				if (empty($p) == false) {
					if (preg_match("/^[a-z_]+$/", $p) == false) {
						die('die, cheater!');
					} else if (file_exists($tmp_path = self::BuildModulPath($p)) == false) {
						die('Modul not found: ' . $tmp_path);
					}
				}

				self::$activePage = $p;
			}

			self::countModulHits();
		}


		public static function BuildModulPath($page = null) {
			if ($page == null) {
				$page = self::$activePage;
			}

			return 'modul/' . $page . '.page.php';
		}

		public static function BuildModulClass($page = null) {
			if ($page == null) {
				$page = self::$activePage;
			}

			$className = '';
			$parts = explode('_', $page);
			foreach ($parts as $part) {
				$className .= ucfirst(strtolower($part));
			}
			return $className . 'Page';
		}
		

		public static function removeCookie($cookie) {
			Util::debugLog('removeCookie(): ' . $cookie);
			if (isset($_COOKIE[$cookie]) == false) {
				return true;
			}

			return setcookie($cookie, '', time() - 3600, '/');
		}

		public static function removeCookies() {
		}


		public static function setCookies($sheep, $hash) {
		}

		public static function setCookie($cookie, $value, $validity) {
			Util::debugLog('setCookie(): ' . $cookie);
			if (isset($_COOKIE[$cookie]) == false || $_COOKIE[$cookie] !== $value) {
				// Set cookie with new value
				$v = time() + $validity;

				Util::debugLog('setCookie(): set new value (' . $value . ' @ ' . $v . ' [now = ' . time() . ']); issset(' . $cookie . ') = ' . isset($_COOKIE[$cookie]));
				return setcookie($cookie, $value, $v, '/');
			}

			Util::debugLog('setCookie(): nothing changed');
			// Cookie has already $value as value
			return true;
		}


		private static function countModulHits() {
			$page = $_SERVER['REQUEST_URI'];
			$ip = self::getCurrentIP();
			if (self::getDb()->getFirstRow("SELECT * FROM page_hits WHERE ip = '" . $ip . "' AND page = '" . $page . "'")) {
				return;
			}
			self::getDb()->query("
				INSERT INTO page_hits 
					(page, ip, hits, added) 
				VALUES 
					('" . esc($page) . "', '" . $ip . "', '1', NOW())
				ON 
					DUPLICATE KEY
				UPDATE
					hits = hits + 1
			");
		}


		public static function getDb() {
			return self::$dbObj;
		}

		public static function getTpl() {
			return self::$tplObj;
		}


		public static function getActivePage() {
			return self::$activePage;
		}

		public static function setActivePage($page) {
			self::$activePage = $page;
		}


		public static function getCurrentIP() {
			return $_SERVER['REMOTE_ADDR'];
		}

	}

?>