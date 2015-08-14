package GUI.GENERAL
{
    import Enums.*;
    import GUI.*;
    import mx.collections.*;

    public class cTileListSetMode extends cTileList
    {

        public function cTileListSetMode()
        {
            return;
        }// end function

        public function SetData() : ArrayCollection
        {
            var _loc_1:* = new Array();
            AddSpriteListToGuiSelector(1000, global.guiIconGroup.mGOList_vector, _loc_1, OBJECTTYPE.GUIICON, FilterSpriteList, null);
            return new ArrayCollection(_loc_1);
        }// end function

    }
}
