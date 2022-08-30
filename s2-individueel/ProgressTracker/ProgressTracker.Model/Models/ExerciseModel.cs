using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgressTracker.MODEL.Models
{
    public class ExerciseModel
    {
        [Key] public Guid Id { get; set; }
        public Guid SchemeId { get; set; }
        public string Name { get; set; }
        public int Sets { get; set; }
        public string? Note { get; set; }
    }
}
