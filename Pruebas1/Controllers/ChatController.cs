using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pruebas1.Models.Response;
using Pruebas1.Models.ViewModels;

namespace Pruebas1.Controllers
{
    [Route("api/[controller]")]
    public class ChatController : Controller
    {
        private Models.MyDBContext db;
        public ChatController(Models.MyDBContext context)
        {
            db = context;
        }
        [HttpGet("[action]")]
        public IEnumerable<MessageViewModels> Message()
        {
            List<MessageViewModels> lst = (from d in db.Message
                                           orderby d.Id descending
                                          select new MessageViewModels
                                          {
                                              Id = d.Id,
                                              Name = d.Name,
                                              Text = d.Text
                                          }).ToList();
            return lst;
        }

        [HttpPost("[action]")]
        public MyResponse Add([FromBody]MessageViewModel model)
        {
            MyResponse oR = new MyResponse();
            try
            {
                Models.Message oMessage = new Models.Message();
                oMessage.Name = model.Name;
                oMessage.Text = model.Text;
                db.Message.Add(oMessage);
                db.SaveChanges();
                oR.Succes = 1;
            }
            catch (Exception ex)
            {
                oR.Succes = 0;
                oR.Message = ex.Message;
            }
            return oR;
        }
    }
}