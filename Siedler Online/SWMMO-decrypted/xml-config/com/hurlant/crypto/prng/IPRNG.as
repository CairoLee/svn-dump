package com.hurlant.crypto.prng
{
    import flash.utils.*;

    public interface IPRNG
    {

        public function IPRNG();

        function init(param1:ByteArray) : void;

        function next() : uint;

        function getPoolSize() : uint;

        function toString() : String;

        function dispose() : void;

    }
}
