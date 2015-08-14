package mx.core
{
    import flash.display.*;
    import mx.utils.*;

    public class FlexShape extends Shape
    {
        static const VERSION:String = "3.5.0.12683";

        public function FlexShape()
        {
            try
            {
                name = NameUtil.createUniqueName(this);
            }
            catch (e:Error)
            {
            }
            return;
        }// end function

        override public function toString() : String
        {
            return NameUtil.displayObjectToString(this);
        }// end function

    }
}
