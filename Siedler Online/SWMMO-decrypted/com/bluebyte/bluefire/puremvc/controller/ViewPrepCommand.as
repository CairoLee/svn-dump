package com.bluebyte.bluefire.puremvc.controller
{
    import com.bluebyte.bluefire.puremvc.view.xiff.*;
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.command.*;

    public class ViewPrepCommand extends SimpleCommand
    {

        public function ViewPrepCommand()
        {
            return;
        }// end function

        override public function execute(param1:INotification) : void
        {
            var _loc_2:* = param1.getBody() as Array;
            facade.registerMediator(new _loc_2[1](_loc_2[0]));
            facade.registerMediator(new XIFFConnectionMediator());
            facade.registerMediator(new XIFFRoomManagerMediator());
            facade.registerMediator(new XIFFRosterMediator());
            return;
        }// end function

    }
}
