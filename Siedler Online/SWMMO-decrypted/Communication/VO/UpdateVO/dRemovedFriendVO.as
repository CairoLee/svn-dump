package Communication.VO.UpdateVO
{
    import flash.utils.*;

    public class dRemovedFriendVO extends Object
    {
        public var removedFriendID:int;
        public var friendRemoverID:int;

        public function dRemovedFriendVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.friendRemoverID = param1.readInt();
            this.removedFriendID = param1.readInt();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.friendRemoverID);
            param1.writeInt(this.removedFriendID);
            return;
        }// end function

        public function toString() : String
        {
            return "<dRemovedFriendVO friendRemoverID=\'" + this.friendRemoverID + "\' removedFriendID=\'" + this.removedFriendID + "\' />";
        }// end function

    }
}
