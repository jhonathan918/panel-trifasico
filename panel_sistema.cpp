#include <iostream>
#include <vector>
#include <string>
#include <fstream>
#include <iomanip>

using namespace std;

struct ModuloSistema {
    char nombre[40];
    bool activo;
    float uso_recursos;
};

void guardar_configuracion(const string& ruta, const vector<ModuloSistema>& modulos) {
    ofstream archivo(ruta, ios::binary | ios::trunc);
    if (!archivo) return;
    
    for (const auto& mod : modulos) {
        archivo.write(reinterpret_cast<const char*>(&mod), sizeof(ModuloSistema));
    }
}

void cargar_configuracion(const string& ruta, vector<ModuloSistema>& modulos) {
    ifstream archivo(ruta, ios::binary);
    if (!archivo) return;
    
    ModuloSistema mod;
    modulos.clear();
    while (archivo.read(reinterpret_cast<char*>(&mod), sizeof(ModuloSistema))) {
        modulos.push_back(mod);
    }
}

int main() {
    string archivo_datos = "datos_cpp.dat";
    system("clear");
    
    vector<ModuloSistema> modulos = {
        {"Compilador GCC Clang", false, 12.5f},
        {"Entorno Mono C#", false, 45.2f},
        {"Linter y Formateador Ruff", false, 5.0f},
        {"Gestor de Paquetes PIP", false, 18.3f},
        {"Analizador Estático Pylint", false, 22.1f}
    };

    cargar_configuracion(archivo_datos, modulos);

    cout << "=======================================================\n";
    cout << "  GESTOR DE ENTORNO EN C++ — TERMUX\n";
    cout << "=======================================================\n";
    
    for (size_t i = 0; i < modulos.size(); ++i) {
        cout << "  [" << (i + 1) << "] " << setw(30) << left << modulos[i].nombre
             << (modulos[i].activo ? "✅ ACTIVO " : "⏸️ INACTIVO")
             << "  Carga: " << fixed << setprecision(1) << modulos[i].uso_recursos << "%\n";
    }
    cout << "=======================================================\n";

    int op;
    cout << "\nSeleccione N° para alternar estado (0 para Salir): ";
    if (cin >> op && op >= 1 && op <= static_cast<int>(modulos.size())) {
        modulos[op - 1].activo = !modulos[op - 1].activo;
        guardar_configuracion(archivo_datos, modulos);
        cout << "\n✅ Cambios guardados en '" << archivo_datos << "'.\n";
    }

    return 0;
}
