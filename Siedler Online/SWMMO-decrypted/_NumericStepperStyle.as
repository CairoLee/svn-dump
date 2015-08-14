package 
{
    import mx.core.*;
    import mx.skins.halo.*;
    import mx.styles.*;

    public class _NumericStepperStyle extends Object
    {

        public function _NumericStepperStyle()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var style:* = StyleManager.getStyleDeclaration("NumericStepper");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration("NumericStepper", style, false);
            }
            if (style.defaultFactory == null)
            {
                style.defaultFactory = function () : void
            {
                this.downArrowSkin = NumericStepperDownSkin;
                this.cornerRadius = 5;
                this.upArrowSkin = NumericStepperUpSkin;
                this.focusRoundedCorners = "tr br";
                return;
            }// end function
            ;
            }
            return;
        }// end function

    }
}
