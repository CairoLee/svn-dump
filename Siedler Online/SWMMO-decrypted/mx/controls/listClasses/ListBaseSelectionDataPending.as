package mx.controls.listClasses
{
    import mx.collections.*;

    public class ListBaseSelectionDataPending extends Object
    {
        public var items:Array;
        public var index:int;
        public var bookmark:CursorBookmark;
        public var offset:int;
        public var useFind:Boolean;
        static const VERSION:String = "3.5.0.12683";

        public function ListBaseSelectionDataPending(param1:Boolean, param2:int, param3:Array, param4:CursorBookmark, param5:int)
        {
            this.useFind = param1;
            this.index = param2;
            this.items = param3;
            this.bookmark = param4;
            this.offset = param5;
            return;
        }// end function

    }
}
