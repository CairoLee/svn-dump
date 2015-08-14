package GOSets
{
    import __AS3__.vec.*;

    public class cGOSet extends Object
    {
        public var mGOSetItem_vector:Vector.<cGOSetItem>;
        public var mName_string:String;
        public var mID:int;

        public function cGOSet()
        {
            this.mGOSetItem_vector = new Vector.<cGOSetItem>;
            return;
        }// end function

        public function Animate(param1:Number) : void
        {
            var _loc_2:cGOSetItem = null;
            for each (_loc_2 in this.mGOSetItem_vector)
            {
                
                _loc_2.mSpriteLib.Animate(param1);
            }
            return;
        }// end function

        public function Render(param1:int, param2:int) : void
        {
            var _loc_3:cGOSetItem = null;
            for each (_loc_3 in this.mGOSetItem_vector)
            {
                
                _loc_3.mSpriteLib.RenderPos(param1 + _loc_3.mOffsetX, param2 + _loc_3.mOffsetY);
            }
            return;
        }// end function

    }
}
