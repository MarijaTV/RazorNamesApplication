using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RazorNamesApplication.Models;

namespace RazorNamesApplication.Controllers
{
    public class NameController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult SubmitName(NameModel model)
        {
            //Reading
            string readModels = System.IO.File.ReadAllText("Names.json");
            List<NameModel> receivedModels = JsonConvert.DeserializeObject<List<NameModel>>(readModels);
            if (receivedModels == null)
            {
                receivedModels = new();
            }

            //Updating File
            receivedModels.Add(model);
            //Saving updates
            string jsonModels = JsonConvert.SerializeObject(receivedModels);

            System.IO.File.WriteAllText("Names.json", jsonModels);
            return View("NamesDisplay", receivedModels);
        }
    }
}
