package Communication.VO
{
    import Communication.VO.UpdateVO.*;

    public class dAdventurePlayerListItemVO extends dPlayerListItemVO
    {
        public var status:int;

        public function dAdventurePlayerListItemVO()
        {
            return;
        }// end function

        public function InitFromAdventurePlayerVO(param1:dAdventurePlayerVO) : dAdventurePlayerListItemVO
        {
            this.id = param1.playerID;
            this.status = param1.status;
            this.username = param1.playerName;
            this.avatarId = param1.avatarID;
            return this;
        }// end function

        public function InitFromPlayerListItemVO(param1:dPlayerListItemVO) : dAdventurePlayerListItemVO
        {
            this.adventureVO = param1.adventureVO;
            this.avatarId = param1.avatarId;
            this.id = param1.id;
            this.onlineStatus = param1.onlineStatus;
            this.playerLevel = param1.playerLevel;
            this.username = param1.username;
            return this;
        }// end function

    }
}
