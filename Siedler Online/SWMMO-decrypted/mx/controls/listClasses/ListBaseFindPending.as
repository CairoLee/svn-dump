package mx.controls.listClasses
{
    import mx.collections.*;

    public class ListBaseFindPending extends Object
    {
        public var currentIndex:int;
        public var stopIndex:int;
        public var startingBookmark:CursorBookmark;
        public var searchString:String;
        public var offset:int;
        public var bookmark:CursorBookmark;
        static const VERSION:String = "3.5.0.12683";

        public function ListBaseFindPending(param1:String, param2:CursorBookmark, param3:CursorBookmark, param4:int, param5:int, param6:int)
        {
            this.searchString = param1;
            this.startingBookmark = param2;
            this.bookmark = param3;
            this.offset = param4;
            this.currentIndex = param5;
            this.stopIndex = param6;
            return;
        }// end function

    }
}
