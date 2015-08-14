package org.igniterealtime.xiff.data.forms
{
    import flash.xml.*;
    import org.igniterealtime.xiff.data.*;

    public class FormExtension extends Extension implements IExtension, ISerializable
    {
        private var _items:Array;
        private var myReportedFields:Array;
        private var myInstructionsNode:XMLNode;
        private var _fields:Array;
        private var myTitleNode:XMLNode;
        public static const TYPE_RESULT:String = "result";
        public static const FIELD_TYPE_TEXT_MULTI:String = "text-multi";
        public static const FIELD_TYPE_BOOLEAN:String = "boolean";
        public static const FIELD_TYPE_LIST_SINGLE:String = "list-single";
        public static const NS:String = "jabber:x:data";
        public static const FIELD_TYPE_TEXT_PRIVATE:String = "text-private";
        public static const ELEMENT_NAME:String = "x";
        public static const FIELD_TYPE_TEXT_SINGLE:String = "text-single";
        public static const FIELD_TYPE_FIXED:String = "fixed";
        public static const TYPE_CANCEL:String = "cancel";
        public static const FIELD_TYPE_JID_SINGLE:String = "jid-single";
        public static const FIELD_TYPE_HIDDEN:String = "hidden";
        public static const TYPE_REQUEST:String = "form";
        public static const FIELD_TYPE_LIST_MULTI:String = "list-multi";
        public static const TYPE_SUBMIT:String = "submit";
        public static const FIELD_TYPE_JID_MULTI:String = "jid-multi";

        public function FormExtension(param1:XMLNode = null)
        {
            _items = [];
            _fields = [];
            myReportedFields = [];
            super(param1);
            return;
        }// end function

        public function removeAllItems() : void
        {
            var _loc_1:FormField = null;
            var _loc_2:* = undefined;
            for each (_loc_1 in _items)
            {
                
                for each (_loc_2 in _loc_1)
                {
                    
                    _loc_2.getNode().removeNode();
                    _loc_2.setNode(null);
                }
            }
            _items = [];
            return;
        }// end function

        public function getAllFields() : Array
        {
            return _fields;
        }// end function

        public function deserialize(param1:XMLNode) : Boolean
        {
            var _loc_2:XMLNode = null;
            var _loc_3:FormField = null;
            var _loc_4:Array = null;
            var _loc_5:XMLNode = null;
            var _loc_6:XMLNode = null;
            setNode(param1);
            removeAllItems();
            removeAllFields();
            for each (_loc_2 in param1.childNodes)
            {
                
                switch(_loc_2.nodeName)
                {
                    case "instructions":
                    {
                        myInstructionsNode = _loc_2;
                        break;
                    }
                    case "title":
                    {
                        myTitleNode = _loc_2;
                        break;
                    }
                    case "reported":
                    {
                        for each (_loc_5 in _loc_2.childNodes)
                        {
                            
                            _loc_3 = new FormField();
                            _loc_3.deserialize(_loc_5);
                            myReportedFields.push(_loc_3);
                        }
                        break;
                    }
                    case "item":
                    {
                        _loc_4 = [];
                        for each (_loc_6 in _loc_2.childNodes)
                        {
                            
                            _loc_3 = new FormField();
                            _loc_3.deserialize(_loc_6);
                            _loc_4.push(_loc_3);
                        }
                        _items.push(_loc_4);
                        break;
                    }
                    case "field":
                    {
                        _loc_3 = new FormField();
                        _loc_3.deserialize(_loc_2);
                        _fields.push(_loc_3);
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

        public function set title(param1:String) : void
        {
            myTitleNode = replaceTextNode(getNode(), myTitleNode, "Title", param1);
            return;
        }// end function

        public function set instructions(param1:String) : void
        {
            myInstructionsNode = replaceTextNode(getNode(), myInstructionsNode, "instructions", param1);
            return;
        }// end function

        public function getFormType() : String
        {
            var _loc_1:FormField = null;
            for each (_loc_1 in _fields)
            {
                
                if (_loc_1.name == "FORM_TYPE")
                {
                    return _loc_1.value;
                }
            }
            return "";
        }// end function

        public function getAllItems() : Array
        {
            return _items;
        }// end function

        public function removeAllFields() : void
        {
            var _loc_1:FormField = null;
            var _loc_2:* = undefined;
            for each (_loc_1 in _fields)
            {
                
                for each (_loc_2 in _loc_1)
                {
                    
                    _loc_2.getNode().removeNode();
                    _loc_2.setNode(null);
                }
            }
            _fields = [];
            return;
        }// end function

        public function get title() : String
        {
            if (myTitleNode && myTitleNode.firstChild)
            {
                return myTitleNode.firstChild.nodeValue;
            }
            return null;
        }// end function

        public function serialize(param1:XMLNode) : Boolean
        {
            var _loc_3:FormField = null;
            var _loc_2:* = getNode();
            for each (_loc_3 in _fields)
            {
                
                if (!_loc_3.serialize(_loc_2))
                {
                    return false;
                }
            }
            if (param1 != _loc_2.parentNode)
            {
                param1.appendChild(_loc_2.cloneNode(true));
            }
            return true;
        }// end function

        public function getNS() : String
        {
            return FormExtension.NS;
        }// end function

        public function get instructions() : String
        {
            if (myInstructionsNode && myInstructionsNode.firstChild)
            {
                return myInstructionsNode.firstChild.nodeValue;
            }
            return null;
        }// end function

        public function getFormField(param1:String) : FormField
        {
            var _loc_2:FormField = null;
            for each (_loc_2 in _fields)
            {
                
                if (_loc_2.name == param1)
                {
                    return _loc_2;
                }
            }
            return null;
        }// end function

        public function getReportedFields() : Array
        {
            return myReportedFields;
        }// end function

        public function set type(param1:String) : void
        {
            getNode().attributes.type = param1;
            return;
        }// end function

        public function getElementName() : String
        {
            return FormExtension.ELEMENT_NAME;
        }// end function

        public function get type() : String
        {
            return getNode().attributes.type;
        }// end function

        public function setFields(param1:Object) : void
        {
            var _loc_2:String = null;
            var _loc_3:FormField = null;
            removeAllFields();
            for (_loc_2 in param1)
            {
                
                _loc_3 = new FormField();
                _loc_3.name = _loc_2;
                _loc_3.setAllValues(param1[_loc_2]);
                _fields.push(_loc_3);
            }
            return;
        }// end function

        public static function enable() : Boolean
        {
            ExtensionClassRegistry.register(FormExtension);
            return true;
        }// end function

    }
}
