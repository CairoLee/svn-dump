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
public class FindDepositResponseVO extends GenericMapping {
    public ArrayCollection foundDeposits_vector;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
