package mx.controls.listClasses
{
    import flash.display.*;
    import mx.collections.*;
    import mx.core.*;

    public class ListBaseContentHolder extends UIComponent
    {
        public var listItems:Array;
        public var topOffset:Number = 0;
        public var rightOffset:Number = 0;
        private var maskShape:Shape;
        public var selectionLayer:Sprite;
        private var parentList:ListBase;
        public var iterator:IViewCursor;
        public var rowInfo:Array;
        public var bottomOffset:Number = 0;
        public var leftOffset:Number = 0;
        public var visibleData:Object;
        var allowItemSizeChangeNotification:Boolean = true;
        static const VERSION:String = "3.5.0.12683";

        public function ListBaseContentHolder(param1:ListBase)
        {
            var _loc_2:Graphics = null;
            visibleData = {};
            listItems = [];
            rowInfo = [];
            this.parentList = param1;
            setStyle("backgroundColor", "");
            setStyle("borderStyle", "none");
            if (!selectionLayer)
            {
                selectionLayer = new FlexSprite();
                selectionLayer.name = "selectionLayer";
                selectionLayer.mouseEnabled = false;
                addChild(selectionLayer);
                _loc_2 = selectionLayer.graphics;
                _loc_2.beginFill(0, 0);
                _loc_2.drawRect(0, 0, 10, 10);
                _loc_2.endFill();
            }
            return;
        }// end function

        override public function set focusPane(param1:Sprite) : void
        {
            var _loc_2:Graphics = null;
            if (param1)
            {
                if (!maskShape)
                {
                    maskShape = new FlexShape();
                    maskShape.name = "mask";
                    _loc_2 = maskShape.graphics;
                    _loc_2.beginFill(16777215);
                    _loc_2.drawRect(-2, -2, parentList.width + 2, parentList.height + 2);
                    _loc_2.endFill();
                    addChild(maskShape);
                }
                maskShape.visible = false;
                param1.mask = maskShape;
            }
            else if (parentList.focusPane.mask == maskShape)
            {
                parentList.focusPane.mask = null;
            }
            parentList.focusPane = param1;
            param1.x = x;
            param1.y = y;
            return;
        }// end function

        public function get heightExcludingOffsets() : Number
        {
            return height + topOffset - bottomOffset;
        }// end function

        public function get widthExcludingOffsets() : Number
        {
            return width + leftOffset - rightOffset;
        }// end function

        override public function invalidateSize() : void
        {
            if (allowItemSizeChangeNotification)
            {
                parentList.invalidateList();
            }
            return;
        }// end function

        function getParentList() : ListBase
        {
            return parentList;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            var _loc_3:* = selectionLayer.graphics;
            _loc_3.clear();
            if (param1 > 0 && param2 > 0)
            {
                _loc_3.beginFill(8421504, 0);
                _loc_3.drawRect(0, 0, param1, param2);
                _loc_3.endFill();
            }
            if (maskShape)
            {
                maskShape.width = param1;
                maskShape.height = param2;
            }
            return;
        }// end function

    }
}
