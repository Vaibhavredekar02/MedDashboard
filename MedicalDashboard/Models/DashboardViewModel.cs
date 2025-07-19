using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MedicalDashboard.Models
{
    public class DashboardViewModel
    {
        public User User { get; set; }
        public List<MedicalFile> UploadedFiles { get; set; }
    }
}