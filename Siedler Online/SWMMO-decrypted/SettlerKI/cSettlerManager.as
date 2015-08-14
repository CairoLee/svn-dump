package SettlerKI
{
    import Enums.*;
    import GO.*;
    import Interface.*;
    import ServerState.*;
    import Specialists.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import nLib.*;

    public class cSettlerManager extends Object
    {
        private var mMaxAnimals:int;
        private var mTempPos:cPosInt;
        private var mAnimalSpawnPositions_vector:Vector.<int>;
        public var ACTIVATE_SETTLER_DEBUG_INFO:Boolean = false;
        public var mSettlersList_vector:Vector.<cSettler>;
        private var mSpawnAnimalsTime:Number;
        private var mAnimalSpawnIterators:int = 0;
        private var mGeneralInterface:cGeneralInterface;
        public static const UNDISPLAYED_SETTLERPOS:int = 2147483647;

        public function cSettlerManager(param1:cGeneralInterface)
        {
            this.mSettlersList_vector = new Vector.<cSettler>;
            this.mAnimalSpawnPositions_vector = new Vector.<int>;
            this.mTempPos = new cPosInt();
            this.mGeneralInterface = param1;
            return;
        }// end function

        private function SetSettlerAtPixelPosition(param1:cGOGroup, param2:int, param3:String, param4:int, param5:int, param6:int) : cSettler
        {
            var _loc_7:* = cSettler.CreateFromString(param1, param3, param2, this.mGeneralInterface);
            cSettler.CreateFromString(param1, param3, param2, this.mGeneralInterface).SetPosition(param5, param6);
            _loc_7.SetRandomFrame();
            _loc_7.SetKI(param4);
            this.mSettlersList_vector.push(_loc_7);
            var _loc_8:* = _loc_7.mSettlerKi as cSettlerKI;
            (_loc_7.mSettlerKi as cSettlerKI).Init();
            return _loc_7;
        }// end function

        public function BuildingWasPlaced(param1:cBuilding, param2:int) : void
        {
            var _loc_3:cSettler = null;
            var _loc_4:* = this.mSettlersList_vector;
            for each (_loc_3 in _loc_4)
            {
                
                _loc_3.mSettlerKi.BuildingWasPlaced(param1, param2);
            }
            return;
        }// end function

        public function SpawnSettlerOnResourcePath(param1:cPlayerData, param2:cResourceCreation, param3:String) : void
        {
            var _loc_4:String = null;
            var _loc_9:int = 0;
            if (param3 == null)
            {
                _loc_9 = int(gMisc.GetRandomMinMax(0, (global.settlerGroup.mGOList_vector.length - 1)));
                _loc_4 = global.settlerGroup.mGOList_vector[_loc_9].mGfxResourceListName_string;
            }
            else
            {
                _loc_4 = param3;
            }
            var _loc_5:* = param2.GetResourceCreationHouse().GetX();
            var _loc_6:* = param2.GetResourceCreationHouse().GetY();
            if (param2.GetPath() != null)
            {
                _loc_5 = param2.GetPath().dest_vector[0].x;
                _loc_6 = param2.GetPath().dest_vector[0].y;
            }
            else
            {
                _loc_5 = UNDISPLAYED_SETTLERPOS;
                _loc_6 = UNDISPLAYED_SETTLERPOS;
            }
            var _loc_7:* = this.SetSettlerAtPixelPosition(global.settlerGroup, OBJECTTYPE.SETTLER, _loc_4, SETTLER_KI_TYP.WALK_TO_DESTINATION, int(_loc_5), int(_loc_6));
            var _loc_8:* = this.SetSettlerAtPixelPosition(global.settlerGroup, OBJECTTYPE.SETTLER, _loc_4, SETTLER_KI_TYP.WALK_TO_DESTINATION, int(_loc_5), int(_loc_6)).mSettlerKi as cSettlerKIWalkToDestination;
            (this.SetSettlerAtPixelPosition(global.settlerGroup, OBJECTTYPE.SETTLER, _loc_4, SETTLER_KI_TYP.WALK_TO_DESTINATION, int(_loc_5), int(_loc_6)).mSettlerKi as cSettlerKIWalkToDestination).SetResourcePath(param2);
            param2.SetSettler(_loc_7);
            return;
        }// end function

        public function RenderCompute() : void
        {
            var _loc_1:cSettler = null;
            var _loc_2:cSettlerKI = null;
            var _loc_3:cIsoElement = null;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            var _loc_8:int = 0;
            var _loc_9:int = 0;
            var _loc_10:int = 0;
            var _loc_11:int = 0;
            var _loc_12:cSettlerKIWalkToDestination = null;
            if (this.mMaxAnimals > 0)
            {
                _loc_5 = 0;
                while (_loc_5 < 1000)
                {
                    
                    _loc_6 = this.mAnimalSpawnIterators;
                    _loc_7 = _loc_6 & defines.STREET_MAP_WIDTH_FINAL_AND;
                    _loc_8 = _loc_6 >> defines.STREET_MAP_WIDTH_FINAL_SHIFT;
                    if (gCalculations.IsGridXYInsideMap(_loc_7, _loc_8))
                    {
                        _loc_3 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_6];
                        if (!_loc_3.IsBlockedAllowedNothing())
                        {
                            this.mAnimalSpawnPositions_vector.push(_loc_6);
                        }
                    }
                    var _loc_13:String = this;
                    var _loc_14:* = this.mAnimalSpawnIterators + 1;
                    _loc_13.mAnimalSpawnIterators = _loc_14;
                    if (this.mAnimalSpawnIterators >= defines.STREET_MAP_SIZE_FINAL)
                    {
                        _loc_9 = this.mAnimalSpawnPositions_vector.length;
                        if (_loc_9 > 10)
                        {
                            _loc_10 = gMisc.GetRandomMinMaxInt(0, (_loc_9 - 1));
                            _loc_11 = this.mAnimalSpawnPositions_vector[_loc_10];
                            _loc_3 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.mIsoMap_list[_loc_11];
                            if (!_loc_3.IsBlockedAllowedNothing())
                            {
                                gCalculations.ConvertStreetGridToPixelPos(_loc_11, this.mTempPos);
                                this.SpawnAnimal(this.mTempPos.x, this.mTempPos.y);
                                var _loc_13:String = this;
                                var _loc_14:* = this.mMaxAnimals - 1;
                                _loc_13.mMaxAnimals = _loc_14;
                            }
                        }
                        this.mAnimalSpawnIterators = 0;
                        this.mAnimalSpawnPositions_vector = new Vector.<int>;
                        break;
                    }
                    _loc_5++;
                }
            }
            var _loc_4:int = 0;
            while (_loc_4 < this.mSettlersList_vector.length)
            {
                
                _loc_1 = this.mSettlersList_vector[_loc_4];
                _loc_1.Compute();
                if (_loc_1.mSettlerKi.GetKIState() == cSettlerKI.SETTLER_STATE_REMOVE_SETTLER)
                {
                    if (_loc_1.mSettlerKi is cSettlerKIWalkToDestination)
                    {
                        _loc_12 = _loc_1.mSettlerKi as cSettlerKIWalkToDestination;
                        if (_loc_12.mResourceCreation != null)
                        {
                            _loc_12.mResourceCreation.SetSettler(null);
                        }
                    }
                    this.mSettlersList_vector.splice(_loc_4, 1);
                    _loc_4 = _loc_4 - 1;
                }
                _loc_4++;
            }
            return;
        }// end function

        public function Init() : void
        {
            this.Clear();
            return;
        }// end function

        public function Clear() : void
        {
            this.mSettlersList_vector = new Vector.<cSettler>;
            this.mSpawnAnimalsTime = 0;
            this.mMaxAnimals = global.maxAnimalsOnMap;
            this.mAnimalSpawnIterators = 0;
            this.mAnimalSpawnPositions_vector = new Vector.<int>;
            return;
        }// end function

        public function SpawnAnimal(param1:int, param2:int) : void
        {
            var _loc_3:* = gMisc.GetRandomMinMaxInt(0, (global.animalGroup.mGOList_vector.length - 1));
            var _loc_4:int = 0;
            var _loc_5:* = global.animalGroup.mGOList_vector[_loc_3].mGfxResourceListName_string;
            this.SetSettlerAtPixelPosition(global.animalGroup, OBJECTTYPE.ANIMAL, _loc_5, SETTLER_KI_TYP.WALK_FROM_FIELD_TO_FIELD, param1, param2);
            return;
        }// end function

        public function SpawnSettler(param1:cSpecialistTask_WithSettler, param2:int, param3:int, param4:String) : cSettler
        {
            var _loc_5:* = this.SetSettlerAtPixelPosition(global.settlerGroup, OBJECTTYPE.SETTLER, param4, SETTLER_KI_TYP.PERFORM_GENERAL_TASK, param2, param3);
            var _loc_6:* = this.SetSettlerAtPixelPosition(global.settlerGroup, OBJECTTYPE.SETTLER, param4, SETTLER_KI_TYP.PERFORM_GENERAL_TASK, param2, param3).mSettlerKi as cSettlerAI_WalkToTarget;
            (this.SetSettlerAtPixelPosition(global.settlerGroup, OBJECTTYPE.SETTLER, param4, SETTLER_KI_TYP.PERFORM_GENERAL_TASK, param2, param3).mSettlerKi as cSettlerAI_WalkToTarget).SetGeneralTask(param1);
            return _loc_5;
        }// end function

        public function RenderSettlerDebugInfo(param1:Graphics) : void
        {
            return;
        }// end function

    }
}
