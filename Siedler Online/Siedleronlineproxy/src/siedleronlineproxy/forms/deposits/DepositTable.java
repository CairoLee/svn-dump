/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.forms.deposits;

import siedleronlineproxy.debug.DebugLog;
import siedleronlineproxy.forms.GenericTable;
import siedleronlineproxy.forms.GridPosition;
import siedleronlineproxy.mappings.DepositVO;
import siedleronlineproxy.registry.DepositRegistry;

/**
 *
 * @author nspecht
 */
public class DepositTable extends GenericTable {

    private static final long serialVersionUID = 1L;
    public String filter = "";

    public DepositTable() {
        super();
        this.acr.setIconSize(16);
        this.model.addColumn("Position");
        this.model.addColumn("Name");
        this.model.addColumn("Zugänglich");
        this.model.addColumn("Current");
        this.model.addColumn("Max");
        this.model.addColumn("Prozent");
        this.model.addColumn("Emptied");

        this.getColumnModel().getColumn(0).setMaxWidth(140);
        this.getColumnModel().getColumn(0).setMinWidth(140);

        for (int i=2;i<=6;i++) {
            this.getColumnModel().getColumn(i).setMaxWidth(100);
            this.getColumnModel().getColumn(i).setMinWidth(100);
        }
    }

    public void perform_update() {
        if (DepositRegistry.getInstance().lastChange.getTime() <= this.lastUpdate.getTime()) {
            return;
        }

        this.flushElements();

        Object[] items = DepositRegistry.getInstance().getItems().toArray();
        for (Object i : items) {
            try {
                if (i != null) {
                    DepositVO item = (DepositVO)i;
                    boolean add = false;

                    if (this.filter.equals("")) {
                        add = true;
                    } else if (this.filter.contains(item.name_string)) {
                        add = true;
                    }

                    if (add) {
                        this.model.addRow(new Object[]{
                                    new GridPosition(item.gridIdx),
                                    item,
                                    item.accessible,
                                    item.amount,
                                    item.maxAmount,
                                    (double) item.amount * 100 / (double) item.maxAmount,
                                    item.emptied
                                });
                    }
                }
            } catch (java.util.ConcurrentModificationException e) {
                this.update();
            } catch (Exception e) {
                DebugLog.put(this, e);
            }
        }
    }
}
