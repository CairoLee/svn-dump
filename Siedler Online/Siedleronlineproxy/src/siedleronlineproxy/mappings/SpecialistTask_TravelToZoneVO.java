/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class SpecialistTask_TravelToZoneVO extends GenericMapping {
    public Integer destinationZoneID;
    public Integer pathPos;
    public Integer garrisonGridIdx;
    public Integer collectedTime;
    public Integer type;
    public Integer phase;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }

}
