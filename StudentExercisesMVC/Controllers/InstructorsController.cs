using System.Collections.Generic;
using System.Data.SqlClient;
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
        public ActionResult Create(Instructor instructor)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        //cmd.CommandText = @"INSERT INTO Instructor ( FirstName )
                        //                    VALUES ( @FirstName )";
                        //cmd.Parameters.Add(new SqlParameter("@FirstName", instructor.FirstName));
                        //cmd.ExecuteNonQuery();

                        //return RedirectToAction(nameof(Index));
                        cmd.CommandText = @"INSERT INTO Instructor ( FirstName, LastName, SlackHandle, InstructorSpecialty, CohortId )
                                            VALUES ( @firstName, @lastName, @slackHandle, @instructorSpecialty, @cohortId )";
                        cmd.Parameters.Add(new SqlParameter("@firstName", instructor.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@lastName", instructor.LastName));
                        cmd.Parameters.Add(new SqlParameter("@slackHandle", instructor.SlackHandle));
                        cmd.Parameters.Add(new SqlParameter("@instructorSpecialty", instructor.InstructorSpecialty));
                        cmd.Parameters.Add(new SqlParameter("@cohortId", instructor.CohortId));
                        cmd.ExecuteNonQuery();

                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Instuctors/Edit/5
        public ActionResult Edit(int id)
        {
            Instructor instructor = GetInstructorByID(id);
            return View(instructor);
        }

        // POST: Instuctors/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Instructor instructor)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"UPDATE Instructor
                                            SET FirstName=@FirstName,
                                                LastName=@LastName,
                                                SlackHandle=@SlackHandle,
                                                InstructorSpecialty=@InstructorSpecialty,
                                                CohortId=@CohortId
                                            WHERE Id=@Id";
                        cmd.Parameters.Add(new SqlParameter("@FirstName", instructor.FirstName));
                        cmd.Parameters.Add(new SqlParameter("@LastName", instructor.LastName));
                        cmd.Parameters.Add(new SqlParameter("@SlackHandle", instructor.SlackHandle));
                        cmd.Parameters.Add(new SqlParameter("@InstructorSpecialty", instructor.InstructorSpecialty));
                        cmd.Parameters.Add(new SqlParameter("@CohortId", instructor.CohortId));
                        cmd.Parameters.Add(new SqlParameter("@Id", id));

                        cmd.ExecuteNonQuery();
                        return RedirectToAction(nameof(Index));
                    }
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Instuctors/Delete/5
        public ActionResult Delete(int id)
        {
            Instructor isntructor = GetInstructorByID(id);
            return View(isntructor);
        }

        // POST: Instuctors/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id, IFormCollection collection)
        {
            try
            {
                using (SqlConnection conn = Connection)
                {
                    conn.Open();
                    using (SqlCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = @"DELETE FROM Instructor WHERE Id=@Id";

                        cmd.Parameters.Add(new SqlParameter("@Id", id));
                        cmd.ExecuteNonQuery();

                        return RedirectToAction(nameof(Index));
                    }
                }
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