package com.bluebyte.bluefire.puremvc.view
{

    public interface IBFTextInput
    {

        public function IBFTextInput();

        function get visible() : Boolean;

        function set visible(param1:Boolean) : void;

        function setFocus() : void;

        function set text(param1:String) : void;

        function get text() : String;

        function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void;

    }
}
