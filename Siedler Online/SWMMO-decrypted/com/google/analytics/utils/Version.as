package com.google.analytics.utils
{

    public class Version extends Object
    {
        private var _revision:uint;
        private var _maxBuild:uint = 255;
        private var _maxMinor:uint = 15;
        private var _maxMajor:uint = 15;
        private var _separator:String = ".";
        private var _maxRevision:uint = 65535;
        private var _build:uint;
        private var _major:uint;
        private var _minor:uint;

        public function Version(param1:uint = 0, param2:uint = 0, param3:uint = 0, param4:uint = 0)
        {
            var _loc_5:Version = null;
            if (param1 > _maxMajor && param2 == 0 && param3 == 0 && param4 == 0)
            {
                _loc_5 = Version.fromNumber(param1);
                param1 = _loc_5.major;
                param2 = _loc_5.minor;
                param3 = _loc_5.build;
                param4 = _loc_5.revision;
            }
            this.major = param1;
            this.minor = param2;
            this.build = param3;
            this.revision = param4;
            return;
        }// end function

        public function toString(param1:int = 0) : String
        {
            var _loc_2:Array = null;
            if (param1 <= 0 || param1 > 4)
            {
                param1 = getFields();
            }
            switch(param1)
            {
                case 1:
                {
                    _loc_2 = [major];
                    break;
                }
                case 2:
                {
                    _loc_2 = [major, minor];
                    break;
                }
                case 3:
                {
                    _loc_2 = [major, minor, build];
                    break;
                }
                case 4:
                {
                }
                default:
                {
                    _loc_2 = [major, minor, build, revision];
                    break;
                }
            }
            return _loc_2.join(_separator);
        }// end function

        public function set revision(param1:uint) : void
        {
            _revision = Math.min(param1, _maxRevision);
            return;
        }// end function

        public function get revision() : uint
        {
            return _revision;
        }// end function

        public function set build(param1:uint) : void
        {
            _build = Math.min(param1, _maxBuild);
            return;
        }// end function

        public function set minor(param1:uint) : void
        {
            _minor = Math.min(param1, _maxMinor);
            return;
        }// end function

        public function get build() : uint
        {
            return _build;
        }// end function

        public function set major(param1:uint) : void
        {
            _major = Math.min(param1, _maxMajor);
            return;
        }// end function

        public function get minor() : uint
        {
            return _minor;
        }// end function

        private function getFields() : int
        {
            var _loc_1:int = 4;
            if (revision == 0)
            {
                _loc_1 = _loc_1 - 1;
            }
            if (_loc_1 == 3 && build == 0)
            {
                _loc_1 = _loc_1 - 1;
            }
            if (_loc_1 == 2 && minor == 0)
            {
                _loc_1 = _loc_1 - 1;
            }
            return _loc_1;
        }// end function

        public function valueOf() : uint
        {
            return major << 28 | minor << 24 | build << 16 | revision;
        }// end function

        public function get major() : uint
        {
            return _major;
        }// end function

        public function equals(param1) : Boolean
        {
            if (!(param1 is Version))
            {
                return false;
            }
            if (param1.major == major && param1.minor == minor && param1.build == build && param1.revision == revision)
            {
                return true;
            }
            return false;
        }// end function

        public static function fromString(param1:String = "", param2:String = ".") : Version
        {
            var _loc_4:Array = null;
            var _loc_3:* = new Version;
            if (param1 == "" || param1 == null)
            {
                return _loc_3;
            }
            if (param1.indexOf(param2) > -1)
            {
                _loc_4 = param1.split(param2);
                _loc_3.major = parseInt(_loc_4[0]);
                _loc_3.minor = parseInt(_loc_4[1]);
                _loc_3.build = parseInt(_loc_4[2]);
                _loc_3.revision = parseInt(_loc_4[3]);
            }
            else
            {
                _loc_3.major = parseInt(param1);
            }
            return _loc_3;
        }// end function

        public static function fromNumber(param1:Number = 0) : Version
        {
            var _loc_2:* = new Version;
            if (isNaN(param1) || param1 == 0 || param1 < 0 || param1 == Number.MAX_VALUE || param1 == Number.POSITIVE_INFINITY || param1 == Number.NEGATIVE_INFINITY)
            {
                return _loc_2;
            }
            _loc_2.major = param1 >>> 28;
            _loc_2.minor = (param1 & 251658240) >>> 24;
            _loc_2.build = (param1 & 16711680) >>> 16;
            _loc_2.revision = param1 & 65535;
            return _loc_2;
        }// end function

    }
}
