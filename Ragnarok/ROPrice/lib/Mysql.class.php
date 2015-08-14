<?php
	require_once FRAMEWORK_LIB_ABS . 'Exception/DatabaseException.class.php';

	class Mysql {
		private $link;
		private $lastQuery;
		private $lastQueryString;

		public function __construct($host, $user, $pass, $db = '') {
			$this->link = @mysql_connect($host, $user, $pass);
			if (is_resource($this->link) == false) {
				throw new SystemException('failed to connect to MySQL Server');
			}

			if (empty($db) == false) {
				$this->selectDb($db);
			}

			$this->lastQueryString = "";
		}


		public function selectDb($db) {
			mysql_select_db($db, $this->link);
		}


		public function query($query) {
			$this->lastQueryString = $query;
			$this->lastQuery = mysql_query($query, $this->link);
			if ($this->lastQuery == false) {
				throw new DatabaseException(mysql_error(), mysql_errno(), $query);
			}

			return $this->lastQuery;
		}

		public function fetch($res = null) {
			if ($res === null) {
				$res = $this->lastQuery;
			}
			if ($res === null) {
				throw new DatabaseException('need a valid query resource', 0, $this->lastQueryString);
			}

			$row = mysql_fetch_array($res, MYSQL_ASSOC);
			if (empty($row) == true) {
				return null;
			}

			return $row;
		}


		public function getFirstRow($query) {
			$result = $this->query($query);
			if ($result === null) {
				return null;
			}

			$row = $this->fetch($result);
			if (empty($row) == false) {
				return $row;
			}
			
			return null;
		}

		public function fetchAll($query) {
			$result = $this->query($query);
			if ($result === null) {
				return null;
			}

			$rows = array();
			while (($row = $this->fetch($result))) {
				$rows[] = $row;
			}

			return $rows;
		}


		public function getLastID() {
			$row = $this->getFirstRow("SELECT LAST_INSERT_ID() AS id");
			return $row['id'];
		}



		public function getLink() {
			return $this->link;
		}

	}

?>