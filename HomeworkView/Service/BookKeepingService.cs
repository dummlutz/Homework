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
            //                Category = ((CategoryEnum)q.Categoryyy).GetDescription(),
            //                CreateDate = q.Dateee,
            //                Remark = q.Remarkkk,
            //            };

            // ((CategoryEnum)q.Categoryyy).GetDescription(),
            //(CategoryEnum)Enum.ToObject(typeof(CategoryEnum), q.Categoryyy).GetDescription(),
            //return query.ToList();
        }

        public static AccountBook GetByID(Guid id)
        {           
            var data = (AccountBook)_HomeworkDbContext.AccountBook.Find(id);
            return data;
        }

        public static AccountBook Update(AccountBook account)
        {
            var data =(AccountBook)_HomeworkDbContext.AccountBook.Find(account.Id);
            data.Amounttt = account.Amounttt;
            data.Categoryyy = account.Categoryyy;
            data.Dateee = account.Dateee;
            data.Remarkkk = account.Remarkkk;
            var result = _HomeworkDbContext.SaveChanges();
            return data;
        }

    }
}