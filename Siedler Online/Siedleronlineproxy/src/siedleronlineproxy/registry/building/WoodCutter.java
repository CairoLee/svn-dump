/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class WoodCutter extends GenericBuilding {
    public WoodCutter() {
        super();
        this.name = "Nadelholzfällerhütte";
        this.type = BuildingTypes.WOODCUTTER;
        this.category = BuildingCategory.WOOD;
        this.productionTime = 1*60 + 30;
        this.needs.put(Products.TREE, 1);
        this.produces.put(Products.WOOD, 1);
    }
}
