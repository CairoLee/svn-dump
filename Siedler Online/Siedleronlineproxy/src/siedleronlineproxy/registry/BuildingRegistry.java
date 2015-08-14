/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.registry;

import java.util.Collection;
import java.util.Date;
import siedleronlineproxy.mappings.BuildingVO;
import siedleronlineproxy.mappings.ResourceCreationVO;
import siedleronlineproxy.registry.building.GenericBuilding;
import siedleronlineproxy.constants.Building;
import siedleronlineproxy.constants.Resource.Products;
import siedleronlineproxy.debug.DebugLog;
import siedleronlineproxy.forms.map.Map;
import siedleronlineproxy.registry.building.UnknownBuilding;
import siedleronlineproxy.util.CollectionTable;
import siedleronlineproxy.util.CollectionEnumTable;

/**
 *
 * @author nspecht
 */
public class BuildingRegistry {

    private static BuildingRegistry instance = null;

    public static BuildingRegistry getInstance() {
        if (BuildingRegistry.instance == null) {
            BuildingRegistry.instance = new BuildingRegistry();
        }
        return BuildingRegistry.instance;
    }
    private CollectionTable<Integer, GenericBuilding> registry = new CollectionTable<Integer, GenericBuilding>();
    public Date lastChange = new Date();

    private void onChange() {
        this.lastChange = new Date();
        Map.getInstance().updateMap();
    }

    public void add(BuildingVO buildingVO) {
        GenericBuilding toAdd;
        try {
            String name = buildingVO.buildingName_string.toUpperCase();
            name = name.replace('-', '_');

            Building.BuildingTypes t = Building.BuildingTypes.valueOf(name);
            Class type = Building.getInstance().classes[t.ordinal()];
            toAdd = (GenericBuilding) type.newInstance();
            toAdd.setType(t);
        } catch (Exception e) {
            DebugLog.put(this, buildingVO.buildingName_string + " ist unbekannt", DebugLog.LogLevel.ERROR);
            toAdd = new UnknownBuilding();
            toAdd.setType(Building.BuildingTypes.UNKNOWN);
            toAdd.setName(buildingVO.buildingName_string);
        }
        toAdd.setBuildingVO(buildingVO);
        this.registry.put(buildingVO.buildingGrid, toAdd);

        this.onChange();
    }

    public void add(GenericBuilding b, int position) {
        BuildingVO bvo = b.getBuildingVO();
        if (bvo == null) {
            bvo = new BuildingVO(false);
            bvo.buildingGrid = position;
            bvo.buildingName_string = b.getClass().getName();
        }

        if (b.getType() == null) {
            String classname = b.getClass().getCanonicalName();
            int dot = classname.lastIndexOf('.');
            classname = classname.substring(dot).toUpperCase();
            try {
                Building.BuildingTypes type = Building.BuildingTypes.valueOf(classname);
                b.setType(type);
            } catch (Exception e) {
                DebugLog.put(this, "BuildingType unknown: " + classname, DebugLog.LogLevel.ERROR);
            }
        }
        b.setBuildingVO(bvo);
        this.removePosition(position);
        this.registry.put(position, b);

        this.onChange();
    }

    public void removePosition(int position) {
        if (this.registry.containsKey(position)) {
            this.registry.remove(position);
            this.onChange();
        }
    }

    public void moveBuilding(int from, int to) {
        GenericBuilding b = this.registry.get(from);
        if (b != null) {
            BuildingVO bvo = b.getBuildingVO();
            bvo.buildingGrid = to;
            b.setBuildingVO(bvo);
            this.registry.remove(from);
            this.registry.put(to, b); // or ! to,b

            this.onChange();
        } else {
            DebugLog.put(this, "building at position " + from + " can't not be moved to " + to + "", DebugLog.LogLevel.ERROR);
        }
    }

    public void pausePosition(int position) {
        if (position <= 0) {
            return;
        }
        GenericBuilding b = this.registry.get(position);
        if (b != null) {
            b.pause();
            this.onChange();
        } else {
            DebugLog.put(this, "No Building at Position " + position + "; can not be paused", DebugLog.LogLevel.ERROR);
        }
    }

