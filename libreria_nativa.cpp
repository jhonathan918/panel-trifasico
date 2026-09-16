#include <iostream>
#include <cstring>

struct Modulo {
    int id;
    char nombre[40];
    bool activo;
    float carga;
};

extern "C" {
    void InicializarModulo(Modulo* mod, int id, const char* nom, float carga) {
        if (mod != nullptr) {
            mod->id = id;
            std::strncpy(mod->nombre, nom, sizeof(mod->nombre) - 1);
            mod->nombre[sizeof(mod->nombre) - 1] = '\0';
            mod->activo = false;
            mod->carga = carga;
        }
    }

    void AlternarEstado(Modulo* mod) {
        if (mod != nullptr) {
            mod->activo = !mod->activo;
        }
    }
}
