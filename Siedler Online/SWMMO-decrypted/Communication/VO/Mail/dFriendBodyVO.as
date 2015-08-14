package Communication.VO.Mail
{
    import Communication.VO.*;
    import flash.utils.*;

    public class dFriendBodyVO extends Object
    {
        public var player:dPlayerListItemVO;

        public function dFriendBodyVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.player = param1.readObject() as dPlayerListItemVO;
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeObject(this.player);
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "<dFriendBodyVO ";
            _loc_1 = _loc_1 + ("player=\'" + this.player + "\' ");
            _loc_1 = _loc_1 + " />\n";
            return _loc_1;
        }// end function

    }
}
