﻿using Exercises.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Exercises.Models.Data;
using Exercises.Models.ViewModels;

namespace Exercises.Controllers
{
    public class StudentController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult List()
        {
            var model = StudentRepository.GetAll();

            return View(model);
        }

        [HttpGet]
        public ActionResult Add()
        {
            var viewModel = new StudentVM();
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Add(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Add(studentVM.Student);

                return RedirectToAction("List");
            }

            else
            {
                studentVM.SetMajorItems(MajorRepository.GetAll());
                studentVM.SetCourseItems(CourseRepository.GetAll());
            }

            return View(studentVM);
            
        }

        [HttpGet]
        public ActionResult EditStudent(int id)
        {
            var viewModel = new StudentVM();
            viewModel.Student = StudentRepository.Get(id);
            viewModel.SetCourseItems(CourseRepository.GetAll());
            viewModel.SetMajorItems(MajorRepository.GetAll());
            viewModel.SetStateItems(StateRepository.GetAll());
            return View(viewModel);

        }

        [HttpPost]
        public ActionResult EditStudent(StudentVM studentVM)
        {
            if (ModelState.IsValid)
            {
                studentVM.Student.Courses = new List<Course>();

                foreach (var id in studentVM.SelectedCourseIds)
                    studentVM.Student.Courses.Add(CourseRepository.Get(id));

                studentVM.Student.Major = MajorRepository.Get(studentVM.Student.Major.MajorId);

                StudentRepository.Edit(studentVM.Student);
            }

            else
            {
                studentVM.SetMajorItems(MajorRepository.GetAll());
                studentVM.SetCourseItems(CourseRepository.GetAll());
            }
                

            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult DeleteStudent(int id)
        {
            var student = StudentRepository.Get(id);
            return View(student);
        }

        [HttpPost]
        public ActionResult DeleteStudent(StudentVM student)
        {
            StudentRepository.Delete(student.Student.StudentId);
            return RedirectToAction("List");
        }
    }
}