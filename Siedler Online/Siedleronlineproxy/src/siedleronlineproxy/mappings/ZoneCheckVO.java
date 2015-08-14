/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class ZoneCheckVO extends GenericMapping {
    public Integer zoneId;
    public Integer zoneCheckSumResources;
    public Number clientTime;
    public Integer gameTickRefreshCounter;
    public Integer zoneCheckSumZone;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }


}
