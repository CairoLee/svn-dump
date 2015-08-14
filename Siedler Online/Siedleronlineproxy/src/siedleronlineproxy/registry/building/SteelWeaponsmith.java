package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class SteelWeaponsmith extends GenericBuilding {
    public SteelWeaponsmith() {
        super();
        this.name = "Stahlwaffenschmiede";
        this.type = BuildingTypes.STEELWEAPONSMITH;
        this.category = BuildingCategory.ARMY;
        this.productionTime = 24*60;
        this.needs.put(Products.STEEL, 2);
        this.needs.put(Products.COAL, 16);
        this.produces.put(Products.STEELSWORD, 1);
    }
}
