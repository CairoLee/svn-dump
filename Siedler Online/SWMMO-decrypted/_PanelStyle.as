package 
{
    import mx.core.*;
    import mx.skins.halo.*;
    import mx.styles.*;

    public class _PanelStyle extends Object
    {

        public function _PanelStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var effects:Array;
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("Panel");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("Panel", style, false);
                effects = mx_internal::effects;
                if (!effects)
                {
                    var _loc_3:* = new Array();
                    mx_internal::effects = new Array();
                    effects = _loc_3;
                }
                effects.push("resizeEndEffect");
                effects.push("resizeStartEffect");
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                null.statusStyleName = this;
                this.borderStyle = "default";
                this.paddingTop = 0;
                this.borderColor = 14869218;
                this.backgroundColor = 16777215;
                this.cornerRadius = 4;
                this.titleBackgroundSkin = TitleBackground;
                this.borderAlpha = 0.4;
                this.borderThicknessTop = 2;
                this.paddingLeft = 0;
                this.resizeEndEffect = "Dissolve";
                this.paddingRight = 0;
                this.titleStyleName = "windowStyles";
                this.roundedBottomCorners = false;
                this.borderThicknessRight = 10;
                this.dropShadowEnabled = true;
                this.resizeStartEffect = "Dissolve";
                this.borderSkin = PanelSkin;
                this.borderThickness = 0;
                this.borderThicknessLeft = 10;
                this.paddingBottom = 0;
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
