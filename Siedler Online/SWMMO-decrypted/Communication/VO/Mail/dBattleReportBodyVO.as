package Communication.VO.Mail
{
    import flash.utils.*;

    public class dBattleReportBodyVO extends Object
    {
        public var battleScript:String;

        public function dBattleReportBodyVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.battleScript = param1.readUTF();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeUTF(this.battleScript);
            return;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "<dBattleReportBodyVO ";
            _loc_1 = _loc_1 + ("battleScript=\'" + this.battleScript + "\' ");
            _loc_1 = _loc_1 + " />\n";
            return _loc_1;
        }// end function

    }
}
