package mx.core
{
    import mx.core.*;

    public class DeferredInstanceFromFunction extends Object implements IDeferredInstance
    {
        private var generator:Function;
        private var instance:Object = null;
        static const VERSION:String = "3.5.0.12683";

        public function DeferredInstanceFromFunction(param1:Function)
        {
            this.generator = param1;
            return;
        }// end function

        public function getInstance() : Object
        {
            if (!instance)
            {
                instance = generator();
            }
            return instance;
        }// end function

    }
}
