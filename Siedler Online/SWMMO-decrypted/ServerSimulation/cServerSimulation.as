package ServerSimulation
{
    import Communication.VO.*;
    import Interface.*;
    import nLib.*;

    public class cServerSimulation extends Object
    {
        private var mFile:cFile;
        private var mDispatcherLoadLevel:cCustomDispatcher;
        private var mDispatcher:cCustomDispatcher;
        private var mGeneralInterface:cGeneralInterface;

        public function cServerSimulation(param1:cGeneralInterface)
        {
            this.mDispatcher = new cCustomDispatcher();
            this.mDispatcherLoadLevel = new cCustomDispatcher();
            this.mGeneralInterface = param1;
            return;
        }// end function

        public function SendSimulatedClientMessage(param1:dServerCall) : void
        {
            return;
        }// end function

    }
}
