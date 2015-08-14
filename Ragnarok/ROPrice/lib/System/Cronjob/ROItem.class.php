<?php

	class ROItem {
		const SPLITTER = "##||##";
		const TABLE = "bot_vender_item";
		const TABLE_PRICE = "item_db_price";

		private $hash = null;

		public $venderID;
		public $id;
		public $name;
		public $price;
		public $price_one;
		public $amount;
		public $refine;
		public $slot0;
		public $slot1;
		public $slot2;
		public $slot3;


		public function __construct($venderID, array $data) {
			// All parts are base64 encoded
			foreach ($data as &$info) {
				$info = base64_decode($info);
			}

			$this->venderID = $venderID;
			$this->import($data);
			//$this->updateAvg();
		}


		public static function cronjob() {
			$query = "UPDATE `" . self::TABLE . "` SET online = 0 WHERE online = 1";
			Framework::getDb()->query($query);

			// Move items to the archiv by an seen-date older than 4 weeks
			// Edit: Nope
			/*
			$moveDate = esc(date('Y-m-d', time() - (60 * 60 * 24 * 30)));
			$query = "INSERT INTO vender_item_achiv (SELECT * FROM vender_item WHERE seen <= '" . $moveDate . "')";
			Framework::getDb()->query($query);
			*/
		}


		public function save($venderID) {
			// Add item to vender items table
			$query = "
				INSERT INTO `" . self::TABLE . "` 
					(id, hash, vender_id, item_id, name, price, price_one, amount, refine, slot0, slot1, slot2, slot3, seen, online)
				VALUES
					(NULL, '" . esc($this->getHash()) . "', '" . esc($venderID) . "', '" . esc($this->id) . "', '" . esc($this->name) . "', '" . esc($this->price) . "', '" . esc($this->price_one) . "', '" . esc($this->amount) . "', '" . esc($this->refine) . "', '" . esc($this->slot0) . "', '" . esc($this->slot1) . "', '" . esc($this->slot2) . "', '" . esc($this->slot3) . "', NOW(), '1')
			";
			Framework::getDb()->query($query);
		}


		private function import(array $data) {
			$this->id = intval($data[0]);
			$this->name = $data[1];
			$this->price = intval($data[2]);
			$this->amount = intval($data[3]);
			$this->refine = intval($data[4]);
			$this->slot0 = intval($data[5]);
			$this->slot1 = intval($data[6]);
			$this->slot2 = intval($data[7]);
			$this->slot3 = intval($data[8]);
			
			if ($this->amount > 1) {
				$this->price_one = floor($this->price / $this->amount);
			} else {
				$this->price_one = $this->price;
			}
		}

		private function updateAvg() {
			// Check if the item exists (item_id, refine, slots)
			$query = "SELECT * FROM " . self::TABLE_PRICE . " WHERE item_hash = '" . esc($this->getHash()) . "'";
			$row = Framework::getDb()->getFirstRow($query);
			if ($row != null) {
				// Found, update price sum (single price)
				$query = "UPDATE " . self::TABLE_PRICE . " SET price_sum = price_sum + " . esc($this->price_one) . ", `count` = `count` + 1 WHERE item_hash = '" . esc($this->getHash()) . "'";
				Framework::getDb()->query($query);
			} else {
				// Add new
				$query = "
						INSERT INTO `" . self::TABLE_PRICE . "` 
							(`item_hash`, `item_id`, `price_sum`, `count`, `last_update`) 
						VALUES 
							('" . esc($this->getHash()) . "',  '" . esc($this->id) . "', '" . esc($this->price_one) . "', '1', NOW())";
				Framework::getDb()->query($query);
			}

		}


		public function getHash() {
			if ($this->hash == null) {
				$this->hash = $this->id . $this->refine . $this->slot0 . $this->slot1 . $this->slot2 . $this->slot3;
				$this->hash = md5($this->hash);
			}
			return $this->hash;
		}

	}

?>