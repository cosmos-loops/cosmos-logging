using Cosmos.Logging.MessageTemplates;
using Cosmos.Logging.Sinks.File.OutputTemplates;
using Xunit;

namespace Cosmos.Logging.Sinks.File.Tests.OutputTemplates {
    public class TextOutputTemplateTests {
        private readonly OutputTemplateParser _parser;

        public TextOutputTemplateTests() {
            _parser = new OutputTemplateParser();
        }

        [Fact]
        public void Template_Text_Test() {
            var template = "{} {Date}";
            var outputTemplate = _parser.Parse(template);

            Assert.NotNull(outputTemplate);
            Assert.Equal(outputTemplate.Tokens.Count, 2);

            Assert.Equal(outputTemplate.Tokens[0].RawText, "{}");
            Assert.Equal(outputTemplate.Tokens[0].RawTokenLength, "{}".Length);
            Assert.Equal(outputTemplate.Tokens[0].StartPosition, 0);
            Assert.Equal(outputTemplate.Tokens[0].TokenRenderType, TokenRenderTypes.AsText);
            Assert.Equal(outputTemplate.Tokens[0].TokenLength, 2);
            Assert.Equal(((TextOutputMessageToken) outputTemplate.Tokens[0]).ToText(), "{}");


            Assert.Equal(outputTemplate.Tokens[1].RawText, "{Date}");
            Assert.Equal(outputTemplate.Tokens[1].RawTokenLength, "{Date}".Length);
            Assert.Equal(outputTemplate.Tokens[1].StartPosition, 3);
            Assert.Equal(outputTemplate.Tokens[1].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[1].TokenLength, 4);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[1]).Name, "Date");
        }

        [Fact]
        public void Template_Error_Test() {
            var template = "{ {Date}";
            var outputTemplate = _parser.Parse(template);

            Assert.NotNull(outputTemplate);
            Assert.Equal(outputTemplate.Tokens.Count, 2);

            Assert.Equal(outputTemplate.Tokens[0].RawText, "{ ");
            Assert.Equal(outputTemplate.Tokens[0].RawTokenLength, "{ ".Length);
            Assert.Equal(outputTemplate.Tokens[0].StartPosition, 0);
            Assert.Equal(outputTemplate.Tokens[0].TokenRenderType, TokenRenderTypes.AsText);
            Assert.Equal(outputTemplate.Tokens[0].TokenLength, 2);
            Assert.Equal(((TextOutputMessageToken) outputTemplate.Tokens[0]).ToText(), "{ ");


            Assert.Equal(outputTemplate.Tokens[1].RawText, "{Date}");
            Assert.Equal(outputTemplate.Tokens[1].RawTokenLength, "{Date}".Length);
            Assert.Equal(outputTemplate.Tokens[1].StartPosition, 2);
            Assert.Equal(outputTemplate.Tokens[1].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[1].TokenLength, 4);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[1]).Name, "Date");
        }
    }
}