using Lift;

public class StartUp
{
    static void Main()
    {
        int totalCountOfPeople = int.Parse(Console.ReadLine());

        int[] currentStateOfTheLift = 
            Console.ReadLine().Split().Select(int.Parse).ToArray();

        LiftSimulator liftSimulator = new LiftSimulator();

        string result = liftSimulator.FitPeopleOnTheLiftAndGetResult(totalCountOfPeople, currentStateOfTheLift);

        Console.Write(result);
    }

    
}
