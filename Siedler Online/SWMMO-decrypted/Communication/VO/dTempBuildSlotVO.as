package Communication.VO
{

    public class dTempBuildSlotVO extends Object
    {
        public var timeOfPurchase:Number;
        public var buildingGridPos:int;
        public var dirtyIndicator:int;

        public function dTempBuildSlotVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            return "<dTempBuildSlotVO timeOfPurchase=\'" + this.timeOfPurchase + "\'buildingGridPos=\'" + this.buildingGridPos + "\'/>";
        }// end function

    }
}
