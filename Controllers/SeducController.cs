using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using scadastro.Db;

namespace scadastro.Controllers
{
    public class SeducController : Controller
    {
        protected readonly ScadastroDbContext db;

        public ScadastroDbContext Db => db;


        public SeducController(ScadastroDbContext context)
        {
            this.db = context;
        }
    }
}
