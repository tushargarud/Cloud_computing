using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity.SqlServer;

namespace ContosoTeamStats.Models
{
    public class Education
    {
        [Key]
        public int UNITID { get; set; }
        public int OPEID { get; set; }
        public int OPEID6 { get; set; }
        public string INSTNM { get; set; }
        public string CITY { get; set; }
        public string STATE { get; set; }
        public string INSTURL { get; set; }
        public string SAT_AVG { get; set; }
        public string GRADDEBT { get; set; }
    }

    [DbConfigurationType(typeof(ContosoTeamStats.Models.EducationConfiguration))]
    public class EducationContext : DbContext
    {
        public EducationContext()
            : base("EducationContext")
        {
        }

        public System.Data.Entity.DbSet<ContosoTeamStats.Models.Education> Educations { get; set; }
    }

    public class EducationConfiguration : DbConfiguration
    {
        public EducationConfiguration()
        {
            SetExecutionStrategy("System.Data.SqlClient", () => new SqlAzureExecutionStrategy());
        }
    }

}