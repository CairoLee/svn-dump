package Communication.VO.UpdateVO
{

    public class dAlertMessageVO extends Object
    {
        public var intData:int;
        public var alertMessage:String;

        public function dAlertMessageVO()
        {
            return;
        }// end function

        public function Init(param1:String, param2:int) : dAlertMessageVO
        {
            this.alertMessage = param1;
            this.intData = param2;
            return this;
        }// end function

        public function toString() : String
        {
            return "<dAlertMessageVO alertMessage=\'" + this.alertMessage + "\' intData=\'" + this.intData + "\' />";
        }// end function

    }
}
