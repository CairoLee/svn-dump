package Communication.VO
{
    import flash.utils.*;

    public class dFreeLandscapeVO extends Object
    {
        public var name_string:String = null;
        public var x:int;
        public var y:int;

        public function dFreeLandscapeVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.name_string = param1.readUTF();
            this.x = param1.readInt();
            this.y = param1.readInt();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeUTF(this.name_string);
            param1.writeInt(this.x);
            param1.writeInt(this.y);
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:* = "<dLandscapeVO name=\'" + this.name_string;
            _loc_1 = _loc_1 + ("\' x=\'" + this.x);
            _loc_1 = _loc_1 + ("\' y=\'" + this.y);
            _loc_1 = _loc_1 + "\' />";
            return _loc_1;
        }// end function

    }
}
