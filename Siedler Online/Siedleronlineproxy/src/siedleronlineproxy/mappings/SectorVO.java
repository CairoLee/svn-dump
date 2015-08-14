/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class SectorVO extends GenericMapping {
    public Integer playerID;
    public Integer cityLevelAtWhichSectorIsActivated;
    public Integer sectorID;
    public Integer explorePriority;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
