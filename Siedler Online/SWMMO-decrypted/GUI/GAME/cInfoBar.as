package GUI.GAME
{
    import Enums.*;
    import GUI.*;
    import GUI.Assets.*;
    import GUI.Components.*;
    import GUI.Loca.*;
    import Interface.*;
    import ServerState.*;
    import flash.events.*;
    import flash.geom.*;
    import mx.core.*;

    public class cInfoBar extends cGuiBaseElement
    {
        private var mGI:cGameInterface;
        protected var mInfoBar:InfoBar;

        public function cInfoBar()
        {
            return;
        }// end function

        private function CheckTargetArea(event:MouseEvent, param2:Container) : Boolean
        {
            var _loc_3:* = new Point(param2.x, param2.y);
            _loc_3 = param2.parent.localToGlobal(_loc_3);
            if (event.stageX > _loc_3.x && event.stageX < _loc_3.x + param2.width)
            {
                return true;
            }
            return false;
        }// end function

        public function HandleInfoBarClick(event:MouseEvent) : void
        {
            if (event.target == this.mInfoBar.btnAddCash)
            {
                return;
            }
            if (this.CheckTargetArea(event, this.mInfoBar.buildings))
            {
                globalFlash.gui.mShopWindow.ShowDeepLink("InfoBar", 5004, 5);
            }
            else if (this.CheckTargetArea(event, this.mInfoBar.hardCurrency))
            {
                globalFlash.gui.mShopWindow.Show();
            }
            else
            {
                globalFlash.gui.ShowWarehouse();
            }
            return;
        }// end function

        public function SetBuildingsCount(param1:int, param2:int) : void
        {
            var _loc_3:* = param2 - param1;
            this.mInfoBar.resourceLabelBuildings.text = _loc_3.toString();
            this.mInfoBar.resourceLabelBuildings.setStyle("color", _loc_3 > 0 ? (16777215) : (16711680));
            this.mInfoBar.buildings.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.LABELS, "BuildingsOnMap", [_loc_3.toString(), param2.toString()]);
            return;
        }// end function

        public function SetPopulation(param1:cResources) : void
        {
            this.mInfoBar.resourceLabelPopulation.text = param1.GetNumberOfUnassignedPopulation().toString();
            this.mInfoBar.resourceLabelPopulation.setStyle("color", param1.GetNumberOfUnassignedPopulation() <= 0 ? (16711680) : (16777215));
            return;
        }// end function

        public function Init(param1:InfoBar) : void
        {
            this.mGI = global.ui as cGameInterface;
            AddBaseElement(param1);
            this.mInfoBar = param1;
            this.mInfoBar.addEventListener(MouseEvent.CLICK, this.HandleInfoBarClick);
            this.mInfoBar.resourceIconPopulation.source = gAssetManager.GetResourceIcon("Population");
            this.mInfoBar.resourceIconBuildings.source = gAssetManager.GetResourceIcon("Building");
            this.mInfoBar.resourceIconHardCurrency.source = gAssetManager.GetResourceIcon("HardCurrency");
            this.mInfoBar.btnAddCash.addEventListener(MouseEvent.CLICK, this.AddHardCurrency);
            this.mInfoBar.resourceIcon1.source = gAssetManager.GetResourceIcon("Tool");
            this.mInfoBar.resourceIcon2.source = gAssetManager.GetResourceIcon("Coin");
            this.mInfoBar.resourceIcon3.source = gAssetManager.GetResourceIcon("Plank");
            this.mInfoBar.resourceIcon4.source = gAssetManager.GetResourceIcon("RealPlank");
            this.mInfoBar.resourceIcon5.source = gAssetManager.GetResourceIcon("Stone");
            this.mInfoBar.resourceIcon6.source = gAssetManager.GetResourceIcon("Marble");
            return;
        }// end function

        private function AddHardCurrency(event:MouseEvent) : void
        {
            globalFlash.gui.mShopWindow.AddHardCurrency(event);
            return;
        }// end function

        public function SetResource(param1:dResource) : void
        {
            var _loc_2:* = Math.floor(param1.amount);
            switch(param1.name_string)
            {
                case "HardCurrency":
                {
                    this.mInfoBar.resourceLabelHardCurrency.text = _loc_2.toString();
                    this.mInfoBar.hardCurrency.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, "HardCurrency");
                    break;
                }
                case "Tool":
                {
                    this.mInfoBar.resourceLabel1.text = _loc_2.toString();
                    this.mInfoBar.resource1.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, "Tool");
                    break;
                }
                case "Coin":
                {
                    this.mInfoBar.resourceLabel2.text = _loc_2.toString();
                    this.mInfoBar.resource2.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, "Coin");
                    break;
                }
                case "Plank":
                {
                    this.mInfoBar.resourceLabel3.text = _loc_2.toString();
                    this.mInfoBar.resource3.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, "Plank");
                    break;
                }
                case "RealPlank":
                {
                    this.mInfoBar.resourceLabel4.text = _loc_2.toString();
                    this.mInfoBar.resource4.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, "RealPlank");
                    break;
                }
                case "Stone":
                {
                    this.mInfoBar.resourceLabel5.text = _loc_2.toString();
                    this.mInfoBar.resource5.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, "Stone");
                    break;
                }
                case "Marble":
                {
                    this.mInfoBar.resourceLabel6.text = _loc_2.toString();
                    this.mInfoBar.resource6.toolTip = cLocaManager.GetInstance().GetText(LOCA_GROUP.RESOURCES, "Marble");
                    break;
                }
                default:
                {
                    break;
                }
            }
            return;
        }// end function

    }
}
