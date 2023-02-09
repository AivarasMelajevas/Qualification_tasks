using System.Text.RegularExpressions;

namespace Clock
{
    public class Program
    {
        static void Main()
        {
            string hours = string.Empty;
            string minutes = string.Empty;
                        
            Console.WriteLine("Enter the time: ");
            hours = ReadTimeInput(hours, ClockConstants.requireHours, ClockConstants.maxHours);
            minutes = ReadTimeInput(minutes, ClockConstants.requireMinutes, ClockConstants.maxMinutes);

            double angle = CalculateAngle(int.Parse(hours), int.Parse(minutes));
            Console.WriteLine("The angle between the hour and minute is " + angle + " degrees.");
            Console.WriteLine();
        }
        static string ReadTimeInput(string time, string requiredText, int maxTimeValue)
        {                      
            while (!ValidateInput(time, maxTimeValue))
            {
                if (time != string.Empty)
                {
                    Console.WriteLine(ClockConstants.errorCode);
                    Console.WriteLine();
                }
                Console.WriteLine(requiredText);
                time = Console.ReadLine();
            }
            return time;
        }
        static double CalculateAngle(int hours, int minutes)
        {
            double hourAngle = 0.5 * (hours * ClockConstants.maxMinutes + minutes);
            double minuteAngle = 6 * minutes;
            double angle = Math.Abs(hourAngle - minuteAngle);

            angle = Math.Min(angle, ClockConstants.maxAngle - angle);

            return angle;
        }
        static bool ValidateInput(string time, int maxTimeValue)
        {          
            bool validInput = false;

            if (time.Length <= ClockConstants.maxDigits && Regex.IsMatch(time, ClockConstants.digitsPattern))
            {
                validInput = ValidateInputValue(int.Parse(time), maxTimeValue);
            }

            return validInput;
        }
        static bool ValidateInputValue(int time, int maxTimeValue)
        {
            bool validInput = false;

            if (time <= maxTimeValue)
            {
                validInput = true;

            }

            return validInput;
        }
    }
}