    public void unpausePosition(int position) {
        GenericBuilding b = this.registry.get(position);
        if (b != null) {
            b.unpause();
            this.onChange();
        } else {
            DebugLog.put(this, "No Building at Position " + position + "; can not be unpaused", DebugLog.LogLevel.ERROR);
        }
    }

    public Collection<GenericBuilding> getItems() {
        return this.registry.values();
    }

    public void reset() {
        this.registry.clear();

        this.onChange();
    }

    public void addResourceCreation(ResourceCreationVO rcvo) {
        if (rcvo.resourceCreationHouseGrid < 0) {
            return;
        }
        if (this.registry.containsKey(rcvo.resourceCreationHouseGrid)) {
            DebugLog.put(this, "ResourceCreation has     been assigned " + rcvo.resourceCreationHouseGrid, DebugLog.LogLevel.SUCCESS);
            this.registry.get(rcvo.resourceCreationHouseGrid).setResourceCreation(rcvo);
            this.onChange();
        } else {
            DebugLog.put(this, "ResourceCreation has not been assigned " + rcvo.resourceCreationHouseGrid, DebugLog.LogLevel.ERROR);
            rcvo.registerProceedLater();
        }


    }

    public int getNearestWarehousePosition(int gridPosition) {
        Object[] buildings = (Object[]) this.getItems().toArray();
        int ret = 0;
        int distance = 10000;
        for (Object obj : buildings) {
            GenericBuilding b = (GenericBuilding) obj;
            if (b.getType() == Building.BuildingTypes.WAREHOUSE || b.getType() == Building.BuildingTypes.MAYORHOUSE) {
                int d = b.distanceInGrid(gridPosition);
                if (d < distance) {
                    ret = b.getBuildingVO().buildingGrid;
                    distance = d;
                }
            }
        }
        return ret;
    }

    public GenericBuilding getBuildingByPosition(int gridPosition) {
        if (this.registry.containsKey(gridPosition)) {
            return this.registry.get(gridPosition);
        }
        return null;
    }

    public CollectionEnumTable<Products, Double>[] getProductivity() {
        return this.getProductivity(null);
    }

    public CollectionEnumTable<Products, Double>[] getProductivity(Integer exceptPosition) {
        CollectionEnumTable<Products, Double> needs = new CollectionEnumTable<Products, Double>(Products.class);
        CollectionEnumTable<Products, Double> produces = new CollectionEnumTable<Products, Double>(Products.class);
        CollectionEnumTable<Products, Double> needs_buffed = new CollectionEnumTable<Products, Double>(Products.class);
        CollectionEnumTable<Products, Double> produces_buffed = new CollectionEnumTable<Products, Double>(Products.class);
        if (exceptPosition == null) {
            exceptPosition = -1;
        }
        //Fülle die Listen
        for (Integer position : this.registry.keySet()) {
            if (position != exceptPosition) {
                try {
                    GenericBuilding building = this.registry.get(position);
                    CollectionEnumTable<Products, Double> tmp;

                    tmp = building.getNeedsPerDay();
                    for (Products p : tmp.keySet()) {
                        if (needs.containsKey(p)) {
                            needs.put(p, needs.get(p) + tmp.get(p));
                            needs_buffed.put(p, needs_buffed.get(p) + tmp.get(p));
                        } else {
                            needs.put(p, tmp.get(p));
                            needs_buffed.put(p, tmp.get(p));
                        }
                    }

                    tmp = building.getProducesPerDay();
                    for (Products p : tmp.keySet()) {
                        if (produces.containsKey(p)) {
                            produces.put(p, produces.get(p) + tmp.get(p));
                            produces_buffed.put(p, produces_buffed.get(p) + tmp.get(p));
                        } else {
                            produces.put(p, tmp.get(p));
                            produces_buffed.put(p, tmp.get(p));
                        }
                        if (building.isBuffed()) {
                            produces_buffed.put(p, produces_buffed.get(p) + tmp.get(p));
                        }
                    }
                } catch (Exception e) {
                    DebugLog.put(this, e);
                }
            }
        }

        CollectionEnumTable ret[] = new CollectionEnumTable[4];
        ret[0] = needs;
        ret[1] = produces;
        ret[2] = needs_buffed;
        ret[3] = produces_buffed;
        return ret;
    }
}
