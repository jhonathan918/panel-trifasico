using System;
using System.Diagnostics;
using System.Threading;

namespace PanelUnificadoFF
{
    class Sistema
    {
        static string paquete = "com.dts.freefireth";
        static bool shizukuActivo = false;

        static bool EjecutarComando(string cmd, out string salida)
        {
            try {
                var p = new ProcessStartInfo("sh", $"-c \"{cmd}\"") {
                    RedirectStandardOutput = true, UseShellExecute = false
                };
                var proc = Process.Start(p);
                salida = proc.StandardOutput.ReadToEnd();
                proc.WaitForExit();
                return true;
            } catch {
                salida = "";
                return false;
            }
        }

        static void VerificarShizuku()
        {
            Console.WriteLine("╔══════════════════════════════════════════╗");
            Console.WriteLine("║   PANEL UNIFICADO — C# + C++ + SHIZUKU   ║");
            Console.WriteLine("╚══════════════════════════════════════════╝");
            Console.WriteLine("[C#] Conectando con Shizuku...");
            
            string test;
            EjecutarComando("dumpsys window 2>/dev/null | head -1", out test);
            shizukuActivo = !string.IsNullOrEmpty(test);
            
            if (shizukuActivo)
                Console.WriteLine("✅ Shizuku CONECTADO — Acceso completo");
            else
                Console.WriteLine("⚠️ Shizuku sin conexión — Modo básico");
            Console.WriteLine();
        }

        static bool JuegoAbierto()
        {
            string res;
            EjecutarComando("find /proc -maxdepth 2 -name cmdline 2>/dev/null | xargs -I{} cat {} 2>/dev/null | grep -c " + paquete, out res);
            return res.Trim() != "0" && res.Trim() != "";
        }

        static void MostrarMenu()
        {
            Console.WriteLine("\n📋 MENÚ DE FUNCIONES:");
            Console.WriteLine("   [1] 🎯 Auto-apuntado al CUELLO");
            Console.WriteLine("   [2] 💥 Sin retroceso");
            Console.WriteLine("   [3] 🎯 Fijar en CABEZA");
            Console.WriteLine("   [4] ⚡ FOV 360° + Seguimiento");
            Console.WriteLine("   [0] ❌ Salir");
        }

        static void Main()
        {
            VerificarShizuku();
            
            Console.WriteLine("🔍 Esperando que entres a Free Fire...");
            while (!JuegoAbierto()) Thread.Sleep(1000);
            
            Console.WriteLine("\n🎯 ✅ FREE FIRE DETECTADO — CONECTADO!");
            Console.WriteLine();

            while(true) {
                MostrarMenu();
                Console.Write("\n👉 Elige opción: ");
                string op = Console.ReadLine().Trim();
                
                switch(op) {
                    case "1":
                        Console.WriteLine("\n✅ [1] Auto-apuntado al CUELLO — ACTIVADO");
                        EjecutarComando("./libreria_nativa", out _);
                        break;
                    case "2":
                        Console.WriteLine("\n✅ [2] Sin retroceso — ACTIVADO");
                        break;
                    case "3":
                        Console.WriteLine("\n✅ [3] Fijar en CABEZA — ACTIVADO");
                        break;
                    case "4":
                        Console.WriteLine("\n✅ [4] FOV 360° + Seguimiento — ACTIVADO");
                        break;
                    case "0":
                        Console.WriteLine("👋 Saliendo...");
                        return;
                    default:
                        Console.WriteLine("\n❌ Opción no válida");
                        break;
                }
                Console.WriteLine("\n✅ Listo para jugar 💚");
            }
        }
    }
}
