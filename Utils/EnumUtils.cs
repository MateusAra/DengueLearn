using System.ComponentModel.DataAnnotations;

namespace DengueLearn.Utils
{
    public static class EnumUtils
    {
        public static string GetDisplayName(Enum enumValue)
        {
            // Obtém o tipo do enum
            var type = enumValue.GetType();
            // Obtém o nome do campo que corresponde ao valor do enum
            var memberInfo = type.GetMember(enumValue.ToString());
            // Verifica se o campo tem o atributo Display
            var attributes = memberInfo[0].GetCustomAttributes(typeof(DisplayAttribute), false);
            // Retorna o nome de exibição se o atributo Display estiver presente
            return attributes.Length > 0 ? ((DisplayAttribute)attributes[0]).Name : enumValue.ToString();
        }
    }
}
