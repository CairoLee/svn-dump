package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;


/**
 *
 * @author nspecht
 */
public class GenericWall extends GenericDecoration {
    public GenericWall() {
        super();
        this.name = "Mauer";
        this.category = BuildingCategory.WALL;
    }
}
