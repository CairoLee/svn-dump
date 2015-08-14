package Communication.VO
{
    import Enums.*;

    public class dGameTickCommandVO extends Object
    {
        public var data:Object;
        public var mode:int;
        public var playerID:int;
        public var time:Number;

        public function dGameTickCommandVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:* = "<dGameTickCommandVO time=\'" + this.time + "\' mode=\'" + this.mode + "\' modeString=\'" + COMMAND.GetString(this.mode) + "\'>\n";
            if (this.data != null)
            {
                _loc_1 = _loc_1 + " <Data>\n";
                _loc_1 = _loc_1 + ("  " + this.data + "\n");
                _loc_1 = _loc_1 + " </Data>\n";
            }
            _loc_1 = _loc_1 + "</dGameTickCommandVO>\n";
            return _loc_1;
        }// end function

    }
}
