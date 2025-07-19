using MedicalDashboard.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext() : base("DefaultConnection") { }

    public DbSet<MedicalFile> MedicalFiles { get; set; }
    public DbSet<User> Users { get; set; }


    

}