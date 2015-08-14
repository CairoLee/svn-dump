<?php

function smarty_function_percent($params, $template) {
	$val1 = $params['val1'];
	$val2 = $params['val2'];
	$round = (isset($params['round']) == true ? $params['round'] : 2);

	if ($val1 >= 1 && $val2 >= 1) {
		$perc = (float)$val1 / (float)$val2;
		$perc *= 100.0;
	} else {
		$perc = 0;
	}
	$perc = round($perc, $round);

	if (isset($params['assign']) == true) {
        $template->assign($params['assign'], $perc);
		return;
	}

	return $perc;
}

?>