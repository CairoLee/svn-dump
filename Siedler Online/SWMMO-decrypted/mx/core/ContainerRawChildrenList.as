package mx.core
{
    import flash.display.*;
    import flash.geom.*;
    import mx.core.*;

    public class ContainerRawChildrenList extends Object implements IChildList
    {
        private var owner:Container;
        static const VERSION:String = "3.5.0.12683";

        public function ContainerRawChildrenList(param1:Container)
        {
            this.owner = param1;
            return;
        }// end function

        public function addChild(param1:DisplayObject) : DisplayObject
        {
            return owner.rawChildren_addChild(param1);
        }// end function

        public function getChildIndex(param1:DisplayObject) : int
        {
            return owner.rawChildren_getChildIndex(param1);
        }// end function

        public function setChildIndex(param1:DisplayObject, param2:int) : void
        {
            owner.rawChildren_setChildIndex(param1, param2);
            return;
        }// end function

        public function getChildByName(param1:String) : DisplayObject
        {
            return owner.rawChildren_getChildByName(param1);
        }// end function

        public function removeChildAt(param1:int) : DisplayObject
        {
            return owner.rawChildren_removeChildAt(param1);
        }// end function

        public function get numChildren() : int
        {
            return owner.$numChildren;
        }// end function

        public function addChildAt(param1:DisplayObject, param2:int) : DisplayObject
        {
            return owner.rawChildren_addChildAt(param1, param2);
        }// end function

        public function getObjectsUnderPoint(param1:Point) : Array
        {
            return owner.rawChildren_getObjectsUnderPoint(param1);
        }// end function

        public function contains(param1:DisplayObject) : Boolean
        {
            return owner.rawChildren_contains(param1);
        }// end function

        public function removeChild(param1:DisplayObject) : DisplayObject
        {
            return owner.rawChildren_removeChild(param1);
        }// end function

        public function getChildAt(param1:int) : DisplayObject
        {
            return owner.rawChildren_getChildAt(param1);
        }// end function

    }
}
