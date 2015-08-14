package siedleronlineproxy.registry.building;

/**
 *
 * @author nspecht
 */
public class GenericDoNothingBuilding extends GenericBuilding {
    public GenericDoNothingBuilding() {
        super();
        this.productionTime = 0*60;
    }

    @Override
    public int getResourceTime() {
        return 0;
    }

    @Override
    public int getWarehouseTime() {
        return 0;
    }
    
    @Override
    public void pause() {
        if (this.buildingVO != null) {
            this.buildingVO.isProductionActive = true;
        }
    }
}
