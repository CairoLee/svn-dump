package com.bluebyte.bluefire.flex3.defaultClient
{
    import flash.events.*;
    import flash.text.*;
    import flash.utils.*;
    import mx.binding.utils.*;
    import mx.collections.*;
    import mx.controls.*;
    import mx.events.*;

    public class ChatHistoryList extends List
    {
        private var noautoscrollPosition:int = 0;
        private var vScrollBarTwinkled:Boolean = false;
        private var vScrollBar:VScrollBar;
        private var scrollBarTwinkleTimer:Timer;
        private var scrolledToEnd:Boolean = false;
        private var autoScroll:Boolean = true;
        private var ss:StyleSheet;
        private var oldScrolledToEnd:int = 0;
        private var format:TextFormat;
        private var CSSFile:Class;
        private static var MSG_MAX:int = 9999999;

        public function ChatHistoryList()
        {
            this.scrollBarTwinkleTimer = new Timer(1000);
            this.CSSFile = ChatHistoryList_CSSFile;
            ChatMessageItemRenderer.STYLESHEET = new StyleSheet();
            ChatMessageItemRenderer.STYLESHEET.parseCSS(new this.CSSFile().toString());
            this.addEventListener(MouseEvent.MOUSE_WHEEL, this.HandleMouseWheel);
            this.scrollBarTwinkleTimer.addEventListener(TimerEvent.TIMER, this.scrollBarTwinkle);
            ChangeWatcher.watch(this, "maxVerticalScrollPosition", this.HandleMaxVerticalChanged);
            return;
        }// end function

        private function HandleMaxVerticalChanged(event:Event = null) : void
        {
            if (this.autoscroll)
            {
                if (!dataProvider)
                {
                    return;
                }
                while ((dataProvider as ArrayCollection).length > MSG_MAX)
                {
                    
                    (dataProvider as ArrayCollection).removeItemAt(0);
                }
                this.validateNow();
                this.verticalScrollPosition = this.maxVerticalScrollPosition;
            }
            return;
        }// end function

        private function swapScrollBarTwinkle() : void
        {
            if (this.vScrollBarTwinkled)
            {
                this.vScrollBarTwinkled = false;
            }
            else
            {
                this.vScrollBarTwinkled = true;
            }
            return;
        }// end function

        private function disableScrollBarTwinkle() : void
        {
            return;
        }// end function

        private function scrollBarTwinkle(event:Event) : void
        {
            this.swapScrollBarTwinkle();
            return;
        }// end function

        private function handleCreationComplete(event:Event) : void
        {
            var _loc_2:int = 0;
            while (_loc_2 < this.numChildren)
            {
                
                if (this.getChildAt(_loc_2) is VScrollBar)
                {
                    this.vScrollBar = VScrollBar(this.getChildAt(_loc_2));
                    break;
                }
                _loc_2++;
            }
            return;
        }// end function

        private function HandleMouseWheel(event:MouseEvent) : void
        {
            this.ScrollList(-event.delta / Math.abs(event.delta) * 3);
            return;
        }// end function

        public function ScrollList(param1:int) : void
        {
            if (this.verticalScrollPosition + param1 < this.maxVerticalScrollPosition)
            {
                this.autoscroll = false;
            }
            else
            {
                this.autoscroll = true;
            }
            if (this.verticalScrollPosition + param1 < 0)
            {
                this.verticalScrollPosition = 0;
            }
            else
            {
                this.verticalScrollPosition = this.verticalScrollPosition + param1;
            }
            return;
        }// end function

        public function set autoscroll(param1:Boolean) : void
        {
            var _loc_2:* = this.autoscroll;
            if (_loc_2 !== param1)
            {
                this._517768508autoscroll = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "autoscroll", _loc_2, param1));
            }
            return;
        }// end function

        override public function set dataProvider(param1:Object) : void
        {
            if (param1 != this.dataProvider)
            {
                super.dataProvider = param1;
                callLater(this.HandleMaxVerticalChanged);
                this.autoScroll = true;
            }
            return;
        }// end function

        private function set _517768508autoscroll(param1:Boolean) : void
        {
            this.autoScroll = param1;
            if (this.autoScroll)
            {
                this.verticalScrollPosition = this.maxVerticalScrollPosition;
            }
            return;
        }// end function

        public function get autoscroll() : Boolean
        {
            return this.autoScroll;
        }// end function

    }
}
