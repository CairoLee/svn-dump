package mx.rpc
{
    import mx.rpc.*;

    public class AsyncResponder extends Object implements IResponder
    {
        private var _faultHandler:Function;
        private var _token:Object;
        private var _resultHandler:Function;

        public function AsyncResponder(param1:Function, param2:Function, param3:Object = null)
        {
            _resultHandler = param1;
            _faultHandler = param2;
            _token = param3;
            return;
        }// end function

        public function result(param1:Object) : void
        {
            _resultHandler(param1, _token);
            return;
        }// end function

        public function fault(param1:Object) : void
        {
            _faultHandler(param1, _token);
            return;
        }// end function

    }
}
