using StudentGrading.Models;
using System.Linq;

namespace StudentGrading.StatisticsService;

public static class StatisticsService
{

	// highest mark in the list
	public static int HighestMark(List<int> marks)
	{
		// in case the marks list is empty or null
		if(marks == null || marks.Count == 0) throw new ArgumentException("Marks list cannot be empty.");

		// refactoring using LINQ
		return marks.Max();
	}

	// lowest mark in list
	public static int LowestMark(List<int> marks)
	{
		// in case the marks list is empty or null
		if(marks == null || marks.Count == 0) throw new ArgumentException("Marks list cannot be empty.");

		// refactoring using LINQ
		return marks.Min();
	}

	// average marks of the list
	public static double AverageMarks(List<int> marks)
	{
		if(marks == null || marks.Count ==0) throw new ArgumentException("Marks List cannot be empty.");

		// refactoring loop using LINQ
		return marks.Average();
	}

	// finding total number of student 
	public static int TotalStudents(List<int> students)
	{
		return students.Count;
	}
	

	// pass/fail counter
	public static int PassStudents(List<int> marks)
	{
		// checking for empty list
		if(marks == null || marks.Count == 0){
			throw new ArgumentException("List should not be empty.");
		}

		// using LINQ instead of foreach loop
		int passcount = marks.Count(m => m >= 40);

		return passcount;		
	}

	public static int FailStudents(List<int> marks)
	{
		// using LINQ instead of foreach loop - here, we are counting how many marks satisfy the condition m < 40
		int failcount = marks.Count(m => m < 40);

		return failcount;
	}
	

	// Grade counter method. Here, the pipeline is - marks -> grades -> grouped grades -> dictionary
	public static Dictionary<Grade, int> GradeCounter(List<int> marks)
	{
		if(marks == null || marks.Count == 0)
		{
			throw new ArgumentException("List cannot be empty. Enter valid list of marks.");
		}

		// take each value of Enum, convert them into keys, and initialize their values as 0.
		Dictionary<Grade, int> gradeCounter = Enum.GetValues(typeof(Grade)).Cast<Grade>().ToDictionary(g => g, g => 0);

		// incrementing dict values after each occurance
		foreach(var mark in marks)
		{
			Grade grade = GetGrade(mark);
			gradeCounter[grade]++;
		}

		// returns a dictionary
		return gradeCounter;
	}
}