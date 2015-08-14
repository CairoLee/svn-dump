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
public class Forester extends GenericForesterBuilding {
    public Forester () {
        super();
        this.productionTime = 2*60 + 15;
        this.name = "Nadelholzforsthütte";
        this.type = BuildingTypes.FORESTER;
        this.category = BuildingCategory.WOOD;
        this.needs.put(Products.SEED, 1);
        this.produces.put(Products.TREE, 1);
    }
}
