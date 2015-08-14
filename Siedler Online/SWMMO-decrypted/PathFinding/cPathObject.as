package PathFinding
{
    import __AS3__.vec.*;

    public class cPathObject extends Object
    {
        public var dest_vector:Vector.<dPathObjectItem>;
        public var pathLenX10000:int;
        public var pathLenX20000:int;
        public var state:int;
        public static const STATE_GOTO_DESTINATION:int = 1;
        public static const STATE_IDLE:int = 0;

        public function cPathObject()
        {
            this.Reset();
            return;
        }// end function

        public function RefreshLength() : void
        {
            var _loc_1:* = this.dest_vector.length;
            var _loc_2:* = 2 * _loc_1;
            this.pathLenX10000 = _loc_1 * defines.INT_SCALE_FACTOR;
            this.pathLenX20000 = _loc_2 * defines.INT_SCALE_FACTOR;
            return;
        }// end function

        public function toString() : String
        {
            var _loc_3:dPathObjectItem = null;
            var _loc_1:String = "PathObject[";
            var _loc_2:Boolean = true;
            for each (_loc_3 in this.dest_vector)
            {
                
                if (!_loc_2)
                {
                    _loc_1 = _loc_1 + ", ";
                }
                else
                {
                    _loc_2 = false;
                }
                _loc_1 = _loc_1 + _loc_3.streetGridIdx;
            }
            _loc_1 = _loc_1 + "]";
            return _loc_1;
        }// end function

        public function Reset() : void
        {
            this.dest_vector = new Vector.<dPathObjectItem>;
            this.state = STATE_IDLE;
            this.pathLenX10000 = 0;
            this.pathLenX20000 = 0;
            return;
        }// end function

        public function CalculateGridIdxForPathPos(param1:int) : int
        {
            var _loc_2:* = param1 as Number;
            var _loc_3:* = int(_loc_2 / defines.INT_SCALE_FACTOR);
            if (_loc_3 >= this.dest_vector.length)
            {
                _loc_3 = this.dest_vector.length - 1;
            }
            return this.dest_vector[_loc_3].streetGridIdx;
        }// end function

        public function PushPathObjectItem(param1:dPathObjectItem) : void
        {
            this.dest_vector.push(param1);
            return;
        }// end function

    }
}
