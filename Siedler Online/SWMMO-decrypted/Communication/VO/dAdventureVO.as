package Communication.VO
{
    import mx.collections.*;

    public class dAdventureVO extends Object
    {
        public var players:ArrayCollection;
        public var adventureDuration:int;
        public var ownerPlayerID:int;
        public var adventureID:int;
        public var adventureDefinitionName:String;
        public var startTime:Number;
        public var state:int;
        public var serverDownDuration:int;

        public function dAdventureVO()
        {
            this.players = new ArrayCollection();
            return;
        }// end function

    }
}
