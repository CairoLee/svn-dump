package Map
{
    import GOSets.*;
    import nLib.*;

    public class cGoSetListAnimationItem extends Object
    {
        public var gridPos:int;
        public var animGoSetListContainer:cGOSetList = null;
        public var runningTime:Number;
        public var pixelPos:cPosInt;
        public var object:Object;

        public function cGoSetListAnimationItem()
        {
            this.pixelPos = new cPosInt();
            return;
        }// end function

    }
}
