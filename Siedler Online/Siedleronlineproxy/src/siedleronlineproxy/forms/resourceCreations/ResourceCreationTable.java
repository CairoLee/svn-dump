/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.forms.resourceCreations;

import java.util.Date;
import siedleronlineproxy.constants.Resource.Products;
import siedleronlineproxy.forms.GenericTable;
import siedleronlineproxy.registry.BuildingRegistry;
import siedleronlineproxy.util.CollectionEnumTable;

/**
 *
 * @author nspecht
 */
public class ResourceCreationTable extends GenericTable {
    private static ResourceCreationTable instance = null;
    public static ResourceCreationTable getInstance() {
        //if (ResourceCreationTable.instance == null) ResourceCreationTable.instance = new ResourceCreationTable();
        return ResourceCreationTable.instance;
    }

    private static final long serialVersionUID = 1L;

    public ResourceCreationTable() {
        super();
        ResourceCreationTable.instance = this;
        this.acr.setIconSize(24);
        this.model.addColumn("Name");
        this.model.addColumn("Produktion");
        this.model.addColumn("Verbrauch");
        this.model.addColumn("Gesamt");
        this.model.addColumn("Buffs");
        this.model.addColumn("Gesamt (Buffs)");

        for (int i=1;i<=5;i++) {
            this.getColumnModel().getColumn(i).setMaxWidth(100);
            this.getColumnModel().getColumn(i).setMinWidth(100);
        }
    }

    public void perform_update() {
        if (BuildingRegistry.getInstance().lastChange.getTime() <= this.lastUpdate.getTime()) {
            return;
        }

        this.flushElements();
        
        CollectionEnumTable<Products,Double> productivity[] = BuildingRegistry.getInstance().getProductivity();

        for (Products p : Products.values()) {
            double ne = 0;
            double pr = 0;
            double nebuffed = 0;
            double prbuffed = 0;

            if (productivity[0].containsKey(p)) {
                ne = productivity[0].get(p);
                nebuffed = productivity[2].get(p);
            }
            if (productivity[1].containsKey(p)) {
                pr = productivity[1].get(p);
                prbuffed = productivity[3].get(p);
            }

            if (ne != 0 || pr != 0) {
            this.model.addRow(new Object[]{
                p,
                pr,
                (ne),
                (pr-ne),
                ((prbuffed-nebuffed) - (pr-ne)),
                (prbuffed-nebuffed)
            });
            }

        }
        this.lastUpdate = new Date();
    }
}
