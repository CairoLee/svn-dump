/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * BuildingCalculation.java
 *
 * Created on 23.05.2011, 14:16:24
 */

package siedleronlineproxy.forms.buildings;

import siedleronlineproxy.registry.building.GenericBuilding;

/**
 *
 * @author nspecht
 */
public class BuildingCalculation extends javax.swing.JPanel {

    /** Creates new form BuildingCalculation */
    public BuildingCalculation() {
        initComponents();
    }

    public void setBuilding(GenericBuilding b) {
        this.buildingProductivityTable1.setBuilding(b);
        this.jSpinner1.setValue(Integer.valueOf(b.getBuildingVO().upgradeLevel));
    }

    /** This method is called from within the constructor to
     * initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is
     * always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {
        java.awt.GridBagConstraints gridBagConstraints;

        jScrollPane1 = new javax.swing.JScrollPane();
        buildingProductivityTable1 = new siedleronlineproxy.forms.buildings.BuildingProductivityTable();
        jSpinner1 = new javax.swing.JSpinner();

        setName("Form"); // NOI18N
        setLayout(new java.awt.GridBagLayout());

        jScrollPane1.setName("jScrollPane1"); // NOI18N

        buildingProductivityTable1.setName("buildingProductivityTable1"); // NOI18N
        jScrollPane1.setViewportView(buildingProductivityTable1);

        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 0;
        gridBagConstraints.gridy = 1;
        gridBagConstraints.gridwidth = 2;
        gridBagConstraints.fill = java.awt.GridBagConstraints.BOTH;
        gridBagConstraints.weightx = 1.0;
        gridBagConstraints.weighty = 1.0;
        add(jScrollPane1, gridBagConstraints);

        jSpinner1.setModel(new javax.swing.SpinnerNumberModel(Integer.valueOf(1), Integer.valueOf(1), null, Integer.valueOf(1)));
        jSpinner1.setEditor(new javax.swing.JSpinner.NumberEditor(jSpinner1, ""));
        jSpinner1.setFocusable(false);
        jSpinner1.setName("jSpinner1"); // NOI18N
        jSpinner1.addChangeListener(new javax.swing.event.ChangeListener() {
            public void stateChanged(javax.swing.event.ChangeEvent evt) {
                jSpinner1StateChanged(evt);
            }
        });
        gridBagConstraints = new java.awt.GridBagConstraints();
        gridBagConstraints.gridx = 1;
        gridBagConstraints.gridy = 0;
        gridBagConstraints.fill = java.awt.GridBagConstraints.HORIZONTAL;
        gridBagConstraints.weightx = 0.5;
        add(jSpinner1, gridBagConstraints);
    }// </editor-fold>//GEN-END:initComponents

    private void jSpinner1StateChanged(javax.swing.event.ChangeEvent evt) {//GEN-FIRST:event_jSpinner1StateChanged
        this.buildingProductivityTable1.setLevel((Integer)this.jSpinner1.getValue());
    }//GEN-LAST:event_jSpinner1StateChanged


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private siedleronlineproxy.forms.buildings.BuildingProductivityTable buildingProductivityTable1;
    private javax.swing.JScrollPane jScrollPane1;
    private javax.swing.JSpinner jSpinner1;
    // End of variables declaration//GEN-END:variables

}