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
public class LootItemsVO extends GenericMapping {
    public ArrayCollection uniqueIDs;
    public Integer maild;
    public ArrayCollection items;
    public Integer shopItemId;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
