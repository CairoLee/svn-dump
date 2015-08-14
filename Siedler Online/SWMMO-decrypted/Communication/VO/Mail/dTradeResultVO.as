package Communication.VO.Mail
{
    import Communication.VO.*;
    import flash.utils.*;

    public class dTradeResultVO extends Object
    {
        public var result:dResourceVO;

        public function dTradeResultVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.result = param1.readObject() as dResourceVO;
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeObject(this.result);
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "<dTradeResultVO ";
            _loc_1 = _loc_1 + ("result=\'" + _loc_1 + "\' ");
            _loc_1 = _loc_1 + " />\n";
            return _loc_1;
        }// end function

    }
}
