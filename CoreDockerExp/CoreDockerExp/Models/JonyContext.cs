using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CoreDockerExp.Models
{
    public class JonyContext : DbContext
    {

        public JonyContext(DbContextOptions<JonyContext> options)
            : base(options)
        {
        }

        public DbSet<JonyModel> Jonys { get; set; }
    }
}
