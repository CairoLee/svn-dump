package mx.containers.utilityClasses
{
    import mx.core.*;

    public class FlexChildInfo extends Object
    {
        public var flex:Number = 0;
        public var preferred:Number = 0;
        public var percent:Number;
        public var width:Number;
        public var height:Number;
        public var size:Number = 0;
        public var max:Number;
        public var min:Number;
        public var child:IUIComponent;
        static const VERSION:String = "3.5.0.12683";

        public function FlexChildInfo()
        {
            return;
        }// end function

    }
}
