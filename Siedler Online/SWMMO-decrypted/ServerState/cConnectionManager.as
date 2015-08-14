package ServerState
{
    import flash.events.*;
    import flash.net.*;
    import flash.utils.*;
    import mx.messaging.*;
    import mx.messaging.channels.*;
    import mx.rpc.remoting.*;
    import nLib.*;

    public class cConnectionManager extends Object
    {
        public var mRemoteService:RemoteObject;
        public var mPlayerService:RemoteObject;
        public var mGuildService:RemoteObject;
        public var mMailService:RemoteObject;
        private var mServerName:String = "";
        public var mLogService:RemoteObject;
        private static const PLAYER_HANDLER:String = "com.bluebyte.game.servlet.PlayerHandler";
        private static const LOG_HANDLER:String = "com.bluebyte.game.servlet.LogHandler";
        private static const DEST_SMC:String = "SMC";
        private static const ENDPOINT:String = "SMC-Endpoint";
        private static const EVENT_HANDLER:String = "com.bluebyte.game.servlet.EventHandler";
        private static const MAIL_HANDLER:String = "com.bluebyte.game.servlet.MailHandler";
        private static const DEST_PLAYER:String = "PLAYER";
        private static var mInstance:cConnectionManager;
        private static const DEST_MAIL:String = "MAIL";
        private static const DEST_GUILD:String = "GUILD";
        private static const DEST_LOGS:String = "LOGS";
        private static const DICT:Dictionary = new Dictionary();
        private static const GUILD_HANDLER:String = "com.bluebyte.game.servlet.GuildHandler";

        public function cConnectionManager(param1:cSingletonEnforcer)
        {
            if (param1 == null)
            {
                throw new Error("cConnectionManager is a Singleton. Use GetInstance() to use this class.");
            }
            return;
        }// end function

        private function KeepAliveErrorHandler(event:Event) : void
        {
            gMisc.ConsoleOut("Error sending keep alive ping.");
            return;
        }// end function

        public function SendKeepAlivePing() : int
        {
            var request:URLRequest;
            var loader:URLLoader;
            if (definesMaster.MASTER_VERSION)
            {
                try
                {
                    request = new URLRequest(defines.KEEP_ALIVE_URL);
                    loader = new URLLoader();
                    loader.load(request);
                    loader.addEventListener(IOErrorEvent.IO_ERROR, this.KeepAliveErrorHandler);
                    loader.addEventListener(SecurityErrorEvent.SECURITY_ERROR, this.KeepAliveErrorHandler);
                    gMisc.ConsoleOut("Sending keep alive ping to: " + defines.KEEP_ALIVE_URL);
                }
                catch (e:Error)
                {
                    gMisc.ConsoleOut("Error sending keep alive ping.");
                }
            }
            return getTimer() + defines.KEEP_ALIVE_INTERVAL * 60 * 1000;
        }// end function

        public function CreateServices(param1:String) : void
        {
            var _loc_2:ChannelSet = null;
            var _loc_3:Channel = null;
            if (this.mServerName != param1)
            {
                this.mRemoteService = new RemoteObject();
                this.mMailService = new RemoteObject();
                this.mPlayerService = new RemoteObject();
                this.mLogService = new RemoteObject();
                this.mGuildService = new RemoteObject();
                if (DICT[param1] == null)
                {
                    _loc_2 = new ChannelSet();
                    _loc_3 = new AMFChannel(ENDPOINT, param1);
                    _loc_3.connectTimeout = 0;
                    _loc_3.requestTimeout = 0;
                    _loc_2.addChannel(_loc_3);
                    DICT[param1] = _loc_2;
                }
                this.mRemoteService.channelSet = DICT[param1];
                this.mRemoteService.destination = DEST_SMC;
                this.mRemoteService.source = EVENT_HANDLER;
                this.mMailService.channelSet = DICT[param1];
                this.mMailService.destination = DEST_MAIL;
                this.mMailService.source = MAIL_HANDLER;
                this.mPlayerService.channelSet = DICT[param1];
                this.mPlayerService.destination = DEST_PLAYER;
                this.mPlayerService.source = PLAYER_HANDLER;
                this.mLogService.channelSet = DICT[param1];
                this.mLogService.destination = DEST_LOGS;
                this.mLogService.source = LOG_HANDLER;
                this.mGuildService.channelSet = DICT[param1];
                this.mGuildService.destination = DEST_GUILD;
                this.mGuildService.source = GUILD_HANDLER;
                this.mServerName = param1;
            }
            return;
        }// end function

        public static function GetInstance() : cConnectionManager
        {
            if (mInstance == null)
            {
                mInstance = new cConnectionManager(new cSingletonEnforcer());
            }
            return mInstance;
        }// end function

    }
}
