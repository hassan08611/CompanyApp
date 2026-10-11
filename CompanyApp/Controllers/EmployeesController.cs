using CompanyApp.Models;
using CompanyApp.Repositories.Base;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

public class EmployeesController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public EmployeesController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // GET: Employees
    public IActionResult Index()
    {
        return View(_unitOfWork.Employees.GetAllWithDepartment());
    }

    // GET: Employees/Details/5
    public IActionResult Details(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = _unitOfWork.Employees.GetByIdWithDepartment(id.Value);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // GET: Employees/Create
    public IActionResult Create()
    {
        ViewBag.Departments = new SelectList(_unitOfWork.Departments.GetAll(), "Id", "Name");
        return View();
    }

    // POST: Employees/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Id,Name,Email,Salary,DepartmentId")] Employee employee)
    {
        if (ModelState.IsValid)
        {
            _unitOfWork.Employees.Add(employee);
            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Departments = new SelectList(_unitOfWork.Departments.GetAll(), "Id", "Name", employee.DepartmentId);
        return View(employee);
    }

    // GET: Employees/Edit/5
    public IActionResult Edit(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = _unitOfWork.Employees.GetById(id.Value);
        if (employee == null)
        {
            return NotFound();
        }
        ViewBag.Departments = new SelectList(_unitOfWork.Departments.GetAll(), "Id", "Name", employee.DepartmentId);
        return View(employee);
    }

    // POST: Employees/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(int? id, [Bind("Id,Name,Email,Salary,DepartmentId")] Employee employee)
    {
        if (id != employee.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            _unitOfWork.Employees.Update(employee);
            _unitOfWork.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        ViewBag.Departments = new SelectList(_unitOfWork.Departments.GetAll(), "Id", "Name", employee.DepartmentId);
        return View(employee);
    }

    // GET: Employees/Delete/5
    public IActionResult Delete(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = _unitOfWork.Employees.GetByIdWithDepartment(id.Value);
        if (employee == null)
        {
            return NotFound();
        }

        return View(employee);
    }

    // POST: Employees/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int? id)
    {
        if (id == null)
        {
            return NotFound();
        }

        var employee = _unitOfWork.Employees.GetById(id.Value);
        if (employee != null)
        {
            _unitOfWork.Employees.Delete(employee);
            _unitOfWork.SaveChanges();
        }
        return RedirectToAction(nameof(Index));
    }
}