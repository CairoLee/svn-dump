package mx.containers
{
    import flash.display.*;
    import mx.containers.utilityClasses.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.styles.*;

    public class Form extends Container
    {
        var layoutObject:BoxLayout;
        private var measuredLabelWidth:Number;
        static const VERSION:String = "3.5.0.12683";
        private static var classInitialized:Boolean = false;

        public function Form()
        {
            layoutObject = new BoxLayout();
            if (!classInitialized)
            {
                initializeClass();
                classInitialized = true;
            }
            showInAutomationHierarchy = true;
            mx_internal::layoutObject.target = this;
            mx_internal::layoutObject.direction = BoxDirection.VERTICAL;
            return;
        }// end function

        override public function addChild(param1:DisplayObject) : DisplayObject
        {
            invalidateLabelWidth();
            return super.addChild(param1);
        }// end function

        override public function styleChanged(param1:String) : void
        {
            if (!param1 || param1 == "styleName" || StyleManager.isSizeInvalidatingStyle(param1))
            {
                invalidateLabelWidth();
            }
            super.styleChanged(param1);
            return;
        }// end function

        override public function removeChildAt(param1:int) : DisplayObject
        {
            invalidateLabelWidth();
            return super.removeChildAt(param1);
        }// end function

        function calculateLabelWidth() : Number
        {
            var _loc_5:DisplayObject = null;
            if (!isNaN(measuredLabelWidth))
            {
                return measuredLabelWidth;
            }
            var _loc_1:Number = 0;
            var _loc_2:Boolean = false;
            var _loc_3:* = numChildren;
            var _loc_4:int = 0;
            while (_loc_4 < _loc_3)
            {
                
                _loc_5 = getChildAt(_loc_4);
                if (_loc_5 is FormItem && FormItem(_loc_5).includeInLayout)
                {
                    _loc_1 = Math.max(_loc_1, FormItem(_loc_5).getPreferredLabelWidth());
                    _loc_2 = true;
                }
                _loc_4++;
            }
            if (_loc_2)
            {
                measuredLabelWidth = _loc_1;
            }
            return _loc_1;
        }// end function

        function invalidateLabelWidth() : void
        {
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            var _loc_3:IUIComponent = null;
            if (!isNaN(measuredLabelWidth) && initialized)
            {
                measuredLabelWidth = NaN;
                _loc_1 = numChildren;
                _loc_2 = 0;
                while (_loc_2 < _loc_1)
                {
                    
                    _loc_3 = IUIComponent(getChildAt(_loc_2));
                    if (_loc_3 is IInvalidating)
                    {
                        IInvalidating(_loc_3).invalidateSize();
                    }
                    _loc_2++;
                }
            }
            return;
        }// end function

        public function get maxLabelWidth() : Number
        {
            var _loc_3:DisplayObject = null;
            var _loc_4:Label = null;
            var _loc_1:* = numChildren;
            var _loc_2:int = 0;
            while (_loc_2 < _loc_1)
            {
                
                _loc_3 = getChildAt(_loc_2);
                if (_loc_3 is FormItem)
                {
                    _loc_4 = FormItem(_loc_3).itemLabel;
                    if (_loc_4)
                    {
                        return _loc_4.width;
                    }
                }
                _loc_2++;
            }
            return 0;
        }// end function

        override protected function updateDisplayList(param1:Number, param2:Number) : void
        {
            super.updateDisplayList(param1, param2);
            mx_internal::layoutObject.updateDisplayList(param1, param2);
            return;
        }// end function

        override public function addChildAt(param1:DisplayObject, param2:int) : DisplayObject
        {
            invalidateLabelWidth();
            return super.addChildAt(param1, param2);
        }// end function

        override protected function measure() : void
        {
            super.measure();
            mx_internal::layoutObject.measure();
            calculateLabelWidth();
            return;
        }// end function

        override public function removeChild(param1:DisplayObject) : DisplayObject
        {
            invalidateLabelWidth();
            return super.removeChild(param1);
        }// end function

        private static function initializeClass() : void
        {
            StyleManager.registerInheritingStyle("labelWidth");
            StyleManager.registerSizeInvalidatingStyle("labelWidth");
            StyleManager.registerInheritingStyle("indicatorGap");
            StyleManager.registerSizeInvalidatingStyle("indicatorGap");
            return;
        }// end function

    }
}
