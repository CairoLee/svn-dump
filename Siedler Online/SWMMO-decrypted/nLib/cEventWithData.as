package nLib
{
    import flash.events.*;

    public class cEventWithData extends Event
    {
        public var mType_string:String;
        public var mObject:Object;

        public function cEventWithData(param1:String, param2:String, param3:Object, param4:Boolean, param5:Boolean)
        {
            super(param1, param4, param5);
            this.mType_string = param2;
            this.mObject = param3;
            return;
        }// end function

    }
}
