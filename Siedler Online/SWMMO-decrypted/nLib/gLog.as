package nLib
{
    import Enums.*;
    import mx.formatters.*;

    public class gLog extends Object
    {
        private static var runtimeLogTypeError:int = definesMaster.LOG_TYPES_ERROR;
        private static var runtimeLogTypeFatal:int = definesMaster.LOG_TYPES_FATAL;
        private static var df:DateFormatter = null;
        private static var runtimeLogLevel:int = 3;
        private static var configLogTypeTrace:int = definesMaster.LOG_TYPES_TRACE;
        private static var configLogTypeWarn:int = definesMaster.LOG_TYPES_WARN;
        private static var configLogTypeDebug:int = definesMaster.LOG_TYPES_DEBUG;
        private static var runtimeLogTypeTrace:int = definesMaster.LOG_TYPES_TRACE;
        private static var runtimeProfilerActive:Boolean = false;
        private static var configLogTypeInfo:int = definesMaster.LOG_TYPES_INFO;
        private static var runtimeLogTypeWarn:int = definesMaster.LOG_TYPES_WARN;
        private static var runtimeLogTypeDebug:int = definesMaster.LOG_TYPES_DEBUG;
        private static var runtimeLogPlayerAction:Boolean = false;
        private static var configLogTypeError:int = definesMaster.LOG_TYPES_ERROR;
        private static var configLogTypeFatal:int = definesMaster.LOG_TYPES_FATAL;
        private static var runtimeLogTypeInfo:int = definesMaster.LOG_TYPES_INFO;

        public function gLog()
        {
            return;
        }// end function

        public static function isTraceEnabled(param1:int) : Boolean
        {
            return (runtimeLogTypeTrace & param1) > 0;
        }// end function

        public static function logDebug(param1:int, param2:String) : void
        {
            trace(df.format(new Date()) + " DEBUG [" + LOG_TYPE.toString(param1) + "] " + param2);
            return;
        }// end function

        public static function getRuntimeLogLevelName() : String
        {
            return LOG_LEVEL.toString(runtimeLogLevel);
        }// end function

        public static function getRuntimeLogTypeMaskDebug() : int
        {
            return runtimeLogTypeDebug;
        }// end function

        public static function isProfilerActive() : Boolean
        {
            return runtimeProfilerActive;
        }// end function

        public static function logFatal(param1:int, param2:String) : void
        {
            trace(df.format(new Date()) + " FATAL [" + LOG_TYPE.toString(param1) + "] " + param2);
            return;
        }// end function

        public static function resetRuntimeLogPlayerActions() : Boolean
        {
            runtimeLogPlayerAction = definesMaster.LOG_PLAYER_ACTIONS;
            return true;
        }// end function

        public static function logError(param1:int, param2:String) : void
        {
            trace(df.format(new Date()) + " ERROR [" + LOG_TYPE.toString(param1) + "] " + param2);
            return;
        }// end function

        public static function isLogPlayerActionsEnabled() : Boolean
        {
            return runtimeLogPlayerAction;
        }// end function

        public static function logInfo(param1:int, param2:String) : void
        {
            trace(df.format(new Date()) + " INFO [" + LOG_TYPE.toString(param1) + "] " + param2);
            return;
        }// end function

        public static function setRuntimeLogPlayerActions(param1:Boolean) : Boolean
        {
            runtimeLogPlayerAction = param1;
            return true;
        }// end function

        public static function resetRuntimeLogTypeMasks() : Boolean
        {
            configLogTypeTrace = definesMaster.LOG_TYPES_TRACE;
            configLogTypeDebug = definesMaster.LOG_TYPES_DEBUG;
            configLogTypeInfo = definesMaster.LOG_TYPES_INFO;
            configLogTypeWarn = definesMaster.LOG_TYPES_WARN;
            configLogTypeError = definesMaster.LOG_TYPES_ERROR;
            configLogTypeFatal = definesMaster.LOG_TYPES_FATAL;
            return setRuntimeLogLevel(runtimeLogLevel);
        }// end function

        public static function logPossibleError(param1:int, param2:String) : void
        {
            trace("(" + param1 + ") " + param2);
            return;
        }// end function

        public static function setRuntimeLogTypeMask(param1:int, param2:int) : Boolean
        {
            if (param2 < LOG_TYPE.NONE || param2 > LOG_TYPE.ALL)
            {
                return false;
            }
            ;
            
            configLogTypeTrace = param2;
            ;
            
            configLogTypeDebug = param2;
            ;
            
            configLogTypeInfo = param2;
            ;
            
            configLogTypeWarn = param2;
            ;
            
            configLogTypeError = param2;
            ;
            
            configLogTypeFatal = param2;
            ;
            
            return false;
        }// end function

        public static function isDebugEnabled(param1:int) : Boolean
        {
            return (runtimeLogTypeDebug & param1) > 0;
        }// end function

        public static function getRuntimeLogTypeMaskFatal() : int
        {
            return runtimeLogTypeFatal;
        }// end function

        public static function getRuntimeLogTypeMaskError() : int
        {
            return runtimeLogTypeError;
        }// end function

        public static function isInfoEnabled(param1:int) : Boolean
        {
            return (runtimeLogTypeInfo & param1) > 0;
        }// end function

        public static function resetRuntimeLogLevel() : Boolean
        {
            return setRuntimeLogLevel(definesMaster.LOG_GLOBAL_LEVEL);
        }// end function

        public static function getRuntimeLogTypeMaskWarn() : int
        {
            return runtimeLogTypeWarn;
        }// end function

        public static function setProfilerActive(param1:Boolean) : void
        {
            runtimeProfilerActive = param1;
            return;
        }// end function

        public static function setRuntimeLogLevel(param1:int) : Boolean
        {
            if (param1 >= LOG_LEVEL.OFF && param1 <= LOG_LEVEL.ALL)
            {
                runtimeLogLevel = param1;
                runtimeLogTypeTrace = runtimeLogLevel <= LOG_LEVEL.TRACE && runtimeLogLevel != LOG_LEVEL.OFF ? (configLogTypeTrace) : (LOG_TYPE.NONE);
                runtimeLogTypeDebug = runtimeLogLevel <= LOG_LEVEL.DEBUG && runtimeLogLevel != LOG_LEVEL.OFF ? (configLogTypeDebug) : (LOG_TYPE.NONE);
                runtimeLogTypeInfo = runtimeLogLevel <= LOG_LEVEL.INFO && runtimeLogLevel != LOG_LEVEL.OFF ? (configLogTypeInfo) : (LOG_TYPE.NONE);
                runtimeLogTypeWarn = runtimeLogLevel <= LOG_LEVEL.WARN && runtimeLogLevel != LOG_LEVEL.OFF ? (configLogTypeWarn) : (LOG_TYPE.NONE);
                runtimeLogTypeError = runtimeLogLevel <= LOG_LEVEL.ERROR && runtimeLogLevel != LOG_LEVEL.OFF ? (configLogTypeError) : (LOG_TYPE.NONE);
                runtimeLogTypeFatal = runtimeLogLevel <= LOG_LEVEL.FATAL && runtimeLogLevel != LOG_LEVEL.OFF ? (configLogTypeFatal) : (LOG_TYPE.NONE);
                return true;
            }
            return false;
        }// end function

        public static function isWarnEnabled(param1:int) : Boolean
        {
            return (runtimeLogTypeWarn & param1) > 0;
        }// end function

        public static function logTrace(param1:int, param2:String) : void
        {
            trace(df.format(new Date()) + " TRACE [" + LOG_TYPE.toString(param1) + "] " + param2);
            return;
        }// end function

        public static function getRuntimeLogLevel() : int
        {
            return runtimeLogLevel;
        }// end function

        public static function isFatalEnabled(param1:int) : Boolean
        {
            return (runtimeLogTypeFatal & param1) > 0;
        }// end function

        public static function isErrorEnabled(param1:int) : Boolean
        {
            return (runtimeLogTypeError & param1) > 0;
        }// end function

        public static function logWarn(param1:int, param2:String) : void
        {
            trace(df.format(new Date()) + " WARN [" + LOG_TYPE.toString(param1) + "] " + param2);
            return;
        }// end function

        public static function getRuntimeLogTypeMaskInfo() : int
        {
            return runtimeLogTypeInfo;
        }// end function

        public static function getRuntimeLogTypeMaskTrace() : int
        {
            return runtimeLogTypeTrace;
        }// end function

        resetRuntimeLogLevel();
        df = new DateFormatter();
        df.formatString = "YYYY-MM-DD JJ:NN:SS";
    }
}
