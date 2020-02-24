using HomeworkView.ActionResults;
using HomeworkView.Models;
using HomeworkView.Service;
using HomeworkView.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace HomeworkView.Controllers
{
    public class BookKeepingController : Controller
    {
       

        // GET: BookKeeping
        public ActionResult Index()
        {
            var list = BookKeepingService.GetData();
            return PartialView(list);
            //int max = 200;
            //List<BookKeepingViewModel> listBookKeepingViewModel = new List<BookKeepingViewModel>();
            //BookKeepingViewModel bookKeepingViewModel;

            //Random rand = new Random(Guid.NewGuid().GetHashCode());

            //List<int> listLinq = new List<int>(Enumerable.Range(1, 10000));
            //var amount = 0;
            //var rnd = new Random();

            //Array categories = Enum.GetValues(typeof(CategoryEnum));
            //Random random = new Random();

            //for (int i = 0; i < max; i++)
            //{
                
            //    CategoryEnum category = (CategoryEnum)categories.GetValue(random.Next(categories.Length));

            //    amount = rnd.Next(10000);
            //    if (category == CategoryEnum.Expenditure) {
            //        amount = 0 - amount;
            //    }

            //    bookKeepingViewModel = new BookKeepingViewModel { No = i + 1, Category = category.GetDescription(), Amout= amount, CreateDate= DateTime.Now.AddDays(0-(max-i)).Date, Remark="" };
            //    listBookKeepingViewModel.Add(bookKeepingViewModel);
            //}
           
            //return PartialView(listBookKeepingViewModel);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Guid guid = new Guid(id);
            var accountBook = BookKeepingService.GetByID(guid);
            return PartialView(accountBook);

        }

        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            try
            {
                Guid guid = new Guid(id);
                var accountBook = BookKeepingService.GetByID(guid);

                var categories = Enum.GetValues(typeof(CategoryEnum)).Cast<CategoryEnum>()
                                .Select(category => new
                                {
                                    value = (int)category,

                                    text = category.GetDescription()
                                });



                var categoryItems = new SelectList(categories, "value", "text", accountBook.Categoryyy);

                ViewBag.CategoryItems = categoryItems;

                //ViewBag.Categories = new from CategoryEnum status in Enum.GetValues(typeof(CategoryEnum))
                //where status != StatusEnum.Default
                //select new SelectListItem
                //{
                //    Text = status.ToString(),
                //    Value = ((int)status).ToString()
                //};  

                return PartialView(accountBook);
            }
            catch (FormatException)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
        }

        [HttpPost]
        public ActionResult Edit(AccountBook accountBook)
        {

            if (ModelState.IsValid)
            {
              
                BookKeepingService.Update(accountBook);
                                
                return RedirectToAction("Index");
            }
            return View();
        }

        public ActionResult Export()
        {

            var list = BookKeepingService.GetData();
            string fileName = string.Format("{0}.{1}", DateTime.Now.ToString("yyyyMMddHHmmss"), "csv");
            return new CsvActionResult<BookKeepingViewModel>(list, fileName);
            
             
        }


    }
}