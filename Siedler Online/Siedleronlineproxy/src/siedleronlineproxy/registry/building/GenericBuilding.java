/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.registry.building;

import java.text.SimpleDateFormat;
import javax.swing.Icon;
import siedleronlineproxy.constants.Building;
import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Resource;
import siedleronlineproxy.constants.Resource.Products;
import siedleronlineproxy.forms.GridPosition;
import siedleronlineproxy.mappings.BuffApplianceVO;
import siedleronlineproxy.mappings.BuildingVO;
import siedleronlineproxy.mappings.ResourceCreationVO;
import siedleronlineproxy.registry.BuildingRegistry;
import siedleronlineproxy.registry.GameRegistry;
import siedleronlineproxy.util.CollectionTable;
import siedleronlineproxy.util.CollectionEnumTable;
import siedleronlineproxy.util.CollectionList;

/**
 *
 * @author nspecht
 */
public abstract class GenericBuilding {

    public static boolean PROCEED_MPATH = false;
    protected Building.BuildingTypes type = Building.BuildingTypes.UNKNOWN;
    protected BuildingVO buildingVO;
    protected ResourceCreationVO resourceCreationVO;
    protected CollectionEnumTable<Products, Integer> needs = new CollectionEnumTable<Resource.Products, Integer>(Resource.Products.class);
    protected CollectionEnumTable<Products, Integer> produces = new CollectionEnumTable<Resource.Products, Integer>(Resource.Products.class);
    protected int productionTime = 24 * 60 * 60;
    protected String name = "";
    private CollectionTable<Integer,Integer> distances = new CollectionTable<Integer, Integer>();
    protected BuildingCategory category = BuildingCategory.__UNKNOWN;

    public void setName(String name) {
        this.name = name;
    }

    public String getName() {
        return this.name;
    }

    public void setBuildingVO(BuildingVO b) {
        this.buildingVO = b;
    }

    public BuildingVO getBuildingVO() {
        return this.buildingVO;
    }

    public void setType(Building.BuildingTypes t) {
        this.type = t;
    }

    public Building.BuildingTypes getType() {
        return this.type;
    }

    public void setCategory(Building.BuildingCategory c) {
        this.category = c;
    }

    public Building.BuildingCategory getCategory() {
        return this.category;
    }

    public CollectionEnumTable<Products, Integer> getNeeds() {
        return this.needs;
    }

    public CollectionEnumTable<Products, Integer> getProducts() {
        return this.produces;
    }

    public void setResourceCreation(ResourceCreationVO c) {
        this.resourceCreationVO = c;
    }
    
    public ResourceCreationVO getResourceCreation() {
        return this.resourceCreationVO;
    }

    public int getCycleTime() {
        return this.productionTime + 2 * (this.getResourceTime() + this.getWarehouseTime());
    }

    public int getResourceTime() {
        if (this.resourceCreationVO != null) {
            if (GenericBuilding.PROCEED_MPATH && this.resourceCreationVO.pathVO != null) {
                return 0;
            }
            if (this.resourceCreationVO.depositBuildingGridPos != 0) {
                return this.distanceInGrid(this.resourceCreationVO.depositBuildingGridPos);
            }
        }
        return this.getWarehouseTime();
    }

    public int getWarehouseTime() {
        if (this.buildingVO == null) {
            return 0;
        }

        if (GenericBuilding.PROCEED_MPATH && this.resourceCreationVO != null) {
            if (this.resourceCreationVO.pathVO != null) {
                Integer i = this.buildingVO.buildingGrid;
                int sum = 0;
                for (Object o : this.resourceCreationVO.pathVO.mPath.getSource()) {
                    if (i != null) {
                        sum += this.distanceInGrid(i, (Integer) o);
                    }
                    i = (Integer) o;
                }
                return sum;
            }
        }

        return this.distanceInGrid(
                BuildingRegistry.getInstance().getNearestWarehousePosition(this.buildingVO.buildingGrid));
    }

    public double getCyclesPerDay() {
        return (24.0 * 60.0 * 60.0) / (double) this.getCycleTime();
    }

    public String getBuffs() {
        if (this.buildingVO == null) {
            return "";
        }
        String ret = "";
        for (Object b : this.buildingVO.buffs.toArray()) {
            BuffApplianceVO buff = (BuffApplianceVO) b;
            SimpleDateFormat f = new SimpleDateFormat("dd.MM.yy HH:mm:ss");
            ret += buff.buffName_string + " (" + f.format(GameRegistry.getInstance().getGameDate(buff.startTime)) + ")\n";
        }
        return ret;
    }

    public boolean isBuffed() {
        if (this.buildingVO == null) {
            return false;
        }
        return (this.buildingVO.buffs.size() > 0 ? true : false);
    }

    public CollectionEnumTable<Resource.Products, Double> getNeedsPerDay() {
        if (this.buildingVO == null) {
            return this.getNeedsPerDayByLevel(1);
        }
        return this.getNeedsPerDayByLevel(this.buildingVO.upgradeLevel);
    }

