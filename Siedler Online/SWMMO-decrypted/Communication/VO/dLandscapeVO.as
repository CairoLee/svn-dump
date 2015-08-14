package Communication.VO
{
    import flash.utils.*;

    public class dLandscapeVO extends Object
    {
        public var playerID:int;
        public var name_string:String = null;
        public var grid:int;

        public function dLandscapeVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.playerID = param1.readInt();
            this.name_string = param1.readUTF();
            this.grid = param1.readInt();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.playerID);
            param1.writeUTF(this.name_string);
            param1.writeInt(this.grid);
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:* = "<dLandscapeVO name=\'" + this.name_string;
            _loc_1 = _loc_1 + ("\' grid=\'" + this.grid);
            _loc_1 = _loc_1 + ("\' playerID=\'" + this.playerID);
            _loc_1 = _loc_1 + "\' />";
            return _loc_1;
        }// end function

    }
}
