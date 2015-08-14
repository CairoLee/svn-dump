<?php
	require_once FRAMEWORK_LIB_ABS . 'Exception/BaseException.class.php';

	class UserException extends BaseException {
		
		public function __construct($Message, $Code = 0) {
			parent::__construct($Message, $Code);
		}


		public function __toString() {
			parent::setBaseException(__CLASS__);
			
			return (string)parent::__toString();
		}

	}

?>