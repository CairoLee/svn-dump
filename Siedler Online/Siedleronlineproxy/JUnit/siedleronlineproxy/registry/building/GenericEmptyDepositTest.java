/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.registry.building;

import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import siedleronlineproxy.constants.Building.BuildingCategory;
import static org.junit.Assert.*;

/**
 *
 * @author nspecht
 */
public class GenericEmptyDepositTest {
    
    public GenericEmptyDepositTest() {
    }

    @BeforeClass
    public static void setUpClass() throws Exception {
    }

    @AfterClass
    public static void tearDownClass() throws Exception {
    }
    
    @Before
    public void setUp() {
    }
    
    @After
    public void tearDown() {
    }

    @Test
    public void testBuilding() {
        GenericEmptyDeposit instance = new GenericEmptyDeposit();
        assertTrue(GenericDoNothingBuilding.class.isInstance(instance));
        assertEquals(BuildingCategory.EMPTYDEPOSIT, instance.category);
        assertEquals(BuildingCategory.EMPTYDEPOSIT, instance.getCategory());
    }
}
