package GUI.GAME
{
    import Communication.VO.*;
    import GUI.*;
    import GUI.Components.*;
    import GUI.Effects.*;
    import Interface.*;
    import NewQuestSystem.Client.*;
    import __AS3__.vec.*;
    import flash.display.*;
    import flash.events.*;
    import flash.geom.*;
    import mx.collections.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.effects.easing.*;
    import mx.events.*;

    public class cHintPointer extends cGuiBaseElement
    {
        private var mMinBounceCount:Number;
        private var mType:int;
        private var mGI:cGameInterface;
        private var mCurrentPointer:Image;
        private var mBounce:BounceMove;
        protected var mPanel:HintPointer;
        private const BOUNCE_SIZE:int = 20;
        private var mPointToX:int;
        private var mPointToY:int;
        private var mTarget:DisplayObject;
        private var mHints:Vector.<QuestHint>;
        private const BOUNCE_DURATION:int = 300;
        private var mActiveHintIndex:int;
        private var mActiveHint:QuestHint;
        public static const SOUTH_WEST:int = 2;
        public static const NEW_QUEST:int = 8;
        public static const NORTH:int = 4;
        public static const NORTH_WEST:int = 3;
        public static const SOUTH:int = 6;
        public static const SOUTH_EAST:int = 1;
        public static const COMPLETED_QUEST:int = 9;
        public static const WEST:int = 7;
        public static const NORTH_EAST:int = 0;
        public static const EAST:int = 5;

        public function cHintPointer()
        {
            return;
        }// end function

        public function BouncePointer(param1:int, param2:Number, param3:Number, param4:int = 0) : void
        {
            this.mMinBounceCount = param4;
            if (!this.mBounce)
            {
                this.mBounce = new BounceMove(this.mPanel);
                this.mBounce.easingFunction = Cubic.easeOut;
                this.mBounce.duration = this.BOUNCE_DURATION;
            }
            this.mBounce.xFrom = this.mPanel.x;
            this.mBounce.yFrom = this.mPanel.y;
            this.mBounce.xTo = this.mBounce.xFrom + param2;
            this.mBounce.yTo = this.mBounce.yFrom + param3;
            this.mBounce.bounceCount = param1;
            this.mBounce.play();
            return;
        }// end function

        private function PointTo(param1:DisplayObject, param2:int, param3:int) : void
        {
            this.mTarget = param1;
            this.mTarget.addEventListener(MouseEvent.CLICK, this.HintCompleted);
            var _loc_4:* = new Point(0, 0);
            _loc_4 = param1.localToGlobal(_loc_4);
            this.mPointToX = _loc_4.x + param1.width / 2 + param2;
            this.mPointToY = _loc_4.y + param1.height / 2 + param3;
            Show();
            return;
        }// end function

        public function SetData(param1) : void
        {
            if (param1.length == 0)
            {
                return;
            }
            this.mHints = param1;
            this.mActiveHintIndex = 0;
            this.ActivateNextHint(null);
            return;
        }// end function

        private function ActivateNextHint(event:Event) : void
        {
            var _loc_2:DisplayObject = null;
            if (this.mActiveHintIndex > (this.mHints.length - 1))
            {
                return;
            }
            Application.application.stage.addEventListener(Event.RESIZE, this.RepositionPointer);
            this.mActiveHint = this.mHints[this.mActiveHintIndex];
            switch(this.mActiveHint.mPointTo)
            {
                case "ActionBarButton01":
                {
                    _loc_2 = Application.application.GAMESTATE_ID_ACTIONBAR.actionBarLeft.btnActionBar01;
                    break;
                }
                case "ActionBarButton02":
                {
                    _loc_2 = Application.application.GAMESTATE_ID_ACTIONBAR.actionBarLeft.btnActionBar02;
                    break;
                }
                case "ActionBarButton03":
                {
                    _loc_2 = Application.application.GAMESTATE_ID_ACTIONBAR.actionBarLeft.btnActionBar03;
                    break;
                }
                case "ActionBarButton04":
                {
                    _loc_2 = Application.application.GAMESTATE_ID_ACTIONBAR.actionBarLeft.btnActionBar04;
                    break;
                }
                case "ActionBarButton05":
                {
                    _loc_2 = Application.application.GAMESTATE_ID_ACTIONBAR.actionBarCenter.btnActionBar05;
                    break;
                }
                case "ActionBarButton06":
                {
                    _loc_2 = Application.application.GAMESTATE_ID_ACTIONBAR.actionBarRight.btnActionBar06;
                    break;
                }
                case "ActionBarButton07":
                {
                    _loc_2 = Application.application.GAMESTATE_ID_ACTIONBAR.actionBarRight.btnActionBar07;
                    break;
                }
                case "ActionBarButton08":
                {
                    _loc_2 = Application.application.GAMESTATE_ID_ACTIONBAR.actionBarRight.btnActionBar08;
                    break;
                }
                case "ActionBarButton09":
                {
                    _loc_2 = Application.application.GAMESTATE_ID_ACTIONBAR.actionBarRight.btnActionBar09;
                    break;
                }
                case "QuestButton":
                {
                    _loc_2 = Application.application.GAMESTATE_ID_AVATAR.btnQuestBook;
                    break;
                }
                default:
                {
                    break;
                }
            }
            this.PointTo(_loc_2, this.mActiveHint.mOffsetX, this.mActiveHint.mOffsetY);
            this.SetPointerType(this.mActiveHint.mType);
            return;
        }// end function

        private function PointToPosition(param1:int, param2:int) : void
        {
            this.mPointToX = param1;
            this.mPointToY = param2;
            return;
        }// end function

        public function SetDataAsArrayCollection(param1:ArrayCollection) : void
        {
            var _loc_2:dQuestDefinitionHintVO = null;
            var _loc_3:QuestHint = null;
            if (param1.length == 0)
            {
                return;
            }
            this.mHints = new Vector.<QuestHint>;
            for each (_loc_2 in param1)
            {
                
                _loc_3 = new QuestHint();
                _loc_3.mType = _loc_2.direction;
                _loc_3.mName_string = _loc_2.name_string;
                _loc_3.mOffsetX = _loc_2.offsetX;
                _loc_3.mOffsetY = _loc_2.offsetY;
                _loc_3.mPointTo = _loc_2.pointTo;
                this.mHints.push(_loc_3);
            }
            this.mActiveHintIndex = 0;
            this.ActivateNextHint(null);
            return;
        }// end function

        private function RepositionPointer(event:Event) : void
        {
            this.Hide();
            var _loc_2:String = this;
            var _loc_3:* = this.mActiveHintIndex - 1;
            _loc_2.mActiveHintIndex = _loc_3;
            this.PointTo(this.mTarget, this.mActiveHint.mOffsetX, this.mActiveHint.mOffsetY);
            return;
        }// end function

        private function HintCompleted(event:MouseEvent) : void
        {
            if (this.mTarget)
            {
                this.mTarget.removeEventListener(MouseEvent.CLICK, this.ActivateNextHint);
                this.StopBouncing();
                this.Hide();
            }
            return;
        }// end function

        public function StopBouncing() : void
        {
            if (!this.mBounce)
            {
                return;
            }
            Application.application.stage.removeEventListener(Event.RESIZE, this.RepositionPointer);
            var _loc_1:String = this;
            var _loc_2:* = this.mActiveHintIndex + 1;
            _loc_1.mActiveHintIndex = _loc_2;
            this.mBounce.addEventListener(EffectEvent.EFFECT_END, this.ActivateNextHint);
            this.mBounce.end();
            this.mBounce = null;
            return;
        }// end function

        private function EnterPointerState(event:FlexEvent) : void
        {
            switch(event.currentTarget)
            {
                case this.mPanel.stateN:
                {
                    this.mPanel.x = this.mPointToX - this.mPanel.width / 2;
                    this.mPanel.y = this.mPointToY;
                    this.BouncePointer(-1, 0, this.BOUNCE_SIZE);
                    break;
                }
                case this.mPanel.stateNE:
                {
                    this.mPanel.x = this.mPointToX - this.mPanel.width;
                    this.mPanel.y = this.mPointToY;
                    this.BouncePointer(-1, -this.BOUNCE_SIZE, this.BOUNCE_SIZE);
                    break;
                }
                case this.mPanel.stateE:
                {
                    this.mPanel.x = this.mPointToX - this.mPanel.width;
                    this.mPanel.y = this.mPointToY - this.mPanel.height / 2;
                    this.BouncePointer(-1, -this.BOUNCE_SIZE, 0);
                    break;
                }
                case this.mPanel.stateSE:
                {
                    this.mPanel.x = this.mPointToX - this.mPanel.width;
                    this.mPanel.y = this.mPointToY - this.mPanel.height;
                    this.BouncePointer(-1, -this.BOUNCE_SIZE, -this.BOUNCE_SIZE);
                    break;
                }
                case this.mPanel.stateS:
                {
                    this.mPanel.x = this.mPointToX - this.mPanel.width / 2;
                    this.mPanel.y = this.mPointToY - this.mPanel.height;
                    this.BouncePointer(-1, 0, -this.BOUNCE_SIZE);
                    break;
                }
                case this.mPanel.stateSW:
                {
                    this.mPanel.x = this.mPointToX;
                    this.mPanel.y = this.mPointToY - this.mPanel.height;
                    this.BouncePointer(-1, this.BOUNCE_SIZE, -this.BOUNCE_SIZE);
                    break;
                }
                case this.mPanel.stateNewQuest:
                case this.mPanel.stateCompletedQuest:
                case this.mPanel.stateW:
                {
                    this.mPanel.x = this.mPointToX;
                    this.mPanel.y = this.mPointToY - this.mPanel.height / 2;
                    this.BouncePointer(-1, this.BOUNCE_SIZE, 0);
                    break;
                }
                case this.mPanel.stateNW:
                {
                    this.mPanel.x = this.mPointToX;
                    this.mPanel.y = this.mPointToY;
                    this.BouncePointer(-1, this.BOUNCE_SIZE, this.BOUNCE_SIZE);
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        override public function Hide() : void
        {
            this.StopBouncing();
            this.mPanel.currentState = "";
            super.Hide();
            return;
        }// end function

        private function SetPointerType(param1:int) : void
        {
            this.mType = param1;
            switch(this.mType)
            {
                case NORTH:
                {
                    this.mPanel.currentState = "N";
                    break;
                }
                case NORTH_EAST:
                {
                    this.mPanel.currentState = "NE";
                    break;
                }
                case EAST:
                {
                    this.mPanel.currentState = "E";
                    break;
                }
                case SOUTH_EAST:
                {
                    this.mPanel.currentState = "SE";
                    break;
                }
                case SOUTH:
                {
                    this.mPanel.currentState = "S";
                    break;
                }
                case SOUTH_WEST:
                {
                    this.mPanel.currentState = "SW";
                    break;
                }
                case WEST:
                {
                    this.mPanel.currentState = "W";
                    break;
                }
                case NORTH_WEST:
                {
                    this.mPanel.currentState = "NW";
                    break;
                }
                case NEW_QUEST:
                {
                    this.mPanel.currentState = "NewQuest";
                    break;
                }
                case COMPLETED_QUEST:
                {
                    this.mPanel.currentState = "CompletedQuest";
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

        public function Init(param1:HintPointer) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mPanel = param1;
            this.mPanel.stateN.addEventListener(FlexEvent.ENTER_STATE, this.EnterPointerState);
            this.mPanel.stateNE.addEventListener(FlexEvent.ENTER_STATE, this.EnterPointerState);
            this.mPanel.stateE.addEventListener(FlexEvent.ENTER_STATE, this.EnterPointerState);
            this.mPanel.stateSE.addEventListener(FlexEvent.ENTER_STATE, this.EnterPointerState);
            this.mPanel.stateS.addEventListener(FlexEvent.ENTER_STATE, this.EnterPointerState);
            this.mPanel.stateSW.addEventListener(FlexEvent.ENTER_STATE, this.EnterPointerState);
            this.mPanel.stateW.addEventListener(FlexEvent.ENTER_STATE, this.EnterPointerState);
            this.mPanel.stateNW.addEventListener(FlexEvent.ENTER_STATE, this.EnterPointerState);
            this.mPanel.stateNewQuest.addEventListener(FlexEvent.ENTER_STATE, this.EnterPointerState);
            this.mPanel.stateCompletedQuest.addEventListener(FlexEvent.ENTER_STATE, this.EnterPointerState);
            return;
        }// end function

    }
}
