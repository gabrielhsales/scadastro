using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using scadastro.Db;

namespace scadastro.Controllers
{
    public class AlunosController : SeducController
    {
        public AlunosController(ScadastroDbContext context) : base(context)
        {
        }

        
        public IActionResult Listagem()
        {
            return View();
        }




    }
}
