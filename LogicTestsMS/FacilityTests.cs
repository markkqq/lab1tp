using Microsoft.VisualStudio.TestTools.UnitTesting;
using petrolstation;
using System.Collections.Generic;
namespace LogicTestsMS
{
    [TestClass]
    public class FacilityTests
    {

        [TestMethod]
        public void Fuel_is_not_available()
        {
            //Arrange
            List<Fuel> fuels = new List<Fuel>();
            for(int i = 0; i < 5; i++)
            {
                Fuel fuel = new(i.ToString(), i * 100); // 0,0; 1,100; 2,200; 3,300; 4,400;
                fuels.Add(fuel);
            }
            Facility facility = new Facility(fuels);
            Fuel fuelToTest = new Fuel(5.ToString(), 500) ;

            //Assert

            Assert.IsFalse(facility.ContainsFuel(fuelToTest));
            
        }
        public void Fuel_is_available()
        {
            List<Fuel> fuels = new List<Fuel>();
            for (int i = 0; i < 5; i++)
            {
                Fuel fuel = new(i.ToString(), i * 100); // 0,0; 1,100; 2,200; 3,300; 4,400;
                fuels.Add(fuel);
            }
            Facility facility = new Facility(fuels);
            Fuel fuelToTest = new Fuel(4.ToString(), 400);

            //Assert

            Assert.IsTrue(facility.ContainsFuel(fuelToTest));
        }
    }
}
