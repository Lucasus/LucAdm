using System.Runtime.CompilerServices;
using Xunit;

namespace LucAdm.Tests
{
    public sealed class NamedTheoryAttribute : TheoryAttribute
    {
        public NamedTheoryAttribute([CallerMemberName] string methodName = null)
        {
            DisplayName = methodName.Replace('_', '\u00A0').AddSpacesToSentence(preserveAcronyms: true, delimiter: '\u00A0');
        }
    }
}