using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    class Repositorio
    {
        private ContextDBMusica _context;
        public Repositorio()
        {
            _context = new ContextDBMusica();
        }

        // obtener resultados de la base de datos
        public List<Canciones> GetCanciones()
        {
            List<Canciones> listacanciones = _context.Canciones.ToList();
            return listacanciones;
        }
        public List<Cantantes> GetCantantes()
        {
            List<Cantantes> listacantantes = _context.Cantantes.ToList();
            return listacantantes;
        }
        public List<Albums> GetAlbums()
        {
            List<Albums> listalbums = _context.Albums.ToList();
            return listalbums;
        }

        public bool GetCancion(string nombre)
        {
            Canciones cancion = GetCanciones().Where(x => x.nombre == nombre).FirstOrDefault();
            if (cancion != null)
                return true;
            else
                return false;
        }

        public bool GetCantante(string nombre)
        {
            Cantantes cantante = GetCantantes().Where(x => x.nombre == nombre).FirstOrDefault();
            if (cantante != null)
                return true;
            else
                return false;
        }


        public void JoinAlbumCancion()
        {
            var resultados = _context.Albums.Join(
                _context.Canciones,
                dir => dir.id_cancion,
                cancion => cancion.id,
                (dir, cancion) => new { dir, cancion }
                ).ToList();
            foreach (var resultado in resultados)
            {
                Console.WriteLine("\n\t La " + resultado.cancion.nombre + " esta en  " + resultado.dir.nombre);
            }
           
        }

        // insertar nuevos registros

        public void AgregarCantante(Cantantes cantante)
        {
            try
            {
                _context.Cantantes.AddOrUpdate(cantante);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tError al intentar agregar un nuevo cantante.");
            }
        }

        public void AgregarCancion(Canciones cancion)
        {
            try
            {
                _context.Canciones.AddOrUpdate(cancion);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tError al intentar agregar una nueva cancion.");
            }
        }

        public void AgregarAlbum(Albums album)
        {
            try
            {
                _context.Albums.AddOrUpdate(album);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("\n\tError al intentar agregar un nuevo album.");
            }
        }

        // eliminar registros de la base de datos

        public void EliminarCancion(Canciones cancion)
        {
            try
            {
                var valor = _context.Canciones.Where(x => x.nombre.Equals(cancion.nombre)).FirstOrDefault();
                _context.Canciones.Remove(valor);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("La cancion que ha intentado eliminar no se encuentra en la base de datos.");
            }
        }

        public void EliminarCantante(Cantantes cantante)
        {
            try
            {
                var valor = _context.Cantantes.Where(x => x.nombre.Equals(cantante.nombre) && x.apellido.Equals(cantante.apellido)).FirstOrDefault();
                _context.Cantantes.Remove(valor);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("El cantante que ha intentado eliminar no se encuentra en la base de datos.");
            }
        }

        public void ActualizarCantante(Cantantes cantante)
        {
            try
            {
                var valor = _context.Cantantes.Where(x => x.nombre.Equals(cantante.nombre) && x.apellido.Equals(cantante.apellido)).FirstOrDefault();
                _context.Cantantes.AddOrUpdate(cantante);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al intentar actualizar la informacion del cantante");
            }
        }

        public void ActualizarCancion(Canciones cancion)
        {
            try
            {
                var valor = _context.Canciones.Where(x => x.nombre.Equals(cancion.nombre)).FirstOrDefault();
                _context.Canciones.AddOrUpdate(cancion);
                _context.SaveChanges();
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al intentar actualizar la informacion de la cancion");
            }
        }

    }
}
