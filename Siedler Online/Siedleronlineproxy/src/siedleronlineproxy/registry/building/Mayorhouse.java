/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource;
import siedleronlineproxy.constants.Resource.Products;
import siedleronlineproxy.util.CollectionEnumTable;

/**
 *
 * @author nspecht
 */
public class Mayorhouse extends GenericDoNothingBuilding {
    public Mayorhouse() {
        super();
        this.name = "Rathaus";
        this.type = BuildingTypes.MAYORHOUSE;
        this.category = BuildingCategory.STORAGE;
    }

    @Override
    public CollectionEnumTable<Resource.Products, Double> getProducesPerDayByLevel(int level) {
        CollectionEnumTable< Products, Double> ret = super.getProducesPerDayByLevel(level);
        ret.put(Products.POPULATION, 50.0);
        return ret;
    }
}
