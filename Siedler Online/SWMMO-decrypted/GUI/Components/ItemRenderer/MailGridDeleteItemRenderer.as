package GUI.Components.ItemRenderer
{
    import Communication.VO.Mail.*;
    import Enums.*;
    import GUI.GAME.*;
    import flash.events.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class MailGridDeleteItemRenderer extends Canvas
    {
        private var _embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_push_png_1727123388:Class;
        private var _embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_standard_png_770916986:Class;
        private var _2082343164btnClose:Button;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_mouseover_png_2116628968:Class;
        private var _embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_disable_png_639665702:Class;

        public function MailGridDeleteItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {childDescriptors:[new UIComponentDescriptor({type:Button, id:"btnClose", events:{click:"__btnClose_click"}, stylesFactory:function () : void
                {
                    null.upSkin = this;
                    this.downSkin = _embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_push_png_1727123388;
                    this.overSkin = _embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_mouseover_png_2116628968;
                    this.disabledSkin = _embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_disable_png_639665702;
                    this.horizontalCenter = "0";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:null, height:21};
                }// end function
                })]};
            }// end function
            });
            this._embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_disable_png_639665702 = MailGridDeleteItemRenderer__embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_disable_png_639665702;
            this._embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_mouseover_png_2116628968 = MailGridDeleteItemRenderer__embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_mouseover_png_2116628968;
            this._embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_push_png_1727123388 = MailGridDeleteItemRenderer__embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_push_png_1727123388;
            this._embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_standard_png_770916986 = MailGridDeleteItemRenderer__embed_mxml_____data_src_gfx_embedded_mailwindow_x_button_standard_png_770916986;
            mx_internal::_document = this;
            return;
        }// end function

        private function deleteMail() : void
        {
            this.dispatchEvent(new ListEvent(cMailWindow.DELETE_MAIL, true, false, 0, data.id));
            return;
        }// end function

        public function __btnClose_click(event:MouseEvent) : void
        {
            this.deleteMail();
            return;
        }// end function

        public function set btnClose(param1:Button) : void
        {
            var _loc_2:* = this._2082343164btnClose;
            if (_loc_2 !== param1)
            {
                this._2082343164btnClose = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "btnClose", _loc_2, param1));
            }
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            var _loc_2:* = (data as dMailVO).type;
            if (_loc_2 == MAIL_TYPE.BANDITS_LOOT || _loc_2 == MAIL_TYPE.DECLINE_TRADE || _loc_2 == MAIL_TYPE.DECLINE_ITEM_TRADE || _loc_2 == MAIL_TYPE.ACCEPT_TRADE || _loc_2 == MAIL_TYPE.ACCEPT_ITEM_TRADE || _loc_2 == MAIL_TYPE.TREASURE_LOOT || _loc_2 == MAIL_TYPE.COOPERATION_REWARD || _loc_2 == MAIL_TYPE.ADVENTURE_WON_LOOT || _loc_2 == MAIL_TYPE.ADVENTURE_LOST_LOOT || _loc_2 == MAIL_TYPE.GIFT || _loc_2 == MAIL_TYPE.BUFF || _loc_2 == MAIL_TYPE.FIND_ADVENTURE_LOOT_POSITIVE || _loc_2 == MAIL_TYPE.FIND_ADVENTURE_LOOT_MAP_FRAGMENT || _loc_2 == MAIL_TYPE.QUEST_LOOT)
            {
                this.btnClose.enabled = false;
            }
            else
            {
                this.btnClose.enabled = true;
            }
            return;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        public function get btnClose() : Button
        {
            return this._2082343164btnClose;
        }// end function

    }
}
