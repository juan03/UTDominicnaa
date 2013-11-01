using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UTDOMINICANA.Models;

namespace UTDOMINICANA.Controllers
{
    public class UserController : Controller
    {
        //
        // GET: /User/
      
        public ActionResult Index()
        {
            User user = new User() { nombre = "marvin", apellido = "sena", Entity = "developer", Estatus = "none", id = 1, Email = "Marvinnnz@gmail.com", EntityType = "dev" };
            User user1 = new User() { nombre = "Edison", apellido = "sena", Entity = "developer", Estatus = "none", id = 2, Email = "Marvinnnz@gmail.com", EntityType = "dev" };
            List<User> listaUsers = new List<User>(); listaUsers.Add(user); listaUsers.Add(user1);
            return View(listaUsers);
        }

        [HttpPost]
        public JsonResult getSomeInfo(int id)
        {

            if (id == 1)
            {
                User user = new User() { nombre = "marvin", apellido = "sena", Entity = "developer", Estatus = "none", id = 1, Email = "Marvinnnz@gmail.com", EntityType = "dev" };
                string[] userinfo = {user.nombre,user.apellido,user.Entity,user.Estatus,user.Email,user.EntityType };
                return Json(user);
            }
            else
            {
                User user = new User() { nombre = "Edison", apellido = "sena", Entity = "developer", Estatus = "none", id = 2, Email = "Marvinnnz@gmail.com", EntityType = "dev" };
                return Json(user);
            }
          
        }
        


    }
}
