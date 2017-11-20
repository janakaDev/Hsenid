using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObject;
using DataAccess;
namespace BusinessLogic
{
    public class EmployeeLogic
    {
        public bool AddEmployees(Employee employeeModel)
        {

            try
            {
                HandleEmployeeData handleEmployeeData = new HandleEmployeeData();
                handleEmployeeData.AddEmployees(employeeModel);
                return true;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }

        public List<Employee> getEmployeeData()
        {
            List<Employee> employeeList = new List<Employee>();
            HandleEmployeeData handleEmployeeData = new HandleEmployeeData();
            employeeList = handleEmployeeData.GetEmployeeData();
            return employeeList;
        }

        public int getEmployeeDataWithNameLogic(string name)
        {
            HandleEmployeeData handleEmployeeData = new HandleEmployeeData();
            int id = handleEmployeeData.getEmployeeIWithName(name);
            return id;
        }
        public string getEmployeeDesignationWithNameLogic(string name)
        {
            HandleEmployeeData handleEmployeeData = new HandleEmployeeData();
            string designation = handleEmployeeData.getEmployeeDesignationWithName(name);
            return designation;
        }

        public int GetSumOfOtHoursLogic(string name)
        {
            HandleEmployeeData handleEMployeeData = new HandleEmployeeData();
            int li = 0;
            li=handleEMployeeData.GetSumOfOtHours(name);
            return li;
        }


        public int DeleteEmployeeLogic(int id)
        {
           
                HandleEmployeeData handleEmployeeData = new HandleEmployeeData();
                int x=handleEmployeeData.DeleteEmployee(id);
            return x;
        }


    }
}
