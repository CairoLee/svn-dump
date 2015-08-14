package GUI.Components
{
    import flash.events.*;
    import flash.net.*;
    import flash.utils.*;
    import mx.binding.*;
    import mx.containers.*;
    import mx.controls.*;
    import mx.core.*;
    import mx.events.*;
    import mx.formatters.*;
    import mx.styles.*;
    import nLib.*;

    public class MemoryMonitorPanel extends Panel implements IBindingClient
    {
        var _bindingsByDestination:Object;
        var _bindingsBeginWithWord:Object;
        public var _MemoryMonitorPanel_Label1:Label;
        public var _MemoryMonitorPanel_Label2:Label;
        public var _MemoryMonitorPanel_Label3:Label;
        public var _MemoryMonitorPanel_Label4:Label;
        public var _MemoryMonitorPanel_Label5:Label;
        var _watchers:Array;
        var _bindings:Array;
        private var _documentDescriptor_:UIComponentDescriptor;
        private var _501407673MEMORYMONITOR_AlphaTestValue:TextInput;
        private static var _watcherSetupUtil:IWatcherSetupUtil;
        static var _MemoryMonitorPanel_StylesInit_done:Boolean = false;

        public function MemoryMonitorPanel()
        {
            this._documentDescriptor_ = new UIComponentDescriptor({type:Panel, propertiesFactory:function () : Object
            {
                return {width:382, height:260, childDescriptors:[new UIComponentDescriptor({type:Form, propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {x:0, y:0, percentWidth:100, childDescriptors:[new UIComponentDescriptor({type:FormItem, stylesFactory:function () : void
                    {
                        null.labelStyleName = this;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        return {label:"Original loaded Sprites:", childDescriptors:[new UIComponentDescriptor({type:Label, id:"_MemoryMonitorPanel_Label1", stylesFactory:function () : void
                        {
                            this.textAlign = "right";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:80};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:FormItem, stylesFactory:function () : void
                    {
                        null.labelStyleName = this;
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {label:"Unscaled Bitmaps:", childDescriptors:[new UIComponentDescriptor({type:Label, id:"_MemoryMonitorPanel_Label2", stylesFactory:function () : void
                        {
                            null.textAlign = this;
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:80};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:FormItem, stylesFactory:function () : void
                    {
                        this.labelStyleName = "customTextAlignLabel";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {label:"Scaled Bitmaps:", childDescriptors:[new UIComponentDescriptor({type:Label, id:"_MemoryMonitorPanel_Label3", stylesFactory:function () : void
                        {
                            this.textAlign = "right";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {width:80};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:FormItem, stylesFactory:function () : void
                    {
                        this.labelStyleName = "customTextAlignLabel";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {label:"Other:", childDescriptors:[new UIComponentDescriptor({type:Label, id:"_MemoryMonitorPanel_Label4", stylesFactory:function () : void
                        {
                            this.textAlign = "right";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:80};
                        }// end function
                        })]};
                    }// end function
                    }), new UIComponentDescriptor({type:FormItem, stylesFactory:function () : void
                    {
                        this.labelStyleName = "customTextAlignLabel";
                        this.fontWeight = "bold";
                        return;
                    }// end function
                    , propertiesFactory:function () : Object
                    {
                        var _loc_1:String = null;
                        return {label:"Total memory used:", width:211, childDescriptors:[new UIComponentDescriptor({type:Label, id:"_MemoryMonitorPanel_Label5", stylesFactory:function () : void
                        {
                            null.textAlign = this;
                            this.fontWeight = "bold";
                            return;
                        }// end function
                        , propertiesFactory:function () : Object
                        {
                            return {null:null};
                        }// end function
                        })]};
                    }// end function
                    })]};
                }// end function
                }), new UIComponentDescriptor({type:Text, propertiesFactory:function () : Object
                {
                    return {null:10, y:149, text:"Check Alphapixel (0-255)", width:135, height:20};
                }// end function
                }), new UIComponentDescriptor({type:TextInput, id:"MEMORYMONITOR_AlphaTestValue", propertiesFactory:function () : Object
                {
                    return {null:null, y:149, width:56, text:"64"};
                }// end function
                }), new UIComponentDescriptor({type:ControlBar, stylesFactory:function () : void
                {
                    null.horizontalAlign = this;
                    return;
                }// end function
                , propertiesFactory:function () : Object
                {
                    var _loc_1:String = null;
                    return {childDescriptors:[new UIComponentDescriptor({type:Button, events:{click:"___MemoryMonitorPanel_Button1_click"}, propertiesFactory:function () : Object
                    {
                        return {null:"Trace report"};
                    }// end function
                    }), new UIComponentDescriptor({type:Button, events:{click:"___MemoryMonitorPanel_Button2_click"}, propertiesFactory:function () : Object
                    {
                        return {null:null};
                    }// end function
                    }), new UIComponentDescriptor({type:Button, events:{click:"___MemoryMonitorPanel_Button3_click"}, propertiesFactory:function () : Object
                    {
                        return {label:"Save report Alpha Info"};
                    }// end function
                    })]};
                }// end function
                })]};
            }// end function
            });
            this._bindings = [];
            this._watchers = [];
            this._bindingsByDestination = {};
            this._bindingsBeginWithWord = {};
            mx_internal::_document = this;
            .mx_internal::_MemoryMonitorPanel_StylesInit();
            this.title = "Memory Monitor";
            this.width = 382;
            this.height = 260;
            this.layout = "absolute";
            return;
        }// end function

        public function get MEMORYMONITOR_AlphaTestValue() : TextInput
        {
            return this._501407673MEMORYMONITOR_AlphaTestValue;
        }// end function

        private function _MemoryMonitorPanel_bindingExprs() : void
        {
            var _loc_1:* = undefined;
            _loc_1 = Application.application.mMemoryMonitor.FormatAsMB_string(Application.application.mMemoryMonitor.mUsedBytesSprites);
            _loc_1 = Application.application.mMemoryMonitor.FormatAsMB_string(Application.application.mMemoryMonitor.mUsedBytesUnscaled);
            _loc_1 = Application.application.mMemoryMonitor.FormatAsMB_string(Application.application.mMemoryMonitor.mUsedBytesScaled);
            _loc_1 = Application.application.mMemoryMonitor.FormatAsMB_string(Application.application.mMemoryMonitor.mOtherMemory);
            _loc_1 = Application.application.mMemoryMonitor.FormatAsMB_string(Application.application.mMemoryMonitor.mTotalMemory);
            return;
        }// end function

        override public function initialize() : void
        {
            var target:MemoryMonitorPanel;
            var watcherSetupUtilClass:Object;
            .mx_internal::setDocumentDescriptor(this._documentDescriptor_);
            var bindings:* = this._MemoryMonitorPanel_bindingsSetup();
            var watchers:Array;
            target;
            if (_watcherSetupUtil == null)
            {
                watcherSetupUtilClass = getDefinitionByName("_GUI_Components_MemoryMonitorPanelWatcherSetupUtil");
                var _loc_2:* = watcherSetupUtilClass;
                _loc_2.watcherSetupUtilClass["init"](null);
            }
            _watcherSetupUtil.setup(this, function (param1:String)
            {
                return null[param1];
            }// end function
            , bindings, watchers);
            var i:uint;
            while (i < bindings.length)
            {
                
                Binding(bindings[i]).execute();
                i = (i + 1);
            }
            mx_internal::_bindings = mx_internal::_bindings.concat(bindings);
            mx_internal::_watchers = mx_internal::_watchers.concat(watchers);
            super.initialize();
            return;
        }// end function

        private function SaveReportDefault() : void
        {
            this.SaveReport(-1);
            return;
        }// end function

        function _MemoryMonitorPanel_StylesInit() : void
        {
            var style:CSSStyleDeclaration;
            var effects:Array;
            if (mx_internal::_MemoryMonitorPanel_StylesInit_done)
            {
                return;
            }
            mx_internal::_MemoryMonitorPanel_StylesInit_done = true;
            style = StyleManager.getStyleDeclaration(".customTextAlignLabel");
            if (!style)
            {
                style = new CSSStyleDeclaration();
                StyleManager.setStyleDeclaration(".customTextAlignLabel", style, false);
            }
            if (style.factory == null)
            {
                style.factory = function () : void
            {
                null.textAlign = this;
                return;
            }// end function
            ;
            }
            return;
        }// end function

        public function set MEMORYMONITOR_AlphaTestValue(param1:TextInput) : void
        {
            var _loc_2:* = this._501407673MEMORYMONITOR_AlphaTestValue;
            if (_loc_2 !== param1)
            {
                this._501407673MEMORYMONITOR_AlphaTestValue = param1;
                this.dispatchEvent(PropertyChangeEvent.createUpdateEvent(this, "MEMORYMONITOR_AlphaTestValue", _loc_2, param1));
            }
            return;
        }// end function

        public function ___MemoryMonitorPanel_Button1_click(event:MouseEvent) : void
        {
            trace(Application.application.mMemoryMonitor.GenerateReport_string(0, -1));
            return;
        }// end function

        public function ___MemoryMonitorPanel_Button2_click(event:MouseEvent) : void
        {
            this.SaveReportDefault();
            return;
        }// end function

        public function ___MemoryMonitorPanel_Button3_click(event:MouseEvent) : void
        {
            this.SaveReportAlphaInfo();
            return;
        }// end function

        private function SaveReport(param1:int) : void
        {
            var _loc_2:* = new Date();
            var _loc_3:* = new DateFormatter();
            _loc_3.formatString = "YYYY-MM-DD_J-NN";
            var _loc_4:* = new FileReference();
            var _loc_5:* = Application.application.mMemoryMonitor.GenerateReport_string(0, param1);
            _loc_4.save(_loc_5, "MemoryMonitorReport_" + _loc_3.format(_loc_2) + ".txt");
            return;
        }// end function

        private function _MemoryMonitorPanel_bindingsSetup() : Array
        {
            var binding:Binding;
            var result:Array;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.mMemoryMonitor.FormatAsMB_string(Application.application.mMemoryMonitor.mUsedBytesSprites);
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _MemoryMonitorPanel_Label1.text = param1;
                return;
            }// end function
            , "_MemoryMonitorPanel_Label1.text");
            result[0] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.mMemoryMonitor.FormatAsMB_string(Application.application.mMemoryMonitor.mUsedBytesUnscaled);
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_MemoryMonitorPanel_Label2.text");
            result[1] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.mMemoryMonitor.FormatAsMB_string(Application.application.mMemoryMonitor.mUsedBytesScaled);
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                _MemoryMonitorPanel_Label3.text = param1;
                return;
            }// end function
            , "_MemoryMonitorPanel_Label3.text");
            result[2] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = Application.application.mMemoryMonitor.FormatAsMB_string(Application.application.mMemoryMonitor.mOtherMemory);
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_MemoryMonitorPanel_Label4.text");
            result[3] = binding;
            binding = new Binding(this, function () : String
            {
                var _loc_1:* = null.application.mMemoryMonitor.FormatAsMB_string(Application.application.mMemoryMonitor.mTotalMemory);
                var _loc_2:* = _loc_1 == undefined ? (null) : (String(_loc_1));
                return _loc_2;
            }// end function
            , function (param1:String) : void
            {
                null.text = null;
                return;
            }// end function
            , "_MemoryMonitorPanel_Label5.text");
            result[4] = binding;
            return result;
        }// end function

        private function SaveReportAlphaInfo() : void
        {
            var _loc_1:* = gMisc.ParseInt(this.MEMORYMONITOR_AlphaTestValue.text);
            this.SaveReport(_loc_1);
            return;
        }// end function

        public static function set watcherSetupUtil(param1:IWatcherSetupUtil) : void
        {
            _watcherSetupUtil = param1;
            return;
        }// end function

    }
}
