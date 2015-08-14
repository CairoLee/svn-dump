package GUI.Events
{
    import flash.display.*;
    import flash.events.*;
    import mx.events.*;

    public class TrackMissionEvent extends ItemClickEvent
    {
        public var track:Boolean = false;
        public static const TRACK_MISSION:String = "trackMission";

        public function TrackMissionEvent(param1:String, param2:Boolean = false, param3:Boolean = false, param4:String = null, param5:int = -1, param6:InteractiveObject = null, param7:Object = null)
        {
            super(param1, param2, param3, param4, param5, param6, param7);
            return;
        }// end function

        override public function clone() : Event
        {
            var _loc_1:* = new TrackMissionEvent(type, bubbles, cancelable, label, index, relatedObject, item);
            _loc_1.track = this.track;
            return _loc_1;
        }// end function

    }
}
