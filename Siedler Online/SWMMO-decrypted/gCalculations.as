package 
{
    import __AS3__.vec.*;
    import flash.geom.*;
    import mx.collections.*;
    import nLib.*;

    public class gCalculations extends Object
    {
        public static var m8DirectionTableStreetGridDirection_vector:Vector.<cVectorListInt> = null;
        public static var m4DirectionBit_list:Vector.<int> = gCalculations.Vector.<int>([1, 2, 4, 8]);
        public static var m8DirectionTableStreetGrid_vector:Vector.<cPosInt> = null;
        public static var m4DirectionOppositeBit_list:Vector.<int> = gCalculations.Vector.<int>([4, 8, 1, 2]);

        public function gCalculations()
        {
            return;
        }// end function

        public static function MoveStreetGridToDir8(param1:int, param2:int) : int
        {
            var _loc_3:* = m8DirectionTableStreetGridDirection_vector[param1 >> defines.STREET_MAP_WIDTH_FINAL_SHIFT & 1];
            return param1 + _loc_3.mList_vector[param2];
        }// end function

        public static function TransFormPoint(param1:Number, param2:Number) : Point
        {
            var _loc_3:* = param1 * (2 * Math.PI);
            var _loc_4:* = new Matrix();
            new Matrix().identity();
            _loc_4.rotate(_loc_3);
            return _loc_4.transformPoint(new Point(0, param2));
        }// end function

        public static function CalculateTileListFromRadius(param1:int)
        {
            var _loc_2:* = new Vector.<cPosInt>;
            _loc_2.push(new cPosInt(0, 0));
            _loc_2.push(new cPosInt(50, 50));
            _loc_2.push(new cPosInt(50, -50));
            _loc_2.push(new cPosInt(-50, 50));
            _loc_2.push(new cPosInt(-50, -50));
            _loc_2.push(new cPosInt(100, 0));
            _loc_2.push(new cPosInt(-100, 0));
            _loc_2.push(new cPosInt(0, 100));
            _loc_2.push(new cPosInt(0, -100));
            _loc_2.push(new cPosInt(100, 100));
            _loc_2.push(new cPosInt(100, -100));
            _loc_2.push(new cPosInt(-100, 100));
            _loc_2.push(new cPosInt(-100, -100));
            _loc_2.push(new cPosInt(150, 50));
            _loc_2.push(new cPosInt(150, -50));
            _loc_2.push(new cPosInt(-150, 50));
            _loc_2.push(new cPosInt(-150, -50));
            _loc_2.push(new cPosInt(50, 150));
            _loc_2.push(new cPosInt(50, -150));
            _loc_2.push(new cPosInt(-50, 150));
            _loc_2.push(new cPosInt(-50, -150));
            _loc_2.push(new cPosInt(0, 200));
            _loc_2.push(new cPosInt(0, -200));
            _loc_2.push(new cPosInt(200, 0));
            _loc_2.push(new cPosInt(-200, 0));
            _loc_2.push(new cPosInt(200, 100));
            _loc_2.push(new cPosInt(200, -100));
            _loc_2.push(new cPosInt(-200, 100));
            _loc_2.push(new cPosInt(-200, -100));
            _loc_2.push(new cPosInt(100, 200));
            _loc_2.push(new cPosInt(100, -200));
            _loc_2.push(new cPosInt(-100, 200));
            _loc_2.push(new cPosInt(-100, -200));
            _loc_2.push(new cPosInt(150, 150));
            _loc_2.push(new cPosInt(150, -150));
            _loc_2.push(new cPosInt(-150, 150));
            _loc_2.push(new cPosInt(-150, -150));
            return _loc_2;
        }// end function

        public static function createIntListString(param1:String, param2:ArrayCollection) : String
        {
            var _loc_4:Boolean = false;
            var _loc_5:Object = null;
            var _loc_3:* = "<" + param1 + " list=\'";
            if (param2 != null)
            {
                _loc_4 = true;
                for each (_loc_5 in param2)
                {
                    
                    if (!_loc_4)
                    {
                        _loc_3 = _loc_3 + ",";
                    }
                    _loc_4 = false;
                    _loc_3 = _loc_3 + _loc_5.toString();
                }
            }
            _loc_3 = _loc_3 + "\' />\n";
            return _loc_3;
        }// end function

        public static function createListString(param1:String, param2:ArrayCollection) : String
        {
            var _loc_4:Object = null;
            var _loc_3:* = "<" + param1 + ">\n";
            if (param2 != null)
            {
                for each (_loc_4 in param2)
                {
                    
                    _loc_3 = _loc_3 + (" " + _loc_4.toString() + "\n");
                }
            }
            _loc_3 = _loc_3 + ("</" + param1 + " >\n");
            return _loc_3;
        }// end function

        public static function ConvertPixelPosToStreetGridPos(param1:int, param2:int) : int
        {
            var _loc_3:Number = NaN;
            var _loc_4:Number = NaN;
            var _loc_5:Number = NaN;
            var _loc_6:Number = NaN;
            var _loc_7:Number = NaN;
            var _loc_8:Number = NaN;
            var _loc_9:* = param1;
            var _loc_10:* = param2;
            _loc_10 = param2 - global.streetGridYHalf;
            _loc_8 = _loc_10 / global.streetGridYFloat;
            _loc_7 = _loc_9 / global.streetGridXFloat;
            _loc_3 = Math.round(_loc_8 - _loc_7);
            _loc_4 = Math.round(_loc_8 + _loc_7);
            _loc_5 = (_loc_4 - _loc_3) / 2 * global.streetGridXFloat;
            _loc_6 = (_loc_4 + _loc_3) / 2 * global.streetGridYFloat;
            _loc_9 = _loc_5;
            _loc_10 = _loc_6 + global.streetGridYHalf;
            var _loc_11:* = int(_loc_9);
            var _loc_12:* = int(_loc_10) / global.streetGridYHalf;
            if ((int(_loc_10) / global.streetGridYHalf & 1) == 0)
            {
                _loc_11 = _loc_11 + global.streetGridX;
            }
            _loc_11 = _loc_11 / global.streetGridX;
            if (!IsGridXYInsideMap(_loc_11, _loc_12))
            {
                return defines.ILLEGAL_INT_POS;
            }
            var _loc_13:* = _loc_11 + (_loc_12 << defines.STREET_MAP_WIDTH_FINAL_SHIFT);
            return _loc_11 + (_loc_12 << defines.STREET_MAP_WIDTH_FINAL_SHIFT);
        }// end function

        public static function AddAngle(param1:Number, param2:Number) : Number
        {
            var _loc_3:* = param1;
            _loc_3 = _loc_3 + param2;
            while (_loc_3 > 1)
            {
                
                _loc_3 = _loc_3 - 1;
            }
            while (_loc_3 < 0)
            {
                
                _loc_3 = _loc_3 + 1;
            }
            return _loc_3;
        }// end function

        public static function ConvertGridFrom128WithToCurrent(param1:int) : int
        {
            var _loc_2:* = param1 & 127;
            var _loc_3:* = param1 >> 7;
            return _loc_2 + (_loc_3 << defines.STREET_MAP_WIDTH_FINAL_SHIFT);
        }// end function

        public static function ConvertStreetGridToPixelPos(param1:int, param2:cPosInt) : void
        {
            var _loc_3:* = param1 & defines.STREET_MAP_WIDTH_FINAL_AND;
            var _loc_4:* = param1 >> defines.STREET_MAP_WIDTH_FINAL_SHIFT;
            var _loc_5:* = _loc_3 * global.streetGridX;
            var _loc_6:* = _loc_4 * global.streetGridYHalf;
            _loc_6 = _loc_4 * global.streetGridYHalf - global.streetGridYHalf;
            if ((_loc_4 & 1) == 0)
            {
                _loc_5 = _loc_5 - global.streetGridXHalf;
            }
            _loc_6 = _loc_6 + global.streetGridYHalf;
            param2.x = _loc_5;
            param2.y = _loc_6;
            return;
        }// end function

        public static function RestrictPixelPosToStreetGrid(param1:cPosInt) : void
        {
            var _loc_2:* = ConvertPixelPosToStreetGridPos(param1.x, param1.y);
            ConvertStreetGridToPixelPos(_loc_2, param1);
            return;
        }// end function

        public static function IsGridXYInsideMap(param1:int, param2:int) : Boolean
        {
            return !(param1 < defines.STREET_MAP_MIN_USABLE_AREA_X || param1 > defines.STREET_MAP_MAX_USABLE_AREA_X || param2 < defines.STREET_MAP_MIN_USABLE_AREA_Y || param2 > defines.STREET_MAP_MAX_USABLE_AREA_Y);
        }// end function

        public static function GetFreeDirectionFromXY(param1:int, param2:int) : Number
        {
            var _loc_3:* = Math.atan2(-param2, param1) + Math.PI;
            var _loc_4:* = _loc_3 * 0.5 / Math.PI;
            _loc_4 = _loc_3 * 0.5 / Math.PI + 1 / 16;
            if (_loc_4 >= 1)
            {
                _loc_4 = _loc_4 - 1;
            }
            return _loc_4;
        }// end function

        public static function CalculateGFXUpgradeLevel(param1:int, param2:int) : int
        {
            param1 = param1 - 1;
            if (param1 < 0)
            {
                param1 = 0;
            }
            if (param1 > param2)
            {
                param1 = param2;
            }
            return param1;
        }// end function

        public static function IsGridInsideMap(param1:int) : Boolean
        {
            var _loc_2:* = param1 & defines.STREET_MAP_WIDTH_FINAL_AND;
            var _loc_3:* = param1 >> defines.STREET_MAP_WIDTH_FINAL_SHIFT;
            return !(_loc_2 < defines.STREET_MAP_MIN_USABLE_AREA_X || _loc_2 > defines.STREET_MAP_MAX_USABLE_AREA_X || _loc_3 < defines.STREET_MAP_MIN_USABLE_AREA_Y || _loc_3 > defines.STREET_MAP_MAX_USABLE_AREA_Y);
        }// end function

        public static function Init() : void
        {
            var _loc_1:cVectorListInt = null;
            m8DirectionTableStreetGrid_vector = new Vector.<cPosInt>;
            m8DirectionTableStreetGrid_vector.push(new cPosInt(global.streetGridXHalf, -global.streetGridYHalf));
            m8DirectionTableStreetGrid_vector.push(new cPosInt(global.streetGridX, 0));
            m8DirectionTableStreetGrid_vector.push(new cPosInt(global.streetGridXHalf, global.streetGridYHalf));
            m8DirectionTableStreetGrid_vector.push(new cPosInt(0, global.streetGridY));
            m8DirectionTableStreetGrid_vector.push(new cPosInt(-global.streetGridXHalf, global.streetGridYHalf));
            m8DirectionTableStreetGrid_vector.push(new cPosInt(-global.streetGridX, 0));
            m8DirectionTableStreetGrid_vector.push(new cPosInt(-global.streetGridXHalf, -global.streetGridYHalf));
            m8DirectionTableStreetGrid_vector.push(new cPosInt(0, -global.streetGridY));
            m8DirectionTableStreetGridDirection_vector = new Vector.<cVectorListInt>;
            _loc_1 = new cVectorListInt();
            _loc_1.mList_vector.push(-defines.STREET_MAP_WIDTH_FINAL);
            _loc_1.mList_vector.push(defines.STREET_MAP_WIDTH_FINAL);
            _loc_1.mList_vector.push((defines.STREET_MAP_WIDTH_FINAL - 1));
            _loc_1.mList_vector.push(-defines.STREET_MAP_WIDTH_FINAL - 1);
            _loc_1.mList_vector.push(-(defines.STREET_MAP_WIDTH_FINAL << 1));
            _loc_1.mList_vector.push(1);
            _loc_1.mList_vector.push(defines.STREET_MAP_WIDTH_FINAL << 1);
            _loc_1.mList_vector.push(-1);
            m8DirectionTableStreetGridDirection_vector.push(_loc_1);
            _loc_1 = new cVectorListInt();
            _loc_1.mList_vector.push(-defines.STREET_MAP_WIDTH_FINAL + 1);
            _loc_1.mList_vector.push((defines.STREET_MAP_WIDTH_FINAL + 1));
            _loc_1.mList_vector.push(defines.STREET_MAP_WIDTH_FINAL);
            _loc_1.mList_vector.push(-defines.STREET_MAP_WIDTH_FINAL);
            _loc_1.mList_vector.push(-(defines.STREET_MAP_WIDTH_FINAL << 1));
            _loc_1.mList_vector.push(1);
            _loc_1.mList_vector.push(defines.STREET_MAP_WIDTH_FINAL << 1);
            _loc_1.mList_vector.push(-1);
            m8DirectionTableStreetGridDirection_vector.push(_loc_1);
            return;
        }// end function

    }
}
