package Communication.VO
{
    import flash.utils.*;

    public class dDataIntStringVO extends Object
    {
        public var value:int;
        public var string:String;

        public function dDataIntStringVO()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.string = param1.readUTF();
            this.value = param1.readInt();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeUTF(this.string);
            param1.writeInt(this.value);
            return;
        }// end function

        public function toString() : String
        {
            return "<dDataIntStringVO string=\'" + this.string + "\' value=\'" + this.value + "\' />";
        }// end function

    }
}
