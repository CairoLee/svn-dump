package com.hurlant.crypto.hash
{
    import flash.utils.*;

    public interface IHash
    {

        public function IHash();

        function getInputSize() : uint;

        function getHashSize() : uint;

        function toString() : String;

        function hash(param1:ByteArray) : ByteArray;

        function getPadSize() : int;

    }
}
