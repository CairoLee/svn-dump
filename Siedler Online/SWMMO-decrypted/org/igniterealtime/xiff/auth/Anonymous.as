package org.igniterealtime.xiff.auth
{
    import org.igniterealtime.xiff.core.*;

    public class Anonymous extends SASLAuth
    {
        public static const MECHANISM:String = "ANONYMOUS";
        public static const NS:String = "urn:ietf:params:xml:ns:xmpp-sasl";

        public function Anonymous(param1:XMPPConnection)
        {
            req.setNamespace(Anonymous.NS);
            req.@mechanism = Anonymous.MECHANISM;
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
