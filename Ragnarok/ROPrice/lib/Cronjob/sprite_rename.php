<?php
	set_time_limit(0);
	error_reporting(E_ALL);

	/*
	// Test base resname against french.. still missing e.x 502 (organge potion) item icon?
	$resname_base = parseFile('D:/Games/data/idnum2itemresnametable.txt');
	$resname_french = parseFile('D:/Games/data/french/idnum2itemresnametable.txt');
	// Test differences
	echo 'entrys base: ' . count($resname_base) . '<br />';
	echo 'entrys french: ' . count($resname_french) . '<br />';
	foreach ($resname_french as $id => $name) {
		if (isset($resname_base[$id]) == false) {
			echo 'missing in base: ' . $id . ' [' . $name . ']<br />';
			continue;
		}
		if ($resname_base[$id] != $name) {
			echo 'difference: ' . $id . ' french[' . $name . '] base[' . $resname_base[$id] . ']<br />';
			continue;
		}
	}
	die('done');
	*/

	// Assume that french resnames are more complete?
	$itemnames_fr = parseFile('D:/Games/data/french/idnum2itemresnametable.txt');
	$itemnames_base = parseFile('D:/Games/data/idnum2itemresnametable.txt');
	// English and french card resnames are equal
	$cardnames = parseFile('D:/Games/data/english/num2cardillustnametable.txt');

	echo 'names done, copy files<br />';

	// Names cached, rename files
	$baseItem = 'D:/Games/data/texture/유저인터페이스/item/';
	$baseCollection = 'D:/Games/data/texture/유저인터페이스/collection/';
	$baseCard = 'D:/Games/data/texture/유저인터페이스/cardbmp/';
	$targetItem = 'D:/Xampp/htdocs/roprice/templates/images/ragnarok/item/';
	$targetCollection = 'D:/Xampp/htdocs/roprice/templates/images/ragnarok/collection/';
	$targetCard = 'D:/Xampp/htdocs/roprice/templates/images/ragnarok/card/';

	foreach ($cardnames as $itemID => $filename) {
		copyFile($itemID, $filename, $baseCard, $targetCard);
	}

	echo 'cards done, copy base files<br />';

	foreach ($itemnames_fr as $itemID => $filename) {
		$result = copyFile($itemID, $filename, $baseItem, $targetItem);
		// File not found, try base name
		if ($result == -1) {
			if (isset($itemnames_base[$itemID])) {
				copyFile($itemID, $itemnames_base[$itemID], $baseItem, $targetItem);
			}
		}

		copyFile($itemID, $filename, $baseCollection, $targetCollection);
		// File not found, try base name
		if ($result == -1) {
			if (isset($itemnames_base[$itemID])) {
				copyFile($itemID, $itemnames_base[$itemID], $baseCollection, $targetCollection);
			}
		}
	}

	exit('done');



	function parseFile($filepath) {
		$lines = file($filepath);

		$names = array();
		foreach ($lines as $line) {
			$line = trim($line);
			if (empty($line) || substr($line, 0, 2) == '//') {
				continue;
			}

			// id#koreaname#
			if (preg_match('/([0-9]+)#([^#]+)#$/', $line, $match) == false) {
				echo "\t" . 'skip: ' . $line . '<br />';
			}

			$id = intval($match[1]);
			$name = trim($match[2]);

			$names[$id] = $name;
		}

		return $names;
	}


	function copyFile($itemID, $filename, $base, $target) {
		$type = substr($base, strrpos(substr($base, 0, -1), '/') + 1, -1);

		$filepath = $base . $filename . '.bmp';
		$targetpath = $target . $itemID . '.bmp';
		$targetpath_png = $target . $itemID . '.png';
		if (file_exists($targetpath) == true || file_exists($targetpath_png) == true) {
			return 0;
		}
		
		if (file_exists($filepath) == false) {
			//echo '[' . $type . '] not found: ' . $filename . '<br />';
			return -1;
		}

		copy($filepath, $targetpath);
		echo '[' . $type . '] copy ' . $itemID . '<br />';

		return 1;
	}

?>