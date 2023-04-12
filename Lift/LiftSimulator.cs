using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lift
{
    public class LiftSimulator
    {
        const int MAX_SEATS_PER_CABIN = 4;

        public string FitPeopleOnTheLiftAndGetResult(int waitingPeopleCount, int[] inputLiftState)
        {
            int[] liftState = FitPeopleOnTheLift(waitingPeopleCount, inputLiftState);
            int peoplePlaced = liftState.Sum() - inputLiftState.Sum();
            int peopleLeft = waitingPeopleCount - peoplePlaced;
            int maxCapacity = liftState.Length * MAX_SEATS_PER_CABIN;
            int freeSeats = maxCapacity - liftState.Sum();

            string result = string.Empty;

            if (peoplePlaced < waitingPeopleCount)
                result += $"There isn't enough space! {peopleLeft} people in a queue!";
            else if (peoplePlaced == waitingPeopleCount)
                if (freeSeats == 0)
                    result += "All people placed and the lift if full.";
                else
                    result += $"The lift has {freeSeats} empty spots!";
            result += $"{Environment.NewLine}{String.Join(' ', liftState)}";

            return result.TrimEnd();
        }

        public int[] FitPeopleOnTheLift(int peopleCount, int[] inputLiftState)
        {
            //  Check the lift size: number of cabins
            if (inputLiftState == null || inputLiftState.Length == 0)
            {
                throw new ArgumentException(
                    "Invalid lift size. It should have positive number of cabins");
            }

            // Check lift state: overflow / underflow of cabins
            foreach (int seats in inputLiftState)
            {
                if (seats < 0 || seats > MAX_SEATS_PER_CABIN)
                    throw new ArgumentException("Invalid lift seat: " + seats);
            }

            // Check the count of waiting people in the queue
            if (peopleCount <= 0)
            {
                throw new ArgumentException("People waiting should be > 0");
            }

            // Clone the liftState
            int[] liftState = inputLiftState.ToArray();

            // Fill the waiting people into cabin seats
            for (int cabin = 0; cabin < liftState.Length; cabin++)
            {
                while (liftState[cabin] < MAX_SEATS_PER_CABIN)
                {
                    if (peopleCount == 0)
                        break;
                    liftState[cabin]++;
                    peopleCount--;
                }
                if (peopleCount == 0)
                    break;
            }

            return liftState;
        }
    }
}
