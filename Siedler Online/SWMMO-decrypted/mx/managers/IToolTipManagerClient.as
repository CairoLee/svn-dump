package mx.managers
{
    import mx.core.*;

    public interface IToolTipManagerClient extends IFlexDisplayObject
    {

        public function IToolTipManagerClient();

        function get toolTip() : String;

        function set toolTip(param1:String) : void;

    }
}
