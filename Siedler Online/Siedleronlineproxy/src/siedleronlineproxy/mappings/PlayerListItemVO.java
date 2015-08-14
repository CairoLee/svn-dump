/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class PlayerListItemVO extends GenericMapping {
    public Integer playerLevel;
    public Integer id;
    public String username;
    public Integer avatarId;
    public AdventureClientInfoVO adventureVO;
    public boolean onlineStatus;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
