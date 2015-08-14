<link href="{$FRAMEWORK_DIR}css/exception.css" type="text/css" rel="stylesheet" />
<div class="exception">
	<div class="container">
		<div class="exCaption">
			An error has occured
			<a href="javascript:void()" onclick="this.parentNode.parentNode.parentNode.style.visibility = 'hidden';">X</a>
		</div>
		<div class="exInfo">
			Exception: {$exception->getBaseException()} (Code {$exception->getCode()})
		</div>
		
		<fieldset>
			<legend>Errormessage:</legend>
			<div style="height:40px;overflow:auto">{$exception->getMessage()}</div>
		</fieldset>
		
		<fieldset>
			<legend>Error Location:</legend>
			File {$exception->getFile()} on line {$exception->getLine()}
		</fieldset>
		
		<fieldset>
			<legend>Stacktrace (For debugging):</legend>
			<div class="exStacktrace">
				{$exception->getFormattedTrace()}
			</div>
		</fieldset>

		<div class="exFooter">
			This Error is reported to GodLesZ automatically.<br />
			We will fix this error as soon as possible.
			{if $returnLink}<br /><a href="{$returnLink}">Return ({$returnLink})</a>{/if}
		</div>
	</div>
</div>