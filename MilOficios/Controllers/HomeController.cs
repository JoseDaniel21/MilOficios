using MilOficios.Entidades;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;

namespace MilOficios.Controllers
{
    [RequireHttps]
    public class HomeController : Controller
    {
        #region VIEWS
        public ActionResult Index()
        {
            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            Response.AppendHeader("Expires", "0"); // Proxies
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult ListMudanza()
        {
            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            Response.AppendHeader("Expires", "0"); // Proxies
            return View();
        }
        public ActionResult ListTecnico()
        {
            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            Response.AppendHeader("Expires", "0"); // Proxies
            return View();
        }
        public ActionResult ListJardinero()
        {
            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            Response.AppendHeader("Expires", "0"); // Proxies
            return View();
        }
        public ActionResult ListArquitecto()
        {
            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            Response.AppendHeader("Expires", "0"); // Proxies
            return View();
        }
        public ActionResult ListSeguridad()
        {
            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            Response.AppendHeader("Expires", "0"); // Proxies
            return View();
        }
        public ActionResult ListGas()
        {
            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            Response.AppendHeader("Expires", "0"); // Proxies
            return View();
        }
        public ActionResult ListCarpintero()
        {
            Response.AppendHeader("Cache-Control", "no-cache, no-store, must-revalidate"); // HTTP 1.1.
            Response.AppendHeader("Pragma", "no-cache"); // HTTP 1.0.
            Response.AppendHeader("Expires", "0"); // Proxies
            return View();
        }

        #endregion

        #region JSON GET
        [HttpGet]
        public JsonResult JListMudanza()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://miloficios.somee.com/");

            var request = clienteHttp.GetAsync("API/ListarServicioXCategoria?codCategoria=1").Result;

            var resultString = request.Content.ReadAsStringAsync().Result;
            var ls = JsonConvert.DeserializeObject<ServicioCabecera>(resultString);
            return Json (ls, JsonRequestBehavior.AllowGet);
        }
        public JsonResult JListTecnico()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://miloficios.somee.com/");

            var request = clienteHttp.GetAsync("API/ListarServicioXCategoria?codCategoria=2").Result;

            var resultString = request.Content.ReadAsStringAsync().Result;
            var ls = JsonConvert.DeserializeObject<ServicioCabecera>(resultString);
            return Json(ls, JsonRequestBehavior.AllowGet);
        }
        public JsonResult JListJardinero()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://miloficios.somee.com/");

            var request = clienteHttp.GetAsync("API/ListarServicioXCategoria?codCategoria=3").Result;

            var resultString = request.Content.ReadAsStringAsync().Result;
            var ls = JsonConvert.DeserializeObject<ServicioCabecera>(resultString);
            return Json(ls, JsonRequestBehavior.AllowGet);
        }
        public JsonResult JListArquitecto()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://miloficios.somee.com/");

            var request = clienteHttp.GetAsync("API/ListarServicioXCategoria?codCategoria=4").Result;

            var resultString = request.Content.ReadAsStringAsync().Result;
            var ls = JsonConvert.DeserializeObject<ServicioCabecera>(resultString);
            return Json(ls, JsonRequestBehavior.AllowGet);
        }
        public JsonResult JListSeguridad()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://miloficios.somee.com/");

            var request = clienteHttp.GetAsync("API/ListarServicioXCategoria?codCategoria=5").Result;

            var resultString = request.Content.ReadAsStringAsync().Result;
            var ls = JsonConvert.DeserializeObject<ServicioCabecera>(resultString);
            return Json(ls, JsonRequestBehavior.AllowGet);
        }
        public JsonResult JListGas()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://miloficios.somee.com/");

            var request = clienteHttp.GetAsync("API/ListarServicioXCategoria?codCategoria=6").Result;

            var resultString = request.Content.ReadAsStringAsync().Result;
            var ls = JsonConvert.DeserializeObject<ServicioCabecera>(resultString);
            return Json(ls, JsonRequestBehavior.AllowGet);
        }
        public JsonResult JListCarpintero()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://miloficios.somee.com/");

            var request = clienteHttp.GetAsync("API/ListarServicioXCategoria?codCategoria=7").Result;

            var resultString = request.Content.ReadAsStringAsync().Result;
            var ls = JsonConvert.DeserializeObject<ServicioCabecera>(resultString);
            return Json(ls, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region JSON POST
        [HttpPost]
        public JsonResult Register(Servicio model)
        {
            //if (model.Nombres == null && model.telefono == null)
            //    return Json(new Result { codResultado = 0, desResultado = (model.Nombres == null ? "Ingrese nombres" : model.telefono == null ? "Ingrese teléfono" : "Ingrese contraseña") }, JsonRequestBehavior.AllowGet);
            //else
            var x = DateTime.Now.ToString(" HH:mm:ss");
            model.FechaFin += x;
            try
            {
                HttpClient clienteHttp = new HttpClient();
                clienteHttp.BaseAddress = new Uri("http://miloficios.somee.com/");
                var url = "API/RegistrarServicio?CodUsuario=" + model.CodUsuario + "&Descripcion=" + model.Descripcion + "&FechaFin=" + model.FechaFin + "&CodCategoria=" + model.CodCategoria + "&codLocalizacion=" + model.codLocalizacion + "&latitud=" + model.latitud + "&longitud=" + model.longitud;
                var request = clienteHttp.GetAsync(url).Result;
                var resultString = request.Content.ReadAsStringAsync().Result;
                var ls = JsonConvert.DeserializeObject<Result>(resultString);
                return Json(ls, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new Result { codResultado = 0, desResultado = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpPost]
        public JsonResult Solicitar(Solicitud model)
        {
            //if (model.Nombres == null && model.telefono == null)
            //    return Json(new Result { codResultado = 0, desResultado = (model.Nombres == null ? "Ingrese nombres" : model.telefono == null ? "Ingrese teléfono" : "Ingrese contraseña") }, JsonRequestBehavior.AllowGet);
            //else
         
            try
            {
                HttpClient clienteHttp = new HttpClient();
                clienteHttp.BaseAddress = new Uri("http://miloficios.somee.com/");
                var url = "API/GenerarSolicitudServicio?codServicio=" + model.codServicio + "&costo=" + model.costo + "&cotizacion=" + model.cotizacion + "&codUsuario=" + model.codUsuario;
                var request = clienteHttp.GetAsync(url).Result;
                var resultString = request.Content.ReadAsStringAsync().Result;
                var ls = JsonConvert.DeserializeObject<Result>(resultString);
                return Json(ls, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new Result { codResultado = 0, desResultado = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        #endregion
    }
}