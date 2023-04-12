using Lift;
using NUnit.Framework;
using NUnit.Framework.Constraints;

namespace LiftTests
{
    public class LiftTests
    {

        
        [Test] 
        public void Test_Check_The_Lift_With_Valid_Input() 
        {
            var lift = new LiftSimulator();

            var waitingPeople = 2;

            int[] currentCabin = { 2, 0 };
            int [] actual = lift.FitPeopleOnTheLift(waitingPeople, currentCabin);

            int[] expected = { 4, 0 };

            Assert.AreEqual(expected, actual);

        }


        [Test]
        public void Test_Check_The_Lift_With_Invalid_Input()
        {
            var lift = new LiftSimulator();

            var waitingPeople = -2;

            int[] currentCabin = { 2, 0 };
            

            Assert.Throws<ArgumentException>(() => lift.FitPeopleOnTheLift(waitingPeople, currentCabin));

        }


        [Test]
        public void Test_Check_The_Lift_With_Invalid_Lift()
        {
            var lift = new LiftSimulator();

            var waitingPeople = 2;

            int[] currentCabin = { -2, -2 };


            Assert.Throws<ArgumentException>(() => lift.FitPeopleOnTheLift(waitingPeople, currentCabin));

        }

        [Test]
        public void Test_Check_The_Lift_With_Invalid_LiftState()
        {
            var lift = new LiftSimulator();

            var waitingPeople = 2;

            int[] currentCabin = {  };


            Assert.Throws<ArgumentException>(() => lift.FitPeopleOnTheLift(waitingPeople, currentCabin));

        }


        [Test]
        public void Test_Assert_The_Lift_Has_Not_Enough_Space()
        {
            var lift = new LiftSimulator();

            var waitingPeople = 2;

            int[] currentCabin = { 4, 4 };
            string actual = lift.FitPeopleOnTheLiftAndGetResult(waitingPeople, currentCabin);

            var expected = "There isn't enough space! 2 people in a queue!\r\n4 4";

            Assert.That(expected, Is.EqualTo(actual));

        }

        
        [Test]
        public void Test_Assert_The_Lift_Is_Full()
        {
            var lift = new LiftSimulator();

            var waitingPeople = 2;

            int[] currentCabin = { 4, 2 };
            string actual = lift.FitPeopleOnTheLiftAndGetResult(waitingPeople, currentCabin);

            var expected = "All people placed and the lift if full.\r\n4 4";

            Assert.AreEqual(expected, actual);

        }

        [Test]
        public void Test_Assert_The_Lift_Has_Empty_Space()
        {
            var lift = new LiftSimulator();

            var waitingPeople = 1;

            int[] currentCabin = { 4, 2 };
            string actual = lift.FitPeopleOnTheLiftAndGetResult(waitingPeople, currentCabin);

            var expected = "The lift has 1 empty spots!\r\n4 3";

            Assert.AreEqual(expected, actual);

        }



    }
}