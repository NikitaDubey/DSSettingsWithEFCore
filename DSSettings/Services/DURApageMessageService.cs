using DSSettings.Models.durapage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DSSettings.Services
{
    public class DURApageMessageService
    {
        public void Update(DURApageMessage dbMessage, DURApageMessage requestMessage)
        {
            dbMessage.Title = requestMessage.Title;
            dbMessage.Body = requestMessage.Body;
        }
    }
}
