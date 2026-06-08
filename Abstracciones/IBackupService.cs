using System;

namespace Abstracciones
{
    public interface IBackupService
    {
        void RealizarBackup(string modulo, string rutaArchivo, string claveCifrado);
        void RestaurarBackup(string modulo, string rutaArchivo, string claveCifrado);
        int ObtenerCantRegistrosBitacoraNuevos(DateTime fecha);
        int ObtenerCantRegistrosCambiosNuevos(DateTime fecha);
    }
}
