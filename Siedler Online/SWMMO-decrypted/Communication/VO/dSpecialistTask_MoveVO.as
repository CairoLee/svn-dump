package Communication.VO
{
    import flash.utils.*;

    public class dSpecialistTask_MoveVO extends dSpecialistTaskVO
    {
        public var newGarrisonGridIdx:int;
        public var currentGarrisonGridIdx:int;
        public var pathPos:int;

        public function dSpecialistTask_MoveVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.currentGarrisonGridIdx = param1.readInt();
            this.newGarrisonGridIdx = param1.readInt();
            this.pathPos = param1.readInt();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.currentGarrisonGridIdx);
            param1.writeInt(this.newGarrisonGridIdx);
            param1.writeInt(this.pathPos);
            return;
        }// end function

        override public function toString() : String
        {
            return "<dSpecialistTask_MoveVO " + super.dataString() + " currentGarrisonGridIdx=\'" + this.currentGarrisonGridIdx + " newGarrisonGridIdx=\'" + this.newGarrisonGridIdx + " pathPos=\'" + this.pathPos + "\' />";
        }// end function

    }
}
