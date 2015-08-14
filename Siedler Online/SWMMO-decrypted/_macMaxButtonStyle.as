package 
{
    import mx.core.*;
    import mx.styles.*;

    public class _macMaxButtonStyle extends Object
    {
        private static var _embed_css_mac_max_dis_png_1215682182:Class = _macMaxButtonStyle__embed_css_mac_max_dis_png_1215682182;
        private static var _embed_css_mac_max_up_png_350974072:Class = _macMaxButtonStyle__embed_css_mac_max_up_png_350974072;
        private static var _embed_css_mac_max_down_png_1209386090:Class = _macMaxButtonStyle__embed_css_mac_max_down_png_1209386090;
        private static var _embed_css_mac_max_over_png_1614424282:Class = _macMaxButtonStyle__embed_css_mac_max_over_png_1614424282;

        public function _macMaxButtonStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration(".macMaxButton");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".macMaxButton", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                this.upSkin = _embed_css_mac_max_up_png_350974072;
                this.overSkin = _embed_css_mac_max_over_png_1614424282;
                this.downSkin = _embed_css_mac_max_down_png_1209386090;
                this.disabledSkin = _embed_css_mac_max_dis_png_1215682182;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
