package mx.containers
{

    public class TitleWindow extends Panel
    {
        static const VERSION:String = "3.5.0.12683";
        static var createAccessibilityImplementation:Function;

        public function TitleWindow()
        {
            return;
        }// end function

        public function set showCloseButton(param1:Boolean) : void
        {
            _showCloseButton = param1;
            return;
        }// end function

        public function get showCloseButton() : Boolean
        {
            return _showCloseButton;
        }// end function

        override protected function initializeAccessibility() : void
        {
            if (createAccessibilityImplementation != null)
            {
                createAccessibilityImplementation(this);
            }
            return;
        }// end function

    }
}
