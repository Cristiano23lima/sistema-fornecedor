using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using sistema_fornecedor.Models;


namespace sistema_fornecedor.Data
{
    public class FornecedorDbContext : DbContext
    {
        public FornecedorDbContext(DbContextOptions<FornecedorDbContext> options)
            : base(options)
        {
        }
        public DbSet<Fornecedores> Fornecedores { get; set; }
        public DbSet<Produto> Produtos { get; set; }
    }
}