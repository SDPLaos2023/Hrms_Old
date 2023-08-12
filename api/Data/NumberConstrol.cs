using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using hrm_api.Models;

namespace hrm_api.Data
{
    public static class NumberConstrol
    {
        public static string GetNumber(string code)
        {
            try
            {
                using (var db = new hrm_projectContext())
                {
                    var number = (from c in db.Numbercontrols where c.Code == code select c.Number).FirstOrDefault();
                    string strNumber = string.Format("{1}{0}", number.ToString().PadLeft(5, '0'),code);
                    return strNumber;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                return RandomString(10);
            }
        }

        public static string GetNextNumber(string code) {
            string strNumber = GetNumber(code);
            SetNextNumber(code);
            return strNumber;
        }

        private static void SetNextNumber(string code) {
            using (var db = new hrm_projectContext())
            {
                var number = (from c in db.Numbercontrols where c.Code == code select c).FirstOrDefault();
                number.Number += 1;
                db.SaveChanges();
            }
        }

        internal static string SetNewMaxNumber(string code,int maxnum)
        {
            using (var db = new hrm_projectContext())
            {

                var number = (from c in db.Numbercontrols where c.Code == code select c).FirstOrDefault();
                number.Number = maxnum+1;                
                db.SaveChanges();

                return GetNextNumber(code);

            }
        }

        private static Random random = new Random();
        public static string RandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789abcdefghijklmnopqrstuvwxyz";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
