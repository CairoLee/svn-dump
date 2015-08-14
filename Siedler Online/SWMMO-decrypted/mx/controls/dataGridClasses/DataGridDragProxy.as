package mx.controls.dataGridClasses
{
    import flash.display.*;
    import flash.geom.*;
    import mx.controls.listClasses.*;
    import mx.core.*;

    public class DataGridDragProxy extends UIComponent
    {
        static const VERSION:String = "3.5.0.12683";

        public function DataGridDragProxy()
        {
            return;
        }// end function

        override protected function createChildren() : void
        {
            var _loc_4:IListItemRenderer = null;
            var _loc_5:UIComponent = null;
            var _loc_6:Object = null;
            var _loc_7:Number = NaN;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:DataGridColumn = null;
            var _loc_11:IListItemRenderer = null;
            var _loc_12:DataGridListData = null;
            var _loc_13:Point = null;
            super.createChildren();
            var _loc_1:* = DataGridBase(owner).selectedItems;
            var _loc_2:* = _loc_1.length;
            var _loc_3:int = 0;
            while (_loc_3 < _loc_2)
            {
                
                _loc_4 = DataGridBase(owner).itemToItemRenderer(_loc_1[_loc_3]);
                if (!_loc_4)
                {
                }
                else
                {
                    _loc_6 = _loc_1[_loc_3];
                    _loc_5 = new UIComponent();
                    addChild(DisplayObject(_loc_5));
                    _loc_7 = 0;
                    if (DataGridBase(owner).visibleLockedColumns)
                    {
                        _loc_8 = DataGridBase(owner).visibleLockedColumns.length;
                        _loc_9 = 0;
                        while (_loc_9 < _loc_8)
                        {
                            
                            _loc_10 = DataGridBase(owner).visibleLockedColumns[_loc_9];
                            _loc_11 = DataGridBase(owner).createColumnItemRenderer(_loc_10, false, _loc_6);
                            _loc_12 = new DataGridListData(_loc_10.itemToLabel(_loc_6), _loc_10.dataField, _loc_10.colNum, "", DataGridBase(owner));
                            if (_loc_11 is IDropInListItemRenderer)
                            {
                                IDropInListItemRenderer(_loc_11).listData = _loc_6 ? (_loc_12) : (null);
                            }
                            _loc_11.data = _loc_6;
                            _loc_11.styleName = DataGridBase(owner);
                            _loc_11.visible = true;
                            _loc_5.addChild(DisplayObject(_loc_11));
                            _loc_11.setActualSize(_loc_10.width, _loc_4.height);
                            _loc_11.move(_loc_7, 0);
                            _loc_7 = _loc_7 + _loc_10.width;
                            _loc_9++;
                        }
                    }
                    _loc_8 = DataGridBase(owner).visibleColumns.length;
                    _loc_9 = 0;
                    while (_loc_9 < _loc_8)
                    {
                        
                        _loc_10 = DataGridBase(owner).visibleColumns[_loc_9];
                        _loc_11 = DataGridBase(owner).createColumnItemRenderer(_loc_10, false, _loc_6);
                        _loc_12 = new DataGridListData(_loc_10.itemToLabel(_loc_6), _loc_10.dataField, _loc_10.colNum, "", DataGridBase(owner));
                        if (_loc_11 is IDropInListItemRenderer)
                        {
                            IDropInListItemRenderer(_loc_11).listData = _loc_6 ? (_loc_12) : (null);
                        }
                        _loc_11.data = _loc_6;
                        _loc_11.styleName = DataGridBase(owner);
                        _loc_11.visible = true;
                        _loc_5.addChild(DisplayObject(_loc_11));
                        _loc_11.setActualSize(_loc_10.width, _loc_4.height);
                        _loc_11.move(_loc_7, 0);
                        _loc_7 = _loc_7 + _loc_10.width;
                        _loc_9++;
                    }
                    _loc_5.setActualSize(_loc_7, _loc_4.height);
                    _loc_13 = new Point(0, 0);
                    _loc_13 = DisplayObject(_loc_4).localToGlobal(_loc_13);
                    _loc_13 = DataGridBase(owner).globalToLocal(_loc_13);
                    _loc_5.y = _loc_13.y;
                    measuredHeight = _loc_5.y + _loc_5.height;
                    measuredWidth = _loc_7;
                }
                _loc_3++;
            }
            invalidateDisplayList();
            return;
        }// end function

        override protected function measure() : void
        {
            var _loc_3:UIComponent = null;
            super.measure();
            var _loc_1:Number = 0;
            var _loc_2:Number = 0;
            var _loc_4:int = 0;
            while (_loc_4 < numChildren)
            {
                
                _loc_3 = getChildAt(_loc_4) as UIComponent;
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
