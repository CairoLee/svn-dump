package GUI
{
    import GO.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import mx.collections.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import nLib.*;
    import nLib.SpriteLibDataClass.*;

    public class cTileList extends cGuiBaseElement
    {
        protected var mTileListDataProvider:ArrayCollection;
        protected var mTileList:TileList;
        protected var mAllowedTypes:Array = null;

        public function cTileList()
        {
            return;
        }// end function

        public function Refresh() : void
        {
            this.mTileList.dataProvider = this.mTileListDataProvider;
            return;
        }// end function

        protected function AddSpriteListToGuiSelector(param1:Number, param2, param3:Array, param4:int, param5:Function, param6:Function) : void
        {
            var _loc_8:cGOSpriteLibContainer = null;
            var _loc_9:String = null;
            var _loc_10:Vector.<dSubtypeCalculated> = null;
            var _loc_11:dSubtypeCalculated = null;
            var _loc_12:dFrameCalculated = null;
            var _loc_13:BitmapData = null;
            var _loc_14:BitmapData = null;
            var _loc_15:String = null;
            var _loc_7:* = Application.application.mGeneralInterface.mZoom.GetScaleFactor();
            Application.application.mGeneralInterface.mZoom.SetScaleFactor(param1, false);
            for each (_loc_8 in param2)
            {
                
                _loc_8.Rescale(0, 0);
                if (this.param5(_loc_8))
                {
                    _loc_9 = _loc_8.mGfxResourceListName_string;
                    _loc_10 = _loc_8.mSubtypeCalculated_vector;
                    _loc_11 = _loc_10[0];
                    _loc_12 = _loc_11.frameList_vector[0];
                    _loc_13 = _loc_12.scaledBitmap;
                    _loc_14 = _loc_13.clone();
                    _loc_15 = _loc_9;
                    if (param6 != null)
                    {
                        _loc_15 = this.param6(_loc_15);
                    }
                    param3.push({label:_loc_15, bitmapData:_loc_14, levelObjectType:param4, gfxResourceListName:_loc_9});
                }
            }
            Application.application.mGeneralInterface.mZoom.SetScaleFactor(1000, true);
            Application.application.mGeneralInterface.mZoom.SetScaleFactor(_loc_7, true);
            return;
        }// end function

        public function Click(event:ListEvent) : void
        {
            return;
        }// end function

        public function Init(param1:TileList) : void
        {
            AddBaseElement(param1);
            this.mTileList = param1;
            return;
        }// end function

        public function SetElementWithGfxResourceListName(param1:String) : void
        {
            var _loc_2:Object = null;
            for each (_loc_2 in this.mTileList.dataProvider)
            {
                
                if (_loc_2.gfxResourceListName == param1)
                {
                    this.mTileList.selectedItem = _loc_2;
                    break;
                }
            }
            return;
        }// end function

        public function SetElement(param1:int) : void
        {
            this.mTileList.selectedItem = this.mTileList.dataProvider[param1];
            return;
        }// end function

        protected function FilterSpriteList(param1:cGOSpriteLibContainer) : Boolean
        {
            var _loc_2:cXML = null;
            var _loc_3:String = null;
            var _loc_4:String = null;
            _loc_2 = param1.mExternalData as cXML;
            _loc_3 = _loc_2.GetAttributeString_string("name");
            for each (_loc_4 in this.mAllowedTypes)
            {
                
                if (_loc_3 == _loc_4)
                {
                    return true;
                }
            }
            return false;
        }// end function

    }
}
