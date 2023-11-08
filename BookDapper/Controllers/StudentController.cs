using BookDapper.Models;
using BookDapper.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookDapper.Controllers
{
    public class StudentController : Controller
    {

        private readonly IStudentService service;
        public StudentController(IStudentService service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            try
            {
                var model = await service.GetStudents();
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }

        }

        public async Task<IActionResult> Details(int id)
        {
            try
            {
                var model = await service.GetStudentById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: BookController/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BookController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Student student)
        {
            try
            {
                int result = await service.AddStudent(student);
                if (result >= 1)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var model = await service.GetStudentById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: BookController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Student student)
        {
            try
            {
                int result = await service.UpdateStudent(student);
                if (result >= 1)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: BookController/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var model = await service.GetStudentById(id);
                return View(model);
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // POST: BookController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirm(int id)
        {
            try
            {
                int result = await service.DeleteStudent(id);
                if (result >= 1)
                    return RedirectToAction("Index");
                else
                    return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }
    }
}
