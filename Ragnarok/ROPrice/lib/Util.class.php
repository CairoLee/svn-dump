<?php

	class Util {

		public static function debugLog($text) {
			$h = fopen('debug.log', 'a+');
			fwrite($h, $text . "\n");
			fclose($h);
		}

		///////////////////////////////////////////////
		// Request Helper
		///////////////////////////////////////////////
		public static function getVar($index, $array, $clean = false, $default = null) {
			if (isset($array[$index]) == false) {
				return $default;
			}

			$value = $array[$index];
			if ($clean == true) {
				$value = stripslashes($value);
				$value = escapeString($value);
			}
			return $value;
		}

		public static function getPost($index) {
			return self::getVar($index, $_POST);
		}

		public static function getGet($index) {
			return self::getVar($index, $_GET);
		}

		public static function getRequest($index) {
			$return = null;
			if (($return = self::getPost($index)) == null) {
				$return = self::getGet($index);
			}
			return $return;
		}



		public static function CreateSalt() {
			return md5(time());
		}
		public static function HashString($string, $salt = null) {
			if ($salt == null) {
				$salt = self::CreateSalt();
			}
			$hash = md5($salt . $string . $salt);
			$hash = sha1($hash . $salt . $hash);

			return $hash;
		}


		

		///////////////////////////////////////////////
		// Admin XML Export Helper
		///////////////////////////////////////////////
		public static function resultToXML($result, $tagName, $filepath) {
			$doc = new DOMDocument();
			$doc->formatOutput = true;
			$items = $doc->createElement('items');
			$doc->appendChild($items);

			while (($row = Framework::getDb()->fetch($result))) {
				$item = $doc->createElement($tagName);
				foreach ($row as $key => $value) {
					$item->appendChild($doc->createElement($key, $value));
				}
				$items->appendChild($item);
			}

			if (@file_exists($filepath) == true) {
				unlink($filepath);
			}
			$doc->save($filepath);
		}


		public static function redirect($url, $urlBase = '/', $exit = true) {
			header('Location: ' . $urlBase . $url);
			if ($exit == true) {
				exit;
			}

			return true;
		}

	}
?>