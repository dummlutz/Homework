using HomeworkView.Models;
using HomeworkView.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeworkView.Service
{
    public  class BookKeepingService
    {
        private static HomeworkDbContext _HomeworkDbContext =new HomeworkDbContext();

        public static List<BookKeepingViewModel> GetData()
        {
            var data = _HomeworkDbContext.AccountBook.OrderByDescending(x => x.Dateee);
            var list = new List<BookKeepingViewModel>();
            foreach (var item in data)
            {
                list.Add(new BookKeepingViewModel
                {
                    ID = item.Id.ToString(),
                    Amout = item.Amounttt,
                    Category = ((CategoryEnum)item.Categoryyy).GetDescription(),
                    CreateDate = item.Dateee,
                    Remark = item.Remarkkk,
                });
            }
            return list;

            //var query = from q in _HomeworkDbContext.AccountBook
            //            select new BookKeepingViewModel
            //            {
            //                ID = q.Id.ToString(),
            //                Amout=q.Amounttt,
            //                Category = q.Categoryyy.ToString(),
            //                CreateDate = q.Dateee,
            //                Remark = q.Remarkkk,
            //            };

            // ((CategoryEnum)q.Categoryyy).GetDescription(),
            //(CategoryEnum)Enum.ToObject(typeof(CategoryEnum), q.Categoryyy).GetDescription(),
            //return query.ToList();
        }

    }
}