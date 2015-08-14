package 
{
    import mx.core.*;
    import mx.styles.*;

    public class _winMaxButtonStyle extends Object
    {
        private static var _embed_css_win_max_over_png_1756669792:Class = _winMaxButtonStyle__embed_css_win_max_over_png_1756669792;
        private static var _embed_css_win_max_up_png_338898818:Class = _winMaxButtonStyle__embed_css_win_max_up_png_338898818;
        private static var _embed_css_win_max_dis_png_183837748:Class = _winMaxButtonStyle__embed_css_win_max_dis_png_183837748;
        private static var _embed_css_win_max_down_png_1534208164:Class = _winMaxButtonStyle__embed_css_win_max_down_png_1534208164;

        public function _winMaxButtonStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration(".winMaxButton");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".winMaxButton", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                this.upSkin = _embed_css_win_max_up_png_338898818;
                this.downSkin = _embed_css_win_max_down_png_1534208164;
                this.overSkin = _embed_css_win_max_over_png_1756669792;
                this.disabledSkin = _embed_css_win_max_dis_png_183837748;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
