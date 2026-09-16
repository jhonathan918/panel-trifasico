using System;
using System.IO;
using System.Threading;
using System.Runtime.InteropServices;

[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
struct ModuloSistema
{
    public int id;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
    public string nombre;
    public bool activo;
    public float valor;
}

class Programa
{
    static unsafe void AlternarEstado(ModuloSistema* mod)
    {
        if (mod != null)
        {
            mod->activo = !mod->activo;
        }
    }

    static void InicializarEntorno(ref ModuloSistema mod, int id, string nombre, float valor)
    {
        mod.id = id;
        mod.nombre = nombre;
        mod.activo = false;
        mod.valor = valor;
    }

    // ANIMACIÓN DE CARGA (BARRA TEXTUAL)
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

    // PANTALLA DE INICIO: Interfaz de Consola de Seguridad
    static void MostrarPantallaCargaCibernetica()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("=======================================================");
        Console.WriteLine("        INICIANDO PROTOCOLO DE CONEXIÓN LOCAL          ");
        Console.WriteLine("=======================================================");
        Console.ResetColor();
        Thread.Sleep(400);

        Console.WriteLine($" [*] Terminal ID   : TERMUX-AArch64-NODE-{(new Random()).Next(1000, 9999)}");
        Console.WriteLine($" [*] Nucleo Kernel : LINUX-ANDROID-CORE");
        Console.WriteLine($" [*] Fecha y Hora  : {DateTime.Now}");
        Thread.Sleep(300);

        // Secuencia de cargas estéticas consecutivas
        EjecutarAnimacionCarga("Mapeando direcciones de memoria RAM", 600);
        EjecutarAnimacionCarga("Estabilizando hilos en procesador CPU", 800);
        EjecutarAnimacionCarga("Verificando integridad de ficheros binarios", 500);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("\n [STATUS] Entorno local verificado y listo.");
        Console.ResetColor();
        Console.Write(" Presiona ENTER para desplegar el panel visual...");
        Console.ReadLine();
    }

    // FUNCIÓN DE ARCHIVOS: Guarda el estado actual en la memoria del dispositivo
    static void GuardarDocumentoConfig(ModuloSistema[] lista, string ruta)
    {
        try
        {
            using (StreamWriter escritor = new StreamWriter(ruta))
            {
                escritor.WriteLine("=== REPORTE DE CONFIGURACION LOCAL ===");
                escritor.WriteLine($"Fecha de guardado: {DateTime.Now}");
                escritor.WriteLine("--------------------------------------");
                foreach (var mod in lista)
                {
                    string estadoText = mod.activo ? "VERIFICADO/ACTIVO" : "INACTIVO";
                    escritor.WriteLine($"ID: {mod.id} | Componente: {mod.nombre,-30} | Estado: {estadoText} | Eficiencia: {mod.valor}%");
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\n[SISTEMA] Documento guardado con éxito en: {Path.GetFullPath(ruta)}");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"\n[ERROR] No se pudo escribir el archivo: {ex.Message}");
            Console.ResetColor();
        }
    }

    static void Main()
    {
        // Lanzar la secuencia animada de inicio antes de abrir el menú principal
        MostrarPantallaCargaCibernetica();

        string archivoConfig = "config_sistema.txt";
        ModuloSistema[] lista = new ModuloSistema[5];
        
        // CORREGIDO AQUÍ: Todas las líneas llaman exactamente a InicializarEntorno con "C"
        InicializarEntorno(ref lista[0], 1, "COMPILADOR CLANG NATIVO",         85.5f);
        InicializarEntorno(ref lista[1], 2, "OPTIMIZADOR DE HILOS CPU",       92.0f);
        InicializarEntorno(ref lista[2], 3, "GESTION DE ARCHIVOS BINARIOS",   78.3f);
        InicializarEntorno(ref lista[3], 4, "SISTEMA DE LOGS Y REPORTES",     65.0f);
        InicializarEntorno(ref lista[4], 5, "VERIFICACION DE DOCUMENTOS",     88.7f);

        bool ejecutando = true;

        while (ejecutando)
        {
            Console.Clear();

            // TITULO Y DIBUJO IMPONENTE DE ITACHI (ARTE ASCII)
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
            Console.WriteLine(@"  --- CONTROLADOR DE ARCHIVOS NATIVOS · ENTORNO TERMUX ---");
            Console.ResetColor();
            Console.WriteLine("=======================================================");

            // TABLA DE COMPONENTES INTERACTIVOS
            for (int i = 0; i < lista.Length; i++)
            {
                string estado = lista[i].activo ? "✅ ACTIVO" : "⏸️ INACTIVO";
                Console.WriteLine($"  [{lista[i].id}] {lista[i].nombre,-30} {estado}  {lista[i].valor:F1}%");
            }
            Console.WriteLine("  [6] Guardar Configuración en Documento");
            Console.WriteLine("  [0] Salir");
            Console.WriteLine("=======================================================");
            Console.Write("Escribe N° de opción: ");
            
            string entrada = Console.ReadLine();

            if (int.TryParse(entrada, out int op))
            {
                if (op == 0)
                {
                    ejecutando = false;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n[+] Cerrando el entorno de forma segura...");
                    Console.ResetColor();
                }
                else if (op >= 1 && op <= lista.Length)
                {
                    unsafe
                    {
                        fixed (ModuloSistema* ptr = &lista[op - 1])
                        {
                            AlternarEstado(ptr);
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"\n[MODIFICADO] Estado de '{lista[op - 1].nombre}' conmutado en la memoria.");
                    Console.ResetColor();
                    Console.WriteLine("Presiona ENTER para refrescar...");
                    Console.ReadLine();
                }
                else if (op == 6)
                {
                    GuardarDocumentoConfig(lista, archivoConfig);
                    Console.WriteLine("Presiona ENTER para continuar...");
                    Console.ReadLine();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n[!] Número fuera de rango. Selecciona una opción del menú.");
                    Console.ResetColor();
                    Console.ReadLine();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n[!] Entrada no válida. Coloca un número limpio.");
                Console.ResetColor();
                Console.ReadLine();
            }
        }
    }
}
