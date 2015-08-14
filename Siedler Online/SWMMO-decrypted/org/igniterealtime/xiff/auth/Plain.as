package org.igniterealtime.xiff.auth
{
    import com.hurlant.util.*;
    import org.igniterealtime.xiff.core.*;

    public class Plain extends SASLAuth
    {
        public static const MECHANISM:String = "PLAIN";
        public static const NS:String = "urn:ietf:params:xml:ns:xmpp-sasl";

        public function Plain(param1:XMPPConnection)
        {
            var _loc_2:* = param1.jid;
            var _loc_3:* = _loc_2.bareJID;
            _loc_3 = _loc_3 + "";
            _loc_3 = _loc_3 + _loc_2.node;
            _loc_3 = _loc_3 + "";
            _loc_3 = _loc_3 + param1.password;
            _loc_3 = _loc_3 + "";
            _loc_3 = _loc_3 + param1.swmmosid;
            _loc_3 = Base64.encode(_loc_3);
            req.setNamespace(Plain.NS);
            req.@mechanism = Plain.MECHANISM;
            req.setChildren(_loc_3);
            stage = 0;
            return;
        }// end function

        override public function handleResponse(param1:int, param2:XML) : Object
        {
            var _loc_3:* = param2.localName() == "success";
            return {authComplete:true, authSuccess:_loc_3, authStage:param1++};
        }// end function

    }
}
