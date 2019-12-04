using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Facebook;
using Newtonsoft.Json;
using System.Web.Security;
using System.Net.Http;
using MilOficios.Models;
using MilOficios.Entidades;

namespace MilOficios.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Usuario

        #region VIEW
        public ActionResult Index()
        {
            return View();
        }
        #endregion
        public ActionResult Login()
        {
            return View();
        }

        #region API FACEBOOK
        [HttpPost]
        public JsonResult LoginWithFacebook()
        {
            return Json("");
        }

        private Uri RediredtUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallback");
                return uriBuilder.Uri;
            }
        }

        [AllowAnonymous]
        public ActionResult Facebook()
        {
            var fb = new FacebookClient();
            var loginUrl = fb.GetLoginUrl(new

            {
                client_id = "374709140113609",
                client_secret = "814aba5e14d3fa4204ea0eb8b6484aab",
                redirect_uri = RediredtUri.AbsoluteUri,
                response_type = "code",
                scope = "email"

            });
            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallback(string code)
        {
            var fb = new FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new
            {
                client_id = "374709140113609",
                client_secret = "814aba5e14d3fa4204ea0eb8b6484aab",
                redirect_uri = RediredtUri.AbsoluteUri,
                code = code
            });

            var accessToken = result.access_token;
            Session["AccessToken"] = accessToken;
            fb.AccessToken = accessToken;
            dynamic me = fb.Get("me?fields=link,first_name,currency,last_name,email,gender,locale,timezone,verified,picture,age_range");
            var user = new Usuario()
            {
                nombres = me.first_name + " " + me.last_name,
                correo = me.email,
                urlFoto = me.picture.data.url
            };

            //1. Comprobar existencia de usuario
            Usuario objUsuario = FindUSuario(user.correo);
            if(objUsuario == null)
            {
                //2. Insertamos al usuario
                string response = InsertUsuario(user);
            }
            objUsuario.nombres = user.nombres;
            objUsuario.correo = user.correo;
            objUsuario.urlFoto = user.urlFoto;

            Session["Usuario"] = objUsuario;

            FormsAuthentication.SetAuthCookie(objUsuario.correo, false);
            return RedirectToAction("Index", "Usuario");
        }
        #endregion

        public JsonResult Listado()
        {
            HttpClient clienteHttp = new HttpClient();
            clienteHttp.BaseAddress = new Uri("http://miloficios.somee.com/");

            var request = clienteHttp.GetAsync("API/ListaTipoUsuario/").Result;

            var resultString = request.Content.ReadAsStringAsync().Result;
            var ls = JsonConvert.DeserializeObject<Rolcabecera>(resultString);
            return Json(ls, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Autenticacion(UserAPi x)
        {
            try
            {
                HttpClient clienteHttp = new HttpClient();
                clienteHttp.BaseAddress = new Uri("http://miloficios.somee.com/");
                var url = "API/Login?usuario=" + x.Correo + "&contrasenia=" + x.Contrasena;
                var request = clienteHttp.GetAsync(url).Result;

                var resultString = request.Content.ReadAsStringAsync().Result;
                var ls = JsonConvert.DeserializeObject<Result>(resultString);
                Session["Usuario"] = ls.login;
                return Json(ls, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {
                return Json(new Result { codResultado = 0, desResultado = ex.Message }, JsonRequestBehavior.AllowGet);
            }          
        }

        [HttpPost]
        public JsonResult Register(UserAPi model)
        {
            if (model.Nombres==null && model.telefono==null)
                return Json(new Result { codResultado = 0, desResultado = (model.Nombres == null ? "Ingrese nombres" : model.telefono == null ? "Ingrese teléfono" : "Ingrese contraseña") }, JsonRequestBehavior.AllowGet);
            else
                try
                {
                    HttpClient clienteHttp = new HttpClient();
                    clienteHttp.BaseAddress = new Uri("http://miloficios.somee.com/");
                    var url = "API/RegistrarUsuario?Nombre="+model.Nombres+"&Email="+model.Correo+"&Contrasenia="+model.Contrasena+ "&isActivo=true&isElimando=false&FechaCreacion="+DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")+"&Telefono=" + model.telefono+"&codRol="+model.TipoUsuario+"&codLocalizacion=1&urlFoto=none";
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

        public ActionResult Logout()
        {
            System.Web.HttpContext.Current.Session.Abandon();
            return RedirectToAction("Login");
        }

        public Usuario FindUSuario(string correo)
        {
            Usuario objUsuario = null;
            try
            {
                HttpClient clienteHttp = new HttpClient();
                clienteHttp.BaseAddress = new Uri("http://miloficios.somee.com/");
                var url = "API/ConsultarCorreo?email=" + correo;
                var request = clienteHttp.GetAsync(url).Result;

                var resultString = request.Content.ReadAsStringAsync().Result;
                objUsuario = JsonConvert.DeserializeObject<Usuario>(resultString);
            }
            catch (Exception ex) {}
            return objUsuario;
        }

        public string InsertUsuario(Usuario objUsuario)
        {
            try
            {
                HttpClient clienteHttp = new HttpClient();
                clienteHttp.BaseAddress = new Uri("http://miloficios.somee.com/");
                var url = "API/RegistrarUsuario?Nombre=" + objUsuario.nombres + "&Email=" + objUsuario.correo + "&Contrasenia=#TodoGetGil&isActivo=true&isElimando=false&FechaCreacion=" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "&Telefono=123456789&codRol=2&codLocalizacion=1&urlFoto=" + objUsuario.urlFoto;
                var request = clienteHttp.GetAsync(url).Result;
                if (request.IsSuccessStatusCode)
                    return "success";
                else
                    return "error";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}