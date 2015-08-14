package mx.messaging
{
    import flash.events.*;
    import mx.events.*;

    public class FlexClient extends EventDispatcher
    {
        private var _waitForFlexClientId:Boolean = false;
        private var _id:String;
        private static var _instance:FlexClient;
        static const NULL_FLEXCLIENT_ID:String = "nil";

        public function FlexClient()
        {
            return;
        }// end function

        public function get id() : String
        {
            return _id;
        }// end function

        function get waitForFlexClientId() : Boolean
        {
            return _waitForFlexClientId;
        }// end function

        public function set id(param1:String) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_id != param1)
            {
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "id", _id, param1);
                _id = param1;
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        function set waitForFlexClientId(param1:Boolean) : void
        {
            var _loc_2:PropertyChangeEvent = null;
            if (_waitForFlexClientId != param1)
            {
                _loc_2 = PropertyChangeEvent.createUpdateEvent(this, "waitForFlexClientId", _waitForFlexClientId, param1);
                _waitForFlexClientId = param1;
                dispatchEvent(_loc_2);
            }
            return;
        }// end function

        public static function getInstance() : FlexClient
        {
            if (_instance == null)
            {
                _instance = new FlexClient;
            }
            return _instance;
        }// end function

    }
}
