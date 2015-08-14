/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package siedleronlineproxy.constants;

import javax.swing.Icon;
import org.junit.After;
import org.junit.AfterClass;
import org.junit.Before;
import org.junit.BeforeClass;
import org.junit.Test;
import static org.junit.Assert.*;
import siedleronlineproxy.constants.Resource.Products;

/**
 *
 * @author nspecht
 */
public class ResourceTest {
    
    public ResourceTest() {
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
     * Test of getInstance method, of class Resource.
     */
    @Test
    public void testGetInstance() {
        assertNotNull(Resource.getInstance());
    }

    /**
     * Test of getIconByString method, of class Resource.
     */
    @Test
    public void testGetIconByString() {
        assertNotNull(Resource.getIconByString("BEER"));
    }

    /**
     * Test of getNameByType method, of class Resource.
     */
    @Test
    public void testGetNameByType() {
        assertEquals("Bier", Resource.getNameByType(Products.BEER));
    }

    /**
     * Test of getNameByString method, of class Resource.
     */
    @Test
    public void testGetNameByString() {
        assertEquals("Bier", Resource.getNameByString("beer"));
    }

    /**
     * Test of getTypeByString method, of class Resource.
     */
    @Test
    public void testGetTypeByString() {
        assertEquals(Products.BEER, Resource.getTypeByString("beer"));
    }

    /**
     * Test of getIconByType method, of class Resource.
     */
    @Test
    public void testGetIconByType() {
        assertNotNull(Resource.getIconByType(Products.BEER));
    }
    
    /**
     * Test Count of resources and deposits
     */
    @Test
    public void testCount() {
        assertEquals(75, Products.values().length);
        assertEquals(18, Resource.Deposits.values().length);
    }
}
