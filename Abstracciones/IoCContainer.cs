using System;
using System.Collections.Generic;

namespace Abstracciones
{
    public static class IoCContainer
    {
        private static readonly Dictionary<Type, Func<object>> _registros = new Dictionary<Type, Func<object>>();

        public static void Registrar<TInterface>(Func<object> fabrica)
        {
            _registros[typeof(TInterface)] = fabrica;
        }

        public static void RegistrarSingleton<TInterface>(Func<object> fabrica)
        {
            Lazy<object> lazy = new Lazy<object>(fabrica);
            _registros[typeof(TInterface)] = () => lazy.Value;
        }

        public static void RegistrarSingleton<TInterface>(TInterface instancia)
        {
            _registros[typeof(TInterface)] = () => instancia;
        }

        public static TInterface Resolver<TInterface>()
        {
            if (_registros.TryGetValue(typeof(TInterface), out Func<object> func))
            {
                return (TInterface)func();
            }
            throw new InvalidOperationException("No se encontro un registro para el tipo: " + typeof(TInterface).FullName);
        }
    }
}
