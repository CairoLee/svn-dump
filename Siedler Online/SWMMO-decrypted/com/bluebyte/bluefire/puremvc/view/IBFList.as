package com.bluebyte.bluefire.puremvc.view
{

    public interface IBFList
    {

        public function IBFList();

        function set dataProvider(param1:Object) : void;

        function get dataProvider() : Object;

        function set selectedItem(param1:Object) : void;

        function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void;

        function get selectedItem() : Object;

    }
}
