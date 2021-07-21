using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Stealer
{
    public class Spy
    {
        public string StealFieldInfo(string name, params string[] fieldsToFind) 
        {
            Type type = Type.GetType(name);
            FieldInfo[] allFields = type.GetFields(BindingFlags.Public|BindingFlags.Instance|BindingFlags.NonPublic|BindingFlags.Static);
            StringBuilder text = new StringBuilder();

            object classInstance = Activator.CreateInstance(type, new object[] { });
            foreach (var field in allFields.Where(x => fieldsToFind.Contains(x.Name)))
            {
                text.AppendLine($"{field.Name} = {field.GetValue(classInstance)}");
            }
            Console.WriteLine($"Class under investigation: {name}");
            return text.ToString().Trim();
        }
        public string AnalyzeAccessModifiers(string className) 
        {
            Type type = Type.GetType("Stealer." + className);
            FieldInfo[] allFields = type.GetFields(BindingFlags.Public 
                | BindingFlags.Instance 
                | BindingFlags.Static);

            StringBuilder text = new StringBuilder();
            foreach (var field in allFields)
            {
                text.AppendLine($"{field.Name} must be private!");
            }
            MethodInfo[] publicMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.Public);
            foreach (var property in publicMethods.Where(x => x.Name.StartsWith("set")))
            {
                Console.WriteLine($"{property.Name} have to be public!");
            }
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var property in privateMethods.Where(x => x.Name.StartsWith("get")))
            {
                Console.WriteLine($"{property.Name} have to be private!");
            }
            return text.ToString().Trim();
        }
        public string RevealPrivateMethods(string className) 
        {
            Type type = Type.GetType(className);
            Console.WriteLine($"All Private Methods of Class: {className}");
            Console.WriteLine($"Base Class: {type.BaseType.Name}");
            MethodInfo[] privateMethods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic);
            StringBuilder text = new StringBuilder();
            foreach (var methods in privateMethods)
            {
                text.AppendLine(methods.Name);
            }
            return text.ToString().Trim();
        }
        public string CollectGettersAndSetters(string className) 
        {
            Type type = Type.GetType(className);
            MethodInfo[] Methods = type.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic|BindingFlags.Public);
            StringBuilder text = new StringBuilder();
            foreach (var item in Methods.Where(x => x.Name.StartsWith("get")))
            {
                text.AppendLine($"{item.Name} will return {item.ReturnType}");
            }
            foreach (var item in Methods.Where(x => x.Name.StartsWith("set")))
            {
                text.AppendLine($"{item.Name} will return {item.GetParameters().First().ParameterType}");
            }
            return text.ToString().Trim();
        }
    }
}
