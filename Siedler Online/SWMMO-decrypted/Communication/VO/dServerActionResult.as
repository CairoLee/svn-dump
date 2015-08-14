package Communication.VO
{
    import flash.utils.*;

    public class dServerActionResult extends Object
    {
        public var errorCode:int;
        public var clientTime:Number;
        public var data:Object;

        public function dServerActionResult(param1:int = 0, param2:Object = null, param3:Number = 0)
        {
            this.errorCode = param1;
            this.data = param2;
            this.clientTime = param3;
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeDouble(this.clientTime);
            param1.writeInt(this.errorCode);
            param1.writeObject(this.data);
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.clientTime = param1.readDouble();
            this.errorCode = param1.readInt();
            this.data = param1.readObject();
            return;
        }// end function

        public function toString() : String
        {
            return "<dServerActionResult clientTime=" + this.clientTime + " errorCode=" + this.errorCode + " data=" + this.data + " >";
        }// end function

    }
}
