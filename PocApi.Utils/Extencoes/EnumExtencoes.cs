using System;
using System.ComponentModel;
using System.Reflection;

namespace PocApi.Utils.Extencoes
{
    public static class EnumExtencoes
    {
        public static string ObterDescricao(this Enum Enumerador)
        {
            FieldInfo fieldInfo = Enumerador.GetType().GetField(Enumerador.ToString());

            if (fieldInfo == null)
                return string.Empty;

            DescriptionAttribute[] attributes =
                (DescriptionAttribute[])fieldInfo.GetCustomAttributes(
                typeof(DescriptionAttribute),
                false);

            if (attributes != null &&
                attributes.Length > 0)
                return attributes[0].Description;
            else
                return Enumerador.ToString();
        }

        public static T ObterValorPorDescricao<T>(this string description) where T : Enum
        {
            foreach (var field in typeof(T).GetFields())
            {
                if (Attribute.GetCustomAttribute(field,
                typeof(DescriptionAttribute)) is DescriptionAttribute attribute)
                {
                    if (attribute.Description == description)
                        return (T)field.GetValue(null);
                }
                else
                {
                    if (field.Name == description)
                        return (T)field.GetValue(null);
                }
            }

            throw new ArgumentException("Not found.", nameof(description));
            // Or return default(T);
        }
    }
}