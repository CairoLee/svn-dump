package GUI.Components.ItemRenderer
{
    import GUI.Components.*;
    import com.bluebyte.tso.chat.*;
    import flash.text.*;
    import mx.controls.*;
    import mx.formatters.*;
    import mx.styles.*;

    public class CustomChatMessage extends Text
    {
        private static const STYLE_CACHE:Object = new Object();
        public static var STYLESHEET:StyleSheet;

        public function CustomChatMessage()
        {
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                null.paddingLeft = this;
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
            var _loc_5:int = 0;
            if (this.data == param1)
            {
                return;
            }
            super.data = param1;
            if (param1 == null)
            {
                return;
            }
            var _loc_2:* = param1 as CustomMessageVO;
            var _loc_3:String = "whisper";
            if (_loc_2.groupMessage)
            {
                _loc_3 = _loc_2.room.split(globalFlash.gui.mChatPanel.roomSeperator)[0];
            }
            var _loc_4:* = new DateFormatter();
            new DateFormatter().formatString = "JJ:NN";
            _loc_5 = 0;
            var _loc_6:int = 0;
            text = "[" + _loc_4.format(_loc_2.time) + "] ";
            _loc_5 = this.text.length;
            var _loc_7:* = _loc_2.sender.name;
            if ((_loc_2.sender as CustomOccupantVO).tag)
            {
                _loc_7 = "[" + (_loc_2.sender as CustomOccupantVO).tag + "] " + _loc_7;
            }
            text = text + (_loc_7 + ":");
            _loc_6 = this.text.length;
            text = text + (" " + _loc_2.text);
            this.validateNow();
            if (_loc_3.indexOf("gc_") == 0)
            {
                _loc_3 = "guild";
            }
            else if (_loc_3.indexOf("gco_") == 0)
            {
                _loc_3 = "officers";
            }
            this.textField.setTextFormat(this.getTextStyle("." + _loc_3 + "tstamp"), 0, _loc_5);
            var _loc_8:* = this.getTextStyle("." + _loc_3 + "sender");
            if (_loc_2.clickable)
            {
                _loc_8.url = "event:action=whisper?fname=" + _loc_2.sender.name + "|" + _loc_2.sender.id;
            }
            this.textField.setTextFormat(_loc_8, _loc_5, _loc_6);
            _loc_8.url = null;
            var _loc_9:* = this.getTextStyle("." + _loc_3 + "msg");
            if (_loc_2.important)
            {
                _loc_9 = this.getTextStyle("." + _loc_3 + "important");
            }
            if (_loc_2.ownname)
            {
                _loc_9 = this.getTextStyle("." + _loc_3 + "ownname");
            }
            if (_loc_2.moderator)
            {
                _loc_9 = this.getTextStyle(".modmsg");
            }
            if (_loc_2.bluebyte)
            {
                _loc_9 = this.getTextStyle(".bbmsg");
            }
            this.textField.setTextFormat(_loc_9, _loc_6, this.text.length);
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
            if (STYLESHEET == null)
            {
                CustomChatMessage.STYLESHEET = new StyleSheet();
                CustomChatMessage.STYLESHEET.parseCSS(new ChatPanel.CSSFile().toString());
            }
            var _loc_3:* = CustomChatMessage.STYLESHEET.getStyle(param1);
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
