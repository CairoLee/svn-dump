package mx.controls.buttonBarClasses
{
    import mx.controls.*;
    import mx.core.*;

    public class ButtonBarButton extends Button
    {
        private var inLayoutContents:Boolean = false;
        static const VERSION:String = "3.5.0.12683";

        public function ButtonBarButton()
        {
            return;
        }// end function

        override function layoutContents(param1:Number, param2:Number, param3:Boolean) : void
        {
            inLayoutContents = true;
            super.layoutContents(param1, param2, param3);
            inLayoutContents = false;
            return;
        }// end function

        override public function determineTextFormatFromStyles() : UITextFormat
        {
            if (inLayoutContents && selected)
            {
                return textField.getUITextFormat();
            }
            return super.determineTextFormatFromStyles();
        }// end function

    }
}
