package mx.messaging
{
    import flash.utils.*;
    import mx.logging.*;
    import mx.messaging.events.*;

    public class ConsumerMessageDispatcher extends Object
    {
        private const _consumerDuplicateMessageBarrier:Object;
        private const _channelSetRefCounts:Dictionary;
        private const _consumers:Object;
        private static var _instance:ConsumerMessageDispatcher;

        public function ConsumerMessageDispatcher()
        {
            _consumers = {};
            _channelSetRefCounts = new Dictionary();
            _consumerDuplicateMessageBarrier = {};
            return;
        }// end function

        public function registerSubscription(param1:AbstractConsumer) : void
        {
            _consumers[param1.clientId] = param1;
            if (_channelSetRefCounts[param1.channelSet] == null)
            {
                param1.channelSet.addEventListener(MessageEvent.MESSAGE, messageHandler);
                _channelSetRefCounts[param1.channelSet] = 1;
            }
            else
            {
                var _loc_2:* = _channelSetRefCounts;
                var _loc_3:* = param1.channelSet;
                var _loc_4:* = _channelSetRefCounts[param1.channelSet] + 1;
                _loc_2[_loc_3] = _loc_4;
            }
            return;
        }// end function

        private function messageHandler(event:MessageEvent) : void
        {
            var _loc_3:int = 0;
            var _loc_4:ChannelSet = null;
            var _loc_5:Array = null;
            var _loc_2:* = _consumers[event.message.clientId];
            if (_loc_2 == null)
            {
                if (Log.isDebug())
                {
                    Log.getLogger("mx.messaging.Consumer").debug("\'{0}\' received pushed message for consumer but no longer subscribed: {1}", event.message.clientId, event.message);
                }
                return;
            }
            if (event.target.currentChannel.channelSets.length > 1)
            {
                _loc_3 = 0;
                for each (_loc_4 in event.target.currentChannel.channelSets)
                {
                    
                    if (_channelSetRefCounts[_loc_4] != null)
                    {
                        _loc_3++;
                    }
                }
                if (_loc_3 > 1)
                {
                    if (_consumerDuplicateMessageBarrier[_loc_2.id] == null)
                    {
                        _consumerDuplicateMessageBarrier[_loc_2.id] = [event.messageId, _loc_3];
                        _loc_2.messageHandler(event);
                    }
                    _loc_5 = _consumerDuplicateMessageBarrier[_loc_2.id];
                    if (_loc_5[0] == event.messageId)
                    {
                        var _loc_6:* = _loc_5;
                        var _loc_7:int = 1;
                        _loc_6[_loc_7] = _loc_5[1] - 1;
                        if (--_loc_5[1] == 0)
                        {
                            delete _consumerDuplicateMessageBarrier[_loc_2.id];
                        }
                    }
                    return;
                }
            }
            _loc_2.messageHandler(event);
            return;
        }// end function

        public function unregisterSubscription(param1:AbstractConsumer) : void
        {
            delete _consumers[param1.clientId];
            var _loc_2:* = _channelSetRefCounts[param1.channelSet];
            if (--_loc_2 == 0)
            {
                param1.channelSet.removeEventListener(MessageEvent.MESSAGE, messageHandler);
                delete _channelSetRefCounts[param1.channelSet];
                if (_consumerDuplicateMessageBarrier[param1.id] != null)
                {
                    delete _consumerDuplicateMessageBarrier[param1.id];
                }
            }
            else
            {
                _channelSetRefCounts[param1.channelSet] = _loc_2 - 1;
            }
            return;
        }// end function

        public function isChannelUsedForSubscriptions(param1:Channel) : Boolean
        {
            var _loc_2:* = param1.channelSets;
            var _loc_3:ChannelSet = null;
            var _loc_4:* = _loc_2.length;
            var _loc_5:int = 0;
            while (_loc_5 < _loc_4)
            {
                
                _loc_3 = _loc_2[_loc_5];
                if (_channelSetRefCounts[_loc_3] != null && _loc_3.currentChannel == param1)
                {
                    return true;
                }
                _loc_5++;
            }
            return false;
        }// end function

        public static function getInstance() : ConsumerMessageDispatcher
        {
            if (!_instance)
            {
                _instance = new ConsumerMessageDispatcher;
            }
            return _instance;
        }// end function

    }
}
