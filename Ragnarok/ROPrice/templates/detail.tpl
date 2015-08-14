{include file='header.tpl'}

<h1><img src="{$FRAMEWORK_TPL}images/ragnarok/item/{$item->ItemID}.png" /> {$item->Name}</h1>
<div class="main" style="min-height: 400px;">
	<div class="">
		<img align="right" valign="top" style="padding: 20px;" src="{$FRAMEWORK_TPL}images/ragnarok/collection/{$item->ItemID}.png" />
		<p>
			{$item->DescriptionFR}
		</p>
	</div>
	<div style="padding-top: 10px;">
	</div>
</div>

{include file='footer.tpl'}