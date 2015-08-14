package Communication.VO
{
    import flash.utils.*;

    public class dLandingFieldVO extends Object
    {
        public var id:int;
        public var grid:int;

        public function dLandingFieldVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.grid = param1.readInt();
            this.id = param1.readInt();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.grid);
            param1.writeInt(this.id);
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:* = "<dLandingFieldVO grid=\'" + this.grid;
            _loc_1 = _loc_1 + ("\' id=\'" + this.id);
            _loc_1 = _loc_1 + "\' />";
            return _loc_1;
        }// end function

    }
}
