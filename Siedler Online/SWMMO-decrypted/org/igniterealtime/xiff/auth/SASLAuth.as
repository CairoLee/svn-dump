package org.igniterealtime.xiff.auth
{

    public class SASLAuth extends Object
    {
        protected var response:XML;
        protected var req:XML;
        protected var stage:int;

        public function SASLAuth()
        {
            req = <auth/>")("<auth/>;
            response = <response/>")("<response/>;
            return;
        }// end function

        public function handleResponse(param1:int, param2:XML) : Object
        {
            throw new Error("Don\'t call this method on SASLAuth; use a subclass");
        }// end function

        public function handleChallenge(param1:int, param2:XML) : XML
        {
            throw new Error("Don\'t call this method on SASLAuth; use a subclass");
        }// end function

        public function get request() : XML
        {
            return req;
        }// end function

    }
}
