package Communication.VO
{

    public class dStreetVO extends Object
    {
        public var grid:int;
        public var streetBits:int = 0;
        public var streetVariation:int = 0;
        public var streetCityLevel:int = 0;
        public var playerID:int;

        public function dStreetVO()
        {
            return;
        }// end function

        public function toString() : String
        {
            return "<dDepositVO playerID=\'" + this.playerID + "\' streetBits=\'" + this.streetBits + "\' streetCityLevel=\'" + this.streetCityLevel + " streetVariation=\'" + this.streetVariation + "\' grid=\'" + this.grid + "\' />";
        }// end function

    }
}
