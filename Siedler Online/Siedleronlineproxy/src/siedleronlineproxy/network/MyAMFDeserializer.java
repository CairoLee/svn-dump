/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.network;

import siedleronlineproxy.debug.UnknownClassPrinter;
import flex.messaging.io.ClassAliasRegistry;
import flex.messaging.io.MessageDeserializer;
import flex.messaging.io.MessageSerializer;
import flex.messaging.io.amf.AmfMessageDeserializer;
import flex.messaging.io.SerializationContext;
import flex.messaging.io.amf.ActionContext;
import flex.messaging.io.amf.ActionMessage;
import flex.messaging.io.amf.AmfMessageSerializer;
import flex.messaging.io.amf.AmfTrace;
import flex.messaging.io.amf.MessageBody;
import flex.messaging.io.amf.MessageHeader;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.OutputStream;
import siedleronlineproxy.PropertyManager;
import siedleronlineproxy.debug.DebugLog;

/**
 * http://pastebin.com/ex8EkEZU
 *
 * Response:
 * http://pastebin.com/y7GzqwDy
 * @author nspecht
 */
public class MyAMFDeserializer extends AbstractAMFDeserializer {

    public static boolean AMFRegistered = false;
    private ActionMessage am = null;
    private ActionContext ac = null;
    SerializationContext sc = null;
    public boolean canBeManipulated = false;

    protected void __readMessage(byte[] mess) throws IOException, ClassNotFoundException {
        //new DebugWriter().add(this.message).write();
        if (mess.length > 0) {
            MessageDeserializer mds = this.sc.newMessageDeserializer();
            AmfTrace trace = new AmfTrace();
            mds.initialize(this.sc, new ByteArrayInputStream(mess), trace);

            this.am = new ActionMessage();
            this.ac = new ActionContext();

            try {
                mds.readMessage(this.am, this.ac);
                if (new Boolean(PropertyManager.getInstance().get("AsObjectForMissingType", "true"))
                        && new Boolean(PropertyManager.getInstance().get("PrintMissingTypes", "false"))
                        ) {
                    for (Object o : this.am.getHeaders()) {
                        MessageHeader header = (MessageHeader) o;
                        Object msg = header.getData();
                        String res = UnknownClassPrinter.searchForAsObjects(msg);
                        if (res.trim().length() > 10) DebugLog.put(this,res, DebugLog.LogLevel.ERROR);
                    }
                    for (Object o : this.am.getBodies()) {
                        MessageBody body = (MessageBody) o;
                        Object msg = body.getDataAsMessage().getBody();
                        String res = UnknownClassPrinter.searchForAsObjects(msg);
                        if (res.trim().length() > 10) DebugLog.put(this,res, DebugLog.LogLevel.ERROR);
                    }
                }
            } catch (ClassNotFoundException e) {
                DebugLog.put(this, e);
            }

        }
    }

    @Override
    protected void __serialize(OutputStream ops) throws IOException {
        MessageSerializer ms = (MessageSerializer) this.sc.newMessageSerializer();
        ms.initialize(sc, ops, null);
        ms.writeMessage(this.am);
    }

    private void registerClass(String name) {
        this.registerClass(name, null);
    }

    private void registerClass(String name, String subpackage) {
        if (subpackage == null) {
            subpackage = "";
        } else {
            subpackage = subpackage + ".";
        }
        ClassAliasRegistry r = ClassAliasRegistry.getRegistry();
        r.registerAlias("defaultGame.Communication.VO." + subpackage + "d" + name, "siedleronlineproxy.mappings." + name);
        //und zurück
        r.registerAlias("siedleronlineproxy.mappings." + name, "defaultGame.Communication.VO." + subpackage + "d" + name);
    }

