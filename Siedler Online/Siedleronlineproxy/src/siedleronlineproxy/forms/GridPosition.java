/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.forms;

import java.text.DecimalFormat;
import siedleronlineproxy.util.CollectionList;

/**
 *
 * @author nspecht
 */
public class GridPosition {
    @SuppressWarnings("unchecked")
    private static CollectionList<Integer>[] sectors = new CollectionList[12];
    public static void registerPosition(int gridx, int sector) {
        if (sectors[sector] == null) sectors[sector] = new CollectionList<Integer>();
        sectors[sector].add((Integer)gridx);
    }

    public int position = 0;
    public int x = 0;
    public int y = 0;

    public GridPosition(int p) {
        this.position = p;
        this.x = this.position % 64;
        this.y = this.position / 64;
    }

    public GridPosition(int px, int py) {
        this.x = px;
        this.y = py;
        this.position = x + y * 64;
    }

    @Override
    public String toString() {
        DecimalFormat f = new DecimalFormat("000");
        int s = 0;
        for (int i=0;i<GridPosition.sectors.length;i++) {
            if (GridPosition.sectors[i] != null)
                    if (GridPosition.sectors[i].contains(this.position)) s=i+1;
        }
        return "Sektor "+s+" ("+f.format(this.x)+"|"+f.format(this.y)+")";
    }
}
