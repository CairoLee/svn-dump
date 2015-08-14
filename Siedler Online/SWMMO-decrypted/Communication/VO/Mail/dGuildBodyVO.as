package Communication.VO.Mail
{

    public class dGuildBodyVO extends Object
    {
        public var guildName:String;
        public var bannerId:int;

        public function dGuildBodyVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "<dBattleReportBodyVO ";
            _loc_1 = _loc_1 + ("guildName=\'" + this.guildName + "\' ");
            _loc_1 = _loc_1 + ("bannerId=\'" + this.bannerId + "\' ");
            _loc_1 = _loc_1 + " />\n";
            return _loc_1;
        }// end function

    }
}
