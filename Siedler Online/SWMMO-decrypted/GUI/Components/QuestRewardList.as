package GUI.Components
{
    import Communication.VO.*;
    import Enums.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import LootTableSystem.*;
    import NewQuestSystem.*;
    import __AS3__.vec.*;
    import mx.collections.*;
    import mx.containers.*;
    import mx.core.*;
    import mx.events.*;

    public class QuestRewardList extends Canvas
    {
        private var lm:cLocaManager;
        private var _3322014list:HBox;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _dataProvider:ArrayCollection;

        public function QuestRewardList()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                return {height:83, childDescriptors:[new UIComponentDescriptor({type:HBox, id:"list", stylesFactory:function () : void
                {
                    this.horizontalCenter = "0";
                    this.horizontalGap = 5;
                    return;
                }// end function
                })]};
            }// end function
            });
            this.lm = cLocaManager.GetInstance();
            mx_internal::_document = this;
            this.height = 83;
            this.verticalScrollPolicy = "off";
            return;
        }// end function

        public function get list() : HBox
        {
            return this._3322014list;
        }// end function

        public function set dataPovider(param1:ArrayCollection) : void
        {
            if (this._dataProvider == param1)
            {
                return;
            }
            this._dataProvider = param1;
            this.displayItems();
            return;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        public function get dataProvider() : ArrayCollection
        {
            return this._dataProvider;
        }// end function

        public function set list(param1:HBox) : void
        {
            var _loc_2:* = this._3322014list;
            if (_loc_2 !== param1)
            {
                this._3322014list = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "list", _loc_2, param1));
            }
            return;
        }// end function

        private function displayItems() : void
        {
            var reward:dQuestDefinitionRewardVO;
            var renderer:Frame;
            var lootTables:Vector.<cLootTable>;
            var lootItem:cLootTableItemContent;
            this.list.removeAllChildren();
            if (this._dataProvider == null || this._dataProvider.length == 0)
            {
                return;
            }
            var _loc_2:int = 0;
            var _loc_3:* = this._dataProvider;
            while (_loc_3 in _loc_2)
            {
                
                reward = _loc_3[_loc_2];
                switch(reward.type)
                {
                    case QuestManagerStatic.TYPE_XP:
                    {
                        renderer = new Frame();
                        renderer.contentType = Frame.CONTENT_TYPE_RESOURCE;
                        renderer.amount = reward.amount;
                        renderer.content = "XP";
                        renderer.toolTip = this.lm.GetText(LOCA_GROUP.RESOURCES, "XP");
                        renderer.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, function (event:ToolTipEvent) : void
            {
                null.createToolTip(cToolTipUtil.SIMPLE_string, event);
                return;
            }// end function
            );
                        this.list.addChild(renderer);
                        break;
                    }
                    case QuestManagerStatic.TYPE_RESOURCE:
                    {
                        renderer = new Frame();
                        renderer.contentType = Frame.CONTENT_TYPE_RESOURCE;
                        renderer.amount = reward.amount;
                        renderer.content = reward.name_string;
                        renderer.toolTip = this.lm.GetText(LOCA_GROUP.RESOURCES, reward.name_string);
                        renderer.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, function (event:ToolTipEvent) : void
            {
                null.createToolTip(cToolTipUtil.SIMPLE_string, event);
                return;
            }// end function
            );
                        this.list.addChild(renderer);
                        break;
                    }
                    case QuestManagerStatic.TYPE_ADVENTURE:
                    {
                        renderer = new Frame();
                        renderer.contentType = Frame.CONTENT_TYPE_ADVENTURE;
                        renderer.content = reward.name_string;
                        renderer.toolTip = this.lm.GetText(LOCA_GROUP.ADVENTURE_NAME, reward.name_string);
                        renderer.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, function (event:ToolTipEvent) : void
            {
                null.createToolTip(cToolTipUtil.SIMPLE_string, event);
                return;
            }// end function
            );
                        this.list.addChild(renderer);
                        break;
                    }
                    case QuestManagerStatic.TYPE_LOOT:
                    {
                        lootTables = global.ui.mServerOnly.CalculateLootTables_vector(reward.amount, 100, global.ui.mCurrentPlayer);
                        var _loc_4:int = 0;
                        var _loc_5:* = lootTables[0].mItemContents_vector;
                        while (_loc_5 in _loc_4)
                        {
                            
                            lootItem = _loc_5[_loc_4];
                            switch(lootItem.GetType())
                            {
                                case ITEM_CONTENT_TYPE.BUFF:
                                {
                                    renderer = new Frame();
                                    if (lootItem.GetName_string() == "Adventure")
                                    {
                                        renderer.contentType = Frame.CONTENT_TYPE_ADVENTURE;
                                        renderer.content = lootItem.GetResourceName_string();
                                        renderer.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.ADVENTURE_NAME, lootItem.GetResourceName_string());
                                    }
                                    else
                                    {
                                        renderer.contentType = Frame.CONTENT_TYPE_BUFF;
                                        renderer.content = lootItem.GetName_string();
                                        renderer.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, lootItem.GetName_string());
                                    }
                                    renderer.addEventListener(ToolTipEvent.TOOL_TIP_CREATE, function (event:ToolTipEvent) : void
            {
                cToolTipUtil.createToolTip(cToolTipUtil.SIMPLE_string, event);
                return;
            }// end function
            );
                                    this.list.addChild(renderer);
                                    break;
                                }
                                default:
                                {
                                    break;
                                }
                            }
                        }
                        break;
                    }
                    default:
                    {
                        break;
                    }
                }
            }
            return;
        }// end function

    }
}
