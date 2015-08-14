package 
{
    import mx.core.*;
    import mx.styles.*;

    public class _winRestoreButtonStyle extends Object
    {
        private static var _embed_css_win_restore_over_png_308561156:Class = _winRestoreButtonStyle__embed_css_win_restore_over_png_308561156;
        private static var _embed_css_win_restore_down_png_34299608:Class = _winRestoreButtonStyle__embed_css_win_restore_down_png_34299608;
        private static var _embed_css_win_restore_up_png_1150082810:Class = _winRestoreButtonStyle__embed_css_win_restore_up_png_1150082810;

        public function _winRestoreButtonStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration(".winRestoreButton");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".winRestoreButton", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                null.upSkin = this;
                this.downSkin = _embed_css_win_restore_down_png_34299608;
                this.overSkin = _embed_css_win_restore_over_png_308561156;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
