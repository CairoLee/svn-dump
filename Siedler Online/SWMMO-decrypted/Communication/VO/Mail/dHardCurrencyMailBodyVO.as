package Communication.VO.Mail
{
    import flash.utils.*;

    public class dHardCurrencyMailBodyVO extends Object
    {
        public var amount:int;
        public var text:String;

        public function dHardCurrencyMailBodyVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.text = param1.readUTF();
            this.amount = param1.readInt();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeUTF(this.text);
            param1.writeInt(this.amount);
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "<dFriendBodyVO ";
            _loc_1 = _loc_1 + ("text=\'" + this.text + "\' ");
            _loc_1 = _loc_1 + ("amount=\'" + this.amount + "\' ");
            _loc_1 = _loc_1 + " />\n";
            return _loc_1;
        }// end function

    }
}
