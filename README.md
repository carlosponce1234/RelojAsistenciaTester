# RelojAsistenciaTester

Ajusta la configuración según la topología de red y el modelo de lector.

## Uso
- Modifica la configuración en el archivo donde `Program.cs` carga parámetros (o pasa argumentos).
- Ejecuta y observa la consola para resultados de conexión, logs y posibles errores.
- Para pruebas de integración, conectar primero con ping/handshake y luego solicitar lectura de eventos.

## Solución de problemas
- Si no hay respuesta: comprobar dirección IP, máscara, puerta de enlace y firewall.
- Para conexión serie: verificar `COM` correcto, baudrate y permisos de acceso.
- Algunos modelos requieren bibliotecas nativas del fabricante; colócalas en el mismo directorio de salida o registra su ruta.
- Habilita logs detallados en `Program.cs` si necesitas traza de paquetes.

## Contribuir
- Abrir issue o pull request en el repositorio.
- Mantener estilo C# y compatibilidad con .NET 10.
