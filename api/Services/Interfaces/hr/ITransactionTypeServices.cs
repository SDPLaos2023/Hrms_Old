using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.hr
{
   public interface ITransactionTypeServices
    {
        string Create(TbtransactionType t);
        string Update(string id, TbtransactionType t);
        string Delete(string id);
        IEnumerable<TbtransactionType> GetList();
        TbtransactionType Get(string id);
    }
}
