/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class BuffApplianceVO extends GenericMapping {
    
    public Number startTime;
    public Integer uniqueID1;
    public String buffName_string;
    public Integer applianceMode;
    //public Integer amount;
    //public Integer remaining;
    //public Integer uniqueId2;
    //public Integer recurringChance;
    //public String resourceName_string;

    @Override
    public void proceed() {
        
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
