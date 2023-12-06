namespace ApiUniversity.Models;

public enum Grade { A, B, C, D, F }
public class Enrollment
{
    public int Id { get; set; }
    public Grade Grade { get; set; }
    public int StudentId { get; set; }
    public int CourseId { get; set; }
    public Student Student { get; set; } = null!;
    public Course Course { get; set; } = null!;

    public Enrollment() { }
    
    public Enrollment(DetailedEnrollmentDTO enrollment){
        Id = enrollment.Id;
        Grade = enrollment.Grade;
        Student = enrollment.Student;
        Course = enrollment.Course;
    }

     public Enrollment(EnrollmentDTO enrollment){
        Id = enrollment.Id;
        Grade = enrollment.Grade;
        StudentId = enrollment.StudentId;
        CourseId = enrollment.CourseId;
    }
}