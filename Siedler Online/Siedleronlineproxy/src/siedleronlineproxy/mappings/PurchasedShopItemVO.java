/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class PurchasedShopItemVO extends GenericMapping {
    public Integer hardCurrenceSpend;
    public String resourcesSpend;
    public Integer giftedToPlayerId;
    public Number timeOfPurchase;
    public Integer playerLevelAtPurchase;
    public Integer shopItemID;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }

}
