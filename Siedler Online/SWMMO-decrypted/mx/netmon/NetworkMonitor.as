package mx.netmon
{
    import flash.events.*;
    import flash.net.*;

    public class NetworkMonitor extends Object
    {
        public static var monitorEventImpl:Function;
        public static var adjustNetConnectionURLImpl:Function;
        public static var monitorFaultImpl:Function;
        public static var monitorInvocationImpl:Function;
        public static var adjustURLRequestImpl:Function;
        public static var isMonitoringImpl:Function;
        public static var monitorResultImpl:Function;

        public function NetworkMonitor()
        {
            return;
        }// end function

        public static function monitorInvocation(param1:String, param2:Object, param3:Object) : void
        {
            if (monitorInvocationImpl != null)
            {
                monitorInvocationImpl(param1, param2, param3);
            }
            return;
        }// end function

        public static function monitorFault(param1:Object, param2:Object) : void
        {
            if (monitorFaultImpl != null)
            {
                monitorFaultImpl(param1, param2);
            }
            return;
        }// end function

        public static function adjustURLRequest(param1:URLRequest, param2:String, param3:String) : void
        {
            if (adjustURLRequestImpl != null)
            {
                adjustURLRequestImpl(param1, param2, param3);
            }
            return;
        }// end function

        public static function monitorEvent(event:Event, param2:String) : void
        {
            if (monitorEventImpl != null)
            {
                monitorEventImpl(event, param2);
            }
            return;
        }// end function

        public static function isMonitoring() : Boolean
        {
            return isMonitoringImpl != null ? (isMonitoringImpl()) : (false);
        }// end function

        public static function adjustNetConnectionURL(param1:String, param2:String) : String
        {
            if (adjustNetConnectionURLImpl != null)
            {
                return adjustNetConnectionURLImpl(param1, param2);
            }
            return null;
        }// end function

        public static function monitorResult(param1:Object, param2:Object) : void
        {
            if (monitorResultImpl != null)
            {
                monitorResultImpl(param1, param2);
            }
            return;
        }// end function

    }
}
