<?php
	set_time_limit(0);
	error_reporting(E_ALL);

	define('NO_SESSION', true);
	require_once '../../global.php';

	// French
	$data_fr = loadDescription('D:/Games/data/french/idnum2itemdesctable.txt');
	// English (not yet done by fRO? Oo)
	//$data_en = loadDescription('D:/Games/data/english/idnum2itemdesctable.txt');

	// Import French
	foreach ($data_fr as $ID => $lines) {
		echo '[FR] update #' . $ID . '<br />';
		$text = formatText($lines);
		Framework::getDb()->query("UPDATE item_db SET description_fr = '" . esc($text) . "' WHERE id = '" . esc($ID) . "'");
	}
	// Import english
	/*
	foreach ($data_en as $ID => $lines) {
		echo '[EN] update #' . $ID . '<br />';
		$text = implode("\n", $lines);
		Framework::getDb()->query("UPDATE item_db SET description_en = '" . esc($text) . "' WHERE id = '" . esc($ID) . "'");
	}
	*/

	exit('done');


	function loadDescription($filepath) {
		$data = array();

		$lines = file($filepath);
		$currentID = null;
		foreach ($lines as $line) {
			$line = trim($line);
			if (empty($line) || (strlen($line) >= 2 && substr($line, 0, 2) == '//')) {
				continue;
			}

			// Block start
			if (preg_match('/^([0-9]+)#$/', $line, $match)) {
				$currentID = intval($match[1]);
				$data[$currentID] = array();
				continue;
			}
			// Block end
			if ($line == '#') {
				continue;
			}

			if ($currentID == null) {
				die($filepath . ': Data without ID: ' . $line);
			}

			$data[$currentID][] = $line;
		}

		return $data;
	}

	function formatText($lines) {
		// Replace beginning attributes with strong (each line)
		$text = '';
		foreach ($lines as &$line) {
			$line = preg_replace('/^([a-z0-9_]{2,})([ \t]*):/i', '<strong>$1</strong>$2:', $line);
		}

		// Implode all lines
		$text = implode('<br />', $lines);

		// Replace colors
		/*
		$search = '/\^([a-z0-9]{6})([^\^])([a-z0-9]{6})?/i';
		$replace = '<span style="color: $1;">$2</span>';
		$textNew = preg_replace($search, $replace, $text);
		*/
		$textNew = '';
		$inColor = false;
		for ($i = 0; $i < strlen($text); $i++) {
			if ($text[$i] == '^') {
				$valid = true;
				$color = '';
				for ($c = $i + 1; $c < ($i + 6) && $c < strlen($text); $c++) {
					$color .= $text[$c];
					if (preg_match('/[a-z0-9]/i', $text[$c]) == false) {
						echo 'no match: ' . $text[$c] . '<br />';
						$valid = false;
						break;
					}
				}
				if ($valid == true) {
					if ($inColor == true) {
						$textNew .= '</span>';
						if ($color != '000000') {
							$textNew .= '<span style="color: #' . $color . ';">';
						} else {
							$inColor = false;
						}
					} else {
						$textNew .= '<span style="color: #' . $color . ';">';
						$inColor = true;
					}

					$i += 6;
					
					continue;
				}
			}

			$textNew .= $text[$i];
		}

		return $textNew;
	}
?>