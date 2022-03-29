#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MvcPortfolio.Models;

namespace MvcPortfolio.Data
{
    public class MvcPortfolioContext : DbContext
    {
        public MvcPortfolioContext (DbContextOptions<MvcPortfolioContext> options)
            : base(options)
        {
        }

        public DbSet<MvcPortfolio.Models.Pessoa> Pessoa { get; set; }

        public DbSet<MvcPortfolio.Models.Projeto> Projeto { get; set; }

        public DbSet<MvcPortfolio.Models.Membros> Membros { get; set; }
    }
}
