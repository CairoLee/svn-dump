/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class QuestDefinitionHintVO extends GenericMapping {
    public Integer offsetY;
    public Integer direction;
    public Integer offsetX;
    public String name_string;
    public String pointTo;

    @Override
    public void proceed() {
        
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
