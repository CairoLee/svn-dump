package siedleronlineproxy.registry.building;

/**
 *
 * @author nspecht
 */
public class GenericForesterBuilding extends GenericBuilding {
    public GenericForesterBuilding() {
        super();
    }

    @Override
    public int getResourceTime() {
        int ret = super.getResourceTime();
        return Math.min(ret,10);
    }
}
