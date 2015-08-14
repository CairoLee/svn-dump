{include file='header.tpl'}

<h1>RO Price</h1>
<div class="main" style="min-height: 400px;">
	$page = {$activePage}
	<br />
	<table id="itemtable" class="colortable" border="0" cellpadding="0" cellspacing="0">
		<colgroup>
			<col width="30" />{* Fav *}
			<col width="30" />{* Icon *}
			<col width="60" />{* ID *}
			<col width="auto" />{* Name *}
			<col width="200" />{* Price (ea) *}
			<col width="100" />{* Avg *}
			<col width="70" />{* Amount *}
			<col width="200" />{* Vender *}
		</colgroup>

		<thead>
			<tr>
				<th></th>
				<th></th>
				<th>#</th>
				<th>Name</th>
				<th>Price</th>
				<th>Amount</th>
				<th>&Oslash; Price</th>
				<th>Vender</th>
			</tr>
		</thead>
		<tbody>
		</tbody>
	</table>
</div>

{include file='footer.tpl'}