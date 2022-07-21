using Microsoft.Extensions.Configuration;
using ModelLayer;
using RepoLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace RepoLayer.Services
{
    public class EmployeeRL : IEmployeeRL
    {
        private readonly IConfiguration configuration;
        public EmployeeRL(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        //To add New Employee Record
        public string AddEmployee(EmployeeModel emp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmpPayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                    cmd.Parameters.AddWithValue("@Profileimage", emp.Profileimage);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@Department", emp.Department);
                    cmd.Parameters.AddWithValue("@salary", emp.Salary);
                    cmd.Parameters.AddWithValue("@startDate", emp.StartDate);
                    cmd.Parameters.AddWithValue("@notes", emp.Notes);
                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result >= 1)
                    {
                        return "data Added";
                    }
                    else
                    {
                        return "data not added";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public string DeleteEmployee(int? id)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmpPayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spDeleteEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Emp_id", id);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result >= 1)
                    {
                        return "data Added";
                    }
                    else
                    {
                        return "data not added";
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        // To View All Employee Details
        public IEnumerable<EmployeeModel> GetAllEmployees()
        {
            try
            {
                List<EmployeeModel> listemployee = new List<EmployeeModel>();
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmpPayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spGetAllEmployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        EmployeeModel emp = new EmployeeModel();

                        emp.Emp_id = Convert.ToInt32(rdr["Emp_id"]);
                        emp.Emp_name = Convert.ToString(rdr["Emp_name"]);
                        emp.Profileimage = Convert.ToString(rdr["Profileimage"]);
                        emp.Gender = Convert.ToString(rdr["Gender"]);
                        emp.Department = Convert.ToString(rdr["Department"]);
                        emp.Salary = Convert.ToInt32(rdr["salary"]);
                        emp.StartDate = Convert.ToDateTime(rdr["startDate"]);
                        emp.Notes = Convert.ToString(rdr["notes"]);

                        listemployee.Add(emp);
                    }
                    con.Close();
                }
                return listemployee;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public EmployeeModel GetEmployeeData(int? id)
        {
            try
            {
                EmployeeModel emp = new EmployeeModel();
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmpPayrollMVC"]))
                {
                    string sqlQuery = "SELECT * FROM tblEmployeeInfo WHERE Emp_id= " + id;
                    SqlCommand cmd = new SqlCommand(sqlQuery, con);
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        emp.Emp_id = Convert.ToInt32(rdr["Emp_id"]);
                        emp.Emp_name = Convert.ToString(rdr["Emp_name"]);
                        emp.Profileimage = Convert.ToString(rdr["Profileimage"]);
                        emp.Gender = Convert.ToString(rdr["Gender"]);
                        emp.Department = Convert.ToString(rdr["Department"]);
                        emp.Salary = Convert.ToInt32(rdr["salary"]);
                        emp.StartDate = Convert.ToDateTime(rdr["startDate"]);
                        emp.Notes = Convert.ToString(rdr["notes"]);
                    }
                }
                return emp;
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        public string UpdateEmployee(EmployeeModel emp)
        {
            try
            {
                using (SqlConnection con = new SqlConnection(configuration["ConnectionStrings:EmpPayrollMVC"]))
                {
                    SqlCommand cmd = new SqlCommand("spUpdateEmployee", con);
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@Emp_id", emp.Emp_id);
                    cmd.Parameters.AddWithValue("@Emp_name", emp.Emp_name);
                    cmd.Parameters.AddWithValue("@Profileimage", emp.Profileimage);
                    cmd.Parameters.AddWithValue("@Gender", emp.Gender);
                    cmd.Parameters.AddWithValue("@Department", emp.Department);
                    cmd.Parameters.AddWithValue("@salary", emp.Salary);
                    cmd.Parameters.AddWithValue("@startDate", emp.StartDate);
                    cmd.Parameters.AddWithValue("@notes", emp.Notes);

                    con.Open();
                    var result = cmd.ExecuteNonQuery();
                    con.Close();
                    if (result >= 1)
                    {
                        return "data Added";
                    }
                    else
                    {
                        return "data not added";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
