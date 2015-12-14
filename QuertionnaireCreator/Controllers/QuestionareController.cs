using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuertionnaireCreator.Controllers
{
    public class QuestionareController : BaseController
    {
        public ActionResult Add(string name)
        {
            var user = GetUser();
            var result = _unitOfWork.QuestionareRepository.Add(new Questionare { Name = name, UserId = user.Id, RespondendsNumber = 0 });

            return View(result.CurrentObject);
        }

        public ActionResult Read(int id)
        {
            return View(id);
        }

        public JsonResult GetById(int id)
        {
            var result = _unitOfWork.QuestionareRepository.Get(id);
            return Json(result);
        }

        public JsonResult GetList()
        {
            var user = GetUser();

            var list = _unitOfWork.QuestionareRepository.GetList(user.Id);
            return Json(list);
        }

        public JsonResult Save(int questionareId, int questionType, string question, string[] options)
        {
            var questionOptions = new List<QuestionOption>();

            foreach (var option in options)
            {
                questionOptions.Add(new QuestionOption { OptionText = option });
            }

            var addResult = _unitOfWork.QuestionRepository.Add(new Question { QuestionText = question, QuestionareId = questionareId, Type = questionType, Options = questionOptions });
            return Json(addResult);
        }
    }
}