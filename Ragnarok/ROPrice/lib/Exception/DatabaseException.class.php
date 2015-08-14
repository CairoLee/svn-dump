<?php
	require_once FRAMEWORK_LIB_ABS . 'Exception/BaseException.class.php';

	class DatabaseException extends BaseException {
		protected $lastQuery;
		
		public function __construct($Message, $Code = 0, $query) {
			parent::__construct($Message, $Code);

			$this->lastQuery = $query;
		}


		public function __toString() {
			parent::setBaseException(__CLASS__);
			
			return (string)parent::__toString();
		}

	}

?>