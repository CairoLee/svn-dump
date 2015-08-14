package Communication.VO
{
    import nLib.*;

    public class dProductionProtocollVO extends Object
    {
        public var buildingGrid:int;
        public var currentTime:Number;
        public var currentResourceNr:int;
        public var lastBuildingMode:int;
        public var processCntr:int;
        public var resourceName:String;
        public var phase:int;
        public var text:String;

        public function dProductionProtocollVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            return "<productionProtocollVO [n=" + this.resourceName + "] [grid=" + this.buildingGrid + "] [cNr=" + this.currentResourceNr + "] [processCntr=" + this.processCntr + "] [lastMode=" + this.lastBuildingMode + "] [time=" + gMisc.ConvertDoubleToString_string(this.currentTime) + "] [phase=" + this.phase + "] [t=" + this.text + "] >";
        }// end function

    }
}
