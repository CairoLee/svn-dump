<?php
	require_once FRAMEWORK_LIB_ABS . 'System/DatabaseObject.class.php';
	require_once FRAMEWORK_LIB_ABS . 'System/RoVender.class.php';

	class RoItem extends DatabaseObject {
		protected $_DBName = 'bot_vender_item';

		public $Vender;
		public $PageHits;

		public function __construct(array $row) {
			$this->_Params = array(
				'id' => 'ID',
				'item_id' => 'ItemID',
				'hash' => 'Hash',
				'name' => 'Name',
				'price' => 'PriceAll',
				'price_one' => 'Price',
				'amount' => 'Amount',
				'refine' => 'Refine',
				'slot0' => 'Slot0',
				'slot1' => 'Slot1',
				'slot2' => 'Slot2',
				'slot3' => 'Slot3',

				'avg_all' => 'AvgAll',
				'name_url' => 'NameUrl',
				'vender_id' => 'VenderID',
				'description_en' => 'DescriptionEN',
				'description_fr' => 'DescriptionFR'
			);

			parent::__construct($row);

			$this->NameUrl = self::cleanName($this->Name);
			$this->Vender = new RoVender(Framework::getDb()->getFirstRow("SELECT * FROM bot_vender WHERE char_id = '" . esc($this->VenderID) . "'"));
		}

		
		public static function getObjects($params = array(), $limit = array('from' => 0, 'to' => 10), $order = null) {
			$queryWhere = array();
			$queryOrder = '';
			$queryLimit = '';

			// Where
			foreach ($params as $key => $value) {
				if (is_array($value) == true) {
					$queryWhere[] = $key . " " . $value[0] . " " . $value[1];
				} else {
					$queryWhere[] = $key . " = '" . esc($value) . "'";
				}
			}

			// Limit
			if ($limit && (isset($limit['from']) || isset($limit['to'])))  {
				$queryLimit = " LIMIT " . (isset($limit['from']) ? $limit['from'] . "," : "") . (isset($limit['to']) ? $limit['to'] : "");
			}

			// Order
			if ($order) {
				$queryOrder = " ORDER BY " . $order;
			}

			$query = "
				SELECT 
					i.*,
					v.char_id AS vender_id,
					(
						SELECT
							ROUND(SUM(price_one) / COUNT(*))
						FROM
							bot_vender_item AS ivg
						WHERE
							ivg.hash = i.hash
					) AS avg_all,
					db.description_en,
					db.description_fr
				FROM 
					bot_vender_item AS i
				INNER JOIN
					bot_vender AS v
				ON
					v.char_id = i.vender_id
				INNER JOIN
					item_db AS db
				ON
					db.id = i.item_id
				WHERE
					" . ($queryWhere ? implode(' AND ', $queryWhere) : "") . "
				" . $queryOrder . "
				" . $queryLimit . "
			";
			$result = Framework::getDb()->query($query);
			if (!$result) {
				return null;
			}

			$objects = array();
			while (($row = Framework::getDb()->fetch($result))) {
				$objects[$row['id']] = new RoItem($row);
			}

			return $objects;
		}


		public function updateDatabase($debug = false) {
			
		}


		public function loadHits() {
			$page = $_SERVER['REQUEST_URI'];
			$rowAll = Framework::getDb()->getFirstRow("SELECT SUM(hits) AS hits FROM page_hits WHERE page = '" . esc($page) . "'");
			$rowToday = Framework::getDb()->getFirstRow("SELECT SUM(hits) AS hits FROM page_hits WHERE page = '" . esc($page) . "' AND added >= DATE_FORMAT('Y-m-d', NOW())");
			$rowMonth = Framework::getDb()->getFirstRow("SELECT SUM(hits) AS hits FROM page_hits WHERE page = '" . esc($page) . "' AND added >= DATE_FORMAT('Y-m', NOW())");
			$rowYear = Framework::getDb()->getFirstRow("SELECT SUM(hits) AS hits FROM page_hits WHERE page = '" . esc($page) . "' AND added >= DATE_FORMAT('Y', NOW())");

			$this->PageHits = array(
				'all' => ($rowAll ? $rowAll['hits'] : 0),
				'today' => ($rowToday ? $rowToday['hits'] : 0),
				'month' => ($rowMonth ? $rowMonth['hits'] : 0),
				'hits' => ($rowYear ? $rowYear['hits'] : 0)
			);
		}


		public static function cleanName($name) {
			$name = strtolower($name);

			$search = "/[^a-z0-9_-]/i";
			$replace = "_";

			return preg_replace($search, $replace, $name);
		}


		public function __toString() {
			return '[' . $this->ID . '] ' . $this->name;
		}

	}

?>