package com.hurlant.crypto.hash
{
    import com.hurlant.crypto.hash.*;
    import flash.utils.*;

    public class MAC extends Object implements IHMAC
    {
        private var innerHash:ByteArray;
        private var pad_1:ByteArray;
        private var bits:uint;
        private var pad_2:ByteArray;
        private var hash:IHash;
        private var outerKey:ByteArray;
        private var outerHash:ByteArray;
        private var innerKey:ByteArray;

        public function MAC(param1:IHash, param2:uint = 0)
        {
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            this.hash = param1;
            this.bits = param2;
            innerHash = new ByteArray();
            outerHash = new ByteArray();
            innerKey = new ByteArray();
            outerKey = new ByteArray();
            if (param1 != null)
            {
                _loc_3 = param1.getPadSize();
                pad_1 = new ByteArray();
                pad_2 = new ByteArray();
                _loc_4 = 0;
                while (_loc_4 < _loc_3)
                {
                    
                    pad_1.writeByte(54);
                    pad_2.writeByte(92);
                    _loc_4++;
                }
            }
            return;
        }// end function

        public function getHashSize() : uint
        {
            if (bits != 0)
            {
                return bits / 8;
            }
            return hash.getHashSize();
        }// end function

        public function dispose() : void
        {
            hash = null;
            bits = 0;
            return;
        }// end function

        public function toString() : String
        {
            return "mac-" + (bits > 0 ? (bits + "-") : ("")) + hash.toString();
        }// end function

        public function setPadSize(param1:int) : void
        {
            return;
        }// end function

        public function compute(param1:ByteArray, param2:ByteArray) : ByteArray
        {
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            if (pad_1 == null)
            {
                _loc_3 = hash.getPadSize();
                pad_1 = new ByteArray();
                pad_2 = new ByteArray();
                _loc_4 = 0;
                while (_loc_4 < _loc_3)
                {
                    
                    pad_1.writeByte(54);
                    pad_2.writeByte(92);
                    _loc_4++;
                }
            }
            innerKey.length = 0;
            outerKey.length = 0;
            innerKey.writeBytes(param1);
            innerKey.writeBytes(pad_1);
            innerKey.writeBytes(param2);
            innerHash = hash.hash(innerKey);
            outerKey.writeBytes(param1);
            outerKey.writeBytes(pad_2);
            outerKey.writeBytes(innerHash);
            outerHash = hash.hash(outerKey);
            if (bits > 0 && bits < 8 * outerHash.length)
            {
                outerHash.length = bits / 8;
            }
            return outerHash;
        }// end function

    }
}
