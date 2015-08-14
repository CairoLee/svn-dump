package SettlerKI
{
    import GO.*;

    public class cSettlerKIDoNothing extends cSettlerKI
    {

        public function cSettlerKIDoNothing(param1:cSettler)
        {
            super(param1);
            return;
        }// end function

        override public function Compute() : void
        {
            return;
        }// end function

    }
}
