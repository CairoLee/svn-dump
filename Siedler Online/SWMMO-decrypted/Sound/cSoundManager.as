package Sound
{
    import flash.events.*;
    import flash.media.*;
    import flash.net.*;
    import mx.events.*;
    import nLib.*;

    public class cSoundManager extends Object implements IEventDispatcher
    {
        private var _1255804266mEffectsMuted:Boolean = false;
        private var _bindingEventDispatcher:EventDispatcher;
        private const LOOP_EXTENSION:String = ".mp3";
        private var mLoopsChannels:Object;
        private var mEffects:Object;
        private var _753370281mLoopsMuted:Boolean = false;
        private var mEffectsFolder:String;
        private var mInitialized:Boolean = false;
        private var mLoops:Object;
        private var mXml:cXML;
        private var mLoopsFolder:String;
        private const EFFECT_EXTENSION:String = ".mp3";
        private static var mInstance:cSoundManager;

        public function cSoundManager(param1:cSingletonEnforcer)
        {
            this._bindingEventDispatcher = new EventDispatcher(IEventDispatcher(this));
            if (param1 == null)
            {
                throw new Error("cSoundManager is a Sigleton. Use GetInstance() to use this class.");
            }
            return;
        }// end function

        public function get mLoopsMuted() : Boolean
        {
            return this._753370281mLoopsMuted;
        }// end function

        public function PlayEffect(param1:String, param2:String = "") : void
        {
            var _name:* = param1;
            var _exceptionName:* = param2;
            if (this.mEffectsMuted)
            {
                return;
            }
            if (!this.mEffects)
            {
                return;
            }
            var sound:* = this.mEffects[_name + "_" + _exceptionName] ? (this.mEffects[_name + "_" + _exceptionName]) : (this.mEffects[_name]);
            if (sound)
            {
                try
                {
                    sound.play();
                }
                catch (error:Error)
                {
                    gMisc.ConsoleOut("Error loading sound");
                }
            }
            return;
        }// end function

        public function removeEventListener(param1:String, param2:Function, param3:Boolean = false) : void
        {
            this._bindingEventDispatcher.removeEventListener(param1, param2, param3);
            return;
        }// end function

        public function addEventListener(param1:String, param2:Function, param3:Boolean = false, param4:int = 0, param5:Boolean = false) : void
        {
            this._bindingEventDispatcher.addEventListener(param1, param2, param3, param4, param5);
            return;
        }// end function

        public function dispatchEvent(event:Event) : Boolean
        {
            return this._bindingEventDispatcher.dispatchEvent(event);
        }// end function

        public function get mEffectsMuted() : Boolean
        {
            return this._1255804266mEffectsMuted;
        }// end function

        public function set mLoopsMuted(param1:Boolean) : void
        {
            var _loc_2:* = this._753370281mLoopsMuted;
            if (_loc_2 !== param1)
            {
                this._753370281mLoopsMuted = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mLoopsMuted", _loc_2, param1));
            }
            return;
        }// end function

        public function willTrigger(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.willTrigger(param1);
        }// end function

        public function set mEffectsMuted(param1:Boolean) : void
        {
            var _loc_2:* = this._1255804266mEffectsMuted;
            if (_loc_2 !== param1)
            {
                this._1255804266mEffectsMuted = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "mEffectsMuted", _loc_2, param1));
            }
            return;
        }// end function

        public function ToggleEffects() : void
        {
            this.mEffectsMuted = !this.mEffectsMuted;
            cLocalSettingsManager.effectsMuted = this.mEffectsMuted;
            if (!this.mEffectsMuted && !this.mInitialized)
            {
                this.Init();
            }
            return;
        }// end function

        private function IoSecurityErrorHandler(event:IOErrorEvent) : void
        {
            gMisc.Assert(true, "Sound could not be loaded: " + event.target.url);
            return;
        }// end function

        public function hasEventListener(param1:String) : Boolean
        {
            return this._bindingEventDispatcher.hasEventListener(param1);
        }// end function

        public function Init() : void
        {
            this.mEffectsFolder = gGfxResource.GetGfxFolder_string() + "sounds/effects/";
            this.mLoopsFolder = gGfxResource.GetGfxFolder_string() + "sounds/loops/";
            this.mEffects = {};
            this.mLoops = {};
            this.mLoopsChannels = {};
            this.mEffectsMuted = cLocalSettingsManager.effectsMuted;
            this.mLoopsMuted = cLocalSettingsManager.loopsMuted;
            if (this.mEffectsMuted && this.mLoopsMuted)
            {
                return;
            }
            this.mXml = new cXML();
            this.mXml.LoadFile(gGfxResource.GetGfxFolder_string() + "sound_settings.xml", this.LoadSettingsComplete, false, definesMaster.LOAD_ENC);
            return;
        }// end function

        private function LoadSound(param1:String) : Sound
        {
            var _loc_2:* = new Sound(new URLRequest(param1));
            _loc_2.addEventListener(IOErrorEvent.IO_ERROR, this.IoSecurityErrorHandler, false, 0, true);
            _loc_2.addEventListener(SecurityErrorEvent.SECURITY_ERROR, this.IoSecurityErrorHandler, false, 0, true);
            return _loc_2;
        }// end function

        private function LoadSettingsComplete(event:Event) : void
        {
            var _loc_2:cXML = null;
            var _loc_3:cXML = null;
            var _loc_4:String = null;
            var _loc_5:String = null;
            var _loc_6:cXML = null;
            var _loc_7:String = null;
            this.mXml.SetXMLString((event.currentTarget as URLLoader).data);
            for each (_loc_2 in this.mXml.MoveToSubNode("Effects").CreateChildrenArray())
            {
                
                _loc_4 = _loc_2.GetAttributeString_string("name");
                _loc_5 = this.mEffectsFolder + _loc_2.GetAttributeString_string("file") + this.EFFECT_EXTENSION;
                if (_loc_2.GetAttributeString_string("file") != "")
                {
                    this.mEffects[_loc_4] = this.LoadSound(_loc_5);
                }
                for each (_loc_6 in _loc_2.CreateChildrenArray())
                {
                    
                    _loc_7 = _loc_6.GetAttributeString_string("name");
                    _loc_5 = this.mEffectsFolder + _loc_6.GetAttributeString_string("file") + this.EFFECT_EXTENSION;
                    this.mEffects[_loc_4 + "_" + _loc_7] = this.LoadSound(_loc_5);
                }
            }
            for each (_loc_3 in this.mXml.MoveToSubNode("Loops").CreateChildrenArray())
            {
                
                _loc_4 = _loc_3.GetAttributeString_string("name");
                _loc_5 = this.mLoopsFolder + _loc_3.GetAttributeString_string("file") + this.LOOP_EXTENSION;
                this.mLoops[_loc_4] = this.LoadSound(_loc_5);
                if (!this.mLoopsMuted)
                {
                    this.mLoopsChannels[_loc_4] = (this.mLoops[_loc_4] as Sound).play(0, int.MAX_VALUE);
                }
            }
            this.mInitialized = true;
            return;
        }// end function

        public function ToggleLoops() : void
        {
            var soundChannel:SoundChannel;
            var key:String;
            this.mLoopsMuted = !this.mLoopsMuted;
            cLocalSettingsManager.loopsMuted = this.mLoopsMuted;
            if (this.mLoopsMuted)
            {
                var _loc_2:int = 0;
                var _loc_3:* = this.mLoopsChannels;
                while (_loc_3 in _loc_2)
                {
                    
                    soundChannel = _loc_3[_loc_2];
                    soundChannel.stop();
                }
            }
            else
            {
                var _loc_2:int = 0;
                var _loc_3:* = this.mLoops;
                do
                {
                    
                    key = _loc_3[_loc_2];
                    try
                    {
                        this.mLoopsChannels[key] = this.mLoops[key].play(0, int.MAX_VALUE);
                    }
                    catch (error:Error)
                    {
                        gMisc.ConsoleOut("Error loading sound");
                    }
                }while (_loc_3 in _loc_2)
            }
            if (!this.mLoopsMuted && !this.mInitialized)
            {
                this.Init();
            }
            return;
        }// end function

        public static function GetInstance() : cSoundManager
        {
            if (mInstance == null)
            {
                mInstance = new cSoundManager(new cSingletonEnforcer());
            }
            return mInstance;
        }// end function

    }
}
