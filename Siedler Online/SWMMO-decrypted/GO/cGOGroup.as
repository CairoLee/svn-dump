package GO
{
    import BuffSystem.*;
    import Enums.*;
    import ServerState.*;
    import __AS3__.vec.*;
    import flash.utils.*;
    import mx.core.*;
    import nLib.*;

    public class cGOGroup extends Object
    {
        private const FLAG_EFFECT_SET_NAME:String = "gosetFlagName";
        public var mCurrentStreams:int = 0;
        public var mGOWorkAnimList_vector:Vector.<cGOSpriteLibContainer> = null;
        private const WORKANIM_FILENAME_ATTRIBUTE_string:String = "workanimfilename";
        public var mConstructionDuration_vector:Vector.<Number> = null;
        public var mDestructionFileName_vector:Vector.<String> = null;
        public var mDestructionDuration_vector:Vector.<Number> = null;
        public var mConstructionFileName_vector:Vector.<String> = null;
        public var mGOWorkAnimListDictionary:Dictionary = null;
        public var mGOList_vector:Vector.<cGOSpriteLibContainer> = null;
        public var defaultZoom:int = 1000;
        public var mStreamedDelay:int = 5;
        public var mLastCurrentStreams:int = -1;
        public var mGameListName_string:String = null;
        public var mGOListDictionary:Dictionary = null;
        public var mStreamIsIdle:Boolean = false;
        public var mGfxListName_string:String = null;
        private const SMOKE_EFFECT_SET_NAME:String = "gosetSmokeEffectSetName";
        private const FILENAME_ATTRIBUTE_string:String = "filename";
        private const CONSTRUCTION_FILENAME_ATTRIBUTE_string:String = "constructionfilename";
        private const DESTRUCTION_FILENAME_ATTRIBUTE_string:String = "destructionfilename";
        public static const STREAM_IDLE_DELAY:int = 5;

        public function cGOGroup()
        {
            return;
        }// end function

        public function GetNameFromNr_string(param1, param2:int) : String
        {
            var _loc_3:* = param1[param2] as cGOSpriteLibContainer;
            return _loc_3.mGfxResourceListName_string;
        }// end function

        public function SetRescaleDirtyFlag() : void
        {
            var _loc_1:cGOSpriteLibContainer = null;
            for each (_loc_1 in this.mGOList_vector)
            {
                
                if (_loc_1 != null)
                {
                    _loc_1.SetDirty();
                }
            }
            for each (_loc_1 in this.mGOWorkAnimList_vector)
            {
                
                if (_loc_1 != null)
                {
                    _loc_1.SetDirty();
                }
            }
            return;
        }// end function

        public function GetSpriteLibFromNr(param1, param2:int) : cSpriteLib
        {
            if (param1 == null)
            {
                return null;
            }
            if (param1.length == 0)
            {
                return null;
            }
            var _loc_3:* = param1[param2] as cSpriteLibContainer;
            if (_loc_3 != null)
            {
                return _loc_3.CreateObject() as cSpriteLib;
            }
            return null;
        }// end function

        public function GetWatchAreaId(param1:String) : int
        {
            var _loc_2:* = this.GetNrFromName(param1);
            var _loc_3:* = this.mGOList_vector[_loc_2] as cGOSpriteLibContainer;
            return _loc_3.mWatchAreaId;
        }// end function

        public function SetGameXML(param1:String) : void
        {
            this.mGameListName_string = param1;
            return;
        }// end function

        public function GetNrFromName(param1:String) : int
        {
            var _loc_2:* = this.mGOListDictionary[param1];
            if (_loc_2 != null)
            {
                return _loc_2.mGfxResourceListNr;
            }
            _loc_2 = this.mGOListDictionary["NotFound"];
            if (_loc_2 != null)
            {
                return _loc_2.mGfxResourceListNr;
            }
            if (param1 == null)
            {
                gLog.logPossibleError(263, "Possible java.lang.NullPointerException in GetNrFromName, unknown element!");
            }
            gMisc.Assert(false, "Not a SpriteLibElement: " + param1);
            return -1;
        }// end function

        public function IsWarehouse(param1:String) : Boolean
        {
            var _loc_2:* = this.GetNrFromName(param1);
            var _loc_3:* = this.mGOList_vector[_loc_2] as cGOSpriteLibContainer;
            return _loc_3.mIsWarehouse;
        }// end function

        public function GetGoSpriteLibContainerFromNr(param1:int) : cGOSpriteLibContainer
        {
            var _loc_2:* = this.mGOList_vector[param1] as cGOSpriteLibContainer;
            return _loc_2;
        }// end function

        public function IsSpriteInGroup(param1:String) : Boolean
        {
            return this.mGOListDictionary[param1] != null;
        }// end function

        private function IsSpriteListLoadedLocal(param1) : Boolean
        {
            var _loc_2:cSpriteLibContainer = null;
            if (param1 == null)
            {
                return true;
            }
            for each (_loc_2 in param1)
            {
                
                if (_loc_2 != null)
                {
                    if (!_loc_2.mLoadingFinished)
                    {
                        return false;
                    }
                }
            }
            return true;
        }// end function

        public function GetBlockingListFromName(param1:String)
        {
            var _loc_2:* = this.GetNrFromName(param1);
            var _loc_3:* = this.mGOList_vector[_loc_2] as cGOSpriteLibContainer;
            return _loc_3.mBlocking_vector;
        }// end function

        public function GetHitPoints(param1:String) : int
        {
            var _loc_2:* = this.GetNrFromName(param1);
            var _loc_3:* = this.mGOList_vector[_loc_2] as cGOSpriteLibContainer;
            return _loc_3.mHitPoints;
        }// end function

        public function GetMaxUnits(param1:String) : int
        {
            var _loc_2:* = this.GetNrFromName(param1);
            var _loc_3:* = this.mGOList_vector[_loc_2] as cGOSpriteLibContainer;
            return _loc_3.mMaxUnits;
        }// end function

        public function CreateContainer(param1:String, param2:Function, param3:Function, param4:Boolean, param5:Boolean) : void
        {
            var _loc_6:String = null;
            var _loc_8:String = null;
            var _loc_9:cGOSpriteLibContainer = null;
            var _loc_17:cXML = null;
            var _loc_18:int = 0;
            var _loc_19:int = 0;
            var _loc_20:String = null;
            var _loc_21:String = null;
            var _loc_22:String = null;
            var _loc_23:cXML = null;
            var _loc_24:cXML = null;
            var _loc_25:Vector.<cXML> = null;
            var _loc_26:cXML = null;
            var _loc_27:cGOSpriteLibContainer = null;
            var _loc_28:cGOSpriteLibContainer = null;
            var _loc_29:cXML = null;
            var _loc_30:int = 0;
            var _loc_31:cXML = null;
            var _loc_32:Vector.<cXML> = null;
            var _loc_33:cXML = null;
            var _loc_34:int = 0;
            var _loc_35:String = null;
            var _loc_36:String = null;
            var _loc_37:cXML = null;
            var _loc_38:Vector.<cXML> = null;
            var _loc_39:cXML = null;
            var _loc_40:String = null;
            var _loc_41:Vector.<cXML> = null;
            var _loc_42:cXML = null;
            var _loc_43:Vector.<dResource> = null;
            var _loc_44:cXML = null;
            var _loc_45:Vector.<cXML> = null;
            var _loc_46:cXML = null;
            var _loc_47:cBuffDefinition = null;
            var _loc_48:cXML = null;
            var _loc_49:dResource = null;
            var _loc_50:cXML = null;
            var _loc_51:String = null;
            var _loc_52:Vector.<cXML> = null;
            var _loc_53:cGOSpriteLibContainer = null;
            var _loc_54:cXML = null;
            var _loc_55:String = null;
            var _loc_56:String = null;
            var _loc_57:String = null;
            var _loc_58:cGOSpriteLibContainer = null;
            var _loc_7:* = gGfxResource.GetGfxFolder_string();
            var _loc_10:* = gGfxResource.GetGfxFolder_string() + param1;
            var _loc_11:Boolean = false;
            var _loc_12:int = -1;
            var _loc_13:String = "building_lib/";
            if (param1 == _loc_13)
            {
                _loc_12 = 0;
                _loc_11 = true;
            }
            this.mGOList_vector = new Vector.<cGOSpriteLibContainer>;
            this.mGOListDictionary = new Dictionary();
            this.mGOWorkAnimList_vector = new Vector.<cGOSpriteLibContainer>;
            this.mGOWorkAnimListDictionary = new Dictionary();
            this.mConstructionFileName_vector = new Vector.<String>;
            this.mDestructionFileName_vector = new Vector.<String>;
            this.mConstructionDuration_vector = new Vector.<Number>;
            this.mDestructionDuration_vector = new Vector.<Number>;
            var _loc_14:* = global.gfxSettingsRootXML.MoveToSubNode("GameObjects");
            var _loc_15:* = global.gfxSettingsRootXML.MoveToSubNode("GameObjects").MoveToSubNode(this.mGfxListName_string);
            var _loc_16:* = global.gfxSettingsRootXML.MoveToSubNode("GameObjects").MoveToSubNode(this.mGfxListName_string).CreateChildrenArray();
            for each (_loc_17 in _loc_16)
            {
                
                _loc_18 = -1;
                if (_loc_12 != -1)
                {
                    if (--_loc_17.GetAttributeInt("id") != _loc_12)
                    {
                        _loc_22 = "gfx_settings.xml -> Error in XML: Section <Building> ID Mismatch at Object: " + _loc_17.GetAttributeString_string("name") + " ID is " + --_loc_17.GetAttributeInt("id") + " but should be " + _loc_12;
                        gErrorMessages.ShowErrorMessage(_loc_22);
                    }
                    _loc_12++;
                }
                if (this.mGfxListName_string == "Buildings")
                {
                    globalFlash.gui.RegisterBuildingType(_loc_17.GetAttributeString_string("name"), _loc_17.GetAttributeString_string("ui"));
                }
                _loc_19 = _loc_17.GetAttributeInt("nofUpgrades");
                _loc_20 = _loc_17.GetAttributeString_string(this.CONSTRUCTION_FILENAME_ATTRIBUTE_string);
                if (_loc_20.length > 0)
                {
                    this.mConstructionFileName_vector.push(_loc_20);
                }
                else
                {
                    this.mConstructionFileName_vector.push(null);
                }
                _loc_21 = _loc_17.GetAttributeString_string(this.DESTRUCTION_FILENAME_ATTRIBUTE_string);
                if (_loc_21.length > 0)
                {
                    this.mDestructionFileName_vector.push(_loc_21);
                }
                else
                {
                    this.mDestructionFileName_vector.push(null);
                }
                this.AutoAddSpriteLibContainerToList(this.mGOList_vector, this.mGOListDictionary, this.FILENAME_ATTRIBUTE_string, _loc_10, _loc_17, this.mGOList_vector, param2, param3, param4, param5, _loc_19, _loc_18);
                this.AutoAddSpriteLibContainerToList(this.mGOWorkAnimList_vector, this.mGOWorkAnimListDictionary, this.WORKANIM_FILENAME_ATTRIBUTE_string, _loc_10, _loc_17, this.mGOWorkAnimList_vector, param2, param3, param4, param5, 0, _loc_18);
            }
            for each (_loc_9 in this.mGOList_vector)
            {
                
                if (_loc_9 != null)
                {
                    _loc_9.ActivateDispatcherEvent();
                }
            }
            for each (_loc_9 in this.mGOWorkAnimList_vector)
            {
                
                if (_loc_9 != null)
                {
                    _loc_9.ActivateDispatcherEvent();
                }
            }
            if (this.mGameListName_string != null)
            {
                _loc_23 = global.gameSettingsRootXML.MoveToSubNode("GameObjects");
                _loc_24 = _loc_23.MoveToSubNode(this.mGameListName_string);
                _loc_25 = _loc_24.CreateChildrenArray();
                for each (_loc_26 in _loc_25)
                {
                    
                    _loc_8 = _loc_26.GetAttributeString_string("name");
                    _loc_28 = this.mGOListDictionary[_loc_8];
                    if (_loc_28 == null)
                    {
                        gErrorMessages.ShowErrorMessage(global.gameSettingsFilename + ": Error! The Object: \'" + _loc_8 + "\' is not in gfx_settings.xml");
                        continue;
                    }
                    _loc_28.mXML = _loc_26;
                }
                for each (_loc_27 in this.mGOList_vector)
                {
                    
                    if (_loc_27 != null)
                    {
                        _loc_29 = _loc_27.mXML;
                        if (_loc_29 != null)
                        {
                            _loc_30 = _loc_29.GetAttributeInt("constructionDuration");
                            if (_loc_30 > 0)
                            {
                                _loc_27.mConstructionDuration = _loc_30;
                            }
                            else
                            {
                                _loc_27.mConstructionDuration = global.buildingDefaultParameterConstructionDuration;
                            }
                            _loc_30 = _loc_29.GetAttributeInt("destructionDuration");
                            if (_loc_30 > 0)
                            {
                                _loc_27.mDestructionDuration = _loc_30;
                            }
                            else
                            {
                                _loc_27.mDestructionDuration = global.buildingDefaultParameterDestructionDuration;
                            }
                            _loc_31 = _loc_29.MoveToSubNode("Blocks");
                            _loc_32 = _loc_31.CreateChildrenArray();
                            for each (_loc_33 in _loc_32)
                            {
                                
                                _loc_27.mBlocking_vector.push(new cBlockingData(_loc_33));
                            }
                            _loc_27.mWatchAreaId = _loc_29.GetAttributeInt("watchAreaId");
                            _loc_27.mIsWarehouse = _loc_29.GetAttributeBool("isWarehouse");
                            _loc_27.mLootTableId = _loc_29.GetAttributeInt("LootTableId");
                            _loc_27.mConstructBuildingWithoutSettler = _loc_29.GetAttributeBool("constructWithoutSettler");
                            _loc_27.mMaxUnits = _loc_29.GetAttributeInt("maxUnits");
                            _loc_27.mHitPoints = _loc_29.GetAttributeInt("hitPoints");
                            _loc_27.mBuildInstantCosts = _loc_29.GetAttributeInt("InstantBuildCosts");
                            _loc_27.mUpgradeInstantBonusPercentage = _loc_29.GetAttributeInt("InstantUpgradeBonusPercentage");
                            if (_loc_29.HasSubNode("BuildingMoveCosts"))
                            {
                                _loc_27.buildingMovementCosts_vector = new Vector.<Vector.<dResource>>;
                                _loc_41 = _loc_29.MoveToSubNode("BuildingMoveCosts").CreateChildrenArray();
                                for each (_loc_42 in _loc_41)
                                {
                                    
                                    _loc_43 = gParse.ParseCosts(_loc_42);
                                    _loc_27.buildingMovementCosts_vector.push(_loc_43);
                                }
                            }
                            if (_loc_29.HasSubNode("BuildingUpgradeBonuses"))
                            {
                                _loc_27.buildingUpgradeBonuses_vector = new Vector.<cBuffDefinition>;
                                _loc_44 = _loc_29.MoveToSubNode("BuildingUpgradeBonuses");
                                _loc_45 = _loc_44.CreateChildrenArray();
                                for each (_loc_46 in _loc_45)
                                {
                                    
                                    _loc_47 = cBuffDefinition.CreateBuffDefinitionFromXml(_loc_46);
                                    if (_loc_47.getUpgradeLevel() != _loc_27.buildingUpgradeBonuses_vector.length)
                                    {
                                        gMisc.Assert(false, "Want to add upgrade bonuses at the wrong position: " + _loc_47.getUpgradeLevel() + " != " + _loc_27.buildingUpgradeBonuses_vector.length + ". Please check the game settings!");
                                    }
                                    _loc_27.buildingUpgradeBonuses_vector.push(_loc_47);
                                }
                            }
                            _loc_27.mDamagePercentForDefendingUnits = _loc_29.GetAttributeInt("damagePercentForDefendingUnits");
                            if (_loc_27.mDamagePercentForDefendingUnits == 0)
                            {
                                _loc_27.mDamagePercentForDefendingUnits = 100;
                            }
                            _loc_27.mShowInGui = 1 - _loc_29.GetAttributeInt("noGui");
                            _loc_27.mIncreaseMaxResourceLimit = _loc_29.GetAttributeInt("incMaxResourceLimit");
                            _loc_34 = _loc_29.GetAttributeInt("maxBuildingLimit");
                            if (_loc_34 == 0)
                            {
                                _loc_34 = global.defaultMaximumBuildingCount;
                            }
                            _loc_27.mMaxBuildingLimit = _loc_34;
                            _loc_35 = _loc_29.GetAttributeString_string("uiType");
                            if (_loc_35 == "CLS")
                            {
                                _loc_27.mUITyp = cGOSpriteLibContainer.UI_TYPE_BASEBUILDING;
                            }
                            else if (_loc_35 == "CL01")
                            {
                                _loc_27.mUITyp = cGOSpriteLibContainer.UI_TYPE_CL01_BUILDING;
                            }
                            else if (_loc_35 == "CL2")
                            {
                                _loc_27.mUITyp = cGOSpriteLibContainer.UI_TYPE_CL2_BUILDING;
                            }
                            else if (_loc_35 == "CL3")
                            {
                                _loc_27.mUITyp = cGOSpriteLibContainer.UI_TYPE_CL3_BUILDING;
                            }
                            else
                            {
                                _loc_27.mUITyp = cGOSpriteLibContainer.UI_TYPE_UNDEFINED;
                            }
                            if (int(_loc_29.GetAttributeInt("playerLevel")) > 0)
                            {
                                _loc_27.mPlayerLevel = int(_loc_29.GetAttributeInt("playerLevel"));
                            }
                            if (int(_loc_29.GetAttributeInt("xp")) > 0)
                            {
                                _loc_27.mXP = int(_loc_29.GetAttributeInt("xp"));
                            }
                            else
                            {
                                _loc_27.mXP = global.buildingDefaultParameterXP;
                            }
                            _loc_36 = _loc_29.GetAttributeString_string("restrictPlacingToDeposit");
                            if (_loc_36 != "")
                            {
                                _loc_27.mRestrictPlacingToDeposit = _loc_36;
                            }
                            if (_loc_29.HasSubNode("AddDeposit"))
                            {
                                _loc_48 = _loc_29.MoveToSubNode("AddDeposit");
                                _loc_27.mAddDepositName = _loc_48.GetAttributeString_string("name");
                                _loc_27.mAddDepositAmount = _loc_48.GetAttributeInt("amount");
                            }
                            else
                            {
                                _loc_27.mAddDepositAmount = -1;
                            }
                            _loc_27.mCostList_vector = new Vector.<dResource>;
                            _loc_37 = _loc_29.MoveToSubNode("Costs");
                            _loc_38 = _loc_37.CreateChildrenArray();
                            for each (_loc_39 in _loc_38)
                            {
                                
                                _loc_49 = new dResource();
                                _loc_49.amount = _loc_39.GetAttributeInt("count");
                                _loc_49.name_string = _loc_39.GetAttributeString_string("name");
                                _loc_27.mCostList_vector.push(_loc_49);
                            }
                            _loc_40 = _loc_29.GetAttributeString_string("subType");
                            if (_loc_40 == "Cursor")
                            {
                                _loc_27.mEnumGoSubType = GO_SUBTYPE.CURSOR;
                            }
                            else if (_loc_40 == "Deco")
                            {
                                _loc_27.mEnumGoSubType = GO_SUBTYPE.DECORATION;
                            }
                            else
                            {
                                _loc_27.mEnumGoSubType = GO_SUBTYPE.DEFAULT;
                            }
                            _loc_27.mXML = null;
                        }
                    }
                }
            }
            if (_loc_11)
            {
                _loc_50 = _loc_14.MoveToSubNode("AnimationsOnMap");
                _loc_51 = _loc_50.GetAttributeString_string("defaultBattleAnimName");
                _loc_52 = _loc_50.CreateChildrenArray();
                for each (_loc_53 in this.mGOList_vector)
                {
                    
                    if (_loc_53 != null)
                    {
                        if (_loc_51.length > 0)
                        {
                            _loc_53.mBattleAnimation_string = _loc_51;
                        }
                    }
                }
                for each (_loc_54 in _loc_52)
                {
                    
                    _loc_55 = _loc_54.GetAttributeString_string("battleAnimName");
                    _loc_56 = _loc_54.GetAttributeString_string("depositAnimName");
                    _loc_57 = _loc_54.GetAttributeString_string("usedBy");
                    for each (_loc_58 in this.mGOList_vector)
                    {
                        
                        if (_loc_58 != null)
                        {
                            if (_loc_57 == _loc_58.mGfxResourceListName_string)
                            {
                                if (_loc_55.length > 0)
                                {
                                    _loc_58.mBattleAnimation_string = _loc_55;
                                }
                                if (_loc_56.length > 0)
                                {
                                    _loc_58.mDepositAnimName_string = _loc_56;
                                }
                                break;
                            }
                        }
                    }
                }
            }
            return;
        }// end function

        public function SetGfxXML(param1:String) : void
        {
            this.mGfxListName_string = param1;
            return;
        }// end function

        public function IsSpriteListLoaded() : Boolean
        {
            return this.IsSpriteListLoadedLocal(this.mGOList_vector) && this.IsSpriteListLoadedLocal(this.mGOWorkAnimList_vector);
        }// end function

        public function GetCostListFromName_vector(param1:String)
        {
            var _loc_2:* = this.GetNrFromName(param1);
            var _loc_3:* = this.mGOList_vector[_loc_2] as cGOSpriteLibContainer;
            return _loc_3.mCostList_vector;
        }// end function

        public function GetSpriteLibFromNameGOList(param1:String) : cSpriteLib
        {
            var _loc_2:* = this.mGOListDictionary[param1];
            if (_loc_2 == null)
            {
                gMisc.Assert(false, "" + param1 + " is no SpriteLibElement");
                return null;
            }
            return _loc_2.CreateObject() as cSpriteLib;
        }// end function

        public function IsNrInGOList(param1:int) : Boolean
        {
            if (this.mGOList_vector == null)
            {
                return false;
            }
            if (param1 < 0 || param1 >= this.mGOList_vector.length)
            {
                return false;
            }
            return true;
        }// end function

        public function GetNameFromNrGOList_string(param1:int) : String
        {
            var _loc_2:* = this.mGOList_vector[param1] as cGOSpriteLibContainer;
            return _loc_2.mGfxResourceListName_string;
        }// end function

        public function IsSpriteInList(param1:String) : Boolean
        {
            var _loc_3:cGOSpriteLibContainer = null;
            if (this.mGOList_vector == null)
            {
                return false;
            }
            var _loc_2:int = 0;
            while (_loc_2 < this.mGOList_vector.length)
            {
                
                _loc_3 = this.mGOList_vector[_loc_2];
                if (param1 == _loc_3.mGfxResourceListName_string)
                {
                    return true;
                }
                _loc_2++;
            }
            return false;
        }// end function

        private function AutoAddSpriteLibContainerToList(param1, param2:Dictionary, param3:String, param4:String, param5:cXML, param6, param7:Function, param8:Function, param9:Boolean, param10:Boolean, param11:int, param12:int) : void
        {
            var _loc_15:Boolean = false;
            var _loc_16:String = null;
            var _loc_17:String = null;
            if (param5 == null)
            {
                return;
            }
            var _loc_13:* = param5.GetAttributeString_string(param3);
            var _loc_14:cGOSpriteLibContainer = null;
            if (_loc_13 != null && _loc_13 != "")
            {
                _loc_15 = param10;
                _loc_16 = param5.GetAttributeString_string("stream");
                if (_loc_16 == "onLoading")
                {
                    _loc_15 = false;
                }
                _loc_14 = new cGOSpriteLibContainer(this, param4 + _loc_13, param7, int(this.defaultZoom), param9, _loc_15, param11);
                _loc_14.mId = param12;
                _loc_14.mExternalData = param5;
                _loc_14.mGfxResourceListName_string = param5.GetAttributeString_string("name");
                _loc_14.mGfxResourceListNr = param6.length;
                _loc_14.mSmokeEffectSetName_string = param5.GetAttributeString_string(this.SMOKE_EFFECT_SET_NAME);
                _loc_14.mFlagEffectSetName_string = param5.GetAttributeString_string(this.FLAG_EFFECT_SET_NAME);
                _loc_14.mEffectDefaultAnimSpeed = param5.GetAttributeFloatingPoint("effectdefaultanimspeed");
                _loc_14.mAnimationSpeed = param5.GetAttributeFloatingPoint("workanimspeed");
                _loc_14.mConstructionAnimSpeed = param5.GetAttributeFloatingPoint("constructionanimspeed");
                _loc_14.mShowMissingResources = !global.buildingDefaultParameterDoNotShowMissingResourceIcon_dictionary.Contains(_loc_14.mGfxResourceListName_string);
                if (_loc_16 == "onGameStart")
                {
                    _loc_14.SetUsageCounter(1);
                }
                _loc_17 = param5.GetAttributeString_string("streamMode");
                _loc_14.mRefreshAfterStream = _loc_17 == "refreshAfterStream";
                if (param8 != null)
                {
                    this.param8(param5, _loc_14);
                }
            }
            param6.push(_loc_14);
            if (_loc_14 != null)
            {
                param2[_loc_14.mGfxResourceListName_string] = _loc_14;
            }
            Application.application.mMemoryMonitor.RegisterGOSpriteLibContainer(_loc_14);
            return;
        }// end function

    }
}
