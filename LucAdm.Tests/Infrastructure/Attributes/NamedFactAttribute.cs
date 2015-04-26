using System.Runtime.CompilerServices;
using System.Text;
using Xunit;

namespace LucAdm.Tests
{
    public class NamedFactAttribute : FactAttribute
    {
        public NamedFactAttribute([CallerMemberName] string propertyName = null)
        {
            DisplayName = AddSpacesToSentence(propertyName.Replace("_", " "), preserveAcronyms: true);
        }

        // Method based on this SO answer: http://stackoverflow.com/questions/272633/add-spaces-before-capital-letters
        private string AddSpacesToSentence(string text, bool preserveAcronyms)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;
            StringBuilder newText = new StringBuilder(text.Length * 2);
            newText.Append(text[0]);
            for (int i = 1; i < text.Length; i++)
            {
                if (char.IsUpper(text[i]))
                    if ((text[i - 1] != ' ' && !char.IsUpper(text[i - 1])) ||
                        (preserveAcronyms && char.IsUpper(text[i - 1]) &&
                         i < text.Length - 1 && !char.IsUpper(text[i + 1])))
                        newText.Append(' ');
                newText.Append(text[i]);
            }
            return newText.ToString();
        }
    }
}