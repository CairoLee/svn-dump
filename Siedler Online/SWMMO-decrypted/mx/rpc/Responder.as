package mx.rpc
{
    import mx.rpc.*;

    public class Responder extends Object implements IResponder
    {
        private var _faultHandler:Function;
        private var _resultHandler:Function;

        public function Responder(param1:Function, param2:Function)
        {
            _resultHandler = param1;
            _faultHandler = param2;
            return;
        }// end function

        public function result(param1:Object) : void
        {
            _resultHandler(param1);
            return;
        }// end function

        public function fault(param1:Object) : void
        {
            _faultHandler(param1);
            return;
        }// end function

    }
}
