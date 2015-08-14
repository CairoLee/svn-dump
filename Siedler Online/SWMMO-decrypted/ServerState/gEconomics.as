package ServerState
{
    import Enums.*;
    import __AS3__.vec.*;
    import nLib.*;

    public class gEconomics extends Object
    {
        public static var mResourceCreationDefinition_vector:Vector.<dResourceCreationDefinition> = null;
        public static var mResourceDefaultDefinition_vector:Vector.<dResourceDefaultDefinition> = null;

        public function gEconomics()
        {
            return;
        }// end function

        public static function Init() : void
        {
            var _loc_8:cXML = null;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:dResourceDefaultDefinition = null;
            var _loc_12:String = null;
            var _loc_13:String = null;
            var _loc_14:int = 0;
            var _loc_15:int = 0;
            var _loc_16:String = null;
            var _loc_17:Vector.<cXML> = null;
            var _loc_18:cXML = null;
            var _loc_19:int = 0;
            var _loc_20:cXML = null;
            var _loc_21:Boolean = false;
            var _loc_22:dResourceDefaultDefinition = null;
            var _loc_23:cXML = null;
            var _loc_24:dExpandMaxLimit = null;
            var _loc_25:String = null;
            var _loc_26:dResourceCreationDefinition = null;
            var _loc_27:String = null;
            var _loc_28:String = null;
            var _loc_1:* = new Vector.<dResourceCreationDefinition>;
            var _loc_2:int = 0;
            while (_loc_2 < 100)
            {
                
                _loc_1.push(null);
                _loc_2++;
            }
            mResourceDefaultDefinition_vector = new Vector.<dResourceDefaultDefinition>;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:* = global.gameSettingsRootXML;
            var _loc_6:* = global.gameSettingsRootXML.MoveToSubNode("ResourceDefinitions");
            global.returnRate = int(_loc_6.GetAttributeFloatingPoint("returnRate") * 100);
            var _loc_7:* = _loc_6.CreateChildrenArray();
            for each (_loc_8 in _loc_7)
            {
                
                _loc_11 = new dResourceDefaultDefinition();
                _loc_13 = _loc_8.GetAttributeString_string("name");
                _loc_14 = _loc_8.GetAttributeInt("id");
                gMisc.Assert(global.resourceDefinitions_vector.length == _loc_14, "Resource definition \'" + _loc_13 + "\' has wrong id! It should be " + global.resourceDefinitions_vector.length + "!");
                global.resourceDefinitions_vector.push(_loc_13);
                _loc_11.resourceName_string = _loc_13;
                if (global.gfxSettingsRootXML.mInternXmlList != null)
                {
                    for each (_loc_23 in global.gfxSettingsRootXML.MoveToSubNode("GameObjects").MoveToSubNode("ResourceIcons").CreateChildrenArray())
                    {
                        
                        if (_loc_23.GetAttributeString_string("name") == _loc_13)
                        {
                            _loc_11.group_string = _loc_23.GetAttributeString_string("group");
                            break;
                        }
                    }
                }
                _loc_15 = _loc_8.GetAttributeInt("MaxLimit");
                if (_loc_15 == 0)
                {
                    _loc_15 = gMisc.GetMaxIntValue();
                }
                _loc_11.maxLimit = _loc_15;
                _loc_16 = _loc_8.GetAttributeString_string("noGui");
                if (_loc_16 != "1")
                {
                    global.visibleResources_vector.push(_loc_8.GetAttributeString_string("name"));
                }
                _loc_11.expandMaxLimitList_vector = new Vector.<dExpandMaxLimit>;
                _loc_17 = _loc_8.CreateChildrenArray();
                for each (_loc_18 in _loc_17)
                {
                    
                    _loc_12 = _loc_18.GetName_string();
                    if (_loc_12 == "ExpandMaxLimit")
                    {
                        _loc_24 = new dExpandMaxLimit();
                        _loc_24.name_string = _loc_18.GetAttributeString_string("ByBuilding");
                        _loc_24.amount = _loc_18.GetAttributeFloatingPoint("Amount");
                        _loc_11.expandMaxLimitList_vector.push(_loc_24);
                    }
                }
                _loc_19 = -1;
                for each (_loc_20 in _loc_17)
                {
                    
                    _loc_12 = _loc_20.GetName_string();
                    if (_loc_12 == "Creation")
                    {
                        _loc_25 = _loc_20.GetAttributeString_string("CreationId");
                        if (_loc_25 == "")
                        {
                            gMisc.Assert(false, "Error: ID is missing in ResourceDefinition \'" + _loc_13 + "\'");
                        }
                        _loc_19 = gMisc.ParseInt(_loc_25);
                        if (_loc_19 > _loc_3)
                        {
                            _loc_3 = _loc_19;
                        }
                        gMisc.Assert(_loc_19 < _loc_1.length, "Error: To many Resourcecreation, maximum is 100");
                        _loc_26 = new dResourceCreationDefinition();
                        gMisc.Assert(_loc_1[_loc_19] == null, "Error: Double Id " + _loc_19);
                        _loc_1[_loc_19] = _loc_26;
                        _loc_26.id = _loc_19;
                        _loc_26.defaultSetting = _loc_11;
                        _loc_27 = _loc_20.GetAttributeString_string("type");
                        if (_loc_27 == "CreatedAlways")
                        {
                            _loc_26.typeEnumResourceType = RESOURCE_TYPE.CREATED_ALWAYS;
                            _loc_26.buildingName_string = null;
                            _loc_26.amountRemoved = _loc_20.GetAttributeInt("CreationTime");
                            if (_loc_26.amountRemoved == 0)
                            {
                                _loc_26.amountRemoved = 1;
                            }
                        }
                        else if (_loc_27 == "CreatedByBuilding")
                        {
                            _loc_26.typeEnumResourceType = RESOURCE_TYPE.CREATED_BY_BUILDING;
                            _loc_26.buildingName_string = _loc_20.GetAttributeString_string("Building");
                            _loc_26.externalResource_string = _loc_20.GetAttributeString_string("ExternalResource");
                            _loc_26.amountRemoved = _loc_20.GetAttributeInt("AmountRemoved");
                            if (_loc_26.amountRemoved == 0)
                            {
                                _loc_26.amountRemoved = 1;
                            }
                            _loc_26.workTime = _loc_20.GetAttributeInt("WorkTime");
                            _loc_28 = _loc_20.GetAttributeString_string("Resource");
                            if (_loc_28 != "")
                            {
                                GetResourcesFromString(_loc_28, _loc_26.necessaryResources_vector);
                            }
                        }
                        if (_loc_20.GetAttributeString_string("ignoreMaxWarehouseLimit") == "true")
                        {
                            _loc_26.ignoreMaxWarehouseLimit = true;
                            continue;
                        }
                        _loc_26.ignoreMaxWarehouseLimit = false;
                    }
                }
                _loc_21 = false;
                for each (_loc_22 in mResourceDefaultDefinition_vector)
                {
                    
                    if (_loc_22.resourceName_string == _loc_11.resourceName_string)
                    {
                        _loc_21 = true;
                        break;
                    }
                }
                if (_loc_21)
                {
                    gErrorMessages.ShowErrorMessage("Error: Double entry in XML ResourceDefinition -> Resourcename " + _loc_11.resourceName_string);
                    continue;
                }
                mResourceDefaultDefinition_vector.push(_loc_11);
            }
            _loc_9 = _loc_3 + 1;
            mResourceCreationDefinition_vector = new Vector.<dResourceCreationDefinition>;
            _loc_10 = 0;
            while (_loc_10 < _loc_9)
            {
                
                mResourceCreationDefinition_vector.push(_loc_1[_loc_10]);
                _loc_10++;
            }
            return;
        }// end function

        public static function GetResourcesCreationDefinitionForBuilding(param1:String) : dResourceCreationDefinition
        {
            var _loc_2:dResourceCreationDefinition = null;
            for each (_loc_2 in mResourceCreationDefinition_vector)
            {
                
                if (_loc_2.typeEnumResourceType == RESOURCE_TYPE.CREATED_BY_BUILDING)
                {
                    if (_loc_2.buildingName_string != null && _loc_2.buildingName_string == param1)
                    {
                        return _loc_2;
                    }
                }
            }
            return null;
        }// end function

        public static function GetResourcesDefaultDefinition(param1:String) : dResourceDefaultDefinition
        {
            var _loc_2:dResourceDefaultDefinition = null;
            for each (_loc_2 in mResourceDefaultDefinition_vector)
            {
                
                if (_loc_2.resourceName_string == param1)
                {
                    return _loc_2;
                }
            }
            return null;
        }// end function

        public static function GetResourcesFromString(param1:String, param2) : void
        {
            var _loc_4:String = null;
            var _loc_5:dResource = null;
            var _loc_6:Array = null;
            var _loc_3:* = param1.split(",");
            for each (_loc_4 in _loc_3)
            {
                
                _loc_4 = gMisc.Trim_string(_loc_4, " ");
                _loc_5 = new dResource();
                _loc_6 = _loc_4.split(" ");
                _loc_5.name_string = _loc_6[0] as String;
                _loc_5.amount = gMisc.ParseInt(_loc_6[1] as String);
                param2.push(_loc_5);
            }
            return;
        }// end function

        public static function Exit() : void
        {
            return;
        }// end function

    }
}
