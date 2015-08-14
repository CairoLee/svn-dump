<?php


	function escapeString($string) {
		if (Framework::getDb() != null) {
			return mysql_real_escape_string($string, Framework::getDb()->getLink());
		}
		return mysql_escape_string($string);
	}

	function esc($string) {
		return escapeString($string);
	}

	// shorter
	function f($num) {
		return (float)$num;
	}
	
	function printDebug($var, $trace = false, $exit = true) {
		echo '<pre>';
		var_dump($var);

		if ($trace == true) {
			debug_print_backtrace();
		}
		if ($exit == true) {
			exit;
		}
	}
	function showDebug($var, $trace = false, $exit = true) {
		return printDebug($var, $trace, $exit);
	}

?>