using System.Runtime.CompilerServices;
using Xunit;

namespace LucAdm.Tests
{
    public class NamedTheoryAttribute : TheoryAttribute
    {
        public NamedTheoryAttribute([CallerMemberName] string methodName = null)
        {
            DisplayName = methodName.Replace("_", " ").AddSpacesToSentence(preserveAcronyms: true);
        }
    }
}