using StudentGrading.Services;

namespace StudentGrading.Presentation;

public static class ReportPrinter
{
		// Print Student Result method 
	public static void PrintStudentResult(List<int> marks)
	{
		// what if list is empty
		if(marks == null || marks.Count == 0)
		{
			throw new ArgumentException("No student data available.");
		}

		Console.WriteLine("\n-----Summary-----");

		// refactoring using LINQ
		var summaries = marks.Select(mark => new{
			Mark = mark,
			Grade = GetGrade(mark),
			Passed = IsPassed(mark)
		});

		foreach(var s in summaries){
			Console.WriteLine($"Marks: {s.Mark}, Grade: {s.Grade}, Result: {(s.Passed ? "Pass" : "Fail")}");
		}
	}

	// print summary method
	public static void PrintSummary(List<int> marks)
	{
		// 1. If marks list is null or empty, print message and return
		if(marks == null || marks.Count == 0)
		{
			throw new ArgumentException("List cannot be empty.");
		}

		Console.WriteLine("\n----------Mark Summary----------");
		
		// 2. Calculate total students
		int total = StatisticsService.TotalStudents(marks);
		Console.WriteLine($"Total Students: {total}");

		// 3. Calculate passed students
		int passStudents = GradeService.PassStudents(marks);
		Console.WriteLine($"Passed Students: {passStudents}");

		// 4. Calculate failed students
		int failStudents = GradeService.FailStudents(marks);
		Console.WriteLine($"Failed Students: {failStudents}");

		// 5. Calculate average marks
		double averageMark = StatisticsService.AverageMarks(marks);
		Console.WriteLine($"Average Marks: {averageMark}");

		// 6. Find highest mark
		int highestMark = StatisticsService.HighestMark(marks);
		Console.WriteLine($"Highest Mark: {highestMark}");

		// 7. Find lowest mark
		int lowestMark = StatisticsService.LowestMark(marks);
		Console.WriteLine($"Lowest Mark: {lowestMark}");

		// 8. Print all values in a clean format
		// printed already above
	}

	// grade distribution of students
	static void GradeDistribution(List<int> marks)
	{
		// calling dictionary method
		Dictionary<Grade, int> gradeSummmary = GradeCounter(marks);

		// printing dictionary
		Console.WriteLine("\n-----Grade Distribution-----");
		foreach(var kvp in gradeSummmary)
		{
			Console.WriteLine($"{kvp.Key}: {kvp.Value}");
		}
	}
}