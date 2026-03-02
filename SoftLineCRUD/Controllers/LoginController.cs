using Microsoft.AspNetCore.Mvc;
using SoftLineCRUD.Models;

namespace SoftLineCRUD.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (loginModel.Login == "admin" && loginModel.Senha == "123456") 
                    {
                    return RedirectToAction("Index", "Home");
                    }
                    TempData["MensagemErro"] = "Login ou senha incorretos!";
                }
                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, algo deu errado! Detalhes do erro: {erro.Message}";
                return RedirectToAction("Index");
            }
        }
    }
}
