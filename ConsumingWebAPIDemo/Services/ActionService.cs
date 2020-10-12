using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsumingWebAPIDemo.IService;

namespace ConsumingWebAPIDemo.Services
{
    public class ActionService
    {
        IAction action; 
       public ActionService(IAction _action)
        {
            action = _action;
        }

        public void TakeAction(string AccessToken, string baseAddress)
        {
            action.DoAction(AccessToken, baseAddress);
        }
    }
}
