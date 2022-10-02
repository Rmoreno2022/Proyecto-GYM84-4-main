using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.EntityFrameworkCore;
using Proyectos.App.Dominio.Entidades;

namespace Proyectos.App.Persistencia.AppRepositorios
{
    public class Repositorios : IRepositorios
    {
       private readonly AppContext _appContext;
       public IEnumerable<Entrenador> entrenadores {get; set;} 
       public IEnumerable<Usuario> usuarios {get; set;} 
      
       public Repositorios(AppContext appContext)
        {
            _appContext = appContext;
        }
        
        //AQUÍ CADA UNO DE LOS MÉTODOS DEL CRUD, REFERENCIADOS EN LA INTERFACE
        //SIGUIENTE DIAPOSITIVA

        Entrenador IRepositorios.AddEntrenador(Entrenador entrenador)
        {
        try
         {
            var EntrenadorAdicionado = _appContext.entrenador.Add( entrenador );  //INSERT en la BD
            _appContext.SaveChanges();                  
            return EntrenadorAdicionado.Entity;
          }catch
            {
                throw;
            }
        }

        IEnumerable<Entrenador> IRepositorios.GetAllEntrenadores(string? searchString)
        {
            if (searchString == null)
                entrenadores = _appContext.entrenador;
            else{
                //busca coincidencias entre los registros y la cadena enviada
                entrenadores = _appContext.entrenador.Where(s => s.identificacion.Contains(searchString));   
                //busca solamente los que son exactamente igual a la cadena enviada 
                //entrenadores = _appContext.entrenador.Where(s => s.identificacion.Equals(searchString));    
            }
            return entrenadores;
        }

       Entrenador IRepositorios.GetEntrenador(int? idEntrenador)
       {
            return _appContext.entrenador.FirstOrDefault(p => p.id == idEntrenador);
       }

       Entrenador IRepositorios.UpdateEntrenador(Entrenador entrenador)
        {    
            var EntrenadorEncontrado = _appContext.entrenador.FirstOrDefault(p => p.id == entrenador.id);
            if (EntrenadorEncontrado != null)
            {
                EntrenadorEncontrado.identificacion  = entrenador.identificacion;
                EntrenadorEncontrado.nombre          = entrenador.nombre;
                EntrenadorEncontrado.mail            = entrenador.mail;
                EntrenadorEncontrado.movil           = entrenador.movil;
                EntrenadorEncontrado.vigente         = entrenador.vigente;
                _appContext.SaveChanges();
            }
            return EntrenadorEncontrado;
        }

        void IRepositorios.DeleteEntrenador(int idEntrenador)
        {   
            var EntrenadorEncontrado = _appContext.entrenador.FirstOrDefault(p => p.id == idEntrenador);
            if (EntrenadorEncontrado != null){                
                _appContext.entrenador.Remove(EntrenadorEncontrado);
                _appContext.SaveChanges();
            }
            return;
        }

        

        //repositorio para usuarios
        Usuario IRepositorios.AddUsuario(Usuario usuario)
        {
        try
         {
            var UsuarioAdicionado = _appContext.usuario.Add( usuario );  //INSERT en la BD
            _appContext.SaveChanges();                  
            return UsuarioAdicionado.Entity;
          }catch
            {
                throw;
            }
        }

        IEnumerable<Usuario> IRepositorios.GetAllUsuarios(string? searchString)
        {
            if (searchString == null)
                usuarios = _appContext.usuario;
            else{
                //busca coincidencias entre los registros y la cadena enviada
                //usuarios = _appContext.usuario.Where(s => s.identificacion.Contains(searchString));   
                //busca solamente los que son exactamente igual a la cadena enviada 
                usuarios = _appContext.usuario.Where(s => s.identificacion.Equals(searchString));    
            }
            return usuarios;
        }

       Usuario IRepositorios.GetUsuario(int? idUsuario)
       {
            return _appContext.usuario.FirstOrDefault(p => p.id == idUsuario);
       }

       Usuario IRepositorios.UpdateUsuario(Usuario usuario)
        {    
            var UsuarioEncontrado = _appContext.usuario.FirstOrDefault(p => p.id == usuario.id);
            if (UsuarioEncontrado != null)
            {
                UsuarioEncontrado.identificacion  = usuario.identificacion;
                UsuarioEncontrado.nombre          = usuario.nombre;
                UsuarioEncontrado.mail            = usuario.mail;
                UsuarioEncontrado.movil           = usuario.movil;
                UsuarioEncontrado.vigente         = usuario.vigente;
                _appContext.SaveChanges();
            }
            return UsuarioEncontrado;
        }

        void IRepositorios.DeleteUsuario(int idUsuario)
        {   
            var UsuarioEncontrado = _appContext.usuario.FirstOrDefault(p => p.id == idUsuario);
            if (UsuarioEncontrado != null){                
                _appContext.usuario.Remove(UsuarioEncontrado);
                _appContext.SaveChanges();
            }
            return;
        }

       
    } //fin repositorios
}

