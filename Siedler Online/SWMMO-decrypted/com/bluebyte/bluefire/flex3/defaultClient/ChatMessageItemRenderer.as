package com.bluebyte.bluefire.flex3.defaultClient
{
    import com.bluebyte.bluefire.api.model.vo.*;
    import flash.text.*;
    import mx.controls.*;
    import mx.formatters.*;
    import mx.styles.*;

    public class ChatMessageItemRenderer extends Text
    {
        private static const STYLE_CACHE:Object = new Object();
        public static var STYLESHEET:StyleSheet;

        public function ChatMessageItemRenderer()
        {
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                this.paddingLeft = -2;
                this.paddingTop = -2;
                this.paddingBottom = -5;
                return;
            }// end function
            ;
            return;
        }// end function

        override public function initialize() : void
        {
            super.initialize();
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            var _loc_2:MessageVO = null;
            var _loc_7:TextFormat = null;
            if (this.data == param1)
            {
                return;
            }
            super.data = param1;
            if (param1 == null)
            {
                return;
            }
            _loc_2 = param1 as MessageVO;
            var _loc_3:* = new DateFormatter();
            _loc_3.formatString = "JJ:NN";
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            text = "[" + _loc_3.format(_loc_2.time) + "] ";
            _loc_4 = this.text.length;
            var _loc_6:* = _loc_2.sender.name;
            text = text + (_loc_6 + ":");
            _loc_5 = this.text.length;
            text = text + (" " + _loc_2.text);
            this.validateNow();
            if (_loc_2.ownname)
            {
                _loc_7 = this.getTextStyle(".ownname");
                this.textField.setTextFormat(_loc_7, _loc_5, this.text.length);
            }
            else if (_loc_2.moderator)
            {
                _loc_7 = this.getTextStyle(".moderator");
                this.textField.setTextFormat(_loc_7, _loc_5, this.text.length);
            }
            else if (_loc_2.important)
            {
                _loc_7 = this.getTextStyle(".important");
                this.textField.setTextFormat(_loc_7, _loc_5, this.text.length);
            }
            this.validateNow();
            return;
        }// end function

        private function getTextStyle(param1:String) : TextFormat
        {
            var _loc_4:String = null;
            var _loc_2:* = STYLE_CACHE[param1];
            if (_loc_2)
            {
                return _loc_2;
            }
            var _loc_3:* = STYLESHEET.getStyle(param1);
            if (_loc_3 != null)
            {
                _loc_4 = _loc_3.color;
                if (_loc_4 != null && _loc_4.indexOf("#") == 0)
                {
                    _loc_3.color = "0x" + _loc_4.substr(1);
                }
                _loc_2 = new TextFormat(_loc_3.fontFamily, _loc_3.fontSize, _loc_3.color, _loc_3.fontWeight == "bold", _loc_3.fontStyle == "italic", _loc_3.textDecoration == "underline", _loc_3.url, _loc_3.target, _loc_3.textAlign, _loc_3.marginLeft, _loc_3.marginRight, _loc_3.indent, _loc_3.leading);
                if (_loc_3.hasOwnProperty("letterSpacing"))
                {
                    _loc_2.letterSpacing = _loc_3.letterSpacing;
                }
            }
            STYLE_CACHE[param1] = _loc_2;
            return _loc_2;
        }// end function

    }
}
