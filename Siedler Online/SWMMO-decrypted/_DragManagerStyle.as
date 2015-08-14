package 
{
    import mx.core.*;
    import mx.skins.halo.*;
    import mx.styles.*;

    public class _DragManagerStyle extends Object
    {
        private static var _embed_css_Assets_swf_mx_skins_cursor_DragLink_1923665577:Class = _DragManagerStyle__embed_css_Assets_swf_mx_skins_cursor_DragLink_1923665577;
        private static var _embed_css_Assets_swf_mx_skins_cursor_DragReject_637398458:Class = _DragManagerStyle__embed_css_Assets_swf_mx_skins_cursor_DragReject_637398458;
        private static var _embed_css_Assets_swf_mx_skins_cursor_DragCopy_1923927616:Class = _DragManagerStyle__embed_css_Assets_swf_mx_skins_cursor_DragCopy_1923927616;
        private static var _embed_css_Assets_swf_mx_skins_cursor_DragMove_1923637972:Class = _DragManagerStyle__embed_css_Assets_swf_mx_skins_cursor_DragMove_1923637972;

        public function _DragManagerStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("DragManager");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("DragManager", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                this.copyCursor = _embed_css_Assets_swf_mx_skins_cursor_DragCopy_1923927616;
                this.moveCursor = _embed_css_Assets_swf_mx_skins_cursor_DragMove_1923637972;
                this.rejectCursor = _embed_css_Assets_swf_mx_skins_cursor_DragReject_637398458;
                this.linkCursor = _embed_css_Assets_swf_mx_skins_cursor_DragLink_1923665577;
                this.defaultDragImageSkin = DefaultDragImage;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
