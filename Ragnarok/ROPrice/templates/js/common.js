
jQuery(document).ready(function() {
	// Load random online items
	jQuery.ajax({
		url: baseUrl + 'search.html',
		type: 'POST',
		dataType: 'json',
		success: function(data) {
			addItems(data);
		}
	});

	// Fav
	jQuery('td.fav a').live('click', function() {
		console.log(this);
		return false;
	});
});


function addItems(data, append) {
	var $table = jQuery('#itemtable'),
		$tbody = $table.find('tbody'),
		content = '',
		i = 1;

	append = append || false;

	// Loading animation

	jQuery.each(data, function(key, value) {
		content += 
				'<tr class="' + (key%2 ? 'even' : 'odd') + '">' + 
					'<td class="fav"><a href="#"><img src="' + baseUrl + 'templates/images/icons/16/star_grey.png" /></a></td>' + 
					'<td class="preview"><img src="' + baseUrl + 'templates/images/ragnarok/item/' + value.ItemID + '.png" /></td>' + 
					'<td>' + value.ItemID + '</td>' + 
					'<td><a href="' + value.ID + '-' + value.NameUrl + '.html">' + value.Name + '</a></td>' + 
					'<td>' + value.PriceAll.numberFormat() + 'z (' + value.Price.numberFormat() + 'z ea)</td>' + 
					'<td>' + value.AvgAll.numberFormat() + '</td>' + 
					'<td>' + value.Amount.numberFormat() + '</td>' + 
					'<td>' + value.Vender.Name + '</td>' + 
				'</tr>' + 
		'';
		i++;
	});

	if (append) {
		$tbody.append(content);
	} else {
		$tbody.html(content);
	}
}

String.prototype.numberFormat = function() {
	if (this.length < 3) {
		return this;
	}

	var string = '';
	var c = ((this.length % 3) != 0 ? 3 - (this.length % 3) : 0);
	for (var i = 0; i < this.length; i++) {
		string += this[i];
		if (++c >= 3 && (i + 1) < this.length) {
			string += '.';
			c = 0;
		}
	}
	return string;
}