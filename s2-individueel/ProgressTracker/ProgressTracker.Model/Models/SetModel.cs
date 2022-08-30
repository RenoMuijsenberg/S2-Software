using System.ComponentModel.DataAnnotations;

namespace ProgressTracker.MODEL.Models;

public class SetModel
{
    [Key] public Guid Id { get; set; }
    public Guid ExerciseId { get; set; }
    public string Set { get; set; }
    public DateTime Date { get; set; }
}