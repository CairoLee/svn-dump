package 
{
    import mx.core.*;
    import mx.styles.*;

    public class _winCloseButtonStyle extends Object
    {
        private static var _embed_css_win_close_up_png_1273476986:Class = _winCloseButtonStyle__embed_css_win_close_up_png_1273476986;
        private static var _embed_css_win_close_down_png_2120287644:Class = _winCloseButtonStyle__embed_css_win_close_down_png_2120287644;
        private static var _embed_css_win_close_over_png_1544106536:Class = _winCloseButtonStyle__embed_css_win_close_over_png_1544106536;

        public function _winCloseButtonStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration(".winCloseButton");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".winCloseButton", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                this.upSkin = _embed_css_win_close_up_png_1273476986;
                this.overSkin = _embed_css_win_close_over_png_1544106536;
                this.downSkin = _embed_css_win_close_down_png_2120287644;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
