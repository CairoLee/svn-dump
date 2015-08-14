<?php

	// Load globals
	require_once dirname(__FILE__) . '/../../global.php';
	// Load Vender and Item helper
	require_once FRAMEWORK_LIB_ABS . 'System/Cronjob/ROItem.class.php';
	require_once FRAMEWORK_LIB_ABS . 'System/Cronjob/ROVender.class.php';

	// Start output cache
	ob_start();

	// Execute cronjob
	// Note: this set all vender and items as "offline"
	//		 that way we have an up-to-date "online" statistic
	ROVender::cronjob();
	ROItem::cronjob();

	// Read all files in /data/
	$dirpath = FRAMEWORK_LIB_ABS . 'Cronjob/data/';
	$dir = dir($dirpath);
	$fileCount = 0;

	echo '<pre>' . "\n";
	while (($file = $dir->read())) {
		// Search for 'data_'
		if (empty($file) || $file[0] == '.' || strlen($file) < 5 || substr($file, 0, 5) != 'data_') {
			continue;
		}
		// Maybe a sub-dir?
		if (is_file($dirpath . $file) == false) {
			echo 'skip subdir ' . $file . "\n";
			continue;
		}
		
		$fileCount++;

		// Beware of locked files
		// Note: we check for writeable too, in case of write-lock
		$inform = false;
		while (@is_readable($dirpath . $file) == false || @is_writeable($dirpath . $file) == false) {
			if ($inform == false) {
				// Only inform me 1 time per file
				echo 'wait for access of file ' . $file . "\n";
				$inform = true;
			}
			sleep(1);
		}

		// File is read and writeable, import it
		echo 'import ' . $file . "\n";

		$lines = file($dirpath . $file);
		foreach( $lines as $line) {
			$line = trim($line);
			if (empty($line)) {
				continue;
			}

			// <vender data>\t<item1>\t...
			$parts = explode("\t", $line);
			$venderData = explode(ROVender::SPLITTER, array_shift($parts));
			$vender = new ROVender($venderData);
			// Save vender data
			$vender->save();
			// Encode items
			$items = array();
			foreach ($parts as $itemData) {
				$itemDataDecoded = explode(ROItem::SPLITTER, $itemData);
				$items[] = new ROItem($vender->id, $itemDataDecoded);
			}

			// Save items
			$vender->addItems($items);
		}

		// Import done, delete the file
		unlink($dirpath . $file);
	}

	// Close the handle
	$dir->close();

	echo 'found ' . $fileCount . 'files' . "\n";
	echo "\n" . '</pre>';

	// Done, take the buffer and redirect
	$output = ob_get_contents();
	ob_end_flush();

	// TODO: Redirect header (10sec)
	// header("");
	echo $output;
	exit;

?>