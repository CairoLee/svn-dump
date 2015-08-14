<?php

	class ROVender {
		const SPLITTER = "##||##";
		const TABLE = "bot_vender";

		public $id;
		public $name;
		public $shopname;
		public $posX;
		public $posY;
		public $posMap;
		// TODO: character style infos


		public function __construct(array $data) {
			// All parts are base64 encoded
			foreach ($data as &$info) {
				$info = base64_decode($info);
			}

			$this->import($data);
		}


		public static function cronjob() {
			// Note: we never delete items or vender entrys
			//		 so we may display a selling history per vender
			//		 maybe a nice feature..
			$query = "UPDATE `" . self::TABLE . "` SET online = 0";
			Framework::getDb()->query($query);

			// TODO: remove items here, if database is slowly
		}


		public function addItems(array $items) {			
			// Add new items 
			foreach ($items as $item) {
				$item->save($this->id);
			}
		}
		
		public function save() {
			// Add vender to the database or set to online
			$query = "SELECT char_id FROM " . self::TABLE . " WHERE char_id = '" . esc($this->id) . "'";
			$row = Framework::getDb()->getFirstRow($query);
			if ($row != null) {
				// Vender found, update it
				// Note: update name incase of name-change
				$query = "
					UPDATE " . self::TABLE . " SET 
						name = '" . esc($this->name) . "', 
						shopname = '" . esc($this->shopname) . "',
						posX = '" . esc($this->posX) . "', 
						posY = '" . esc($this->posY) . "', 
						posMap = '" . esc($this->posMap) . "', 
						online = 1,
						seen = NOW()
					WHERE char_id = '" . esc($this->id) . "'
				";
			} else {
				// New entry
				$query = "
					INSERT INTO " . self::TABLE . "
						(char_id, name, shopname, posX, posY, posMap, seen, online)
					VALUES
						('" . esc($this->id) . "', '" . esc($this->name) . "', '" . esc($this->shopname) . "', '" . esc($this->posX) . "', '" . esc($this->posY) . "', '" . esc($this->posMap) . "', NOW(), '1')
				";
			}
			
			Framework::getDb()->query($query);
		}


		private function import(array $data) {
			$this->id = $data[0];
			$this->name = $data[1];
			$this->shopname = $data[2];
			$this->posX = $data[3];
			$this->posY = $data[4];
			$this->posMap = $data[5];

			// TODO: character style
		}

	}

?>