package mx.rpc
{
    import flash.events.*;
    import flash.utils.*;

    public class AsyncDispatcher extends Object
    {
        private var _method:Function;
        private var _timer:Timer;
        private var _args:Array;

        public function AsyncDispatcher(param1:Function, param2:Array, param3:Number)
        {
            _method = param1;
            _args = param2;
            _timer = new Timer(param3);
            _timer.addEventListener(TimerEvent.TIMER, timerEventHandler);
            _timer.start();
            return;
        }// end function

        private function timerEventHandler(event:TimerEvent) : void
        {
            _timer.stop();
            _timer.removeEventListener(TimerEvent.TIMER, timerEventHandler);
            _method.apply(null, _args);
            return;
        }// end function

    }
}
