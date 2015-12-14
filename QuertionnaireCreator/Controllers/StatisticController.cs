using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuertionnaireCreator.Controllers
{
    public class StatisticController : BaseController
    {
        public ActionResult Index(int id)
        {
            return View(id);
        }

        // GET: Statistic
        public JsonResult GetByQuestionareId(int id)
        {
            var result = _unitOfWork.QuestionareRepository.Get(id);
            return Json(result);
        }

        public JsonResult GetStatByQuestionOption(int id)
        {
            var result = _unitOfWork.QuestionRepository.GetStatisticByQuestionOption(id);
            return Json(result);
        }
    }
}