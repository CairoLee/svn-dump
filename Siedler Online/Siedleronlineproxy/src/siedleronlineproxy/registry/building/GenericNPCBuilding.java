package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;

/**
 *
 * @author nspecht
 */
public class GenericNPCBuilding extends GenericDoNothingBuilding {
    public GenericNPCBuilding() {
        super();
        this.category = BuildingCategory.NPC;
    }
}
