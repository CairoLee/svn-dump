package ServerState
{
    import Enums.*;
    import flash.events.*;
    import flash.net.*;
    import flash.utils.*;
    import mx.rpc.events.*;

    public class cBigBrotherMessage extends Object
    {
        private var errorRetry:int = 0;
        private var mObject:Object;
        private var mLoginQueueStatus:cLoginQueueStatus;
        private var mURLVariables:URLVariables;
        private var mType:int;
        private var mTimer:Timer;
        private var mZoneInitialized:Boolean = false;
        private var mFaultEvent:FaultEvent;
        private var mURLRequest:URLRequest;
        private var mZoneId:int;
        private var mURLLoader:URLLoader;
        private var mResultServerName:String;
        private var mStatus:int;
        public static const ERROR_RETRIES:int = 5;

        public function cBigBrotherMessage(param1:int, param2:int, param3:Object)
        {
            this.mFaultEvent = new FaultEvent(FaultEvent.FAULT);
            this.mURLRequest = new URLRequest();
            if (global.ui.mClientMessages.mLastVisitedZoneID == param2 && global.ui.mClientMessages.mLastResultServerName != "")
            {
                global.ui.mClientMessages.SendMessagetoServerII(param1, param2, param3, global.ui.mClientMessages.mLastResultServerName);
            }
            else
            {
                global.ui.mClientMessages.mLastVisitedZoneID = 0;
                global.ui.mClientMessages.mLastResultServerName = "";
                this.mURLRequest.url = defines.BIG_BROTHER_URL;
                this.mURLRequest.method = URLRequestMethod.POST;
                this.mTimer = new Timer(5000, 0);
                this.mTimer.addEventListener(TimerEvent.TIMER, this.Retry);
                this.mType = param1;
                this.mZoneId = param2;
                this.mObject = param3;
                this.mResultServerName = "";
                this.mURLVariables = new URLVariables();
                this.mURLVariables.zoneID = param2;
                this.mURLVariables.DSOAUTHTOKEN = cClientMessagesII.mAuthToken;
                this.mURLVariables.DSOAUTHUSER = cClientMessagesII.mAuthUser;
                this.mURLRequest.data = this.mURLVariables;
                this.mURLRequest.url = defines.BIG_BROTHER_URL + "Z" + new Date().getTime();
                this.mURLLoader = new URLLoader();
                this.mURLLoader.dataFormat = URLLoaderDataFormat.TEXT;
                this.ConfigureListeners(this.mURLLoader);
                this.mURLLoader.load(this.mURLRequest);
                if (this.mZoneInitialized == false)
                {
                    this.mLoginQueueStatus = new cLoginQueueStatus();
                }
            }
            return;
        }// end function

        private function GetResultServerName() : String
        {
            return this.mResultServerName;
        }// end function

        private function HttpStatusHandler(event:HTTPStatusEvent) : void
        {
            this.mStatus = event.status;
            switch(this.mStatus)
            {
                case 403:
                {
                    global.ui.mClientMessages.FaultHandler(new FaultEvent(ERROR_CODES.BB_AUTH_FAILED + " BigBrother returned : " + this.mStatus));
                    break;
                }
                case 404:
                {
                    global.ui.mClientMessages.FaultHandler(new FaultEvent(ERROR_CODES.BB_SERVERS_FULL + " BigBrother returned : " + this.mStatus));
                    break;
                }
                case 405:
                case 503:
                {
                    global.ui.mClientMessages.FaultHandler(new FaultEvent(ERROR_CODES.BB_SERVICE_FAILED + " BigBrother returned : " + this.mStatus));
                    break;
                }
                default:
                {
                    break;
                    break;
                }
            }
            return;
        }// end function

        private function CompleteHandler(event:Event) : void
        {
            if (this.mStatus != 202)
            {
                this.mResultServerName = String(URLLoader(event.target).data);
                global.ui.mClientMessages.mLastVisitedZoneID = this.mZoneId;
                global.ui.mClientMessages.mLastResultServerName = this.mResultServerName;
                global.ui.mClientMessages.SendMessagetoServerII(this.mType, this.mZoneId, this.mObject, this.mResultServerName);
                if (this.mTimer != null)
                {
                    this.mTimer.stop();
                    this.mTimer.removeEventListener(TimerEvent.TIMER, this.Retry);
                    this.mTimer = null;
                }
                if (this.mLoginQueueStatus != null)
                {
                    this.mLoginQueueStatus.dispose();
                    this.mLoginQueueStatus = null;
                }
                this.mZoneInitialized = true;
            }
            else
            {
                this.mTimer.start();
            }
            return;
        }// end function

        private function Retry(event:TimerEvent) : void
        {
            if (this.mLoginQueueStatus != null)
            {
                this.mLoginQueueStatus.update(String(this.mURLLoader.data));
            }
            this.mURLRequest.url = defines.BIG_BROTHER_URL + "Z" + new Date().getTime();
            this.mURLLoader.load(this.mURLRequest);
            return;
        }// end function

        private function IoErrorHandler(event:IOErrorEvent) : void
        {
            if (this.errorRetry < ERROR_RETRIES)
            {
                var _loc_2:String = this;
                var _loc_3:* = this.errorRetry + 1;
                _loc_2.errorRetry = _loc_3;
                this.mURLRequest.url = defines.BIG_BROTHER_URL + "Z" + new Date().getTime();
                this.mURLLoader.load(this.mURLRequest);
            }
            else
            {
                global.ui.mClientMessages.FaultHandler(new FaultEvent("cBigBrotherMessage " + event.type + " " + event.text));
            }
            return;
        }// end function

        private function ConfigureListeners(param1:IEventDispatcher) : void
        {
            param1.addEventListener(HTTPStatusEvent.HTTP_STATUS, this.HttpStatusHandler);
            param1.addEventListener(Event.COMPLETE, this.CompleteHandler);
            param1.addEventListener(IOErrorEvent.IO_ERROR, this.IoErrorHandler);
            param1.addEventListener(SecurityErrorEvent.SECURITY_ERROR, this.SecurityErrorHandler);
            return;
        }// end function

        private function SecurityErrorHandler(event:SecurityErrorEvent) : void
        {
            if (this.errorRetry < ERROR_RETRIES)
            {
                var _loc_2:String = this;
                var _loc_3:* = this.errorRetry + 1;
                _loc_2.errorRetry = _loc_3;
                this.mURLRequest.url = defines.BIG_BROTHER_URL + "Z" + new Date().getTime();
                this.mURLLoader.load(this.mURLRequest);
            }
            else
            {
                global.ui.mClientMessages.FaultHandler(new FaultEvent("cBigBrotherMessage " + event.type + " " + event.text));
            }
            return;
        }// end function

        private function GetZoneId() : int
        {
            return this.mZoneId;
        }// end function

    }
}
