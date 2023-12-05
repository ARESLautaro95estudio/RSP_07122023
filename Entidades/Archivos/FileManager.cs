using Entidades.Exceptions;
using Entidades.Interfaces;
using Entidades.Modelos;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Entidades.Files
{
    public  static class FileManager
    {
        /// <summary>
        /// Es un objeto estatico con un unico atributo.
        /// Se inicia su atributo en el 
        /// </summary>
        private static string path;
        static FileManager()
        {
            FileManager.path = Path.Combine( Environment.GetFolderPath(Environment.SpecialFolder.Desktop),"Marguery Lautaro\\");
            FileManager.ValidarExstenciaDeDirectorio();
        }
        public static void Guardar(string data, string nombraArchivo,bool append)
        {
            try 
            { 
                FileManager.path = Path.Combine(FileManager.path,nombraArchivo);
                using (StreamWriter escritor = new StreamWriter(FileManager.path,append))
                {
                    escritor.WriteLine(data);
                }
            }
            catch (Exception ex)
            {
                FileManager.Guardar(ex.Message, "logs.txt",true);
                FileManager.Guardar(ex.InnerException.Message, "logs.txt",true);
                FileManager.Guardar(ex.StackTrace, "logs.txt",true);
            }
        }
        public static bool Serializar<T>(T elemento,string nombreArchivo)
        where T : class
        {
            try 
            {
                FileManager.path = Path.Combine(FileManager.path, nombreArchivo);
                if (!(File.Exists(FileManager.path)))
                {
                    throw new FileManagerException("Leer");
                }
                FileManager.ValidarExstenciaDeDirectorio();
                string aux = JsonSerializer.Serialize(elemento);
                File.WriteAllText(FileManager.path, aux);
            }
            catch (FileManagerException FME)
            {
                FileManager.Guardar(FME.Message,"logs.txt",true);
            }
            return true;
        }
        private static void ValidarExstenciaDeDirectorio()
        {
            try
            {
                if (!(File.Exists(FileManager.path)))
                {
                    FileManager.path = Path.Combine(FileManager.path, "Marguery Lautaro\\Archivo.txt");
                }
            }
            catch (FieldAccessException FAE)
            {
                throw new FileManagerException("Leer");
            }
            catch (FileManagerException FM)
            {
                FileManager.Guardar(FM.Message, "logs.txt", true);
                FileManager.Guardar(FM.InnerException.Message, "logs.txt", true);
                FileManager.Guardar(FM.StackTrace, "logs.txt", true);
            }
            catch(Exception E) 
            {
                FileManager.Guardar(E.Message, "logs.txt", true);
                FileManager.Guardar(E.InnerException.Message, "logs.txt", true);
                FileManager.Guardar(E.StackTrace, "logs.txt", true);
            }
        }
    }
}
