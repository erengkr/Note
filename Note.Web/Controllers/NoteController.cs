using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Note.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Note.Web.Controllers
{
    public class NoteController : Controller
    {
        // GET: NoteController
        public ActionResult Index()
        {
            var list = GetNoteList();
            return View(list);
        }

        // GET: NoteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: NoteController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: NoteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NoteController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: NoteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: NoteController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: NoteController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
        private List<TblNotess> GetNoteList()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://localhost:61865/api/TblNotesses");
            WebResponse response = request.GetResponse();
            string responseData;
            var retVal = new List<TblNotess>();

            using (StreamReader responseReader = new StreamReader(response.GetResponseStream()))
            {
                responseData = responseReader.ReadToEnd();
            }
            retVal = JsonConvert.DeserializeObject<List<TblNotess>>(responseData);
            return retVal;
        }
    }
}
