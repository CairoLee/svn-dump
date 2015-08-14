package 
{
    import mx.core.*;
    import mx.styles.*;

    public class _TitleWindowStyle extends Object
    {
        private static var _embed_css_Assets_swf_CloseButtonDisabled_714488160:Class = _TitleWindowStyle__embed_css_Assets_swf_CloseButtonDisabled_714488160;
        private static var _embed_css_Assets_swf_CloseButtonDown_1309599594:Class = _TitleWindowStyle__embed_css_Assets_swf_CloseButtonDown_1309599594;
        private static var _embed_css_Assets_swf_CloseButtonOver_1145564744:Class = _TitleWindowStyle__embed_css_Assets_swf_CloseButtonOver_1145564744;
        private static var _embed_css_Assets_swf_CloseButtonUp_72020991:Class = _TitleWindowStyle__embed_css_Assets_swf_CloseButtonUp_72020991;

        public function _TitleWindowStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("TitleWindow");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("TitleWindow", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                null.closeButtonDisabledSkin = this;
                this.paddingTop = 4;
                this.dropShadowEnabled = true;
                this.backgroundColor = 16777215;
                this.closeButtonOverSkin = _embed_css_Assets_swf_CloseButtonOver_1145564744;
                this.closeButtonUpSkin = _embed_css_Assets_swf_CloseButtonUp_72020991;
                this.closeButtonDownSkin = _embed_css_Assets_swf_CloseButtonDown_1309599594;
                this.cornerRadius = 8;
                this.paddingLeft = 4;
                this.paddingBottom = 4;
                this.paddingRight = 4;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
