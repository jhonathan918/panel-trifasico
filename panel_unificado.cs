using System;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

class Programa
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct ModuloSistema
    {
        public int id;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
        public string nombre;
        [MarshalAs(UnmanagedType.I1)]
        public bool activo;
        public float valor;
    }

    [DllImport("./libnativa.so", EntryPoint = "InicializarEntorno")]
    public static extern void InicializarEntorno(ref ModuloSistema mod, int id, string nom, float valor);

    [DllImport("./libnativa.so", EntryPoint = "AlternarEstado")]
    public static extern void AlternarEstado(ref ModuloSistema mod);

    static void EjecutarAnimacionCarga(string proceso, int milisegundos)
    {
        Console.Write($"\n [>] {proceso}: [");
        for (int i = 0; i <= 20; i++)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("█");
            Thread.Sleep(milisegundos / 20);
        }
        Console.ResetColor();
        Console.WriteLine("] 100% [COMPLETO]");
    }

    static void Main()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=======================================================");
        Console.WriteLine("        INICIANDO PROTOCOLO DE CONEXIÓN LOCAL          ");
        Console.WriteLine("=======================================================");
        Console.ResetColor();
        Thread.Sleep(300);

        EjecutarAnimacionCarga("Mapeando direcciones de memoria RAM", 400);
        EjecutarAnimacionCarga("Estabilizando hilos en procesador CPU", 400);
        
        ModuloSistema[] lista = new ModuloSistema[5];
        InicializarEntorno(ref lista[0], 1, "COMPILADOR CLANG NATIVO",         85.5f);
        InicializarEntorno(ref lista[1], 2, "OPTIMIZADOR DE HILOS CPU",       92.0f);
        InicializarEntorno(ref lista[2], 3, "GESTION DE ARCHIVOS BINARIOS",   78.3f);
        InicializarEntorno(ref lista[3], 4, "SISTEMA DE LOGS Y REPORTES",     65.0f);
        InicializarEntorno(ref lista[4], 5, "VERIFICACION DE DOCUMENTOS",     88.7f);

        bool ejecutando = true;
        while (ejecutando)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(@"    ____  ___    _   __________     ___________ ");
            Console.WriteLine(@"   / __ \/   |  / | / / ____/ /    / ____/ ____| ");
            Console.WriteLine(@"  / /_/ / /| | /  |/ / __/ / /    / /_  / /_     ");
            Console.WriteLine(@" / ____/ ___ |/ /|  / /___/ /____/ __/ / __/     ");
            Console.WriteLine(@"/_/   /_/  |_/_/ |_/_____/_____/_/   /_/         ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(@"             _______          ______             ");
            Console.WriteLine(@"            /  ____ \        / ____  \           ");
            Console.WriteLine(@"           /  /    \ \      / /    \  \          ");
            Console.WriteLine(@"          |  |  O   | |    | |   O  |  |         ");
            Console.WriteLine(@"           \  \____/ /      \ \____/  /          ");
            Console.WriteLine(@"            \_______/        \_______/           ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.WriteLine(@"  --- CONTROLADOR EN MEMORIA RAM · ENTORNO TERMUX ---");
            Console.ResetColor();
            Console.WriteLine("=======================================================");

            for (int i = 0; i < lista.Length; i++) {
                string estado = lista[i].activo ? "✅ ACTIVO " : "⏸️ INACTIVO";
                Console.WriteLine($"  [{lista[i].id}] {lista[i].nombre,-30} {estado} ({lista[i].valor}%)");
            }
            Console.WriteLine("=======================================================");
            Console.Write("Escribe N° de opción (0=Salir): ");
            
            string entrada = Console.ReadLine();
            if (int.TryParse(entrada, out int op)) {
                if (op == 0) ejecutando = false;
                else if (op >= 1 && op <= lista.Length) {
                    AlternarEstado(ref lista[op - 1]);
                }
            }
        }
    }
}
