using HomeworkView.Models;
using HomeworkView.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HomeworkView.Controllers
{
    public class BookKeepingController : Controller
    {
        enum CategoryEnum
        {
            [Description("支出")]
            Expenditure,
            [Description("收入")]
            Income
        }

        // GET: BookKeeping
        public ActionResult Index()
        {
            int max = 200;
            List<BookKeepingViewModel> listBookKeepingViewModel = new List<BookKeepingViewModel>();
            BookKeepingViewModel bookKeepingViewModel;

            Random rand = new Random(Guid.NewGuid().GetHashCode());

            List<int> listLinq = new List<int>(Enumerable.Range(1, 10000));
            var amount = 0;
            var rnd = new Random();

            Array categories = Enum.GetValues(typeof(CategoryEnum));
            Random random = new Random();

            for (int i = 0; i < max; i++)
            {
                
                CategoryEnum category = (CategoryEnum)categories.GetValue(random.Next(categories.Length));

                amount = rnd.Next(10000);
                if (category == CategoryEnum.Expenditure) {
                    amount = 0 - amount;
                }

                bookKeepingViewModel = new BookKeepingViewModel { No = i + 1, Category = category.GetDescription(), Amout= amount, CreateDate= DateTime.Now.AddDays(0-(max-i)).Date, Remark="" };
                listBookKeepingViewModel.Add(bookKeepingViewModel);
            }
           
            return PartialView(listBookKeepingViewModel);
        }
    }
}