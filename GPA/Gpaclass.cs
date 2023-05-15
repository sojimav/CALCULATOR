using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GPA
{
    internal class Gpaclass
    {
        public static string courseCode = "";
        public static int courseUnit = 0;
        public static double courseScore = 0;
        public static double totalWeightPoint;
        public static int totalCourseUnitPassed;
        public static int totalCourseUnit;
        public static float gradePointAverage;
        public static double weightPoint;
        public static double gradeUnit;
        public static string userName = "";
        public string collectNoOfCourse = "";
        public static int numberOfCourse;
        public static string theGrades = "";
        public static string theRemarks = "";
        public static int result;
        public static string dataTable = "";
        public static string tableList = "";
        private static int garbage = 0;
        private static int unitGarbage = 0;
        private static double unitScoreGarbage;
        public string receiveUnit = "";
        public string receiveScore = "";

        public Gpaclass(string name)
        {
            userName = name;
        }

        enum GradeUnit
        {
            zeroTo39 = 0,
            fortyTo44 = 1,
            fortyfiveTo49 = 2,
            fiftyTo59 = 3,
            sixtyTo69 = 4,
            seventyTo100 = 5,
        }

        string[] grade = { "A", "B", "C", "D", "E", "F" };
        string[] remark = { "Excellent", "Very Good", "Good", "Fair", "Pass", "Fail" };

        public float CollectData()
        {
            do
            {
                Console.Clear();
                Console.Write($"Welcome! {userName}, input the number of courses you want to calculate: ");
                collectNoOfCourse = Console.ReadLine()!;
            }
            while (!int.TryParse(collectNoOfCourse, out garbage));

            numberOfCourse = int.Parse(collectNoOfCourse);

            Console.WriteLine();

            for (int i = 0; i < numberOfCourse; i++)
            {
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter a Valid Course Code e.g (Mat101 or MAT101)");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.Write("Enter Course Name and Code: ");
                    courseCode = Console.ReadLine()!;
                } while (!Regex.IsMatch(courseCode, @"^[A-z]{3}[0-9]{3}$"));

                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter a valid figure between 1 to 5");
                    Console.ResetColor();
                    Console.WriteLine();
                    Console.Write($"Enter Course Unit for {courseCode}: ");
                    receiveUnit = Console.ReadLine()!;

                }
                while (!int.TryParse(receiveUnit, out unitGarbage) || int.Parse(receiveUnit) < 1 || int.Parse(receiveUnit) > 5);

                courseUnit = int.Parse(receiveUnit);
                do
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"Please {userName}, enter a valid score between 1 and 100");
                    Console.WriteLine();
                    Console.ResetColor();
                    Console.Write($"Enter Course Score for {courseCode}: ");
                    receiveScore = Console.ReadLine()!;
                    Console.Clear();
                }
                while (!double.TryParse(receiveScore, out unitScoreGarbage) || double.Parse(receiveScore) < 1 || double.Parse(receiveScore) > 100);

                courseScore = double.Parse(receiveScore);

                gradeUnit = CalculateGradeUnit(courseScore);
                if (gradeUnit >= 1)
                {
                    totalCourseUnitPassed += courseUnit;
                }

                theGrades = (result == 5) ? grade[0] : (result == 4) ? grade[1] : (result == 3)
                  ? grade[2] : (result == 2) ? grade[3] : (result == 1) ? grade[4] : grade[5];

                theRemarks = (result == 5) ? remark[0] : (result == 4) ? remark[1] : (result == 3) ? remark[2] : (result == 2) ?
                  remark[3] : (result == 1) ? remark[4] : remark[5];

                weightPoint = courseUnit * gradeUnit;

                dataTable = $"|    {courseCode.PadLeft(7),-14} | {courseUnit.ToString().PadLeft(7),-16}" +
                    $" | {theGrades.PadLeft(7),-13} |  {gradeUnit.ToString().PadLeft(7),-13} |  {weightPoint.ToString().PadLeft(7),-11} " +
                    $"|  {theRemarks.PadLeft(9),-13}  | ";

                totalWeightPoint += weightPoint;
                totalCourseUnit += courseUnit;
                tableList += $"{dataTable} \n";

            }

            gradePointAverage = (float)totalWeightPoint / totalCourseUnit;

            return gradePointAverage;
        }

        static double CalculateGradeUnit(double param)
        {

            switch (param)
            {
                case double score when (score >= 70 && score <= 100):
                    result = (int)GradeUnit.seventyTo100;
                    break;
                case double score when (score >= 60 && score <= 69):
                    result = (int)GradeUnit.sixtyTo69;
                    break;
                case double score when (score >= 50 && score <= 59):
                    result = (int)GradeUnit.fiftyTo59;
                    break;
                case double score when (score >= 45 && score <= 49):
                    result = (int)GradeUnit.fortyfiveTo49;
                    break;
                case double score when (score >= 40 && score <= 44):
                    result = (int)GradeUnit.fortyTo44;
                    break;
                default:
                    result = (int)GradeUnit.zeroTo39;
                    break;
            }

            return result;
        }

        public void PrintResult()
        {
            Console.WriteLine(tableList);
            Console.WriteLine("\n");
            Console.WriteLine($"Total Course Unit Registered is {totalCourseUnit}");
            Console.WriteLine($"Total Course Unit Passed is {totalCourseUnitPassed}");
            Console.WriteLine($"Total Weight Point is {totalWeightPoint}");
            Console.WriteLine();
            Console.WriteLine($"Your GPA is = {gradePointAverage.ToString("0.00")}");
        }

    }
}
