package mx.rpc
{

    public class ActiveCalls extends Object
    {
        private var callOrder:Array;
        private var calls:Object;

        public function ActiveCalls()
        {
            calls = {};
            callOrder = [];
            return;
        }// end function

        public function removeCall(param1:String) : AsyncToken
        {
            var _loc_2:* = calls[param1];
            if (_loc_2 != null)
            {
                delete calls[param1];
                callOrder.splice(callOrder.lastIndexOf(param1), 1);
            }
            return _loc_2;
        }// end function

        public function cancelLast() : AsyncToken
        {
            if (callOrder.length > 0)
            {
                return removeCall(callOrder[(callOrder.length - 1)] as String);
            }
            return null;
        }// end function

        public function hasActiveCalls() : Boolean
        {
            return callOrder.length > 0;
        }// end function

        public function wasLastCall(param1:String) : Boolean
        {
            if (callOrder.length > 0)
            {
                return callOrder[(callOrder.length - 1)] == param1;
            }
            return false;
        }// end function

        public function getAllMessages() : Array
        {
            var _loc_2:String = null;
            var _loc_1:Array = [];
            for (_loc_2 in calls)
            {
                
                _loc_1.push(calls[_loc_2]);
            }
            return _loc_1;
        }// end function

        public function addCall(param1:String, param2:AsyncToken) : void
        {
            calls[param1] = param2;
            callOrder.push(param1);
            return;
        }// end function

    }
}
