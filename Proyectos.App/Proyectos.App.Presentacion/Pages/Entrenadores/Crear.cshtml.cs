using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

using Proyectos.App.Dominio.Entidades;
using Proyectos.App.Persistencia.AppRepositorios;
using Proyectos.App.Persistencia;

namespace Proyectos.App.Presentacion.Entrenadores
{
    public class CrearModel : PageModel
    {
        private readonly IRepositorios _appContext;
        [BindProperty]
        public Entrenador entrenador { get; set; }

        public CrearModel(){
            //cargar desde la base de datos tabla entrenador
            this._appContext = new Repositorios(new Proyectos.App.Persistencia.AppContext());
            //cargarTemporales();
        }
       

        public IActionResult OnGet(int? entrenadorId)
        {
            if (entrenadorId.HasValue)
            {
                entrenador = _appContext.GetEntrenador(entrenadorId.Value);
            }
            else
            {
                entrenador = new Entrenador();
            }
            if (entrenador == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
                return Page();

        }

        public IActionResult OnPost()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }
            if(entrenador.id > 0)
            {
               entrenador = _appContext.UpdateEntrenador(entrenador);
            }
            else
            {
                //entrenador.vigente = true;
               _appContext.AddEntrenador(entrenador);
            }
            return Redirect("List");
            
        }
    }
}