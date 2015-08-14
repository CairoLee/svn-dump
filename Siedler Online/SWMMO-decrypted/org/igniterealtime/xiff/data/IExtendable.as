package org.igniterealtime.xiff.data
{

    public interface IExtendable
    {

        public function IExtendable();

        function removeAllExtensions(param1:String) : void;

        function getAllExtensionsByNS(param1:String) : Array;

        function removeExtension(param1:IExtension) : Boolean;

        function addExtension(param1:IExtension) : IExtension;

        function getAllExtensions() : Array;

    }
}
