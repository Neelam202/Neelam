using AngularCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularCrud.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Get_AllEmployee()
        {
            using(SampleEntities db=new SampleEntities())
            {
                List<Employee> Emp = new List<Employee>();
                return Json(Emp, JsonRequestBehavior.AllowGet);
            }


        }

        public string Insert_Employee(Employee employee)
        {

            if(employee!=null)
            {
                using (SampleEntities db = new SampleEntities())
                {
                    db.Employees.Add(employee);
                    db.SaveChanges();
                    return "Employee Saved successfully";
                
                }
                
            }
            else { return "Error"; }
        }

         public string Delete_Employee(Employee Emp)
        {
            if (Emp != null)
            {
                using(SampleEntities db=new SampleEntities())
                {
                    var Emp_ = db.Entry(Emp);
                        if(Emp_.State==System.Data.Entity.EntityState.Detached)
                    {
                        db.Employees.Attach(Emp);
                        db.Employees.Remove(Emp);

                    }
                    db.SaveChanges();
                    return "Employee deleted successfully";
                }
            }
            else { return "Employee not deleted ! try again"; }
        }


        public string Update_Employee(Employee Emp)
        {
            if (Emp!=null)
            {
                using(SampleEntities db=new SampleEntities())
                {
                    var Emp_ = db.Entry(Emp);
                    Employee employeeObj = db.Employees.Where(x => x.Emp_Id == Emp.Emp_Id).FirstOrDefault();
                    employeeObj.Emp_Name = Emp.Emp_Name;
                    employeeObj.Emp_City = Emp.Emp_City;
                    employeeObj.Emp_Age = Emp.Emp_Age;

                    db.SaveChanges();
                    return "Employee updated successfully ";

                }
            }
            else
            {
                return "Error While Update";
            }
        }
    }
}