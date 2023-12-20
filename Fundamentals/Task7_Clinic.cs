namespace Fundamentals_Task7
{
    internal class Clinic
    {
        public static void Main(string[] args)
        {
            Console.Write("Print the count of peoples in the queue: ");

            int lengthOfQueue = Convert.ToInt32(Console.ReadLine());

            int peopleServiceTimeInMinutes = 10;
            int minutesPerHour = 60;

            int waitingTime = lengthOfQueue * peopleServiceTimeInMinutes;
            int waitingHours = waitingTime / minutesPerHour;
            int waitingMinutes = waitingTime % minutesPerHour;

            Console.WriteLine($"Hours: {waitingHours} Minutes: {waitingMinutes}");
        }
    }
}
