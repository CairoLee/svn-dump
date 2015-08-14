package 
{
    import mx.core.*;
    import mx.styles.*;

    public class _winMinButtonStyle extends Object
    {
        private static var _embed_css_win_min_up_png_2010309858:Class = _winMinButtonStyle__embed_css_win_min_up_png_2010309858;
        private static var _embed_css_win_min_dis_png_418903456:Class = _winMinButtonStyle__embed_css_win_min_dis_png_418903456;
        private static var _embed_css_win_min_down_png_1214555360:Class = _winMinButtonStyle__embed_css_win_min_down_png_1214555360;
        private static var _embed_css_win_min_over_png_1618461860:Class = _winMinButtonStyle__embed_css_win_min_over_png_1618461860;

        public function _winMinButtonStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration(".winMinButton");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".winMinButton", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                this.upSkin = _embed_css_win_min_up_png_2010309858;
                this.downSkin = _embed_css_win_min_down_png_1214555360;
                this.overSkin = _embed_css_win_min_over_png_1618461860;
                this.disabledSkin = _embed_css_win_min_dis_png_418903456;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
