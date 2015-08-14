package Communication.VO.Mail
{
    import Communication.VO.*;
    import flash.utils.*;

    public class dBuffedDataVO extends Object
    {
        public var buffedObjectGridIdx:int;
        public var buffVO:dBuffVO;

        public function dBuffedDataVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.buffedObjectGridIdx = param1.readInt();
            this.buffVO = param1.readObject() as dBuffVO;
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.buffedObjectGridIdx);
            param1.writeObject(this.buffVO);
            return;
        }// end function

        public function toString() : String
        {
            return "<dBuffedDataVO buffedObjectGridIdx=\'" + this.buffedObjectGridIdx + "\' buffVO=\'" + this.buffVO + "\' />";
        }// end function

    }
}
