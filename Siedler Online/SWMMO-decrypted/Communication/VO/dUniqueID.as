package Communication.VO
{
    import flash.utils.*;

    public class dUniqueID extends Object
    {
        public var uniqueID1:int = 0;
        public var uniqueID2:int = 0;

        public function dUniqueID()
        {
            return;
        }// end function

        public function Init(param1:int, param2:int) : dUniqueID
        {
            this.uniqueID1 = param1;
            this.uniqueID2 = param2;
            return this;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.uniqueID1 = param1.readInt();
            this.uniqueID2 = param1.readInt();
            return;
        }// end function

        public function toString() : String
        {
            return this.uniqueID1 + "." + this.uniqueID2;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.uniqueID1);
            param1.writeInt(this.uniqueID2);
            return;
        }// end function

        public function eq(param1:dUniqueID) : Boolean
        {
            return param1.uniqueID1 == this.uniqueID1 && param1.uniqueID2 == this.uniqueID2;
        }// end function

        public function equals(param1:Object) : Boolean
        {
            var _loc_2:Boolean = false;
            var _loc_3:Boolean = false;
            if (param1 is dUniqueID)
            {
                _loc_2 = this.uniqueID1 == (param1 as dUniqueID).uniqueID1;
                _loc_3 = this.uniqueID2 == (param1 as dUniqueID).uniqueID2;
                return _loc_2 && _loc_3;
            }
            return false;
        }// end function

    }
}
