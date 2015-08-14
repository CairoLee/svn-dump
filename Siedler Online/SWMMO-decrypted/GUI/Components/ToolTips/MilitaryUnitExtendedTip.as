package GUI.Components.ToolTips
{
    import Enums.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import MilitarySystem.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;

    public class MilitaryUnitExtendedTip extends Canvas implements IToolTip
    {
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _1115058732headline:Label;
        private var _text:String;
        private var _1724546052description:CustomText;

        public function MilitaryUnitExtendedTip()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Canvas, propertiesFactory:function () : Object
            {
                var _loc_1:String = null;
                return {width:250, childDescriptors:[new UIComponentDescriptor({type:Label, id:"headline", stylesFactory:function () : void
                {
                    this.top = "5";
                    this.left = "5";
                    this.right = "5";
                    this.fontWeight = "bold";
                    this.color = 16777215;
                    return;
                }// end function
                }), new UIComponentDescriptor({type:CustomText, id:"description", stylesFactory:function () : void
                {
                    this.color = 16777215;
                    this.left = "5";
                    this.right = "5";
                    this.top = "26";
                    this.bottom = "5";
                    return;
                }// end function
                })]};
            }// end function
            });
            mx_internal::_document = this;
            this.mouseEnabled = false;
            this.mouseChildren = false;
            this.width = 250;
            this.styleName = "toolTip";
            return;
        }// end function

        public function set text(param1:String) : void
        {
            var _loc_5:cMilitaryUnitSkill = null;
            var _loc_6:String = null;
            this._text = param1;
            var _loc_2:* = cMilitaryUnitDescription.GetUnitDescriptionForType(this._text);
            this.headline.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, this._text);
            if (_loc_2.GetSkill(MILLITARY_UNIT_SKILLS.FIRST_STRIKE))
            {
                _loc_6 = MILLITARY_UNIT_SKILLS.toString(MILLITARY_UNIT_SKILLS.FIRST_STRIKE);
            }
            else if (_loc_2.GetSkill(MILLITARY_UNIT_SKILLS.LAST_STRIKE))
            {
                _loc_6 = MILLITARY_UNIT_SKILLS.toString(MILLITARY_UNIT_SKILLS.LAST_STRIKE);
            }
            else
            {
                _loc_6 = "InitiativeNormal";
            }
            var _loc_3:* = "\n" + cLocaManager.GetInstance().GetText(LOCA_GROUP.DESCRIPTIONS, this._text) + "\n";
            _loc_3 = _loc_3 + ("\n" + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "UnitDetailsHitpoints", [_loc_2.GetHitPoints().toString()]));
            _loc_3 = _loc_3 + ("\n" + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "UnitDetailsDamage", [_loc_2.GetMissDamage().toString(), _loc_2.GetHitDamage().toString()]));
            _loc_3 = _loc_3 + ("\n" + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "UnitDetailsAccuracy", [_loc_2.GetHitPercentage().toString()]));
            _loc_3 = _loc_3 + ("\n" + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "UnitDetailsInitiative", ["UnitSkill" + _loc_6]));
            var _loc_4:String = "";
            for each (_loc_5 in _loc_2.GetSkills())
            {
                
                if (_loc_5.GetType() != MILLITARY_UNIT_SKILLS.FIRST_STRIKE && _loc_5.GetType() != MILLITARY_UNIT_SKILLS.LAST_STRIKE)
                {
                    _loc_4 = _loc_4 + ("\n- " + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "UnitSkill" + MILLITARY_UNIT_SKILLS.toString(_loc_5.GetType())));
                }
            }
            if (_loc_4.length > 0)
            {
                _loc_3 = _loc_3 + ("\n\n" + cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "UnitDetailsSkills") + _loc_4);
            }
            this.description.text = _loc_3;
            return;
        }// end function

        public function get description() : CustomText
        {
            return this._1724546052description;
        }// end function

        public function set description(param1:CustomText) : void
        {
            var _loc_2:* = this._1724546052description;
            if (_loc_2 !== param1)
            {
                this._1724546052description = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "description", _loc_2, param1));
            }
            return;
        }// end function

        public function get headline() : Label
        {
            return this._1115058732headline;
        }// end function

        public function get text() : String
        {
            return this._text;
        }// end function

        public function set headline(param1:Label) : void
        {
            var _loc_2:* = this._1115058732headline;
            if (_loc_2 !== param1)
            {
                this._1115058732headline = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "headline", _loc_2, param1));
            }
            return;
        }// end function

        override public function initialize() : void
        {
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            super.initialize();
            return;
        }// end function

    }
}
