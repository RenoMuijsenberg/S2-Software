using System.ComponentModel.DataAnnotations;

namespace ProgressTracker.MODEL.Models
{
    public class WorkoutModel
    {
        [Key] public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public string? Note { get; set; }
    }
}
