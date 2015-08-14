/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.registry.building;

import siedleronlineproxy.constants.Building.BuildingCategory;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;

/**
 *
 * @author nspecht
 */
public class GenericNPCBuildingTest {
    
    public GenericNPCBuildingTest() {
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
        GenericNPCBuilding instance = new GenericNPCBuilding();
        assertTrue(GenericDoNothingBuilding.class.isInstance(instance));
        assertEquals(BuildingCategory.NPC, instance.category);
        assertEquals(BuildingCategory.NPC, instance.getCategory());
    }
}
