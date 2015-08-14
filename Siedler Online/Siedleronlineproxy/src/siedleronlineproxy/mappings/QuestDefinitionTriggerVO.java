/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class QuestDefinitionTriggerVO extends GenericMapping {
    public Integer amount;
    public Integer condition;
    public String name_string;
    public Integer type;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
