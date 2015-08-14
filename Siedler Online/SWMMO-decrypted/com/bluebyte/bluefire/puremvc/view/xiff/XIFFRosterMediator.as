package com.bluebyte.bluefire.puremvc.view.xiff
{
    import com.bluebyte.bluefire.api.model.vo.*;
    import com.bluebyte.bluefire.puremvc.*;
    import org.igniterealtime.xiff.core.*;
    import org.igniterealtime.xiff.data.*;
    import org.igniterealtime.xiff.data.im.*;
    import org.igniterealtime.xiff.events.*;
    import org.igniterealtime.xiff.im.*;
    import org.puremvc.as3.multicore.interfaces.*;
    import org.puremvc.as3.multicore.patterns.mediator.*;

    public class XIFFRosterMediator extends Mediator implements IMediator
    {
        public static const NAME:String = "XIFFRosterMediator";

        public function XIFFRosterMediator()
        {
            super(NAME);
            return;
        }// end function

        override public function listNotificationInterests() : Array
        {
            return [XIFFConnectionMediator.XIFF_CONNECTION_CREATED];
        }// end function

        override public function handleNotification(param1:INotification) : void
        {
            switch(param1.getName())
            {
                case XIFFConnectionMediator.XIFF_CONNECTION_CREATED:
                {
                    viewComponent = new Roster(param1.getBody() as XMPPConnection);
                    this.roster.addEventListener(RosterEvent.ROSTER_LOADED, this.roster_RosterLoadedHandler);
                    this.roster.addEventListener(RosterEvent.USER_PRESENCE_UPDATED, this.roster_UserPresenceUpdatedHandler);
                    this.roster.addEventListener(RosterEvent.USER_ADDED, this.roster_UserAddedHandler);
                    this.roster.addEventListener(RosterEvent.SUBSCRIPTION_REQUEST, this.roster_SubscriptionRequestHandler);
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        private function roster_RosterLoadedHandler(event:RosterEvent) : void
        {
            trace("yes");
            var _loc_2:* = new Presence(null, this.roster.connection.jid.escaped, null, null, null, 1);
            this.roster.connection.send(_loc_2);
            this.roster.removeEventListener(RosterEvent.ROSTER_LOADED, this.roster_RosterLoadedHandler);
            sendNotification(BlueFireFacade.ROOM_JOIN_ALL);
            return;
        }// end function

        private function roster_UserPresenceUpdatedHandler(event:RosterEvent) : void
        {
            var _loc_2:* = event.data;
            sendNotification(BlueFireFacade.FRIEND_PRESENCE_UPDATED, new PresenceUpdatedVO(_loc_2.displayName, _loc_2.online));
            return;
        }// end function

        private function roster_UserAddedHandler(event:RosterEvent) : void
        {
            var _loc_2:* = event.data;
            sendNotification(BlueFireFacade.FRIEND_PRESENCE_UPDATED, new PresenceUpdatedVO(_loc_2.displayName, _loc_2.online));
            return;
        }// end function

        private function get roster() : Roster
        {
            return viewComponent as Roster;
        }// end function

        private function roster_SubscriptionRequestHandler(event:RosterEvent) : void
        {
            this.roster.grantSubscription(event.jid, true);
            return;
        }// end function

    }
}
