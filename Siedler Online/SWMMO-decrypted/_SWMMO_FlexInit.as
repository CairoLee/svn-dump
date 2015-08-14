package 
{
    import Communication.VO.*;
    import Communication.VO.Guild.*;
    import Communication.VO.Mail.*;
    import Communication.VO.UpdateVO.*;
    import GUI.GAME.Chat.*;
    import ServerState.*;
    import flash.net.*;
    import mx.collections.*;
    import mx.core.*;
    import mx.effects.*;
    import mx.messaging.channels.*;
    import mx.messaging.config.*;
    import mx.messaging.messages.*;
    import mx.styles.*;
    import mx.utils.*;

    public class _SWMMO_FlexInit extends Object
    {
        private static var mx_messaging_channels_AMFChannel_ref:AMFChannel;

        public function _SWMMO_FlexInit()
        {
            return;
        }// end function

        public static function init(param1:IFlexModuleFactory) : void
        {
            var fbs:* = param1;
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("addedEffect", "added");
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("completeEffect", "complete");
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("creationCompleteEffect", "creationComplete");
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("focusInEffect", "focusIn");
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("focusOutEffect", "focusOut");
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("hideEffect", "hide");
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("itemsChangeEffect", "itemsChange");
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("mouseDownEffect", "mouseDown");
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("mouseUpEffect", "mouseUp");
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("moveEffect", "move");
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("removedEffect", "removed");
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("resizeEffect", "resize");
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("resizeEndEffect", "resizeEnd");
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("resizeStartEffect", "resizeStart");
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("rollOutEffect", "rollOut");
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("rollOverEffect", "rollOver");
            var _loc_3:* = EffectManager;
            _loc_3.mx_internal::registerEffectTrigger("showEffect", "show");
            try
            {
                if (getClassByAlias("defaultGame.Communication.VO.Guild.dGuildEditValueVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Guild.dGuildEditValueVO", dGuildEditValueVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Guild.dGuildEditValueVO", dGuildEditValueVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.Guild.dGuildHeadersListVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Guild.dGuildHeadersListVO", dGuildHeadersListVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Guild.dGuildHeadersListVO", dGuildHeadersListVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.Guild.dGuildLogListItemVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Guild.dGuildLogListItemVO", dGuildLogListItemVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Guild.dGuildLogListItemVO", dGuildLogListItemVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.Guild.dGuildPlayerListItemVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Guild.dGuildPlayerListItemVO", dGuildPlayerListItemVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Guild.dGuildPlayerListItemVO", dGuildPlayerListItemVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.Guild.dGuildPlayerPermissionVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Guild.dGuildPlayerPermissionVO", dGuildPlayerPermissionVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Guild.dGuildPlayerPermissionVO", dGuildPlayerPermissionVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.Guild.dGuildRankListItemVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Guild.dGuildRankListItemVO", dGuildRankListItemVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Guild.dGuildRankListItemVO", dGuildRankListItemVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.Guild.dGuildUpdateVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Guild.dGuildUpdateVO", dGuildUpdateVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Guild.dGuildUpdateVO", dGuildUpdateVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.Guild.dGuildVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Guild.dGuildVO", dGuildVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Guild.dGuildVO", dGuildVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.Mail.dBattleReportBodyVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Mail.dBattleReportBodyVO", dBattleReportBodyVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Mail.dBattleReportBodyVO", dBattleReportBodyVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.Mail.dBuffedDataVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Mail.dBuffedDataVO", dBuffedDataVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Mail.dBuffedDataVO", dBuffedDataVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.Mail.dFriendBodyVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Mail.dFriendBodyVO", dFriendBodyVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Mail.dFriendBodyVO", dFriendBodyVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.Mail.dGuildBodyVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Mail.dGuildBodyVO", dGuildBodyVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Mail.dGuildBodyVO", dGuildBodyVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.Mail.dHardCurrencyMailBodyVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Mail.dHardCurrencyMailBodyVO", dHardCurrencyMailBodyVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Mail.dHardCurrencyMailBodyVO", dHardCurrencyMailBodyVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.Mail.dMailVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Mail.dMailVO", dMailVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Mail.dMailVO", dMailVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.Mail.dNewMailCountVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Mail.dNewMailCountVO", dNewMailCountVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Mail.dNewMailCountVO", dNewMailCountVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.Mail.dTradeBodyVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Mail.dTradeBodyVO", dTradeBodyVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Mail.dTradeBodyVO", dTradeBodyVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.Mail.dTradeResultVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.Mail.dTradeResultVO", dTradeResultVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.Mail.dTradeResultVO", dTradeResultVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dAdventureClientInfoVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dAdventureClientInfoVO", dAdventureClientInfoVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dAdventureClientInfoVO", dAdventureClientInfoVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dAdventureExpiredVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dAdventureExpiredVO", dAdventureExpiredVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dAdventureExpiredVO", dAdventureExpiredVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dAdventurePlayerVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dAdventurePlayerVO", dAdventurePlayerVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dAdventurePlayerVO", dAdventurePlayerVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dAlertMessageVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dAlertMessageVO", dAlertMessageVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dAlertMessageVO", dAlertMessageVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dBattleResultVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dBattleResultVO", dBattleResultVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dBattleResultVO", dBattleResultVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dCasualty") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dCasualty", dCasualty);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dCasualty", dCasualty);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dExploreSectorResponseVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dExploreSectorResponseVO", dExploreSectorResponseVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dExploreSectorResponseVO", dExploreSectorResponseVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dExploredSectorDataVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dExploredSectorDataVO", dExploredSectorDataVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dExploredSectorDataVO", dExploredSectorDataVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dExploredSectorVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dExploredSectorVO", dExploredSectorVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dExploredSectorVO", dExploredSectorVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dFindDepositResponseVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dFindDepositResponseVO", dFindDepositResponseVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dFindDepositResponseVO", dFindDepositResponseVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dFindEventZoneResponseVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dFindEventZoneResponseVO", dFindEventZoneResponseVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dFindEventZoneResponseVO", dFindEventZoneResponseVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dFindTreasureResponseVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dFindTreasureResponseVO", dFindTreasureResponseVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dFindTreasureResponseVO", dFindTreasureResponseVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dFoundDepositVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dFoundDepositVO", dFoundDepositVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dFoundDepositVO", dFoundDepositVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dHardCurrencyPurchased") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dHardCurrencyPurchased", dHardCurrencyPurchased);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dHardCurrencyPurchased", dHardCurrencyPurchased);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dLootItemsVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dLootItemsVO", dLootItemsVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dLootItemsVO", dLootItemsVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dQuestUpdateVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dQuestUpdateVO", dQuestUpdateVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dQuestUpdateVO", dQuestUpdateVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dRemovedFriendVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dRemovedFriendVO", dRemovedFriendVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dRemovedFriendVO", dRemovedFriendVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.UpdateVO.dTravellingSpecialistArivalVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.UpdateVO.dTravellingSpecialistArivalVO", dTravellingSpecialistArivalVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.UpdateVO.dTravellingSpecialistArivalVO", dTravellingSpecialistArivalVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dAcceptItemTradeVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dAcceptItemTradeVO", dAcceptItemTradeVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dAcceptItemTradeVO", dAcceptItemTradeVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dAdventurePlayerListItemVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dAdventurePlayerListItemVO", dAdventurePlayerListItemVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dAdventurePlayerListItemVO", dAdventurePlayerListItemVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dAdventureVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dAdventureVO", dAdventureVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dAdventureVO", dAdventureVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dArmyVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dArmyVO", dArmyVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dArmyVO", dArmyVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dBackgroundTileVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dBackgroundTileVO", dBackgroundTileVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dBackgroundTileVO", dBackgroundTileVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dBuffApplianceVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dBuffApplianceVO", dBuffApplianceVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dBuffApplianceVO", dBuffApplianceVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dBuffVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dBuffVO", dBuffVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dBuffVO", dBuffVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dBuildQueueVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dBuildQueueVO", dBuildQueueVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dBuildQueueVO", dBuildQueueVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dBuildingVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dBuildingVO", dBuildingVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dBuildingVO", dBuildingVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dBuyOneClickShopItemVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dBuyOneClickShopItemVO", dBuyOneClickShopItemVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dBuyOneClickShopItemVO", dBuyOneClickShopItemVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dBuyShopItemVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dBuyShopItemVO", dBuyShopItemVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dBuyShopItemVO", dBuyShopItemVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dClientDateVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dClientDateVO", dClientDateVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dClientDateVO", dClientDateVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dClientInitDataVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dClientInitDataVO", dClientInitDataVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dClientInitDataVO", dClientInitDataVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dClientLogMessagesVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dClientLogMessagesVO", dClientLogMessagesVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dClientLogMessagesVO", dClientLogMessagesVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dDataIntStringVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dDataIntStringVO", dDataIntStringVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dDataIntStringVO", dDataIntStringVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dDataTrackingVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dDataTrackingVO", dDataTrackingVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dDataTrackingVO", dDataTrackingVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dDeclineItemTradeVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dDeclineItemTradeVO", dDeclineItemTradeVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dDeclineItemTradeVO", dDeclineItemTradeVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dDepositGroupVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dDepositGroupVO", dDepositGroupVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dDepositGroupVO", dDepositGroupVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dDepositQualityVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dDepositQualityVO", dDepositQualityVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dDepositQualityVO", dDepositQualityVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dDepositVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dDepositVO", dDepositVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dDepositVO", dDepositVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dFindDepositTaskVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dFindDepositTaskVO", dFindDepositTaskVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dFindDepositTaskVO", dFindDepositTaskVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dFreeLandscapeVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dFreeLandscapeVO", dFreeLandscapeVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dFreeLandscapeVO", dFreeLandscapeVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dGameTickCommandVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dGameTickCommandVO", dGameTickCommandVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dGameTickCommandVO", dGameTickCommandVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dItemTradeOfferVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dItemTradeOfferVO", dItemTradeOfferVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dItemTradeOfferVO", dItemTradeOfferVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dLandingFieldVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dLandingFieldVO", dLandingFieldVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dLandingFieldVO", dLandingFieldVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dLandscapeVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dLandscapeVO", dLandscapeVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dLandscapeVO", dLandscapeVO);
                try
                {
                }
                if (getClassByAlias("Communication.VO.dLocalUserSettingsVO") == null)
                {
                    registerClassAlias("Communication.VO.dLocalUserSettingsVO", dLocalUserSettingsVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("Communication.VO.dLocalUserSettingsVO", dLocalUserSettingsVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dMapValueItemVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dMapValueItemVO", dMapValueItemVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dMapValueItemVO", dMapValueItemVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dNumberVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dNumberVO", dNumberVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dNumberVO", dNumberVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dPathVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dPathVO", dPathVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dPathVO", dPathVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dPlayerListItemVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dPlayerListItemVO", dPlayerListItemVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dPlayerListItemVO", dPlayerListItemVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dPlayerVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dPlayerVO", dPlayerVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dPlayerVO", dPlayerVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dPosVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dPosVO", dPosVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dPosVO", dPosVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dProductionProtocollVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dProductionProtocollVO", dProductionProtocollVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dProductionProtocollVO", dProductionProtocollVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dPurchasedShopItemVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dPurchasedShopItemVO", dPurchasedShopItemVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dPurchasedShopItemVO", dPurchasedShopItemVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dQuestDefinitionContainerVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dQuestDefinitionContainerVO", dQuestDefinitionContainerVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dQuestDefinitionContainerVO", dQuestDefinitionContainerVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dQuestDefinitionHintVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dQuestDefinitionHintVO", dQuestDefinitionHintVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dQuestDefinitionHintVO", dQuestDefinitionHintVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dQuestDefinitionPostrequisitsVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dQuestDefinitionPostrequisitsVO", dQuestDefinitionPostrequisitsVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dQuestDefinitionPostrequisitsVO", dQuestDefinitionPostrequisitsVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dQuestDefinitionRewardVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dQuestDefinitionRewardVO", dQuestDefinitionRewardVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dQuestDefinitionRewardVO", dQuestDefinitionRewardVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dQuestDefinitionTriggerVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dQuestDefinitionTriggerVO", dQuestDefinitionTriggerVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dQuestDefinitionTriggerVO", dQuestDefinitionTriggerVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dQuestDefinitionVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dQuestDefinitionVO", dQuestDefinitionVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dQuestDefinitionVO", dQuestDefinitionVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dQuestElementVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dQuestElementVO", dQuestElementVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dQuestElementVO", dQuestElementVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dQuestPoolVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dQuestPoolVO", dQuestPoolVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dQuestPoolVO", dQuestPoolVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dQuestTriggerVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dQuestTriggerVO", dQuestTriggerVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dQuestTriggerVO", dQuestTriggerVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dQuestVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dQuestVO", dQuestVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dQuestVO", dQuestVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dRaiseArmyVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dRaiseArmyVO", dRaiseArmyVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dRaiseArmyVO", dRaiseArmyVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dResourceCreationVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dResourceCreationVO", dResourceCreationVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dResourceCreationVO", dResourceCreationVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dResourceVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dResourceVO", dResourceVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dResourceVO", dResourceVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dResourcesVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dResourcesVO", dResourcesVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dResourcesVO", dResourcesVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dSectorDiscoveryVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dSectorDiscoveryVO", dSectorDiscoveryVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dSectorDiscoveryVO", dSectorDiscoveryVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dSectorVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dSectorVO", dSectorVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dSectorVO", dSectorVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dServerAction") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dServerAction", dServerAction);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dServerAction", dServerAction);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dServerActionResult") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dServerActionResult", dServerActionResult);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dServerActionResult", dServerActionResult);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dServerCall") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dServerCall", dServerCall);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dServerCall", dServerCall);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dServerClientUpdateVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dServerClientUpdateVO", dServerClientUpdateVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dServerClientUpdateVO", dServerClientUpdateVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dServerResponse") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dServerResponse", dServerResponse);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dServerResponse", dServerResponse);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dSpecialistResultVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dSpecialistResultVO", dSpecialistResultVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dSpecialistResultVO", dSpecialistResultVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dSpecialistTaskVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dSpecialistTaskVO", dSpecialistTaskVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dSpecialistTaskVO", dSpecialistTaskVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dSpecialistTask_AttackBuildingVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_AttackBuildingVO", dSpecialistTask_AttackBuildingVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_AttackBuildingVO", dSpecialistTask_AttackBuildingVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dSpecialistTask_ExploreSectorVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_ExploreSectorVO", dSpecialistTask_ExploreSectorVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_ExploreSectorVO", dSpecialistTask_ExploreSectorVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dSpecialistTask_FindDepositVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_FindDepositVO", dSpecialistTask_FindDepositVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_FindDepositVO", dSpecialistTask_FindDepositVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dSpecialistTask_FindEventZoneVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_FindEventZoneVO", dSpecialistTask_FindEventZoneVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_FindEventZoneVO", dSpecialistTask_FindEventZoneVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dSpecialistTask_FindTreasureVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_FindTreasureVO", dSpecialistTask_FindTreasureVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_FindTreasureVO", dSpecialistTask_FindTreasureVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dSpecialistTask_MoveVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_MoveVO", dSpecialistTask_MoveVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_MoveVO", dSpecialistTask_MoveVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dSpecialistTask_RecoverVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_RecoverVO", dSpecialistTask_RecoverVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_RecoverVO", dSpecialistTask_RecoverVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dSpecialistTask_TravelToZoneVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_TravelToZoneVO", dSpecialistTask_TravelToZoneVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_TravelToZoneVO", dSpecialistTask_TravelToZoneVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dSpecialistTask_WaitForConfirmationVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_WaitForConfirmationVO", dSpecialistTask_WaitForConfirmationVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dSpecialistTask_WaitForConfirmationVO", dSpecialistTask_WaitForConfirmationVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dSpecialistVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dSpecialistVO", dSpecialistVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dSpecialistVO", dSpecialistVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dSquadVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dSquadVO", dSquadVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dSquadVO", dSquadVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dStartTimedProductionVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dStartTimedProductionVO", dStartTimedProductionVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dStartTimedProductionVO", dStartTimedProductionVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dStreetVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dStreetVO", dStreetVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dStreetVO", dStreetVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dTempBuildSlotVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dTempBuildSlotVO", dTempBuildSlotVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dTempBuildSlotVO", dTempBuildSlotVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dTimedProductionQueueChangeVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dTimedProductionQueueChangeVO", dTimedProductionQueueChangeVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dTimedProductionQueueChangeVO", dTimedProductionQueueChangeVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dTimedProductionVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dTimedProductionVO", dTimedProductionVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dTimedProductionVO", dTimedProductionVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dTrackedMissionListVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dTrackedMissionListVO", dTrackedMissionListVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dTrackedMissionListVO", dTrackedMissionListVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dTrackedMissionVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dTrackedMissionVO", dTrackedMissionVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dTrackedMissionVO", dTrackedMissionVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dTradeOfferVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dTradeOfferVO", dTradeOfferVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dTradeOfferVO", dTradeOfferVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dTradeVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dTradeVO", dTradeVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dTradeVO", dTradeVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dUniqueID") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dUniqueID", dUniqueID);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dUniqueID", dUniqueID);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dUpateVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dUpateVO", dUpateVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dUpateVO", dUpateVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dZoneCheckVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dZoneCheckVO", dZoneCheckVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dZoneCheckVO", dZoneCheckVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dZoneRefreshVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dZoneRefreshVO", dZoneRefreshVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dZoneRefreshVO", dZoneRefreshVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.Communication.VO.dZoneVO") == null)
                {
                    registerClassAlias("defaultGame.Communication.VO.dZoneVO", dZoneVO);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.Communication.VO.dZoneVO", dZoneVO);
                try
                {
                }
                if (getClassByAlias("defaultGame.GUI.GAME.Chat.cTradeData") == null)
                {
                    registerClassAlias("defaultGame.GUI.GAME.Chat.cTradeData", cTradeData);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.GUI.GAME.Chat.cTradeData", cTradeData);
                try
                {
                }
                if (getClassByAlias("defaultGame.ServerState.dResource") == null)
                {
                    registerClassAlias("defaultGame.ServerState.dResource", dResource);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("defaultGame.ServerState.dResource", dResource);
                try
                {
                }
                if (getClassByAlias("ServerState.dResourceDefinition") == null)
                {
                    registerClassAlias("ServerState.dResourceDefinition", dResourceCreationDefinition);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("ServerState.dResourceDefinition", dResourceCreationDefinition);
                try
                {
                }
                if (getClassByAlias("flex.messaging.io.ArrayCollection") == null)
                {
                    registerClassAlias("flex.messaging.io.ArrayCollection", ArrayCollection);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("flex.messaging.io.ArrayCollection", ArrayCollection);
                try
                {
                }
                if (getClassByAlias("flex.messaging.io.ArrayList") == null)
                {
                    registerClassAlias("flex.messaging.io.ArrayList", ArrayList);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("flex.messaging.io.ArrayList", ArrayList);
                try
                {
                }
                if (getClassByAlias("flex.messaging.config.ConfigMap") == null)
                {
                    registerClassAlias("flex.messaging.config.ConfigMap", ConfigMap);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("flex.messaging.config.ConfigMap", ConfigMap);
                try
                {
                }
                if (getClassByAlias("flex.messaging.messages.AcknowledgeMessage") == null)
                {
                    registerClassAlias("flex.messaging.messages.AcknowledgeMessage", AcknowledgeMessage);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("flex.messaging.messages.AcknowledgeMessage", AcknowledgeMessage);
                try
                {
                }
                if (getClassByAlias("DSK") == null)
                {
                    registerClassAlias("DSK", AcknowledgeMessageExt);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("DSK", AcknowledgeMessageExt);
                try
                {
                }
                if (getClassByAlias("flex.messaging.messages.AsyncMessage") == null)
                {
                    registerClassAlias("flex.messaging.messages.AsyncMessage", AsyncMessage);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("flex.messaging.messages.AsyncMessage", AsyncMessage);
                try
                {
                }
                if (getClassByAlias("DSA") == null)
                {
                    registerClassAlias("DSA", AsyncMessageExt);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("DSA", AsyncMessageExt);
                try
                {
                }
                if (getClassByAlias("flex.messaging.messages.CommandMessage") == null)
                {
                    registerClassAlias("flex.messaging.messages.CommandMessage", CommandMessage);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("flex.messaging.messages.CommandMessage", CommandMessage);
                try
                {
                }
                if (getClassByAlias("DSC") == null)
                {
                    registerClassAlias("DSC", CommandMessageExt);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("DSC", CommandMessageExt);
                try
                {
                }
                if (getClassByAlias("flex.messaging.messages.ErrorMessage") == null)
                {
                    registerClassAlias("flex.messaging.messages.ErrorMessage", ErrorMessage);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("flex.messaging.messages.ErrorMessage", ErrorMessage);
                try
                {
                }
                if (getClassByAlias("flex.messaging.messages.MessagePerformanceInfo") == null)
                {
                    registerClassAlias("flex.messaging.messages.MessagePerformanceInfo", MessagePerformanceInfo);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("flex.messaging.messages.MessagePerformanceInfo", MessagePerformanceInfo);
                try
                {
                }
                if (getClassByAlias("flex.messaging.messages.RemotingMessage") == null)
                {
                    registerClassAlias("flex.messaging.messages.RemotingMessage", RemotingMessage);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("flex.messaging.messages.RemotingMessage", RemotingMessage);
                try
                {
                }
                if (getClassByAlias("flex.messaging.io.ObjectProxy") == null)
                {
                    registerClassAlias("flex.messaging.io.ObjectProxy", ObjectProxy);
                }
            }
            catch (e:Error)
            {
                registerClassAlias("flex.messaging.io.ObjectProxy", ObjectProxy);
            }
            var styleNames:Array;
            var i:int;
            while (i < styleNames.length)
            {
                
                StyleManager.registerInheritingStyle(styleNames[i]);
                i = (i + 1);
            }
            ServerConfig.xml = <services>
n	t<service id=""swmmo-zend"">
n	t	t<destination id=""swmmo"">
n	t	t	t<channels>
n	t	t	t	t<channel ref=""swmmo-endpoint""/>
n	t	t	t</channels>
n	t	t</destination>
n	t</service>
n	t<channels>
n	t	t<channel id=""swmmo-endpoint"" type=""mx.messaging.channels.AMFChannel"">
n	t	t	t<endpoint uri=""http://dus-infr-bbweb:8888/amf/""/>
n	t	t	t<properties>
n	t	t	t</properties>
n	t	t</channel>
n	t</channels>
n</services>")("<services>
	<service id="swmmo-zend">
		<destination id="swmmo">
			<channels>
				<channel ref="swmmo-endpoint"/>
			</channels>
		</destination>
	</service>
	<channels>
		<channel id="swmmo-endpoint" type="mx.messaging.channels.AMFChannel">
			<endpoint uri="http://dus-infr-bbweb:8888/amf/"/>
			<properties>
			</properties>
		</channel>
	</channels>
</services>;
            return;
        }// end function

    }
}
