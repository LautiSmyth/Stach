using System;

namespace Abstracciones
{
    public interface IBackupDAL
    {
        void RealizarBackup(string rutaDestino);
        void RestaurarBackup(string rutaOrigen);
        int ObtenerCantRegistrosBitacoraNuevos(DateTime fecha);
        int ObtenerCantRegistrosCambiosNuevos(DateTime fecha);
    }
}
