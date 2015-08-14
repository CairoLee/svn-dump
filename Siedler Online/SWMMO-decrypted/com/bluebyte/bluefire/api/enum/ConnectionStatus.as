package com.bluebyte.bluefire.api.enum
{

    public class ConnectionStatus extends Object
    {
        public static const SERVER_NOT_AVAILABLE:int = 2;
        public static const LOGGING_IN:int = 4;
        public static const CONNECT_SUCCESS:int = 0;
        public static const LOGGED_IN:int = 5;
        public static const LOGIN_FAILED:int = 3;
        public static const TRYING_TO_CONNECT:int = 1;

        public function ConnectionStatus()
        {
            return;
        }// end function

    }
}
