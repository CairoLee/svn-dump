/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

import flex.messaging.io.ArrayCollection;

/**
 *
 * @author nspecht
 */
public class AdventureClientInfoVO extends GenericMapping {
    public Integer status;
    public Integer ownerPlayerID;
    public ArrayCollection players;
    public Number collectedTime;
    public Integer zoneID;
    public String adventureName;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }


}
