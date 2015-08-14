package AdventureSystem
{
    import nLib.*;

    public class cAdventureDefinition extends Object
    {
        public var mDifficulty:int = 0;
        public var mMaxPlayers:int;
        public var mQuality:int = 0;
        public var mName_string:String;
        public var mDuration:int;
        public var mSuccessLootTableID:int;
        public var mId:int;
        public var mAllowsPvP:Boolean;
        public var mQuestFileName_string:String;
        public var mPlayerLevel:int;
        public var mColorSchema:String;
        public var mMapFileName_string:String;
        public static var mTeaserImages:Object = {};
        public static var mAvatarImages:Object = {};

        public function cAdventureDefinition()
        {
            return;
        }// end function

        public function GetAvatarImage() : String
        {
            return cAdventureDefinition.mAvatarImages[this.mName_string];
        }// end function

        public function GetTeaserImage() : String
        {
            return cAdventureDefinition.mTeaserImages[this.mName_string];
        }// end function

        public static function CreateFromXML(param1:cXML) : cAdventureDefinition
        {
            var _loc_2:* = new cAdventureDefinition;
            _loc_2.mId = param1.GetAttributeInt("id");
            _loc_2.mName_string = param1.GetAttributeString_string("name");
            _loc_2.mDifficulty = param1.GetAttributeInt("difficulty");
            _loc_2.mQuality = param1.GetAttributeInt("quality");
            _loc_2.mMapFileName_string = param1.GetAttributeString_string("mapFileName");
            _loc_2.mQuestFileName_string = param1.GetAttributeString_string("questFileName");
            _loc_2.mPlayerLevel = param1.GetAttributeInt("playerLevel");
            _loc_2.mMaxPlayers = param1.GetAttributeInt("maxPlayers");
            _loc_2.mDuration = param1.GetAttributeInt("durationHours") * 60 * 60 * 1000;
            _loc_2.mSuccessLootTableID = param1.GetAttributeInt("successLootTable");
            _loc_2.mAllowsPvP = param1.GetAttributeBool("allowsPvP");
            _loc_2.mColorSchema = param1.GetAttributeString_string("colorSchema");
            return _loc_2;
        }// end function

        public static function FindAdventureDefinition(param1:String) : cAdventureDefinition
        {
            var _loc_2:cAdventureDefinition = null;
            for each (_loc_2 in global.adventures_vector)
            {
                
                if (_loc_2.mName_string == param1)
                {
                    return _loc_2;
                }
            }
            return null;
        }// end function

    }
}
