using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Asp.netCoreMVCCRUD.Models;
using ReflectionIT.Mvc.Paging;

namespace Asp.netCoreMVCCRUD.Controllers
{
    public class SuperheroController : Controller
    {
    
        private readonly SuperheroContext _context;

        public SuperheroController(SuperheroContext context)
        {
            _context = context;
        }



        public IActionResult Index(int pageindex = 1, string sort = "Name", string searchString = null)
        {


            var superheros = from s in _context.Superhero
                             select s;

            if (!String.IsNullOrEmpty(searchString))
            {
                superheros = superheros.Where(s => (s.Name.Contains(searchString) || s.Power.Contains(searchString) || s.Editorial.Contains(searchString)));
            }

            var model = PagingList.Create(superheros, 10, pageindex, sort, "Name");

            return View(model);
        }

        // GET: Superhero/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superhero = await _context.Superhero
                .FirstOrDefaultAsync(m => m.SuperheroId == id);
            if (superhero == null)
            {
                return NotFound();
            }

            return View(superhero);
        }

        // GET: Superhero/Add
        public IActionResult Create()
        {
            return View();
        }

        // POST: Superhero/Add
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SuperheroId,Name,Power,Editorial")] Superhero superhero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(superhero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(superhero);
        }

        // GET: Superhero/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superhero = await _context.Superhero.FindAsync(id);
            if (superhero == null)
            {
                return NotFound();
            }
            return View(superhero);
        }

        // POST: Superhero/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SuperheroId,Name,Power,Editorial")] Superhero superhero)
        {
            if (id != superhero.SuperheroId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(superhero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SuperheroExists(superhero.SuperheroId))
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
            return View(superhero);
        }

        // GET: Superhero/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var superhero = await _context.Superhero
                .FirstOrDefaultAsync(m => m.SuperheroId == id);
            if (superhero == null)
            {
                return NotFound();
            }

            return View(superhero);
        }

        // POST: Superhero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var superhero = await _context.Superhero.FindAsync(id);
            _context.Superhero.Remove(superhero);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SuperheroExists(int id)
        {
            return _context.Superhero.Any(e => e.SuperheroId == id);
        }
    }
}

   