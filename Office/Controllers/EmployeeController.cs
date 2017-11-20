using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BusinessObject;
using BusinessLogic;
using Office.ViewModels;

namespace Office.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            List<Employee> listEmployee = new List<Employee>();
            EmployeeLogic employeeLogic = new EmployeeLogic();

            listEmployee = employeeLogic.getEmployeeData();
            List<Office.ViewModels.EmployeeViewModel> empViewModel = new List<ViewModels.EmployeeViewModel>();
            foreach (var item in listEmployee)
            {
                empViewModel.Add(
                    new ViewModels.EmployeeViewModel
                    {
                        Id = item.Id,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Designation = item.Designation
                    }
                   );
            }

            return View(empViewModel);
        }

        // GET: Employee/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult GetId(string reportID)
        {
            string b = reportID;
            EmployeeLogic employeeLogic = new EmployeeLogic();
            int a=employeeLogic.getEmployeeDataWithNameLogic(reportID);
            return View();
        }

        [HttpPost]
        public ActionResult AddOtHours(List<string> x)
        {
            
            EmployeeLogic employeeLogic = new EmployeeLogic();
            int Id = Convert.ToInt16(x[0]);
            DateTime date = Convert.ToDateTime(x[1]);
            int OtHours = Convert.ToInt16(x[2]);
           
            return View();
        }




        public JsonResult getDesignation(string name)
        {
            EmployeeLogic employeeLogic = new EmployeeLogic();
            string x = name;
            string designation= employeeLogic.getEmployeeDesignationWithNameLogic(name);
            return Json(designation,JsonRequestBehavior.AllowGet);
        }


        // GET: Employee/Create
        public ActionResult Create()
        {
            return View();
        }

        public JsonResult GetTotalOtHours(string namew)
        {
            int x = 0;
            string nameL = namew;
            EmployeeLogic emp = new EmployeeLogic();
            x=emp.GetSumOfOtHoursLogic(nameL);
            return Json(x, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetTotalOtHours23(string namew)
        {
            int x = 0;
            string nameL = namew;
            EmployeeLogic emp = new EmployeeLogic();
            x = emp.GetSumOfOtHoursLogic(namew);
            ViewBag.Mess = x;
            return View();
        }




        // POST: Employee/Create
        [HttpPost]
        public ActionResult Create(EmployeeViewModel employeeViewModel)
        {
            try
            {
                EmployeeLogic businessLogic = new EmployeeLogic();
                Employee employeeModel = new Employee();
                employeeModel.FirstName = employeeViewModel.FirstName;
                employeeModel.LastName = employeeViewModel.LastName;
                employeeModel.Designation = employeeViewModel.Designation;
                businessLogic.AddEmployees(employeeModel);
                ViewBag.employeeOt = new EmployeeOtViewModel();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Employee/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Employee/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Employee/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public ActionResult DeleteEmployeeData(string id)
        {
            int idx = Convert.ToInt16(id);
            EmployeeLogic emp = new EmployeeLogic();
            int x = emp.DeleteEmployeeLogic(idx);
            return View();

        }


    }
}
