package Specialists
{
    import GO.*;
    import Interface.*;
    import PathFinding.*;
    import SettlerKI.*;

    public class cSpecialistTask_WithSettler extends cSpecialistTask
    {
        private var mDestinationPath:cPathObject;
        private var mDestinationPathPos:int = 0;
        protected var mSettler:cSettler = null;

        public function cSpecialistTask_WithSettler(param1:cGeneralInterface, param2:int, param3:cSpecialist, param4:int, param5:int)
        {
            super(param1, param2, param3, param4, param5);
            return;
        }// end function

        protected function GetSettler() : cSettler
        {
            return this.mSettler;
        }// end function

        public function GetSettlerGridIndex() : int
        {
            if (this.mSettler == null)
            {
                return -1;
            }
            return gCalculations.ConvertPixelPosToStreetGridPos(this.mSettler.GetXInt(), this.mSettler.GetYInt());
        }// end function

        public function RemoveSettler() : void
        {
            if (this.mSettler == null)
            {
                return;
            }
            (this.mSettler.mSettlerKi as cSettlerAI_WalkToTarget).DeactivateKI();
            this.mSettler = null;
            return;
        }// end function

        protected function SpawnSettler(param1:int, param2:int) : void
        {
            this.mSettler = mGeneralInterface.mCurrentPlayerZone.mSettlerKIManager.SpawnSettler(this, param1, param2, "General");
            return;
        }// end function

        override protected function NextPhase() : void
        {
            super.NextPhase();
            this.CheckSettler();
            return;
        }// end function

        public function SetPathPos(param1:int) : void
        {
            this.mDestinationPathPos = param1;
            return;
        }// end function

        public function IncPathPos(param1:int) : void
        {
            this.mDestinationPathPos = this.mDestinationPathPos + param1;
            return;
        }// end function

        override protected function SetTaskPhase(param1:int) : void
        {
            super.SetTaskPhase(param1);
            this.CheckSettler();
            return;
        }// end function

        protected function SetDestinationPath(param1:cPathObject) : void
        {
            this.mDestinationPath = param1;
            return;
        }// end function

        public function GetPathPos() : int
        {
            return this.mDestinationPathPos;
        }// end function

        public function GetDestinationPath() : cPathObject
        {
            return this.mDestinationPath;
        }// end function

        protected function CheckSettler() : void
        {
            return;
        }// end function

    }
}
