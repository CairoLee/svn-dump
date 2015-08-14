<?php

	abstract class DatabaseObject {
		public $ID = null;
		public $autoUpdate = false;

		protected $_Params = array();
		protected $_DBName = '';
		
		public function __construct(array $row = array()) {
			if (count($row) == 0) {
				return;
			}

			$this->loadFromRow($row);
		}

		public function __destruct() {
			if ($this->autoUpdate == true) {
				$this->updateDatabase();
			}
		}

		public function __get($name) {
			if ($this->hasProperty($name)) {
				return $this->$name;
			}

			throw new SystemException("Property " . $name . " not found");
		}

		public function __set($name, $value) {
			if ($this->hasProperty($name)) {
				$this->$name = $value;
				return $this->$name;
			}

			throw new SystemException("Property " . $name . " not found");
		}


		protected function hasProperty($name) {
			// Native prop
			if (property_exists($this, $name)) {
				return true;
			}

			// Array
			if (isset($this->_Params[$name]) || in_array($name, $this->_Params)) {
				return true;
			}

			return false;
		}


		protected function loadFromRow($row) {
			foreach ($this->_Params as $key => $propertie) {
				if (isset($row[$key]) == true) {
					$this->{$propertie} = $row[$key];
				}
			}
		}

		public function updateDatabase($debug = false) {
			$keys = array();
			$values = array();
			$query = '';

			if ($this->ID == null) {
				foreach ($this->_Params as $key => $propertie) {
					if ($this->{$propertie} != null) {
						$keys[] = '`' . $key . '`';
						$values[] = "'" . escapeString($this->{$propertie}) . "'";
					}
				}

				$query = "INSERT INTO `" . $this->getDBName() . "` (" . implode(', ', $keys) . ") VALUES (" . implode(', ', $values) . ")";
				Framework::getDb()->query($query);
				if (($lastID = Framework::getDb()->getLastID()) != 0) {
					$this->ID = $lastID;
				}
			} else {
				foreach ($this->_Params as $key => $propertie) {
					if ($key != 'id') {
						$values[] = "`" . $key . "` = '" . escapeString($this->{$propertie}) . "'";
					}
				}
				
				$query = "UPDATE `" . $this->getDBName() . "` SET " . implode(', ', $values) . " WHERE `id` = '" . escapeString($this->ID) . "'";
				
				if ($debug == true) {
					echo '<pre>';
					//print_r($this);
					echo '<strong>Query</strong>: '. $query . '<br />';
					echo '</pre>';
				}
				Framework::getDb()->query($query);
			}

			return true;
		}


		public function getParams() {
			return $this->_Params;
		}

		public function getDBName() {
			return $this->_DBName;
		}

	}

?>