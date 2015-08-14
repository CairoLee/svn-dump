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
public class DataTrackingVO extends GenericMapping {
    public Integer amount;
    public ArrayCollection dataTracking;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
