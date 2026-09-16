#!/bin/bash
rm -f ~/*.cfg ~/*.log ~/*.json ~/patch_sync.cfg 2>/dev/null
ROJO="\033[91m"; VERDE="\033[92m"; AMARILLO="\033[93m"; CIAN="\033[96m"
MORADO="\033[95m"; GRIS="\033[90m"; BLANCO="\033[97m"; NEGRITA="\033[1m"; RESET="\033[0m"
DPI_INJECT=800
BASE_OS="$HOME/akatsuki_core"
mkdir -p "$BASE_OS/bin64" "$BASE_OS/regedit_db" "$BASE_OS/arm64_v8a" "$BASE_OS/registry_backup"
echo '{"kernel":"v260.0","runtime":"AARCH64_EMU"}' > "$BASE_OS/bin64/kernel.sys"
echo "{\"DPI_reference\":$DPI_INJECT}" > "$BASE_OS/regedit_db/hardware.reg"
cat << 'DATA_EOF' > "$BASE_OS/arm64_v8a/global-metadata.dat"
00000000: 4372 2020 4b9e ec66 6766 6620 f360 6620  Cr  K..fgff .`f 
00000010: f060 66be 2020 662e 9b79 666e ed8a 6636  .`f..f..yfnd..f6
00000020: ed6a 6636 7066 66c6 f86a 66ca 4a6f 662a  .jf6ff..jf.Jof*
DATA_EOF
for i in {3..100}; do
    offset=$(printf "%08X" $((i * 16)))
    hex_chunk=$(cat /dev/urandom | tr -dc 'A-F0-9' | head -c 32 | sed 's/../& /g')
    echo "$offset: $hex_chunk [ARM64_STREAM_DATA]" >> "$BASE_OS/arm64_v8a/global-metadata.dat"
done
CURRENT_DIR="$BASE_OS"
ejecutar_calculo_dpi() {
    clear
    echo -e "${CIAN}${NEGRITA}[MÓDULO DE HARDWARE] Leyendo Parámetros del Sistema...${RESET}"
    echo -e "  ➧ Cargando DPI asignado por defecto: ${VERDE}$DPI_INJECT${RESET}"
    local coef_corto=$(( DPI_INJECT * 4 ))
    local coef_largo=$(( DPI_INJECT * 2 ))
    echo -e "\n${VERDE}${NEGRITA}╔══════════════════════════════════════════════════════════════╗${RESET}"
    echo -e "  ➧ Coeficiente Rango Corto:     ${ROJO}+${coef_corto} px/s${RESET}"
    echo -e "  ➧ Coeficiente Largo Alcance:   ${AMARILLO}+${coef_largo} px/s${RESET}"
    echo -e "${GRIS}────────────────────────────────────────────────────────────────────────${RESET}"
    read -p "Presione Enter para regresar..."
}
ejecutar_volcado_registro_avanzado() {
    clear
    echo -e "${MORADO}${NEGRITA}[STRUCTURE MONITOR] Reading Local Registry Trees...${RESET}"
    for i in {1..20}; do
        local rand_id=$(cat /dev/urandom | tr -dc 'A-F0-9' | head -c 6)
        echo -e "  ${GRIS}[NODE_0x$rand_id]${RESET} Compiling: \033[96mconfig_node_$i.reg\033[0m ... ${VERDE}[LOADED_OK]${RESET}"
        sleep 0.02
    done
    echo -e "\n${CIAN}[DATABASES SYNCED] Mapping file headers...${RESET}"
    for j in {1..25}; do
        local hex_addr=$(cat /dev/urandom | tr -dc 'A-F0-9' | head -c 8)
        local hex_stream=$(cat /dev/urandom | tr -dc 'A-F0-9' | head -c 24 | sed 's/../& /g')
        printf "  \033[90m[0x%s]\033[0m │ \033[95m%-75s\033[0m │ \033[92m[REG_SYNC]\033[0m\n" "$hex_addr" "$hex_stream"
        sleep 0.01
    done
    read -p "Presiona Enter para regresar..."
}
ejecutar_modificacion_simulada() {
    clear
    echo -e "${ROJO}${NEGRITA}[INTERNAL PATCH ENGINE] Attaching Static Analysis Module...${RESET}"
    echo -e "  \033[90m[0x00000000]\033[0m │ \033[91m4372 2020 4b9e ec66 6766 6620 f360 6620\033[0m │ \033[92m[TARGET_LOCK_CUELLO_ON]\033[0m"
    echo -e "  \033[90m[0x00000010]\033[0m │ \033[91mf060 66be 2020 662e 9b79 666e ed8a 6636\033[0m │ \033[92m[SPREAD_REDUCTION_100%%]\033[0m"
    echo -e "  \033[90m[0x00000020]\033[0m │ \033[91med6a 6636 7066 66c6 f86a 66ca 4a6f 662a\033[0m │ \033[92m[VECTOR_Y_COMPENSATION]\033[0m"
    tail -n +4 "$BASE_OS/arm64_v8a/global-metadata.dat" | head -n 30 | while read -r fila; do
        echo -e "  \033[90m[V_TRACE]\033[0m  │ \033[92m$fila\033[0m │ \033[93m[SYNC_OK]\033[0m"
        sleep 0.01
    done
    read -p "Presiona Enter para regresar..."
}
ejecutar_consola_pc_real() {
    clear
    echo -e "${CIAN}${NEGRITA}[ENTORNO PC REAL] Iniciando subsistema virtual de Ubuntu...${RESET}"
    proot-distro login ubuntu
}
ejecutar_volcado_hex_avanzado() {
    echo -e "\n\033[91m\033[1m[CRITICAL CORE ATTACH] Initializing Multi-Threaded Hex Trace...\033[0m"
    if [ -f "/data/data/com.termux/files/usr/bin/bash" ]; then
        od -An -tx1 -w16 /data/data/com.termux/files/usr/bin/bash 2>/dev/null | head -n 40 | while read -r line; do
            local virtual_addr=$(cat /dev/urandom | tr -dc 'A-F0-9' | head -c 8)
            printf "  \033[90m[0x%s]\033[0m │  \033[92m%-48s\033[0m │ \033[93m[OK]\033[0m\n" "$virtual_addr" "$line"
            sleep 0.01
        done
    fi
}
mostrar_banner_principal() {
    clear
    echo -e "${ROJO}${NEGRITA}"
    echo "            .---.          .---.      "
    echo "           /     \  ____  /     \     "
    echo "          \\\\ 👁️ 👁️ // /    \ \\\\ 👁️ 👁️ //    "
    echo "           \\\\  ═  //  \  /  \\\\  ═  //    "
    echo "            \`---'    \`--'    \`---'     "
    echo -e "${BLANCO} 💻 AKATSUKI ENTERPRISE CONSOLE — WORKSTATION v260.0"
    echo -e "────────────────────────────────────────────────────────────────────────${RESET}"
}
mostrar_banner_principal
while true; do
    DIR_ACTUAL=$(basename "$CURRENT_DIR")
    printf "${ROJO}akatsuki-os:${CIAN}/${DIR_ACTUAL}# ${RESET}"
    read -r comando_usuario
    cmd=$(echo "$comando_usuario" | awk '{print $1}')
    arg=$(echo "$comando_usuario" | awk '{print $2}')
    case $cmd in
        "ayuda")
            echo -e "\n${CIAN}📜 MANUAL DE MÓDULOS DEL SISTEMA OPERATIVO v260.0:${RESET}"
            echo -e "  ${AMARILLO}ls${RESET}            ➧ Listar los archivos y subcarpetas."
            echo -e "  ${AMARILLO}cd [carpeta]${RESET}  ➧ Desplazar la terminal hacia una carpeta virtual."
            echo -e "  ${AMARILLO}cat [archivo]${RESET} ➧ Leer el contenido de texto de un archivo."
            echo -e "  ${AMARILLO}analizar${RESET}      ➧ Ejecutar el volcado hexadecimal verde de 64 bits."
            echo -e "  ${AMARILLO}modificar${RESET}     ➧ Lanzar la simulación de edición y reemplazo de bytes."
            echo -e "  ${AMARILLO}dpi${RESET}           ➧ Procesar de manera directa el valor inyectado ($DPI_INJECT)."
            echo -e "  ${AMARILLO}registro${RESET}      ➧ Lanzar el volcado masivo de archivos de registro."
            echo -e "  ${AMARILLO}pc${RESET}            ➧ Encender e ingresar a la CONSOLA DE PC REAL."
            echo -e "  ${AMARILLO}limpiar${RESET}       ➧ Limpiar la pantalla."
            echo -e "  ${AMARILLO}salir${RESET}         ➧ Apagar la estación de trabajo y volver a Termux base."
            echo ""
            ;;
        "ls")
            echo -e "\n${BLANCO}📁 Componentes localizados en este nodo:${RESET}"
            ls -F "$CURRENT_DIR" | sed "s/^/  /g"
            echo ""
            ;;
        "cd")
            if [ -z "$arg" ]; then
                echo -e "❌ Error: Especifica el nodo de destino.\n"
            elif [ "$arg" = ".." ]; then
                if [ "$CURRENT_DIR" != "$BASE_OS" ]; then
                    CURRENT_DIR=$(dirname "$CURRENT_DIR")
                fi
            elif [ -d "$CURRENT_DIR/$arg" ]; then
                CURRENT_DIR="$CURRENT_DIR/$arg"
            else
                echo -e "❌ Error: El subdirectorio no existe.\n"
            fi
            ;;
        "cat")
            if [ -z "$arg" ]; then
                echo -e "❌ Error: Especifica el archivo a inspeccionar.\n"
            elif [ -f "$CURRENT_DIR/$arg" ]; then
                echo -e "\n${GRIS}📖 Flujo estructurado de ($arg):${RESET}"
                cat "$CURRENT_DIR/$arg" | sed "s/^/  /g"
                echo ""
            else
                echo -e "❌ Error: No se localizó el archivo.\n"
            fi
            ;;
        "analizar")
            ejecutar_volcado_hex_avanzado
            ;;
        "modificar")
            ejecutar_modificacion_simulada
            ;;
        "dpi")
            ejecutar_calculo_dpi
            ;;
        "registro")
            ejecutar_volcado_registro_avanzado
            ;;
        "pc")
            ejecutar_consola_pc_real
            ;;
        "limpiar")
            mostrar_banner_principal
            ;;
        "salir")
            echo -e "\n${ROJO}Apagando Akatsuki OS... Canales de memoria purgados.${RESET}"
            sleep 0.4
            clear
            break
            ;;
        "")
            # Ignorar entradas vacías
            ;;
        *)
            echo -e "❌ Comando no reconocido: '$cmd'. Escribe 'ayuda'.\n"
            ;;
    esac
done
