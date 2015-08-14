package 
{
    import GUI.Components.*;
    import GUI.Loca.*;
    import mx.controls.*;
    import nLib.*;

    public class gErrorMessages extends Object
    {

        public function gErrorMessages()
        {
            return;
        }// end function

        public static function TraceError(param1:String) : void
        {
            gMisc.ConsoleOut(param1);
            return;
        }// end function

        public static function TraceWarning(param1:String) : void
        {
            gMisc.ConsoleOut(param1);
            return;
        }// end function

        public static function ShowWarningMessage(param1:String) : void
        {
            Alert.show(param1);
            gMisc.ConsoleOut(param1);
            return;
        }// end function

        public static function ShowIOErrorMessage(param1:String) : void
        {
            var _loc_2:String = null;
            var _loc_3:String = null;
            gMisc.ConsoleOut("Could not load file: " + param1);
            if (cLocaManager.GetInstance().IsInitialized())
            {
                CustomAlert.show("IOError", "IOError");
            }
            else
            {
                _loc_2 = "File loading failed";
                _loc_3 = "The client was unable to load a data file.\nDelete your browser cache and try again.";
                CustomAlert.show(_loc_3, _loc_2, 4, null, null, null, 4, false);
            }
            return;
        }// end function

        public static function TraceInfo(param1:String) : void
        {
            gMisc.ConsoleOut(param1);
            return;
        }// end function

        public static function ShowErrorMessage(param1:String) : void
        {
            Alert.show(param1);
            gMisc.ConsoleOut(param1);
            return;
        }// end function

        public static function ShowInfoMessage(param1:String) : void
        {
            Alert.show(param1);
            gMisc.ConsoleOut(param1);
            return;
        }// end function

        public static function ShowGameInfo(param1:String) : void
        {
            Alert.show(param1);
            return;
        }// end function

    }
}
