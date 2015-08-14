<?php
	require_once FRAMEWORK_LIB_ABS . 'System/DatabaseObject.class.php';

	class RoVender extends DatabaseObject {
		protected $_DBName = 'bot_vender';


		public function __construct(array $row) {
			$this->_Params = array(
				'char_id' => 'ID',
				'name' => 'Name',
				'shopname' => 'Shopname',

				'name_url' => 'NameUrl'
			);

			parent::__construct($row);

			$this->NameUrl = RoItem::cleanName($this->Name);
		}


		public function updateDatabase($debug = false) {
			
		}


		public function __toString() {
			return '[' . $this->ID . '] ' . $this->name;
		}

	}

?>