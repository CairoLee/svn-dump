package com.google.analytics.core
{
    import com.google.analytics.utils.*;

    public class Organic extends Object
    {
        private var _sourcesCache:Array;
        private var _sourcesEngine:Array;
        private var _ignoredKeywords:Array;
        private var _ignoredReferralsCache:Object;
        private var _ignoredReferrals:Array;
        private var _ignoredKeywordsCache:Object;
        private var _sources:Array;
        public static var throwErrors:Boolean = false;

        public function Organic()
        {
            _sources = [];
            _sourcesCache = [];
            _sourcesEngine = [];
            _ignoredReferrals = [];
            _ignoredReferralsCache = {};
            _ignoredKeywords = [];
            _ignoredKeywordsCache = {};
            return;
        }// end function

        public function isIgnoredKeyword(param1:String) : Boolean
        {
            if (_ignoredKeywordsCache.hasOwnProperty(param1))
            {
                return true;
            }
            return false;
        }// end function

        public function getKeywordValue(param1:OrganicReferrer, param2:String) : String
        {
            var _loc_3:* = param1.keyword;
            return getKeywordValueFromPath(_loc_3, param2);
        }// end function

        public function isIgnoredReferral(param1:String) : Boolean
        {
            if (_ignoredReferralsCache.hasOwnProperty(param1))
            {
                return true;
            }
            return false;
        }// end function

        public function clear() : void
        {
            clearEngines();
            clearIgnoredReferrals();
            clearIgnoredKeywords();
            return;
        }// end function

        public function get count() : int
        {
            return _sources.length;
        }// end function

        public function get ignoredKeywordsCount() : int
        {
            return _ignoredKeywords.length;
        }// end function

        public function match(param1:String) : Boolean
        {
            if (param1 == "")
            {
                return false;
            }
            param1 = param1.toLowerCase();
            if (_sourcesEngine[param1] != undefined)
            {
                return true;
            }
            return false;
        }// end function

        public function clearIgnoredKeywords() : void
        {
            _ignoredKeywords = [];
            _ignoredKeywordsCache = {};
            return;
        }// end function

        public function addSource(param1:String, param2:String) : void
        {
            var _loc_3:* = new OrganicReferrer(param1, param2);
            if (_sourcesCache[_loc_3.toString()] == undefined)
            {
                _sources.push(_loc_3);
                _sourcesCache[_loc_3.toString()] = _sources.length - 1;
                if (_sourcesEngine[_loc_3.engine] == undefined)
                {
                    _sourcesEngine[_loc_3.engine] = [(_sources.length - 1)];
                }
                else
                {
                    _sourcesEngine[_loc_3.engine].push((_sources.length - 1));
                }
            }
            else if (throwErrors)
            {
                throw new Error(_loc_3.toString() + " already exists, we don\'t add it.");
            }
            return;
        }// end function

        public function clearEngines() : void
        {
            _sources = [];
            _sourcesCache = [];
            _sourcesEngine = [];
            return;
        }// end function

        public function get ignoredReferralsCount() : int
        {
            return _ignoredReferrals.length;
        }// end function

        public function addIgnoredReferral(param1:String) : void
        {
            if (_ignoredReferralsCache[param1] == undefined)
            {
                _ignoredReferrals.push(param1);
                _ignoredReferralsCache[param1] = _ignoredReferrals.length - 1;
            }
            else if (throwErrors)
            {
                throw new Error("\"" + param1 + "\" already exists, we don\'t add it.");
            }
            return;
        }// end function

        public function clearIgnoredReferrals() : void
        {
            _ignoredReferrals = [];
            _ignoredReferralsCache = {};
            return;
        }// end function

        public function getReferrerByName(param1:String) : OrganicReferrer
        {
            var _loc_2:int = 0;
            if (match(param1))
            {
                _loc_2 = _sourcesEngine[param1][0];
                return _sources[_loc_2];
            }
            return null;
        }// end function

        public function addIgnoredKeyword(param1:String) : void
        {
            if (_ignoredKeywordsCache[param1] == undefined)
            {
                _ignoredKeywords.push(param1);
                _ignoredKeywordsCache[param1] = _ignoredKeywords.length - 1;
            }
            else if (throwErrors)
            {
                throw new Error("\"" + param1 + "\" already exists, we don\'t add it.");
            }
            return;
        }// end function

        public function get sources() : Array
        {
            return _sources;
        }// end function

        public static function getKeywordValueFromPath(param1:String, param2:String) : String
        {
            var _loc_3:String = null;
            var _loc_4:Variables = null;
            if (param2.indexOf(param1 + "=") > -1)
            {
                if (param2.charAt(0) == "?")
                {
                    param2 = param2.substr(1);
                }
                param2 = param2.split("+").join("%20");
                _loc_4 = new Variables(param2);
                _loc_3 = _loc_4[param1];
            }
            return _loc_3;
        }// end function

    }
}
