package mx.controls.listClasses
{
    import mx.collections.*;

    public class ListBaseSeekPending extends Object
    {
        public var offset:int;
        public var bookmark:CursorBookmark;
        static const VERSION:String = "3.5.0.12683";

        public function ListBaseSeekPending(param1:CursorBookmark, param2:int)
        {
            this.bookmark = param1;
            this.offset = param2;
            return;
        }// end function

    }
}
