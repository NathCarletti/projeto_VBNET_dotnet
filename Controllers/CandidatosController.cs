using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using crudmysql.Models;

namespace crudmysql.Controllers
{
  public class CandidatosController : Controller
  {
    private readonly CandidatosContexto _context;

    public CandidatosController(CandidatosContexto context)
    {
      _context = context;
    }

    // GET: Candidatos

    public async Task<IActionResult> Index()
    {
      //return Json(await _context.Candidatos.ToListAsync());
      return View(await _context.Candidatos.ToListAsync());
    }

    // GET: Candidatos/Details/5
    public async Task<IActionResult> Details(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var candidatos = await _context.Candidatos
          .FirstOrDefaultAsync(m => m.Idcandidatos == id);
      if (candidatos == null)
      {
        return NotFound();
      }
      // return Json(candidatos);
      return View(candidatos);
    }

    // GET: Candidatos/Create
    public IActionResult Create()
    {
      return View();
    }

    // POST: Candidatos/Create
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Idcandidatos,Nome,Cpf,Valorp,Situacao,Numurna,Ocupacao,Vice,Ver,Partido,VicePref,Datanasc")] Candidatos candidatos)
    {
      if (ModelState.IsValid)
      {
        _context.Add(candidatos);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
      }
      return View(candidatos);
    }

    // GET: Candidatos/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var candidatos = await _context.Candidatos.FindAsync(id);
      if (candidatos == null)
      {
        return NotFound();
      }
      return View(candidatos);
    }

    // POST: Candidatos/Edit/5
    // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
    // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Idcandidatos,Nome,Cpf,Valorp,Situacao,Numurna,Ocupacao,Vice,Ver,Partido,VicePref,Datanasc")] Candidatos candidatos)
    {
      if (id != candidatos.Idcandidatos)
      {
        return NotFound();
      }

      if (ModelState.IsValid)
      {
        try
        {
          _context.Update(candidatos);
          await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
          if (!CandidatosExists(candidatos.Idcandidatos))
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
      return View(candidatos);
    }

    // GET: Candidatos/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
      if (id == null)
      {
        return NotFound();
      }

      var candidatos = await _context.Candidatos
          .FirstOrDefaultAsync(m => m.Idcandidatos == id);
      if (candidatos == null)
      {
        return NotFound();
      }

      return View(candidatos);
    }

    // POST: Candidatos/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
      var candidatos = await _context.Candidatos.FindAsync(id);
      _context.Candidatos.Remove(candidatos);
      await _context.SaveChangesAsync();
      return RedirectToAction(nameof(Index));
    }

    private bool CandidatosExists(int id)
    {
      return _context.Candidatos.Any(e => e.Idcandidatos == id);
    }
  }
}
