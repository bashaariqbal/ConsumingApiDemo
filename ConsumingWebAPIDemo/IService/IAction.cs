using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsumingWebAPIDemo.IService
{
   public interface IAction
    {
       void DoAction(string AccessToken, string baseAddress);
    }
}
