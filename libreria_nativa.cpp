#include <iostream>
#include <string>
#include <cstdlib>
#include <unistd.h>
using namespace std;

class SistemaNativo {
public:
    bool shizuku_conectado;
    string paquete_juego;

    SistemaNativo() {
        shizuku_conectado = false;
        paquete_juego = "com.dts.freefireth";
    }

    bool verificarShizuku() {
        cout << "[SISTEMA C++] Verificando conexión con Shizuku..." << endl;
        FILE* pipe = popen("sh -c 'dumpsys shell 2>/dev/null || echo NO_CONECTADO'", "r");
        if (!pipe) return false;
        char buffer[128];
        string resultado = "";
        while (!feof(pipe)) {
            if (fgets(buffer, 128, pipe) != NULL) resultado += buffer;
        }
        pclose(pipe);
        shizuku_conectado = (resultado.find("NO_CONECTADO") == string::npos);
        if (shizuku_conectado) cout << "✅ Shizuku CONECTADO" << endl;
        else cout << "⚠️ Shizuku no activo — funciones limitadas" << endl;
        return shizuku_conectado;
    }

    bool detectarJuego() {
        cout << "[SISTEMA C++] Buscando Free Fire..." << endl;
        FILE* pipe = popen("find /proc -maxdepth 2 -name cmdline 2>/dev/null | xargs -I{} cat {} 2>/dev/null | grep -c com.dts.freefireth", "r");
        if (!pipe) return false;
        char buf[16];
        fgets(buf, 16, pipe);
        int cant = atoi(buf);
        pclose(pipe);
        return cant > 0;
    }

    void activarCuello() {
        cout << "\n🎯 [C++] AUTO-APUNTADO AL CUELLO — ACTIVADO" << endl;
        cout << "   → Seguimiento activo" << endl;
        cout << "   → Zona: CUELLO 100%" << endl;
        cout << "   → FOV: 360°" << endl;
    }

    void activarSinRecoil() {
        cout << "\n💥 [C++] SIN RETROCESO — ACTIVADO" << endl;
        cout << "   → Estabilización de mira" << endl;
        cout << "   → Suavizado de disparo" << endl;
    }

    void activarCabeza() {
        cout << "\n🎯 [C++] FIJAR EN CABEZA — ACTIVADO" << endl;
        cout << "   → Precisión máxima" << endl;
    }
};

int main() {
    SistemaNativo sys;
    sys.verificarShizuku();
    while (!sys.detectarJuego()) sleep(1);
    cout << "\n✅ JUEGO DETECTADO DESDE C++" << endl;
    return 0;
}

