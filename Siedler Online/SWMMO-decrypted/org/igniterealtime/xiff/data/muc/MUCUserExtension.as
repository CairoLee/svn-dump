package org.igniterealtime.xiff.data.muc
{
    import flash.xml.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;

    public class MUCUserExtension extends MUCBaseExtension implements IExtension
    {
        private var _statuses:Array;
        private var _passwordNode:XMLNode;
        private var _actionNode:XMLNode;
        public static const NS:String = "http://jabber.org/protocol/muc#user";
        public static const TYPE_OTHER:String = "other";
        public static const TYPE_INVITE:String = "invite";
        public static const TYPE_DECLINE:String = "decline";
        public static const TYPE_DESTROY:String = "destroy";
        public static const ELEMENT_NAME:String = "x";

        public function MUCUserExtension(param1:XMLNode = null)
        {
            _statuses = [];
            super(param1);
            return;
        }// end function

        public function getElementName() : String
        {
            return MUCUserExtension.ELEMENT_NAME;
        }// end function

        private function updateActionNode(param1:String, param2:Object, param3:String) : void
        {
            var _loc_4:String = null;
            if (_actionNode != null)
            {
                _actionNode.removeNode();
            }
            _actionNode = XMLFactory.createElement(param1);
            for (_loc_4 in param2)
            {
                
                if (exists(param2[_loc_4]))
                {
                    _actionNode.attributes[_loc_4] = param2[_loc_4];
                }
            }
            getNode().appendChild(_actionNode);
            if (param3.length > 0)
            {
                replaceTextNode(_actionNode, undefined, "reason", param3);
            }
            return;
        }// end function

        public function get reason() : String
        {
            if (_actionNode.firstChild != null)
            {
                if (_actionNode.firstChild.firstChild != null)
                {
                    return _actionNode.firstChild.firstChild.nodeValue;
                }
            }
            return null;
        }// end function

        public function get jid() : EscapedJID
        {
            return new EscapedJID(_actionNode.attributes.jid);
        }// end function

        public function set statuses(param1:Array) : void
        {
            _statuses = param1;
            return;
        }// end function

        public function get password() : String
        {
            if (_passwordNode == null)
            {
                return null;
            }
            return _passwordNode.firstChild.nodeValue;
        }// end function

        public function invite(param1:EscapedJID, param2:EscapedJID, param3:String) : void
        {
            updateActionNode(TYPE_INVITE, {to:param1.toString(), from:param2 ? (param2.toString()) : (null)}, param3);
            return;
        }// end function

        override public function deserialize(param1:XMLNode) : Boolean
        {
            var _loc_2:XMLNode = null;
            super.deserialize(param1);
            for each (_loc_2 in param1.childNodes)
            {
                
                switch(_loc_2.nodeName)
                {
                    case TYPE_DECLINE:
                    {
                        _actionNode = _loc_2;
                        break;
                    }
                    case TYPE_DESTROY:
                    {
                        _actionNode = _loc_2;
                        break;
                    }
                    case TYPE_INVITE:
                    {
                        _actionNode = _loc_2;
                        break;
                    }
                    case "status":
                    {
                        _statuses.push(new MUCStatus(_loc_2, this));
                        break;
                    }
                    case "password":
                    {
                        _passwordNode = _loc_2;
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            return true;
        }// end function

        public function destroy(param1:EscapedJID, param2:String) : void
        {
            updateActionNode(TYPE_DESTROY, {jid:param1.toString()}, param2);
            return;
        }// end function

        public function getNS() : String
        {
            return MUCUserExtension.NS;
        }// end function

        public function get statuses() : Array
        {
            return _statuses;
        }// end function

        public function get from() : EscapedJID
        {
            return new EscapedJID(_actionNode.attributes.from);
        }// end function

        public function set password(param1:String) : void
        {
            _passwordNode = replaceTextNode(getNode(), _passwordNode, "password", param1);
            return;
        }// end function

        public function hasStatusCode(param1:Number) : Boolean
        {
            var _loc_2:MUCStatus = null;
            for each (_loc_2 in statuses)
            {
                
                if (_loc_2.code == param1)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function get type() : String
        {
            if (_actionNode == null)
            {
                return null;
            }
            return _actionNode.nodeName == null ? (TYPE_OTHER) : (_actionNode.nodeName);
        }// end function

        public function get to() : EscapedJID
        {
            return new EscapedJID(_actionNode.attributes.to);
        }// end function

        public function decline(param1:EscapedJID, param2:EscapedJID, param3:String) : void
        {
            updateActionNode(TYPE_DECLINE, {to:param1.toString(), from:param2 ? (param2.toString()) : (null)}, param3);
            return;
        }// end function

    }
}
