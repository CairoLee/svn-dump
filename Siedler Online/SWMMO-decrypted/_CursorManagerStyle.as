package 
{
    import mx.core.*;
    import mx.styles.*;

    public class _CursorManagerStyle extends Object
    {
        private static var _embed_css_Assets_swf_mx_skins_cursor_BusyCursor_28571274:Class = _CursorManagerStyle__embed_css_Assets_swf_mx_skins_cursor_BusyCursor_28571274;

        public function _CursorManagerStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("CursorManager");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("CursorManager", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                null.busyCursor = this;
                this.busyCursorBackground = _embed_css_Assets_swf_mx_skins_cursor_BusyCursor_28571274;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