    public CollectionEnumTable<Resource.Products, Double> getNeedsPerDayByLevel(int level) {
        CollectionEnumTable< Products, Double> ret = new CollectionEnumTable<Resource.Products, Double>(Resource.Products.class);
        if (this.buildingVO != null) {
            if (!this.buildingVO.isProductionActive) {
                return ret;
            }
        }
        for (Products p : this.needs.keySet()) {
            ret.put(p, this.getCyclesPerDay() * this.needs.get(p) * level);
        }
        return ret;
    }

    public CollectionEnumTable<Resource.Products, Double> getProducesPerDay() {
        if (this.buildingVO == null) {
            return this.getProducesPerDayByLevel(1);
        }
        return this.getProducesPerDayByLevel(this.buildingVO.upgradeLevel);
    }

    public CollectionEnumTable<Resource.Products, Double> getProducesPerDayByLevel(int level) {
        CollectionEnumTable< Products, Double> ret = new CollectionEnumTable<Resource.Products, Double>(Resource.Products.class);
        if (this.buildingVO != null) {
            if (!this.buildingVO.isProductionActive) {
                return ret;
            }
        }
        for (Products p : this.produces.keySet()) {
            ret.put(p, this.getCyclesPerDay() * this.produces.get(p) * level);
        }
        return ret;
    }
    
    public void pause() {
        if (this.buildingVO != null) {
            this.buildingVO.isProductionActive = false;
        }
    }
    
    public void unpause() {
        if (this.buildingVO != null) {
            this.buildingVO.isProductionActive = true;
        }
    }

    public int distanceInGrid(int to) {
        if (this.distances.containsKey(to)) return this.distances.get(to);
        if (this.buildingVO == null) {
            return 0;
        }
        
        int ret = this.distanceInGrid(this.buildingVO.buildingGrid, to);
        this.distances.put(to, ret);
        return ret;
    }

    public int distanceInGrid(int g1, int g2) { //oder inSabine :D
        //return distanceCityBlock(g1, g2)*2;
        return (distanceAStar(g1, g2)+2)*2;
    }

    public int distanceCityBlock(int g1, int g2) {
        int x1 = g1 % 64;
        int x2 = g2 % 64;

        int y1 = g1 / 64;
        int y2 = g2 / 64;

        return (Math.abs(x1 - x2) + Math.abs(y1 - y2));
    }

    private int distanceAStar(int g1, int g2) {
        if (g1 == g2) {
            return 0;
        }
        GridPosition position = new GridPosition(g1);
        GridPosition target = new GridPosition(g2);
        CollectionList<Integer[]> queue = new CollectionList<Integer[]>();
        Integer[] visited = new Integer[100 * 300];
        for (int i = 0; i < visited.length; i++) {
            visited[i] = Integer.MAX_VALUE;
        }
        
        if (position.y % 2 == 0) {
            position = new GridPosition(position.x,position.y+1);
        } else {
            position = new GridPosition(position.x+1,position.y+1);
        }
        queue.add(new Integer[]{position.position, 0});

        while (!queue.isEmpty()) {
            Integer pos[] = queue.get(0);
            queue.remove(0);
            position = new GridPosition(pos[0]);
            //this.distances.put(pos[0],pos[1]);
            //System.out.println((new GridPosition(g1))+"->"+target+" = "+position+"/"+pos[1]);
            if (this.inLandingZone(position, target)) {
                return pos[1];
            }
            if (visited[pos[0]]>pos[1]) {
                visited[pos[0]] = pos[1];
                boolean f = false;
                f |= this.distanceAStarAddQueue(new GridPosition(position.x,position.y-1), target, pos[1], queue, visited);
                f |= this.distanceAStarAddQueue(new GridPosition(position.x,position.y+1), target, pos[1], queue, visited);
                if (position.y % 2 == 0) {
                    f |= this.distanceAStarAddQueue(new GridPosition(position.x-1,position.y+1), target, pos[1], queue, visited);
                    f |= this.distanceAStarAddQueue(new GridPosition(position.x-1,position.y-1), target, pos[1], queue, visited);
                } else {
                    f |= this.distanceAStarAddQueue(new GridPosition(position.x+1,position.y+1), target, pos[1], queue, visited);
                    f |= this.distanceAStarAddQueue(new GridPosition(position.x+1,position.y-1), target, pos[1], queue, visited);
                }
                if (f) return pos[1]+1;
            }
        }

        return 0;
    }

    private boolean distanceAStarAddQueue(GridPosition newPos, GridPosition target, int stepcount, CollectionList<Integer[]> queue, Integer[] visited) {
        if (this.inLandingZone(newPos, target)) return true;
        if (newPos.x < 0) return false;
        if (newPos.y < 0) return false;
        if (newPos.x > 64) return false;
        if (newPos.y > 200) return false;
        
        if ((BuildingRegistry.getInstance().getBuildingByPosition(newPos.position) == null) && (visited[newPos.position]>stepcount+1)) {
            queue.add(new Integer[]{newPos.position, stepcount + 1});
        }
        return false;
    }

    private boolean inLandingZone(GridPosition pos, GridPosition target) {
        if (pos.position==target.position) return true;

        if (target.y % 2 == 0) {
            if (pos.x == target.x && pos.y == target.y + 1) return true;
        } else {
            if (pos.x == target.x + 1 && pos.y == target.y + 1) return true;
        }
        return false;
    }

    public Icon getIcon() {
        return Building.getIconByType(this.type);
    }
}
