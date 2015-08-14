package 
{
    import mx.core.*;
    import mx.skins.halo.*;
    import mx.styles.*;

    public class _RadioButtonStyle extends Object
    {

        public function _RadioButtonStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("RadioButton");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("RadioButton", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                null.downSkin = this;
                this.iconColor = 2831164;
                this.cornerRadius = 7;
                this.selectedDownIcon = null;
                this.selectedUpSkin = null;
                this.overIcon = null;
                this.skin = null;
                this.upSkin = null;
                this.selectedDownSkin = null;
                this.selectedOverIcon = null;
                this.selectedDisabledIcon = null;
                this.textAlign = "left";
                this.horizontalGap = 5;
                this.downIcon = null;
                this.icon = RadioButtonIcon;
                this.overSkin = null;
                this.disabledIcon = null;
                this.selectedDisabledSkin = null;
                this.upIcon = null;
                this.paddingLeft = 0;
                this.paddingRight = 0;
                this.fontWeight = "normal";
                this.selectedUpIcon = null;
                this.disabledSkin = null;
                this.selectedOverSkin = null;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
