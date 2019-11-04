using System;
using System.Reflection;

namespace SMTRPZ.Lab2
{
    public abstract class Singleton<TSingleton> where TSingleton : Singleton<TSingleton>
    {
        private static TSingleton _instance;

        protected Singleton()
        { }

        private static TSingleton CreateInstance()
        {
            ConstructorInfo cInfo = typeof(TSingleton).GetConstructor(
                BindingFlags.Instance | BindingFlags.NonPublic,
                null,
                new Type[0],
                new ParameterModifier[0]);

            return (TSingleton)cInfo.Invoke(null);
        }

        public static TSingleton Instance => _instance ?? (_instance = CreateInstance());
    }
}
