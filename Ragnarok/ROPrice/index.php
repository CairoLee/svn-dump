<?php

	define('SHEEPWAR', 1);

	require_once "global.php";

	// load template engine
	$Framework->loadTpl(dirname(__FILE__) . '/templates/');
	$Framework->loadOthers();

	// load active page/modul
	require_once $Framework->BuildModulPath();
	$activePage = $Framework->BuildModulClass();

	// create active page
	$page = new $activePage();
	
	// assign to use in template
	Framework::getTpl()->assign('activePage', Framework::getActivePage());
	Framework::getTpl()->assign('activePageObj', $page);

	// Load data
	$page->loadData();

	// display active page
	$page->show();

	// clean up
	$Framework = null;
	exit;

?>