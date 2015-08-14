package GUI.GAME
{
    import Communication.VO.*;
    import Enums.*;
    import GUI.Components.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Loca.*;
    import Interface.*;
    import MilitarySystem.*;
    import __AS3__.vec.*;
    import flash.events.*;
    import mx.core.*;
    import nLib.*;

    public class cBattleWindow extends cBasicPanel
    {
        private var mReport:XML;
        private var mPhase:int = 0;
        private var mGI:cGameInterface;
        private var mAttack:int = 0;
        private var mRound:int = 0;
        private const NEXT_ROUND:int = 1;
        private var mCasualtiesGroup:int = 0;
        private const NEXT_PHASE:int = 2;
        private var mNextTickTime:int;
        private const HIGHLIGHT_ATTACKING_UNIT:int = 7;
        private const DISPLAY_RESULTS:int = 14;
        private const NONE:int = -1;
        private const HIDE_CASUALTIES_HIGHLIGHT:int = 13;
        private var mSquadsDefender:Vector.<dSquadVO>;
        private const BATTLE_ENDED:int = 15;
        private var mSquadsAttacker:Vector.<dSquadVO>;
        private var mCurrentCasualtiesGroup:XML;
        private var mAttackGroup:int = 0;
        private const NEXT_ATTACK_DEFENDERS:int = 6;
        private var mNextTickDuration:int;
        private var mCurrentAttacksGroup:XML;
        private const DISPLAY_CASUALTIES:int = 12;
        private var mCurrentPhase:XML;
        private const NEXT_ATTACK_ATTACKERS:int = 5;
        protected var mPanel:BattleWindow;
        private const HIGHLIGHT_DEFENDING_UNIT:int = 8;
        private var mCurrentCasualty:XML;
        private var mCurrentRound:XML;
        private var mCurrentAttack:XML;
        private var mAvailableSlotsDefender:Vector.<BattleSlotItemRenderer>;
        private var mCasualty:int = 0;
        private var mNextTick:int;
        private const ROTATE_INDICATOR_RIGHT:int = 4;
        private var mSlotsDefender:Object;
        private var mAvailableSlotsAttacker:Vector.<BattleSlotItemRenderer>;
        private const ROTATE_INDICATOR_LEFT:int = 3;
        private var mSlotsAttacker:Object;
        private const MAKE_DAMAGE:int = 11;
        private const SETUP_BATTLE:int = 0;
        private const DEFENDER:int = 1;
        private const REMOVE_HIGHLIGHTS:int = 9;
        private var mSlotPreferences:Object;
        private const DISPLAY_STRIKE:int = 10;
        private const ATTACKER:int = 0;

        public function cBattleWindow()
        {
            this.mSlotPreferences = new Object();
            return;
        }// end function

        private function ParseSlotPreferences(param1) : void
        {
            var _loc_2:cXML = null;
            for each (_loc_2 in param1)
            {
                
                if (_loc_2.GetAttributeString_string("slot") != "" && _loc_2.GetAttributeString_string("group") == "Military")
                {
                    this.mSlotPreferences[_loc_2.GetAttributeString_string("name")] = _loc_2.GetAttributeInt("slot");
                }
            }
            return;
        }// end function

        public function SetData(param1:String) : void
        {
            var _loc_3:XML = null;
            this.Clear();
            this.mReport = new XML(param1);
            this.mPanel.attackerAvatar.data = this.mGI.mCurrentPlayer.GetPlayerListItem();
            this.mPanel.attackerNameLabel.text = this.mGI.mCurrentPlayer.GetPlayerListItem().username;
            var _loc_2:* = new dPlayerListItemVO();
            _loc_2.id = -1;
            _loc_2.avatarId = -1;
            _loc_2.username = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, "Bandit");
            this.mPanel.defenderAvatar.data = _loc_2;
            this.mPanel.defenderNameLabel.text = _loc_2.username;
            this.GetAvailableSlots();
            for each (_loc_3 in this.mReport.ArmyDescription.Army)
            {
                
                this.InitArmy(_loc_3);
            }
            this.DisplayArmies();
            return;
        }// end function

        private function ClosePanel(event:MouseEvent) : void
        {
            this.Hide();
            return;
        }// end function

        override public function Show() : void
        {
            globalFlash.gui.mDarkenPanel.Show();
            super.Show();
            return;
        }// end function

        public function Init(param1:BattleWindow) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.btnClose.addEventListener(MouseEvent.CLICK, this.ClosePanel);
            this.ParseSlotPreferences(global.gfxSettingsRootXML.MoveToSubNode("GameObjects").MoveToSubNode("ResourceIcons").CreateChildrenArray());
            return;
        }// end function

        private function GetNextAttackGroup() : Boolean
        {
            var _loc_1:* = this.mCurrentPhase.child("Attacks");
            if (_loc_1 && this.mAttackGroup < _loc_1.length())
            {
                this.mCurrentAttacksGroup = _loc_1[this.mAttackGroup];
                var _loc_2:String = this;
                var _loc_3:* = this.mAttackGroup + 1;
                _loc_2.mAttackGroup = _loc_3;
                this.mAttack = 0;
                this.mCurrentAttack = null;
                this.DisableNotEngagedUnits();
                return true;
            }
            return false;
        }// end function

        private function Clear() : void
        {
            this.mPanel.overlayTextPhase.visible = false;
            this.mPanel.overlayTextRound.visible = false;
            this.mPanel.rotationContainer.rotation = 0;
            return;
        }// end function

        private function DisplayArmies() : void
        {
            var _loc_2:int = 0;
            var _loc_3:dSquadVO = null;
            var _loc_4:String = null;
            var _loc_5:int = 0;
            var _loc_6:int = 0;
            var _loc_7:BattleSlotItemRenderer = null;
            var _loc_1:* = new Vector.<dSquadVO>;
            _loc_2 = this.mPanel.attackerAvatar.GetColorIndex();
            for each (_loc_3 in this.mSquadsAttacker)
            {
                
                _loc_4 = "attacker" + this.GetPrefferedSlotName(_loc_3.GetType_string());
                _loc_5 = -1;
                _loc_6 = 0;
                while (_loc_6 < this.mAvailableSlotsAttacker.length)
                {
                    
                    if (this.mAvailableSlotsAttacker[_loc_6].id == _loc_4)
                    {
                        _loc_5 = _loc_6;
                        break;
                    }
                    _loc_6++;
                }
                if (_loc_5 > -1)
                {
                    this.mAvailableSlotsAttacker[_loc_5].SetSquad(_loc_3, _loc_2);
                    this.mSlotsAttacker[_loc_3.GetType_string()] = this.mAvailableSlotsAttacker[_loc_5];
                    this.mAvailableSlotsAttacker.splice(_loc_5, 1);
                    continue;
                }
                _loc_1.push(_loc_3);
            }
            for each (_loc_3 in _loc_1)
            {
                
                _loc_7 = this.mAvailableSlotsAttacker.shift();
                if (_loc_7 == null)
                {
                    break;
                }
                _loc_7.SetSquad(_loc_3);
                this.mSlotsAttacker[_loc_3.GetType_string()] = _loc_7;
            }
            _loc_2 = this.mPanel.defenderAvatar.GetColorIndex();
            for each (_loc_3 in this.mSquadsDefender)
            {
                
                _loc_4 = "defender" + this.GetPrefferedSlotName(_loc_3.GetType_string());
                _loc_5 = -1;
                _loc_6 = 0;
                while (_loc_6 < this.mAvailableSlotsDefender.length)
                {
                    
                    if (this.mAvailableSlotsDefender[_loc_6].id == _loc_4)
                    {
                        _loc_5 = _loc_6;
                        break;
                    }
                    _loc_6++;
                }
                if (_loc_5 > -1)
                {
                    this.mAvailableSlotsDefender[_loc_5].SetSquad(_loc_3, _loc_2);
                    this.mAvailableSlotsDefender[_loc_5].disabled = true;
                    this.mSlotsDefender[_loc_3.GetType_string()] = this.mAvailableSlotsDefender[_loc_5];
                    this.mAvailableSlotsDefender.splice(_loc_5, 1);
                    continue;
                }
                _loc_1.push(_loc_3);
            }
            for each (_loc_3 in _loc_1)
            {
                
                _loc_7 = this.mAvailableSlotsDefender.shift();
                if (_loc_7 == null)
                {
                    break;
                }
                _loc_7.SetSquad(_loc_3);
                this.mSlotsDefender[_loc_3.GetType_string()] = _loc_7;
            }
            this.SetNextTick(this.SETUP_BATTLE);
            this.ResetBattle();
            this.StartPlayback();
            return;
        }// end function

        private function Perform(event:Event) : void
        {
            if (gMisc.GetTimeSinceStartup() >= this.mNextTickTime)
            {
                this.PerformBattleTick();
            }
            return;
        }// end function

        private function StopPlayback() : void
        {
            this.mPanel.removeEventListener(Event.ENTER_FRAME, this.Perform);
            return;
        }// end function

        override public function Hide() : void
        {
            this.StopPlayback();
            globalFlash.gui.mDarkenPanel.Hide();
            super.Hide();
            return;
        }// end function

        private function GetPrefferedSlotName(param1:String) : String
        {
            var _loc_2:* = this.mSlotPreferences[param1];
            return "Slot" + (_loc_2 < 10 ? ("0" + _loc_2) : (_loc_2.toString()));
        }// end function

        private function StartPlayback() : void
        {
            this.mPanel.addEventListener(Event.ENTER_FRAME, this.Perform);
            return;
        }// end function

        private function GetNextCasualty() : Boolean
        {
            if (!this.mCasualtiesGroup)
            {
                return false;
            }
            var _loc_1:* = this.mCurrentCasualtiesGroup.child("Casualty");
            if (_loc_1 && this.mCasualty < _loc_1.length())
            {
                this.mCurrentCasualty = _loc_1[this.mCasualty];
                var _loc_2:String = this;
                var _loc_3:* = this.mCasualty + 1;
                _loc_2.mCasualty = _loc_3;
                return true;
            }
            return this.GetNextCasualtiesGroup() && this.GetNextCasualty();
        }// end function

        private function PerformBattleTick() : void
        {
            var _loc_1:BattleSlotItemRenderer = null;
            var _loc_2:int = 0;
            this.mNextTickTime = this.mNextTickTime + this.mNextTickDuration;
            switch(this.mNextTick)
            {
                case this.SETUP_BATTLE:
                {
                    this.SetNextTick(this.NEXT_ROUND);
                    break;
                }
                case this.NEXT_ROUND:
                {
                    if (this.GetNextRound())
                    {
                        this.SetNextTick(this.NEXT_PHASE);
                    }
                    else
                    {
                        this.SetNextTick(this.DISPLAY_RESULTS);
                    }
                    break;
                }
                case this.NEXT_PHASE:
                {
                    if (this.mPanel.overlayTextRound.visible)
                    {
                        this.mPanel.overlayTextRound.visible = false;
                    }
                    if (this.GetNextPhase())
                    {
                        this.SetNextTick(this.ROTATE_INDICATOR_RIGHT);
                    }
                    else
                    {
                        this.SetNextTick(this.NEXT_ROUND);
                    }
                    break;
                }
                case this.ROTATE_INDICATOR_LEFT:
                {
                    this.mPanel.rotateToAttacker.play();
                    this.SetNextTick(this.HIGHLIGHT_ATTACKING_UNIT);
                    break;
                }
                case this.ROTATE_INDICATOR_RIGHT:
                {
                    if (this.mPanel.overlayTextPhase.visible)
                    {
                        this.mPanel.overlayTextPhase.visible = false;
                    }
                    this.mPanel.rotateToDefender.play();
                    this.SetNextTick(this.HIGHLIGHT_ATTACKING_UNIT);
                    break;
                }
                case this.HIGHLIGHT_ATTACKING_UNIT:
                {
                    if (this.GetNextAttack())
                    {
                        if (this.mCurrentAttacksGroup.@group == "Attackers")
                        {
                            this.mSlotsAttacker[this.mCurrentAttack.@attackingUnitType].highlightAttacker = true;
                        }
                        else if (this.mCurrentAttacksGroup.@group == "Defenders")
                        {
                            this.mSlotsDefender[this.mCurrentAttack.@attackingUnitType].highlightAttacker = true;
                        }
                        this.SetNextTick(this.HIGHLIGHT_DEFENDING_UNIT);
                    }
                    else
                    {
                        this.SetNextTick(this.DISPLAY_CASUALTIES);
                    }
                    break;
                }
                case this.HIGHLIGHT_DEFENDING_UNIT:
                {
                    if (this.mCurrentAttacksGroup.@group == "Attackers")
                    {
                        this.mSlotsDefender[this.mCurrentAttack.@defendingUnitType].highlightDefender = true;
                    }
                    else if (this.mCurrentAttacksGroup.@group == "Defenders")
                    {
                        this.mSlotsAttacker[this.mCurrentAttack.@defendingUnitType].highlightDefender = true;
                    }
                    this.SetNextTick(this.DISPLAY_STRIKE);
                    break;
                }
                case this.DISPLAY_STRIKE:
                {
                    if (this.mCurrentAttacksGroup.@group == "Attackers")
                    {
                        _loc_1 = this.mSlotsDefender[this.mCurrentAttack.@defendingUnitType];
                    }
                    else if (this.mCurrentAttacksGroup.@group == "Defenders")
                    {
                        _loc_1 = this.mSlotsAttacker[this.mCurrentAttack.@defendingUnitType];
                    }
                    this.mPanel.attackAnimation.x = _loc_1.parent.x + _loc_1.x - 20;
                    this.mPanel.attackAnimation.y = _loc_1.parent.y + _loc_1.y - 40;
                    this.mPanel.attackAnimation.visible = true;
                    this.SetNextTick(this.MAKE_DAMAGE);
                    break;
                }
                case this.MAKE_DAMAGE:
                {
                    _loc_1 = null;
                    if (this.mCurrentAttacksGroup.@group == "Attackers")
                    {
                        _loc_1 = this.mSlotsDefender[this.mCurrentAttack.@defendingUnitType];
                    }
                    else if (this.mCurrentAttacksGroup.@group == "Defenders")
                    {
                        _loc_1 = this.mSlotsAttacker[this.mCurrentAttack.@defendingUnitType];
                    }
                    _loc_1.MakeDamage(this.mCurrentAttack.@damage);
                    this.SetNextTick(this.REMOVE_HIGHLIGHTS);
                    break;
                }
                case this.REMOVE_HIGHLIGHTS:
                {
                    if (this.mCurrentAttacksGroup.@group == "Attackers")
                    {
                        this.mSlotsAttacker[this.mCurrentAttack.@attackingUnitType].highlightAttacker = false;
                        this.mSlotsDefender[this.mCurrentAttack.@defendingUnitType].highlightDefender = false;
                    }
                    else if (this.mCurrentAttacksGroup.@group == "Defenders")
                    {
                        this.mSlotsAttacker[this.mCurrentAttack.@defendingUnitType].highlightDefender = false;
                        this.mSlotsDefender[this.mCurrentAttack.@attackingUnitType].highlightAttacker = false;
                    }
                    if (this.mAttack == this.mCurrentAttacksGroup.child("Attack").length() && this.mCurrentAttacksGroup.@group == "Attackers")
                    {
                        this.SetNextTick(this.ROTATE_INDICATOR_LEFT);
                    }
                    else
                    {
                        this.SetNextTick(this.HIGHLIGHT_ATTACKING_UNIT);
                    }
                    break;
                }
                case this.DISPLAY_CASUALTIES:
                {
                    _loc_2 = 0;
                    while (this.GetNextCasualty())
                    {
                        
                        _loc_2++;
                        if (this.mCurrentCasualtiesGroup.@group == "Attackers")
                        {
                            _loc_1 = this.mSlotsAttacker[this.mCurrentCasualty.@unitType];
                        }
                        else if (this.mCurrentCasualtiesGroup.@group == "Defenders")
                        {
                            _loc_1 = this.mSlotsDefender[this.mCurrentCasualty.@unitType];
                        }
                        _loc_1.DisplayCasualties(this.mCurrentCasualty.@dead, this.mCurrentCasualty.@totalHealth);
                        _loc_1.damageHighlight = true;
                    }
                    if (_loc_2 > 0)
                    {
                        this.SetNextTick(this.HIDE_CASUALTIES_HIGHLIGHT);
                    }
                    else
                    {
                        this.SetNextTick(this.NEXT_PHASE);
                    }
                    break;
                }
                case this.HIDE_CASUALTIES_HIGHLIGHT:
                {
                    this.mCasualtiesGroup = 0;
                    this.mCasualty = 0;
                    this.GetNextCasualtiesGroup();
                    while (this.GetNextCasualty())
                    {
                        
                        if (this.mCurrentCasualtiesGroup.@group == "Attackers")
                        {
                            _loc_1 = this.mSlotsAttacker[this.mCurrentCasualty.@unitType];
                        }
                        else if (this.mCurrentCasualtiesGroup.@group == "Defenders")
                        {
                            _loc_1 = this.mSlotsDefender[this.mCurrentCasualty.@unitType];
                        }
                        _loc_1.damageHighlight = false;
                    }
                    this.SetNextTick(this.NEXT_PHASE);
                    break;
                }
                case this.DISPLAY_RESULTS:
                {
                    if (this.mReport.@resultMsg != null && this.mReport.@resultMsg.toString() != "")
                    {
                        this.mPanel.overlayTextPhase.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.MESSAGES, this.mReport.@resultMsg);
                        this.mPanel.overlayTextPhase.visible = true;
                    }
                    this.SetNextTick(this.BATTLE_ENDED);
                    break;
                }
                case this.BATTLE_ENDED:
                {
                    this.mPanel.overlayTextPhase.visible = false;
                    this.StopPlayback();
                    this.SetNextTick(this.NONE);
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        private function DisableNotEngagedUnits() : void
        {
            var _loc_2:XML = null;
            var _loc_3:String = null;
            var _loc_1:* = new Vector.<String>;
            if (this.mCurrentAttacksGroup.@group == "Attackers")
            {
                for each (_loc_2 in this.mCurrentAttacksGroup.child("Attack"))
                {
                    
                    _loc_1.push(_loc_2.@attackingUnitType);
                }
                for (_loc_3 in this.mSlotsAttacker)
                {
                    
                    (this.mSlotsAttacker[_loc_3] as BattleSlotItemRenderer).disabled = _loc_1.indexOf(_loc_3) == -1;
                }
                for (_loc_3 in this.mSlotsDefender)
                {
                    
                    (this.mSlotsDefender[_loc_3] as BattleSlotItemRenderer).disabled = false;
                }
            }
            else if (this.mCurrentAttacksGroup.@group == "Defenders")
            {
                for each (_loc_2 in this.mCurrentAttacksGroup.child("Attack"))
                {
                    
                    _loc_1.push(_loc_2.@attackingUnitType);
                }
                for (_loc_3 in this.mSlotsDefender)
                {
                    
                    (this.mSlotsDefender[_loc_3] as BattleSlotItemRenderer).disabled = _loc_1.indexOf(_loc_3) == -1;
                }
                for (_loc_3 in this.mSlotsAttacker)
                {
                    
                    (this.mSlotsAttacker[_loc_3] as BattleSlotItemRenderer).disabled = false;
                }
            }
            return;
        }// end function

        private function SetNextTick(param1:int) : void
        {
            this.mNextTick = param1;
            switch(this.mNextTick)
            {
                case this.SETUP_BATTLE:
                {
                    this.mNextTickTime = gMisc.GetTimeSinceStartup();
                    this.mNextTickDuration = 2000;
                    break;
                }
                case this.HIGHLIGHT_ATTACKING_UNIT:
                case this.HIGHLIGHT_DEFENDING_UNIT:
                {
                    this.mNextTickDuration = 300;
                    break;
                }
                case this.DISPLAY_STRIKE:
                {
                    this.mNextTickDuration = 1000;
                    break;
                }
                case this.DISPLAY_CASUALTIES:
                {
                    this.mNextTickDuration = 2000;
                    break;
                }
                case this.NEXT_ROUND:
                case this.NEXT_PHASE:
                {
                    this.mNextTickDuration = 2000;
                    break;
                }
                case this.DISPLAY_RESULTS:
                {
                    this.mNextTickDuration = 3500;
                    break;
                }
                case this.ROTATE_INDICATOR_LEFT:
                case this.ROTATE_INDICATOR_RIGHT:
                {
                    this.mNextTickDuration = 2000;
                    break;
                }
                case this.NEXT_ATTACK_ATTACKERS:
                case this.NEXT_ATTACK_DEFENDERS:
                case this.REMOVE_HIGHLIGHTS:
                case this.DISPLAY_RESULTS:
                case this.HIDE_CASUALTIES_HIGHLIGHT:
                {
                }
                default:
                {
                    this.mNextTickDuration = 200;
                    break;
                }
            }
            return;
        }// end function

        private function GetNextPhase() : Boolean
        {
            var _loc_1:* = this.mCurrentRound.child("Phase");
            if (_loc_1 && this.mPhase < _loc_1.length())
            {
                this.mCurrentPhase = _loc_1[this.mPhase];
                this.mPanel.phaseLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "BattlePhaseInitiative" + this.mCurrentPhase.@initiative);
                this.mPanel.overlayTextPhase.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "BattlePhaseInitiative" + this.mCurrentPhase.@initiative);
                this.mPanel.overlayTextPhase.visible = true;
                this.mAttackGroup = 0;
                this.mCurrentAttacksGroup = null;
                this.mCasualtiesGroup = 0;
                this.mCurrentCasualtiesGroup = null;
                var _loc_2:String = this;
                var _loc_3:* = this.mPhase + 1;
                _loc_2.mPhase = _loc_3;
                this.GetNextAttackGroup();
                this.GetNextCasualtiesGroup();
                return true;
            }
            return false;
        }// end function

        private function GetAvailableSlots() : void
        {
            var _loc_1:UIComponent = null;
            this.mAvailableSlotsAttacker = new Vector.<BattleSlotItemRenderer>;
            this.mAvailableSlotsDefender = new Vector.<BattleSlotItemRenderer>;
            this.mSlotsAttacker = new Object();
            this.mSlotsDefender = new Object();
            for each (_loc_1 in this.mPanel.attackerHolder.getChildren())
            {
                
                if (_loc_1 is BattleSlotItemRenderer)
                {
                    (_loc_1 as BattleSlotItemRenderer).Clear();
                    this.mAvailableSlotsAttacker.push(_loc_1);
                }
            }
            for each (_loc_1 in this.mPanel.defenderHolder.getChildren())
            {
                
                if (_loc_1 is BattleSlotItemRenderer)
                {
                    (_loc_1 as BattleSlotItemRenderer).Clear();
                    this.mAvailableSlotsDefender.push(_loc_1);
                }
            }
            return;
        }// end function

        private function GetNextRound() : Boolean
        {
            var _loc_1:* = this.mReport.child("Round");
            if (_loc_1 && this.mRound < _loc_1.length())
            {
                this.mCurrentRound = _loc_1[this.mRound];
                this.mPanel.roundLabel.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "BattleRound", [((this.mRound + 1)).toString()]);
                this.mPanel.overlayTextRound.text = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "BattleRound", [((this.mRound + 1)).toString()]);
                this.mPanel.overlayTextRound.visible = true;
                this.mPanel.phaseLabel.text = "";
                this.mPhase = 0;
                this.mCurrentPhase = null;
                var _loc_2:String = this;
                var _loc_3:* = this.mRound + 1;
                _loc_2.mRound = _loc_3;
                return true;
            }
            return false;
        }// end function

        private function ResetBattle() : void
        {
            this.mRound = 0;
            this.mPhase = 0;
            this.mAttackGroup = 0;
            this.mAttack = 0;
            this.mCasualtiesGroup = 0;
            this.mCasualty = 0;
            this.mPanel.roundLabel.text = "";
            this.mPanel.phaseLabel.text = "";
            return;
        }// end function

        private function GetNextCasualtiesGroup() : Boolean
        {
            var _loc_1:* = this.mCurrentPhase.child("Casualties");
            if (_loc_1 && this.mCasualtiesGroup < _loc_1.length())
            {
                this.mCurrentCasualtiesGroup = _loc_1[this.mCasualtiesGroup];
                var _loc_2:String = this;
                var _loc_3:* = this.mCasualtiesGroup + 1;
                _loc_2.mCasualtiesGroup = _loc_3;
                this.mCurrentCasualty = null;
                this.mCasualty = 0;
                return true;
            }
            return false;
        }// end function

        private function GetNextAttack() : Boolean
        {
            if (!this.mCurrentAttacksGroup)
            {
                return false;
            }
            var _loc_1:* = this.mCurrentAttacksGroup.child("Attack");
            if (_loc_1 && this.mAttack < _loc_1.length())
            {
                this.mCurrentAttack = _loc_1[this.mAttack];
                var _loc_2:String = this;
                var _loc_3:* = this.mAttack + 1;
                _loc_2.mAttack = _loc_3;
                return true;
            }
            return this.GetNextAttackGroup() && this.GetNextAttack();
        }// end function

        private function InitArmy(param1:XML) : void
        {
            var _loc_3:XML = null;
            var _loc_4:dSquadVO = null;
            var _loc_2:* = new Vector.<dSquadVO>;
            if (param1.@group == "Attackers")
            {
                this.mSquadsAttacker = _loc_2;
            }
            else if (param1.@group == "Defenders")
            {
                this.mSquadsDefender = _loc_2;
            }
            else
            {
                gMisc.ConsoleOut("Could not interpret army group: " + param1.@group);
                return;
            }
            for each (_loc_3 in param1.Squad)
            {
                
                _loc_4 = new dSquadVO().init(_loc_3.@unitType, _loc_3.@amount, cMilitaryUnitDescription.GetHitPointsForUnit(_loc_3.@unitType));
                _loc_4.mTotalHealth = _loc_3.@totalHealth;
                _loc_2.push(_loc_4);
            }
            return;
        }// end function

    }
}
