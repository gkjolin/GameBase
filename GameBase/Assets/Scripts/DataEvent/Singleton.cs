using System;

namespace Game
{
    public class Singleton<T> where T : new()
    {
        private static T m_instance;
        protected Singleton() { }

        public static T Instance
        {
            get
            {
                if (m_instance == null)
                    m_instance = Activator.CreateInstance<T>();
                return m_instance;
            }
        }
    }

    /*public class Singleton<T> where T : class, new()
    {
        // Fields
        private static T _instance;

        // Methods
        public static T Instance()
        {
            if (Singleton<T>._instance == null)
            {
                Singleton<T>._instance = Activator.CreateInstance<T>();
                if (Singleton<T>._instance == null)
                {
                    GameInput.Log("Failed to create the instance of " + typeof(T) + " as singleton!");
                }
            }
            return Singleton<T>._instance;
        }

        public static void Release()
        {
            if (Singleton<T>._instance != null)
            {
                Singleton<T>._instance = null;
            }
        }
    }*/


}

