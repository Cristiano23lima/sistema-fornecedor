using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using sistema_fornecedor.Data;
using sistema_fornecedor.Models;

namespace sistema_fornecedor.Controllers
{
    public class FornecedorController : Controller
    {
        private readonly FornecedorDbContext _context;

        public FornecedorController(FornecedorDbContext context)
        {
            _context = context;
        }

        // GET: Fornecedor
        public async Task<IActionResult> Index()
        {
            return View(await _context.Fornecedores.ToListAsync());
        }

        // GET: Fornecedor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedores = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedores == null)
            {
                return NotFound();
            }

            return View(fornecedores);
        }


        // GET: Fornecedor/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Fornecedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Endereco,Cep,Bairro,Cidade,Estado,Telefone")] Fornecedores fornecedores)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fornecedores);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedores);
        }

        // GET: Fornecedor/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedores = _context.Fornecedores.Find(id);
            if (fornecedores == null)
            {
                return NotFound();
            }
            return PartialView(fornecedores);
        }

        // POST: Fornecedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Endereco,Cep,Bairro,Cidade,Estado,Telefone")] Fornecedores fornecedores)
        {
            if (id != fornecedores.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fornecedores);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FornecedoresExists(fornecedores.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(fornecedores);
        }

        // GET: Fornecedor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fornecedores = await _context.Fornecedores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (fornecedores == null)
            {
                return NotFound();
            }

            return View(fornecedores);
        }

        // POST: Fornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fornecedores = await _context.Fornecedores.FindAsync(id);
            _context.Fornecedores.Remove(fornecedores);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FornecedoresExists(int id)
        {
            return _context.Fornecedores.Any(e => e.Id == id);
        }
    }
}
