package mx.effects.effectClasses
{

    public class PropertyChanges extends Object
    {
        public var target:Object;
        public var start:Object;
        public var end:Object;
        static const VERSION:String = "3.5.0.12683";

        public function PropertyChanges(param1:Object)
        {
            end = {};
            start = {};
            this.target = param1;
            return;
        }// end function

    }
}
