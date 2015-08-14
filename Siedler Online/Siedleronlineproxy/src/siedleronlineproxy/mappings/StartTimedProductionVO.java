/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class StartTimedProductionVO extends GenericMapping {
    public Object uniqueIds;
    public Integer productionType;
    public Integer amount;
    public String type_string;
    
    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }

}
