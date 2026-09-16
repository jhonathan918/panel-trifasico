using System;
using System.IO;
using System.Collections.Generic;

class Modulo {
    public string Nombre { get; set; }
    public bool Activo { get; set; }
    public float Carga { get; set; }

    public Modulo(string n, float c) {
        Nombre = n; Carga = c; Activo = false;
    }
}

class Program {
    static string rutaArchivo = "datos_cs.txt";

    static void Main() {
        Console.Clear();
        var modulos = new List<Modulo> {
            new Modulo("Compilador GCC Clang", 12.5f),
            new Modulo("Entorno Mono C#", 45.2f),
            new Modulo("Linter y Formateador Ruff", 5.0f),
            new Modulo("Gestor de Paquetes PIP", 18.3f),
            new Modulo("Analizador Estático Pylint", 22.1f)
        };

        if (File.Exists(rutaArchivo)) {
            string[] lineas = File.ReadAllLines(rutaArchivo);
            for (int i = 0; i < modulos.Count && i < lineas.Length; i++) {
                if (bool.TryParse(lineas[i], out bool estado)) {
                    modulos[i].Activo = estado;
                }
            }
        }

        Console.WriteLine("=======================================================");
        Console.WriteLine("  GESTOR DE ENTORNO EN C# — MONO");
        Console.WriteLine("=======================================================");
        
        for (int i = 0; i < modulos.Count; i++) {
            Console.WriteLine($"  [{i + 1}] {modulos[i].Nombre,-30} {(modulos[i].Activo ? "✅ ACTIVO " : "⏸️ INACTIVO")}  Carga: {modulos[i].Carga:F1}%");
        }
        Console.WriteLine("=======================================================");

        Console.Write("\nSelecciona N° para cambiar estado (0=Salir): ");
        string entrada = Console.ReadLine();
        if (int.TryParse(entrada, out int op) && op >= 1 && op <= modulos.Count) {
            modulos[op - 1].Activo = !modulos[op - 1].Activa;

            List<string> estados = new List<string>();
            foreach (var mod in modulos) {
                estados.Add(mod.Activo.ToString());
            }
            File.WriteAllLines(rutaArchivo, estados);
            Console.WriteLine($"\n✅ Cambios guardados en '{rutaArchivo}'.");
        }
    }
}
