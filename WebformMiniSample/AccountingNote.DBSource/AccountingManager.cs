using AccountingNote.ORM.DBModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNote.DBSource
{
    public class AccountingManager
    {
        /// <summary> 查詢流水帳清單 </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static List<Accounting> GetAccountingList(Guid userID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Accountings
                         where item.UserID == userID
                         select item);

                    var list = query.ToList();
                    return list;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }


        /// <summary> 查詢流水帳 </summary>
        /// <param name="id"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static Accounting GetAccounting(int id, Guid userID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var query =
                        (from item in context.Accountings
                         where item.ID == id && item.UserID == userID
                         select item);

                    var obj = query.FirstOrDefault();
                    return obj;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }


        /// <summary> 建立流水帳 </summary>
        /// <param name="accounting"></param>
        public static void CreateAccounting(Accounting accounting)
        {
            // <<<<< check input >>>>>
            if (accounting.Amount < 0 || accounting.Amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1,000,000 .");

            if (accounting.ActType < 0 || accounting.ActType > 1)
                throw new ArgumentException("ActType must be 0 or 1.");
            // <<<<< check input >>>>>

            try
            {
                using (ContextModel context = new ContextModel())
                {
                    accounting.CreateDate = DateTime.Now;
                    context.Accountings.Add(accounting);
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }


        /// <summary> 變更流水帳 </summary>
        /// <param name="accounting"></param>
        public static bool UpdateAccounting(Accounting accounting)
        {
            // <<<<< check input >>>>>
            if (accounting.Amount < 0 || accounting.Amount > 1000000)
                throw new ArgumentException("Amount must between 0 and 1,000,000 .");

            if (accounting.ActType < 0 || accounting.ActType > 1)
                throw new ArgumentException("ActType must be 0 or 1.");
            // <<<<< check input >>>>>

            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var dbObject = 
                        context.Accountings.Where(obj => obj.ID == accounting.ID).FirstOrDefault();

                    if(dbObject != null)
                    {
                        dbObject.Caption = accounting.Caption;
                        dbObject.Body = accounting.Body;
                        dbObject.Amount = accounting.Amount;
                        dbObject.ActType = accounting.ActType;

                        context.SaveChanges();

                        return true;
                    }

                    return false;
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return false;
            }
        }


        /// <summary> 刪除流水帳 </summary>
        /// <param name="ID"></param>
        public static void DeleteAccounting(int ID)
        {
            try
            {
                using (ContextModel context = new ContextModel())
                {
                    var dbObject = 
                        context.Accountings.Where(obj => obj.ID == ID).FirstOrDefault();

                    if(dbObject != null)
                    {
                        context.Accountings.Remove(dbObject);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
            }
        }
    }
}