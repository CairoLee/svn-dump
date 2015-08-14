package Communication.VO
{
    import flash.utils.*;

    public class dBackgroundTileVO extends Object
    {
        public var name_string:String = null;

        public function dBackgroundTileVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.name_string = param1.readUTF();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeUTF(this.name_string);
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:* = "<dBackgroundTileVO name=\'" + this.name_string + "\' />";
            return _loc_1;
        }// end function

    }
}
