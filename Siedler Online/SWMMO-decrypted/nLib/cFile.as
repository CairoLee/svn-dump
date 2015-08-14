package nLib
{
    import flash.events.*;
    import flash.net.*;
    import mx.controls.*;
    import mx.core.*;

    public class cFile extends Object
    {
        public var mIsLoaded:Boolean = false;
        private var mDispatcher:cCustomDispatcher;
        public var mError:Boolean = false;
        public var mFileName_string:String;
        public var mFileData_string:String = null;

        public function cFile()
        {
            this.mDispatcher = new cCustomDispatcher();
            return;
        }// end function

        private function securityErrorHandler(event:SecurityErrorEvent) : void
        {
            this.mError = true;
            Alert.show("securityErrorHandler: " + event);
            return;
        }// end function

        private function Dispatcher(event:Event) : void
        {
            var _loc_2:* = URLLoader(event.target);
            Application.application.mMemoryMonitor.RegisterLoadedXML(_loc_2.bytesTotal);
            this.mFileData_string = _loc_2.data;
            this.mIsLoaded = true;
            this.mDispatcher.doAction();
            return;
        }// end function

        private function ioErrorHandler(event:IOErrorEvent) : void
        {
            this.mError = true;
            Alert.show("ioErrorHandler: " + event);
            return;
        }// end function

        public function LoadString(param1:String, param2:Function, param3:Function, param4:Function) : void
        {
            this.mDispatcher.addEventListener(cCustomDispatcher.mAction_string, param2);
            var _loc_5:* = new cXML();
            this.mFileName_string = param1;
            this.mIsLoaded = false;
            this.mError = false;
            _loc_5.LoadFile(param1, this.Dispatcher);
            return;
        }// end function

    }
}
