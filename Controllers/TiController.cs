﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Projeto_RH.Data;
using Projeto_RH.Entidades;

namespace Projeto_RH.Controllers
{

    public class TiController : BaseController
    {
        private readonly ApplicationDbContext _context;

        public TiController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Ti
        public async Task<IActionResult> Index()
        {
            return View(await _context.RH.ToListAsync());
        }

        // GET: Ti/Details/5
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

        // GET: Ti/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ti/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,DataCadastro,N_Referencia_Pandape,Vaga,Email_Solicitante,EnumFiliais,Solicitação_Infra,Solicitação_Telefonia,Tipo_Equipamento,Cargo,Setor,Filial_infra,Movidesk_Infra,Movidesk_Telefonia,Andamento")] Rh rh)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rh);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(rh);
        }

        // GET: Ti/Edit/5
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

        // POST: Ti/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,DataCadastro,N_Referencia_Pandape,Vaga,Email_Solicitante,EnumFiliais,Solicitação_Infra,Solicitação_Telefonia,Tipo_Equipamento,Cargo,Setor,Filial_infra,Movidesk_Infra,Movidesk_Telefonia,Andamento")] Rh rh)
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

        // GET: Ti/Delete/5
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

        // POST: Ti/Delete/5
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
