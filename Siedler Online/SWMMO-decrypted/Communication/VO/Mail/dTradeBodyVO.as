package Communication.VO.Mail
{
    import Communication.VO.*;
    import flash.utils.*;

    public class dTradeBodyVO extends Object
    {
        public var offer:dResourceVO;
        public var costs:dResourceVO;

        public function dTradeBodyVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.offer = param1.readObject() as dResourceVO;
            this.costs = param1.readObject() as dResourceVO;
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeObject(this.offer);
            param1.writeObject(this.costs);
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "<dTradeBodyVO ";
            _loc_1 = _loc_1 + ("offer=\'" + this.offer + "\' ");
            _loc_1 = _loc_1 + ("costs=\'" + this.costs + "\' ");
            _loc_1 = _loc_1 + " />\n";
            return _loc_1;
        }// end function

    }
}
