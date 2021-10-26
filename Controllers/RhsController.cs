using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_RH.Data;
using Projeto_RH.Entidades;

namespace Projeto_RH.Controllers
{
    public class RhsController : BaseController
    {
        private readonly ApplicationDbContext _context;

     

        public RhsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Rhs
        public async Task<IActionResult> Index(string sortOrder)

        {
            ViewBag.CurrentSort = sortOrder;
            ViewBag.idParam = String.IsNullOrEmpty(sortOrder) ? "id_desc" : "";
            ViewBag.DateParm = sortOrder == "Date" ? "Date_desc" : "Date";

                        var requisicao = from s in _context.RH
                         select s;

            switch (sortOrder)
            {
                case "id_desc":
                    requisicao = requisicao.OrderByDescending(s => s.id);
                    break;
                case "Data":
                    requisicao = requisicao.OrderBy(s => s.DataCadastro);
                    break;
                case "Data_desc":
                    requisicao = requisicao.OrderByDescending(s => s.DataCadastro);
                    break;
                default:
                    requisicao = requisicao.OrderBy(s => s.id);
                    break;
            }

            var temacesso = await Usuario_Tem_Acesso(2, _context);

            if (!temacesso)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(await _context.RH.ToListAsync());
        }

        // GET: Rhs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rh = await _context.RH
                .FirstOrDefaultAsync(m => m.id == id);
            if (rh == null)
            {
                return NotFound();
            }

            return View(rh);
        }

        // GET: Rhs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rhs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,DataCadastro,N_Referencia_Pandape,Vaga,Email_Solicitante,EnumFiliais,Solicitação_Infra,Solicitação_Telefonia,Tipo_Equipamento,Cargo,Setor,Filial_infra,Movidesk_Infra,Movidesk_Telefonia,Andamento,Recebido_por,DataRecebimento,Serie_equipamento")] Rh rh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rh);
        }

        // GET: Rhs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rh = await _context.RH.FindAsync(id);
            if (rh == null)
            {
                return NotFound();
            }
            return View(rh);
        }

        // POST: Rhs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DataCadastro,N_Referencia_Pandape,Vaga,Email_Solicitante,EnumFiliais,Solicitação_Infra,Solicitação_Telefonia,Tipo_Equipamento,Cargo,Setor,Filial_infra,Movidesk_Infra,Movidesk_Telefonia,Andamento,Recebido_por,DataRecebimento,Serie_equipamento")] Rh rh)
        {
            if (id != rh.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rh);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RhExists(rh.id))
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
            return View(rh);
        }

        // GET: Rhs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rh = await _context.RH
                .FirstOrDefaultAsync(m => m.id == id);
            if (rh == null)
            {
                return NotFound();
            }

            return View(rh);
        }

        // POST: Rhs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rh = await _context.RH.FindAsync(id);
            _context.RH.Remove(rh);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RhExists(int id)
        {
            return _context.RH.Any(e => e.id == id);
        }
    }
}
