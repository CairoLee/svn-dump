package Communication.VO
{
    import Enums.*;

    public class dBuffApplianceVO extends Object
    {
        public var gridPosition:int;
        public var applianceMode:int;
        public var buffName_string:String;
        public var startTime:Number;
        public var resourceName_string:String;

        public function dBuffApplianceVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            return "<dBuffApplianceVO " + "buffName_string=\'" + this.buffName_string + "\' " + "gridPosition=\'" + this.gridPosition + "\' " + "startTime=\'" + this.startTime + "\' " + "applianceMode=\'" + BUFF_APPLIANCE_MODE.toString(this.applianceMode) + "\' " + "resourceName=\'" + this.resourceName_string + "\' " + " />";
        }// end function

    }
}
