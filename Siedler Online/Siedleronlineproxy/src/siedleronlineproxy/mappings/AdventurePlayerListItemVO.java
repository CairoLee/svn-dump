/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class AdventurePlayerListItemVO extends GenericMapping {
    public Integer playerLevel;
    public Integer id;
    public String username;
    public Integer avatarId;
    public Integer status;
    public Object adventureVO;
    public Boolean onlineStatus;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
