/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */

/*
 * HelpBox.java
 *
 * Created on 24.05.2011, 13:20:14
 */

package siedleronlineproxy;

/**
 *
 * @author nspecht
 */
public class CopyrightBox extends javax.swing.JPanel {

    /** Creates new form HelpBox */
    public CopyrightBox() {
        initComponents();
    }

    /** This method is called from within the constructor to
     * initialize the form.
     * WARNING: Do NOT modify this code. The content of this method is
     * always regenerated by the Form Editor.
     */
    @SuppressWarnings("unchecked")
    // <editor-fold defaultstate="collapsed" desc="Generated Code">//GEN-BEGIN:initComponents
    private void initComponents() {

        jScrollPane1 = new javax.swing.JScrollPane();
        jEditorPane1 = new javax.swing.JEditorPane();

        setName("Form"); // NOI18N
        setLayout(new javax.swing.BoxLayout(this, javax.swing.BoxLayout.LINE_AXIS));

        jScrollPane1.setName("jScrollPane1"); // NOI18N

        org.jdesktop.application.ResourceMap resourceMap = org.jdesktop.application.Application.getInstance(siedleronlineproxy.SiedlerOnlineProxyApp.class).getContext().getResourceMap(CopyrightBox.class);
        jEditorPane1.setContentType(resourceMap.getString("jEditorPane1.contentType")); // NOI18N
        jEditorPane1.setText(resourceMap.getString("jEditorPane1.text")); // NOI18N
        jEditorPane1.setName("jEditorPane1"); // NOI18N
        jScrollPane1.setViewportView(jEditorPane1);

        add(jScrollPane1);
    }// </editor-fold>//GEN-END:initComponents


    // Variables declaration - do not modify//GEN-BEGIN:variables
    private javax.swing.JEditorPane jEditorPane1;
    private javax.swing.JScrollPane jScrollPane1;
    // End of variables declaration//GEN-END:variables

}
