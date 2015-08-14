package mx.effects.effectClasses
{
    import flash.events.*;
    import mx.containers.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.events.*;
    import mx.styles.*;

    public class ResizeInstance extends TweenEffectInstance
    {
        private var left:Object;
        private var origPercentHeight:Number;
        private var parentOrigHorizontalScrollPolicy:String = "";
        private var explicitWidthSet:Boolean;
        public var widthFrom:Number;
        private var origExplicitHeight:Number;
        private var _widthTo:Number;
        private var parentOrigVerticalScrollPolicy:String = "";
        private var right:Object;
        private var origExplicitWidth:Number;
        private var restoreAutoLayoutArray:Array;
        private var restoreVisibleArray:Array;
        private var bottom:Object;
        private var heightSet:Boolean;
        private var _heightBy:Number;
        private var widthSet:Boolean;
        private var origHorizontalScrollPolicy:String = "";
        private var numHideEffectsPlaying:Number = 0;
        private var top:Object;
        private var origVerticalScrollPolicy:String = "";
        private var _heightTo:Number;
        private var explicitHeightSet:Boolean;
        public var hideChildrenTargets:Array;
        private var origPercentWidth:Number;
        public var heightFrom:Number;
        private var _widthBy:Number;
        static const VERSION:String = "3.5.0.12683";

        public function ResizeInstance(param1:Object)
        {
            super(param1);
            needToLayout = true;
            return;
        }// end function

        public function set widthBy(param1:Number) : void
        {
            _widthBy = param1;
            widthSet = !isNaN(param1);
            return;
        }// end function

        public function get heightTo() : Number
        {
            return _heightTo;
        }// end function

        public function set heightTo(param1:Number) : void
        {
            _heightTo = param1;
            heightSet = !isNaN(param1);
            return;
        }// end function

        private function hidePanelChildren() : Boolean
        {
            var _loc_3:Object = null;
            var _loc_4:Number = NaN;
            if (!hideChildrenTargets)
            {
                return false;
            }
            restoreVisibleArray = [];
            restoreAutoLayoutArray = [];
            var _loc_1:* = hideChildrenTargets.length;
            var _loc_2:int = 0;
            while (_loc_2 < _loc_1)
            {
                
                _loc_3 = hideChildrenTargets[_loc_2];
                if (_loc_3 is Panel)
                {
                    _loc_4 = numHideEffectsPlaying;
                    _loc_3.addEventListener(EffectEvent.EFFECT_START, eventHandler);
                    _loc_3.dispatchEvent(new Event("resizeStart"));
                    _loc_3.removeEventListener(EffectEvent.EFFECT_START, eventHandler);
                    if (numHideEffectsPlaying == _loc_4)
                    {
                        makePanelChildrenInvisible(Panel(_loc_3), _loc_2);
                    }
                }
                _loc_2++;
            }
            return numHideEffectsPlaying > 0;
        }// end function

        override public function play() : void
        {
            super.play();
            calculateExplicitDimensionChanges();
            var _loc_1:* = hidePanelChildren();
            if (target is IStyleClient)
            {
                left = target.getStyle("left");
                if (left != undefined)
                {
                    target.setStyle("left", undefined);
                }
                right = target.getStyle("right");
                if (right != undefined)
                {
                    target.setStyle("right", undefined);
                }
                top = target.getStyle("top");
                if (top != undefined)
                {
                    target.setStyle("top", undefined);
                }
                bottom = target.getStyle("bottom");
                if (bottom != undefined)
                {
                    target.setStyle("bottom", undefined);
                }
            }
            if (!_loc_1)
            {
                startResizeTween();
            }
            return;
        }// end function

        public function set heightBy(param1:Number) : void
        {
            _heightBy = param1;
            heightSet = !isNaN(param1);
            return;
        }// end function

        override public function initEffect(event:Event) : void
        {
            super.initEffect(event);
            if (event is ResizeEvent && event.type == ResizeEvent.RESIZE)
            {
                if (isNaN(widthBy))
                {
                    if (isNaN(widthFrom))
                    {
                        widthFrom = ResizeEvent(event).oldWidth;
                    }
                    if (isNaN(widthTo))
                    {
                        _widthTo = target.width;
                    }
                }
                if (isNaN(heightBy))
                {
                    if (isNaN(heightFrom))
                    {
                        heightFrom = ResizeEvent(event).oldHeight;
                    }
                    if (isNaN(heightTo))
                    {
                        _heightTo = target.height;
                    }
                }
            }
            return;
        }// end function

        public function get widthBy() : Number
        {
            return _widthBy;
        }// end function

        override public function onTweenUpdate(param1:Object) : void
        {
            EffectManager.suspendEventHandling();
            target.width = Math.round(param1[0]);
            target.height = Math.round(param1[1]);
            if (tween)
            {
                tween.needToLayout = true;
            }
            needToLayout = true;
            EffectManager.resumeEventHandling();
            return;
        }// end function

        override function eventHandler(event:Event) : void
        {
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_2:* = event.target as Container;
            super.eventHandler(event);
            if (event.type == EffectEvent.EFFECT_START)
            {
                _loc_2.addEventListener(EffectEvent.EFFECT_END, eventHandler);
                var _loc_6:* = numHideEffectsPlaying + 1;
                numHideEffectsPlaying = _loc_6;
            }
            else if (event.type == EffectEvent.EFFECT_END)
            {
                _loc_2.removeEventListener(EffectEvent.EFFECT_END, eventHandler);
                _loc_3 = hideChildrenTargets.length;
                _loc_4 = 0;
                while (_loc_4 < _loc_3)
                {
                    
                    if (hideChildrenTargets[_loc_4] == _loc_2)
                    {
                        break;
                    }
                    _loc_4++;
                }
                makePanelChildrenInvisible(_loc_2, _loc_4);
                if (--numHideEffectsPlaying == 0)
                {
                    startResizeTween();
                }
            }
            return;
        }// end function

        public function set widthTo(param1:Number) : void
        {
            _widthTo = param1;
            widthSet = !isNaN(param1);
            return;
        }// end function

        private function calculateExplicitDimensionChanges() : void
        {
            var _loc_5:Container = null;
            var _loc_6:Container = null;
            var _loc_1:* = propertyChanges ? (propertyChanges.end["explicitWidth"]) : (undefined);
            var _loc_2:* = propertyChanges ? (propertyChanges.end["explicitHeight"]) : (undefined);
            var _loc_3:* = propertyChanges ? (propertyChanges.end["percentWidth"]) : (undefined);
            var _loc_4:* = propertyChanges ? (propertyChanges.end["percentHeight"]) : (undefined);
            if (!heightSet)
            {
                if (_loc_4 !== undefined)
                {
                    origPercentHeight = _loc_4;
                }
                else
                {
                    origPercentHeight = target.percentHeight;
                }
                if (isNaN(origPercentHeight))
                {
                    if (_loc_2 !== undefined)
                    {
                        origExplicitHeight = _loc_2;
                    }
                    else
                    {
                        origExplicitHeight = target.explicitHeight;
                    }
                }
                _loc_5 = target as Container;
                if (_loc_5 && _loc_5.verticalScrollBar == null)
                {
                    origVerticalScrollPolicy = _loc_5.verticalScrollPolicy;
                    _loc_5.verticalScrollPolicy = ScrollPolicy.OFF;
                }
                if (target.parent)
                {
                    _loc_6 = target.parent as Container;
                    if (_loc_6 && _loc_6.verticalScrollBar == null)
                    {
                        parentOrigVerticalScrollPolicy = _loc_6.verticalScrollPolicy;
                        _loc_6.verticalScrollPolicy = ScrollPolicy.OFF;
                    }
                }
            }
            if (!widthSet)
            {
                if (_loc_3 !== undefined)
                {
                    origPercentWidth = _loc_3;
                }
                else
                {
                    origPercentWidth = target.percentWidth;
                }
                if (isNaN(origPercentWidth))
                {
                    if (_loc_1 !== undefined)
                    {
                        origExplicitWidth = _loc_1;
                    }
                    else
                    {
                        origExplicitWidth = target.explicitWidth;
                    }
                }
                _loc_5 = target as Container;
                if (_loc_5 && _loc_5.horizontalScrollBar == null)
                {
                    origHorizontalScrollPolicy = _loc_5.horizontalScrollPolicy;
                    _loc_5.horizontalScrollPolicy = ScrollPolicy.OFF;
                }
                if (target.parent)
                {
                    _loc_6 = target.parent as Container;
                    if (_loc_6 && _loc_6.horizontalScrollBar == null)
                    {
                        parentOrigHorizontalScrollPolicy = _loc_6.horizontalScrollPolicy;
                        _loc_6.horizontalScrollPolicy = ScrollPolicy.OFF;
                    }
                }
            }
            if (isNaN(widthFrom))
            {
                widthFrom = !isNaN(widthTo) && !isNaN(widthBy) ? (widthTo - widthBy) : (target.width);
            }
            if (isNaN(widthTo))
            {
                if (isNaN(widthBy) && propertyChanges && (propertyChanges.end["width"] !== undefined || _loc_1 !== undefined))
                {
                    if (_loc_1 !== undefined && !isNaN(_loc_1))
                    {
                        explicitWidthSet = true;
                        _widthTo = _loc_1;
                    }
                    else
                    {
                        _widthTo = propertyChanges.end["width"];
                    }
                }
                else
                {
                    _widthTo = !isNaN(widthBy) ? (widthFrom + widthBy) : (target.width);
                }
            }
            if (isNaN(heightFrom))
            {
                heightFrom = !isNaN(heightTo) && !isNaN(heightBy) ? (heightTo - heightBy) : (target.height);
            }
            if (isNaN(heightTo))
            {
                if (isNaN(heightBy) && propertyChanges && (propertyChanges.end["height"] !== undefined || _loc_2 !== undefined))
                {
                    if (_loc_2 !== undefined && !isNaN(_loc_2))
                    {
                        explicitHeightSet = true;
                        _heightTo = _loc_2;
                    }
                    else
                    {
                        _heightTo = propertyChanges.end["height"];
                    }
                }
                else
                {
                    _heightTo = !isNaN(heightBy) ? (heightFrom + heightBy) : (target.height);
                }
            }
            return;
        }// end function

        private function makePanelChildrenInvisible(param1:Container, param2:Number) : void
        {
            var _loc_4:IUIComponent = null;
            var _loc_3:Array = [];
            var _loc_5:* = param1.numChildren;
            var _loc_6:int = 0;
            while (_loc_6 < _loc_5)
            {
                
                _loc_4 = IUIComponent(param1.getChildAt(_loc_6));
                if (_loc_4.visible)
                {
                    _loc_3.push(_loc_4);
                    _loc_4.setVisible(false, true);
                }
                _loc_6++;
            }
            _loc_4 = param1.horizontalScrollBar;
            if (_loc_4 && _loc_4.visible)
            {
                _loc_3.push(_loc_4);
                _loc_4.setVisible(false, true);
            }
            _loc_4 = param1.verticalScrollBar;
            if (_loc_4 && _loc_4.visible)
            {
                _loc_3.push(_loc_4);
                _loc_4.setVisible(false, true);
            }
            restoreVisibleArray[param2] = _loc_3;
            if (param1.autoLayout)
            {
                param1.autoLayout = false;
                restoreAutoLayoutArray[param2] = true;
            }
            return;
        }// end function

        override public function end() : void
        {
            if (!tween)
            {
                calculateExplicitDimensionChanges();
                onTweenEnd(playReversed ? ([widthFrom, heightFrom]) : ([widthTo, heightTo]));
            }
            super.end();
            return;
        }// end function

        private function startResizeTween() : void
        {
            EffectManager.startVectorEffect(IUIComponent(target));
            tween = createTween(this, [widthFrom, heightFrom], [widthTo, heightTo], duration);
            applyTweenStartValues();
            return;
        }// end function

        public function get heightBy() : Number
        {
            return _heightBy;
        }// end function

        private function restorePanelChildren() : void
        {
            var _loc_1:int = 0;
            var _loc_2:int = 0;
            var _loc_3:IUIComponent = null;
            var _loc_4:Array = null;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            if (hideChildrenTargets)
            {
                _loc_1 = hideChildrenTargets.length;
                _loc_2 = 0;
                while (_loc_2 < _loc_1)
                {
                    
                    _loc_3 = hideChildrenTargets[_loc_2];
                    _loc_4 = restoreVisibleArray[_loc_2];
                    if (_loc_4)
                    {
                        _loc_5 = _loc_4.length;
                        _loc_6 = 0;
                        while (_loc_6 < _loc_5)
                        {
                            
                            _loc_4[_loc_6].setVisible(true, true);
                            _loc_6++;
                        }
                    }
                    if (restoreAutoLayoutArray[_loc_2])
                    {
                        Container(_loc_3).autoLayout = true;
                    }
                    _loc_3.dispatchEvent(new Event("resizeEnd"));
                    _loc_2++;
                }
            }
            return;
        }// end function

        override public function onTweenEnd(param1:Object) : void
        {
            var _loc_2:Container = null;
            var _loc_3:Container = null;
            EffectManager.endVectorEffect(IUIComponent(target));
            Application.application.callLater(restorePanelChildren);
            super.onTweenEnd(param1);
            EffectManager.suspendEventHandling();
            if (!heightSet)
            {
                target.percentHeight = origPercentHeight;
                target.explicitHeight = origExplicitHeight;
                if (origVerticalScrollPolicy != "")
                {
                    _loc_2 = target as Container;
                    if (_loc_2)
                    {
                        _loc_2.verticalScrollPolicy = origVerticalScrollPolicy;
                        origVerticalScrollPolicy = "";
                    }
                }
                if (parentOrigVerticalScrollPolicy != "" && target.parent)
                {
                    _loc_3 = target.parent as Container;
                    if (_loc_3)
                    {
                        _loc_3.verticalScrollPolicy = parentOrigVerticalScrollPolicy;
                        parentOrigVerticalScrollPolicy = "";
                    }
                }
            }
            if (!widthSet)
            {
                target.percentWidth = origPercentWidth;
                target.explicitWidth = origExplicitWidth;
                if (origHorizontalScrollPolicy != "")
                {
                    _loc_2 = target as Container;
                    if (_loc_2)
                    {
                        _loc_2.horizontalScrollPolicy = origHorizontalScrollPolicy;
                        origHorizontalScrollPolicy = "";
                    }
                }
                if (parentOrigHorizontalScrollPolicy != "" && target.parent)
                {
                    _loc_3 = target.parent as Container;
                    if (_loc_3)
                    {
                        _loc_3.horizontalScrollPolicy = parentOrigHorizontalScrollPolicy;
                        parentOrigHorizontalScrollPolicy = "";
                    }
                }
            }
            if (left != undefined)
            {
                target.setStyle("left", left);
            }
            if (right != undefined)
            {
                target.setStyle("right", right);
            }
            if (top != undefined)
            {
                target.setStyle("top", top);
            }
            if (bottom != undefined)
            {
                target.setStyle("bottom", bottom);
            }
            EffectManager.resumeEventHandling();
            return;
        }// end function

        public function get widthTo() : Number
        {
            return _widthTo;
        }// end function

    }
}
