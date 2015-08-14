/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class TradeBodyVO extends GenericMapping {
    public ResourceVO offer;
    public ResourceVO cost;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }

}
