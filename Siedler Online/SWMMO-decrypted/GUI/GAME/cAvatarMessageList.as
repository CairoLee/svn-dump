package GUI.GAME
{
    import BuffSystem.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import GO.*;
    import GUI.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Loca.*;
    import Interface.*;
    import ServerState.*;
    import Sound.*;
    import Specialists.*;
    import flash.events.*;

    public class cAvatarMessageList extends cGuiBaseElement
    {
        protected var prevMessage:AvatarMessageItemRenderer;
        private var mGI:cGameInterface;
        protected var mMessageList:AvatarMessageList;

        public function cAvatarMessageList()
        {
            return;
        }// end function

        public function IsMessageInList(param1:String) : Boolean
        {
            var _loc_3:AvatarMessageItemRenderer = null;
            var _loc_2:* = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGE_LABELS, param1);
            for each (_loc_3 in this.mMessageList.getChildren())
            {
                
                if (_loc_3.visible && _loc_3.headlineLabel.text == _loc_2)
                {
                    return true;
                }
            }
            return false;
        }// end function

        public function Init(param1:AvatarMessageList) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mMessageList = param1;
            return;
        }// end function

        public function AddMessage(param1:String, param2:Object = null) : void
        {
            var task:cSpecialistTask_WithSettler;
            var _messageType:* = param1;
            var data:* = param2;
            var sound:String;
            var message:* = new AvatarMessageItemRenderer();
            this.mMessageList.addChild(message);
            message.headlineLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGE_LABELS, _messageType);
            switch(_messageType)
            {
                case AVATAR_MESSAGE_TYPE.GENERAL_FINISHED_POSITIVE:
                case AVATAR_MESSAGE_TYPE.GENERAL_FINISHED_POSITIVE_VIEWER:
                case AVATAR_MESSAGE_TYPE.GENERAL_FINISHED_NEGATIVE:
                case AVATAR_MESSAGE_TYPE.GENERAL_FINISHED_NEGATIVE_VIEWER:
                {
                    sound;
                }
                case AVATAR_MESSAGE_TYPE.GENERAL_STARTET_TRANSFER:
                case AVATAR_MESSAGE_TYPE.GENERAL_TRAVELS_TO_ZONE:
                {
                    if (sound == "")
                    {
                        sound;
                    }
                }
                case AVATAR_MESSAGE_TYPE.GENERAL_RETREAT:
                case AVATAR_MESSAGE_TYPE.GENERAL_RETREAT_VIEWER:
                {
                    if (sound == "")
                    {
                        sound;
                    }
                }
                case AVATAR_MESSAGE_TYPE.GENERAL_STARTET_ATTACK:
                case AVATAR_MESSAGE_TYPE.GENERAL_STARTET_ATTACK_VIEWER:
                {
                    if (sound == "")
                    {
                        sound;
                    }
                }
                case AVATAR_MESSAGE_TYPE.GENERAL_LOST:
                case AVATAR_MESSAGE_TYPE.GENERAL_LOST_VIEWER:
                {
                    if (sound == "")
                    {
                        sound;
                    }
                }
                case AVATAR_MESSAGE_TYPE.GENERAL_WON_AND_CONTINUES:
                case AVATAR_MESSAGE_TYPE.GENERAL_WON_AND_CONTINUES_VIEWER:
                case AVATAR_MESSAGE_TYPE.GENERAL_WON_AND_RETURNS:
                case AVATAR_MESSAGE_TYPE.GENERAL_WON_AND_RETURNS_VIEWER:
                {
                    if (sound == "")
                    {
                        sound;
                    }
                    task = (data as cSpecialist).GetTask() as cSpecialistTask_WithSettler;
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                if (task.GetSettlerGridIndex() != -1)
                {
                    var _loc_1:* = task.GetSettlerGridIndex();
                }
                else
                {
                    _loc_1 = (data as cSpecialist).GetGarrison().GetBuildingGrid();
                }
                mGI.mCurrentPlayerZone.ScrollToGrid(_loc_1);
                return;
            }// end function
            );
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    message.image.source = gAssetManager.GetBitmap("IconGeneral");
                    break;
                }
                case AVATAR_MESSAGE_TYPE.NEW_GENERAL:
                {
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                null.gui.mStarMenu.Show();
                return;
            }// end function
            );
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    message.image.source = gAssetManager.GetBitmap("IconGeneral");
                    break;
                }
                case AVATAR_MESSAGE_TYPE.NEW_EXPLORER:
                {
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                globalFlash.gui.mStarMenu.Show();
                return;
            }// end function
            );
                    sound;
                }
                case AVATAR_MESSAGE_TYPE.EXPLORER_FINISHED_NEGATIVE:
                case AVATAR_MESSAGE_TYPE.EXPLORER_FOUND_MAP_FRAGMENT:
                case AVATAR_MESSAGE_TYPE.EXPLORER_DID_NOT_FIND_EVENT_ZONE:
                case AVATAR_MESSAGE_TYPE.EXPLORER_DID_NOT_FIND_TREASURE:
                {
                    if (sound == "")
                    {
                        sound;
                    }
                }
                case AVATAR_MESSAGE_TYPE.EXPLORER_FINISHED_POSITIVE:
                case AVATAR_MESSAGE_TYPE.EXPLORER_FOUND_EVENT_ZONE:
                case AVATAR_MESSAGE_TYPE.EXPLORER_FOUND_TREASURE:
                {
                    if (sound == "")
                    {
                        sound;
                    }
                }
                case AVATAR_MESSAGE_TYPE.EXPLORER_STARTED_FIND_TREASURE:
                case AVATAR_MESSAGE_TYPE.EXPLORER_STARTED_FIND_EVENT_ZONE:
                case AVATAR_MESSAGE_TYPE.EXPLORER_STARTED:
                {
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    message.image.source = gAssetManager.GetBitmap("IconExplorer");
                    if (sound == "")
                    {
                        sound;
                    }
                    break;
                }
                case AVATAR_MESSAGE_TYPE.NEW_GEOLOGIST:
                {
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                globalFlash.gui.mStarMenu.Show();
                return;
            }// end function
            );
                    sound;
                }
                case AVATAR_MESSAGE_TYPE.GEOLOGIST_STARTED:
                {
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    message.image.source = gAssetManager.GetBitmap("IconGeologist");
                    if (sound == "")
                    {
                        sound;
                    }
                    break;
                }
                case AVATAR_MESSAGE_TYPE.GEOLOGIST_FINISHED_NEGATIVE_ALL_ACCESSIBLE:
                case AVATAR_MESSAGE_TYPE.GEOLOGIST_FINISHED_NEGATIVE_NO_DEPOSIT:
                case AVATAR_MESSAGE_TYPE.GEOLOGIST_FINISHED_NEGATIVE:
                {
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType, [data as String]);
                    message.image.source = gAssetManager.GetResourceIcon(data as String);
                    if (sound == "")
                    {
                        sound;
                    }
                    break;
                }
                case AVATAR_MESSAGE_TYPE.GEOLOGIST_FINISHED_POSITIVE:
                {
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType, [(data as cDeposit).GetName_string()]);
                    message.image.source = gAssetManager.GetResourceIcon((data as cDeposit).GetName_string());
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                null.ScrollToGrid((data as cDeposit).GetGridIdx());
                return;
            }// end function
            );
                    sound;
                    break;
                }
                case AVATAR_MESSAGE_TYPE.DEPOSIT_DEPLETED:
                {
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType, [(data as cDeposit).GetName_string()]);
                    message.image.source = gAssetManager.GetResourceIcon((data as cDeposit).GetName_string());
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                null.mCurrentPlayerZone.ScrollToGrid((data as cDeposit).GetGridIdx());
                return;
            }// end function
            );
                    sound;
                    break;
                }
                case AVATAR_MESSAGE_TYPE.NEW_MAIL:
                {
                    sound;
                }
                case AVATAR_MESSAGE_TYPE.MAIL_SENT:
                {
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    message.image.source = gAssetManager.GetBitmap("ButtonIconNewMail");
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                null.gui.mMailWindow.Show();
                return;
            }// end function
            );
                    break;
                }
                case AVATAR_MESSAGE_TYPE.FRIEND_REQUEST_SENT:
                {
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    message.image.source = gAssetManager.GetBitmap("ButtonIconNewMail");
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                null.mMailWindow.Show();
                return;
            }// end function
            );
                    break;
                }
                case AVATAR_MESSAGE_TYPE.FRIEND_REQUEST_COOLDOWN:
                {
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    message.image.source = gAssetManager.GetBitmap("ButtonIconNewMail");
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                null.gui.mMailWindow.Show();
                return;
            }// end function
            );
                    break;
                }
                case AVATAR_MESSAGE_TYPE.NEW_QUEST:
                {
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    message.image.source = gAssetManager.GetBitmap("IconQuest");
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                null.HideCurrentActivePanel();
                globalFlash.gui.mQuestBook.Show();
                return;
            }// end function
            );
                    sound;
                    break;
                }
                case AVATAR_MESSAGE_TYPE.NO_TOOLS:
                {
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    message.image.source = gAssetManager.GetResourceIcon("Tool");
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                null.mCurrentPlayerZone.ScrollToGrid((data as cBuilding).GetBuildingGrid());
                return;
            }// end function
            );
                    break;
                }
                case AVATAR_MESSAGE_TYPE.LAST_BUILDING_LICENSE_USED:
                {
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    message.image.source = gAssetManager.GetBuffIcon("IncreaseMaxBuildingCount");
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                globalFlash.gui.mShopWindow.ShowDeepLink("AvatarMessage", 5004, 5);
                return;
            }// end function
            );
                    break;
                }
                case AVATAR_MESSAGE_TYPE.USED_DEPOSIT_BUFF:
                {
                    if ((data as cBuff).GetResourceName_string() != "")
                    {
                        message.image.source = gAssetManager.GetResourceIcon((data as cBuff).GetResourceName_string());
                        message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType, [(data as cBuff).GetAmount().toString(), (data as cBuff).GetResourceName_string()]);
                    }
                    else
                    {
                        message.image.source = gAssetManager.GetBuffIcon((data as cBuff).GetBuffDefinition().GetName_string());
                        message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType, [(data as cBuff).GetAmount().toString(), "Units"]);
                    }
                    break;
                }
                case AVATAR_MESSAGE_TYPE.USED_RESOURCE_BUFF:
                case AVATAR_MESSAGE_TYPE.USED_RESOURCE_BUFF_LIMIT_REACHED:
                {
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                null.gui.ShowWarehouse();
                return;
            }// end function
            );
                    message.image.source = gAssetManager.GetResourceIcon((data as cBuff).GetResourceName_string());
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType, [(data as cBuff).GetAppliedAmount().toString(), (data as cBuff).GetResourceName_string()]);
                    break;
                }
                case AVATAR_MESSAGE_TYPE.QUEST_REWARD_LIMIT_REACHED:
                {
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                null.ShowWarehouse();
                return;
            }// end function
            );
                    message.image.source = gAssetManager.GetResourceIcon((data as dResource).name_string);
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType, [(data as dResource).amount.toString(), (data as dResource).name_string]);
                    break;
                }
                case AVATAR_MESSAGE_TYPE.PLACED_BUFF:
                case AVATAR_MESSAGE_TYPE.PLACED_BUFF_ON_FRIEND:
                case AVATAR_MESSAGE_TYPE.PLACED_BUFF_ON_FRIEND_NEGATIVE:
                case AVATAR_MESSAGE_TYPE.PLACED_BUFF_BY_FRIEND:
                case AVATAR_MESSAGE_TYPE.PLACED_BUFF_BY_FRIEND_NEGATIVE:
                {
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                null.ScrollToGrid((data as cBuilding).GetBuildingGrid());
                return;
            }// end function
            );
                    message.image.source = gAssetManager.GetBuildingIcon((data as cBuilding).GetBuildingName_string());
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    break;
                }
                case AVATAR_MESSAGE_TYPE.PRODUCTION_FINISHED:
                {
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                globalFlash.gui.mStarMenu.Show();
                return;
            }// end function
            );
                    message.image.source = gAssetManager.GetBuildingIcon("ProvisionHouse");
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    sound;
                    break;
                }
                case AVATAR_MESSAGE_TYPE.INCREASED_MAX_BUILDINGS:
                {
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    message.image.source = gAssetManager.GetBuffIcon((data as cBuff).GetType_string());
                    break;
                }
                case AVATAR_MESSAGE_TYPE.INCREASED_PERMANENT_BUILDSLOT:
                {
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    message.image.source = gAssetManager.GetBuffIcon((data as cBuff).GetType_string());
                    break;
                }
                case AVATAR_MESSAGE_TYPE.PURCHASE_SUCCESSFUL:
                {
                    message.addEventListener(MouseEvent.CLICK, function () : void
            {
                null.mStarMenu.Show();
                return;
            }// end function
            );
                    globalFlash.gui.mActionBar.ShowStarAnim();
                }
                case AVATAR_MESSAGE_TYPE.PURCHASE_GIFT_SUCCESSFUL:
                {
                    message.image.source = gAssetManager.GetResourceIcon("HardCurrency");
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    sound;
                    break;
                }
                case AVATAR_MESSAGE_TYPE.RECRUITMENT_FINISHED:
                {
                    message.image.source = gAssetManager.GetBuildingIcon("Barracks");
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    sound;
                    break;
                }
                case AVATAR_MESSAGE_TYPE.TRADE_INITIATED:
                case AVATAR_MESSAGE_TYPE.TRADE_ACCEPTED:
                {
                    message.image.source = gAssetManager.GetBitmap("ButtonIconDiplomacy");
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    break;
                }
                case AVATAR_MESSAGE_TYPE.CLAIMED_SECTOR:
                {
                    message.image.source = gAssetManager.GetBuildingIcon(defines.WAREHOUSES_NAME_string);
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    break;
                }
                case AVATAR_MESSAGE_TYPE.SERVER_CALL_FAILED:
                {
                    sound;
                    break;
                }
                case AVATAR_MESSAGE_TYPE.GUILD_INCREASE_SIZE:
                {
                    message.image.source = gAssetManager.GetResourceIcon((data as cBuff).GetResourceName_string());
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType, [(data as cBuff).GetBuffDefinition().GetAmount().toString()]);
                    break;
                }
                case AVATAR_MESSAGE_TYPE.ADVENTURE_STARTED:
                {
                    message.image.source = gAssetManager.GetBitmap("ButtonIconFindAdventure");
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType, [(data as dAdventureClientInfoVO).adventureName]);
                    break;
                }
                case AVATAR_MESSAGE_TYPE.ADVENTURE_PLAYER_WAS_INVITED:
                {
                    message.image.source = gAssetManager.GetBitmap("ButtonIconFindAdventure");
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType, [data.playerName, data.adventureName, data.owner]);
                    break;
                }
                case AVATAR_MESSAGE_TYPE.ADVENTURE_PLAYER_ACCEPTED_INVITATION:
                case AVATAR_MESSAGE_TYPE.ADVENTURE_PLAYER_DECLINED_INVITATION:
                {
                    message.image.source = gAssetManager.GetBitmap("ButtonIconFindAdventure");
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType, [data.playerName, data.adventureName]);
                    break;
                }
                default:
                {
                    message.messageBody.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, _messageType);
                    break;
                }
            }
            if (sound == "")
            {
                sound;
            }
            cSoundManager.GetInstance().PlayEffect(sound);
            if (message.headlineLabel.text == "[undefined text]")
            {
                message.headlineLabel.text = _messageType;
            }
            if (globalFlash.gui.mChatPanel)
            {
                globalFlash.gui.mChatPanel.PutMessageToChannelWithoutServer("news", new Date(), "System", message.messageBody.text, false, false);
            }
            return;
        }// end function

    }
}
