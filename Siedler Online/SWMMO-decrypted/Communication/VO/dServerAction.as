package Communication.VO
{
    import flash.utils.*;

    public class dServerAction extends Object
    {
        public var endGrid:int;
        public var grid:int;
        public var data:Object;
        public var type:int;

        public function dServerAction()
        {
            return;
        }// end function

        public function readExternal(param1:IDataInput) : void
        {
            this.type = param1.readInt();
            this.grid = param1.readInt();
            this.endGrid = param1.readInt();
            this.data = param1.readObject();
            return;
        }// end function

        public function writeExternal(param1:IDataOutput) : void
        {
            param1.writeInt(this.type);
            param1.writeInt(this.grid);
            param1.writeInt(this.endGrid);
            param1.writeObject(this.data);
            return;
        }// end function

        public function toString() : String
        {
            return "<dServerAction type=\'" + this.type + "\' grid=\'" + this.grid + "\' endGrid=\'" + this.endGrid + "\' data=\'" + this.data + "\' />";
        }// end function

    }
}
