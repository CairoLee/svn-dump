package com.google.analytics.core
{
    import com.google.analytics.debug.*;
    import com.google.analytics.v4.*;
    import flash.display.*;
    import flash.events.*;
    import flash.utils.*;

    public class IdleTimer extends Object
    {
        private var _stage:Stage;
        private var _loop:Timer;
        private var _lastMove:int;
        private var _inactivity:Number;
        private var _debug:DebugConfiguration;
        private var _session:Timer;
        private var _buffer:Buffer;

        public function IdleTimer(param1:Configuration, param2:DebugConfiguration, param3:DisplayObject, param4:Buffer)
        {
            var _loc_5:* = param1.idleLoop;
            var _loc_6:* = param1.idleTimeout;
            var _loc_7:* = param1.sessionTimeout;
            _loop = new Timer(_loc_5 * 1000);
            _session = new Timer(_loc_7 * 1000, 1);
            _debug = param2;
            _stage = param3.stage;
            _buffer = param4;
            _lastMove = getTimer();
            _inactivity = _loc_6 * 1000;
            _loop.addEventListener(TimerEvent.TIMER, checkForIdle);
            _session.addEventListener(TimerEvent.TIMER_COMPLETE, endSession);
            _stage.addEventListener(MouseEvent.MOUSE_MOVE, onMouseMove);
            _debug.info("delay: " + _loc_5 + "sec , inactivity: " + _loc_6 + "sec, sessionTimeout: " + _loc_7, VisualDebugMode.geek);
            _loop.start();
            return;
        }// end function

        private function onMouseMove(event:MouseEvent) : void
        {
            _lastMove = getTimer();
            if (_session.running)
            {
                _debug.info("session timer reset", VisualDebugMode.geek);
                _session.reset();
            }
            return;
        }// end function

        public function endSession(event:TimerEvent) : void
        {
            _session.removeEventListener(TimerEvent.TIMER_COMPLETE, endSession);
            _debug.info("session timer end session", VisualDebugMode.geek);
            _session.reset();
            _buffer.resetCurrentSession();
            _debug.info(_buffer.utmb.toString(), VisualDebugMode.geek);
            _debug.info(_buffer.utmc.toString(), VisualDebugMode.geek);
            _session.addEventListener(TimerEvent.TIMER_COMPLETE, endSession);
            return;
        }// end function

        public function checkForIdle(event:TimerEvent) : void
        {
            var _loc_2:* = getTimer();
            if (_loc_2 - _lastMove >= _inactivity)
            {
                if (!_session.running)
                {
                    _debug.info("session timer start", VisualDebugMode.geek);
                    _session.start();
                }
            }
            return;
        }// end function

    }
}
