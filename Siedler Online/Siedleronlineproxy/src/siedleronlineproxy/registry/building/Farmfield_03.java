package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;

/**
 *
 * @author nspecht
 */
public class Farmfield_03 extends Farmfield {
    public Farmfield_03() {
        super();
        this.name = "Mittleres Getreidefeld";
        this.type = BuildingTypes.FARMFIELD_03;
        this.category = BuildingCategory.CORN;
    }
}
