/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class FindEventZoneResponseVO extends GenericMapping {
    public String adventureName_string;
    public Integer specialistUniqueId;
    public Integer eventZonePlayerID;
    public UniqueID buffUniqueID;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }

}
