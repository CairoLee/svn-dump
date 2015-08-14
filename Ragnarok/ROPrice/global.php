<?php
	error_reporting(E_ALL);
	if (!defined('NO_SESSION')) {
		session_start();
	}

	// TODO: clean up path nirvana
	if (isset($_SERVER)) {
		$host = $_SERVER['HTTP_HOST'];
		if ($host == 'localhost') {
			define('FRAMEWORK_DIR', '/roprice/');
		}
	}
	
	if (!defined('FRAMEWORK_DIR')) define('FRAMEWORK_DIR', '/');
	define('FRAMEWORK_DIR_ABS', dirname(__FILE__) . '/');
	define('FRAMEWORK_LIB', FRAMEWORK_DIR . 'lib/');
	define('FRAMEWORK_LIB_ABS', FRAMEWORK_DIR_ABS . 'lib/');
	define('FRAMEWORK_MODUL', FRAMEWORK_DIR . 'modul/');
	define('FRAMEWORK_MODUL_ABS', FRAMEWORK_DIR_ABS . 'modul/');
	define('FRAMEWORK_TPL', FRAMEWORK_DIR . 'templates/');
	define('FRAMEWORK_TPL_ABS', FRAMEWORK_DIR_ABS . '/templates/');

	require_once FRAMEWORK_LIB_ABS . 'functions.php';
	require_once FRAMEWORK_LIB_ABS . 'Framework.class.php';

	$Framework = new Framework();
	$Framework->loadDb('localhost', 'roprice', '3bvZJ6TWDQuhaFtn', 'roprice');

?>