package com.bluebyte.tso.chat
{
    import com.bluebyte.bluefire.api.controller.*;
    import com.bluebyte.bluefire.api.controller.slashCommands.*;
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.puremvc.*;
    import com.bluebyte.bluefire.puremvc.model.*;
    import com.bluebyte.bluefire.puremvc.view.*;
    import com.bluebyte.tso.chat.Commands.*;
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.mediator.*;

    public class SlashCommandsMediator extends Mediator
    {
        public static const NAME:String = "SlashCommandsMediator";

        public function SlashCommandsMediator(param1:IChatPanel)
        {
            super(NAME, param1);
            return;
        }// end function

        override public function listNotificationInterests() : Array
        {
            return [cAll.COMMAND_ALL, cBan.COMMAND_BAN, cChatInfoCommand.COMMAND_CHAT_INFO, cFindBan.COMMAND_FIND_BAN, cFindFriend.COMMAND_FIND_FRIEND, cFindUser.COMMAND_FIND_USER, cHelp.COMMAND_HELP, cIgnoreAdd.COMMAND_IGNORE_ADD, cIgnoreRemove.COMMAND_IGNORE_REMOVE, cIgnoreShow.COMMAND_IGNORE_SHOW, cJoinChat.COMMAND_JOIN_CHAT, cLeaveChat.COMMAND_LEAVE_CHAT, cReport.COMMAND_REPORT, cShowModLog.COMMAND_SHOW_MOD_LOG, cUnban.COMMAND_UNBAN, cVersion.COMMAND_VERSION, cReportingShow.COMMAND_REPORTING_SHOW];
        }// end function

        protected function registerSlashCommand(param1:SlashCommand) : void
        {
            sendNotification(BlueFireFacade.REGISTER_SLASH_COMMAND, param1);
            return;
        }// end function

        protected function get panel() : IChatPanel
        {
            return viewComponent as IChatPanel;
        }// end function

        override public function onRegister() : void
        {
            super.onRegister();
            this.registerSlashCommand(new cAll());
            this.registerSlashCommand(new cBan());
            this.registerSlashCommand(new cChatInfoCommand());
            this.registerSlashCommand(new cFindBan());
            this.registerSlashCommand(new cFindFriend());
            this.registerSlashCommand(new cFindUser());
            this.registerSlashCommand(new cHelp());
            this.registerSlashCommand(new cIgnoreAdd());
            this.registerSlashCommand(new cIgnoreRemove());
            this.registerSlashCommand(new cIgnoreShow());
            this.registerSlashCommand(new cJoinChat());
            this.registerSlashCommand(new cLeaveChat());
            this.registerSlashCommand(new cReport());
            this.registerSlashCommand(new cShowModLog());
            this.registerSlashCommand(new cUnban());
            this.registerSlashCommand(new cVersion());
            this.registerSlashCommand(new cReportingShow());
            return;
        }// end function

        override public function handleNotification(param1:INotification) : void
        {
            var _loc_5:ConnectionProxy = null;
            var _loc_6:ConnectionProxy = null;
            var _loc_2:* = param1.getBody() as MessageVO;
            var _loc_3:* = new MessageVO();
            var _loc_4:* = this.panel.mucs.dataProvider.getItemIndex(this.panel.selectedChannel);
            switch(param1.getName())
            {
                case cAll.COMMAND_ALL:
                case cBan.COMMAND_BAN:
                case cChatInfoCommand.COMMAND_CHAT_INFO:
                case cFindBan.COMMAND_FIND_BAN:
                case cFindFriend.COMMAND_FIND_FRIEND:
                case cFindUser.COMMAND_FIND_USER:
                case cIgnoreAdd.COMMAND_IGNORE_ADD:
                case cIgnoreRemove.COMMAND_IGNORE_REMOVE:
                case cIgnoreShow.COMMAND_IGNORE_SHOW:
                case cShowModLog.COMMAND_SHOW_MOD_LOG:
                case cReport.COMMAND_REPORT:
                case cUnban.COMMAND_UNBAN:
                case cReportingShow.COMMAND_REPORTING_SHOW:
                {
                    _loc_3.text = param1.getBody() as String;
                    _loc_3.room = this.panel.selectedChannel.name;
                    if (_loc_4 != -1)
                    {
                        _loc_3.groupMessage = true;
                    }
                    sendNotification(BlueFireFacade.SEND_MESSAGE, _loc_3);
                    break;
                }
                case cHelp.COMMAND_HELP:
                {
                    _loc_3.room = this.panel.selectedChannel.name;
                    _loc_3.text = TextController.instance.getText("ChatHelpCommand");
                    _loc_3.sender = new OccupantVO();
                    _loc_3.time = new Date();
                    _loc_6 = facade.retrieveProxy(ConnectionProxy.NAME) as ConnectionProxy;
                    _loc_3.sender.name = TextController.instance.getText("SenderHelp");
                    _loc_3.sender.id = _loc_6.player.id;
                    _loc_3.important = true;
                    if (_loc_4 != -1)
                    {
                        _loc_3.groupMessage = true;
                    }
                    sendNotification(BlueFireFacade.ADD_MESSAGE, _loc_3);
                    break;
                }
                case cJoinChat.COMMAND_JOIN_CHAT:
                {
                    sendNotification(BlueFireFacade.ROOM_JOIN, (param1.getBody() as String).split(" ")[1]);
                    break;
                }
                case cVersion.COMMAND_VERSION:
                {
                    _loc_3.room = this.panel.selectedChannel.name;
                    _loc_3.sender = new OccupantVO();
                    _loc_3.sender.name = TextController.instance.getText("SenderHelp");
                    _loc_3.time = new Date();
                    _loc_5 = facade.retrieveProxy(ConnectionProxy.NAME) as ConnectionProxy;
                    _loc_3.text = TextController.instance.getText("ClientVersionNumber", [ConnectionProxy.VERSION + ""]);
                    if (_loc_4 != -1)
                    {
                        _loc_3.groupMessage = true;
                    }
                    sendNotification(BlueFireFacade.ADD_MESSAGE, _loc_3);
                    break;
                }
                case cLeaveChat.COMMAND_LEAVE_CHAT:
                {
                    sendNotification(BlueFireFacade.LEAVE_CHAT, _loc_3);
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
