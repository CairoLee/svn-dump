<?php
	require_once FRAMEWORK_LIB_ABS . 'Paging/AbstractPage.class.php';

	class IndexPage extends AbstractPage {
		protected $template = 'index';


		public function __construct() {
			parent::__construct();
		}


		public function loadData() {
			parent::loadData();
		}


		public function show() {
			parent::show();
		}
	}

?>