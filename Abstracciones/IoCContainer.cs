using System;
using System.Collections.Generic;

namespace Abstracciones
{
    public static class IoCContainer
    {
        private static readonly Dictionary<Type, Func<object>> _registros = new Dictionary<Type, Func<object>>();
        private static readonly object _lock = new object();

        public static void Registrar<TInterface>(Func<object> fabrica)
        {
            lock (_lock)
            {
                _registros[typeof(TInterface)] = fabrica;
            }
        }

        public static void RegistrarSingleton<TInterface>(Func<object> fabrica)
        {
            Lazy<object> lazy = new Lazy<object>(fabrica);
            lock (_lock)
            {
                _registros[typeof(TInterface)] = () => lazy.Value;
            }
        }

        public static void RegistrarSingleton<TInterface>(TInterface instancia)
        {
            lock (_lock)
            {
                _registros[typeof(TInterface)] = () => instancia;
            }
        }

        public static TInterface Resolver<TInterface>()
        {
            Func<object> func;
            lock (_lock)
            {
                if (!_registros.TryGetValue(typeof(TInterface), out func))
                {
                    throw new InvalidOperationException("No se encontro un registro para el tipo: " + typeof(TInterface).FullName);
                }
            }
            return (TInterface)func();
        }
    }
}