package GUI.Assets
{
    import AdventureSystem.*;
    import Communication.VO.*;
    import Enums.*;
    import NewQuestSystem.*;
    import VO.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import flash.events.*;
    import flash.filters.*;
    import flash.geom.*;
    import flash.net.*;
    import flash.system.*;
    import flash.utils.*;
    import mx.core.*;
    import nLib.*;

    public class gAssetManager extends Object
    {
        private static const AvatarBackground12:Class = gAssetManager_AvatarBackground12;
        private static const AvatarBackgroundSmall11:Class = gAssetManager_AvatarBackgroundSmall11;
        private static const IconEasterGeneral:Class = gAssetManager_IconEasterGeneral;
        private static const DetailsIconOverallTime:Class = gAssetManager_DetailsIconOverallTime;
        private static const AvatarBackground13:Class = gAssetManager_AvatarBackground13;
        private static const IconMasterGeneral:Class = gAssetManager_IconMasterGeneral;
        private static const TooltipBackgroundGreen:Class = gAssetManager_TooltipBackgroundGreen;
        private static const ArrowLeftScrollDisabled:Class = gAssetManager_ArrowLeftScrollDisabled;
        private static const AvatarBackgroundSmall07:Class = gAssetManager_AvatarBackgroundSmall07;
        private static const BuildQueueTempSlotTimeLeftIcon:Class = gAssetManager_BuildQueueTempSlotTimeLeftIcon;
        private static const GROUP_RESOURCES:int = 1;
        private static const ArrowRightEnd:Class = gAssetManager_ArrowRightEnd;
        private static const ArrowDown:Class = gAssetManager_ArrowDown;
        private static const ButtonIconFindAdventure:Class = gAssetManager_ButtonIconFindAdventure;
        private static const ButtonIconBomb:Class = gAssetManager_ButtonIconBomb;
        private static var inactiveShader:Shader;
        private static var completeFunction:Function;
        private static const ArrowRightScrollHighlight:Class = gAssetManager_ArrowRightScrollHighlight;
        private static const ChatTabHighlight:Class = gAssetManager_ChatTabHighlight;
        private static const ButtonIconStone:Class = gAssetManager_ButtonIconStone;
        private static const ActionBarIcon03Highlight:Class = gAssetManager_ActionBarIcon03Highlight;
        private static const ActionBarIcon03Deactivated:Class = gAssetManager_ActionBarIcon03Deactivated;
        private static var buildings:Dictionary = new Dictionary();
        private static const ArrowSmallNUp:Class = gAssetManager_ArrowSmallNUp;
        private static const PayshopIndicator:Class = gAssetManager_PayshopIndicator;
        private static const ButtonIconStart:Class = gAssetManager_ButtonIconStart;
        private static const ChatTabNormal:Class = gAssetManager_ChatTabNormal;
        private static const ActionBarIcon06Deactivated:Class = gAssetManager_ActionBarIcon06Deactivated;
        private static const HalfTimeDisabled:Class = gAssetManager_HalfTimeDisabled;
        private static const ButtonAddCashDisabled:Class = gAssetManager_ButtonAddCashDisabled;
        private static const DetailsIconDeposit:Class = gAssetManager_DetailsIconDeposit;
        private static const ArrowUp:Class = gAssetManager_ArrowUp;
        private static const ButtonIconBronze:Class = gAssetManager_ButtonIconBronze;
        private static const ArrowRightScroll:Class = gAssetManager_ArrowRightScroll;
        private static const QueuePaidBackground:Class = gAssetManager_QueuePaidBackground;
        private static const AvatarAdd:Class = gAssetManager_AvatarAdd;
        public static var buffCursorTypes:Dictionary = new Dictionary();
        private static const ActionBarIcon09Deactivated:Class = gAssetManager_ActionBarIcon09Deactivated;
        private static const ActionBarIcon01:Class = gAssetManager_ActionBarIcon01;
        private static const BuyTempSlot:Class = gAssetManager_BuyTempSlot;
        private static const ActionBarIcon03:Class = gAssetManager_ActionBarIcon03;
        private static const ActionBarIcon04:Class = gAssetManager_ActionBarIcon04;
        private static const ActionBarIcon05:Class = gAssetManager_ActionBarIcon05;
        private static const ActionBarIcon06:Class = gAssetManager_ActionBarIcon06;
        private static const ActionBarIcon07:Class = gAssetManager_ActionBarIcon07;
        private static const ActionBarIcon09:Class = gAssetManager_ActionBarIcon09;
        private static const IconMailTypeHardCurrency:Class = gAssetManager_IconMailTypeHardCurrency;
        private static const ActionBarIcon02:Class = gAssetManager_ActionBarIcon02;
        private static const BattlePlayerColor01:Class = gAssetManager_BattlePlayerColor01;
        private static const BattlePlayerColor02:Class = gAssetManager_BattlePlayerColor02;
        private static const BattlePlayerColor03:Class = gAssetManager_BattlePlayerColor03;
        private static const BattlePlayerColor04:Class = gAssetManager_BattlePlayerColor04;
        private static const IconMailTypeFriend:Class = gAssetManager_IconMailTypeFriend;
        private static const BattlePlayerColor06:Class = gAssetManager_BattlePlayerColor06;
        private static const BattlePlayerColor07:Class = gAssetManager_BattlePlayerColor07;
        private static const BattlePlayerColor08:Class = gAssetManager_BattlePlayerColor08;
        private static const BattlePlayerColor09:Class = gAssetManager_BattlePlayerColor09;
        private static const BattlePlayerColor05:Class = gAssetManager_BattlePlayerColor05;
        private static const ButtonIconInstant:Class = gAssetManager_ButtonIconInstant;
        private static const ButtonIconCrown:Class = gAssetManager_ButtonIconCrown;
        private static const QuestAdvisor:Class = gAssetManager_QuestAdvisor;
        private static const SmallIconHardCurrency:Class = gAssetManager_SmallIconHardCurrency;
        private static const ActionBarIcon08:Class = gAssetManager_ActionBarIcon08;
        private static const CloseDisabled:Class = gAssetManager_CloseDisabled;
        private static const ButtonIconHardCurrency:Class = gAssetManager_ButtonIconHardCurrency;
        private static const BattlePlayerColor10:Class = gAssetManager_BattlePlayerColor10;
        private static const BattlePlayerColor11:Class = gAssetManager_BattlePlayerColor11;
        private static const BattlePlayerColor12:Class = gAssetManager_BattlePlayerColor12;
        private static const BattlePlayerColor13:Class = gAssetManager_BattlePlayerColor13;
        private static const BattlePlayerColor14:Class = gAssetManager_BattlePlayerColor14;
        private static const ArrowUpHighlight:Class = gAssetManager_ArrowUpHighlight;
        private static const ButtonIconUpgrade:Class = gAssetManager_ButtonIconUpgrade;
        private static const IconMailTypeAdventureLoot:Class = gAssetManager_IconMailTypeAdventureLoot;
        private static const ActionBarIcon07Highlight:Class = gAssetManager_ActionBarIcon07Highlight;
        private static const IconRetailBoxGeneral:Class = gAssetManager_IconRetailBoxGeneral;
        private static var IconInactiveFilter:Class = gAssetManager_IconInactiveFilter;
        private static const IconGeologist:Class = gAssetManager_IconGeologist;
        private static const InputMissingForeground:Class = gAssetManager_InputMissingForeground;
        private static const BattleSlotBackground:Class = gAssetManager_BattleSlotBackground;
        private static const IconMailTypeGuild:Class = gAssetManager_IconMailTypeGuild;
        private static const QuestItemBackgroundNormal:Class = gAssetManager_QuestItemBackgroundNormal;
        private static const InputMissingBackground:Class = gAssetManager_InputMissingBackground;
        private static const ArrowDownHighlight:Class = gAssetManager_ArrowDownHighlight;
        private static const IconEasterExplorer:Class = gAssetManager_IconEasterExplorer;
        private static const IconCannotBuild:Class = gAssetManager_IconCannotBuild;
        private static const DetailsIconWorkyard:Class = gAssetManager_DetailsIconWorkyard;
        private static const ButtonIconSwords:Class = gAssetManager_ButtonIconSwords;
        private static const DailyLoginQuestionMark:Class = gAssetManager_DailyLoginQuestionMark;
        private static const ScrollbarArrowDown:Class = gAssetManager_ScrollbarArrowDown;
        private static const TrackedAdventureBackground:Class = gAssetManager_TrackedAdventureBackground;
        private static const ChatTab:Class = gAssetManager_ChatTab;
        private static const QueueBackground:Class = gAssetManager_QueueBackground;
        private static const ButtonIconFlag:Class = gAssetManager_ButtonIconFlag;
        private static const ButtonIconSalpeter:Class = gAssetManager_ButtonIconSalpeter;
        private static const ChatTabMinimized:Class = gAssetManager_ChatTabMinimized;
        private static var military:Dictionary = new Dictionary();
        private static const ButtonIconTaskEvenLonger:Class = gAssetManager_ButtonIconTaskEvenLonger;
        private static const AddFriendBackground:Class = gAssetManager_AddFriendBackground;
        private static const FriendIndicatorEnemy:Class = gAssetManager_FriendIndicatorEnemy;
        private static const ShopItemBackgroundHighlight:Class = gAssetManager_ShopItemBackgroundHighlight;
        private static const QueueEmptyBackground:Class = gAssetManager_QueueEmptyBackground;
        private static const FriendVisit:Class = gAssetManager_FriendVisit;
        private static const FriendIndicatorAdventure:Class = gAssetManager_FriendIndicatorAdventure;
        private static const ButtonIconTrade:Class = gAssetManager_ButtonIconTrade;
        private static const DailyLoginFailed:Class = gAssetManager_DailyLoginFailed;
        private static const ScrollbarArrowDownHighlight:Class = gAssetManager_ScrollbarArrowDownHighlight;
        private static const ButtonIconMagnifier:Class = gAssetManager_ButtonIconMagnifier;
        private static const ShopItemBackground:Class = gAssetManager_ShopItemBackground;
        private static const TooltipBackgroundRed:Class = gAssetManager_TooltipBackgroundRed;
        private static const ActionBarIcon04Highlight:Class = gAssetManager_ActionBarIcon04Highlight;
        private static const AvatarMessageRed:Class = gAssetManager_AvatarMessageRed;
        private static const IconPadlock:Class = gAssetManager_IconPadlock;
        private static const TooltipBackgroundBlue:Class = gAssetManager_TooltipBackgroundBlue;
        private static const ArrowRightEndHighlight:Class = gAssetManager_ArrowRightEndHighlight;
        private static const BattleSlotHighlightAttacker:Class = gAssetManager_BattleSlotHighlightAttacker;
        private static const QuestItemBackgroundOver:Class = gAssetManager_QuestItemBackgroundOver;
        private static const ActionBarIcon01Deactivated:Class = gAssetManager_ActionBarIcon01Deactivated;
        private static const DailyLoginPassed:Class = gAssetManager_DailyLoginPassed;
        private static const FriendIndicatorGuild:Class = gAssetManager_FriendIndicatorGuild;
        private static const ArrowLeftGreen:Class = gAssetManager_ArrowLeftGreen;
        private static const ButtonIconStop:Class = gAssetManager_ButtonIconStop;
        private static const StarmenuFrameEmpty:Class = gAssetManager_StarmenuFrameEmpty;
        private static const AvatarSmall00:Class = gAssetManager_AvatarSmall00;
        private static const ActionBarIcon04Deactivated:Class = gAssetManager_ActionBarIcon04Deactivated;
        private static const AdventureAvatarDefault:Class = gAssetManager_AdventureAvatarDefault;
        private static const IconMailTypeGift:Class = gAssetManager_IconMailTypeGift;
        private static const DetailsIconInternal:Class = gAssetManager_DetailsIconInternal;
        private static var tempDict:Dictionary = new Dictionary();
        private static const FriendFilterBackground:Class = gAssetManager_FriendFilterBackground;
        private static const ButtonIconTaskLong:Class = gAssetManager_ButtonIconTaskLong;
        private static var binFiles:Dictionary = new Dictionary();
        private static const QuestAdvisorMedium:Class = gAssetManager_QuestAdvisorMedium;
        private static const IconBuildStreet:Class = gAssetManager_IconBuildStreet;
        private static const IconMasterExplorer:Class = gAssetManager_IconMasterExplorer;
        private static const CloseHighlight:Class = gAssetManager_CloseHighlight;
        private static const ButtonIconPay:Class = gAssetManager_ButtonIconPay;
        private static const QuestItemBackgroundSelected:Class = gAssetManager_QuestItemBackgroundSelected;
        private static const ButtonIconTools:Class = gAssetManager_ButtonIconTools;
        private static const HalfTime:Class = gAssetManager_HalfTime;
        private static const DetailsIconProductionTime:Class = gAssetManager_DetailsIconProductionTime;
        private static const ActionBarIcon07Deactivated:Class = gAssetManager_ActionBarIcon07Deactivated;
        private static const OnlineStatusGreen:Class = gAssetManager_OnlineStatusGreen;
        private static const ButtonIconCrownGems:Class = gAssetManager_ButtonIconCrownGems;
        private static const ArrowLeftEndHighlight:Class = gAssetManager_ArrowLeftEndHighlight;
        private static const ButtonIconGranite:Class = gAssetManager_ButtonIconGranite;
        private static const Close:Class = gAssetManager_Close;
        private static const ActionBarIcon08Highlight:Class = gAssetManager_ActionBarIcon08Highlight;
        private static const AvatarAdventureZone:Class = gAssetManager_AvatarAdventureZone;
        private static const ButtonIconGold:Class = gAssetManager_ButtonIconGold;
        private static const ArrowSmallWOver:Class = gAssetManager_ArrowSmallWOver;
        private static var countLoaded:int = 0;
        private static const ArrowSmallWUp:Class = gAssetManager_ArrowSmallWUp;
        private static const ActionBarIcon01Highlight:Class = gAssetManager_ActionBarIcon01Highlight;
        private static const ButtonIconFindWildZone:Class = gAssetManager_ButtonIconFindWildZone;
        private static const FrameDailyLogin:Class = gAssetManager_FrameDailyLogin;
        private static const ButtonIconMarble:Class = gAssetManager_ButtonIconMarble;
        private static const IconGeneral:Class = gAssetManager_IconGeneral;
        private static const ButtonIconNewMail:Class = gAssetManager_ButtonIconNewMail;
        private static const ButtonAddCashUp:Class = gAssetManager_ButtonAddCashUp;
        private static const AvatarBanditSmall01:Class = gAssetManager_AvatarBanditSmall01;
        private static const IconTmpArmyTransporter:Class = gAssetManager_IconTmpArmyTransporter;
        private static const IconMailTypeBuffed:Class = gAssetManager_IconMailTypeBuffed;
        private static const ArrowSmallRight:Class = gAssetManager_ArrowSmallRight;
        private static const IconMailTypeMail:Class = gAssetManager_IconMailTypeMail;
        private static const AdventureQuality1:Class = gAssetManager_AdventureQuality1;
        private static const AdventureQuality2:Class = gAssetManager_AdventureQuality2;
        private static var resources:Dictionary = new Dictionary();
        private static const AddFriendBackgroundHighlight:Class = gAssetManager_AddFriendBackgroundHighlight;
        private static const AdventureQuality3:Class = gAssetManager_AdventureQuality3;
        private static const AdventureQuality4:Class = gAssetManager_AdventureQuality4;
        private static const OnlineStatusRed:Class = gAssetManager_OnlineStatusRed;
        private static const FrameDailyLoginLast:Class = gAssetManager_FrameDailyLoginLast;
        private static const ButtonIconFindTreasure:Class = gAssetManager_ButtonIconFindTreasure;
        private static const IconMailTypeTrade:Class = gAssetManager_IconMailTypeTrade;
        private static const ArrowLeftDisabled:Class = gAssetManager_ArrowLeftDisabled;
        private static const GROUP_BUILDINGS:int = 0;
        private static const QueueStdBackground:Class = gAssetManager_QueueStdBackground;
        public static var buffCursorTypesForeign:Dictionary = new Dictionary();
        private static const ArrowRightHighlight:Class = gAssetManager_ArrowRightHighlight;
        private static const OutputBuffedBackground:Class = gAssetManager_OutputBuffedBackground;
        private static const ButtonIconIron:Class = gAssetManager_ButtonIconIron;
        private static const BuildQueueExtensionBar:Class = gAssetManager_BuildQueueExtensionBar;
        private static const IconSkull:Class = gAssetManager_IconSkull;
        private static const OutputBuffedForeground:Class = gAssetManager_OutputBuffedForeground;
        private static const FrameSpecialist:Class = gAssetManager_FrameSpecialist;
        private static const BattleSlotHighlightDefender:Class = gAssetManager_BattleSlotHighlightDefender;
        private static const ArrowSmallEUp:Class = gAssetManager_ArrowSmallEUp;
        private static const IconSpy:Class = gAssetManager_IconSpy;
        private static const ArrowSmallNOver:Class = gAssetManager_ArrowSmallNOver;
        private static const ButtonIconTrumpet:Class = gAssetManager_ButtonIconTrumpet;
        private static var shopItems:Dictionary = new Dictionary();
        private static const IconMailTypeBattleReport:Class = gAssetManager_IconMailTypeBattleReport;
        private static const ActionBarIcon05Highlight:Class = gAssetManager_ActionBarIcon05Highlight;
        private static const ArrowLeftScroll:Class = gAssetManager_ArrowLeftScroll;
        private static var buffs:Dictionary = new Dictionary();
        private static const FrameBuffInstant:Class = gAssetManager_FrameBuffInstant;
        private static const AvatarMessageRedHighlight:Class = gAssetManager_AvatarMessageRedHighlight;
        private static const FriendBackground:Class = gAssetManager_FriendBackground;
        private static const IconHalloweenGeneral:Class = gAssetManager_IconHalloweenGeneral;
        private static const ButtonIconTaskMedium:Class = gAssetManager_ButtonIconTaskMedium;
        private static const ButtonIconDiplomacy:Class = gAssetManager_ButtonIconDiplomacy;
        private static const ProductionArrow:Class = gAssetManager_ProductionArrow;
        private static const ArrowLeftScrollHighlight:Class = gAssetManager_ArrowLeftScrollHighlight;
        private static const ChatTabSelected:Class = gAssetManager_ChatTabSelected;
        private static const ButtonIconGift:Class = gAssetManager_ButtonIconGift;
        private static const FrameBuffUpgrade:Class = gAssetManager_FrameBuffUpgrade;
        private static const ButtonIconExploreSector:Class = gAssetManager_ButtonIconExploreSector;
        private static const FrameArrow:Class = gAssetManager_FrameArrow;
        private static const ArrowRightEndDisabled:Class = gAssetManager_ArrowRightEndDisabled;
        private static const ArrowLeftEndDisabled:Class = gAssetManager_ArrowLeftEndDisabled;
        private static const HalfTimeHighlight:Class = gAssetManager_HalfTimeHighlight;
        private static const ActionBarIcon02Deactivated:Class = gAssetManager_ActionBarIcon02Deactivated;
        private static const IconMailReply:Class = gAssetManager_IconMailReply;
        private static const ArrowSmallEOver:Class = gAssetManager_ArrowSmallEOver;
        private static var requestDict:Dictionary = new Dictionary();
        private static const InfoOrnamentalTop1:Class = gAssetManager_InfoOrnamentalTop1;
        private static const IconQuestHighlight:Class = gAssetManager_IconQuestHighlight;
        private static const ArrowSmallSUp:Class = gAssetManager_ArrowSmallSUp;
        private static const ActionBarIcon05Deactivated:Class = gAssetManager_ActionBarIcon05Deactivated;
        private static const ActionBarIcon09Highlight:Class = gAssetManager_ActionBarIcon09Highlight;
        private static const ArrowRightScrollDisabled:Class = gAssetManager_ArrowRightScrollDisabled;
        private static const ArrowLeftHighlight:Class = gAssetManager_ArrowLeftHighlight;
        private static const BackgroundHighlight:Class = gAssetManager_BackgroundHighlight;
        private static const ArrowUpDisabled:Class = gAssetManager_ArrowUpDisabled;
        private static const QuestAdvisorSmall:Class = gAssetManager_QuestAdvisorSmall;
        private static const ArrowRightGreen:Class = gAssetManager_ArrowRightGreen;
        private static const IconMailTypeLoot:Class = gAssetManager_IconMailTypeLoot;
        private static const ActionBarIcon08Deactivated:Class = gAssetManager_ActionBarIcon08Deactivated;
        private static const ActionBarIcon02Highlight:Class = gAssetManager_ActionBarIcon02Highlight;
        private static const ButtonIconAlloy:Class = gAssetManager_ButtonIconAlloy;
        private static const ButtonIconCoal:Class = gAssetManager_ButtonIconCoal;
        private static const ArrowLeftEnd:Class = gAssetManager_ArrowLeftEnd;
        private static const IconMasterGeologist:Class = gAssetManager_IconMasterGeologist;
        private static const ButtonIconHalfTheTime:Class = gAssetManager_ButtonIconHalfTheTime;
        private static var requestFailCounterDict:Dictionary = new Dictionary();
        private static const TrackedQuestBackground:Class = gAssetManager_TrackedQuestBackground;
        private static const DetailsIconWarehouse:Class = gAssetManager_DetailsIconWarehouse;
        private static const ButtonIconTaskShort:Class = gAssetManager_ButtonIconTaskShort;
        private static const ArrowRightDisabled:Class = gAssetManager_ArrowRightDisabled;
        private static const ButtonIconUpgradeGems:Class = gAssetManager_ButtonIconUpgradeGems;
        private static const IconMailTypeMailRead:Class = gAssetManager_IconMailTypeMailRead;
        private static const ProductionArrowDown:Class = gAssetManager_ProductionArrowDown;
        private static var countTotal:int = 0;
        private static const FriendBackgroundHighlight:Class = gAssetManager_FriendBackgroundHighlight;
        private static const ArrowLeft:Class = gAssetManager_ArrowLeft;
        private static const BuildQueueResourceMissing:Class = gAssetManager_BuildQueueResourceMissing;
        private static const ActionBarIcon06Highlight:Class = gAssetManager_ActionBarIcon06Highlight;
        private static const ArrowRight:Class = gAssetManager_ArrowRight;
        private static const ButtonAddCashOver:Class = gAssetManager_ButtonAddCashOver;
        private static const AvatarBackgroundSmall00:Class = gAssetManager_AvatarBackgroundSmall00;
        private static const AvatarBackgroundSmall01:Class = gAssetManager_AvatarBackgroundSmall01;
        private static const AvatarBackgroundSmall02:Class = gAssetManager_AvatarBackgroundSmall02;
        public static var inactiveFilter:ShaderFilter;
        private static const AvatarBackgroundSmall04:Class = gAssetManager_AvatarBackgroundSmall04;
        private static const AvatarBackgroundSmall05:Class = gAssetManager_AvatarBackgroundSmall05;
        private static const ArrowDownDisabled:Class = gAssetManager_ArrowDownDisabled;
        private static const AvatarBackground01:Class = gAssetManager_AvatarBackground01;
        private static const IconQuest:Class = gAssetManager_IconQuest;
        private static const AvatarBackground03:Class = gAssetManager_AvatarBackground03;
        private static const AvatarBackground04:Class = gAssetManager_AvatarBackground04;
        private static const AvatarBackground05:Class = gAssetManager_AvatarBackground05;
        private static const AvatarBackground06:Class = gAssetManager_AvatarBackground06;
        private static const AvatarBackground07:Class = gAssetManager_AvatarBackground07;
        private static const AvatarBackground08:Class = gAssetManager_AvatarBackground08;
        private static const AvatarBackground02:Class = gAssetManager_AvatarBackground02;
        private static const BackgroundNormal:Class = gAssetManager_BackgroundNormal;
        private static const FrameBuffTimed:Class = gAssetManager_FrameBuffTimed;
        private static const AvatarBackgroundSmall09:Class = gAssetManager_AvatarBackgroundSmall09;
        private static const AvatarBackgroundSmall03:Class = gAssetManager_AvatarBackgroundSmall03;
        private static const DailyLoginHeaderOrnamental:Class = gAssetManager_DailyLoginHeaderOrnamental;
        private static const AvatarBackgroundSmall06:Class = gAssetManager_AvatarBackgroundSmall06;
        private static const AvatarBackground09:Class = gAssetManager_AvatarBackground09;
        private static const AvatarBackgroundSmall12:Class = gAssetManager_AvatarBackgroundSmall12;
        private static const AvatarBackgroundSmall14:Class = gAssetManager_AvatarBackgroundSmall14;
        private static const AvatarBackground11:Class = gAssetManager_AvatarBackground11;
        private static const ArrowSmallSOver:Class = gAssetManager_ArrowSmallSOver;
        private static const AvatarBackground14:Class = gAssetManager_AvatarBackground14;
        private static const AvatarBackground10:Class = gAssetManager_AvatarBackground10;
        private static const AvatarBackgroundSmall10:Class = gAssetManager_AvatarBackgroundSmall10;
        private static const AvatarBackgroundSmall13:Class = gAssetManager_AvatarBackgroundSmall13;
        private static const QuestionMark:Class = gAssetManager_QuestionMark;
        private static const AvatarBackgroundSmall08:Class = gAssetManager_AvatarBackgroundSmall08;
        private static const IconEraseStreet:Class = gAssetManager_IconEraseStreet;
        private static const IconExplorer:Class = gAssetManager_IconExplorer;

        public function gAssetManager()
        {
            return;
        }// end function

        public static function GetResourceIcon(param1:String, param2:Boolean = true) : Bitmap
        {
            return LoadIcon(param1, param2, resources);
        }// end function

        private static function CompleteHandlerLoadDynamic(event:Event) : void
        {
            var _loc_2:* = event.target as LoaderInfo;
            Application.application.mMemoryMonitor.RegisterLoadedGraphic(_loc_2.bytesTotal);
            gAssetManager[_loc_2.loader.name][tempDict[_loc_2]] = _loc_2.content as Bitmap;
            var _loc_4:* = countLoaded + 1;
            countLoaded = _loc_4;
            completeFunction(event);
            return;
        }// end function

        public static function GetBitmap(param1:String, param2:Boolean = true) : Bitmap
        {
            return LoadIcon(param1, param2);
        }// end function

        public static function GetClass(param1:String) : Class
        {
            var c:Class;
            var _name_string:* = param1;
            if (_name_string == "")
            {
                if (gLog.isWarnEnabled(LOG_TYPE.GUI))
                {
                    gLog.logWarn(LOG_TYPE.GUI, "gAssetManager.GetClass(): Empty class name given! Called from: " + gMisc.GetCallingMethodName(3));
                }
                return new Class();
            }
            try
            {
                c = gAssetManager[_name_string] as Class;
            }
            catch (e:Error)
            {
                if (gLog.isWarnEnabled(LOG_TYPE.GUI))
                {
                    gLog.logWarn(LOG_TYPE.GUI, "gAssetManager.GetClass(): Class \"" + _name_string + "\" not found! Called from: " + gMisc.GetCallingMethodName(3));
                }
                c = new Class();
            }
            return c;
        }// end function

        public static function CompleteHandlerAMFPackLoaderBIN(event:Event) : void
        {
            var _loc_4:BinVO = null;
            var _loc_2:* = ByteArray(event.target.data);
            var _loc_3:* = _loc_2.readObject();
            var index:int = 0;
            while (index < _loc_3.length)
            {
                
                _loc_4 = _loc_3[index];
                binFiles[_loc_4.name] = _loc_4.bin;
                index++;
            }
            var _loc_7:* = countLoaded + 1;
            countLoaded = _loc_7;
            return;
        }// end function

        private static function TurnToGreyScale(param1:Bitmap) : Bitmap
        {
            var _loc_2:* = param1.bitmapData;
            _loc_2.applyFilter(_loc_2, _loc_2.rect, new Point(), inactiveFilter);
            param1.bitmapData = _loc_2;
            return param1;
        }// end function

        private static function ErrorHandler(event:Event) : void
        {
            var _loc_5:LoaderContext = null;
            var _loc_2:* = event.target as LoaderInfo;
            var _loc_3:* = requestDict[_loc_2] as URLRequest;
            var _loc_4:* = requestFailCounterDict[_loc_2];
            if (++requestFailCounterDict[_loc_2] < defines.STATIC_FILES_URL_LIST.length)
            {
                _loc_3.url = _loc_3.url.replace(defines.STATIC_FILES_URL_LIST[++requestFailCounterDict[_loc_2] - 1], defines.STATIC_FILES_URL_LIST[_loc_4]);
                _loc_5 = new LoaderContext(true);
                _loc_5.checkPolicyFile = true;
                _loc_2.loader.load(_loc_3, _loc_5);
                requestFailCounterDict[_loc_2] = _loc_4;
            }
            else
            {
                gErrorMessages.ShowIOErrorMessage(_loc_3.url);
            }
            return;
        }// end function

        public static function InitFilters() : void
        {
            inactiveShader = new Shader(new IconInactiveFilter() as ByteArray);
            inactiveFilter = new ShaderFilter(inactiveShader);
            return;
        }// end function

        public static function GetBuffIcon(param1:String, param2:Boolean = true) : Bitmap
        {
            return LoadIcon(param1, param2, buffs);
        }// end function

        private static function CloneBitmap(param1:Bitmap) : Bitmap
        {
            if (!param1)
            {
                return null;
            }
            var _loc_2:* = new Bitmap();
            _loc_2.bitmapData = param1.bitmapData.clone();
            return _loc_2;
        }// end function

        public static function CompleteHandlerAMFPackLoader(event:Event) : void
        {
            var _loc_4:BinVO = null;
            var _loc_2:* = ByteArray(event.target.data);
            var _loc_3:* = _loc_2.readObject();
            var _loc_5:* = new Loader();
            var _loc_6:int = 0;
            while (_loc_6 < _loc_3.length)
            {
                
                _loc_5 = new Loader();
                _loc_4 = _loc_3[_loc_6];
                tempDict[_loc_5.contentLoaderInfo] = _loc_4.name;
                _loc_5.name = AMFPackageURLLoader(event.target).targetDict;
                _loc_5.contentLoaderInfo.addEventListener(Event.COMPLETE, CompleteHandlerLoadDynamic);
                _loc_5.loadBytes(_loc_4.bin);
                var _loc_8:* = countTotal + 1;
                countTotal = _loc_8;
                _loc_6++;
            }
            var _loc_8:* = countLoaded + 1;
            countLoaded = _loc_8;
            return;
        }// end function

        public static function GetMilitaryIcon(param1:String, param2:Boolean = true) : Bitmap
        {
            return LoadIcon(param1, param2, military);
        }// end function

        public static function LoadIcons(param1:String, param2:Function) : void
        {
            var _loc_6:cXML = null;
            var _loc_7:AMFPackageURLLoader = null;
            var _loc_8:AMFPackageURLLoader = null;
            var _loc_9:AMFPackageURLLoader = null;
            var _loc_10:AMFPackageURLLoader = null;
            var _loc_11:AMFPackageURLLoader = null;
            var _loc_12:AMFPackageURLLoader = null;
            var _loc_13:AMFPackageURLLoader = null;
            var _loc_14:String = null;
            var _loc_15:String = null;
            var _loc_16:String = null;
            var _loc_17:String = null;
            completeFunction = param2;
            var _loc_3:* = global.gfxSettingsRootXML.MoveToSubNode("GameObjects");
            var _loc_4:* = _loc_3.MoveToSubNode("AvailableBuffs");
            var _loc_5:* = _loc_3.MoveToSubNode("AvailableBuffs").CreateChildrenArray();
            for each (_loc_6 in _loc_5)
            {
                
                _loc_14 = _loc_6.GetAttributeString_string("name");
                _loc_15 = _loc_6.GetAttributeString_string("iconfilename");
                _loc_16 = _loc_6.GetAttributeString_string("cursorType");
                if (_loc_16 != "")
                {
                    buffCursorTypes[_loc_14] = _loc_16;
                }
                _loc_17 = _loc_6.GetAttributeString_string("foreignCursorType");
                if (_loc_17 != "")
                {
                    buffCursorTypesForeign[_loc_14] = _loc_17;
                }
            }
            _loc_7 = new AMFPackageURLLoader();
            var _loc_19:* = countTotal + 1;
            countTotal = _loc_19;
            _loc_7.loadAMFPackage(gGfxResource.GetGfxFolder_string() + "icons/buildings/buildingicons.bin", CompleteHandlerAMFPackLoader, "buildings");
            _loc_8 = new AMFPackageURLLoader();
            var _loc_19:* = countTotal + 1;
            countTotal = _loc_19;
            _loc_8.loadAMFPackage(gGfxResource.GetGfxFolder_string() + "icons/resources/ressourceicons.bin", CompleteHandlerAMFPackLoader, "resources");
            _loc_9 = new AMFPackageURLLoader();
            var _loc_19:* = countTotal + 1;
            countTotal = _loc_19;
            _loc_9.loadAMFPackage(gGfxResource.GetGfxFolder_string() + "icons/units/battleicons.bin", CompleteHandlerAMFPackLoader, "military");
            _loc_10 = new AMFPackageURLLoader();
            var _loc_19:* = countTotal + 1;
            countTotal = _loc_19;
            _loc_10.loadAMFPackage(gGfxResource.GetGfxFolder_string() + "icons/buffs/bufficons.bin", CompleteHandlerAMFPackLoader, "buffs");
            _loc_11 = new AMFPackageURLLoader();
            var _loc_19:* = countTotal + 1;
            countTotal = _loc_19;
            _loc_11.loadAMFPackage(gGfxResource.GetGfxFolder_string() + "adventures/buffs/adventureicons.bin", CompleteHandlerAMFPackLoader, "buffs");
            _loc_12 = new AMFPackageURLLoader();
            var _loc_19:* = countTotal + 1;
            countTotal = _loc_19;
            _loc_12.loadAMFPackage(gGfxResource.GetGfxFolder_string() + "shop/icons/shopicons.bin", CompleteHandlerAMFPackLoader, "shopItems");
            _loc_13 = new AMFPackageURLLoader();
            var _loc_19:* = countTotal + 1;
            countTotal = _loc_19;
            _loc_13.loadAMFPackage(gGfxResource.GetGfxFolder_string() + "binlibs.bin", CompleteHandlerAMFPackLoaderBIN);
            return;
        }// end function

        public static function GetGuildBannerUrlById(param1:int) : String
        {
            return gGfxResource.GetGfxFolder_string() + "icons/guildbanner/banner" + (param1 < 10 ? ("0" + param1) : (param1)) + ".png";
        }// end function

        public static function GetShopIcon(param1:String, param2:Boolean = true) : Bitmap
        {
            return LoadIcon(param1, param2, shopItems);
        }// end function

        public static function IsLoaded() : Boolean
        {
            if (countTotal == countLoaded)
            {
                InitFilters();
                tempDict = null;
                return true;
            }
            return false;
        }// end function

        public static function GetBin(param1:String) : ByteArray
        {
            return binFiles[param1.substring(gGfxResource.GetGfxFolder_string().length)];
        }// end function

        public static function CheckGraphicsFileNameExtension(param1:String) : void
        {
            var _loc_2:* = param1.substr(param1.lastIndexOf("."));
            if (_loc_2 != ".png" && _loc_2 != ".jpg")
            {
                throw new Error("Error!: Extension " + _loc_2 + " is not allowed!");
            }
            return;
        }// end function

        private static function LoadIcon(param1:String, param2:Boolean = true, param3:Dictionary = null) : Bitmap
        {
            var bmd:BitmapData;
            var _name_string:* = param1;
            var _active:* = param2;
            var _data:* = param3;
            var bitmap:Bitmap;
            var iconError:Boolean;
            if (_name_string == "")
            {
                if (gLog.isWarnEnabled(LOG_TYPE.GUI))
                {
                    gLog.logWarn(LOG_TYPE.GUI, "gAssetManager.LoadIcon(): Empty icon name given! Called from: " + gMisc.GetCallingMethodName(3));
                }
                iconError;
            }
            else if (_data == null)
            {
                try
                {
                    bitmap = new gAssetManager[_name_string] as Bitmap;
                }
                catch (e:Error)
                {
                    iconError;
                }
            }
            else
            {
                bitmap = CloneBitmap(_data[_name_string]);
            }
            if (!iconError && !bitmap)
            {
                if (gLog.isWarnEnabled(LOG_TYPE.GUI))
                {
                    gLog.logWarn(LOG_TYPE.GUI, "gAssetManager.LoadIcon(): Bitmap \"" + _name_string + "\" not found! Called from: " + gMisc.GetCallingMethodName(3));
                }
                iconError;
            }
            if (iconError)
            {
                bmd = new BitmapData(1, 1);
                bmd.setPixel32(0, 0, 0);
                bitmap = new Bitmap(bmd);
            }
            return _active ? (bitmap) : (TurnToGreyScale(bitmap));
        }// end function

        public static function GetAvatarUrl(param1:int, param2:String = "large") : String
        {
            return gGfxResource.GetGfxFolder_string() + "icons/avatars/" + param2 + "/Avatar" + (param1 < 10 ? ("0" + param1) : (param1)) + ".png";
        }// end function

        private static function LoadPNG(param1:String, param2:String, param3:Function) : void
        {
            var lc:LoaderContext;
            var request:URLRequest;
            var _fileName_string:* = param1;
            var _identifier_string:* = param2;
            var _completeFunction:* = param3;
            var imageLoader:* = new Loader();
            imageLoader.contentLoaderInfo.addEventListener(Event.COMPLETE, _completeFunction);
            imageLoader.contentLoaderInfo.addEventListener(IOErrorEvent.IO_ERROR, ErrorHandler);
            imageLoader.contentLoaderInfo.addEventListener(SecurityErrorEvent.SECURITY_ERROR, ErrorHandler);
            CheckGraphicsFileNameExtension(_fileName_string);
            try
            {
                lc = new LoaderContext(true);
                lc.checkPolicyFile = true;
                request = new URLRequest(_fileName_string);
                imageLoader.load(request, lc);
                requestDict[imageLoader.contentLoaderInfo] = request;
                tempDict[imageLoader.contentLoaderInfo] = _identifier_string;
            }
            catch (error:Error)
            {
                gMisc.ConsoleOut("SWMMO Unable to load Image: " + error);
            }
            return;
        }// end function

        public static function GetQuestTriggerIcon(param1:dQuestDefinitionTriggerVO, param2:Boolean = true)
        {
            var _loc_3:* = undefined;
            switch(param1.type)
            {
                case QuestManagerStatic.TYPE_BUILDING:
                {
                    if (param1.condition == QuestManagerStatic.CONDITION_DESTROYED)
                    {
                        _loc_3 = GetBuildingIcon("Bandits");
                    }
                    else if (param1.condition == QuestManagerStatic.CONDITION_UPGRADED)
                    {
                        _loc_3 = GetBitmap("ButtonIconUpgrade");
                    }
                    else
                    {
                        _loc_3 = GetBuildingIcon(param1.name_string);
                    }
                    break;
                }
                case QuestManagerStatic.TYPE_RESOURCE:
                case QuestManagerStatic.TYPE_PAY_FOR_QUEST_FINISH:
                {
                    _loc_3 = GetResourceIcon(param1.name_string);
                    break;
                }
                case QuestManagerStatic.TYPE_SPECIALIST:
                {
                    if (param1.condition == QuestManagerStatic.CONDITION_FOUND_DEPOSIT)
                    {
                        _loc_3 = GetResourceIcon(param1.name_string);
                    }
                    else if (param1.condition == QuestManagerStatic.CONDITION_ASSIGNED_UNITS)
                    {
                        _loc_3 = GetBitmap("IconGeneral");
                    }
                    else
                    {
                        _loc_3 = LoadIcon("Icon" + param1.name_string);
                    }
                    break;
                }
                case QuestManagerStatic.TYPE_BUFF:
                case QuestManagerStatic.TYPE_BUFF_BY_FRIEND:
                case QuestManagerStatic.TYPE_BUFF_ON_FRIEND:
                {
                    if (param1.name_string != "")
                    {
                        _loc_3 = GetBuffIcon(param1.name_string);
                    }
                    else
                    {
                        _loc_3 = LoadIcon("ButtonIconCrown");
                    }
                    break;
                }
                case QuestManagerStatic.TYPE_MILITARYUNIT:
                {
                    _loc_3 = GetMilitaryIcon(param1.name_string);
                    break;
                }
                case QuestManagerStatic.TYPE_PLAYERLEVEL:
                {
                    _loc_3 = GetResourceIcon("XP");
                    break;
                }
                case QuestManagerStatic.TYPE_ADVENTURE:
                {
                    if (param1.name_string != "")
                    {
                        _loc_3 = cAdventureDefinition.FindAdventureDefinition(param1.name_string).GetAvatarImage();
                    }
                    else
                    {
                        _loc_3 = GetBitmap("AdventureAvatarDefault");
                    }
                    break;
                }
                case QuestManagerStatic.TYPE_SECTOR:
                {
                    if (param1.condition == QuestManagerStatic.CONDITION_EXPLORED)
                    {
                        _loc_3 = LoadIcon("ButtonIconExploreSector");
                    }
                    else if (param1.condition == QuestManagerStatic.CONDITION_CLAIMED)
                    {
                        _loc_3 = GetBuildingIcon(defines.WAREHOUSES_NAME_string);
                    }
                    else
                    {
                        _loc_3 = null;
                    }
                    break;
                }
                default:
                {
                    _loc_3 = null;
                    break;
                }
            }
            return _loc_3;
        }// end function

        public static function GetBuildingIcon(param1:String, param2:Boolean = true) : Bitmap
        {
            return LoadIcon(param1, param2, buildings);
        }// end function

    }
}
