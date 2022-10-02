//Directivas
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Proyectos.App.Dominio.Entidades;
using Proyectos.App.Persistencia.AppRepositorios;

namespace Proyectos.App.Persistencia.AppRepositorios
{
    public interface IRepositorios
    {
        //contratos o firmas para los metodos Entrenador        
        Entrenador AddEntrenador(Entrenador entrenador);
        IEnumerable<Entrenador> GetAllEntrenadores(string? searchString);         
        Entrenador GetEntrenador(int? idEntrenador);
        Entrenador UpdateEntrenador(Entrenador entrenador);
        void DeleteEntrenador(int idEntrenador); 

    } //fin IRepositorios
}



