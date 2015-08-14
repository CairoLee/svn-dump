package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building;
import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.mappings.BuildingVO;

/**
 *
 * @author nspecht
 */
public class GenericDecoration extends GenericDoNothingBuilding {
    public GenericDecoration() {
        super();
        this.name = "Dekoration";
        this.category = BuildingCategory.DEKO;
    }

    @Override
    public void setBuildingVO(BuildingVO bvo) {
        super.setBuildingVO(bvo);
        this.name = bvo.buildingName_string;
    }

    @Override
    public void setType(Building.BuildingTypes t) {
        super.setType(t);
        this.name = t.toString();
    }
    
    @Override
    public void pause() {
        if (this.buildingVO != null) {
            this.buildingVO.isProductionActive = true;
        }
    }
}
