package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;

/**
 *
 * @author nspecht
 */
public class GenericMineBuilding extends GenericBuilding {
    public GenericMineBuilding() {
        super();
        this.category = BuildingCategory.MINE;
    }

    @Override
    public int getResourceTime() {
        return 0;
    }
}
