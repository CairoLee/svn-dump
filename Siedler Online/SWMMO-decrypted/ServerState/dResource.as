package ServerState
{
    import flash.utils.*;

    public class dResource extends Object
    {
        public var name_string:String;
        public var group_string:String;
        public var amount:int;
        public var maxLimit:int;

        public function dResource()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.name_string = param1.readUTF();
            this.amount = param1.readInt();
            this.maxLimit = param1.readInt();
            this.group_string = param1.readUTF();
            return;
        }// end function

        public function toString() : String
        {
            return "<Resource \'" + this.name_string + "\' amount=" + this.amount + "\' maxLimit=" + this.maxLimit + "\' group_string=" + this.group_string + " >";
        }// end function

        public function Init(param1:String, param2:int) : dResource
        {
            this.name_string = param1;
            this.amount = param2;
            return this;
        }// end function

        public function GetFromDResource(param1:dResource) : void
        {
            this.amount = param1.amount;
            this.name_string = param1.name_string;
            this.group_string = param1.group_string;
            this.maxLimit = param1.maxLimit;
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeUTF(this.name_string);
            param1.writeInt(this.amount);
            param1.writeInt(this.maxLimit);
            param1.writeUTF(this.group_string);
            return;
        }// end function

    }
}
