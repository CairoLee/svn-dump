<?php
	require_once FRAMEWORK_LIB_ABS . 'Paging/AbstractPage.class.php';
	require_once FRAMEWORK_LIB_ABS . 'System/RoItem.class.php';

	class AjaxSearchPage extends AbstractPage {
		protected $template = 'ajax_search';
		
		private $data = null;


		public function __construct() {
			parent::__construct();
		}


		public function loadData() {
			parent::loadData();

			$items = RoItem::getObjects(array('i.online' => '1'), array('to' => 10));
			$this->data = json_encode($items);
		}


		public function show() {
			Framework::getTpl()->assign('data', $this->data);

			header('Content-type: application/json');
			parent::show();
		}
	}

?>