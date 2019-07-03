using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using StudentExercisesMVC.Models;

namespace StudentExercisesMVC.Controllers
{
    public class InstructorsController : Controller
    {
        private readonly IConfiguration _config;

        public InstructorsController(IConfiguration config)
        {
            _config = config;
        }

        public SqlConnection Connection
        {
            get
            {
                return new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            }
        }
        // GET: Instuctors
        public ActionResult Index()
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        SELECT Id,
                                            FirstName,
                                            LastName,
                                            SlackHandle,
                                            InstructorSpecialty,
                                            CohortId
                                        FROM Instructor
                                    ";
                    SqlDataReader reader = cmd.ExecuteReader();

                    List<Instructor> instructors = new List<Instructor>();
                    while (reader.Read())
                    {
                        Instructor instructor = new Instructor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            SlackHandle = reader.GetString(reader.GetOrdinal("SlackHandle")),
                            InstructorSpecialty = reader.GetString(reader.GetOrdinal("InstructorSpecialty")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
                        };

                        instructors.Add(instructor);
                    }

                    reader.Close();

                    return View(instructors);
                }
            }
        }

        // GET: Instuctors/Details/5
        public ActionResult Details(int id)
        {
            Instructor instructor = GetInstructorByID(id);
            return View(instructor);
        }

        // GET: Instuctors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Instuctors/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Instuctors/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Instuctors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Instuctors/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Instuctors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private Instructor GetInstructorByID(int id)
        {
            using (SqlConnection conn = Connection)
            {
                conn.Open();
                using (SqlCommand cmd = conn.CreateCommand())
                {
                    cmd.CommandText = @"
                                        SELECT Id,
                                            FirstName,
                                            LastName,
                                            SlackHandle,
                                            InstructorSpecialty,
                                            CohortId
                                        FROM Instructor
                                        WHERE Id = @Id
                                    ";
                    cmd.Parameters.Add(new SqlParameter("@id", id));

                    SqlDataReader reader = cmd.ExecuteReader();

                    Instructor instructor = null;

                    if (reader.Read())
                    {
                        instructor = new Instructor
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            FirstName = reader.GetString(reader.GetOrdinal("FirstName")),
                            LastName = reader.GetString(reader.GetOrdinal("LastName")),
                            SlackHandle = reader.GetString(reader.GetOrdinal("SlackHandle")),
                            InstructorSpecialty = reader.GetString(reader.GetOrdinal("InstructorSpecialty")),
                            CohortId = reader.GetInt32(reader.GetOrdinal("CohortId"))
                        };
                    }
                    reader.Close();

                    return instructor;
                }
            }
        }
    }
}