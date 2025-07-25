using Microsoft.AspNetCore.Mvc;

public class FormulaireController : Controller
{
    // Action Index par défaut
    public IActionResult Index()
    {
        return View(); // Va chercher Views/Formulaire/Index.cshtml
    }

    // Exemple d’autre action
    public IActionResult Details()
    {
        return View(); // Va chercher Views/Formulaire/Details.cshtml
    }
}
