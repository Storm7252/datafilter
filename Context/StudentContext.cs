using FilteringData.Models;
using Microsoft.EntityFrameworkCore;

namespace FilteringData.Context
{
    public class StudentContext:DbContext
    {
        public StudentContext(DbContextOptions opt):base(opt)
        {
            
        }
        public DbSet<StudentData> Students { get; set; }
    }
}
