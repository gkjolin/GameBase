using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FileStreamTest
{
    public class TestType
    {
        private static Assembly a;
        public static void Test2()
        {
            Test<Data>();
        }

        public static void Test<T>()
        {
            T d = Activator.CreateInstance<T>();
            //T d = Activator.CreateInstance("Data");
            //Data d = new Data();
            Type t = d.GetType();
            //Type t = a.GetType("FileStreamTest.Data");
//             Assembly a = Assembly.LoadFrom("System.string");
//             Console.WriteLine("assembly name " + a.FullName);
            MemberInfo[] members = t.GetMembers();
            for(int i = 0;i<members.Length;i++)
            {
                MemberInfo info = members[i];
                Console.WriteLine("memberinfo name : " + info.Name);
            }
            FieldInfo[] _fields =  t.GetFields();

            for(int i = 0;i<_fields.Length;i++)
            {
                FieldInfo field = _fields[i];
                Console.WriteLine("fields name : " + field.Name);
            }

//            t.GetField("index").SetValue(d, 1232);
            //t.GetField("index").SetValue(d, 1232);
            t.GetField("index").SetValue(d, Convert.ChangeType(1232, t.GetField("index").FieldType));
            Console.WriteLine("d.index : " + (d as Data).index + "  getValue " + t.GetField("index").GetValue(d));

            t.GetMethod("GetIndex").Invoke(d, null);

            PropertyInfo[] properties = t.GetProperties();
            for(int i = 0;i<properties.Length;i++)
            {
                Console.WriteLine("property name : " + properties[i].Name);
            }
        }
        private T GetData<T>()
        {
            T t = Activator.CreateInstance<T>();
            Type _type = t.GetType();
            FieldInfo[] _fields = _type.GetFields();
            for(int i = 0;i<_fields.Length;i++)
            {
                FieldInfo _field = _fields[i];
                _field.SetValue(t, Convert.ChangeType("", _field.FieldType));
            }

            return t;
        }
    }


    public class Data
    {
        public int index;
        public string name;

        public void GetIndex()
        {
            Console.WriteLine("----------------------------------------------------getInex");
        }
    }


}

