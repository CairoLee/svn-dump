package GUI.Components
{
    import AdventureSystem.*;
    import Communication.VO.*;
    import Communication.VO.UpdateVO.*;
    import Enums.*;
    import GUI.Components.ItemRenderer.*;
    import GUI.Loca.*;
    import mx.containers.*;
    import mx.events.*;

    public class GroupedQuestList extends VBox
    {
        private var lm:cLocaManager;
        private var _dataProvider:Object;
        private var _selectedItem:Object;
        private var _groupRendererMap:Object;

        public function GroupedQuestList()
        {
            this._groupRendererMap = {};
            this.lm = cLocaManager.GetInstance();
            this.clipContent = false;
            this.addEventListener(ItemClickEvent.ITEM_CLICK, this.select);
            return;
        }// end function

        protected function select(event:ItemClickEvent) : void
        {
            this.selectedItem = event.item;
            return;
        }// end function

        protected function updateList() : void
        {
            var _loc_2:Object = null;
            var _loc_3:String = null;
            var _loc_4:QuestListGroupItemRenderer = null;
            var _loc_1:Object = {};
            for each (_loc_2 in this._dataProvider)
            {
                
                _loc_1[_loc_2.groupId] = _loc_2;
                if (this._groupRendererMap[_loc_2.groupId])
                {
                    _loc_4 = this._groupRendererMap[_loc_2.groupId];
                }
                else
                {
                    _loc_4 = new QuestListGroupItemRenderer();
                    _loc_4.title = this.lm.GetText(LOCA_GROUP.LABELS, _loc_2.groupId);
                    _loc_4.emptyText = this.lm.GetText(LOCA_GROUP.LABELS, _loc_2.groupId + "Empty");
                    this._groupRendererMap[_loc_2.groupId] = _loc_4;
                    this.addChild(_loc_4);
                }
                _loc_4.data = _loc_2.data;
            }
            for (_loc_3 in this._groupRendererMap)
            {
                
                if (!_loc_1[_loc_3])
                {
                    this.removeChild(this._groupRendererMap[_loc_3]);
                    delete this._groupRendererMap[_loc_3];
                }
            }
            this.selectedItem = this._selectedItem;
            return;
        }// end function

        private function compareItems(param1:Object, param2:Object) : Boolean
        {
            var _loc_3:String = null;
            var _loc_4:String = null;
            if (!param1)
            {
                return false;
            }
            if (!param2)
            {
                return false;
            }
            if (param1 is dQuestElementVO)
            {
                _loc_3 = param1.mQuestName_string;
            }
            else if (param1 is dAdventureClientInfoVO)
            {
                _loc_3 = param1.adventureName + param1.zoneID;
            }
            else if (param1 is cAdventureDefinition)
            {
                _loc_3 = param1.mName_string;
            }
            if (param2 is dQuestElementVO)
            {
                _loc_4 = param2.mQuestName_string;
            }
            else if (param2 is dAdventureClientInfoVO)
            {
                _loc_4 = param2.adventureName + param2.zoneID;
            }
            else if (param2 is cAdventureDefinition)
            {
                _loc_4 = param2.mName_string;
            }
            return _loc_3 == _loc_4;
        }// end function

        public function get selectedItem() : Object
        {
            return this._selectedItem;
        }// end function

        public function set dataProvider(param1:Object) : void
        {
            this._dataProvider = param1;
            this.updateList();
            return;
        }// end function

        public function removeItem(param1:Object) : void
        {
            var _loc_2:Object = null;
            var _loc_3:Array = null;
            var _loc_4:int = 0;
            for each (_loc_2 in this._dataProvider)
            {
                
                _loc_3 = _loc_2.data as Array;
                _loc_4 = 0;
                while (_loc_4 < _loc_3.length)
                {
                    
                    if (this.compareItems(param1, _loc_3[_loc_4]))
                    {
                        _loc_3.splice(_loc_4, 1);
                        this.updateList();
                        return;
                    }
                    _loc_4++;
                }
            }
            return;
        }// end function

        public function get dataProvider() : Object
        {
            return this._dataProvider;
        }// end function

        public function set selectedItem(param1:Object) : void
        {
            var _loc_3:QuestListGroupItemRenderer = null;
            var _loc_4:QuestListItemRenderer = null;
            var _loc_2:Boolean = false;
            for each (_loc_3 in this.getChildren())
            {
                
                for each (_loc_4 in _loc_3.list.getChildren())
                {
                    
                    _loc_4.selected = this.compareItems(param1, _loc_4.data);
                    if (_loc_4.selected)
                    {
                        _loc_2 = true;
                    }
                }
            }
            if (_loc_2 || param1 == null)
            {
                this._selectedItem = param1;
            }
            return;
        }// end function

    }
}
