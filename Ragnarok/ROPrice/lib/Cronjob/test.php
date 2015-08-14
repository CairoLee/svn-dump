<?php
	require_once dirname(__FILE__) . '/../../global.php';
	$t = '##||##';

	$vender = 
			base64_encode(1) . $t . 
			base64_encode('GodLesZ') . $t . 
			base64_encode('ROPrice test') . $t . 
			base64_encode(159) . $t . 
			base64_encode(159) . $t . 
			base64_encode('prontera');

	$result = Framework::getDb()->fetchAll("SELECT * FROM item_db WHERE id >= 501 AND id <= 510");
	foreach ($result as $row) {
		$h = fopen('data/data_' . date('Y-m-d_H-i') . '_' . rand() . '.txt', 'w+');

		// Build random
		$price = ($row['price_buy'] + (rand(1,2) == 1 ? rand(10, 100) : 0));
		$amount = rand(10, 100);
		$price *= $amount; // In RO we get the price for all items
		$refine = 0;
		$card0 = 0;
		$card1 = 0;
		$card2 = 0;
		$card3 = 0;
		$item = 
			base64_encode($row['id']) . $t . 
			base64_encode($row['name_japanese']) . $t . 
			base64_encode($price) . $t . 
			base64_encode($amount) . $t . 
			base64_encode($refine) . $t . 
			base64_encode($card0) . $t . 
			base64_encode($card1) . $t . 
			base64_encode($card2) . $t . 
			base64_encode($card3);

		$line = $vender . "\t" . $item . "\n";
		fwrite($h, $line);

		fclose($h);
	}



?>