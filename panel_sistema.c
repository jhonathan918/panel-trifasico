#include <stdio.h>
#include <stdlib.h>
#include <string.h>

// Estructura fija para compatibilidad con archivos binarios
typedef struct {
    int id;
    char nombre[40];
    int activo;
    float carga;
} Modulo;

void guardar_estado(const char *ruta, Modulo *lista, int total) {
    FILE *archivo = fopen(ruta, "wb");
    if (archivo != NULL) {
        fwrite(lista, sizeof(Modulo), total, archivo);
        fclose(archivo);
    }
}

void cargar_estado(const char *ruta, Modulo *lista, int total) {
    FILE *archivo = fopen(ruta, "rb");
    if (archivo != NULL) {
        fread(lista, sizeof(Modulo), total, archivo);
        fclose(archivo);
    }
}

int main() {
    const char *archivo_datos = "datos_c.dat";
    system("clear");
    
    // Lista de módulos base
    Modulo lista[] = {
        {1, "Compilador GCC Clang", 0, 12.5f},
        {2, "Entorno Mono C#", 0, 45.2f},
        {3, "Linter y Formateador Ruff", 0, 5.0f},
        {4, "Gestor de Paquetes PIP", 0, 18.3f},
        {5, "Analizador Estático Pylint", 0, 22.1f}
    };
    
    int total = sizeof(lista) / sizeof(lista[0]);
    cargar_estado(archivo_datos, lista, total);

    printf("=======================================================\n");
    printf("  GESTOR DE ENTORNO EN C — TERMUX AArch64\n");
    printf("=======================================================\n");
    
    for(int i = 0; i < total; i++) {
        printf("  [%d] %-30s %s  (%.1f%%)\n",
            lista[i].id, lista[i].nombre,
            lista[i].activo ? "✅ ACTIVO " : "⏸️ INACTIVO",
            lista[i].carga);
    }
    printf("=======================================================\n");

    int op;
    printf("\nSelecciona N° para alternar estado (0=Salir): ");
    if(scanf("%d", &op) == 1 && op >= 1 && op <= total) {
        lista[op-1].activo = !lista[op-1].activo;
        guardar_estado(archivo_datos, lista, total);
        printf("\n✅ Cambios guardados en '%s'.\n", archivo_datos);
    }
    
    return 0;
}
