package org.igniterealtime.xiff.data
{
    import org.igniterealtime.xiff.data.*;

    public class ExtensionContainer extends Object implements IExtendable
    {
        public var _exts:Object;

        public function ExtensionContainer()
        {
            _exts = {};
            return;
        }// end function

        public function removeAllExtensions(param1:String) : void
        {
            var _loc_2:String = null;
            for (_loc_2 in _exts[param1])
            {
                
                removeExtension(_exts[param1][_loc_2]);
            }
            _exts[param1] = [];
            return;
        }// end function

        public function getAllExtensionsByNS(param1:String) : Array
        {
            return _exts[param1];
        }// end function

        public function getExtension(param1:String) : Extension
        {
            var name:* = param1;
            return getAllExtensions().filter(function (param1:IExtension, param2:int, param3:Array) : Boolean
            {
                return null.getElementName() == name;
            }// end function
            )[0];
        }// end function

        public function removeExtension(param1:IExtension) : Boolean
        {
            var _loc_3:String = null;
            var _loc_2:* = _exts[param1.getNS()];
            for (_loc_3 in _loc_2)
            {
                
                if (_loc_2[_loc_3] === param1)
                {
                    _loc_2[_loc_3].remove();
                    _loc_2.splice(parseInt(_loc_3), 1);
                    return true;
                }
            }
            return false;
        }// end function

        public function addExtension(param1:IExtension) : IExtension
        {
            if (_exts[param1.getNS()] == null)
            {
                _exts[param1.getNS()] = [];
            }
            _exts[param1.getNS()].push(param1);
            return param1;
        }// end function

        public function getAllExtensions() : Array
        {
            var _loc_2:String = null;
            var _loc_1:Array = [];
            for (_loc_2 in _exts)
            {
                
                _loc_1 = _loc_1.concat(_exts[_loc_2]);
            }
            return _loc_1;
        }// end function

    }
}
