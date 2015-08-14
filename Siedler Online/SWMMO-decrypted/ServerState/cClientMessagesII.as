package ServerState
{
    import Communication.VO.*;
    import Communication.VO.Guild.*;
    import Communication.VO.Mail.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import GO.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import Interface.*;
    import Map.*;
    import Specialists.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import flash.external.*;
    import flash.net.*;
    import flash.system.*;
    import flash.utils.*;
    import mx.collections.*;
    import mx.controls.*;
    import mx.events.*;
    import mx.rpc.*;
    import mx.rpc.events.*;
    import mx.rpc.remoting.*;
    import mx.utils.*;
    import nLib.*;

    public class cClientMessagesII extends Object
    {
        private var errorRetry:int = 0;
        private var mURLVariables:URLVariables;
        private var mDebugZoneString:String = null;
        private var mURLRequest:URLRequest;
        public var mLastVisitedZoneID:int = 0;
        private var mURLLoader:URLLoader;
        private var mNextKeepAlivePing:int;
        public var mLastResultServerName:String = "";
        private var mGeneralInterface:cGeneralInterface;
        public static const RECEIVED_FROM_EXTERNAL_SERVER:Boolean = true;
        private static var mChatServerPW_string:String;
        public static var mAuthRandomClient:int = Math.floor(Math.random() * (int.MAX_VALUE - 1));
        public static var mAuthToken:String = "";
        private static var mChatServerSID_string:String;
        public static const RECEIVED_FROM_INTERNAL_SERVER:Boolean = true;
        public static const SHUTDOWN:int = 1;
        public static const OTHER_ERROR:int = 3;
        public static var mAuthUser:String = "";
        private static var mInitialized:Boolean = false;
        private static var mChatServerUsername_string:String;
        public static const AUTH_FAILED:int = 2;
        private static var mDispatcher:cCustomDispatcher = new cCustomDispatcher();

        public function cClientMessagesII(param1:cGeneralInterface)
        {
            this.mURLRequest = new URLRequest();
            this.mURLVariables = new URLVariables();
            this.mURLLoader = new URLLoader();
            this.mGeneralInterface = param1;
            return;
        }// end function

        public function ReceivedMessageFromServer(param1:dServerResponse) : void
        {
            var _loc_2:cSpecialist = null;
            var _loc_3:dResourceVO = null;
            var _loc_4:cBuilding = null;
            var _loc_5:dGameTickCommandVO = null;
            var _loc_6:dServerActionResult = null;
            var _loc_7:String = null;
            var _loc_8:String = null;
            var _loc_9:String = null;
            var _loc_10:String = null;
            var _loc_11:Array = null;
            var _loc_12:Boolean = false;
            var _loc_13:dZoneVO = null;
            var _loc_14:Array = null;
            var _loc_15:String = null;
            var _loc_16:ArrayCollection = null;
            var _loc_17:dGameTickCommandVO = null;
            var _loc_18:dGameTickCommandVO = null;
            var _loc_19:Number = NaN;
            var _loc_20:Number = NaN;
            var _loc_21:Number = NaN;
            var _loc_22:Number = NaN;
            var _loc_23:dGameTickCommandVO = null;
            var _loc_24:dServerAction = null;
            var _loc_25:dUniqueID = null;
            var _loc_26:cSpecialist = null;
            var _loc_27:cBuilding = null;
            var _loc_28:dZoneRefreshVO = null;
            var _loc_29:dZoneVO = null;
            var _loc_30:String = null;
            var _loc_31:Array = null;
            var _loc_32:dGuildVO = null;
            var _loc_33:cBuilding = null;
            var _loc_34:int = 0;
            var _loc_35:* = undefined;
            _loc_6 = param1.data as dServerActionResult;
            if (_loc_6.errorCode > ERROR_CODES.NO_ERROR)
            {
                _loc_7 = "";
                if (_loc_6.data != null)
                {
                    _loc_7 = String(_loc_6.data);
                }
                if (_loc_6.errorCode >= ERROR_CODES.SERVER_ERROR_CODES)
                {
                    if (this.mGeneralInterface.mConnectionLost == 0)
                    {
                        this.mGeneralInterface.SendClientLogMessagesToServer();
                        var _loc_36:* = this.mGeneralInterface;
                        var _loc_37:* = this.mGeneralInterface.mConnectionLost + 1;
                        _loc_36.mConnectionLost = _loc_37;
                        globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.SERVER_CALL_FAILED);
                        switch(_loc_6.errorCode)
                        {
                            case ERROR_CODES.SERVER_ZONE_INIT_FAILED:
                            {
                                LogMessageToBigBrother(new FaultEvent("SERVER ERROR CODE : " + ERROR_CODES.toString(_loc_6.errorCode) + "(" + String(_loc_6.errorCode) + ")\n" + _loc_7 + "\n"));
                                CustomAlert.show("ServerZoneInitFailed", "ServerZoneInitFailed", Alert.OK, null, this.handleRedirectClient);
                                break;
                            }
                            case ERROR_CODES.ADVENTURE_MAXIMUM_CONCURRENT_REACHED:
                            {
                                LogMessageToBigBrother(new FaultEvent("SERVER ERROR CODE : " + ERROR_CODES.toString(_loc_6.errorCode) + "(" + String(_loc_6.errorCode) + ")\n" + _loc_7 + "\n"));
                                CustomAlert.show("ConnectionLost", "ConnectionLost", Alert.OK, null, this.handleRedirectClient);
                                break;
                            }
                            case ERROR_CODES.SERVER_ZONE_CRASHED:
                            {
                                LogMessageToBigBrother(new FaultEvent("SERVER ERROR CODE : " + ERROR_CODES.toString(_loc_6.errorCode) + "(" + String(_loc_6.errorCode) + ")\n" + _loc_7 + "\n"));
                                CustomAlert.show("ServerZoneCrashed", "ServerZoneCrashed", Alert.OK, null, this.handleRedirectClient);
                                break;
                            }
                            case ERROR_CODES.SERVER_ZONE_SUPPORT_LOCK:
                            {
                                LogMessageToBigBrother(new FaultEvent("SERVER ERROR CODE : " + ERROR_CODES.toString(_loc_6.errorCode) + "(" + String(_loc_6.errorCode) + ")\n" + _loc_7 + "\n"));
                                CustomAlert.show("ServerZoneSupportLock", "ServerZoneSupportLock", Alert.OK, null, this.handleRedirectClient);
                                break;
                            }
                            case ERROR_CODES.SERVER_ZONE_BANNED:
                            {
                                LogMessageToBigBrother(new FaultEvent("SERVER ERROR CODE : " + ERROR_CODES.toString(_loc_6.errorCode) + "(" + String(_loc_6.errorCode) + ")\n" + _loc_7 + "\n"));
                                CustomAlert.show("ServerZoneBanned", "ServerZoneBanned", Alert.OK, null, this.handleRedirectClient);
                                break;
                            }
                            case ERROR_CODES.SERVER_SHUTDOWN:
                            {
                                LogMessageToBigBrother(new FaultEvent("SERVER ERROR CODE : " + ERROR_CODES.toString(_loc_6.errorCode) + "(" + String(_loc_6.errorCode) + ")\n" + _loc_7 + "\n"));
                                CustomAlert.show("ServerShutdown", "ServerShutdown", Alert.OK, null, this.handleRedirectClient);
                                break;
                            }
                            case ERROR_CODES.SERVER_PLAYER_TRIES_TO_CHEAT:
                            {
                                break;
                            }
                            case ERROR_CODES.SERVER_OVERSTRAINED:
                            {
                                LogMessageToBigBrother(new FaultEvent("SERVER ERROR CODE : " + ERROR_CODES.toString(_loc_6.errorCode) + "(" + String(_loc_6.errorCode) + ")\n" + _loc_7 + "\n"));
                                CustomAlert.show("ServerOverstrained", "ServerOverstrained", Alert.OK, null, this.handleRedirectClient);
                                break;
                            }
                            case ERROR_CODES.SERVER_NO_VALID_SESSION:
                            {
                                LogMessageToBigBrother(new FaultEvent("SERVER ERROR CODE : " + ERROR_CODES.toString(_loc_6.errorCode) + "(" + String(_loc_6.errorCode) + ")\n" + _loc_7 + "\n"));
                                CustomAlert.show("ServerNoValidSession", "ServerNoValidSession", Alert.OK, null, this.handleRedirectClient);
                                break;
                            }
                            case ERROR_CODES.SERVER_VALIDATOR_ERROR_NULL_VALUE_EXCEPTION:
                            case ERROR_CODES.SERVER_VALIDATOR_ERROR_RANGE_EXCEPTION:
                            case ERROR_CODES.SERVER_VALIDATOR_ERROR_WRONG_INSTANCE_EXCEPTION:
                            case ERROR_CODES.ADVENTURE_PLAYER_LEVEL_IS_NOT_HIGH_ENOUGH:
                            {
                                LogMessageToBigBrother(new FaultEvent("SERVER ERROR CODE : " + ERROR_CODES.toString(_loc_6.errorCode) + "(" + String(_loc_6.errorCode) + ")\n" + _loc_7 + "\n"));
                                CustomAlert.show("Server Response Error Code E:" + _loc_6.errorCode + " M:" + param1.type + " !", "Error", Alert.OK, null, this.handleRedirectClient, null, 4, false);
                                break;
                            }
                            case ERROR_CODES.NEWER_SESSION_DETECTED:
                            {
                                CustomAlert.show("ServerNoValidSession", "ServerNoValidSession", Alert.OK, null, this.handleRedirectClient);
                                break;
                            }
                            default:
                            {
                                break;
                                break;
                            }
                        }
                    }
                    return;
                }
                else
                {
                    this.mGeneralInterface.LocalLogMessageDetail("IGNORED ERROR CODE " + COMMAND.GetString(param1.type) + "  Error: " + ERROR_CODES.toString(_loc_6.errorCode));
                    return;
                }
            }
            else if (_loc_6.errorCode < ERROR_CODES.NO_ERROR && _loc_6.errorCode != ERROR_CODES.GUILD_EDIT_NOT_ALLOWED && _loc_6.errorCode != ERROR_CODES.GUILD_FOUND_NAME_EXISTS && _loc_6.errorCode != ERROR_CODES.GUILD_FOUND_TAG_EXISTS && _loc_6.errorCode != ERROR_CODES.GUILD_EDIT_NOT_ALLOWED)
            {
                _loc_8 = "";
                if (_loc_6.data != null)
                {
                    _loc_8 = String(_loc_6.data);
                }
                LogMessageToBigBrother(new FaultEvent("Guild ERROR CODE : " + ERROR_CODES.toString(_loc_6.errorCode) + "(" + String(_loc_6.errorCode) + ")\n" + _loc_8 + "\n"));
                switch(_loc_6.errorCode)
                {
                    case ERROR_CODES.GUILD_HASGUILD:
                    case ERROR_CODES.GUILD_FULL:
                    case ERROR_CODES.GUILD_JOIN_COOLDOWN:
                    case ERROR_CODES.GUILD_DISBANDED:
                    {
                        _loc_9 = ERROR_CODES.toString(_loc_6.errorCode);
                        CustomAlert.show(_loc_9, _loc_9);
                        break;
                    }
                    default:
                    {
                        CustomAlert.show("Non handled Error: " + ERROR_CODES.toString(_loc_6.errorCode), "Error", 4, null, null, null, 4, false);
                        break;
                    }
                }
            }
            switch(param1.type)
            {
                case COMMAND.GET_ZONE:
                {
                    if (_loc_6.data is dAdventureExpiredVO)
                    {
                        CustomAlert.show("AdventureZoneExpired", "AdventureZoneExpired", Alert.OK);
                        globalFlash.gui.mFriendsList.RemoveFriendById((_loc_6.data as dAdventureExpiredVO).zoneID);
                        globalFlash.gui.mLoadingZonePanel.Hide();
                        break;
                    }
                    _loc_12 = false;
                    if (this.mGeneralInterface.mCurrentPlayer.GetPlayerId() == 0)
                    {
                        _loc_12 = true;
                    }
                    this.mGeneralInterface.mServer.RefreshZone(_loc_6.data as dZoneVO, false, _loc_12, defines.STORE_ZONE_DELTA);
                    this.mGeneralInterface.mCurrentPlayerZone.ZoneSetStartZoom();
                    if (!this.mGeneralInterface.mCurrentPlayer.mIsPlayerZone || this.mGeneralInterface.mCurrentPlayer.mIsAdventureZone)
                    {
                        globalFlash.gui.mInfoBar.Hide();
                        globalFlash.gui.mBuildQueue.Hide();
                        globalFlash.gui.mHintPointer.Hide();
                    }
                    else
                    {
                        globalFlash.gui.mInfoBar.Show();
                    }
                    this.InitChat();
                    break;
                }
                case COMMAND.GET_ZONE_ON_THE_FLY:
                {
                    this.mGeneralInterface.mServer.RefreshZone(_loc_6.data as dZoneVO, true, false, defines.STORE_ZONE_DELTA);
                    break;
                }
                case COMMAND.GET_ASCIIZONE:
                {
                    this.mGeneralInterface.mCurrentAsciiZone = _loc_6.data as String;
                    gMisc.MessageBox("Press . to save current Zone to XML File");
                    break;
                }
                case COMMAND.GRAB_FOREIGN_ZONE:
                {
                    _loc_13 = _loc_6.data as dZoneVO;
                    this.mGeneralInterface.mServer.RefreshZone(_loc_13, true, false, defines.STORE_ZONE_DELTA);
                    break;
                }
                case COMMAND.INIT_CHAT:
                {
                    this.InitChat();
                }
                case COMMAND.SEARCH_PLAYER_LIST:
                {
                    _loc_14 = [];
                    if (_loc_6.data)
                    {
                        _loc_14 = _loc_6.data.players.toArray().sortOn("username", Array.CASEINSENSITIVE);
                    }
                    globalFlash.gui.mAddFriendsPanel.SetData(_loc_14);
                    break;
                }
                case COMMAND.ADD_FRIEND:
                {
                    if (_loc_6.data)
                    {
                        globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.FRIEND_REQUEST_SENT);
                    }
                    else
                    {
                        globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.FRIEND_REQUEST_COOLDOWN);
                    }
                    break;
                }
                case COMMAND.SEARCH_RECIEPIENT_LIST:
                {
                    _loc_14 = [];
                    if (_loc_6.data)
                    {
                        _loc_14 = _loc_6.data.players.toArray().sortOn("username", Array.CASEINSENSITIVE);
                    }
                    globalFlash.gui.mMailWindow.SetReciepientList(_loc_14);
                    break;
                }
                case COMMAND.GET_FRIEND_LIST:
                {
                    trace("-----------------------------handle getfriendlist-------------------------------");
                    _loc_15 = String(_loc_6.data);
                    if (_loc_6.data == null || _loc_6.data.players == null)
                    {
                        globalFlash.gui.mFriendsList.SetData([]);
                    }
                    else
                    {
                        globalFlash.gui.mFriendsList.SetData(_loc_6.data.players.toArray());
                    }
                    this.InitChat();
                    break;
                }
                case COMMAND.GET_UPDATES:
                {
                    this.mGeneralInterface.mGetUpdatesSend = false;
                    this.handleGetUpdates(_loc_6.data as ArrayCollection);
                    break;
                }
                case COMMAND.SPEEDMODE:
                case COMMAND.BUY_SHOP_ITEM:
                case COMMAND.STOP_GAME:
                case COMMAND.SET_BUILDING_IN_GAME:
                case COMMAND.SET_BUILDING_BY_BUFF:
                case COMMAND.MOVE_BUILDING:
                case COMMAND.BUILDQUEUE_MOVE_UP:
                case COMMAND.BUILDQUEUE_MOVE_DOWN:
                case COMMAND.BUILDQUEUE_REMOVE:
                case COMMAND.DESTRUCT_BUILDING:
                case COMMAND.UPGRADE_BUILDING:
                case COMMAND.STOP_PRODUCTION:
                case COMMAND.APPLY_BUFF:
                case COMMAND.REMOVE_BUFF:
                case COMMAND.START_TIMED_PRODUCTION:
                case COMMAND.BUY_SPECIALIST:
                case COMMAND.ACCEPT_TRADE:
                case COMMAND.ACCEPT_LOOT:
                case COMMAND.BUY_ONE_CLICK_SHOP_ITEM:
                case COMMAND.RESOURCES_CHEAT:
                case COMMAND.SET_CITY_LEVEL:
                case COMMAND.INITIATE_TRADE:
                case COMMAND.INVITE_TO_ADVENTURE:
                case COMMAND.INITIATE_ITEM_TRADE:
                case COMMAND.ACCEPT_ITEM_TRADE:
                case COMMAND.ADD_ITEM_TRADE_RESOURCE:
                case COMMAND.RETREAT:
                case COMMAND.RAISE_ARMY:
                case COMMAND.APPLY_LOOTTABLE_BUFF:
                {
                    if (_loc_6.data != null)
                    {
                        this.mGeneralInterface.AddGameTickCommand(_loc_6.data as dGameTickCommandVO);
                    }
                    break;
                }
                case COMMAND.QUEST_TRIGGER:
                {
                    this.handleGetUpdates(_loc_6.data as ArrayCollection);
                    break;
                }
                case COMMAND.GOD_MODE_CHEAT:
                {
                    if (_loc_6.data != null)
                    {
                        _loc_16 = _loc_6.data as ArrayCollection;
                        if (_loc_16 != null)
                        {
                            for each (_loc_17 in _loc_16)
                            {
                                
                                this.mGeneralInterface.AddGameTickCommand(_loc_17);
                            }
                        }
                    }
                    break;
                }
                case COMMAND.SET_TASK:
                {
                    if (_loc_6.data != null)
                    {
                        _loc_18 = _loc_6.data as dGameTickCommandVO;
                        this.mGeneralInterface.AddGameTickCommand(_loc_18);
                        _loc_19 = this.mGeneralInterface.GetClientTime();
                        _loc_20 = _loc_18.time - _loc_19;
                        _loc_21 = _loc_20;
                        _loc_22 = _loc_21 / this.mGeneralInterface.mGlobalTimeScale;
                        _loc_22 = _loc_22;
                        if (_loc_22 > 2500)
                        {
                            _loc_23 = _loc_6.data as dGameTickCommandVO;
                            _loc_24 = _loc_23.data as dServerAction;
                            _loc_25 = _loc_24.data as dUniqueID;
                            if (_loc_25 != null)
                            {
                                _loc_26 = this.mGeneralInterface.mCurrentPlayerZone.getSpecialist(_loc_18.playerID, _loc_25);
                                if (_loc_26 != null)
                                {
                                    _loc_27 = _loc_26.GetGarrison();
                                    if (_loc_27 != null)
                                    {
                                        _loc_27.mGarrissonWaitForCommand = true;
                                    }
                                }
                            }
                        }
                    }
                    break;
                }
                case COMMAND.SPOOLTIME:
                {
                    if (_loc_6.data != null)
                    {
                        _loc_28 = _loc_6.data as dZoneRefreshVO;
                        this.mGeneralInterface.LocalLogMessage(_loc_28.resultString);
                        this.mGeneralInterface.mServer.RefreshZone(_loc_28.zoneVO, true, false, defines.STORE_ZONE_DELTA);
                    }
                    break;
                }
                case COMMAND.GET_DEBUG_ZONE:
                {
                    _loc_29 = _loc_6.data as dZoneVO;
                    this.mDebugZoneString = _loc_29.toString();
                    Alert.show("Save Server Zone To File", "Info", 4, null, this.GetDebugZoneCloseHandler);
                    break;
                }
                case COMMAND.SESSION_AUTH:
                {
                    _loc_30 = String(_loc_6.data);
                    _loc_31 = _loc_30.split("|");
                    mChatServerSID_string = _loc_31[0];
                    mChatServerUsername_string = _loc_31[1];
                    mChatServerPW_string = _loc_31[2];
                    this.SendMessagetoServer(COMMAND.GET_FRIEND_LIST, this.mGeneralInterface.mCurrentViewedZoneID, null);
                    break;
                }
                case COMMAND.GET_MAIL_HEADERS:
                {
                    globalFlash.gui.mMailWindow.SetHeaders(_loc_6.data as ArrayCollection);
                    break;
                }
                case COMMAND.GET_MAIL:
                {
                    gMisc.ConsoleOut((_loc_6.data as dMailVO).toString());
                    globalFlash.gui.mMailWindow.SetMail(_loc_6.data as dMailVO);
                    break;
                }
                case COMMAND.GUILD_GET_OWN:
                {
                    _loc_32 = _loc_6.data as dGuildVO;
                    this.mGeneralInterface.SetCurrentPlayerGuild(_loc_32);
                    if (_loc_32 != null)
                    {
                        globalFlash.gui.mChatPanel.joinGuildChannel(_loc_32);
                        if (_loc_32.playerPermissions.OfficersChannel())
                        {
                            globalFlash.gui.mChatPanel.joinOfficersChannel(_loc_32);
                        }
                        _loc_33 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetGuildHouse();
                        if (_loc_33)
                        {
                            _loc_34 = 0;
                            for (_loc_35 in global.guildUpgradeLevels)
                            {
                                
                                if (_loc_32.maxSize >= global.guildUpgradeLevels[_loc_35])
                                {
                                    _loc_34 = _loc_35;
                                    continue;
                                }
                                break;
                            }
                            _loc_33.SetUpgradeLevel(_loc_34);
                        }
                    }
                    else
                    {
                        _loc_33 = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetGuildHouse();
                        if (_loc_33)
                        {
                            _loc_33.SetUpgradeLevel(1);
                        }
                    }
                    break;
                }
                case COMMAND.GUILD_GET:
                {
                    _loc_32 = _loc_6.data as dGuildVO;
                    globalFlash.gui.mGuildWindow.SetGuild(_loc_32);
                    break;
                }
                case COMMAND.GUILD_GET_HEADERS:
                {
                    globalFlash.gui.mGuildWindow.SetHeaders(_loc_6.data as dGuildHeadersListVO);
                    break;
                }
                case COMMAND.GUILD_FOUND_VALIDATE_NAME:
                {
                    globalFlash.gui.mFoundGuildPanel.ValidateName(_loc_6.data as String, _loc_6.errorCode);
                    break;
                }
                case COMMAND.GUILD_FOUND_VALIDATE_TAG:
                {
                    globalFlash.gui.mFoundGuildPanel.ValidateTag(_loc_6.data as String, _loc_6.errorCode);
                    break;
                }
                case COMMAND.GUILD_FOUND:
                {
                    this.mGeneralInterface.mClientMessages.SendMessagetoServer(COMMAND.GUILD_GET_OWN, this.mGeneralInterface.mCurrentPlayer.GetHomeZoneId(), null);
                    break;
                }
                case COMMAND.GUILD_EDIT_VALUE:
                {
                    if (_loc_6.errorCode == ERROR_CODES.GUILD_EDIT_NOT_ALLOWED)
                    {
                        CustomAlert.show(ERROR_CODES.toString(_loc_6.errorCode), ERROR_CODES.toString(_loc_6.errorCode));
                        globalFlash.gui.mGuildWindow.ResetValue(_loc_6.data as dGuildEditValueVO);
                    }
                    break;
                }
                case COMMAND.RECONNECT_TO_CHAT:
                {
                    _loc_10 = String(_loc_6.data);
                    _loc_11 = _loc_10.split("|");
                    mChatServerSID_string = _loc_11[0];
                    mChatServerUsername_string = _loc_11[1];
                    mChatServerPW_string = _loc_11[2];
                    globalFlash.gui.mChatPanel.reEstablishConnection(mChatServerUsername_string, mChatServerPW_string);
                    break;
                }
                case COMMAND.SET_FAKE_DATE:
                {
                    this.mGeneralInterface.mServerDate = _loc_6.data as dClientDateVO;
                    break;
                }
                case COMMAND.INSERT_ZONE_EVENT_LOG:
                {
                    break;
                }
                case COMMAND.INIT_CLIENT_DONE:
                case COMMAND.PLAYER_ACTION:
                case COMMAND.MARK_MAIL_AS_READ:
                {
                    break;
                }
                default:
                {
                    if (this.mGeneralInterface.mLog.isWarnEnabled(LOG_TYPE.EVENT))
                    {
                        this.mGeneralInterface.mLog.logWarn(LOG_TYPE.EVENT, "Unknown ResponseType from server: " + param1.type);
                    }
                    break;
                    break;
                }
            }
            return;
        }// end function

        public function InitializeServerCommunication() : void
        {
            var _loc_1:String = null;
            var _loc_2:Array = null;
            var _loc_3:String = null;
            if (defines.USE_EXTERNAL_SERVER)
            {
                if (defines.USE_PHP)
                {
                    _loc_1 = ExternalInterface.call("function getCookie(){return document.cookie;}");
                    _loc_1 = _loc_1.replace(" ", "");
                    _loc_2 = _loc_1.split(";");
                    for each (_loc_3 in _loc_2)
                    {
                        
                        if (_loc_3.indexOf("dsoAuthToken=") != -1)
                        {
                            mAuthToken = StringUtil.trim(_loc_3).substr(13);
                            continue;
                        }
                        if (_loc_3.indexOf("dsoAuthUser=") != -1)
                        {
                            mAuthUser = StringUtil.trim(_loc_3).substr(12);
                        }
                    }
                }
                if (!defines.USE_BIG_BROTHER)
                {
                    this.SendMessagetoServer(COMMAND.SESSION_AUTH, this.mGeneralInterface.mCurrentViewedZoneID, mAuthToken);
                    mInitialized = true;
                }
                else
                {
                    this.mURLRequest.url = defines.BIG_BROTHER_URL + "authenticate";
                    this.mURLRequest.method = URLRequestMethod.POST;
                    this.mURLVariables.DSOAUTHTOKEN = mAuthToken;
                    this.mURLVariables.DSOAUTHUSER = mAuthUser;
                    this.mURLRequest.data = this.mURLVariables;
                    this.mURLLoader.dataFormat = URLLoaderDataFormat.TEXT;
                    this.ConfigureListeners(this.mURLLoader);
                    this.mURLLoader.load(this.mURLRequest);
                }
            }
            else
            {
                mInitialized = true;
                this.SendMessagetoServer(COMMAND.INIT_SERVER, this.mGeneralInterface.mCurrentViewedZoneID, null);
            }
            return;
        }// end function

        public function SendMessagetoServerII(param1:int, param2:int, param3:Object, param4:String) : void
        {
            var _loc_6:AsyncToken = null;
            var _loc_7:RemoteObject = null;
            var _loc_8:RemoteObject = null;
            var _loc_9:RemoteObject = null;
            var _loc_10:RemoteObject = null;
            var _loc_11:RemoteObject = null;
            var _loc_12:RemoteObject = null;
            var _loc_5:* = new dServerCall();
            new dServerCall().type = param1;
            _loc_5.data = param3;
            _loc_5.zoneID = param2;
            _loc_5.dsoAuthToken = mAuthToken;
            _loc_5.dsoAuthUser = mAuthUser;
            _loc_5.dsoAuthRandomClientID = mAuthRandomClient;
            if (this.mGeneralInterface.mConnectionLost != 0)
            {
                if (param1 != COMMAND.CLIENT_LOG)
                {
                    gMisc.ConsoleOut("Connection Lost: Message is removed " + _loc_5 + " Type: " + param1 + " Object: " + param3);
                    return;
                }
            }
            if (!defines.USE_EXTERNAL_SERVER)
            {
                this.mGeneralInterface.mServerSimulation.SendSimulatedClientMessage(_loc_5);
            }
            if (defines.USE_EXTERNAL_SERVER)
            {
                this.mGeneralInterface.LocalLogMessageDetail("send: pid=" + this.mGeneralInterface.mHomePlayer.GetPlayerId() + " ClientTime: " + this.mGeneralInterface.GetClientTime() / 1000 + " type=" + param1 + " Object=" + param3);
                cConnectionManager.GetInstance().CreateServices(param4);
                _loc_7 = cConnectionManager.GetInstance().mRemoteService;
                _loc_8 = cConnectionManager.GetInstance().mMailService;
                _loc_9 = cConnectionManager.GetInstance().mPlayerService;
                _loc_10 = cConnectionManager.GetInstance().mMailService;
                _loc_11 = cConnectionManager.GetInstance().mLogService;
                _loc_12 = cConnectionManager.GetInstance().mGuildService;
                switch(param1)
                {
                    case COMMAND.GET_FRIEND_LIST:
                    {
                        _loc_6 = _loc_9.GetFriends(_loc_5);
                        break;
                    }
                    case COMMAND.ADD_FRIEND:
                    {
                        _loc_6 = _loc_9.AddFriend(_loc_5);
                        break;
                    }
                    case COMMAND.ACCEPT_FRIEND_REQUEST:
                    {
                        _loc_6 = _loc_9.AcceptFriendRequest(_loc_5);
                        break;
                    }
                    case COMMAND.DECLINE_FRIEND_REQUEST:
                    {
                        _loc_6 = _loc_9.DeclineFriendRequest(_loc_5);
                        break;
                    }
                    case COMMAND.REMOVE_FRIEND:
                    {
                        _loc_6 = _loc_9.RemoveFriend(_loc_5);
                        break;
                    }
                    case COMMAND.SEARCH_PLAYER_LIST:
                    case COMMAND.SEARCH_RECIEPIENT_LIST:
                    {
                        _loc_6 = _loc_9.SearchPlayerListByName(_loc_5);
                        break;
                    }
                    case COMMAND.GET_PLAYER_LIST:
                    {
                        _loc_6 = _loc_9.GetPlayerList(_loc_5);
                        break;
                    }
                    case COMMAND.SESSION_AUTH:
                    {
                        _loc_6 = _loc_7.Authenticate(_loc_5);
                        break;
                    }
                    case COMMAND.RECONNECT_TO_CHAT:
                    {
                        _loc_6 = _loc_7.ReconnectToChat(_loc_5);
                        break;
                    }
                    case COMMAND.GET_MAIL_HEADERS:
                    {
                        _loc_6 = _loc_10.GetHeaders(_loc_5);
                        break;
                    }
                    case COMMAND.GET_MAIL:
                    {
                        _loc_6 = _loc_10.GetMail(_loc_5);
                        break;
                    }
                    case COMMAND.DELETE_MAIL:
                    {
                        _loc_6 = _loc_10.DeleteMail(_loc_5);
                        break;
                    }
                    case COMMAND.SEND_MAIL:
                    {
                        _loc_6 = _loc_10.SendMail(_loc_5);
                        break;
                    }
                    case COMMAND.MARK_MAIL_AS_READ:
                    {
                        _loc_6 = _loc_10.MarkMailAsRead(_loc_5);
                        break;
                    }
                    case COMMAND.CLIENT_LOG:
                    {
                        _loc_6 = _loc_11.Log(_loc_5);
                        break;
                    }
                    case COMMAND.GUILD_GET:
                    {
                        _loc_6 = _loc_12.GetGuild(_loc_5);
                        break;
                    }
                    case COMMAND.GUILD_GET_OWN:
                    {
                        _loc_6 = _loc_12.GetGuildOwn(_loc_5);
                        break;
                    }
                    case COMMAND.GUILD_GET_HEADERS:
                    {
                        _loc_6 = _loc_12.GetGuildHeaders(_loc_5);
                        break;
                    }
                    case COMMAND.GUILD_FOUND:
                    {
                        _loc_6 = _loc_12.FoundGuild(_loc_5);
                        break;
                    }
                    case COMMAND.GUILD_FOUND_VALIDATE_NAME:
                    {
                        _loc_6 = _loc_12.Found_ValidateGuildName(_loc_5);
                        break;
                    }
                    case COMMAND.GUILD_FOUND_VALIDATE_TAG:
                    {
                        _loc_6 = _loc_12.Found_ValidateGuildTag(_loc_5);
                        break;
                    }
                    case COMMAND.GUILD_EDIT_VALUE:
                    {
                        _loc_6 = _loc_12.EditValue(_loc_5);
                        break;
                    }
                    case COMMAND.GUILD_INVITE:
                    {
                        _loc_6 = _loc_12.InviteToGuild(_loc_5);
                        break;
                    }
                    case COMMAND.GUILD_JOIN_REQUEST:
                    {
                        _loc_6 = _loc_12.JoinRequest(_loc_5);
                        break;
                    }
                    case COMMAND.GUILD_LEAVE:
                    {
                        _loc_6 = _loc_12.LeaveGuild(_loc_5);
                        break;
                    }
                    case COMMAND.GUILD_INVITE_ACCEPT:
                    {
                        _loc_6 = _loc_12.InviteAccept(_loc_5);
                        break;
                    }
                    case COMMAND.GUILD_INVITE_DECLINE:
                    {
                        _loc_6 = _loc_12.InviteDecline(_loc_5);
                        break;
                    }
                    case COMMAND.GUILD_KICK:
                    {
                        _loc_6 = _loc_12.KickMember(_loc_5);
                        break;
                    }
                    case COMMAND.GUILD_SEND_MAIL:
                    {
                        _loc_6 = _loc_12.SendGuildMail(_loc_5);
                        break;
                    }
                    default:
                    {
                        _loc_6 = _loc_7.ExecuteServerCall(_loc_5);
                        break;
                        break;
                    }
                }
                _loc_6.addResponder(new AsyncResponder(this.ResultHandler, this.FaultHandler));
            }
            return;
        }// end function

        private function IoErrorHandler(event:IOErrorEvent) : void
        {
            if (this.errorRetry < cBigBrotherMessage.ERROR_RETRIES)
            {
                var _loc_2:String = this;
                var _loc_3:* = this.errorRetry + 1;
                _loc_2.errorRetry = _loc_3;
                this.mURLLoader.load(this.mURLRequest);
            }
            else
            {
                this.FaultHandler(new FaultEvent("IoError on BigBrother Authenticate : " + event.type + " " + event.text));
            }
            return;
        }// end function

        private function handleGetUpdates(param1:ArrayCollection) : void
        {
            var specialist:cSpecialist;
            var guildVO:dGuildVO;
            var updateVO:Object;
            var questUpdateVO:dQuestUpdateVO;
            var serverClientUpdateVO:dServerClientUpdateVO;
            var serverTime:Number;
            var synchronizeTime:Number;
            var adventurePlayerVO:dAdventurePlayerVO;
            var foundPlayer:Boolean;
            var changedPlayer:Boolean;
            var playerListItemVO:dPlayerListItemVO;
            var playerIdx:int;
            var existingAdventurePlayerVO:dAdventurePlayerListItemVO;
            var newAdventurePlayerListItemVO:dAdventurePlayerListItemVO;
            var owner:dAdventurePlayerListItemVO;
            var player:dAdventurePlayerListItemVO;
            var playerVO:dPlayerVO;
            var playerData:cPlayerData;
            var resources:cResources;
            var travellingSpecialistArivalVO:dTravellingSpecialistArivalVO;
            var zoneRefreshVO:dZoneRefreshVO;
            var resultStringList:Array;
            var str:String;
            var newMailCountVO:dNewMailCountVO;
            var findTreasureResponseVO:dFindTreasureResponseVO;
            var battleResultVO:dBattleResultVO;
            var findEventZoneResponseVO:dFindEventZoneResponseVO;
            var specialists:Vector.<cSpecialist>;
            var specialistIdx:int;
            var explorerSearchResponseVO:dFindDepositResponseVO;
            var specialistFoundDepositVO:dFoundDepositVO;
            var deposit:cDeposit;
            var findDepositTask:cSpecialistTask_FindDeposit;
            var exploreSectorResponseVO:dExploreSectorResponseVO;
            var exploredSectorVO:dExploredSectorVO;
            var sector:cSector;
            var exploreSectorTask:cSpecialistTask_ExploreSector;
            var alertMessageVO:dAlertMessageVO;
            var motdChanged:Boolean;
            var guildBuilding:cBuilding;
            var upgradelevel:int;
            var k:*;
            var newPlayer:cPlayerData;
            var oldPlayer:cPlayerData;
            var found:Boolean;
            var i:int;
            var _updateVOs:* = param1;
            var playerList:* = new Vector.<cPlayerData>;
            var updateZoneID:int;
            var playerListUpdated:Boolean;
            var _loc_3:int = 0;
            var _loc_4:* = _updateVOs;
            while (_loc_4 in _loc_3)
            {
                
                updateVO = _loc_4[_loc_3];
                if (updateVO is dQuestUpdateVO)
                {
                    questUpdateVO = updateVO as dQuestUpdateVO;
                    this.mGeneralInterface.mQuestClientCallbacks.ReceivedMessagesFromServer(questUpdateVO);
                    continue;
                }
                if (updateVO is dServerClientUpdateVO)
                {
                    serverClientUpdateVO = updateVO as dServerClientUpdateVO;
                    serverTime = serverClientUpdateVO.serverClientSynchronizationTime;
                    updateZoneID = serverClientUpdateVO.zoneId;
                    if (updateZoneID != this.mGeneralInterface.mHomePlayer.GetPlayerId())
                    {
                        this.mGeneralInterface.LocalLogMessage("UpdateVO is from different Zone Client: " + this.mGeneralInterface.mHomePlayer.GetPlayerId() + " Server; " + updateZoneID);
                        break;
                    }
                    synchronizeTime = serverTime - this.mGeneralInterface.GetClientTime();
                    if (Math.abs(synchronizeTime) > 10)
                    {
                        if (Math.abs(synchronizeTime) > 50000)
                        {
                            this.mGeneralInterface.mSynchronisationErrorBitField = this.mGeneralInterface.mSynchronisationErrorBitField | cGeneralInterface.SYNCHRONISATION_ERROR_SERVER_CLIENT_TIME_MISMATCH;
                            this.mGeneralInterface.LocalLogMessage("UpdateVO Time SynchronizationError Client: " + this.mGeneralInterface.GetClientTime() + " Server; " + serverTime);
                        }
                        else
                        {
                            this.mGeneralInterface.mSynchronizetime = synchronizeTime;
                        }
                    }
                    continue;
                }
                if (updateVO is dAdventureExpiredVO)
                {
                    CustomAlert.show("AdventureZoneJustExpired", "AdventureZoneJustExpired", Alert.OK, null, function () : void
            {
                globalFlash.gui.mLoadingZonePanel.Show();
                global.ui.mClientMessages.SendMessagetoServer(COMMAND.GET_ZONE, mGeneralInterface.mCurrentPlayer.GetPlayerId(), false);
                return;
            }// end function
            );
                    continue;
                }
                if (updateVO is dAdventurePlayerVO)
                {
                    adventurePlayerVO = updateVO as dAdventurePlayerVO;
                    foundPlayer;
                    changedPlayer;
                    playerListItemVO = globalFlash.gui.mFriendsList.GetFriendById(adventurePlayerVO.adventureID);
                    playerIdx;
                    while (playerIdx < playerListItemVO.adventureVO.players.length && !foundPlayer)
                    {
                        
                        existingAdventurePlayerVO = playerListItemVO.adventureVO.players[playerIdx];
                        if (existingAdventurePlayerVO.id == adventurePlayerVO.playerID)
                        {
                            foundPlayer;
                            if (existingAdventurePlayerVO.status != adventurePlayerVO.status)
                            {
                                existingAdventurePlayerVO.status = adventurePlayerVO.status;
                                if (existingAdventurePlayerVO.status == ADVENTURE_INVITATION_STATUS.DECLINED)
                                {
                                    playerListItemVO.adventureVO.players.removeItemAt(playerIdx);
                                }
                                changedPlayer;
                            }
                        }
                        playerIdx = (playerIdx + 1);
                    }
                    if (!foundPlayer && adventurePlayerVO.status != ADVENTURE_INVITATION_STATUS.DECLINED)
                    {
                        newAdventurePlayerListItemVO = new dAdventurePlayerListItemVO().InitFromAdventurePlayerVO(adventurePlayerVO);
                        playerListItemVO.adventureVO.players.addItem(newAdventurePlayerListItemVO);
                        changedPlayer;
                    }
                    if (changedPlayer)
                    {
                        switch(adventurePlayerVO.status)
                        {
                            case ADVENTURE_INVITATION_STATUS.PENDING:
                            {
                                var _loc_5:int = 0;
                                var _loc_6:* = playerListItemVO.adventureVO.players;
                                while (_loc_6 in _loc_5)
                                {
                                    
                                    player = _loc_6[_loc_5];
                                    if (player.id == playerListItemVO.adventureVO.ownerPlayerID)
                                    {
                                        owner = player;
                                    }
                                }
                                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.ADVENTURE_PLAYER_WAS_INVITED, {playerName:adventurePlayerVO.playerName, adventureName:playerListItemVO.adventureVO.adventureName, owner:owner.username});
                                break;
                            }
                            case ADVENTURE_INVITATION_STATUS.ACCEPTED:
                            {
                                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.ADVENTURE_PLAYER_ACCEPTED_INVITATION, {playerName:adventurePlayerVO.playerName, adventureName:playerListItemVO.adventureVO.adventureName});
                                break;
                            }
                            case ADVENTURE_INVITATION_STATUS.DECLINED:
                            {
                                globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.ADVENTURE_PLAYER_DECLINED_INVITATION, {playerName:adventurePlayerVO.playerName, adventureName:playerListItemVO.adventureVO.adventureName});
                                break;
                            }
                            default:
                            {
                                break;
                            }
                        }
                    }
                    continue;
                }
                if (updateVO is dPlayerVO)
                {
                    if (!playerListUpdated)
                    {
                        playerListUpdated;
                        playerList.push(this.mGeneralInterface.mCurrentPlayer);
                    }
                    playerVO = updateVO as dPlayerVO;
                    if (playerVO.userID != 0)
                    {
                        playerData = new cPlayerData(this.mGeneralInterface);
                        resources = this.mGeneralInterface.mCurrentPlayerZone.GetResources(playerData);
                        this.mGeneralInterface.mServer.CreatePlayerFromPlayerVO(playerData, playerVO);
                        playerList.push(playerData);
                    }
                    continue;
                }
                if (updateVO is dGameTickCommandVO)
                {
                    this.mGeneralInterface.AddGameTickCommand(updateVO as dGameTickCommandVO);
                    continue;
                }
                if (updateVO is dPlayerListItemVO)
                {
                    globalFlash.gui.mFriendsList.AddConfirmedFriend(updateVO as dPlayerListItemVO);
                    continue;
                }
                if (updateVO is dRemovedFriendVO)
                {
                    globalFlash.gui.mFriendsList.RemoveFriendById((updateVO as dRemovedFriendVO).removedFriendID);
                    continue;
                }
                if (updateVO is dTravellingSpecialistArivalVO)
                {
                    travellingSpecialistArivalVO = updateVO as dTravellingSpecialistArivalVO;
                    specialist = cSpecialist.CreateSpecialistFromVO(this.mGeneralInterface, travellingSpecialistArivalVO.specialistVO, false);
                    this.mGeneralInterface.mCurrentPlayerZone.GetSpecialists_vector().push(specialist);
                    continue;
                }
                if (updateVO is dRemovedFriendVO)
                {
                    globalFlash.gui.mFriendsList.RemoveFriendById((updateVO as dRemovedFriendVO).friendRemoverID);
                    continue;
                }
                if (updateVO is dZoneRefreshVO)
                {
                    zoneRefreshVO = updateVO as dZoneRefreshVO;
                    this.mGeneralInterface.mServer.RefreshZone(zoneRefreshVO.zoneVO, true, false, defines.STORE_ZONE_DELTA);
                    if ((zoneRefreshVO.refreshReason & cGeneralInterface.SYNCHRONISATION_ERROR_MISSED_GAMETICK) != 0 || (zoneRefreshVO.refreshReason >> 16 & cGeneralInterface.SYNCHRONISATION_ERROR_MISSED_GAMETICK) != 0)
                    {
                        if (this.mGeneralInterface.mLog.isInfoEnabled(LOG_TYPE.SYNC))
                        {
                            this.mGeneralInterface.mLog.logInfo(LOG_TYPE.SYNC, "Zone refresh: Gametick missed on client time " + this.mGeneralInterface.GetClientTime() + ": set post process time to " + zoneRefreshVO.gameTickPostProcessTime);
                        }
                        this.mGeneralInterface.GameTickSystemPostProcessTime = zoneRefreshVO.gameTickPostProcessTime;
                    }
                    else if (this.mGeneralInterface.mLog.isInfoEnabled(LOG_TYPE.SYNC))
                    {
                        this.mGeneralInterface.mLog.logInfo(LOG_TYPE.SYNC, "Zone Refresh: Synchronisation error on client time " + this.mGeneralInterface.GetClientTime() + " with reason " + zoneRefreshVO.refreshReason);
                        if (zoneRefreshVO.resultString)
                        {
                            resultStringList = zoneRefreshVO.resultString.split("\n");
                            var _loc_5:int = 0;
                            var _loc_6:* = resultStringList;
                            while (_loc_6 in _loc_5)
                            {
                                
                                str = _loc_6[_loc_5];
                                this.mGeneralInterface.mLog.logInfo(LOG_TYPE.SYNC, str);
                            }
                        }
                    }
                    continue;
                }
                if (updateVO is dNewMailCountVO)
                {
                    newMailCountVO = updateVO as dNewMailCountVO;
                    if (newMailCountVO.count > 0)
                    {
                        globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.NEW_MAIL);
                        globalFlash.gui.mAvatar.ShowMailNotification();
                    }
                    continue;
                }
                if (updateVO is dMailVO)
                {
                    gMisc.ConsoleOut((updateVO as dMailVO).toString());
                    globalFlash.gui.mMailWindow.PutMailInCache(updateVO as dMailVO);
                    continue;
                }
                if (updateVO is dFindTreasureResponseVO)
                {
                    findTreasureResponseVO = updateVO as dFindTreasureResponseVO;
                    specialist = this.mGeneralInterface.mCurrentPlayerZone.getSpecialist(findTreasureResponseVO.specialistPlayerID, findTreasureResponseVO.specialistUniqueId);
                    if (specialist != null && specialist.GetTask() != null && specialist.GetTask() is cSpecialistTask_FindTreasure)
                    {
                        (specialist.GetTask() as cSpecialistTask_FindTreasure).SetFindTreasureResponseVO(findTreasureResponseVO);
                    }
                    continue;
                }
                if (updateVO is dBattleResultVO)
                {
                    battleResultVO = updateVO as dBattleResultVO;
                    specialist = this.mGeneralInterface.mCurrentPlayerZone.getSpecialist(battleResultVO.specialistPlayerID, battleResultVO.specialistUniqueID);
                    if (specialist != null && specialist.GetTask() != null && specialist.GetTask() is cSpecialistTask_AttackBuilding)
                    {
                        (specialist.GetTask() as cSpecialistTask_AttackBuilding).SetBattleResultVO(battleResultVO);
                    }
                    continue;
                }
                if (updateVO is dFindEventZoneResponseVO)
                {
                    findEventZoneResponseVO = updateVO as dFindEventZoneResponseVO;
                    specialists = this.mGeneralInterface.mCurrentPlayerZone.GetSpecialists_vector();
                    specialistIdx;
                    while (specialistIdx < specialists.length)
                    {
                        
                        specialist = specialists[specialistIdx] as cSpecialist;
                        if (specialist.GetUniqueID().equals(findEventZoneResponseVO.specialistUniqueId))
                        {
                            if (specialist.GetTask() != null && specialist.GetTask() is cSpecialistTask_FindEventZone)
                            {
                                gMisc.ConsoleOut("Applying " + findEventZoneResponseVO + " to " + specialist);
                                (specialist.GetTask() as cSpecialistTask_FindEventZone).SetFindEventZoneResponseVO(findEventZoneResponseVO);
                            }
                            else
                            {
                                gMisc.ConsoleOut("Could not apply " + updateVO + " to " + specialist + " because he has no task or it is not a \'Find Event Zone\' task!");
                            }
                        }
                        specialistIdx = (specialistIdx + 1);
                    }
                    continue;
                }
                if (updateVO is dFindDepositResponseVO)
                {
                    specialistIdx;
                    explorerSearchResponseVO = updateVO as dFindDepositResponseVO;
                    var _loc_5:int = 0;
                    var _loc_6:* = explorerSearchResponseVO.foundDeposits_vector;
                    while (_loc_6 in _loc_5)
                    {
                        
                        specialistFoundDepositVO = _loc_6[_loc_5];
                        specialists = this.mGeneralInterface.mCurrentPlayerZone.GetSpecialists_vector();
                        specialistIdx;
                        while (specialistIdx < specialists.length)
                        {
                            
                            specialist = specialists[specialistIdx] as cSpecialist;
                            if (specialist.GetUniqueID().equals(specialistFoundDepositVO.specialistID))
                            {
                                deposit;
                                if (specialistFoundDepositVO.depositVO != null)
                                {
                                    deposit = cDeposit.CreateDepositFromVO(specialistFoundDepositVO.depositVO, this.mGeneralInterface);
                                }
                                if (specialist.GetTask() != null && specialist.GetTask().GetType() == SPECIALIST_TASK_TYPES.DEPOSIT_SEARCH)
                                {
                                    findDepositTask = specialist.GetTask() as cSpecialistTask_FindDeposit;
                                    findDepositTask.SetExploredDepositResult(specialistFoundDepositVO.exploredDepositResult, deposit);
                                }
                                else
                                {
                                    gMisc.ConsoleOut(specialist + " has no \'Find Deposit\' task! Ignoring \'Found Deposit\' message.");
                                }
                            }
                            specialistIdx = (specialistIdx + 1);
                        }
                    }
                    continue;
                }
                if (updateVO is dExploreSectorResponseVO)
                {
                    exploreSectorResponseVO = updateVO as dExploreSectorResponseVO;
                    var _loc_5:int = 0;
                    var _loc_6:* = exploreSectorResponseVO.exploredSectors_vector;
                    while (_loc_6 in _loc_5)
                    {
                        
                        exploredSectorVO = _loc_6[_loc_5];
                        specialists = this.mGeneralInterface.mCurrentPlayerZone.GetSpecialists_vector();
                        specialistIdx;
                        while (specialistIdx < specialists.length)
                        {
                            
                            specialist = specialists[specialistIdx] as cSpecialist;
                            if (specialist.GetUniqueID().equals(exploredSectorVO.specialistID))
                            {
                                gMisc.ConsoleOut("cClientMessagesII.ReceivedMessageFromServer: " + specialist + " explored sector " + sector + ". His task is " + specialist.GetTask());
                                sector = this.mGeneralInterface.mCurrentPlayerZone.mSectorList_vector[exploredSectorVO.sectorID];
                                if (specialist.GetTask() != null && specialist.GetTask().GetType() == SPECIALIST_TASK_TYPES.EXPLORE_SECTOR)
                                {
                                    exploreSectorTask = specialist.GetTask() as cSpecialistTask_ExploreSector;
                                    exploreSectorTask.SetExploredSector(sector);
                                }
                                else
                                {
                                    gMisc.ConsoleOut(specialist + " has no \'Explore Sector\' task! Ignoring \'Explored Sector\' message.");
                                }
                            }
                            specialistIdx = (specialistIdx + 1);
                        }
                    }
                    continue;
                }
                if (updateVO is dAlertMessageVO)
                {
                    alertMessageVO = updateVO as dAlertMessageVO;
                    CustomAlert.show(alertMessageVO.alertMessage, alertMessageVO.alertMessage, Alert.OK);
                    continue;
                }
                if (updateVO is dGuildUpdateVO)
                {
                    motdChanged;
                    guildVO = (updateVO as dGuildUpdateVO).guild;
                    if (guildVO && this.mGeneralInterface.GetCurrentPlayerGuild() && guildVO.motd != this.mGeneralInterface.GetCurrentPlayerGuild().motd)
                    {
                        motdChanged;
                    }
                    this.mGeneralInterface.SetCurrentPlayerGuild(guildVO);
                    globalFlash.gui.mGuildWindow.RefreshOwnGuild();
                    if (guildVO != null)
                    {
                        if (globalFlash.gui.mChatPanel != null)
                        {
                            globalFlash.gui.mChatPanel.joinGuildChannel(guildVO);
                            if (guildVO.playerPermissions.OfficersChannel())
                            {
                                globalFlash.gui.mChatPanel.joinOfficersChannel(guildVO);
                            }
                        }
                        guildBuilding = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetGuildHouse();
                        if (guildBuilding)
                        {
                            upgradelevel;
                            var _loc_5:int = 0;
                            var _loc_6:* = global.guildUpgradeLevels;
                            while (_loc_6 in _loc_5)
                            {
                                
                                k = _loc_6[_loc_5];
                                if (guildVO.maxSize >= global.guildUpgradeLevels[k])
                                {
                                    upgradelevel = k;
                                    continue;
                                }
                                break;
                            }
                            guildBuilding.SetUpgradeLevel(upgradelevel);
                        }
                        else
                        {
                            guildBuilding = this.mGeneralInterface.mCurrentPlayerZone.mStreetDataMap.GetGuildHouse();
                            if (guildBuilding)
                            {
                                guildBuilding.SetUpgradeLevel(1);
                            }
                        }
                    }
                    else
                    {
                        globalFlash.gui.mChatPanel.leaveGuildChannels();
                    }
                    if (motdChanged)
                    {
                        globalFlash.gui.mChatPanel.PutMessageToChannelWithoutServer("gc_" + guildVO.id, new Date(), cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "chatguild"), guildVO.motd, false, false);
                    }
                    continue;
                }
                if (updateVO is dClientDateVO)
                {
                    this.mGeneralInterface.mServerDate = updateVO as dClientDateVO;
                    continue;
                }
                gMisc.Assert(false, "cClientMessagesII.ReceivedMessageFromServer: Could not handle " + updateVO);
            }
            if (playerListUpdated)
            {
                var _loc_3:int = 0;
                var _loc_4:* = playerList;
                while (_loc_4 in _loc_3)
                {
                    
                    newPlayer = _loc_4[_loc_3];
                    found;
                    i;
                    while (i < this.mGeneralInterface.GetPlayerList_vector().length)
                    {
                        
                        oldPlayer = this.mGeneralInterface.GetPlayerList_vector()[i];
                        if (oldPlayer.GetPlayerId() == newPlayer.GetPlayerId())
                        {
                            this.mGeneralInterface.GetPlayerList_vector()[i] = newPlayer;
                            found;
                            break;
                        }
                        i = (i + 1);
                    }
                    if (!found)
                    {
                        this.mGeneralInterface.GetPlayerList_vector().push(newPlayer);
                    }
                }
                i;
                while (i < this.mGeneralInterface.GetPlayerList_vector().length)
                {
                    
                    found;
                    oldPlayer = this.mGeneralInterface.GetPlayerList_vector()[i];
                    var _loc_3:int = 0;
                    var _loc_4:* = playerList;
                    while (_loc_4 in _loc_3)
                    {
                        
                        newPlayer = _loc_4[_loc_3];
                        if (oldPlayer.GetPlayerId() == newPlayer.GetPlayerId())
                        {
                            found;
                            break;
                        }
                    }
                    if (!found)
                    {
                        this.mGeneralInterface.GetPlayerList_vector().splice(i, 1);
                        i = (i - 1);
                    }
                    i = (i + 1);
                }
            }
            if (this.mGeneralInterface.mCurrentPlayer == this.mGeneralInterface.mHomePlayer)
            {
                globalFlash.gui.mAvatar.SetData(this.mGeneralInterface.mCurrentPlayer, this.mGeneralInterface.GetPlayerList_vector());
            }
            return;
        }// end function

        public function ResultHandler(event:ResultEvent, param2:Object = null) : void
        {
            var _loc_4:String = null;
            var _loc_5:String = null;
            var _loc_3:* = event.result as dServerResponse;
            if (_loc_3 == null)
            {
                _loc_4 = "Error";
                _loc_5 = "Server Response is null!";
                CustomAlert.show(_loc_5, _loc_4, 4, null, null, null, 4, false);
            }
            if (_loc_3.type == COMMAND.SESSION_AUTH)
            {
                this.ReceivedMessageFromServer(_loc_3);
            }
            else if (!this.mGeneralInterface.mLastServerResponseRead)
            {
                this.mGeneralInterface.mLastServerResponse.push(_loc_3);
            }
            else if (!this.mGeneralInterface.mLastServerResponseIIRead)
            {
                this.mGeneralInterface.mLastServerResponseII.push(_loc_3);
            }
            else
            {
                gMisc.MessageBox("Server Response Error!");
            }
            return;
        }// end function

        private function handleRedirectClient(event:CloseEvent) : void
        {
            var _loc_2:* = defines.BIG_BROTHER_URL;
            navigateToURL(new URLRequest(_loc_2), "_self");
            return;
        }// end function

        private function ConfigureListeners(param1:IEventDispatcher) : void
        {
            param1.addEventListener(HTTPStatusEvent.HTTP_STATUS, this.HttpStatusHandler);
            param1.addEventListener(Event.COMPLETE, this.CompleteHandler);
            param1.addEventListener(IOErrorEvent.IO_ERROR, this.IoErrorHandler);
            param1.addEventListener(SecurityErrorEvent.SECURITY_ERROR, this.SecurityErrorHandler);
            return;
        }// end function

        private function GetDebugZoneCloseHandler(event:Event) : void
        {
            var _loc_2:* = new FileReference();
            _loc_2.save(this.mDebugZoneString, "ServerZone.xml");
            this.mDebugZoneString = null;
            return;
        }// end function

        public function SendMessagetoServer(param1:int, param2:int, param3:Object) : void
        {
            if (defines.USE_BIG_BROTHER)
            {
                new cBigBrotherMessage(param1, param2, param3);
            }
            else
            {
                this.SendMessagetoServerII(param1, param2, param3, defines.BIG_BROTHER_URL + "/amf");
            }
            if (this.mNextKeepAlivePing <= getTimer())
            {
                this.mNextKeepAlivePing = cConnectionManager.GetInstance().SendKeepAlivePing();
            }
            return;
        }// end function

        private function IsUniqueIDEqualTo(param1:dUniqueID, param2:dUniqueID) : Boolean
        {
            var _loc_3:* = param1.uniqueID1 == param2.uniqueID1;
            var _loc_4:* = param1.uniqueID2 == param2.uniqueID2;
            return _loc_3 && _loc_4;
        }// end function

        private function SecurityErrorHandler(event:SecurityErrorEvent) : void
        {
            if (this.errorRetry < cBigBrotherMessage.ERROR_RETRIES)
            {
                var _loc_2:String = this;
                var _loc_3:* = this.errorRetry + 1;
                _loc_2.errorRetry = _loc_3;
                this.mURLLoader.load(this.mURLRequest);
            }
            else
            {
                this.FaultHandler(new FaultEvent("SecurityError on BigBrother Authenticate : " + event.type + " " + event.text));
            }
            return;
        }// end function

        public function getClientSession() : int
        {
            return mAuthRandomClient;
        }// end function

        public function FaultHandler(event:FaultEvent, param2:Object = null) : void
        {
            var _loc_3:* = this.mGeneralInterface;
            var _loc_4:* = this.mGeneralInterface.mConnectionLost + 1;
            _loc_3.mConnectionLost = _loc_4;
            globalFlash.gui.mAvatarMessageList.AddMessage(AVATAR_MESSAGE_TYPE.SERVER_CALL_FAILED);
            LogMessageToBigBrother(event, param2);
            switch(event.type)
            {
                case ERROR_CODES.BB_AUTH_FAILED:
                {
                    CustomAlert.show("BigBrotherAuthFailed", "BigBrotherAuthFailed", Alert.OK, null, this.handleRedirectClient);
                    return;
                }
                case ERROR_CODES.BB_SERVICE_FAILED:
                {
                    CustomAlert.show("BigBrotherServiceUnavailable", "BigBrotherServiceUnavailable", Alert.OK, null, this.handleRedirectClient);
                    return;
                }
                case ERROR_CODES.BB_FILE_NOT_FOUND:
                {
                    CustomAlert.show("BigBrotherFileNotFound", "BigBrotherFileNotFound", Alert.OK, null, this.handleRedirectClient);
                    return;
                }
                case ERROR_CODES.BB_SERVERS_FULL:
                {
                    CustomAlert.show("ServerFull", "ServerFull", Alert.OK, null, this.handleRedirectClient);
                    return;
                }
                default:
                {
                    if (this.mGeneralInterface.mConnectionLost == 0)
                    {
                        this.mGeneralInterface.SendClientLogMessagesToServer();
                    }
                    CustomAlert.show("ConnectionLost", "ConnectionLost", Alert.OK, null, this.handleRedirectClient);
                    return;
                    continue;
                }
            }
        }// end function

        public function InitChat() : void
        {
            var _loc_1:Boolean = true;
            if (globalFlash.gui.mChatPanel == null)
            {
                _loc_1 = false;
            }
            else
            {
                if (!globalFlash.gui.mChatPanel.IsConnectionEstablished())
                {
                    globalFlash.gui.mChatPanel.EstablishConnection(mChatServerUsername_string, mChatServerPW_string);
                }
                else
                {
                    _loc_1 = false;
                }
                if (globalFlash.gui.GetDefaultGuiElementsLoaded())
                {
                    globalFlash.gui.mChatPanel.Show();
                }
                else
                {
                    _loc_1 = false;
                }
            }
            if (!_loc_1)
            {
                this.mGeneralInterface.CreateGameTickCommand(this.mGeneralInterface.mCurrentPlayer.GetPlayerId(), COMMAND.INIT_CHAT, null, 1000);
            }
            return;
        }// end function

        private function HttpStatusHandler(event:HTTPStatusEvent) : void
        {
            switch(event.status)
            {
                case 403:
                {
                    this.FaultHandler(new FaultEvent(ERROR_CODES.BB_AUTH_FAILED + " BigBrother returned : 403 on AUTHENTICATE"));
                    break;
                }
                case 404:
                {
                    this.FaultHandler(new FaultEvent(ERROR_CODES.BB_SERVERS_FULL + " BigBrother returned : 404 on AUTHENTICATE"));
                    break;
                }
                case 405:
                case 503:
                {
                    this.FaultHandler(new FaultEvent(ERROR_CODES.BB_SERVICE_FAILED + " BigBrother returned : 503 on AUTHENTICATE"));
                    break;
                }
                default:
                {
                    break;
                    break;
                }
            }
            return;
        }// end function

        private function CompleteHandler(event:Event) : void
        {
            mInitialized = true;
            var _loc_2:* = String(URLLoader(event.target).data);
            var _loc_3:* = _loc_2.split("|");
            mChatServerSID_string = _loc_3[0];
            mChatServerUsername_string = _loc_3[1];
            mChatServerPW_string = _loc_3[2];
            this.SendMessagetoServer(COMMAND.GET_FRIEND_LIST, 0, null);
            this.SendMessagetoServer(COMMAND.GET_ZONE, 0, false);
            return;
        }// end function

        public static function LogMessageToBigBrother(event:Event, param2:Object = null) : void
        {
            var _loc_3:Object = null;
            var _loc_4:String = null;
            var _loc_5:URLRequest = null;
            var _loc_6:URLVariables = null;
            var _loc_7:URLLoader = null;
            if (defines.USE_BIG_BROTHER)
            {
                _loc_3 = ObjectUtil.getClassInfo(event);
                _loc_4 = _loc_3["name"] + " : " + ObjectUtil.toString(event, null, ["target", "currentTarget"]) + "\n";
                _loc_4 = _loc_4 + ("Flash Player Version : " + Capabilities.version + "\n\n----\n\n");
                _loc_5 = new URLRequest();
                _loc_6 = new URLVariables();
                _loc_7 = new URLLoader();
                _loc_5.url = defines.BIG_BROTHER_URL + "log";
                _loc_5.method = URLRequestMethod.POST;
                _loc_6.log = _loc_4;
                _loc_5.data = _loc_6;
                _loc_7.dataFormat = URLLoaderDataFormat.TEXT;
                _loc_7.load(_loc_5);
            }
            return;
        }// end function

    }
}
