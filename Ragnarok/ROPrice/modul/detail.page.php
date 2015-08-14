<?php
	require_once FRAMEWORK_LIB_ABS . 'Paging/AbstractPage.class.php';
	require_once FRAMEWORK_LIB_ABS . 'System/RoItem.class.php';

	class DetailPage extends AbstractPage {
		protected $template = 'detail';
		
		private $item;
		private $items;


		public function __construct() {
			$id = Util::getRequest('id');
			if ($id == null || intval($id) != $id) {
				Util::redirect('?missing_id');
			}

			// Hash auslesen
			$results = RoItem::getObjects(array('i.id' => $id), array('to' => 1), "i.online ASC, i.item_id ASC, i.price_one ASC");
			if ($results == null || is_array($results) == false || count($results) == 0) {
				Util::redirect('?hash_not_found');
			}

			$this->item = current($results);
			$this->item->loadHits();
			
			parent::__construct();
		}


		public function loadData() {
			// Items auslesen
			$this->items = RoItem::getObjects(array('i.hash' => $this->item->Hash), null, "i.online ASC, i.item_id ASC, i.price_one ASC");

			parent::loadData();
		}


		public function show() {
			Framework::getTpl()->assign(array(
				'headerTitle' => $this->item->ItemID . ' ' . $this->item->Name,
				'item' => $this->item,
				'items' => $this->items
			));

			parent::show();
		}
	}

?>