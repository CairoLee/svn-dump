/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class SectorDiscoveryVO extends GenericMapping {
    public Integer playerID;
    public Integer discoveryType;
    public Integer sectorID;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