    protected void init() {
        if (!MyAMFDeserializer.AMFRegistered) {
            ClassAliasRegistry r = ClassAliasRegistry.getRegistry();
            r.registerAlias("DSK", flex.messaging.messages.AcknowledgeMessageExt.class.getCanonicalName());
            r.registerAlias(
                    "DSA", flex.messaging.messages.AsyncMessageExt.class.getCanonicalName());
            r.registerAlias(
                    "DSC", flex.messaging.messages.CommandMessageExt.class.getCanonicalName());

            this.registerClass("BuildQueueVO");
            this.registerClass("BuildingVO");
            this.registerClass("BuffVO");
            this.registerClass("BuffApplianceVO");
            this.registerClass("ServerAction");
            this.registerClass("DepositVO");
            this.registerClass("ZoneVO");
            this.registerClass("ZoneRefreshVO");
            this.registerClass("MapValueItemVO");
            this.registerClass("SectorVO");
            this.registerClass("ResourceVO");
            this.registerClass("ResourceCreationVO");
            this.registerClass("ResourceListVO");
            this.registerClass("SpecialistTask_MoveVO");
            this.registerClass("NewMailCountVO", "Mail");
            this.registerClass("FoundDepositVO", "UpdateVO");

            if (new Boolean(PropertyManager.getInstance().get("fullAMFRegistration", "false"))) {
                this.registerClass("ServerCall");
                this.registerClass("ServerResponse");
                
                this.registerClass("ServerActionResult");
                this.registerClass("ServerClientUpdateVO");
                this.registerClass("NumberVO");
                this.registerClass("UniqueID");
                this.registerClass("PathVO");
                this.registerClass("DataTrackingVO");
                this.registerClass("DataIntStringVO");
                this.registerClass("ServerClientSynchronizeCheck");
                this.registerClass("GameTickCommandVO");
                this.registerClass("UpateVO");
                this.registerClass("UpdateVO");
                this.registerClass("ClientLogMessagesVO");
                this.registerClass("PurchasedShopItemVO");

                this.registerClass("ZoneCheckVO");
                this.registerClass("BackgroundTileVO");

                this.registerClass("SectorDiscoveryVO");
                this.registerClass("FreeLandscapeVO");
                this.registerClass("LandscapeVO");
                this.registerClass("LandingFieldVO");

                this.registerClass("ResourcesVO");

                this.registerClass("MailVO", "Mail");
                this.registerClass("MailBodyVO", "Mail");
                this.registerClass("BattleReportBodyVO", "Mail");
                this.registerClass("BuffedDataVO", "Mail");
                this.registerClass("TradeResultVO", "Mail");
                this.registerClass("TradeBodyVO", "Mail");
                this.registerClass("HardCurrencyMailBodyVO", "Mail");

                this.registerClass("TradeVO");
                this.registerClass("TradeOfferVO");

                this.registerClass("SpecialistVO");
                this.registerClass("SpecialistTask_FindDepositVO");
                this.registerClass("SpecialistTask_RecoverVO");
                this.registerClass("SpecialistTask_AttackBuildingVO");
                this.registerClass("SpecialistTask_FindEventZoneVO");
                this.registerClass("SpecialistTask_TravelToZoneVO");
                this.registerClass("TravellingSpecialistArivalVO","UpdateVO");
                this.registerClass("FindDepositTaskVO");
                this.registerClass("ArmyVO");
                this.registerClass("SquadVO");
                this.registerClass("RaiseArmyVO");

                this.registerClass("FindDepositResponseVO", "UpdateVO");
                this.registerClass("SpecialistTask_FindTreasureVO");
                this.registerClass("FindTreasureResponseVO", "UpdateVO");
                this.registerClass("FindEventZoneResponseVO", "UpdateVO");
                this.registerClass("LootItemsVO", "UpdateVO");
                this.registerClass("BattleResultVO", "UpdateVO");
                this.registerClass("RemovedFriendVO", "UpdateVO");
                this.registerClass("Casualty", "UpdateVO");

                this.registerClass("StartTimedProductionVO");
                this.registerClass("TimedProductionVO");
                this.registerClass("StreetVO");

                this.registerClass("QuestVO");
                this.registerClass("QuestUpdateVO","UpdateVO");
                this.registerClass("QuestPoolVO");
                this.registerClass("QuestElementVO");
                this.registerClass("QuestTriggerVO");
                this.registerClass("QuestDefinitionContainerVO");
                this.registerClass("QuestDefinitionVO");
                this.registerClass("QuestDefinitionPostrequisitsVO");
                this.registerClass("QuestDefinitionTriggerVO");
                this.registerClass("QuestDefinitionRewardVO");
                this.registerClass("QuestDefinitionHintVO");

                this.registerClass("AdventurePlayerListItemVO");
                this.registerClass("AdventureClientInfoVO", "UpdateVO");
                
                this.registerClass("PlayerVO");
                this.registerClass("PlayerListVO");
                this.registerClass("PlayerListItemVO");
                

                this.registerClass("GuildVO", "Guild");
                this.registerClass("GuildUpdateVO", "Guild");
                this.registerClass("GuildPlayerListItemVO", "Guild");
                this.registerClass("GuildRankListItemVO", "Guild");
                this.registerClass("GuildPlayerPermissionVO", "Guild");
                this.registerClass("GuildLogListItemVO", "Guild");
                this.registerClass("GuildHeadersListVO", "Guild");
            }
            MyAMFDeserializer.AMFRegistered = true;
        }

        this.sc = SerializationContext.getSerializationContext();


        if (new Boolean(PropertyManager.getInstance().get("AsObjectForMissingType", "true"))) {
            this.sc.createASObjectForMissingType = true;
        }

        this.sc.ignorePropertyErrors = true;

        this.sc.supportRemoteClass = true;

        this.sc.instantiateTypes = true;


        this.sc.setDeserializerClass(AmfMessageDeserializer.class);


        this.sc.setSerializerClass(AmfMessageSerializer.class);


        this.sc.setDeserializationValidator(
                null);
    }

    public void printMissingTypes() {
        for (Object o : this.am.getBodies()) {
            MessageBody m = (MessageBody) o;
            System.out.println(m.getData().getClass().getCanonicalName());
            System.out.println(m.getDataAsMessage().getBody().getClass().getCanonicalName() + "\n\n");
        }
    }
}
