package mx.controls.menuClasses
{
    import mx.controls.*;
    import mx.controls.listClasses.*;
    import mx.core.*;
    import mx.styles.*;

    public interface IMenuBarItemRenderer extends IDataRenderer, IUIComponent, ISimpleStyleClient, IListItemRenderer
    {

        public function IMenuBarItemRenderer();

        function get menuBar() : MenuBar;

        function set menuBarItemState(param1:String) : void;

        function set menuBarItemIndex(param1:int) : void;

        function set menuBar(param1:MenuBar) : void;

        function get menuBarItemState() : String;

        function get menuBarItemIndex() : int;

    }
}
