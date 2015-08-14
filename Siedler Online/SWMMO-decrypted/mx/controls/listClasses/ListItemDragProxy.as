package mx.controls.listClasses
{
    import flash.display.*;
    import mx.core.*;

    public class ListItemDragProxy extends UIComponent
    {
        static const VERSION:String = "3.5.0.12683";

        public function ListItemDragProxy()
        {
            return;
        }// end function

        override protected function createChildren() : void
        {
            var _loc_4:IListItemRenderer = null;
            var _loc_5:IListItemRenderer = null;
            var _loc_6:ListBaseContentHolder = null;
            var _loc_7:BaseListData = null;
            super.createChildren();
            var _loc_1:* = ListBase(owner).selectedItems;
            var _loc_2:* = _loc_1.length;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                _loc_4 = ListBase(owner).itemToItemRenderer(_loc_1[_loc_3]);
                if (!_loc_4)
                {
                }
                else
                {
                    _loc_5 = ListBase(owner).createItemRenderer(_loc_1[_loc_3]);
                    _loc_5.styleName = ListBase(owner);
                    if (_loc_5 is IDropInListItemRenderer)
                    {
                        _loc_7 = IDropInListItemRenderer(_loc_4).listData;
                        IDropInListItemRenderer(_loc_5).listData = _loc_1[_loc_3] ? (_loc_7) : (null);
                    }
                    _loc_5.data = _loc_1[_loc_3];
                    addChild(DisplayObject(_loc_5));
                    _loc_6 = _loc_4.parent as ListBaseContentHolder;
                    _loc_5.setActualSize(_loc_4.width, _loc_4.height);
                    _loc_5.x = _loc_4.x + _loc_6.leftOffset;
                    _loc_5.y = _loc_4.y + _loc_6.topOffset;
                    measuredHeight = Math.max(measuredHeight, _loc_5.y + _loc_5.height);
                    measuredWidth = Math.max(measuredWidth, _loc_5.x + _loc_5.width);
                    _loc_5.visible = true;
                }
                _loc_3++;
            }
            invalidateDisplayList();
            return;
        }// end function

        override protected function measure() : void
        {
            var _loc_3:IListItemRenderer = null;
            super.measure();
            var _loc_1:Number = 0;
            var _loc_2:Number = 0;
            var _loc_4:int = 0;
            while (_loc_4 < numChildren)
            {
                
                _loc_3 = getChildAt(_loc_4) as IListItemRenderer;
                if (_loc_3)
                {
                    _loc_1 = Math.max(_loc_1, _loc_3.x + _loc_3.width);
                    _loc_2 = Math.max(_loc_2, _loc_3.y + _loc_3.height);
                }
                _loc_4++;
            }
            var _loc_5:* = _loc_1;
            measuredMinWidth = _loc_1;
            measuredWidth = _loc_5;
            var _loc_5:* = _loc_2;
            measuredMinHeight = _loc_2;
            measuredHeight = _loc_5;
            return;
        }// end function

    }
}
