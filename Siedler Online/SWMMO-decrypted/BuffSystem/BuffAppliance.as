package BuffSystem
{
    import Communication.VO.*;
    import Enums.*;
    import Interface.*;

    public class BuffAppliance extends Object
    {
        private var buffDefinition:cBuffDefinition;
        private var gridOldPosition:int;
        private var startTime:Number;
        private var gridPosition:int;
        private var resourceName_string:String;
        public var mDirtyIndicator:int = 0;
        private var applianceMode:int = 0;

        public function BuffAppliance(param1:cBuffDefinition, param2:int, param3:int, param4:String)
        {
            this.buffDefinition = param1;
            this.applianceMode = param2;
            this.gridPosition = param3;
            this.resourceName_string = param4;
            return;
        }// end function

        public function GetResourceName_string() : String
        {
            return this.resourceName_string;
        }// end function

        public function SetStartTime(param1:Number) : void
        {
            this.startTime = param1;
            return;
        }// end function

        public function Calculate(param1:Number) : Boolean
        {
            if (param1 - this.startTime >= this.buffDefinition.getDuration(this.applianceMode))
            {
                return true;
            }
            return false;
        }// end function

        public function GetBuffDefinition() : cBuffDefinition
        {
            return this.buffDefinition;
        }// end function

        public function CreateBuffApplianceVOFromBuff() : dBuffApplianceVO
        {
            var _loc_1:* = new dBuffApplianceVO();
            _loc_1.gridPosition = this.gridPosition;
            _loc_1.buffName_string = this.buffDefinition.GetType_string();
            _loc_1.startTime = this.startTime;
            _loc_1.applianceMode = this.applianceMode;
            _loc_1.resourceName_string = this.resourceName_string;
            return _loc_1;
        }// end function

        public function GetGridPosition() : int
        {
            return this.gridPosition;
        }// end function

        public function toString() : String
        {
            return "<BuffAppliance " + "id=\'" + this.buffDefinition.GetId() + "\' " + "gridPosition=\'" + this.gridPosition + "\' " + "buffname=\'" + this.buffDefinition.GetName_string() + "\' " + "startTime=\'" + this.startTime + "\' " + "applianceMode=\'" + BUFF_APPLIANCE_MODE.toString(this.applianceMode) + "\' " + " />\n";
        }// end function

        public function BuffRemoved(param1:cGeneralInterface) : void
        {
            if (this.buffDefinition.GetName_string().indexOf("ChangeColorScheme") == 0)
            {
                if (gGfxResource.SetFilter(null, FILTER_SOURCE.BUFF))
                {
                    gGfxResource.ApplyZoom(param1.mZoom.GetInvScaleFactor());
                    param1.mCurrentPlayerZone.SetBackgroundHasChanged(true);
                    param1.mCurrentPlayerZone.SetAllRescaleDirtyFlags();
                }
            }
            return;
        }// end function

        public function SetGridPosition(param1:int) : void
        {
            this.gridOldPosition = this.gridPosition;
            this.gridPosition = param1;
            this.mDirtyIndicator = this.mDirtyIndicator | DIRTY_INDICATOR.MODIFIED_BIT;
            return;
        }// end function

        public function GetGridOldPosition() : int
        {
            return this.gridOldPosition;
        }// end function

        public function GetStartTime() : Number
        {
            return this.startTime;
        }// end function

        public function GetApplicanceMode() : int
        {
            return this.applianceMode;
        }// end function

        public static function CreateBuffApplianceFromVO(param1:dBuffApplianceVO) : BuffAppliance
        {
            var _loc_2:* = global.map_BuffName_BuffDefinition[param1.buffName_string];
            var _loc_3:* = new BuffAppliance(_loc_2, param1.applianceMode, param1.gridPosition, param1.resourceName_string);
            _loc_3.startTime = param1.startTime;
            _loc_3.applianceMode = param1.applianceMode;
            return _loc_3;
        }// end function

    }
}
