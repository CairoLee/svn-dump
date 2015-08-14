/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.registry.building;

import javax.swing.Icon;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;
import siedleronlineproxy.constants.Building.BuildingCategory;
import siedleronlineproxy.constants.Building.BuildingTypes;
import siedleronlineproxy.constants.Resource;
import siedleronlineproxy.mappings.BuildingVO;
import siedleronlineproxy.mappings.ResourceCreationVO;
import siedleronlineproxy.util.CollectionEnumTable;

/**
 *
 * @author nspecht
 */
public class GenericBuildingTest {
    
    public GenericBuildingTest() {
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
     * Test of setName method, of class GenericBuilding.
     */
    @Test
    public void testSetName() {
        GenericBuilding instance = new GenericBuildingImpl();
        instance.setName("Testname");
        assertSame("Testname", instance.name);
        assertSame("Testname", instance.getName());
    }

    /**
     * Test of setBuildingVO method, of class GenericBuilding.
     */
    @Test
    public void testSetBuildingVO() {
        BuildingVO b = new BuildingVO();
        GenericBuilding instance = new GenericBuildingImpl();
        instance.setBuildingVO(b);
        assertSame(b, instance.buildingVO);
        assertSame(b, instance.getBuildingVO());
    }

    /**
     * Test of setType method, of class GenericBuilding.
     */
    @Test
    public void testSetType() {
        BuildingTypes t = BuildingTypes.BAKERY;
        GenericBuilding instance = new GenericBuildingImpl();
        instance.setType(t);
        assertSame(t, instance.type);
        assertSame(t, instance.getType());
    }

    /**
     * Test of setCategory method, of class GenericBuilding.
     */
    @Test
    public void testSetCategory() {
        BuildingCategory c = BuildingCategory.AKTION;
        GenericBuilding instance = new GenericBuildingImpl();
        instance.setCategory(c);
        assertSame(c, instance.category);
        assertSame(c, instance.getCategory());
    }

    /**
     * Test of getNeeds method, of class GenericBuilding.
     */
    @Test
    public void testGetNeeds() {
        // wird in den Gebäuden getestet
    }

    /**
     * Test of getProducts method, of class GenericBuilding.
     */
    @Test
    public void testGetProducts() {
        //wird in den Gebäuden getestet
    }

    /**
     * Test of setResourceCreation method, of class GenericBuilding.
     */
    @Test
    public void testSetResourceCreation() {
        ResourceCreationVO c = new ResourceCreationVO();
        GenericBuilding instance = new GenericBuildingImpl();
        instance.setResourceCreation(c);
        assertSame(c, instance.resourceCreationVO);
        assertSame(c, instance.getResourceCreation());
    }

    /**
     * Test of getCycleTime method, of class GenericBuilding.
     */
    @Test
    public void testGetCycleTime() {
        GenericBuilding instance = new GenericBuildingImpl();
        int expResult = 86400;
        int result = instance.getCycleTime();
        assertEquals(expResult, result);
    }

    /**
     * Test of getResourceTime method, of class GenericBuilding.
     */
    @Test
    public void testGetResourceTime() {
        GenericBuilding instance = new GenericBuildingImpl();
        int expResult = 0;
        int result = instance.getResourceTime();
        assertEquals(expResult, result);
    }

    /**
     * Test of getWarehouseTime method, of class GenericBuilding.
     */
    @Test
    public void testGetWarehouseTime() {
        GenericBuilding instance = new GenericBuildingImpl();
        int expResult = 0;
        int result = instance.getWarehouseTime();
        assertEquals(expResult, result);
    }

    /**
     * Test of getCyclesPerDay method, of class GenericBuilding.
     */
    @Test
    public void testGetCyclesPerDay() {
        GenericBuilding instance = new GenericBuildingImpl();
        double expResult = 1.0;
        double result = instance.getCyclesPerDay();
        assertEquals(expResult, result, 0.0);
    }

    /**
     * Test of getBuffs method, of class GenericBuilding.
     */
    @Test
    public void testGetBuffs() {
        GenericBuilding instance = new GenericBuildingImpl();
        String expResult = "";
        String result = instance.getBuffs();
        assertEquals(expResult, result);
    }

    /**
     * Test of isBuffed method, of class GenericBuilding.
     */
    @Test
    public void testIsBuffed() {
        GenericBuilding instance = new GenericBuildingImpl();
        boolean expResult = false;
        boolean result = instance.isBuffed();
        assertEquals(expResult, result);
    }

    /**
     * Test of getNeedsPerDay method, of class GenericBuilding.
     */
    @Test
    public void testGetNeedsPerDay() {
        GenericBuilding instance = new GenericBuildingImpl();
        CollectionEnumTable<Resource.Products, Double> expResult = 
                new CollectionEnumTable<Resource.Products, Double>(Resource.Products.class);
        CollectionEnumTable result = instance.getNeedsPerDay();
        assertEquals(expResult, result);
    }

    /**
     * Test of getNeedsPerDayByLevel method, of class GenericBuilding.
     */
    @Test
    public void testGetNeedsPerDayByLevel() {
        GenericBuilding instance = new GenericBuildingImpl();
        CollectionEnumTable<Resource.Products, Double> expResult = 
                new CollectionEnumTable<Resource.Products, Double>(Resource.Products.class);
        CollectionEnumTable result = instance.getNeedsPerDayByLevel(1);
        assertEquals(expResult, result);
    }

    /**
     * Test of getProducesPerDay method, of class GenericBuilding.
     */
    @Test
    public void testGetProducesPerDay() {
        GenericBuilding instance = new GenericBuildingImpl();
        CollectionEnumTable<Resource.Products, Double> expResult = 
                new CollectionEnumTable<Resource.Products, Double>(Resource.Products.class);
        CollectionEnumTable result = instance.getProducesPerDay();
        assertEquals(expResult, result);
    }

    /**
     * Test of getProducesPerDayByLevel method, of class GenericBuilding.
     */
    @Test
    public void testGetProducesPerDayByLevel() {
        GenericBuilding instance = new GenericBuildingImpl();
        CollectionEnumTable<Resource.Products, Double> expResult = 
                new CollectionEnumTable<Resource.Products, Double>(Resource.Products.class);
        CollectionEnumTable result = instance.getProducesPerDayByLevel(1);
        assertEquals(expResult, result);
    }

    /**
     * Test of pause method, of class GenericBuilding.
     */
    @Test
    public void testPause() {
        GenericBuilding instance = new GenericBuildingImpl();
        instance.setBuildingVO(new BuildingVO());
        instance.pause();
        assertFalse(instance.buildingVO.isProductionActive);
        instance.unpause();
        assertTrue(instance.buildingVO.isProductionActive);
    }

    /**
     * Test of distanceInGrid method, of class GenericBuilding.
     */
    @Test
    public void testDistanceInGrid_int() {
        GenericBuilding instance = new GenericBuildingImpl();
        instance.setBuildingVO(new BuildingVO());
        instance.buildingVO.buildingGrid = 0;
        
        assertEquals(10, instance.distanceInGrid(2));
        assertEquals(18, instance.distanceInGrid(4));
    }

    /**
     * Test of distanceInGrid method, of class GenericBuilding.
     */
    @Test
    public void testDistanceInGrid_int_int() {
        GenericBuilding instance = new GenericBuildingImpl();
        assertEquals(10, instance.distanceInGrid(0, 2));
        assertEquals(18, instance.distanceInGrid(0, 4));
    }

    /**
     * Test of distanceCityBlock method, of class GenericBuilding.
     */
    @Test
    public void testDistanceCityBlock() {
        GenericBuilding instance = new GenericBuildingImpl();
        assertEquals(2, instance.distanceCityBlock(0, 2));
        assertEquals(4, instance.distanceCityBlock(0, 4));
    }

    /**
     * Test of getIcon method, of class GenericBuilding.
     */
    @Test
    public void testGetIcon() {
        GenericBuilding instance = new GenericBuildingImpl();
        assertNotNull(instance.getIcon());
    }

    public class GenericBuildingImpl extends GenericBuilding {
    }
}
