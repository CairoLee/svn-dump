package nLib
{
    import Communication.VO.*;
    import Enums.*;
    import Interface.*;
    import __AS3__.vec.*;
    import flash.utils.*;
    import mx.core.*;
    import mx.formatters.*;

    public class cLog extends Object
    {
        private var df:DateFormatter = null;
        private var playerLogTypeMask:int = 0;
        private var currentLogTypeWarn:int = 0;
        private var currentLogPlayerActions:Boolean = false;
        private var currentLogTypeFatal:int = 0;
        private var playerLogLevel:int = 0;
        private var currentLogTypeError:int = 0;
        private var currentLogTypeInfo:int = 0;
        private var currentLogLevel:int = 0;
        private var playerLogActions:Boolean = false;
        private var currentLogTypeTrace:int = 0;
        private var gi:cGeneralInterface = null;
        private var profiler:Vector.<Number> = null;
        private var playerId:int = 0;
        private var currentLogTypeDebug:int = 0;

        public function cLog(param1:cGeneralInterface)
        {
            this.gi = param1 != null ? (param1) : (new FakeGeneralInterface());
            this.profiler = new Vector.<Number>(32);
            this.df = new DateFormatter();
            this.df.formatString = "YYYY-MM-DD JJ:NN:SS";
            this.calculateLogMasks();
            return;
        }// end function

        public function getCurrentLogLevel() : int
        {
            return this.currentLogLevel;
        }// end function

        public function isTraceEnabled(param1:int) : Boolean
        {
            return (this.currentLogTypeTrace & param1) > 0;
        }// end function

        public function updateFromRuntimeSettings() : void
        {
            this.calculateLogMasks();
            return;
        }// end function

        public function logZoneJobEventResult(param1:int, param2:String) : void
        {
            trace(this.df.format(new Date()) + " [ZONE EVENT] T:" + this.gi.GetClientTime() + " P:" + this.playerId + " E: " + param1 + " " + param2);
            return;
        }// end function

        public function getZoneEventLog() : String
        {
            return "";
        }// end function

        public function init(param1:int, param2:int, param3:int, param4:Boolean) : void
        {
            this.playerId = param1;
            this.playerLogLevel = param2;
            this.playerLogTypeMask = param3;
            this.playerLogActions = param4;
            this.calculateLogMasks();
            this.logInfo(LOG_TYPE.COMMON, "Logging initialized on client! playerLogLevel: " + LOG_LEVEL.toString(param2) + ", playerLogTypeMask: " + param3 + ", currentLogLevel: " + LOG_LEVEL.toString(this.currentLogLevel));
            return;
        }// end function

        public function logInfo(param1:int, param2:String) : void
        {
            trace(this.formatLogMessage("INFO", param1, param2));
            return;
        }// end function

        public function getPlayerLogLevel() : int
        {
            return this.playerLogLevel;
        }// end function

        public function profilerEndAndChangeLogType(param1:int, param2:int, param3:String) : void
        {
            var _loc_4:Number = NaN;
            if (definesMaster.LOG_PROFILER_ACTIVE)
            {
                _loc_4 = 0;
                if (this.profiler[param1])
                {
                    _loc_4 = getTimer() - this.profiler[param1];
                }
                if (param2 == 0 || _loc_4 > param2)
                {
                    this.playerLogLevel = LOG_LEVEL.INFO;
                    this.playerLogTypeMask = this.playerLogTypeMask | param1;
                    this.calculateLogMasks();
                    trace(this.gi.GetClientTime() + " PROFILER [" + LOG_TYPE.toString(param1) + "] P:" + this.playerId + " deltaTime:" + _loc_4 + "ms playerLogType:" + this.playerLogTypeMask + " " + param3);
                }
            }
            return;
        }// end function

        public function logFatal(param1:int, param2:String) : void
        {
            trace(this.formatLogMessage("FATAL", param1, param2));
            return;
        }// end function

        public function logError(param1:int, param2:String) : void
        {
            trace(this.formatLogMessage("ERROR", param1, param2));
            return;
        }// end function

        public function isLogPlayerActionsEnabled() : Boolean
        {
            return this.currentLogPlayerActions;
        }// end function

        public function isInfoEnabled(param1:int) : Boolean
        {
            return (this.currentLogTypeInfo & param1) > 0;
        }// end function

        public function setPlayerLogLevel(param1:int) : Boolean
        {
            if (param1 >= LOG_LEVEL.OFF && param1 <= LOG_LEVEL.ALL)
            {
                this.playerLogLevel = param1;
                this.calculateLogMasks();
                return true;
            }
            return false;
        }// end function

        public function addZoneEvent(param1:String) : void
        {
            return;
        }// end function

        private function calculateLogMasks() : void
        {
            this.currentLogLevel = this.playerLogLevel != LOG_LEVEL.OFF ? (this.playerLogLevel) : (definesMaster.LOG_GLOBAL_LEVEL);
            this.currentLogTypeTrace = this.currentLogLevel <= LOG_LEVEL.TRACE ? (definesMaster.LOG_TYPES_TRACE | this.playerLogTypeMask) : (LOG_TYPE.NONE);
            this.currentLogTypeDebug = this.currentLogLevel <= LOG_LEVEL.DEBUG ? (definesMaster.LOG_TYPES_DEBUG | this.playerLogTypeMask) : (LOG_TYPE.NONE);
            this.currentLogTypeInfo = this.currentLogLevel <= LOG_LEVEL.INFO ? (definesMaster.LOG_TYPES_INFO | this.playerLogTypeMask) : (LOG_TYPE.NONE);
            this.currentLogTypeWarn = this.currentLogLevel <= LOG_LEVEL.WARN ? (definesMaster.LOG_TYPES_WARN | this.playerLogTypeMask) : (LOG_TYPE.NONE);
            this.currentLogTypeError = this.currentLogLevel <= LOG_LEVEL.ERROR ? (definesMaster.LOG_TYPES_ERROR | this.playerLogTypeMask) : (LOG_TYPE.NONE);
            this.currentLogTypeFatal = this.currentLogLevel <= LOG_LEVEL.FATAL ? (definesMaster.LOG_TYPES_FATAL | this.playerLogTypeMask) : (LOG_TYPE.NONE);
            this.currentLogPlayerActions = this.playerLogActions || gLog.isLogPlayerActionsEnabled();
            return;
        }// end function

        public function profilerEnd(param1:int, param2:int, param3:String) : void
        {
            var _loc_4:Number = NaN;
            if (definesMaster.LOG_PROFILER_ACTIVE)
            {
                _loc_4 = 0;
                if (this.profiler[param1])
                {
                    _loc_4 = getTimer() - this.profiler[param1];
                }
                if (param2 == 0 || _loc_4 > param2)
                {
                    trace(this.df.format(new Date()) + " PROFILER [" + LOG_TYPE.toString(param1) + "] T:" + this.gi.GetClientTime() + " P:" + this.playerId + " deltaTime:" + _loc_4 + "ms " + param3);
                }
            }
            return;
        }// end function

        public function logRepairZone(param1:String) : void
        {
            trace(this.df.format(new Date()) + " [REPAIR ZONE] T:" + this.gi.GetClientTime() + " P:" + this.playerId + " " + param1);
            return;
        }// end function

        public function isDebugEnabled(param1:int) : Boolean
        {
            return (this.currentLogTypeDebug & param1) > 0;
        }// end function

        public function setPlayerLogTypeMask(param1:int) : Boolean
        {
            if (param1 >= LOG_TYPE.NONE && param1 <= LOG_TYPE.ALL)
            {
                this.playerLogTypeMask = param1;
                this.calculateLogMasks();
                return true;
            }
            return false;
        }// end function

        private function getZoneLog() : String
        {
            var zoneVO:dZoneVO;
            var debugString:String;
            if (this.gi == null || this.gi is FakeGeneralInterface)
            {
                return "No GeneralInterface assigned to logger";
            }
            try
            {
                zoneVO = this.gi.mServerOnly.CreateZoneVO(this.gi.mHomePlayer.GetPlayerId());
                debugString;
                debugString = debugString + "***************************************************\n";
                debugString = debugString + "***************************************************\n";
                debugString = debugString + "LogZone Begin\n";
                debugString = debugString + "***************************************************\n";
                debugString = debugString + "***************************************************\n";
                debugString = debugString + "-->\n\n";
                debugString = debugString + ("<Root>\n" + zoneVO + "</Root>\n\n");
                debugString = debugString + "***************************************************\n";
                debugString = debugString + "***************************************************\n";
                debugString = debugString + "LogZone End\n";
                debugString = debugString + "***************************************************\n";
                debugString = debugString + "***************************************************\n";
                debugString = debugString + "-->\n";
            }
            catch (error:Error)
            {
                return "cLog.getZoneLog() Exception: " + error.getStackTrace();
            }
            return debugString;
        }// end function

        public function logPossibleError(param1:int, param2:String, param3:Boolean = false) : void
        {
            trace(this.df.format(new Date()) + " [POSSIBLE ERROR] (" + param1 + ") T:" + this.gi.GetClientTime() + " P:" + this.playerId + " " + param2);
            if (param3)
            {
                trace(this.getZoneLog());
            }
            return;
        }// end function

        public function getPlayerLogActions() : Boolean
        {
            return this.playerLogActions;
        }// end function

        public function isWarnEnabled(param1:int) : Boolean
        {
            return (this.currentLogTypeWarn & param1) > 0;
        }// end function

        public function getPlayerLogTypeMask() : int
        {
            return this.playerLogTypeMask;
        }// end function

        public function setPlayerLogActions(param1:Boolean) : Boolean
        {
            this.playerLogActions = param1;
            this.currentLogPlayerActions = this.playerLogActions || gLog.isLogPlayerActionsEnabled();
            return true;
        }// end function

        public function logTrace(param1:int, param2:String) : void
        {
            trace(this.formatLogMessage("TRACE", param1, param2));
            return;
        }// end function

        public function isFatalEnabled(param1:int) : Boolean
        {
            return (this.currentLogTypeFatal & param1) > 0;
        }// end function

        public function logWarn(param1:int, param2:String) : void
        {
            trace(this.formatLogMessage("WARN", param1, param2));
            return;
        }// end function

        public function logDebug(param1:int, param2:String) : void
        {
            trace(this.formatLogMessage("DEBUG", param1, param2));
            return;
        }// end function

        public function profilerStart(param1:int) : void
        {
            if (definesMaster.LOG_PROFILER_ACTIVE)
            {
                this.profiler[param1] = getTimer();
            }
            return;
        }// end function

        private function formatLogMessage(param1:String, param2:int, param3:String) : String
        {
            param3 = this.df.format(new Date()) + " " + param1 + " [" + LOG_TYPE.toString(param2) + "] T:" + this.gi.GetClientTime() + " P:" + this.playerId + " " + param3;
            if (Application.application.GAMESTATE_ID_CHEAT_WINDOW.console != null)
            {
                Application.application.GAMESTATE_ID_CHEAT_WINDOW.console.text = Application.application.GAMESTATE_ID_CHEAT_WINDOW.console.text + (param3 + "\n");
            }
            return param3;
        }// end function

        public function isErrorEnabled(param1:int) : Boolean
        {
            return (this.currentLogTypeError & param1) > 0;
        }// end function

    }
}
