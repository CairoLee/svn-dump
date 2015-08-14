package org.igniterealtime.xiff.data.auth
{
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;
    import org.igniterealtime.xiff.util.*;

    public class AuthExtension extends Extension implements IExtension, ISerializable
    {
        private var myUsernameNode:XMLNode;
        private var myPasswordNode:XMLNode;
        private var mySWMMOSIDNode:XMLNode;
        private var myDigestNode:XMLNode;
        private var myResourceNode:XMLNode;
        public static const NS:String = "jabber:iq:auth";
        public static const ELEMENT_NAME:String = "query";

        public function AuthExtension(param1:XMLNode = null)
        {
            super(param1);
            return;
        }// end function

        public function get swmmosid() : String
        {
            return mySWMMOSIDNode.firstChild.nodeValue;
        }// end function

        public function set swmmosid(param1:String) : void
        {
            mySWMMOSIDNode = replaceTextNode(getNode(), mySWMMOSIDNode, "swmmosid", param1);
            return;
        }// end function

        public function get digest() : String
        {
            if (myDigestNode && myDigestNode.firstChild)
            {
                return myDigestNode.firstChild.nodeValue;
            }
            return null;
        }// end function

        public function isDigest() : Boolean
        {
            return exists(myDigestNode);
        }// end function

        public function set digest(param1:String) : void
        {
            myPasswordNode.removeNode();
            myPasswordNode = null;
            myDigestNode = replaceTextNode(getNode(), myDigestNode, "digest", param1);
            return;
        }// end function

        public function get resource() : String
        {
            if (myResourceNode && myResourceNode.firstChild)
            {
                return myResourceNode.firstChild.nodeValue;
            }
            return null;
        }// end function

        public function get username() : String
        {
            if (myUsernameNode && myUsernameNode.firstChild)
            {
                return myUsernameNode.firstChild.nodeValue;
            }
            return null;
        }// end function

        public function deserialize(param1:XMLNode) : Boolean
        {
            var _loc_3:String = null;
            setNode(param1);
            var _loc_2:* = param1.childNodes;
            for (_loc_3 in _loc_2)
            {
                
                switch(_loc_2[_loc_3].nodeName)
                {
                    case "username":
                    {
                        myUsernameNode = _loc_2[_loc_3];
                        break;
                    }
                    case "password":
                    {
                        myPasswordNode = _loc_2[_loc_3];
                        break;
                    }
                    case "swmmosid":
                    {
                        mySWMMOSIDNode = _loc_2[_loc_3];
                        break;
                    }
                    case "digest":
                    {
                        myDigestNode = _loc_2[_loc_3];
                        break;
                    }
                    case "resource":
                    {
                        myResourceNode = _loc_2[_loc_3];
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

        public function set resource(param1:String) : void
        {
            myResourceNode = replaceTextNode(getNode(), myResourceNode, "resource", param1);
            return;
        }// end function

        public function serialize(param1:XMLNode) : Boolean
        {
            if (!exists(getNode().parentNode))
            {
                param1.appendChild(getNode().cloneNode(true));
            }
            return true;
        }// end function

        public function isPassword() : Boolean
        {
            return exists(myPasswordNode);
        }// end function

        public function getNS() : String
        {
            return NS;
        }// end function

        public function set username(param1:String) : void
        {
            myUsernameNode = replaceTextNode(getNode(), myUsernameNode, "username", param1);
            return;
        }// end function

        public function getElementName() : String
        {
            return ELEMENT_NAME;
        }// end function

        public function set password(param1:String) : void
        {
            myDigestNode = myDigestNode == null ? (XMLStanza.XMLFactory.createElement("")) : (myDigestNode);
            myDigestNode.removeNode();
            myDigestNode = null;
            myPasswordNode = replaceTextNode(getNode(), myPasswordNode, "password", param1);
            return;
        }// end function

        public function get password() : String
        {
            if (myPasswordNode && myPasswordNode.firstChild)
            {
                return myPasswordNode.firstChild.nodeValue;
            }
            return null;
        }// end function

        public static function enable() : void
        {
            ExtensionClassRegistry.register();
            return;
        }// end function

        public static function computeDigest(param1:String, param2:String) : String
        {
            return SHA1.calcSHA1(param1 + param2).toLowerCase();
        }// end function

    }
}
