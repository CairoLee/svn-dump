/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.mappings;

/**
 *
 * @author nspecht
 */
public class GuildPlayerListItemVO extends GenericMapping {
    public Integer playerLevel;
    public Integer id;
    public String username;
    public Integer avatarId;
    public Object adventureVO;
    public Integer rankID;
    public Object officerNote;
    public boolean onlineStatus;
    public String note;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
