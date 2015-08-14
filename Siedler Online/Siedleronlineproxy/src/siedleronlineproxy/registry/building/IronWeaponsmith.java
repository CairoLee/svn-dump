package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class IronWeaponsmith extends GenericBuilding {
    public IronWeaponsmith() {
        super();
        this.name = "Eisenwaffenschmiede";
        this.type = BuildingTypes.IRONWEAPONSMITH;
        this.category = BuildingCategory.ARMY;
        this.productionTime = 12*60;
        this.needs.put(Products.IRON, 2);
        this.needs.put(Products.COAL, 8);
        this.produces.put(Products.IRONSWORD, 1);
    }
}
