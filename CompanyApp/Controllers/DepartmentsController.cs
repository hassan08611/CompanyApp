
using CompanyApp.Models;
using CompanyApp.Repositories.Base;
using Microsoft.AspNetCore.Mvc;

public class DepartmentsController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public DepartmentsController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: DEPARTMENTS
    public IActionResult Index()
    {
        return View(_unitOfWork.Departments.GetAll());
    }

    // GET: DEPARTMENTS/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = _unitOfWork.Departments.GetById(id.Value);
        if (department == null)
        {
            return NotFound();
        }

        return View(department);
    }

    // GET: DEPARTMENTS/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: DEPARTMENTS/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Id,Name")] Department department)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Departments.Add(department);
            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(department);
    }

    // GET: DEPARTMENTS/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = _unitOfWork.Departments.GetById(id.Value);
        if (department == null)
        {
            return NotFound();
        }
        return View(department);
    }

    // POST: DEPARTMENTS/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int? id, [Bind("Id,Name")] Department department)
    {
        if (id != department.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
          
            _unitOfWork.Departments.Update(department);
           _unitOfWork.SaveChanges();
          return RedirectToAction(nameof(Index));
        }
        return View(department);
    }

    // GET: DEPARTMENTS/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = _unitOfWork.Departments.GetById(id.Value);
        if (department == null)
        {
            return NotFound();
        }
        
        

        return View(department);
    }

    // POST: DEPARTMENTS/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var department = _unitOfWork.Departments.GetById(id.Value);
        if (department != null)
        {
            _unitOfWork.Departments.Delete(department);
            _unitOfWork.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
  
}
