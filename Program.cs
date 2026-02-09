using System.Runtime.CompilerServices;
using StudentGrading.Presentation;

class Program
{
	static void Main()
	{
	// Main method starts here		
	List<int> marks = new List<int>()
	{
		20, 30, 40, 56, 2, 67, 78, 89, 90, 12, 23, 34, 54, 76, 87, 89, 100
	};

	marks.Add(99);
	marks.Add(9);
	marks.Add(95);
	marks.Add(19);
	marks.Add(49);

	ReportPrinter.PrintStudentResult(marks);
	ReportPrinter.PrintSummary(marks);
	ReportPrinter.GradeDistribution(marks);

	Console.WriteLine("\nProgram finished successfully!");
	}
}