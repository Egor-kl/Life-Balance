using Life_Balance.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Life_Balance.DAL
{
    public class LifeBalanceDbContext : IdentityDbContext<User>
    {
        public LifeBalanceDbContext(DbContextOptions<LifeBalanceDbContext> options) : base(options)
        {
        }

        public DbSet<Diary> Diary { get; set; }
        public DbSet<Profile> Profiles { get; set; }
    }
}
