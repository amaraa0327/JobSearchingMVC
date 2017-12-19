using JobSearchTrackingMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace JobSearchTrackingMVC.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            IEnumerable<JSTrackingViewModel> jstrackings = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.0.7:8888/api/");

                var responseTask = client.GetAsync("jstracking");
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<IList<JSTrackingViewModel>>();
                    readtask.Wait();

                    jstrackings = readtask.Result;
                }
                else //web api sent error response 
                {
                    jstrackings = Enumerable.Empty<JSTrackingViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(jstrackings);
        }

        public ActionResult FollowedUps(bool followup)
        {
            IEnumerable<JSTrackingViewModel> jstrackings = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.0.7:8888/api/");

                var responseTask = client.GetAsync(String.Format("jstracking?followUp={0}", followup));
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<IList<JSTrackingViewModel>>();
                    readtask.Wait();

                    jstrackings = readtask.Result;
                }
                else //web api sent error response 
                {
                    jstrackings = Enumerable.Empty<JSTrackingViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(jstrackings);
        }

        public ActionResult WithInterview(bool withinterview)
        {
            IEnumerable<JSTrackingViewModel> jstrackings = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.0.7:8888/api/");

                var responseTask = client.GetAsync(String.Format("jstracking?withInterview={0}", withinterview));
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<IList<JSTrackingViewModel>>();
                    readtask.Wait();

                    jstrackings = readtask.Result;
                }
                else //web api sent error response 
                {
                    jstrackings = Enumerable.Empty<JSTrackingViewModel>();

                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(jstrackings);
        }

        public ActionResult Create() {
            return View();
        }

        [HttpPost]
        public ActionResult Create(JSTrackingViewModel jstracking)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.0.7:8888/api/");
                var postTask = client.PostAsJsonAsync<JSTrackingViewModel>("jstracking", jstracking);
                postTask.Wait();

                var result = postTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(jstracking);
        }

        public ActionResult Details(int id)
        {
            JSTrackingViewModel jstracking = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.0.7:8888/api/");
                var responseTask = client.GetAsync(String.Format("jstracking?id={0}", id.ToString()));
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<JSTrackingViewModel>();
                    readtask.Wait();

                    jstracking = readtask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(jstracking);
        }

        public ActionResult Edit(int id)
        {
            JSTrackingViewModel jstracking = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.0.7:8888/api/");
                var responseTask = client.GetAsync(String.Format("jstracking?id={0}", id.ToString()));
                responseTask.Wait();
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readtask = result.Content.ReadAsAsync<JSTrackingViewModel>();
                    readtask.Wait();

                    jstracking = readtask.Result;
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Server error. Please contact administrator.");
                }
            }

            return View(jstracking);
        }

        [HttpPost]
        public ActionResult Edit(JSTrackingViewModel jstracking)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.0.7:8888/api/");

                var putTask = client.PutAsJsonAsync<JSTrackingViewModel>("jstracking", jstracking);
                putTask.Wait();

                var result = putTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            }
            ModelState.AddModelError(string.Empty, "Server Error. Please contact administrator.");

            return View(jstracking);
        }

        public ActionResult Delete(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://192.168.0.7:8888/api/");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync("jstracking/" + id.ToString());
                deleteTask.Wait();

                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {

                    return RedirectToAction("Index");
                }
            }

            return RedirectToAction("Index");
        }
    }
}