package mx.controls.listClasses
{
    import mx.collections.*;

    public class ListBaseSelectionPending extends Object
    {
        public var offset:int;
        public var stopData:Object;
        public var index:int;
        public var placeHolder:CursorBookmark;
        public var bookmark:CursorBookmark;
        public var incrementing:Boolean;
        public var transition:Boolean;
        static const VERSION:String = "3.5.0.12683";

        public function ListBaseSelectionPending(param1:Boolean, param2:int, param3:Object, param4:Boolean, param5:CursorBookmark, param6:CursorBookmark, param7:int)
        {
            this.incrementing = param1;
            this.index = param2;
            this.stopData = param3;
            this.transition = param4;
            this.placeHolder = param5;
            this.bookmark = param6;
            this.offset = param7;
            return;
        }// end function

    }
}
