using BankCore.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankCore.IdentityData
{
 
    public class ApplicationIdentityDbContext : IdentityDbContext 
    {
        public ApplicationIdentityDbContext(DbContextOptions<ApplicationIdentityDbContext> options)
            : base(options)
        {
        }
        // Lägg till din DbSet här, inuti klassen   
      //  public DbSet<Account> Accounts { get; set; } det här förstörde koden sjukt nog

    }
}
