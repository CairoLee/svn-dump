package mx.controls.listClasses
{
    import flash.events.*;
    import mx.core.*;
    import mx.managers.*;
    import mx.styles.*;

    public interface IListItemRenderer extends IDataRenderer, IEventDispatcher, IFlexDisplayObject, ILayoutManagerClient, ISimpleStyleClient, IUIComponent
    {

        public function IListItemRenderer();

    }
}
