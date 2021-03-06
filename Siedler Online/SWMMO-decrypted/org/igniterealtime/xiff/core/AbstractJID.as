﻿package org.igniterealtime.xiff.core
{

    public class AbstractJID extends Object
    {
        protected var _node:String = "";
        protected var _domain:String = "";
        private const BYTE_LIMIT_TOTAL:uint = 3071;
        protected var _resource:String = "";
        private const BYTE_LIMIT_ITEM:uint = 1023;
        private static var quoteregex2:RegExp = new RegExp("\'", "g");
        private static var quoteregex:RegExp = new RegExp("\"", "g");
        static var jidNodeValidator:RegExp = /^([\9\3-\5\8-\E\0-\'9\B\D\F\)1-\E\ 0    　 -  -​۝ ܏᠎‌-‍ - - ⁠-⁣⁪-⁯￹-￼-uFDD0-uFDEF uFFFE-uFFFF?-?￹-�⿰-⿻]{1,1023})""^([\x29\x23-\x25\x28-\x2E\x30-\x39\x3B\x3D\x3F\x41-\x7E\xA0    　 -  -​۝ ܏᠎‌-‍ - - ⁠-⁣⁪-⁯￹-￼-uFDD0-uFDEF uFFFE-uFFFF?-?￹-�⿰-⿻]{1,1023})/;

        public function AbstractJID(param1:String, param2:Boolean = false)
        {
            if (param2)
            {
                if (!jidNodeValidator.test(param1) || param1.indexOf(" ") > -1 || param1.length > BYTE_LIMIT_TOTAL)
                {
                    trace("Invalid JID: %s", param1);
                    throw "Invalid JID";
                }
            }
            var _loc_3:* = param1.lastIndexOf("@");
            var _loc_4:* = param1.lastIndexOf("/");
            if (param1.lastIndexOf("/") >= 0)
            {
                _resource = param1.substring((_loc_4 + 1));
            }
            _domain = param1.substring((_loc_3 + 1), _loc_4 >= 0 ? (_loc_4) : (param1.length));
            if (_loc_3 >= 1)
            {
                _node = param1.substring(0, _loc_3);
            }
            return;
        }// end function

        public function get domain() : String
        {
            return _domain;
        }// end function

        public function get bareJID() : String
        {
            var _loc_1:* = toString();
            var _loc_2:* = _loc_1.lastIndexOf("/");
            if (_loc_2 > 0)
            {
                _loc_1 = _loc_1.substring(0, _loc_2);
            }
            return _loc_1;
        }// end function

        public function toString() : String
        {
            var _loc_1:String = "";
            if (node)
            {
                _loc_1 = _loc_1 + (node + "@");
            }
            _loc_1 = _loc_1 + domain;
            if (resource)
            {
                _loc_1 = _loc_1 + ("/" + resource);
            }
            return _loc_1;
        }// end function

        public function get node() : String
        {
            if (_node.length > 0)
            {
                return _node;
            }
            return null;
        }// end function

        public function get resource() : String
        {
            if (_resource.length > 0)
            {
                return _resource;
            }
            return null;
        }// end function

        public static function escapedNode(param1:String) : String
        {
            if (param1 && (param1.indexOf("@") >= 0 || param1.indexOf(" ") >= 0 || param1.indexOf("\\") >= 0 || param1.indexOf("/") >= 0 || param1.indexOf("&") >= 0 || param1.indexOf("\'") >= 0 || param1.indexOf("\"") >= 0 || param1.indexOf(":") >= 0 || param1.indexOf("<") >= 0 || param1.indexOf(">") >= 0))
            {
                param1 = param1.replace(/\\\"""\\/g, "\\5c");
                param1 = param1.replace(/@""@/g, "\\40");
                param1 = param1.replace(/ "" /g, "\\20");
                param1 = param1.replace(/&""&/g, "\\26");
                param1 = param1.replace(/>"">/g, "\\3e");
                param1 = param1.replace(/<""</g, "\\3c");
                param1 = param1.replace(/:"":/g, "\\3a");
                param1 = param1.replace(/\/""\//g, "\\2f");
                param1 = param1.replace(quoteregex, "\\22");
                param1 = param1.replace(quoteregex2, "\\27");
            }
            return param1;
        }// end function

        public static function unescapedNode(param1:String) : String
        {
            if (param1 && (param1.indexOf("\\40") >= 0 || param1.indexOf("\\20") >= 0 || param1.indexOf("\\26") >= 0 || param1.indexOf("\\3e") >= 0 || param1.indexOf("\\3c") >= 0 || param1.indexOf("\\5c") >= 0 || param1.indexOf("\\3a") >= 0 || param1.indexOf("\\2f") >= 0 || param1.indexOf("\\22") >= 0 || param1.indexOf("\\27") >= 0))
            {
                param1 = param1.replace(/\40""\40/g, "@");
                param1 = param1.replace(/\20""\20/g, " ");
                param1 = param1.replace(/\26""\26/g, "&");
                param1 = param1.replace(/\3e""\3e/g, ">");
                param1 = param1.replace(/\3c""\3c/g, "<");
                param1 = param1.replace(/\3a""\3a/g, ":");
                param1 = param1.replace(/\2f""\2f/g, "/");
                param1 = param1.replace(quoteregex, "\"");
                param1 = param1.replace(quoteregex2, "\'");
                param1 = param1.replace(/\5c""\5c/g, "\\");
            }
            return param1;
        }// end function

    }
}
