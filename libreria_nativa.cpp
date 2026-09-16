#include <iostream>
#include <cstring>

struct ModuloSistema {
    int id;
    char nombre[50];
    bool activo;
    float valor;
};

extern "C" {
    void InicializarEntorno(ModuloSistema* mod, int id, const char* nom, float valor) {
        if (mod != nullptr) {
            mod->id = id;
            std::strncpy(mod->nombre, nom, sizeof(mod->nombre) - 1);
            mod->nombre[sizeof(mod->nombre) - 1] = '\0';
            mod->activo = false;
            mod->valor = valor;
        }
    }

    void AlternarEstado(ModuloSistema* mod) {
        if (mod != nullptr) {
            mod->activo = !mod->activo;
        }
    }
}
