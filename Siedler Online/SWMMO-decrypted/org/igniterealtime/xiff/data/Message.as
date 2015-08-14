package org.igniterealtime.xiff.data
{
    import flash.xml.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;
    import org.igniterealtime.xiff.data.muc.*;
    import org.igniterealtime.xiff.data.xhtml.*;

    public class Message extends XMPPStanza implements ISerializable
    {
        private var mySubjectNode:XMLNode;
        private var myThreadNode:XMLNode;
        private var myTimeStampNode:XMLNode;
        private var myBodyNode:XMLNode;
        private var myStateNode:XMLNode;
        public static const TYPE_HEADLINE:String = "headline";
        public static const RECEIPT_REQUEST:String = "request";
        public static const TYPE_NORMAL:String = "normal";
        public static const STATE_ACTIVE:String = "active";
        private static var isMessageStaticCalled:Boolean = MessageStaticConstructor();
        public static const NS_RECEIPT:String = "urn:xmpp:receipts";
        public static const STATE_COMPOSING:String = "composing";
        public static const TYPE_ERROR:String = "error";
        private static var staticConstructorDependency:Array = [XMPPStanza, XHTMLExtension, ExtensionClassRegistry];
        public static const STATE_GONE:String = "gone";
        public static const RECEIPT_RECEIVED:String = "received";
        public static const TYPE_GROUPCHAT:String = "groupchat";
        public static const NS_STATE:String = "http://jabber.org/protocol/chatstates";
        public static const STATE_INACTIVE:String = "inactive";
        public static const STATE_PAUSED:String = "paused";
        public static const TYPE_CHAT:String = "chat";

        public function Message(param1:EscapedJID = null, param2:String = null, param3:String = null, param4:String = null, param5:String = null, param6:String = null, param7:String = null)
        {
            var _loc_8:* = exists(param2) ? (param2) : (generateID("m_"));
            super(param1, null, param5, _loc_8, "message");
            body = param3;
            htmlBody = param4;
            subject = param6;
            state = param7;
            return;
        }// end function

        override public function deserialize(param1:XMLNode) : Boolean
        {
            var _loc_3:Array = null;
            var _loc_4:String = null;
            var _loc_5:MUCUserExtension = null;
            var _loc_2:* = super.deserialize(param1);
            if (_loc_2)
            {
                _loc_3 = param1.childNodes;
                for (_loc_4 in _loc_3)
                {
                    
                    switch(_loc_3[_loc_4].nodeName)
                    {
                        case "error":
                        {
                            break;
                        }
                        case "body":
                        {
                            myBodyNode = _loc_3[_loc_4];
                            break;
                        }
                        case "subject":
                        {
                            mySubjectNode = _loc_3[_loc_4];
                            break;
                        }
                        case "thread":
                        {
                            myThreadNode = _loc_3[_loc_4];
                            break;
                        }
                        case "x":
                        {
                            if (_loc_3[_loc_4].attributes.xmlns == "jabber:x:delay")
                            {
                                myTimeStampNode = _loc_3[_loc_4];
                            }
                            if (_loc_3[_loc_4].attributes.xmlns == MUCUserExtension.NS)
                            {
                                _loc_5 = new MUCUserExtension(getNode());
                                _loc_5.deserialize(_loc_3[_loc_4]);
                                addExtension(_loc_5);
                            }
                            break;
                        }
                        case "delay":
                        {
                            trace("Message used \'delay\' as defined in XEP-0203.");
                            break;
                        }
                        case Message.STATE_ACTIVE:
                        case Message.STATE_COMPOSING:
                        case Message.STATE_GONE:
                        case Message.STATE_INACTIVE:
                        case Message.STATE_PAUSED:
                        {
                            myStateNode = _loc_3[_loc_4];
                            break;
                        }
                        default:
                        {
                            break;
                        }
                    }
                }
            }
            return _loc_2;
        }// end function

        public function get thread() : String
        {
            if (myThreadNode == null || myThreadNode.firstChild == null)
            {
                return null;
            }
            return myThreadNode.firstChild.nodeValue;
        }// end function

        public function set body(param1:String) : void
        {
            myBodyNode = replaceTextNode(getNode(), myBodyNode, "body", param1);
            return;
        }// end function

        public function get time() : Date
        {
            if (myTimeStampNode == null)
            {
                return null;
            }
            var _loc_1:* = myTimeStampNode.attributes.stamp;
            trace("myTimeStampNode: " + myTimeStampNode.toString());
            var _loc_2:* = new Date();
            _loc_2.setUTCFullYear(_loc_1.substr(0, 4));
            _loc_2.setUTCMonth((parseInt(_loc_1.substr(4, 2)) - 1));
            _loc_2.setUTCDate(_loc_1.substr(6, 2));
            _loc_2.setUTCHours(_loc_1.substr(9, 2));
            _loc_2.setUTCMinutes(_loc_1.substr(12, 2));
            _loc_2.setUTCSeconds(_loc_1.substr(15, 2));
            return _loc_2;
        }// end function

        public function get state() : String
        {
            if (!myStateNode)
            {
                return null;
            }
            return myStateNode.nodeName;
        }// end function

        public function set thread(param1:String) : void
        {
            myThreadNode = replaceTextNode(getNode(), myThreadNode, "thread", param1);
            return;
        }// end function

        public function set subject(param1:String) : void
        {
            mySubjectNode = replaceTextNode(getNode(), mySubjectNode, "subject", param1);
            return;
        }// end function

        public function set time(param1:Date) : void
        {
            return;
        }// end function

        override public function serialize(param1:XMLNode) : Boolean
        {
            return super.serialize(param1);
        }// end function

        public function set htmlBody(param1:String) : void
        {
            var _loc_2:XHTMLExtension = null;
            removeAllExtensions(XHTMLExtension.NS);
            if (exists(param1) && param1.length > 0)
            {
                _loc_2 = new XHTMLExtension(getNode());
                _loc_2.body = param1;
                addExtension(_loc_2);
            }
            return;
        }// end function

        public function get body() : String
        {
            if (!exists(myBodyNode) || !exists(myBodyNode.firstChild))
            {
                return null;
            }
            var value:String;
            try
            {
                value = myBodyNode.firstChild.nodeValue;
            }
            catch (error:Error)
            {
                trace(error.getStackTrace());
            }
            return value;
        }// end function

        public function set state(param1:String) : void
        {
            if (param1 != Message.STATE_ACTIVE && param1 != Message.STATE_COMPOSING && param1 != Message.STATE_PAUSED && param1 != Message.STATE_INACTIVE && param1 != Message.STATE_GONE && param1 != null && param1 != "")
            {
                throw new Error("Invalid state value: " + param1 + " for ChatState");
            }
            if (myStateNode && (param1 == null || param1 == ""))
            {
                myStateNode.removeNode();
                myStateNode = null;
            }
            else if (myStateNode && (param1 != null && param1 != ""))
            {
                myStateNode.nodeName = param1;
            }
            else if (!myStateNode && (param1 != null && param1 != ""))
            {
                myStateNode = XMLStanza.XMLFactory.createElement(param1);
                myStateNode.attributes = {xmlns:Message.NS_STATE};
                getNode().appendChild(myStateNode);
            }
            return;
        }// end function

        public function get subject() : String
        {
            if (mySubjectNode == null || mySubjectNode.firstChild == null)
            {
                return null;
            }
            return mySubjectNode.firstChild.nodeValue;
        }// end function

        public function get htmlBody() : String
        {
            var ext:XHTMLExtension;
            try
            {
                ext = getAllExtensionsByNS(XHTMLExtension.NS)[0];
                return ext.body;
            }
            catch (error:Error)
            {
                trace("Error : null trapped. Resuming.");
            }
            return null;
        }// end function

        public static function MessageStaticConstructor() : Boolean
        {
            XHTMLExtension.enable();
            return true;
        }// end function

    }
}
