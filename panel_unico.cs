using System;
using System.Runtime.InteropServices;

// Estructura de datos optimizada con alineación de memoria fija (Estilo C)
[StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
struct ModuloSistema {
    public int id;
    [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 50)]
    public string nombre;
    public bool activo;
    public float cargaCPU;
}

class Program {
    // 1. LÓGICA ESTILO LENGUAJE C: Manipulación directa de memoria por punteros
    // Requiere activar el modo 'unsafe' en el compilador
    static unsafe void AlternarEstadoPuntero(ModuloSistema* mod) {
        if (mod != null) {
            mod->activo = !mod->activo;
        }
    }

    // 2. LÓGICA ESTILO C++: Estructuración modular orientada a objetos nativa
    static void InicializarEntorno(ref ModuloSistema mod, int id, string nombre, float carga) {
        mod.id = id;
        mod.nombre = nombre;
        mod.activo = false;
        mod.cargaCPU = carga;
    }

    // 3. LÓGICA DE CONTROL EN C#: Gestión de arreglos y flujo de consola principal
    static void Main() {
        Console.Clear();

        // Crear el arreglo de estructuras en memoria
        ModuloSistema[] lista = new ModuloSistema[3];
        
        // Inicialización de los tres sub-entornos de desarrollo
        InicializarEntorno(ref lista[0], 1, "Nucleo de Rendimiento en C", 14.2f);
        InicializarEntorno(ref lista[1], 2, "Procesamiento de Graficos (C++)", 38.5f);
        InicializarEntorno(ref lista[2], 3, "Controlador de Interfaz (C#)", 8.0f);

        // =========================================================================
        //  TITULO Y DIBUJO EN ARTE ASCII (ESTILO ITACHI SHARINGAN)
        // =========================================================================
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
        Console.WriteLine(@"     --- SHARINGAN UNIFICADO CON CONSOLE-RAM ---");
        Console.ResetColor();
        Console.WriteLine("=======================================================");

        // Bucle de renderizado de la interfaz gráfica textual
        for (int i = 0; i < lista.Length; i++) {
            string estado = lista[i].activo ? "✅ ACTIVO " : "⏸️ INACTIVO";
            Console.WriteLine($"  [{lista[i].id}] {lista[i].nombre,-35} {estado} ({lista[i].cargaCPU}%)");
        }
        Console.WriteLine("  [4] ACTIVAR LOS 3 ENTORNOS EN SIMULTANEO");
        Console.WriteLine("=======================================================");

        Console.Write("\nEscribe el N° de opcion (0=Salir): ");
        if (int.TryParse(Console.ReadLine(), out int op)) {
            // Modificación individual usando punteros directos (Lógica C)
            if (op >= 1 && op <= lista.Length) {
                unsafe {
                    fixed (ModuloSistema* ptr = &lista[op - 1]) {
                        AlternarEstadoPuntero(ptr);
                    }
                }
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"\n[OK] Estado del entorno {op} modificado directamente en la RAM.");
                Console.ResetColor();
            }
            // Activación masiva trifásica en un solo ciclo
            else if (op == 4) {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine(">>> Ejecutando conmutacion masiva por mapeo de memoria...\n");
                
                unsafe {
                    for (int i = 0; i < lista.Length; i++) {
                        if (!lista[i].activo) {
                            fixed (ModuloSistema* ptr = &lista[i]) {
                                AlternarEstadoPuntero(ptr);
                            }
                        }
                    }
                }
                Console.ResetColor();

                Console.WriteLine("=======================================================");
                for (int i = 0; i < lista.Length; i++) {
                    string estado = lista[i].activo ? "✅ ACTIVO " : "⏸️ INACTIVO";
                    Console.WriteLine($"  [{lista[i].id}] {lista[i].nombre,-35} {estado}");
                }
                Console.WriteLine("=======================================================");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n[EXITO] Los 3 sistemas estan operando juntos de verdad.");
                Console.ResetColor();
            }
        }
        Console.WriteLine("\nSesion de consola finalizada.");
    }
}
