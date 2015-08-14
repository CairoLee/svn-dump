package Enums
{
    import nLib.*;

    public class ITEM_CONTENT_TYPE extends Object
    {
        public static const NOTHING:int = 6;
        public static const RESOURCE:int = 1;
        public static const ADVENTURE:int = 5;
        public static const SPECIALIST:int = 4;
        public static const BUFF:int = 0;
        public static const BUILDING:int = 3;
        public static const MILITARY_UNIT:int = 2;
        public static const XP:int = 7;

        public function ITEM_CONTENT_TYPE()
        {
            return;
        }// end function

        public static function parse(param1:String) : int
        {
            if (param1 == toString(BUFF))
            {
                return BUFF;
            }
            if (param1 == toString(RESOURCE))
            {
                return RESOURCE;
            }
            if (param1 == toString(MILITARY_UNIT))
            {
                return MILITARY_UNIT;
            }
            if (param1 == toString(BUILDING))
            {
                return BUILDING;
            }
            if (param1 == toString(SPECIALIST))
            {
                return SPECIALIST;
            }
            if (param1 == toString(ADVENTURE))
            {
                return ADVENTURE;
            }
            if (param1 == toString(NOTHING))
            {
                return NOTHING;
            }
            if (param1 == toString(XP))
            {
                return XP;
            }
            gMisc.Assert(false, "Could not interpret item content string \'" + param1 + "\'!");
            return -1;
        }// end function

        public static function toString(param1:int) : String
        {
            switch(param1)
            {
                case BUFF:
                {
                    return "Buff";
                }
                case RESOURCE:
                {
                    return "Resource";
                }
                case MILITARY_UNIT:
                {
                    return "MilitaryUnit";
                }
                case BUILDING:
                {
                    return "Building";
                }
                case SPECIALIST:
                {
                    return "Specialist";
                }
                case ADVENTURE:
                {
                    return "Adventure";
                }
                case NOTHING:
                {
                    return "Nothing";
                }
                case XP:
                {
                    return "XP";
                }
                default:
                {
                    return "Unknown: " + param1;
                    continue;
                }
            }
        }// end function

    }
}
