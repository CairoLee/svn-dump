package mx.events
{
    import flash.events.*;
    import mx.controls.*;
    import mx.controls.listClasses.*;

    public class MenuEvent extends ListEvent
    {
        public var index:int;
        public var label:String;
        public var item:Object;
        public var menuBar:MenuBar;
        public var menu:Menu;
        public static const MENU_HIDE:String = "menuHide";
        public static const ITEM_ROLL_OVER:String = "itemRollOver";
        public static const CHANGE:String = "change";
        public static const ITEM_ROLL_OUT:String = "itemRollOut";
        public static const ITEM_CLICK:String = "itemClick";
        public static const MENU_SHOW:String = "menuShow";
        static const VERSION:String = "3.5.0.12683";

        public function MenuEvent(param1:String, param2:Boolean = false, param3:Boolean = true, param4:MenuBar = null, param5:Menu = null, param6:Object = null, param7:IListItemRenderer = null, param8:String = null, param9:int = -1)
        {
            super(param1, param2, param3);
            this.menuBar = param4;
            this.menu = param5;
            this.item = param6;
            this.itemRenderer = param7;
            this.label = param8;
            this.index = param9;
            return;
        }// end function

        override public function clone() : Event
        {
            return new MenuEvent(type, bubbles, cancelable, menuBar, menu, item, itemRenderer, label, index);
        }// end function

    }
}
