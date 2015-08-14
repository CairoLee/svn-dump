/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.registry;

import java.util.Date;

/**
 *
 * @author nspecht
 */
public class GameRegistry {
    private static GameRegistry instance = null;

    public static GameRegistry getInstance() {
        if (GameRegistry.instance == null) {
            GameRegistry.instance = new GameRegistry();
        }
        return GameRegistry.instance;
    }

    private Number serverTime = new Date().getTime();
    private Date serverTimeChanged = new Date();
    public void setServerTime(Number t) {
        this.serverTime = t;
        this.serverTimeChanged = new Date();
    }

    public Number getServerTime() {
        return this.serverTime;
    }

    public Date getGameDate(Number d) {
        Date ret = new Date();
        Long diff = (d.longValue() - this.serverTime.longValue());
        ret.setTime(this.serverTimeChanged.getTime() + diff);
        return ret;
    }
}
