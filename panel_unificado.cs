using System;
using System.Runtime.InteropServices;

class Program {
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Ansi)]
    public struct Modulo {
        public int id;
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 40)]
        public string nombre;
        [MarshalAs(UnmanagedType.I1)]
        public bool activo;
        public float carga;
    }

    [DllImport("./libnativa.so", EntryPoint = "InicializarModulo")]
    public static extern void InicializarModulo(ref Modulo mod, int id, string nom, float carga);

    [DllImport("./libnativa.so", EntryPoint = "AlternarEstado")]
    public static extern void AlternarEstado(ref Modulo mod);

    static void Main() {
        Console.Clear();
        
        Modulo[] lista = new Modulo[3];
        
        InicializarModulo(ref lista[0], 1, "Compilador GCC Clang (C)", 12.5f);
        InicializarModulo(ref lista[1], 2, "Entorno Mono (C#)", 45.2f);
        InicializarModulo(ref lista[2], 3, "Linter Ruff (C++)", 5.0f);

        Console.WriteLine("=======================================================");
        Console.WriteLine("  SISTEMA TRIFÁSICO UNIFICADO: C + C++ + C# ");
        Console.WriteLine("=======================================================");

        for (int i = 0; i < lista.Length; i++) {
            string estado = lista[i].activo ? "✅ ACTIVO " : "⏸️ INACTIVO";
            Console.WriteLine($"  [{lista[i].id}] {lista[i].nombre,-30} {estado} ({lista[i].carga}%)");
        }
        Console.WriteLine("  [4] ACTIVAR LOS 3 AL MISMO TIEMPO");
        Console.WriteLine("=======================================================");

        Console.Write("\nSelecciona una opcion (0=Salir): ");
        if (int.TryParse(Console.ReadLine(), out int op)) {
            if (op >= 1 && op <= lista.Length) {
                // Alternar solo el elegido
                AlternarEstado(ref lista[op - 1]);
                string nuevoEstado = lista[op - 1].activo ? "ACTIVADO" : "DESACTIVADO";
                Console.WriteLine($"\n El modulo '{lista[op - 1].nombre}' fue {nuevoEstado} por C++.");
            }
            else if (op == 4) {
                // Bucle optimizado para activar los 3 en fila pasando el control a C/C++
                Console.Clear();
                Console.WriteLine(">>> Procesando activacion masiva en memoria...");
                for (int i = 0; i < lista.Length; i++) {
                    if (!lista[i].activo) {
                        AlternarEstado(ref lista[i]);
                    }
                }
                
                Console.WriteLine("\n=======================================================");
                for (int i = 0; i < lista.Length; i++) {
                    string estado = lista[i].activo ? "✅ ACTIVO " : "⏸️ INACTIVO";
                    Console.WriteLine($"  [{lista[i].id}] {lista[i].nombre,-30} {estado}");
                }
                Console.WriteLine("=======================================================");
                Console.WriteLine("\n✅ Los 3 entornos se han encendido correctamente en simultaneo.");
            }
        }
    }
}
