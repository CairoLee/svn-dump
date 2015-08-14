package GUI.Components
{
    import flash.events.*;
    import flash.text.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class CustomText extends Text
    {

        public function CustomText()
        {
            this.addEventListener(FlexEvent.CREATION_COMPLETE, this.resize);
            return;
        }// end function

        override public function set text(param1:String) : void
        {
            super.text = param1 + "\n";
            return;
        }// end function

        private function resize(event:Event) : void
        {
            var _loc_2:String = this;
            if (_loc_2.mx_internal::getTextField().numLines > 1)
            {
                this.validateNow();
                var _loc_2:String = this;
                _loc_2.mx_internal::getTextField().autoSize = TextFieldAutoSize.LEFT;
                var _loc_2:String = this;
                this.height = _loc_2.mx_internal::getTextField().height + 1;
            }
            return;
        }// end function

    }
}
