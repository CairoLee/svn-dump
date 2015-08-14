package org.igniterealtime.xiff.data.forms
{
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;

    public class FormField extends XMLStanza implements ISerializable
    {
        private var myDescNode:XMLNode;
        private var myValueNodes:Array;
        private var myRequiredNode:XMLNode;
        private var myOptionNodes:Array;
        public static const ELEMENT_NAME:String = "field";

        public function FormField()
        {
            return;
        }// end function

        public function serialize(param1:XMLNode) : Boolean
        {
            getNode().nodeName = FormField.ELEMENT_NAME;
            if (param1 != getNode().parentNode)
            {
                param1.appendChild(getNode().cloneNode(true));
            }
            return true;
        }// end function

        public function get type() : String
        {
            return getNode().attributes.type;
        }// end function

        public function set value(param1:String) : void
        {
            if (myValueNodes == null)
            {
                myValueNodes = [];
            }
            myValueNodes[0] = replaceTextNode(getNode(), myValueNodes[0], "value", param1);
            return;
        }// end function

        public function set label(param1:String) : void
        {
            getNode().attributes.label = param1;
            return;
        }// end function

        public function get name() : String
        {
            return getNode().attributes["var"];
        }// end function

        public function get value() : String
        {
            try
            {
                if (myValueNodes[0] != null && myValueNodes[0].firstChild != null)
                {
                    return myValueNodes[0].firstChild.nodeValue;
                }
            }
            catch (error:Error)
            {
                trace(error.getStackTrace());
            }
            return null;
        }// end function

        public function set type(param1:String) : void
        {
            getNode().attributes.type = param1;
            return;
        }// end function

        public function getAllOptions() : Array
        {
            return myOptionNodes.map(function (param1:XMLNode, param2:uint, param3:Array) : Object
            {
                return {null:null.attributes.label, value:param1.firstChild.firstChild.nodeValue};
            }// end function
            );
        }// end function

        public function set name(param1:String) : void
        {
            getNode().attributes["var"] = param1;
            return;
        }// end function

        public function setAllOptions(param1:Array) : void
        {
            var optionNode:XMLNode;
            var value:* = param1;
            var _loc_3:int = 0;
            var _loc_4:* = myOptionNodes;
            while (_loc_4 in _loc_3)
            {
                
                optionNode = _loc_4[_loc_3];
                optionNode.removeNode();
            }
            myOptionNodes = value.map(function (param1:Object, param2:uint, param3:Array) : XMLNode
            {
                var _loc_4:* = null.replaceTextNode(null.getNode(), undefined, "value", param1.value);
                null.replaceTextNode(null.getNode(), undefined, "value", param1.value).attributes.label = param1.label;
                return _loc_4;
            }// end function
            );
            return;
        }// end function

        public function setAllValues(param1:Array) : void
        {
            var v:XMLNode;
            var value:* = param1;
            var _loc_3:int = 0;
            var _loc_4:* = myValueNodes;
            while (_loc_4 in _loc_3)
            {
                
                v = _loc_4[_loc_3];
                v.removeNode();
            }
            myValueNodes = value.map(function (param1:String, param2:uint, param3:Array)
            {
                return null.replaceTextNode(getNode(), undefined, "value", param1);
            }// end function
            );
            return;
        }// end function

        public function get label() : String
        {
            return getNode().attributes.label;
        }// end function

        public function getAllValues() : Array
        {
            var _loc_2:XMLNode = null;
            var _loc_1:Array = [];
            for each (_loc_2 in myValueNodes)
            {
                
                _loc_1.push(_loc_2.firstChild.nodeValue);
            }
            return _loc_1;
        }// end function

        public function deserialize(param1:XMLNode) : Boolean
        {
            var _loc_3:String = null;
            var _loc_4:XMLNode = null;
            setNode(param1);
            myValueNodes = [];
            myOptionNodes = [];
            var _loc_2:* = param1.childNodes;
            for (_loc_3 in _loc_2)
            {
                
                _loc_4 = _loc_2[_loc_3];
                switch(_loc_2[_loc_3].nodeName)
                {
                    case "desc":
                    {
                        myDescNode = _loc_4;
                        break;
                    }
                    case "required":
                    {
                        myRequiredNode = _loc_4;
                        break;
                    }
                    case "value":
                    {
                        myValueNodes.push(_loc_4);
                        break;
                    }
                    case "option":
                    {
                        myOptionNodes.push(_loc_4);
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

    }
}
