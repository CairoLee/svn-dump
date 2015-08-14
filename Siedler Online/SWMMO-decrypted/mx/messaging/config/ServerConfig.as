package mx.messaging.config
{
    import flash.utils.*;
    import mx.collections.*;
    import mx.messaging.*;
    import mx.messaging.errors.*;
    import mx.resources.*;
    import mx.utils.*;

    public class ServerConfig extends Object
    {
        private static var _resourceManager:IResourceManager;
        public static const URI_ATTR:String = "uri";
        private static var _clusteredChannels:Object = {};
        private static var _unclusteredChannels:Object = {};
        private static var _configFetchedChannels:Object;
        public static var channelSetFactory:Class = ChannelSet;
        public static var serverConfigData:XML;
        private static var _channelSets:Object = {};
        public static const CLASS_ATTR:String = "type";

        public function ServerConfig()
        {
            return;
        }// end function

        public static function getProperties(param1:String) : XMLList
        {
            var destination:XMLList;
            var message:String;
            var destinationId:* = param1;
            var _loc_4:int = 0;
            var _loc_5:* = xml..destination;
            var _loc_3:* = new XMLList("");
            for each (_loc_6 in _loc_5)
            {
                
                var _loc_7:* = _loc_5[_loc_4];
                with (_loc_5[_loc_4])
                {
                    if (@id == destinationId)
                    {
                        _loc_3[_loc_4] = _loc_6;
                    }
                }
            }
            destination = _loc_3;
            if (destination.length() > 0)
            {
                return destination.properties;
            }
            message = resourceManager.getString("messaging", "unknownDestination", [destinationId]);
            throw new InvalidDestinationError(message);
        }// end function

        static function getChannelIdList(param1:String) : Array
        {
            var _loc_2:* = getDestinationConfig(param1);
            return _loc_2 ? (getChannelIds(_loc_2)) : (getDefaultChannelIds());
        }// end function

        private static function convertToXML(param1:ConfigMap, param2:XML) : void
        {
            var _loc_3:Object = null;
            var _loc_4:Object = null;
            var _loc_5:Array = null;
            var _loc_6:int = 0;
            var _loc_7:XML = null;
            var _loc_8:XML = null;
            for (_loc_3 in param1)
            {
                
                _loc_4 = param1[_loc_3];
                if (_loc_4 is String)
                {
                    if (_loc_3 == "")
                    {
                        param2.appendChild(_loc_4);
                    }
                    else
                    {
                        param2[_loc_3] = _loc_4;
                    }
                    continue;
                }
                if (_loc_4 is ArrayCollection || _loc_4 is Array)
                {
                    if (_loc_4 is ArrayCollection)
                    {
                        _loc_5 = ArrayCollection(_loc_4).toArray();
                    }
                    else
                    {
                        _loc_5 = _loc_4 as Array;
                    }
                    _loc_6 = 0;
                    while (_loc_6 < _loc_5.length)
                    {
                        
                        _loc_7 = new XML("<" + _loc_3 + "></" + _loc_3 + ">");
                        param2.appendChild(_loc_7);
                        convertToXML(_loc_5[_loc_6] as ConfigMap, _loc_7);
                        _loc_6++;
                    }
                    continue;
                }
                _loc_8 = new XML("<" + _loc_3 + "></" + _loc_3 + ">");
                param2.appendChild(_loc_8);
                convertToXML(_loc_4 as ConfigMap, _loc_8);
            }
            return;
        }// end function

        public static function getChannel(param1:String, param2:Boolean = false) : Channel
        {
            var _loc_3:Channel = null;
            if (!param2)
            {
                if (param1 in _unclusteredChannels)
                {
                    return _unclusteredChannels[param1];
                }
                _loc_3 = createChannel(param1);
                _unclusteredChannels[param1] = _loc_3;
                return _loc_3;
                ;
            }
            if (param1 in _clusteredChannels)
            {
                return _clusteredChannels[param1];
            }
            _loc_3 = createChannel(param1);
            _clusteredChannels[param1] = _loc_3;
            return _loc_3;
        }// end function

        static function needsConfig(param1:Channel) : Boolean
        {
            var _loc_2:Array = null;
            var _loc_3:int = 0;
            var _loc_4:int = 0;
            var _loc_5:Array = null;
            var _loc_6:int = 0;
            var _loc_7:int = 0;
            if (_configFetchedChannels == null || _configFetchedChannels[param1.endpoint] == null)
            {
                _loc_2 = param1.channelSets;
                _loc_3 = _loc_2.length;
                _loc_4 = 0;
                while (_loc_4 < _loc_3)
                {
                    
                    if (getQualifiedClassName(_loc_2[_loc_4]).indexOf("Advanced") != -1)
                    {
                        return true;
                    }
                    _loc_5 = ChannelSet(_loc_2[_loc_4]).messageAgents;
                    _loc_6 = _loc_5.length;
                    _loc_7 = 0;
                    while (_loc_7 < _loc_6)
                    {
                        
                        if (MessageAgent(_loc_5[_loc_7]).needsConfig)
                        {
                            return true;
                        }
                        _loc_7++;
                    }
                    _loc_4++;
                }
            }
            return false;
        }// end function

        public static function getChannelSet(param1:String) : ChannelSet
        {
            var _loc_2:* = getDestinationConfig(param1);
            return internalGetChannelSet(_loc_2, param1);
        }// end function

        public static function get xml() : XML
        {
            if (serverConfigData == null)
            {
                serverConfigData = <services/>")("<services/>;
            }
            return serverConfigData;
        }// end function

        static function updateServerConfigData(param1:ConfigMap, param2:String = null) : void
        {
            var newServices:XML;
            var newService:XML;
            var newChannels:XMLList;
            var oldServices:XMLList;
            var oldDestinations:XMLList;
            var newDestination:XML;
            var oldService:XML;
            var oldChannels:XML;
            var serverConfig:* = param1;
            var endpoint:* = param2;
            if (serverConfig != null)
            {
                if (endpoint != null)
                {
                    if (_configFetchedChannels == null)
                    {
                        _configFetchedChannels = {};
                    }
                    _configFetchedChannels[endpoint] = true;
                }
                newServices = <services></services>")("<services></services>;
                convertToXML(serverConfig, newServices);
                xml["default-channels"] = newServices["default-channels"];
                var _loc_4:int = 0;
                var _loc_5:* = newServices..service;
                while (_loc_5 in _loc_4)
                {
                    
                    newService = _loc_5[_loc_4];
                    var _loc_7:int = 0;
                    var _loc_8:* = xml.service;
                    var _loc_6:* = new XMLList("");
                    for each (_loc_9 in _loc_8)
                    {
                        
                        var _loc_10:* = _loc_8[_loc_7];
                        with (_loc_8[_loc_7])
                        {
                            if (@id == newService.@id)
                            {
                                _loc_6[_loc_7] = _loc_9;
                            }
                        }
                    }
                    oldServices = _loc_6;
                    if (oldServices.length() != 0)
                    {
                        oldService = oldServices[0];
                        var _loc_6:int = 0;
                        var _loc_7:* = newService..destination;
                        while (_loc_7 in _loc_6)
                        {
                            
                            newDestination = _loc_7[_loc_6];
                            var _loc_9:int = 0;
                            var _loc_10:* = oldService.destination;
                            var _loc_8:* = new XMLList("");
                            for each (_loc_11 in _loc_10)
                            {
                                
                                var _loc_12:* = _loc_10[_loc_9];
                                with (_loc_10[_loc_9])
                                {
                                    if (@id == newDestination.@id)
                                    {
                                        _loc_8[_loc_9] = _loc_11;
                                    }
                                }
                            }
                            oldDestinations = _loc_8;
                            if (oldDestinations.length() != 0)
                            {
                                delete oldDestinations[0];
                            }
                            oldService.appendChild(newDestination.copy());
                        }
                        continue;
                    }
                    var _loc_6:int = 0;
                    var _loc_7:* = newService..destination;
                    while (_loc_7 in _loc_6)
                    {
                        
                        newDestination = _loc_7[_loc_6];
                        var _loc_9:int = 0;
                        var _loc_10:* = xml..destination;
                        var _loc_8:* = new XMLList("");
                        for each (_loc_11 in _loc_10)
                        {
                            
                            var _loc_12:* = _loc_10[_loc_9];
                            with (_loc_10[_loc_9])
                            {
                                if (@id == newDestination.@id)
                                {
                                    _loc_8[_loc_9] = _loc_11;
                                }
                            }
                        }
                        oldDestinations = _loc_8;
                        if (oldDestinations.length() != 0)
                        {
                            oldDestinations[0] = newDestination[0].copy();
                            var _loc_9:int = 0;
                            var _loc_10:* = newService..destination;
                            var _loc_8:* = new XMLList("");
                            for each (_loc_11 in _loc_10)
                            {
                                
                                var _loc_12:* = _loc_10[_loc_9];
                                with (_loc_10[_loc_9])
                                {
                                    if (@id == newDestination.@id)
                                    {
                                        _loc_8[_loc_9] = _loc_11;
                                    }
                                }
                            }
                            delete _loc_8[0];
                        }
                    }
                    if (newService.children().length() > 0)
                    {
                        xml.appendChild(newService);
                    }
                }
                newChannels = newServices.channels;
                if (newChannels.length() > 0)
                {
                    oldChannels = xml.channels[0];
                    if (oldChannels == null || oldChannels.length() == 0)
                    {
                        xml.appendChild(newChannels);
                    }
                }
            }
            return;
        }// end function

        private static function internalGetChannelSet(param1:XML, param2:String) : ChannelSet
        {
            var _loc_3:Array = null;
            var _loc_4:Boolean = false;
            var _loc_6:String = null;
            var _loc_7:ChannelSet = null;
            var _loc_8:int = 0;
            if (param1 == null)
            {
                _loc_3 = getDefaultChannelIds();
                if (_loc_3.length == 0)
                {
                    _loc_6 = resourceManager.getString("messaging", "noChannelForDestination", [param2]);
                    throw new InvalidDestinationError(_loc_6);
                }
                _loc_4 = false;
            }
            else
            {
                _loc_3 = getChannelIds(param1);
                _loc_4 = param1.properties.network.cluster.length() > 0 ? (true) : (false);
            }
            var _loc_5:* = _loc_3.join(",") + ":" + _loc_4;
            if (_loc_3.join(",") + ":" + _loc_4 in _channelSets)
            {
                return _channelSets[_loc_5];
            }
            _loc_7 = new channelSetFactory(_loc_3, _loc_4);
            _loc_8 = serverConfigData["flex-client"]["heartbeat-interval-millis"];
            if (_loc_8 > 0)
            {
                _loc_7.heartbeatInterval = _loc_8;
            }
            if (_loc_4)
            {
                _loc_7.initialDestinationId = param2;
            }
            _channelSets[_loc_5] = _loc_7;
            return _loc_7;
        }// end function

        private static function getDefaultChannelIds() : Array
        {
            var _loc_1:Array = [];
            var _loc_2:* = xml["default-channels"].channel;
            var _loc_3:* = _loc_2.length();
            var _loc_4:int = 0;
            while (_loc_4 < _loc_3)
            {
                
                _loc_1.push(_loc_2[_loc_4].@ref.toString());
                _loc_4++;
            }
            return _loc_1;
        }// end function

        private static function createChannel(param1:String) : Channel
        {
            var message:String;
            var channels:XMLList;
            var channelConfig:XML;
            var className:String;
            var endpoint:XMLList;
            var uri:String;
            var channel:Channel;
            var channelClass:Class;
            var channelId:* = param1;
            var _loc_4:int = 0;
            var _loc_5:* = xml.channels.channel;
            var _loc_3:* = new XMLList("");
            for each (_loc_6 in _loc_5)
            {
                
                var _loc_7:* = _loc_5[_loc_4];
                with (_loc_5[_loc_4])
                {
                    if (@id == channelId)
                    {
                        _loc_3[_loc_4] = _loc_6;
                    }
                }
            }
            channels = _loc_3;
            if (channels.length() == 0)
            {
                message = resourceManager.getString("messaging", "unknownChannelWithId", [channelId]);
                throw new InvalidChannelError(message);
            }
            channelConfig = channels[0];
            className = channelConfig.attribute(CLASS_ATTR).toString();
            endpoint = channelConfig.endpoint;
            uri = endpoint.length() > 0 ? (endpoint[0].attribute(URI_ATTR).toString()) : (null);
            channel;
            try
            {
                channelClass = getDefinitionByName(className) as Class;
                channel = new channelClass(channelId, uri);
                channel.applySettings(channelConfig);
                if (LoaderConfig.parameters != null && LoaderConfig.parameters.WSRP_ENCODED_CHANNEL != null)
                {
                    channel.url = LoaderConfig.parameters.WSRP_ENCODED_CHANNEL;
                }
            }
            catch (e:ReferenceError)
            {
                message = resourceManager.getString("messaging", "unknownChannelClass", [className]);
                throw new InvalidChannelError(message);
            }
            return channel;
        }// end function

        public static function set xml(param1:XML) : void
        {
            serverConfigData = param1;
            _channelSets = {};
            _clusteredChannels = {};
            _unclusteredChannels = {};
            return;
        }// end function

        private static function getChannelIds(param1:XML) : Array
        {
            var _loc_2:Array = [];
            var _loc_3:* = param1.channels.channel;
            var _loc_4:* = _loc_3.length();
            var _loc_5:int = 0;
            while (_loc_5 < _loc_4)
            {
                
                _loc_2.push(_loc_3[_loc_5].@ref.toString());
                _loc_5++;
            }
            return _loc_2;
        }// end function

        private static function getDestinationConfig(param1:String) : XML
        {
            var destinations:XMLList;
            var destinationCount:int;
            var destinationId:* = param1;
            var _loc_4:int = 0;
            var _loc_5:* = xml..destination;
            var _loc_3:* = new XMLList("");
            for each (_loc_6 in _loc_5)
            {
                
                var _loc_7:* = _loc_5[_loc_4];
                with (_loc_5[_loc_4])
                {
                    if (@id == destinationId)
                    {
                        _loc_3[_loc_4] = _loc_6;
                    }
                }
            }
            destinations = _loc_3;
            destinationCount = destinations.length();
            if (destinationCount == 0)
            {
                return null;
            }
            return destinations[0];
        }// end function

        static function fetchedConfig(param1:String) : Boolean
        {
            return _configFetchedChannels != null && _configFetchedChannels[param1] != null;
        }// end function

        static function channelSetMatchesDestinationConfig(param1:ChannelSet, param2:String) : Boolean
        {
            var csUris:Array;
            var csChannels:Array;
            var i:uint;
            var ids:Array;
            var dsUris:Array;
            var dsChannels:XMLList;
            var channelConfig:XML;
            var endpoint:XML;
            var dsUri:String;
            var j:uint;
            var channelSet:* = param1;
            var destination:* = param2;
            if (channelSet != null)
            {
                if (ObjectUtil.compare(channelSet.channelIds, getChannelIdList(destination)) == 0)
                {
                    return true;
                }
                csUris;
                csChannels = channelSet.channels;
                i;
                while (i < csChannels.length)
                {
                    
                    csUris.push(csChannels[i].uri);
                    i = (i + 1);
                }
                ids = getChannelIdList(destination);
                dsUris;
                j;
                while (j < ids.length)
                {
                    
                    var _loc_5:int = 0;
                    var _loc_6:* = xml.channels.channel;
                    var _loc_4:* = new XMLList("");
                    for each (_loc_7 in _loc_6)
                    {
                        
                        var _loc_8:* = _loc_6[_loc_5];
                        with (_loc_6[_loc_5])
                        {
                            if (@id == ids[j])
                            {
                                _loc_4[_loc_5] = _loc_7;
                            }
                        }
                    }
                    dsChannels = _loc_4;
                    channelConfig = dsChannels[0];
                    endpoint = channelConfig.endpoint;
                    dsUri = endpoint.length() > 0 ? (endpoint[0].attribute(URI_ATTR).toString()) : (null);
                    if (dsUri != null)
                    {
                        dsUris.push(dsUri);
                    }
                    j = (j + 1);
                }
                return ObjectUtil.compare(csUris, dsUris) == 0;
            }
            return false;
        }// end function

        public static function checkChannelConsistency(param1:String, param2:String) : void
        {
            var _loc_3:* = getChannelIdList(param1);
            var _loc_4:* = getChannelIdList(param2);
            if (ObjectUtil.compare(_loc_3, _loc_4) != 0)
            {
                throw new ArgumentError("Specified destinations are not channel consistent");
            }
            return;
        }// end function

        private static function get resourceManager() : IResourceManager
        {
            if (!_resourceManager)
            {
                _resourceManager = ResourceManager.getInstance();
            }
            return _resourceManager;
        }// end function

    }
}
