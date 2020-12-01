using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aplicacion
{
    class Program
    {
        static Repositorio repo = new Repositorio();
        static void Main(string[] args)
        {
            String opc;
            do
            {
                Console.WriteLine("\n\t\t\tBienvenido A Sunfest Festival\n\n");
                Console.WriteLine("\t¿Que desea hacer?");
                Console.WriteLine("\t1) Ver informacion sobre los registros");
                Console.WriteLine("\t2) Insertar nuevos registros");
                Console.WriteLine("\t3) Eliminar registros");
                Console.WriteLine("\t4) Actualizar registros");
                Console.WriteLine("\t5) Salir");
                Console.Write("\tRespuesta: ");
                opc = Console.ReadLine();
                Console.Clear();
                switch (opc)
                {
                    case "1":
                        MenuDB();
                        break;
                    case "2":
                        AgregarDB();
                        break;
                    case "3":
                        EliminarDB();
                        break;
                    case "4":
                        ActualizarDB();
                        break;
                    case "5":
                        break;
                    default:
                        Console.WriteLine("\t\t\tFavor de seleccionar una opcion correcta\n\n\n\n");
                        Console.Clear();
                        break;
                }
            } while (opc.Equals("5") != true);
            
        }
        
        public static void MenuDB()
        {
            string opc;
            string valor;
            do
            {
                Console.WriteLine("\n\t\t\tRegistros de la Base de Datos\n\n");
                Console.WriteLine("\t¿Que desea hacer?");
                Console.WriteLine("\t1) Ver todos los cantantes ");
                Console.WriteLine("\t2) Ver todas las canciones ");
                Console.WriteLine("\t3) Buscar un artista por nombre ");
                Console.WriteLine("\t4) Buscar una cancion por nombre ");
                Console.WriteLine("\t5) Ver los albums a los que pertenecen las cancion");
                Console.WriteLine("\t6) Regresar al menu principal");
                Console.Write("\tRespuesta: ");
                opc = Console.ReadLine();
                Console.Clear();
                switch (opc)
                {
                    case "1":
                        List<Cantantes> listacantantes = repo.GetCantantes();
                        Console.WriteLine("\n\t\t\tCantantes que participaran\n\n");
                        foreach (var cantante in listacantantes)
                        {
                            Console.WriteLine("\t\t\t" + cantante.nombre +  " " + cantante.apellido + " su edad es de " + cantante.edad);
                        }
                        Console.WriteLine("\nPara continuar teclee cualquier tecla");
                        Console.ReadLine();
                        break;
                    case "2":
                        List<Canciones> listacanciones = repo.GetCanciones();
                        Console.WriteLine("\n\t\t\tCanciones\n\n");
                        foreach (var cancion in listacanciones)
                        {
                            Console.WriteLine("\t\t\t" + cancion.nombre);
                        }
                        Console.WriteLine("\nPara continuar teclee cualquier tecla");
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.Write("\n\t\t\tInserte el nombre del artista que desea buscar: \n\n");
                        valor = Console.ReadLine();
                        repo.GetCantante(valor);
                        Console.WriteLine("\nPara continuar teclee cualquier tecla");
                        Console.ReadLine();
                        break;
                    case "4":
                        Console.Write("\n\t\t\tInserte el nombre de la cancion que desea buscar: \n\n");
                        valor = Console.ReadLine();
                        repo.GetCancion(valor);
                        Console.WriteLine("\nPara continuar teclee cualquier tecla");
                        Console.ReadLine();
                        break;
                    case "5":
                        repo.JoinAlbumCancion();
                        Console.WriteLine("\nPara continuar teclee cualquier tecla");
                        Console.ReadLine();
                        break;
                    case "6":
                        break;
                    default:
                        Console.WriteLine("\t\t\tFavor de seleccionar una opcion correcta\n\n\n\n");
                        break;
                }
                Console.Clear();
            } while (opc.Equals("6") != true);

        }

        public static void AgregarDB()
        {
            string opc;
            do
            {
                Console.WriteLine("\n\t\t\tAñadir registros\n\n");
                Console.WriteLine("\t¿Que desea hacer?");
                Console.WriteLine("\t1) Agregar cantante ");
                Console.WriteLine("\t2) Agregar cancion ");
                Console.WriteLine("\t3) Regresar al menu principal");
                Console.Write("\tRespuesta: ");
                opc = Console.ReadLine();
                Console.Clear();
                switch (opc)
                {
                    case "1":
                        Cantantes cantante = new Cantantes();
                        Console.WriteLine("Digite el nombre del nuevo cantante: ");
                        Console.Write("Respuesta: ");
                        cantante.nombre = Console.ReadLine();
                        Console.WriteLine("Digite el apellido del nuevo cantante: ");
                        Console.Write("Respuesta: ");
                        cantante.apellido = Console.ReadLine();
                        Console.WriteLine("Digite la edad");
                        Console.Write("Respuesta: ");
                        cantante.edad = Console.Read();    
                        repo.AgregarCantante(cantante);
                        break;
                    case "2":
                        Canciones cancion = new Canciones();
                        Console.WriteLine("Digite el nombre de la nueva cancion: ");
                        Console.Write("Respuesta: ");
                        repo.AgregarCancion(cancion);
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("\t\t\tFavor de seleccionar una opcion correcta\n\n\n\n");
                        break;
                }
                Console.Clear();

            } while (opc.Equals("3") != true);
        }

        public static void EliminarDB()
        {
            int value;
            string opc;
            do
            {
                Console.WriteLine("\n\t\t\tEliminar informacion de la Base de Datos\n\n");
                Console.WriteLine("\t¿Que desea hacer?");
                Console.WriteLine("\t1) Eliminar cantante ");
                Console.WriteLine("\t2) Eliminar cancion ");
                Console.WriteLine("\t3) Regresar al menu principal");
                Console.Write("\tRespuesta: ");
                opc = Console.ReadLine();
                Console.Clear();
                switch (opc)
                {
                    case "1":
                        Cantantes cantante = new Cantantes();
                        Console.WriteLine("Digite el nombre del cantante a eliminar: ");
                        Console.Write("Respuesta: ");
                        cantante.nombre = Console.ReadLine();
                        Console.WriteLine("Digite el apellido del cantante a eliminar: ");
                        Console.Write("Respuesta: ");
                        cantante.apellido = Console.ReadLine();
                        repo.EliminarCantante(cantante);
                        break;
                    case "2":
                        Canciones cancion = new Canciones();
                        Console.WriteLine("Digite el nombre de la nueva cancion: ");
                        Console.Write("Respuesta: ");
                        repo.EliminarCancion(cancion);
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("\t\t\tFavor de seleccionar una opcion correcta\n\n\n\n");
                        break;
                }
                Console.Clear();
            } while (opc.Equals("3") != true);
        }

        public static void ActualizarDB()
        {
            string opc;
            do
            {
                Console.WriteLine("\n\t\t\tActualizar informacion de la Base de Datos\n\n");
                Console.WriteLine("\t¿Que desea hacer?");
                Console.WriteLine("\t1) Actualizar cantate ");
                Console.WriteLine("\t2) Actualizar cancion ");
                Console.WriteLine("\t3) Regresar al menu principal");
                Console.Write("\tRespuesta: ");
                opc = Console.ReadLine();
                Console.Clear();
                switch (opc)
                {
                    case "1":
                        Cantantes cantante = new Cantantes();
                        Console.WriteLine("Digite el nombre del cantante que desea actualizar: ");
                        Console.Write("Respuesta: ");
                        cantante.nombre = Console.ReadLine();
                        if (repo.GetCantante(cantante.nombre))
                        {
                            Console.WriteLine("Digite el nombre del cantante: ");
                            Console.Write("Respuesta: ");
                            cantante.nombre = Console.ReadLine();
                            Console.WriteLine("Digite el apellido del cantante: ");
                            Console.Write("Respuesta: ");
                            cantante.apellido = Console.ReadLine();
                            Console.WriteLine("Digite la edad del cantante");
                            Console.Write("Respuesta: ");
                            cantante.edad = Console.Read();
                            repo.ActualizarCantante(cantante);
                        }
                        else
                        {
                            Console.WriteLine("\n\tEl cantante que desea actualizar no ha sido encontrado");
                        }
                        break;
                    case "2":
                        Canciones cancion = new Canciones();
                        Console.WriteLine("Digite el nombre de la nueva cancion: ");
                        Console.Write("Respuesta: ");
                        cancion.nombre = Console.ReadLine();
                        if (repo.GetCancion(cancion.nombre))
                        {
                            Console.WriteLine("Digite el nuevo nombre de la nueva cancion: ");
                            Console.Write("Respuesta: ");
                            cancion.nombre = Console.ReadLine();
                            repo.ActualizarCancion(cancion);
                        }
                        else
                        {
                            Console.WriteLine("\n\tLa cancion que desea actualizar no ha sido encontrada en la base de datos");
                        }
                        break;
                    case "3":
                        break;
                    default:
                        Console.WriteLine("\t\t\tFavor de seleccionar una opcion correcta\n\n\n\n");
                        break;
                }
                Console.Clear();

            } while (opc.Equals("3") != true);
        }

        
    }
}
