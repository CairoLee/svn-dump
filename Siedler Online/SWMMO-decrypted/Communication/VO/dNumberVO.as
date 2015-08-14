package Communication.VO
{
    import flash.utils.*;

    public class dNumberVO extends Object
    {
        public var value:Number;

        public function dNumberVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.value = param1.readDouble();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeDouble(this.value);
            return;
        }// end function

        public function toString() : String
        {
            return "<dNumberVO value=\'" + this.value + "\' />";
        }// end function

    }
}
