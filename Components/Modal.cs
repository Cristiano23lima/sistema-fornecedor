using Microsoft.AspNetCore.Mvc;
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
            var items = await GetItemsAsync(id);
            return View(items);
        }

        private Task<List<Fornecedores>> GetItemsAsync(int id) => db.Fornecedores.Where(a => a.Id == id).ToListAsync();
    }
}