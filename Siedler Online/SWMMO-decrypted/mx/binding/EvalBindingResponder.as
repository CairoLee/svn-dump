package mx.binding
{
    import mx.rpc.*;

    public class EvalBindingResponder extends Object implements IResponder
    {
        private var binding:Binding;
        private var object:Object;
        static const VERSION:String = "3.5.0.12683";

        public function EvalBindingResponder(param1:Binding, param2:Object)
        {
            this.binding = param1;
            this.object = param2;
            return;
        }// end function

        public function fault(param1:Object) : void
        {
            return;
        }// end function

        public function result(param1:Object) : void
        {
            binding.execute(object);
            return;
        }// end function

    }
}
