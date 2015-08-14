package GUI.Components.ItemRenderer
{
    import AdventureSystem.*;
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import GUI.Assets.*;
    import GUI.Components.ToolTips.*;
    import GUI.Loca.*;
    import flash.events.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.styles.*;

    public class TrackedMissionItemRenderer extends Canvas
    {
        private var lm:cLocaManager;
        private var _26032799lblName:Label;
        private var _100313435image:Image;
        private var _1855339882lblDuration:Label;
        private var _documentDescriptor_:UIComponentDescriptor;

        public function TrackedMissionItemRenderer()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:180, childDescriptors:[new UIComponentDescriptor({type:Image, id:"image", stylesFactory:function () : void
                {
                    this.left = "15";
                    return;
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"lblName", stylesFactory:function () : void
                {
                    null.right = this;
                    this.color = 16777215;
                    this.fontWeight = "bold";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:false};
                }// end function
                }), new UIComponentDescriptor({type:Label, id:"lblDuration", stylesFactory:function () : void
                {
                    this.color = 16777215;
                    this.right = "17";
                    this.top = "6";
                    this.fontWeight = "bold";
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    return {null:false};
                }// end function
                })]};
            }// end function
            });
            this.lm = cLocaManager.GetInstance();
            mx_internal::_document = this;
            if (!this.styleDeclaration)
            {
                this.styleDeclaration = new CSSStyleDeclaration();
            }
            this.styleDeclaration.defaultFactory = function () : void
            {
                null.backgroundSize = this;
                return;
            }// end function
            ;
            this.width = 180;
            this.mouseChildren = false;
            this.addEventListener("click", this.___TrackedMissionItemRenderer_Canvas1_click);
            this.addEventListener("toolTipCreate", this.___TrackedMissionItemRenderer_Canvas1_toolTipCreate);
            return;
        }// end function

        private function display(event:Event = null) : void
        {
            var _loc_2:dQuestElementVO = null;
            var _loc_3:dAdventureClientInfoVO = null;
            removeEventListener(FlexEvent.CREATION_COMPLETE, this.display);
            if (data is dQuestElementVO)
            {
                _loc_2 = data as dQuestElementVO;
                this.setStyle("backgroundImage", gAssetManager.GetClass("TrackedQuestBackground"));
                this.height = 36;
                this.toolTip = _loc_2.mQuestName_string;
                this.image.source = gAssetManager.GetBitmap("QuestAdvisorSmall");
                this.image.setConstraintValue("top", 7);
                this.lblName.text = this.lm.GetText(LOCA_GROUP.QUEST_LABELS, _loc_2.mQuestName_string);
                this.lblName.setConstraintValue("top", 9);
                this.lblName.width = this.width - this.lblName.getConstraintValue("right") - 40;
                this.lblDuration.visible = false;
            }
            else if (data is dAdventureClientInfoVO)
            {
                _loc_3 = data as dAdventureClientInfoVO;
                this.setStyle("backgroundImage", gAssetManager.GetClass("TrackedAdventureBackground"));
                this.height = 73;
                this.image.source = cAdventureDefinition.FindAdventureDefinition(_loc_3.adventureName).GetAvatarImage();
                this.image.setConstraintValue("top", 2);
                this.lblName.text = this.lm.GetText(LOCA_GROUP.ADVENTURE_NAME, _loc_3.adventureName);
                this.lblName.setConstraintValue("top", 51);
                this.lblName.width = this.width - this.lblName.getConstraintValue("right") - 17;
                this.lblDuration.visible = true;
                this.refresh();
            }
            return;
        }// end function

        override public function set data(param1:Object) : void
        {
            super.data = param1;
            if (this.image)
            {
                this.display();
            }
            else
            {
                addEventListener(FlexEvent.CREATION_COMPLETE, this.display);
            }
            return;
        }// end function

        public function set lblName(param1:Label) : void
        {
            var _loc_2:* = this._26032799lblName;
            if (_loc_2 !== param1)
            {
                this._26032799lblName = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "lblName", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

        public function refresh() : void
        {
            if (data is dAdventureClientInfoVO)
            {
                this.lblDuration.text = this.lm.FormatDuration(data.totalDuration - data.collectedTime, cLocaManager.DURATION_FORMAT_NUMERIC);
            }
            return;
        }// end function

        public function get lblName() : Label
        {
            return this._26032799lblName;
        }// end function

        public function get image() : Image
        {
            return this._100313435image;
        }// end function

        public function set lblDuration(param1:Label) : void
        {
            var _loc_2:* = this._1855339882lblDuration;
            if (_loc_2 !== param1)
            {
                this._1855339882lblDuration = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "lblDuration", _loc_2, param1));
            }
            return;
        }// end function

        private function clickHandler(event:MouseEvent) : void
        {
            var _loc_2:dPlayerListItemVO = null;
            if (data is dQuestElementVO)
            {
                globalFlash.gui.mQuestBook.SetPreselectedQuest(data as dQuestElementVO);
                globalFlash.gui.mQuestBook.Show();
            }
            else if (data is dAdventureClientInfoVO)
            {
                _loc_2 = globalFlash.gui.mFriendsList.GetFriendById((data as dAdventureClientInfoVO).zoneID);
                globalFlash.gui.ShowFriendListMenu(event, _loc_2);
            }
            return;
        }// end function

        public function get lblDuration() : Label
        {
            return this._1855339882lblDuration;
        }// end function

        public function ___TrackedMissionItemRenderer_Canvas1_toolTipCreate(event:ToolTipEvent) : void
        {
            cToolTipUtil.createToolTip(cToolTipUtil.TRACKED_MISSION_string, event, data);
            return;
        }// end function

        public function set image(param1:Image) : void
        {
            var _loc_2:* = this._100313435image;
            if (_loc_2 !== param1)
            {
                this._100313435image = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "image", _loc_2, param1));
            }
            return;
        }// end function

        public function ___TrackedMissionItemRenderer_Canvas1_click(event:MouseEvent) : void
        {
            this.clickHandler(event);
            return;
        }// end function

    }
}
