package Communication.VO.UpdateVO
{
    import Enums.*;

    public class dAdventurePlayerVO extends Object
    {
        public var adventureID:int;
        public var playerName:String;
        public var status:int = 0;
        public var avatarID:int;
        public var playerID:int;

        public function dAdventurePlayerVO()
        {
            return;
        }// end function

        public function Init(param1:int, param2:int) : dAdventurePlayerVO
        {
            this.adventureID = param1;
            this.playerID = param2;
            return this;
        }// end function

        public function toString() : String
        {
            return "<dAdventurePlayerVO adventureID=\'" + this.adventureID + "\' playerID=\'" + this.playerID + "\' status=\'" + ADVENTURE_INVITATION_STATUS.toString(this.status) + "\' />";
        }// end function

    }
}
