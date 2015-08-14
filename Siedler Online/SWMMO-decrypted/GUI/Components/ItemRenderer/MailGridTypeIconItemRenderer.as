package GUI.Components.ItemRenderer
{
    import Enums.*;
    import GUI.Assets.*;
    import mx.controls.*;
    import mx.controls.dataGridClasses.*;
    import mx.styles.*;

    public class MailGridTypeIconItemRenderer extends Image
    {

        public function MailGridTypeIconItemRenderer()
        {
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                null.horizontalAlign = this;
                return;
            }// end function
            ;
            this.scaleContent = false;
            return;
        }// end function

        override public function initialize() : void
        {
            super.initialize();
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            switch(param1[DataGridListData(listData).dataField])
            {
                case MAIL_TYPE.MAIL:
                {
                    if (data.read)
                    {
                        this.source = gAssetManager.GetBitmap("IconMailTypeMailRead");
                    }
                    else
                    {
                        this.source = gAssetManager.GetBitmap("IconMailTypeMail");
                    }
                    break;
                }
                case MAIL_TYPE.TRADE:
                case MAIL_TYPE.ITEM_TRADE:
                case MAIL_TYPE.ACCEPT_TRADE:
                case MAIL_TYPE.ACCEPT_ITEM_TRADE:
                case MAIL_TYPE.DECLINE_TRADE:
                case MAIL_TYPE.DECLINE_ITEM_TRADE:
                {
                    this.source = gAssetManager.GetBitmap("IconMailTypeTrade");
                    break;
                }
                case MAIL_TYPE.FRIEND_REQUEST:
                case MAIL_TYPE.FRIEND_INVITATION_CONFIRMED:
                {
                    this.source = gAssetManager.GetBitmap("IconMailTypeFriend");
                    break;
                }
                case MAIL_TYPE.GUILD_INVITE:
                case MAIL_TYPE.GUILD_INVITE_DECLINE:
                case MAIL_TYPE.GUILD_INVITE_FULL:
                case MAIL_TYPE.GUILD_KICK:
                {
                    this.source = gAssetManager.GetBitmap("IconMailTypeGuild");
                    break;
                }
                case MAIL_TYPE.TREASURE_LOOT:
                case MAIL_TYPE.COOPERATION_REWARD:
                case MAIL_TYPE.BANDITS_LOOT:
                case MAIL_TYPE.QUEST_LOOT:
                {
                    this.source = gAssetManager.GetBitmap("IconMailTypeLoot");
                    break;
                }
                case MAIL_TYPE.GIFT:
                {
                    this.source = gAssetManager.GetBitmap("IconMailTypeGift");
                    break;
                }
                case MAIL_TYPE.BUFF:
                {
                    this.source = gAssetManager.GetBitmap("IconMailTypeGift");
                    break;
                }
                case MAIL_TYPE.BUFFED_BUILDING:
                case MAIL_TYPE.BUFFED_DEPOSIT:
                {
                    this.source = gAssetManager.GetBitmap("IconMailTypeBuffed");
                    break;
                }
                case MAIL_TYPE.BATTLE_REPORT:
                case MAIL_TYPE.BATTLE_REPORT_INTERCEPTED:
                {
                    this.source = gAssetManager.GetBitmap("IconMailTypeBattleReport");
                    break;
                }
                case MAIL_TYPE.HARD_CURRENCY_PURCHASED:
                case MAIL_TYPE.INVITED_FRIEND_PURCHASED:
                {
                    this.source = gAssetManager.GetBitmap("IconMailTypeHardCurrency");
                    break;
                }
                case MAIL_TYPE.ADVENTURE_WON_LOOT:
                case MAIL_TYPE.ADVENTURE_LOST_LOOT:
                case MAIL_TYPE.INVITE_TO_ADVENTURE:
                case MAIL_TYPE.FIND_ADVENTURE_LOOT_POSITIVE:
                case MAIL_TYPE.FIND_ADVENTURE_LOOT_NEGATIVE:
                case MAIL_TYPE.FIND_ADVENTURE_LOOT_MAP_FRAGMENT:
                {
                    this.source = gAssetManager.GetBitmap("IconMailTypeAdventureLoot");
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

    }
}
