using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ficheros
{
    class Program
    {
        #region EJERCICIO1
        static string GetExtension(string ruta)
        {
            string extension = Path.GetExtension(ruta);
            return extension;
        }
        static string GetFileName(string ruta)
        {
            string nombreArchivo = Path.GetFileName(ruta);
            return nombreArchivo;
        }
        static string GetFileNameWithoutExtension(string ruta)
        {
            string obtenerNombreSinExt = Path.GetFileNameWithoutExtension(ruta);
            return obtenerNombreSinExt;
        }
        static string GetDirectoryName(string ruta)
        {
            string directorio = Path.GetDirectoryName(ruta);
            return directorio;
        }
        static string GetPathRoot(string rutaAbsoluta)
        {
            string direcRaiz = Path.GetPathRoot(rutaAbsoluta);
            return direcRaiz;
        }
        static string GetFullPath(string ruta)
        {
            string rutaCompleta = Path.GetFullPath(ruta);
            return rutaCompleta;
        }
        static string CrearDirectorio()
        {
            char barra = Path.DirectorySeparatorChar;
            string ruta = $".{barra}datos{barra}datos.txt";
            if (Directory.Exists(Path.GetDirectoryName(ruta)) == false)
            {
                Directory.CreateDirectory("datos");
                File.Create(ruta).Close();
            }
            return ruta;
        }
        static string Combine(string rutaAbsoluta, string rutaRelativa)
        {
            string rutaCombinada = Path.Combine(rutaAbsoluta, rutaRelativa);
            return rutaCombinada;
        }
        static string CrearRutaAbsoluta()
        {
            char barra = Path.DirectorySeparatorChar;
            string rutaAbsoluta = $"C:{barra}datos{barra}datos.txt";
            if (Directory.Exists(Path.GetDirectoryName(rutaAbsoluta)) == false)
            {
                Directory.SetCurrentDirectory($"C:{barra}");
                Directory.CreateDirectory("datos");
            }
            File.Create(rutaAbsoluta).Close();
            return rutaAbsoluta;
        }
        static void Main()
        {
            string ruta = CrearDirectorio();
            string obtenerExtension = GetExtension(ruta);
            Console.WriteLine($"La extensión del archivo es --> {obtenerExtension}");
            string obtenerNombreFichero = GetFileName(ruta);
            Console.WriteLine($"El nombre del archivo (con su extensión) es --> {obtenerNombreFichero}");
            string obtenerNombreSinExt = GetFileNameWithoutExtension(ruta);
            Console.WriteLine($"El nombre del archivo (sin extension) es --> {obtenerNombreSinExt}");
            string obtenerDirectorio = GetDirectoryName(ruta);
            Console.WriteLine($"Nombre del directorio --> {obtenerDirectorio}");

            string rutaAbsoluta = CrearRutaAbsoluta();
            string direcRaiz = GetPathRoot(rutaAbsoluta);
            Console.WriteLine($"Directorio raíz --> {direcRaiz}");

            string rutaCombinada = Combine(rutaAbsoluta, ruta);
            Console.WriteLine("Nueva extensión --> " + Path.GetExtension(Path.ChangeExtension(ruta, ".doc")));
            Console.WriteLine($"Ruta completa --> " + Path.GetFullPath(ruta));
            Console.WriteLine($"Ruta combinada --> {rutaCombinada}");
        }
        #endregion

        #region EJERCICIO9
        struct Alumno
        {
            public string nombre;
            public string apellido;
            public int edad;

            public Alumno(string nombre, string apellido, int edad)
            {
                this.nombre = nombre;
                this.apellido = apellido;
                this.edad = edad;
            }
        }
        static FileStream IntroduceAlumno(Alumno alumno, FileStream stream)
        {
            Console.Write("1. Introduce los datos del alumno: ");
            alumno.nombre = Console.ReadLine();
            alumno.apellido = Console.ReadLine();
            alumno.edad = int.Parse(Console.ReadLine());
            StreamWriter envoltorio = new StreamWriter(stream, Encoding.UTF8);
            Console.WriteLine("Nombre;Apellido;Edad");
            envoltorio.WriteLine($"{alumno.nombre};{alumno.apellido};{alumno.edad}");
            envoltorio.Close();

            return stream;
        }

        static void BuscarAlumno(FileStream sr)
        {
            sr = new FileStream("alumnos.csv", FileMode.Open, FileAccess.Read);
            StreamReader buscarTexto = new StreamReader(sr, Encoding.UTF8);

            Console.Write("Introduce el apellido: ");
            string apellido = Console.ReadLine();

            string alumnoTxt = buscarTexto.ReadLine();

            int i = -1;
            while ((alumnoTxt = buscarTexto.ReadLine()) != null)
            {
                i++;
                if (alumnoTxt.Split(new char[] { ';' })[1] == apellido)
                    Console.WriteLine($"{alumnoTxt}");
            }
        }
        static void MostrarInformacion(FileStream sr)
        {
            sr = new FileStream("alumnos.csv", FileMode.Open, FileAccess.Read);
            StreamReader streamR = new StreamReader(sr, Encoding.UTF8);
            StringBuilder textBuilder = new StringBuilder(streamR.ReadToEnd());
            streamR.Close();
            Console.WriteLine(textBuilder);
        }
        static void Main()
        {
            Alumno alumno = new Alumno();
            FileStream stream = new FileStream("alumnos.csv", FileMode.Append, FileAccess.Write);

            IntroduceAlumno(alumno, stream);
            MostrarInformacion(stream);
            BuscarAlumno(stream);
        }
        #endregion

        #region EJERCICIO10
        static string LeerFichero(string fichero)
        {
            string texto;
            FileStream fs = new FileStream(fichero, FileMode.Open, FileAccess.Read);
            StreamReader sr = new StreamReader(fs, Encoding.UTF8);
            texto = sr.ReadToEnd();

            return texto;
        }
        static void CopiarFichero(string fichero, string texto)
        {
            FileStream fsCopia = new FileStream(fichero, FileMode.Create, FileAccess.Write); /////Copiar contenido de fichero en ficheroCopia
            StreamWriter eCopia = new StreamWriter(fsCopia, Encoding.UTF8);
            eCopia.Write(texto);
            eCopia.Close();
        }
        static string TransformaTexto(string texto)
        {
            StringBuilder transformarTexto = new StringBuilder(texto);
            transformarTexto.Replace("\t", "");
            transformarTexto.Replace("\n", "");
            transformarTexto.Replace(" ", "");

            return transformarTexto.ToString();
        }
        static void Main()
        {
            string fichero = "fichero.txt";
            string ficheroCopia = "ficheroCopia.txt";

            Console.WriteLine("Escribe lo que quieras: ");
            string texto = Console.ReadLine();

            CopiarFichero(fichero, texto);
            texto = LeerFichero(fichero);
            string textoTransformado = TransformaTexto(texto);
            CopiarFichero(ficheroCopia, textoTransformado);
        }
        #endregion
        //JEJE

        static void Main()
        {

        }
    }
}
