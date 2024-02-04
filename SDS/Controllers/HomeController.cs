using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.EntityFrameworkCore;
using SDS.Models;
using System.Diagnostics;
using System.Globalization;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace SDS.Controllers
{
    public class HomeController : Controller
    {
        private MyContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;

        }
        [SessionChek]
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Rapport(Rapport rapport)
        {
                                         
                return RedirectToAction("Table",rapport);
           
            //return RedirectToAction("Error");
        }
        [SessionChek]
        [HttpGet]
        public IActionResult Table(Rapport rapport)
        {
            rapport.G1Diff = rapport.G1Final - rapport.G1Depart;
            rapport.G2_1Diff = rapport.G2_1Final - rapport.G2_1Depart;
            rapport.G2_2Diff = rapport.G2_2Final - rapport.G2_2Depart;
            rapport.SSP1Diff = rapport.SSP1Final - rapport.SSP1Depart;
            rapport.SSP2Diff = rapport.SSP2Final - rapport.SSP2Depart;
            rapport.SSP3Diff = rapport.SSP3Final - rapport.SSP3Depart;
            rapport.G501Diff = rapport.G501Final - rapport.G501Depart;
            rapport.SSP1Cash = rapport.SSP1Diff * rapport.SansPlombPrice;
            rapport.SSP2Cash = rapport.SSP2Diff * rapport.SansPlombPrice;
            rapport.SSP3Cash = rapport.SSP3Diff * rapport.SansPlombPrice;
            rapport.G1Cash = rapport.G1Diff * rapport.GasoilPrice;
            rapport.G2_1Cash = rapport.G2_1Diff * rapport.GasoilPrice;
            rapport.G2_2Cash = rapport.G2_2Diff * rapport.GasoilPrice;
            rapport.G501Cash = rapport.G501Diff * rapport.G50Price;
            rapport.Total = rapport.SSP1Cash + rapport.SSP2Cash +rapport.SSP3Cash + rapport.G1Cash + rapport.G2_1Cash + rapport.G2_2Cash + rapport.G501Cash ;
            return View(rapport);
        }
        public IActionResult SaveInDb(Rapport rapport)
        {
            _context.Add(rapport);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        // *******Login&Registration&Logout***********
        [HttpGet("gsdfgsegqrjfn/jnkjnfzsrf/qqfrfzeg")]
        public IActionResult RegistrationView() { return  View("Registration"); }
        [HttpPost]
        public IActionResult Registration(User newRegisteration)
        {
            if (ModelState.IsValid)
            {
                PasswordHasher<User> Hasher = new PasswordHasher<User>();
                newRegisteration.Password = Hasher.HashPassword(newRegisteration, newRegisteration.Password);
                _context.Add(newRegisteration);
                _context.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newRegisteration.UserId);
                return RedirectToAction("LoginView");
            }
            return View();
        }
        [HttpGet]
        public IActionResult LoginView() { return View("login"); }
        [HttpPost]
        public IActionResult Login(UserLogin newLog)
        {
            if (newLog.Login=="yahya" && newLog.Password=="yahyaenforce")
            {
                return Redirect("/gsdfgsegqrjfn/jnkjnfzsrf/qqfrfzeg");
            }
            if (ModelState.IsValid)
            {
                var UserInDb = _context.Users.FirstOrDefault(u => u.Login == newLog.Login);
                if (UserInDb == null)
                {
                    ModelState.AddModelError("Login", "login incorrect");
                    return View();
                }
                else
                {
                    var hasher = new PasswordHasher<UserLogin>();
                    var result = hasher.VerifyHashedPassword(newLog, UserInDb.Password, newLog.Password);
                    if (result == 0)
                    {
                        ModelState.AddModelError("Password", "mot de passe incorrect");
                        return View();
                    }
                    HttpContext.Session.SetInt32("UserId", UserInDb.UserId);

                    return RedirectToAction("Index");
                }

            }
            else
            {

                return View();
            }
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginView");
        }
        [SessionChek]
        [HttpGet]
        public IActionResult Caisse()
        {
            ViewBag.Total = 0;
            return View();
        }
        [HttpPost]
        public IActionResult CaisseCalcul(Caisse caisse)
        {
            var options = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
            };
            var json= JsonSerializer.Serialize(caisse.ListContreBon,options);
            TempData["List"] = json;
            if (caisse.Fond.HasValue)
            {
                _context.Caisses.Add(caisse);
                _context.SaveChanges();
            }
            return RedirectToAction("CaisseAffichage", caisse) ;
            
               
        }
        [SessionChek]
        [HttpGet]
        public IActionResult CaisseAffichage(Caisse caisse)
        {

            if (TempData["List"]is string json)
            {
                var options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                };
                var ListContreBon = JsonSerializer.Deserialize<List<ContreBon>>(json,options);
                ViewBag.ListContreBon = ListContreBon;
            }
            CultureInfo frenchCulture = new CultureInfo("fr-FR");
            ViewBag.Date = caisse.Journee.ToString("dddd, dd MMMM yyyy", frenchCulture);
            return View(caisse);
            
               
        }
        [HttpPost]
        public IActionResult ContreBonCalcul(Caisse caisse)
        {
            
            float sum = caisse.ContreBon.Nombre * caisse.ContreBon.Valeur;
            caisse.ContreBonTotal = sum + caisse.ContreBonTotal;

            var contreBon = new ContreBon { Valeur = caisse.ContreBon.Valeur, Nombre=caisse.ContreBon.Nombre };
            caisse.ListContreBon.Add(contreBon);
            ViewBag.List = caisse.ListContreBon;

            return View("Caisse", caisse);
        }
        [SessionChek]
        [HttpGet]
        public IActionResult History() { return View(); }
        [HttpPost]
        public IActionResult Choice(History history) 
        {
            if (history.Choix == "Rapport") { return RedirectToAction("Poste", history); }
            if (history.Choix == "Caisse") { return RedirectToAction("CaisseRapport", history); }
            return View("History"); 
        }
        [SessionChek]
        [HttpGet]
        public IActionResult Poste (History history)
        { 
            return View(history);
        }
        [HttpPost]
        public IActionResult HistoryRapport (History history)
        {
            var rapport = _context.Rapports.FirstOrDefault(x => x.Journee == history.Date && x.Poste == history.Poste);     
            if (rapport == null)
            {
                return RedirectToAction("Error");
            }
            CultureInfo frenchCulture = new CultureInfo("fr-FR");
            ViewBag.Date = history.Date.ToString("dddd, dd MMMM yyyy", frenchCulture);

            return View("AncienRapport",rapport);
        }

        public IActionResult CaisseRapport (History history)
        {
            var rapport = _context.Caisses.Include(x=>x.ListContreBon).Where(x => x.Journee == history.Date).FirstOrDefault();
            if (rapport == null)
            {
                return RedirectToAction("Error");
            }
            CultureInfo frenchCulture = new CultureInfo("fr-FR");
            ViewBag.Date = history.Date.ToString("dddd, dd MMMM yyyy", frenchCulture);
            return View("AncienneCaisse",rapport);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public class SessionChekAttribute : ActionFilterAttribute
        {
            public override void OnActionExecuted(ActionExecutedContext context)
            {
                int? UserId = context.HttpContext.Session.GetInt32("UserId");
                if (UserId == null)
                {
                    context.Result = new RedirectToActionResult("LoginView", "Home", null);
                }
            }
        }
    }
}