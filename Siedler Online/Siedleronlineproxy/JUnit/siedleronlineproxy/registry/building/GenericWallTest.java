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
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.mappings.BuildingVO;

/**
 *
 * @author nspecht
 */
public class GenericWallTest {
    
    public GenericWallTest() {
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
        GenericWall instance = new GenericWall();
        assertTrue(GenericDoNothingBuilding.class.isInstance(instance));
        assertTrue(GenericDecoration.class.isInstance(instance));
        assertEquals(BuildingCategory.WALL, instance.category);
        assertEquals(BuildingCategory.WALL, instance.getCategory());
    }
}
