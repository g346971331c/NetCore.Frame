using Microsoft.EntityFrameworkCore;
using NetCore.Repository.Entitys.Systems;
using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Repository
{
    public class DataDBContext : DbContext
    {
        public DataDBContext(DbContextOptions<DataDBContext> options) : base(options)
        { }
        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<Role> Roles { get; set; }
    }
}

