using hrm_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hrm_api.Services.Interfaces.auth
{
  public  interface IRuleItemServices
    {
        object Get(string id);
        object GetList(string rule_id);
        object GetList();
        object Create(TbruleItem t);
        object Update(string id ,TbruleItem t);
        object Delete(string id);
        object AddRuleItem(string rule_id,int page_id);
        object AddAllRuleItem(string rule_id);


    }
}
