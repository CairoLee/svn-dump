package 
{
    import mx.core.*;
    import mx.skins.halo.*;
    import mx.styles.*;

    public class _MenuStyle extends Object
    {
        private static var _embed_css_Assets_swf_MenuCheckEnabled_1039091038:Class = _MenuStyle__embed_css_Assets_swf_MenuCheckEnabled_1039091038;
        private static var _embed_css_Assets_swf_MenuCheckDisabled_1577250559:Class = _MenuStyle__embed_css_Assets_swf_MenuCheckDisabled_1577250559;
        private static var _embed_css_Assets_swf_MenuRadioEnabled_1075733377:Class = _MenuStyle__embed_css_Assets_swf_MenuRadioEnabled_1075733377;
        private static var _embed_css_Assets_swf_MenuRadioDisabled_499715390:Class = _MenuStyle__embed_css_Assets_swf_MenuRadioDisabled_499715390;
        private static var _embed_css_Assets_swf_MenuBranchEnabled_1118814550:Class = _MenuStyle__embed_css_Assets_swf_MenuBranchEnabled_1118814550;
        private static var _embed_css_Assets_swf_MenuBranchDisabled_928093383:Class = _MenuStyle__embed_css_Assets_swf_MenuBranchDisabled_928093383;
        private static var _embed_css_Assets_swf_MenuSeparator_113346240:Class = _MenuStyle__embed_css_Assets_swf_MenuSeparator_113346240;

        public function _MenuStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("Menu");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("Menu", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                null.radioIcon = this;
                this.borderStyle = "menuBorder";
                this.paddingTop = 1;
                this.rightIconGap = 15;
                this.branchIcon = _embed_css_Assets_swf_MenuBranchEnabled_1118814550;
                this.checkDisabledIcon = _embed_css_Assets_swf_MenuCheckDisabled_1577250559;
                this.verticalAlign = "middle";
                this.paddingLeft = 1;
                this.paddingRight = 0;
                this.checkIcon = _embed_css_Assets_swf_MenuCheckEnabled_1039091038;
                this.radioDisabledIcon = _embed_css_Assets_swf_MenuRadioDisabled_499715390;
                this.dropShadowEnabled = true;
                this.branchDisabledIcon = _embed_css_Assets_swf_MenuBranchDisabled_928093383;
                this.dropIndicatorSkin = ListDropIndicator;
                this.separatorSkin = _embed_css_Assets_swf_MenuSeparator_113346240;
                this.horizontalGap = 6;
                this.leftIconGap = 18;
                this.paddingBottom = 1;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
