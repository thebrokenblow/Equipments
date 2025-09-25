using Equipments.View.Data;
using Equipments.View.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Equipments.View.Controllers;

public class FacilitiesController : Controller
{
    private readonly EquipmentsDbContext _context;

    public FacilitiesController(EquipmentsDbContext context)
    {
        _context = context;
    }

    // GET: Facilities
    public async Task<IActionResult> Index()
    {
        return View(await _context.Facilities.ToListAsync());
    }

    // GET: Facilities/Details/5
    public async Task<IActionResult> Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var facility = await _context.Facilities
            .FirstOrDefaultAsync(m => m.Id == id);
        if (facility == null)
        {
            return NotFound();
        }

        return View(facility);
    }

    // GET: Facilities/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: Facilities/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Id,Name")] Facility facility)
    {
        if (ModelState.IsValid)
        {
            _context.Add(facility);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(facility);
    }

    // GET: Facilities/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var facility = await _context.Facilities.FindAsync(id);
        if (facility == null)
        {
            return NotFound();
        }
        return View(facility);
    }

    // POST: Facilities/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Facility facility)
    {
        if (id != facility.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(facility);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FacilityExists(facility.Id))
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
        return View(facility);
    }

    // GET: Facilities/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var facility = await _context.Facilities
            .FirstOrDefaultAsync(m => m.Id == id);
        if (facility == null)
        {
            return NotFound();
        }

        return View(facility);
    }

    // POST: Facilities/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        var facility = await _context.Facilities.FindAsync(id);
        if (facility != null)
        {
            _context.Facilities.Remove(facility);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool FacilityExists(int id)
    {
        return _context.Facilities.Any(e => e.Id == id);
    }
}