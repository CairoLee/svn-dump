package GOSets
{
    import GO.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class cGOSetManager extends Object
    {

        public function cGOSetManager()
        {
            return;
        }// end function

        public static function CreateSingleGfxGOSetList(param1:String, param2:int, param3:int, param4:cGOGroup) : cGOSetList
        {
            var _loc_5:* = new cGOSetListControllerStatic();
            var _loc_6:* = new cGOSetItem();
            new cGOSetItem().mOffsetX = param2;
            _loc_6.mOffsetY = param3;
            _loc_6.mSpriteLib = param4.GetSpriteLibFromNameGOList(param1);
            _loc_6.mSpriteLib.SetSubType(0);
            _loc_6.mSpriteLib.SetAnim((_loc_6.mSpriteLib.GetContainer() as cGOSpriteLibContainer).mEffectDefaultAnimSpeed, true);
            _loc_6.mSpriteLib.SetAnimFrame(0);
            var _loc_7:* = new cGOSet();
            new cGOSet().mGOSetItem_vector.push(_loc_6);
            var _loc_8:* = new cGOSetListItem();
            new cGOSetListItem().mValue = 0;
            _loc_8.mGOSet = _loc_7;
            var _loc_9:* = new cGOSetList(_loc_5);
            new cGOSetList(_loc_5).mName_string = param1;
            _loc_9.mBlocking_vector = null;
            _loc_9.mGOSetListItem_vector.push(_loc_8);
            _loc_5.SetValue(0);
            return _loc_9;
        }// end function

        public static function CreateGOSetList(param1:String, param2:cGOSetListController) : cGOSetList
        {
            var _loc_5:cGOSetList = null;
            var _loc_6:cGOSetListItem = null;
            var _loc_7:cGOSetListItem = null;
            if (param2 == null)
            {
                param2 = new cGOSetListControllerStatic();
            }
            var _loc_3:* = new cGOSetList(param2);
            var _loc_4:* = gMisc.RemoveExtension(param1);
            for each (_loc_5 in global.goSetList_vector)
            {
                
                if (_loc_5.mName_string == _loc_4)
                {
                    _loc_3.mName_string = _loc_5.mName_string;
                    _loc_3.mType_string = _loc_5.mType_string;
                    _loc_3.mBlocking_vector = _loc_5.mBlocking_vector;
                    for each (_loc_6 in _loc_5.mGOSetListItem_vector)
                    {
                        
                        _loc_7 = new cGOSetListItem();
                        _loc_7.mValue = _loc_6.mValue;
                        _loc_7.mName_string = _loc_6.mName_string;
                        _loc_7.mGOSet = CreateGOSet(_loc_7.mName_string);
                        _loc_3.mGOSetListItem_vector.push(_loc_7);
                    }
                    param2.SetValue(0);
                    return _loc_3;
                }
            }
            gMisc.Assert(false, "Wrong GOSetList name: " + _loc_4);
            return null;
        }// end function

        private static function CreateGOSet(param1:String) : cGOSet
        {
            var _loc_3:cGOSet = null;
            var _loc_4:cGOSetItem = null;
            var _loc_5:cGOSetItem = null;
            var _loc_6:cGOGroup = null;
            var _loc_2:* = new cGOSet();
            for each (_loc_3 in global.goSet_vector)
            {
                
                if (_loc_3.mName_string == param1)
                {
                    for each (_loc_4 in _loc_3.mGOSetItem_vector)
                    {
                        
                        _loc_5 = new cGOSetItem();
                        _loc_5.mOffsetX = _loc_4.mOffsetX;
                        _loc_5.mOffsetY = _loc_4.mOffsetY;
                        _loc_5.mName_string = _loc_4.mName_string;
                        _loc_5.mGroup_string = _loc_4.mGroup_string;
                        _loc_6 = new cGOGroup();
                        if (_loc_5.mGroup_string == "Landscapes")
                        {
                            _loc_6 = global.landscapeGroup;
                        }
                        else if (_loc_5.mGroup_string == "Effects")
                        {
                            _loc_6 = global.effectGroup;
                        }
                        else if (_loc_5.mGroup_string == "Buildings")
                        {
                            _loc_6 = global.buildingGroup;
                        }
                        else if (_loc_5.mGroup_string == "Settlers")
                        {
                            _loc_6 = global.settlerGroup;
                        }
                        _loc_5.mSpriteLib = _loc_6.GetSpriteLibFromNameGOList(_loc_5.mName_string);
                        _loc_5.mSpriteLib.SetSubType(0);
                        _loc_5.mSpriteLib.SetAnim((_loc_5.mSpriteLib.GetContainer() as cGOSpriteLibContainer).mEffectDefaultAnimSpeed, true);
                        _loc_5.mSpriteLib.SetAnimFrame(0);
                        _loc_2.mGOSetItem_vector.push(_loc_5);
                    }
                    return _loc_2;
                }
            }
            gMisc.Assert(false, "GOSet name " + param1 + " not found!");
            return null;
        }// end function

        public static function LoadGOSetData() : void
        {
            var xml:cXML;
            var goListGfxObjectsList:cXML;
            var xml3:cXML;
            var eset:cGOSet;
            var xml2:cXML;
            var eitem:cGOSetItem;
            var gosetlist:cGOSetList;
            var arr_vector:Vector.<cGOSetListItem>;
            var xml4:cXML;
            var i:cGOSetListItem;
            var xml5:cXML;
            var gosetlistitem:cGOSetListItem;
            var blockList:cXML;
            var blockListArray:Vector.<cXML>;
            var blockingDataXml:cXML;
            var gfxObjectsList:* = global.gfxSettingsRootXML.MoveToSubNode("GameObjects");
            var goGfxObjectsList:* = gfxObjectsList.MoveToSubNode("GOSets");
            var gfxObjectsListArray:* = goGfxObjectsList.CreateChildrenArray();
            var _loc_2:int = 0;
            var _loc_3:* = gfxObjectsListArray;
            while (_loc_3 in _loc_2)
            {
                
                xml = _loc_3[_loc_2];
                eset = new cGOSet();
                eset.mName_string = xml.GetAttributeString_string("name");
                eset.mID = xml.GetAttributeInt("id");
                var _loc_4:int = 0;
                var _loc_5:* = xml.CreateChildrenArray();
                while (_loc_5 in _loc_4)
                {
                    
                    xml2 = _loc_5[_loc_4];
                    eitem = new cGOSetItem();
                    eitem.mOffsetX = xml2.GetAttributeInt("x");
                    eitem.mOffsetY = xml2.GetAttributeInt("y");
                    eitem.mName_string = xml2.GetAttributeString_string("name");
                    eitem.mGroup_string = xml2.GetAttributeString_string("group");
                    eset.mGOSetItem_vector.push(eitem);
                }
                global.goSet_vector.push(eset);
            }
            goListGfxObjectsList = gfxObjectsList.MoveToSubNode("GOSetLists");
            gfxObjectsListArray = goListGfxObjectsList.CreateChildrenArray();
            var _loc_2:int = 0;
            var _loc_3:* = gfxObjectsListArray;
            while (_loc_3 in _loc_2)
            {
                
                xml3 = _loc_3[_loc_2];
                gosetlist = new cGOSetList(null);
                gosetlist.mName_string = xml3.GetAttributeString_string("name");
                gosetlist.mType_string = xml3.GetAttributeString_string("type");
                arr_vector = new Vector.<cGOSetListItem>;
                var _loc_4:int = 0;
                var _loc_5:* = xml3.CreateChildrenArray();
                while (_loc_5 in _loc_4)
                {
                    
                    xml4 = _loc_5[_loc_4];
                    gosetlistitem = new cGOSetListItem();
                    gosetlistitem.mName_string = xml4.GetAttributeString_string("name");
                    gosetlistitem.mValue = xml4.GetAttributeInt("value");
                    arr_vector.push(gosetlistitem);
                }

                with ({})
                {
                    {}.compare = function (param1:cGOSetListItem, param2:cGOSetListItem) : Number
					{
						if (param1.mValue < param2.mValue)
						{
							return -1;
						}
						return 1;
					};// end function

                }
                arr_vector.sort(function (param1:cGOSetListItem, param2:cGOSetListItem) : Number
				{
					if (param1.mValue < param2.mValue)
					{
						return -1;
					}
					return 1;
				}); // end function

                var _loc_4:int = 0;
                var _loc_5:* = arr_vector;
                while (_loc_5 in _loc_4)
                {
                    
                    i = _loc_5[_loc_4];
                    gosetlist.mGOSetListItem_vector.push(i);
                }
                var _loc_4:int = 0;
                var _loc_5:* = global.gameSettingsRootXML.MoveToSubNode("GameObjects").MoveToSubNode("GOSets").CreateChildrenArray();
                while (_loc_5 in _loc_4)
                {
                    
                    xml5 = _loc_5[_loc_4];
                    if (xml5.GetAttributeString_string("name") == xml3.GetAttributeString_string("blockingset"))
                    {
                        blockList = xml5.MoveToSubNode("Blocks");
                        blockListArray = blockList.CreateChildrenArray();
                        var _loc_6:int = 0;
                        var _loc_7:* = blockListArray;
                        while (_loc_7 in _loc_6)
                        {
                            
                            blockingDataXml = _loc_7[_loc_6];
                            gosetlist.mBlocking_vector.push(new cBlockingData(blockingDataXml));
                        }
                    }
                }
                global.goSetList_vector.push(gosetlist);
            }
            return;
        }// end function

    }
}
