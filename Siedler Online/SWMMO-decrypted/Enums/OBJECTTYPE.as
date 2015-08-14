package Enums
{
    import nLib.*;

    final public class OBJECTTYPE extends Object
    {
        public static const STREET:int = 3;
        public static const SETTLER:int = 6;
        public static const LANDSCAPE:int = 2;
        public static const BACKGROUND:int = 1;
        public static const BUILDING:int = 4;
        public static const GUIICON:int = 0;
        public static const ANIMAL:int = 5;
        public static const UNUSED:int = 8;
        public static const DEPOSIT:int = 7;

        public function OBJECTTYPE()
        {
            return;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case GUIICON:
                {
                    return "GuiIcon";
                }
                case BACKGROUND:
                {
                    return "Background";
                }
                case LANDSCAPE:
                {
                    return "Landscape";
                }
                case STREET:
                {
                    return "Street";
                }
                case BUILDING:
                {
                    return "Building";
                }
                case ANIMAL:
                {
                    return "Animal";
                }
                case SETTLER:
                {
                    return "Settler";
                }
                case DEPOSIT:
                {
                    return "Deposit";
                }
                default:
                {
                    return "Unknown: " + param1;
                    continue;
                }
            }
        }// end function

        public static function parse(param1:String) : int
        {
            if (param1 == toString(GUIICON))
            {
                return GUIICON;
            }
            if (param1 == toString(BACKGROUND))
            {
                return BACKGROUND;
            }
            if (param1 == toString(LANDSCAPE))
            {
                return LANDSCAPE;
            }
            if (param1 == toString(STREET))
            {
                return STREET;
            }
            if (param1 == toString(BUILDING))
            {
                return BUILDING;
            }
            if (param1 == toString(ANIMAL))
            {
                return ANIMAL;
            }
            if (param1 == toString(SETTLER))
            {
                return SETTLER;
            }
            if (param1 == toString(DEPOSIT))
            {
                return DEPOSIT;
            }
            gMisc.Assert(false, "Could not interpret string \'" + param1 + "\' for an object type!");
            return GUIICON;
        }// end function

    }
}
