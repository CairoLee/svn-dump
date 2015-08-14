package org.igniterealtime.xiff.data
{
    import flash.xml.*;

    public interface INodeProxy
    {

        public function INodeProxy();

        function getNode() : XMLNode;

        function setNode(param1:XMLNode) : Boolean;

    }
}
