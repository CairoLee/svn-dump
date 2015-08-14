package ServerState
{
    import Enums.*;
    import GUI.Loca.*;

    public class cLoginQueueStatus extends Object
    {
        private var mAvg:Number;
        private var mQueuePos:int = 2.14748e+009;
        private var mTime:Array;
        private var mAdvancedPositions:int;
        private var mSum:Number;

        public function cLoginQueueStatus()
        {
            globalFlash.gui.mNewsWindow.SetLoadingMessageFromBB(cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LoginQueueInit"));
            this.mAdvancedPositions = 0;
            this.mAvg = 0;
            this.mSum = 0;
            this.mTime = [];
            this.mTime[0] = new Date().getTime();
            return;
        }// end function

        public function update(param1:String) : void
        {
            var _loc_4:int = 0;
            var _loc_5:int = 0;
            var _loc_6:String = null;
            var _loc_2:* = String(param1);
            var _loc_3:* = _loc_2.split("&");
            if (_loc_3.length == 2)
            {
                _loc_4 = int(String(_loc_3[0]).split("=")[1]);
                _loc_5 = int(String(_loc_3[1]).split("=")[1]);
                if (_loc_4 < this.mQueuePos)
                {
                    var _loc_7:String = this;
                    var _loc_8:* = this.mAdvancedPositions + 1;
                    _loc_7.mAdvancedPositions = _loc_8;
                    this.mQueuePos = _loc_4;
                }
                if (this.mAdvancedPositions > 0)
                {
                    this.mAvg = this.mSum / this.mAdvancedPositions * this.mQueuePos;
                }
                _loc_6 = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LoginQueuePosition", [this.mQueuePos, _loc_4]);
                if (this.mAvg > 0)
                {
                    _loc_6 = _loc_6 + (" " + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LoginQueueRemainingTime", [cLocaManager.GetInstance().FormatDuration(this.mAvg)]));
                }
                else
                {
                    _loc_6 = _loc_6 + (" " + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "LoginQueueApproxTime"));
                }
                globalFlash.gui.mNewsWindow.SetLoadingMessageFromBB(_loc_6);
                this.mTime[1] = new Date().getTime();
                this.mSum = this.mSum + (this.mTime[1] - this.mTime[0]);
                this.mTime[0] = this.mTime[1];
            }
            return;
        }// end function

        public function dispose() : void
        {
            this.mAdvancedPositions = -1;
            this.mSum = 0;
            this.mAvg = 0;
            this.mTime.length = 0;
            this.mTime = null;
            return;
        }// end function

    }
}
