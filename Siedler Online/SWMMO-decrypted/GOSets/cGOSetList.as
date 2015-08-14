package GOSets
{
    import GO.*;
    import __AS3__.vec.*;

    public class cGOSetList extends Object
    {
        public var mType_string:String;
        public var mGOSetListItem_vector:Vector.<cGOSetListItem>;
        public var mBlocking_vector:Vector.<cBlockingData>;
        private var mController:cGOSetListController;
        private var mCurrentRenderedItem:cGOSetListItem;
        public var mName_string:String;

        public function cGOSetList(param1:cGOSetListController)
        {
            this.mGOSetListItem_vector = new Vector.<cGOSetListItem>;
            this.mBlocking_vector = new Vector.<cBlockingData>;
            if (param1 != null)
            {
                param1.SetGOSetList(this);
            }
            this.mController = param1;
            return;
        }// end function

        public function Animate(param1:Number) : void
        {
            this.mCurrentRenderedItem.mGOSet.Animate(param1);
            return;
        }// end function

        public function SetSubTypeCurrentGOSetItem(param1:int) : void
        {
            var _loc_2:cGOSetItem = null;
            for each (_loc_2 in this.mCurrentRenderedItem.mGOSet.mGOSetItem_vector)
            {
                
                _loc_2.mSpriteLib.SetSubTypeAndFrame(param1, 0);
            }
            return;
        }// end function

        public function SetValue(param1:Number) : void
        {
            if (this.mController != null)
            {
                this.mController.SetValue(param1);
            }
            return;
        }// end function

        public function Render(param1:int, param2:int) : void
        {
            this.mCurrentRenderedItem.mGOSet.Render(param1, param2);
            return;
        }// end function

        public function SetCurrentRenderedItem(param1:cGOSetListItem) : void
        {
            this.mCurrentRenderedItem = param1;
            return;
        }// end function

    }
}
