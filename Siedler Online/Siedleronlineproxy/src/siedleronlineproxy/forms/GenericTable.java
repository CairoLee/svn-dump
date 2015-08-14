/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

package siedleronlineproxy.forms;

import java.lang.reflect.InvocationTargetException;
import java.util.Date;
import javax.swing.JTable;
import javax.swing.SwingUtilities;
import javax.swing.table.DefaultTableModel;
import javax.swing.table.TableRowSorter;
import siedleronlineproxy.debug.DebugLog;

/**
 *
 * @author nspecht
 */
public abstract class GenericTable extends JTable {
    protected AdvancedCellRenderer acr = null;
    protected TableRowSorter<DefaultTableModel> sorter = null;
    protected DefaultTableModel model = null;
    protected Date lastUpdate = new Date();

    protected abstract void perform_update();

    public GenericTable() {
        super();
        sorter = new TableRowSorter<DefaultTableModel>();
        this.acr = AdvancedCellRenderer.setCellRenderer(this);
        acr.setIconSize(32);
        this.setRowSorter(sorter);
        this.setAutoCreateRowSorter(true);

        this.model = new DefaultTableModel() {
            @Override
            public boolean isCellEditable(int a, int b) {
                return false;
            }
        };

        this.setModel(this.model);
    }

    public void forceUpdate() {
        this.lastUpdate = new Date();
        this.lastUpdate.setTime(0);
        this.update();
    }

    public void update() {
        try {
            SwingUtilities.invokeAndWait(new Runnable() {
                public void run() {
                    perform_update();
                }
            });
        } catch (InterruptedException ex) {
            DebugLog.put(this, ex);
        } catch (InvocationTargetException ex) {
            DebugLog.put(this, ex);
        }
        this.lastUpdate = new Date();
    }

    protected void flushElements() {
        this.clearSelection();
        this.setCellSelectionEnabled(false);
        int size = this.model.getRowCount()-1;
        if (size > 0) {
            this.model.getDataVector().removeAllElements();
            this.model.fireTableRowsDeleted(0, size);
        }
        this.setCellSelectionEnabled(true);
    }
}
