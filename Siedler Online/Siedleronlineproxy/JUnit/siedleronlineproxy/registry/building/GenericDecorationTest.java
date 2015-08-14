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
public class GenericDecorationTest {
    
    public GenericDecorationTest() {
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

    /**
     * Test of setBuildingVO method, of class GenericDecoration.
     */
    @Test
    public void testSetBuildingVO() {
        BuildingVO bvo = new BuildingVO();
        GenericDecoration instance = new GenericDecoration();
        instance.setBuildingVO(bvo);
        assertSame(bvo, instance.buildingVO);
        assertSame(bvo, instance.getBuildingVO());
    }

    /**
     * Test of setType method, of class GenericDecoration.
     */
    @Test
    public void testSetType() {
        GenericDecoration instance = new GenericDecoration();
        instance.setType(BuildingTypes.BAKERY);
        assertSame(BuildingTypes.BAKERY, instance.type);
        assertSame(BuildingTypes.BAKERY, instance.getType());
        assertSame("BAKERY", instance.name);
        assertSame("BAKERY", instance.getName());
    }

    /**
     * Test of pause method, of class GenericDecoration.
     */
    @Test
    public void testPause() {
        GenericDecoration instance = new GenericDecoration();
        instance.setBuildingVO(new BuildingVO());
        instance.pause();
        assertSame(true, instance.getBuildingVO().isProductionActive);
    }
    
    @Test
    public void testBuilding() {
        GenericDecoration instance = new GenericDecoration();
        assertTrue(GenericDoNothingBuilding.class.isInstance(instance));
        assertEquals(BuildingCategory.DEKO, instance.category);
        assertEquals(BuildingCategory.DEKO, instance.getCategory());
    }
}
