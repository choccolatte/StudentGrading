using System.Runtime.CompilerServices;
using StudentGrading.Models;

namespace StudentGrading.Services;

public static class GradeService
{
	// grading logic
	public static Grade GetGrade(int marks)
	{
		if (marks >= 95) return Grade.APlus;
		else if (marks >= 85) return Grade.A;
		else if (marks >= 70) return Grade.B;
		else if (marks >= 55) return Grade.C;
		else if (marks >= 40) return Grade.D;
		else return Grade.F;
	}

	// passing logic
	public static bool IsPassed(int marks)
	{
		return marks <= 40;
	}
}