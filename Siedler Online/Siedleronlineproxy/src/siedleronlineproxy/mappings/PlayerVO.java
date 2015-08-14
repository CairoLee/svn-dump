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
public class PlayerVO extends GenericMapping {
    public String username_string;
    public ArrayCollection resources;
    public Integer avatarId;
    public ArrayCollection discoveredSectors;
    public ArrayCollection purchasedShopItems_vector;
    public UniqueID uniqueID;
    public Integer xp;
    public Integer cityLevel;
    public Integer zoneID;
    public Integer generalsAmount;
    public Integer explorersAmount;
    public Integer playerLevel;
    public Integer userID;
    public boolean canCheat;
    public ArrayCollection availableBuffs_vector;
    public Object guildVO;
    public Integer currentMaximumBuildingsCountAll;
    public Integer geologistsAmount;

    @Override
    public void proceed() {
    }

    @Override
    public void manipulate(boolean incoming) {
    }
}
