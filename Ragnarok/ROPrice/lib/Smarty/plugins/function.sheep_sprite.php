<?php
	require_once SHEEPWAR_LIB_ABS . 'System/SheepSprite.class.php';

	function smarty_function_sheep_sprite($params, $template) {
		$spriteObj = null;
		$nameID = null;
		if (isset($params['sheep']) == true) {
			$spriteObj = $params['sheep']->getSprite();
			$nameID = $params['sheep']->NameClean;
		} else if (isset($params['from_sprite']) == true) {
			$spriteObj = $params['from_sprite'];
		}

		if ($spriteObj instanceof SheepSprite)  {
			foreach ($spriteObj->getParams() as $key => $prop) {
				if ($key != 'id') {
					${$key} = $spriteObj->{$prop};
				}
			}
		} else {
			$body = _getParam($params, 'body', 0);
			$eye = _getParam($params, 'eye', 0);
			$eyebrush = _getParam($params, 'eyebrush', 0);
			$mouth = _getParam($params, 'mouth', 0);
			$arm_left = _getParam($params, 'arm_left', 0);
			$arm_right = _getParam($params, 'arm_right', 0);
			$foot = _getParam($params, 'foot', 0);
		}

		if (!$nameID) {
			if (isset($params['name']) == true) {
				$nameID = $params['name'];
			} else if(isset($params['id']) == true) {
				$nameID = $params['id'];
			} else {
				throw new Exception("sheep_sprite: missing 'id'/'name')");
			}
		}
		
		$opt_width = _getParam($params, 'width', 0);
		$opt_height = _getParam($params, 'height', 0);

		$return = '<div id="sheep_' . $nameID . '" class="sprite s_body" style="background-image: url(' . SheepSprite::$SPRITE_PATHS['body']['path'] . $body . '.png);">';
		foreach (SheepSprite::$SPRITE_PATHS as $index => $sprInfo) {
			if ($index != 'body') {
				$return .= '<div class="sprite s_' . $index . '" style="background-image: url(' . $sprInfo['path'] . ${$index} . '.png);"></div>';
			}
		}
		$return .= '</div>';

		return $return;
	}


	function _getParam($params, $index, $default = 0) {
		if (isset($params[$index]) == false) {
			return $default;
		}
		return $params[$index];
	}

?>