package org.igniterealtime.xiff.core
{
    import org.igniterealtime.xiff.data.*;
    import org.igniterealtime.xiff.data.browse.*;
    import org.igniterealtime.xiff.data.disco.*;

    public class Browser extends Object
    {
        private var _connection:XMPPConnection;
        private var _pending:Object;
        private static var _isEventEnabled:Boolean = BrowserStaticConstructor();
        private static var _staticDepends:Array = [ItemDiscoExtension, InfoDiscoExtension, BrowseExtension, ExtensionClassRegistry];

        public function Browser(param1:XMPPConnection)
        {
            _pending = {};
            connection = param1;
            return;
        }// end function

        public function getServiceItems(param1:EscapedJID, param2:Function, param3:Function = null) : void
        {
            var _loc_4:* = new IQ(param1, IQ.TYPE_GET);
            new IQ(param1, IQ.TYPE_GET).callback = param2;
            _loc_4.errorCallback = param3;
            _loc_4.addExtension(new ItemDiscoExtension(_loc_4.getNode()));
            _connection.send(_loc_4);
            return;
        }// end function

        public function getNodeInfo(param1:EscapedJID, param2:String, param3:Function, param4:Function = null) : void
        {
            var _loc_6:InfoDiscoExtension = null;
            var _loc_5:* = new IQ(param1, IQ.TYPE_GET);
            _loc_6 = new InfoDiscoExtension(_loc_5.getNode());
            _loc_6.service = param1;
            _loc_6.serviceNode = param2;
            _loc_5.callback = param3;
            _loc_5.errorCallback = param4;
            _loc_5.addExtension(_loc_6);
            _connection.send(_loc_5);
            return;
        }// end function

        public function getNodeItems(param1:EscapedJID, param2:String, param3:Function, param4:Function = null) : void
        {
            var _loc_5:* = new IQ(param1, IQ.TYPE_GET);
            var _loc_6:* = new ItemDiscoExtension(_loc_5.getNode());
            new ItemDiscoExtension(_loc_5.getNode()).service = param1;
            _loc_6.serviceNode = param2;
            _loc_5.callback = param3;
            _loc_5.errorCallback = param4;
            _loc_5.addExtension(_loc_6);
            _connection.send(_loc_5);
            return;
        }// end function

        public function getServiceInfo(param1:EscapedJID, param2:Function, param3:Function = null) : void
        {
            var _loc_4:* = new IQ(param1, IQ.TYPE_GET);
            new IQ(param1, IQ.TYPE_GET).callback = param2;
            _loc_4.errorCallback = param3;
            _loc_4.addExtension(new InfoDiscoExtension(_loc_4.getNode()));
            _connection.send(_loc_4);
            return;
        }// end function

        public function set connection(param1:XMPPConnection) : void
        {
            _connection = param1;
            return;
        }// end function

        public function browseItem(param1:EscapedJID, param2:Function, param3:Function = null) : void
        {
            var _loc_4:* = new IQ(param1, IQ.TYPE_GET);
            new IQ(param1, IQ.TYPE_GET).callback = param2;
            _loc_4.errorCallback = param3;
            _loc_4.addExtension(new BrowseExtension(_loc_4.getNode()));
            _connection.send(_loc_4);
            return;
        }// end function

        public function get connection() : XMPPConnection
        {
            return _connection;
        }// end function

        private static function BrowserStaticConstructor() : Boolean
        {
            ItemDiscoExtension.enable();
            InfoDiscoExtension.enable();
            BrowseExtension.enable();
            return true;
        }// end function

    }
}
