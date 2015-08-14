package com.bluebyte.bluefire.api.controller.slashCommands
{

    public class SlashCommand extends Object
    {
        protected var _regEx:Object;

        public function SlashCommand()
        {
            return;
        }// end function

        final public function execute(param1:String) : String
        {
            if (param1.toLowerCase().search(this._regEx) != -1)
            {
                return this.internalEvaluate(param1);
            }
            return null;
        }// end function

        protected function internalEvaluate(param1:String) : String
        {
            throw new Error("Abstract Method!");
        }// end function

    }
}
