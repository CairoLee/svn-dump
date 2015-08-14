package 
{
    import mx.core.*;
    import mx.styles.*;

    public class _macMinButtonStyle extends Object
    {
        private static var _embed_css_mac_min_down_png_1616193818:Class = _macMinButtonStyle__embed_css_mac_min_down_png_1616193818;
        private static var _embed_css_mac_min_up_png_635162500:Class = _macMinButtonStyle__embed_css_mac_min_up_png_635162500;
        private static var _embed_css_mac_min_dis_png_385416694:Class = _macMinButtonStyle__embed_css_mac_min_dis_png_385416694;
        private static var _embed_css_mac_min_over_png_1217661026:Class = _macMinButtonStyle__embed_css_mac_min_over_png_1217661026;

        public function _macMinButtonStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration(".macMinButton");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".macMinButton", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                this.upSkin = _embed_css_mac_min_up_png_635162500;
                this.overSkin = _embed_css_mac_min_over_png_1217661026;
                this.downSkin = _embed_css_mac_min_down_png_1616193818;
                this.alpha = 0.5;
                this.disabledSkin = _embed_css_mac_min_dis_png_385416694;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
