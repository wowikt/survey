using AutoMapper;
using Survey.App.Interfaces;
using Survey.Core.Enums;
using Survey.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Survey.Web.Helpers;

namespace Survey.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ISurveyPlanService _surveyService;
        private readonly IFinishedSurveyService _finishedSurveyService;

        public HomeController()
        {
            _surveyService = DependencyResolver.Current.GetService<ISurveyPlanService>();
            _finishedSurveyService = DependencyResolver.Current.GetService<IFinishedSurveyService>();
        }

        public ActionResult Index()
        {
            var viewModel = Mapper.Map<List<SurveyPlanViewModel>>(_surveyService.GetAll());
            return View(viewModel);
        }

        public ActionResult ViewSurvey(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            // Построение вью-модели из бизнес-модели и ее корректировка перед отображением
            SurveyPlanViewModel model = Mapper.Map<SurveyPlanViewModel>(_surveyService.GetSurveyPlanModel(id));
            ViewModelHelper.PrepareSurveyPlanViewModel(model);

            // Сохранение исходной модели в сессии (нужно будет при последующем запросе сохранения данных)
            Session["SurveyPlanViewModel"] = model;

            return View(model);
        }

        [HttpPost]
        public ActionResult ViewSurvey(SurveyPlanViewModel model)
        {
            bool isValid = ModelState.IsValid;

            // Валидация модели
            for (int i = 0; i < model.QuestionModels.Count; i++)
            {
                // В зависимости от типа вопроса проверяем наличие ответа на него
                var question = model.QuestionModels[i];
                switch (question.Type)
                {
                    case QuestionType.ClosedSingle:
                        if (question.SelectedIndex < 0)
                        {
                            isValid = false;
                            ModelState.AddModelError($"QuestionModels[{i}]", "Не сделан выбор");
                        }
                        break;
                    case QuestionType.ClosedMultiple:
                        if (question.Answers.All(a => !a.IsSelected))
                        {
                            isValid = false;
                            ModelState.AddModelError($"QuestionModels[{i}]", "Не выбрано ни одного значения");
                        }
                        break;
                    case QuestionType.Open:
                        if (string.IsNullOrEmpty(question.Answers[0].Text))
                        {
                            isValid = false;
                            ModelState.AddModelError($"QuestionModels[{i}]", "Не введен ответ");
                        }
                        break;
                }
            }

            // Сливаем полученную модель с ранее сохраненной моделью, т. к. тексты вопросов/ответов
            //  в странице не сохраняются и в модели не передаются
            var dbModel = (SurveyPlanViewModel)Session["SurveyPlanViewModel"];
            ViewModelHelper.MergeSurveyPlanViewModels(dbModel, model);

            if (!isValid)
            {
                return View(dbModel);
            }

            // Если все нормально, сохраняем модель...
            var modelToSave = ViewModelHelper.CreateFinishedSurveyModel(dbModel);
            var id = _finishedSurveyService.Save(modelToSave);

            //  ... и переадресуемся на страницу просмотра результатов опроса
            return RedirectToAction("ViewFinishedSurvey", new { id });
        }

        public ActionResult ViewFinishedSurvey(int id = 0)
        {
            if (id == 0)
            {
                return RedirectToAction("Index");
            }

            // Извчеление бизнес-модели и построение из нее вью-модели
            var model = _finishedSurveyService.GetFinishedSurvey(id);
            var viewModel = ViewModelHelper.CreateFinishedSurveyViewModel(model);

            return View(viewModel);
        }
    }
}