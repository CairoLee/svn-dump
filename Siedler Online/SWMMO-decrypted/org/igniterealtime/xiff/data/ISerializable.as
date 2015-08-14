package org.igniterealtime.xiff.data
{
    import flash.xml.*;

    public interface ISerializable
    {

        public function ISerializable();

        function serialize(param1:XMLNode) : Boolean;

        function deserialize(param1:XMLNode) : Boolean;

    }
}
