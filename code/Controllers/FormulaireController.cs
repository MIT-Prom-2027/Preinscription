using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http; // Pour HttpContext.Session


public class FormulaireController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        var info = HttpContext.Session.GetString("infos_bacc");
        if (info != null)
        {
            ViewBag.InfosBacc = System.Text.Json.JsonSerializer.Deserialize<BaccInfo>(info);
        }
        return View();
    }

    [HttpPost]
    public IActionResult Index(string numero_bacc)
    {
        if (string.IsNullOrWhiteSpace(numero_bacc))
        {
            ViewBag.Erreur = "Le numéro BACC est requis.";
            return View();
        }

        // Simuler une base de données
        var baseSimulee = new Dictionary<string, BaccInfo>
        {
            { "12345678", new BaccInfo { Nom = "Rakoto Herisoa", NumeroBacc = "12345678", Mention = "Bien", Serie = "C", Annee = 2024 } },
            { "87654321", new BaccInfo { Nom = "Randria Lova", NumeroBacc = "87654321", Mention = "Assez Bien", Serie = "A2", Annee = 2023 } }
        };

        if (!baseSimulee.ContainsKey(numero_bacc))
        {
            ViewBag.Erreur = "Numéro BACC invalide ou introuvable.";
            return View();
        }

        var infos = baseSimulee[numero_bacc];

        // Stocker dans la session
        HttpContext.Session.SetString("infos_bacc", System.Text.Json.JsonSerializer.Serialize(infos));

        ViewBag.InfosBacc = infos;
        return View();
    }

    public class BaccInfo
    {
        public string NumeroBacc { get; set; }
        public string Nom { get; set; }
        public string Mention { get; set; }
        public string Serie { get; set; }
        public int Annee { get; set; }
    }
}
