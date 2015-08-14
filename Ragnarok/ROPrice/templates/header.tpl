<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml" xml:lang="de" lang="de" dir="ltr">
	<head>
		<title>RO Price{if isset($headerTitle)} | {$headerTitle}{/if}</title>
		<link rel="icon" href="./favicon.ico" type="image/x-icon" />
		<link rel="shortcut icon" href="./favicon.ico" type="image/x-icon" />
		<meta http-equiv="Content-Type" content="text/html; charset=iso-8859-1" />
		<meta name="robots" content="index,follow" />
		<meta name="author" content="GodLesZ" />
		<meta name="description" content="Roprice,Ragnarok Online,Ragnarok,marketwatch,market,market watch,rocheck" />
		<link href="{$FRAMEWORK_TPL}css/common.css" type="text/css" rel="stylesheet" />
		<script src="{$FRAMEWORK_TPL}js/jquery-1.6.3.js" type="text/javascript"></script>
		<script src="{$FRAMEWORK_TPL}js/common.js" type="text/javascript"></script>
		<script type="text/javascript">
			var baseUrl = "{$FRAMEWORK_DIR}";
		</script>
	</head>

	<body>
		<div id="main">
			<table border="0" cellpadding="0" cellspacing="0" id="layout">
				<colgroup>
					<col width="300" />
					<col />
				</colgroup>

				<tr>
					<td colspan="2" valign="top">
						<div id="header">
							<a href="{$FRAMEWORK_DIR}" title="RO Price Homepage">
								<div style="width: 100%; height: 180px">
								</div>
							</a>
						</div>
					</td>
				</tr>

				<tr>
					<td class="lside" valign="top">
						{* Menu *}
						<div class="box shadow">
							<div class="inner">
								<h3>Menu</h3>
								
								<ul>
									<li class="first"><a href="/">Home</a></li>
									<li><a href="/">Test</a></li>
								</ul>
							</div>
						</div>

						{* Search *}
						<div class="box shadow">
							<div class="inner">
								<h3>Search</h3>
							
								<form action="/search.html" method="POST">
									<input type="text" name="name" />
									<input type="submit" name="submit" value="Search" />
								</form>
								<p>
									<a href="/search.html?extended">Extended search</a>
								</p>
							</div>
						</div>

					</td>
					<td class="rside" valign="top">
						<div id="content" class="">