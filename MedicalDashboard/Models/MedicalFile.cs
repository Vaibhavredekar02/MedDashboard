using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MedicalDashboard.Models
{
    public class MedicalFile
    {
        [Key]
        public int FileId { get; set; }

        [Required]
        [ForeignKey("User")]
        public int UserId { get; set; }

        [Required]
        [MaxLength(150)]
        public string FileName { get; set; }

        [Required]
        [MaxLength(50)]
        public string FileType { get; set; }

        [Required]
        [MaxLength(255)]
        public string FilePath { get; set; }

        public DateTime UploadedAt { get; set; } = DateTime.Now;

        public virtual User User { get; set; }
    }
}
