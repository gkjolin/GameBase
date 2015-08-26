using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
namespace Game
{
    public class MyMonoBehaviour:MonoBehaviour
    {
        private void Test()
        {
        }

        public void Invoke(Action method,float time)
        {
            Invoke(method.Method.Name, time);
        }

        public I GetInterfaceComponent<I>() where I : class
        {
            //I i = gameObject.GetComponent(typeof(I)) as I;
            return GetComponent(typeof(I)) as I;
        }

        public static List<I> FindObjectsOfInterface<I>() where I : class
        {
            MonoBehaviour[] monoBehaviours = FindObjectsOfType<MonoBehaviour>();
            List<I> list = new List<I>();

            foreach (MonoBehaviour behaviour in monoBehaviours)
            {
                I component = behaviour.GetComponent(typeof(I)) as I;

                if (component != null)
                {
                    list.Add(component);
                }
            }
            return list;
        }
    }
}
