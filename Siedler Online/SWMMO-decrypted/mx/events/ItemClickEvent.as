package mx.events
{
    import flash.display.*;
    import flash.events.*;

    public class ItemClickEvent extends Event
    {
        public var relatedObject:InteractiveObject;
        public var index:int;
        public var label:String;
        public var item:Object;
        static const VERSION:String = "3.5.0.12683";
        public static const ITEM_CLICK:String = "itemClick";

        public function ItemClickEvent(param1:String, param2:Boolean = false, param3:Boolean = false, param4:String = null, param5:int = -1, param6:InteractiveObject = null, param7:Object = null)
        {
            super(param1, param2, param3);
            this.label = param4;
            this.index = param5;
            this.relatedObject = param6;
            this.item = param7;
            return;
        }// end function

        override public function clone() : Event
        {
            return new ItemClickEvent(type, bubbles, cancelable, label, index, relatedObject, item);
        }// end function

    }
}
