package com.bluebyte.tso.chat
{
    import com.bluebyte.bluefire.api.controller.slashCommands.*;
    import com.bluebyte.bluefire.puremvc.*;
    import mx.collections.*;
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.mediator.*;

    public class SlashCommandMediator extends Mediator
    {
        public static const NAME:String = "SlashCommandMediator";
        private static const _commands:ArrayCollection = new ArrayCollection();

        public function SlashCommandMediator()
        {
            super(NAME);
            return;
        }// end function

        override public function listNotificationInterests() : Array
        {
            return [BlueFireFacade.REGISTER_SLASH_COMMAND, BlueFireFacade.EVALUATE_SLASH_COMMAND];
        }// end function

        override public function handleNotification(param1:INotification) : void
        {
            var _loc_2:SlashCommand = null;
            var _loc_3:String = null;
            switch(param1.getName())
            {
                case BlueFireFacade.REGISTER_SLASH_COMMAND:
                {
                    _commands.addItem(param1.getBody());
                    break;
                }
                case BlueFireFacade.EVALUATE_SLASH_COMMAND:
                {
                    for each (_loc_2 in _commands)
                    {
                        
                        _loc_3 = _loc_2.execute(param1.getBody() as String);
                        if (_loc_3)
                        {
                            sendNotification(_loc_3, param1.getBody());
                            break;
                        }
                    }
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
