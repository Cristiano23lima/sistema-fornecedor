using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sistema_fornecedor.Models;
using sistema_fornecedor.Data;

namespace sistema_fornecedor.Components
{
    public class Modal : ViewComponent
    {
        private readonly FornecedorDbContext db;

        public Modal(FornecedorDbContext context) => this.db = context;

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            // Console.WriteLine(id);
            // // var items = await GetItemsAsync(id);
            if (id == 0)
            {
                Console.WriteLine("Id veio nulo");
                return View();
            }


            return View(await db.Fornecedores.FirstOrDefaultAsync(data => data.Id == id));
        }

        private Task<List<Fornecedores>> GetItemsAsync(int id) => db.Fornecedores.Where(a => a.Id == id).ToListAsync();
    }
}