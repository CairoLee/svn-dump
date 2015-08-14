package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;

/**
 *
 * @author nspecht
 */
public class GenericEmptyDeposit extends GenericDoNothingBuilding {
    public GenericEmptyDeposit() {
        super();
        this.category = BuildingCategory.EMPTYDEPOSIT;
    }
}
