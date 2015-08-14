package GUI.GAME
{
    import GO.*;

    public class cBasicInfoPanel extends cBasicPanel
    {

        public function cBasicInfoPanel()
        {
            return;
        }// end function

        public function SetData(param1:cBuilding) : void
        {
            throw new Error("Abstract method called. Method must be overidden.");
        }// end function

    }
}
