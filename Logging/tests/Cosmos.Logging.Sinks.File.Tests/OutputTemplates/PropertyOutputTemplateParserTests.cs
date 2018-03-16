using Cosmos.Logging.MessageTemplates;
using Cosmos.Logging.Sinks.File.OutputTemplates;
using Xunit;

namespace Cosmos.Logging.Sinks.File.Tests.OutputTemplates {
    public class PropertyOutputTemplateParserTests {
        private readonly OutputTemplateParser _parser;

        public PropertyOutputTemplateParserTests() {
            _parser = new OutputTemplateParser();
        }

        [Fact]
        public void Template_General_Test() {
            var template = "{Date} {Name}[{Level}]{EventInfo}{CallerInfo} {Message}{NewLine}";
            var outputTemplate = _parser.Parse(template);

            Assert.NotNull(outputTemplate);
            Assert.Equal(outputTemplate.Tokens.Count, 7);
            Assert.Equal(outputTemplate.Tokens[0].RawText, "{Date}");
            Assert.Equal(outputTemplate.Tokens[0].RawTokenLength, "{Date}".Length);
            Assert.Equal(outputTemplate.Tokens[0].StartPosition, 0);
            Assert.Equal(outputTemplate.Tokens[0].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[0].TokenLength, 4);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[0]).Name, "Date");

            Assert.Equal(outputTemplate.Tokens[1].RawText, "{Name}");
            Assert.Equal(outputTemplate.Tokens[1].RawTokenLength, "{Name}".Length);
            Assert.Equal(outputTemplate.Tokens[1].StartPosition, 7);
            Assert.Equal(outputTemplate.Tokens[1].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[1].TokenLength, 4);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[1]).Name, "Name");

            Assert.Equal(outputTemplate.Tokens[2].RawText, "{Level}");
            Assert.Equal(outputTemplate.Tokens[2].RawTokenLength, "{Level}".Length);
            Assert.Equal(outputTemplate.Tokens[2].StartPosition, 14);
            Assert.Equal(outputTemplate.Tokens[2].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[2].TokenLength, 5);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[2]).Name, "Level");

            Assert.Equal(outputTemplate.Tokens[3].RawText, "{EventInfo}");
            Assert.Equal(outputTemplate.Tokens[3].RawTokenLength, "{EventInfo}".Length);
            Assert.Equal(outputTemplate.Tokens[3].StartPosition, 22);
            Assert.Equal(outputTemplate.Tokens[3].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[3].TokenLength, 9);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[3]).Name, "EventInfo");

            Assert.Equal(outputTemplate.Tokens[4].RawText, "{CallerInfo}");
            Assert.Equal(outputTemplate.Tokens[4].RawTokenLength, "{CallerInfo}".Length);
            Assert.Equal(outputTemplate.Tokens[4].StartPosition, 33);
            Assert.Equal(outputTemplate.Tokens[4].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[4].TokenLength, 10);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[4]).Name, "CallerInfo");

            Assert.Equal(outputTemplate.Tokens[5].RawText, "{Message}");
            Assert.Equal(outputTemplate.Tokens[5].RawTokenLength, "{Message}".Length);
            Assert.Equal(outputTemplate.Tokens[5].StartPosition, 46);
            Assert.Equal(outputTemplate.Tokens[5].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[5].TokenLength, 7);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[5]).Name, "Message");

            Assert.Equal(outputTemplate.Tokens[6].RawText, "{NewLine}");
            Assert.Equal(outputTemplate.Tokens[6].RawTokenLength, "{NewLine}".Length);
            Assert.Equal(outputTemplate.Tokens[6].StartPosition, 55);
            Assert.Equal(outputTemplate.Tokens[6].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[6].TokenLength, 7);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[6]).Name, "NewLine");
        }

        [Fact]
        public void Template_ErrorEnd_Test() {
            var template = "{Date} {Name}[{Level}]{EventInfo}{CallerInfo} {Message}{NewLine";
            var outputTemplate = _parser.Parse(template);

            Assert.NotNull(outputTemplate);
            Assert.Equal(outputTemplate.Tokens.Count, 7);
            Assert.Equal(outputTemplate.Tokens[0].RawText, "{Date}");
            Assert.Equal(outputTemplate.Tokens[0].RawTokenLength, "{Date}".Length);
            Assert.Equal(outputTemplate.Tokens[0].StartPosition, 0);
            Assert.Equal(outputTemplate.Tokens[0].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[0].TokenLength, 4);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[0]).Name, "Date");

            Assert.Equal(outputTemplate.Tokens[1].RawText, "{Name}");
            Assert.Equal(outputTemplate.Tokens[1].RawTokenLength, "{Name}".Length);
            Assert.Equal(outputTemplate.Tokens[1].StartPosition, 7);
            Assert.Equal(outputTemplate.Tokens[1].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[1].TokenLength, 4);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[1]).Name, "Name");

            Assert.Equal(outputTemplate.Tokens[2].RawText, "{Level}");
            Assert.Equal(outputTemplate.Tokens[2].RawTokenLength, "{Level}".Length);
            Assert.Equal(outputTemplate.Tokens[2].StartPosition, 14);
            Assert.Equal(outputTemplate.Tokens[2].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[2].TokenLength, 5);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[2]).Name, "Level");

            Assert.Equal(outputTemplate.Tokens[3].RawText, "{EventInfo}");
            Assert.Equal(outputTemplate.Tokens[3].RawTokenLength, "{EventInfo}".Length);
            Assert.Equal(outputTemplate.Tokens[3].StartPosition, 22);
            Assert.Equal(outputTemplate.Tokens[3].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[3].TokenLength, 9);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[3]).Name, "EventInfo");

            Assert.Equal(outputTemplate.Tokens[4].RawText, "{CallerInfo}");
            Assert.Equal(outputTemplate.Tokens[4].RawTokenLength, "{CallerInfo}".Length);
            Assert.Equal(outputTemplate.Tokens[4].StartPosition, 33);
            Assert.Equal(outputTemplate.Tokens[4].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[4].TokenLength, 10);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[4]).Name, "CallerInfo");

            Assert.Equal(outputTemplate.Tokens[5].RawText, "{Message}");
            Assert.Equal(outputTemplate.Tokens[5].RawTokenLength, "{Message}".Length);
            Assert.Equal(outputTemplate.Tokens[5].StartPosition, 46);
            Assert.Equal(outputTemplate.Tokens[5].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[5].TokenLength, 7);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[5]).Name, "Message");

            Assert.Equal(outputTemplate.Tokens[6].RawText, "{NewLine");
            Assert.Equal(outputTemplate.Tokens[6].RawTokenLength, "{NewLine".Length);
            Assert.Equal(outputTemplate.Tokens[6].StartPosition, 55);
            Assert.Equal(outputTemplate.Tokens[6].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[6].TokenLength, 7);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[6]).Name, "NewLine");
        }

        [Fact]
        public void Template_SpaceEnd_Test() {
            var template = "{Date} {Name}[{Level}]{EventInfo}{CallerInfo} {Message}{NewLine} ";
            var outputTemplate = _parser.Parse(template);

            Assert.NotNull(outputTemplate);
            Assert.Equal(outputTemplate.Tokens.Count, 7);
            Assert.Equal(outputTemplate.Tokens[0].RawText, "{Date}");
            Assert.Equal(outputTemplate.Tokens[0].RawTokenLength, "{Date}".Length);
            Assert.Equal(outputTemplate.Tokens[0].StartPosition, 0);
            Assert.Equal(outputTemplate.Tokens[0].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[0].TokenLength, 4);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[0]).Name, "Date");

            Assert.Equal(outputTemplate.Tokens[1].RawText, "{Name}");
            Assert.Equal(outputTemplate.Tokens[1].RawTokenLength, "{Name}".Length);
            Assert.Equal(outputTemplate.Tokens[1].StartPosition, 7);
            Assert.Equal(outputTemplate.Tokens[1].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[1].TokenLength, 4);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[1]).Name, "Name");

            Assert.Equal(outputTemplate.Tokens[2].RawText, "{Level}");
            Assert.Equal(outputTemplate.Tokens[2].RawTokenLength, "{Level}".Length);
            Assert.Equal(outputTemplate.Tokens[2].StartPosition, 14);
            Assert.Equal(outputTemplate.Tokens[2].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[2].TokenLength, 5);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[2]).Name, "Level");

            Assert.Equal(outputTemplate.Tokens[3].RawText, "{EventInfo}");
            Assert.Equal(outputTemplate.Tokens[3].RawTokenLength, "{EventInfo}".Length);
            Assert.Equal(outputTemplate.Tokens[3].StartPosition, 22);
            Assert.Equal(outputTemplate.Tokens[3].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[3].TokenLength, 9);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[3]).Name, "EventInfo");

            Assert.Equal(outputTemplate.Tokens[4].RawText, "{CallerInfo}");
            Assert.Equal(outputTemplate.Tokens[4].RawTokenLength, "{CallerInfo}".Length);
            Assert.Equal(outputTemplate.Tokens[4].StartPosition, 33);
            Assert.Equal(outputTemplate.Tokens[4].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[4].TokenLength, 10);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[4]).Name, "CallerInfo");

            Assert.Equal(outputTemplate.Tokens[5].RawText, "{Message}");
            Assert.Equal(outputTemplate.Tokens[5].RawTokenLength, "{Message}".Length);
            Assert.Equal(outputTemplate.Tokens[5].StartPosition, 46);
            Assert.Equal(outputTemplate.Tokens[5].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[5].TokenLength, 7);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[5]).Name, "Message");

            Assert.Equal(outputTemplate.Tokens[6].RawText, "{NewLine}");
            Assert.Equal(outputTemplate.Tokens[6].RawTokenLength, "{NewLine}".Length);
            Assert.Equal(outputTemplate.Tokens[6].StartPosition, 55);
            Assert.Equal(outputTemplate.Tokens[6].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[6].TokenLength, 7);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[6]).Name, "NewLine");
        }

        [Fact]
        public void Template_Error_SpaceEnd_Test() {
            var template = "{Date} {Name}[{Level}]{EventInfo}{CallerInfo} {Message {NewLine ";
            var outputTemplate = _parser.Parse(template);

            Assert.NotNull(outputTemplate);
            Assert.Equal(outputTemplate.Tokens.Count, 7);
            Assert.Equal(outputTemplate.Tokens[0].RawText, "{Date}");
            Assert.Equal(outputTemplate.Tokens[0].RawTokenLength, "{Date}".Length);
            Assert.Equal(outputTemplate.Tokens[0].StartPosition, 0);
            Assert.Equal(outputTemplate.Tokens[0].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[0].TokenLength, 4);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[0]).Name, "Date");

            Assert.Equal(outputTemplate.Tokens[1].RawText, "{Name}");
            Assert.Equal(outputTemplate.Tokens[1].RawTokenLength, "{Name}".Length);
            Assert.Equal(outputTemplate.Tokens[1].StartPosition, 7);
            Assert.Equal(outputTemplate.Tokens[1].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[1].TokenLength, 4);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[1]).Name, "Name");

            Assert.Equal(outputTemplate.Tokens[2].RawText, "{Level}");
            Assert.Equal(outputTemplate.Tokens[2].RawTokenLength, "{Level}".Length);
            Assert.Equal(outputTemplate.Tokens[2].StartPosition, 14);
            Assert.Equal(outputTemplate.Tokens[2].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[2].TokenLength, 5);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[2]).Name, "Level");

            Assert.Equal(outputTemplate.Tokens[3].RawText, "{EventInfo}");
            Assert.Equal(outputTemplate.Tokens[3].RawTokenLength, "{EventInfo}".Length);
            Assert.Equal(outputTemplate.Tokens[3].StartPosition, 22);
            Assert.Equal(outputTemplate.Tokens[3].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[3].TokenLength, 9);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[3]).Name, "EventInfo");

            Assert.Equal(outputTemplate.Tokens[4].RawText, "{CallerInfo}");
            Assert.Equal(outputTemplate.Tokens[4].RawTokenLength, "{CallerInfo}".Length);
            Assert.Equal(outputTemplate.Tokens[4].StartPosition, 33);
            Assert.Equal(outputTemplate.Tokens[4].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[4].TokenLength, 10);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[4]).Name, "CallerInfo");

            Assert.Equal(outputTemplate.Tokens[5].RawText, "{Message ");
            Assert.Equal(outputTemplate.Tokens[5].RawTokenLength, "{Message ".Length);
            Assert.Equal(outputTemplate.Tokens[5].StartPosition, 46);
            Assert.Equal(outputTemplate.Tokens[5].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[5].TokenLength, 7);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[5]).Name, "Message");

            Assert.Equal(outputTemplate.Tokens[6].RawText, "{NewLine ");
            Assert.Equal(outputTemplate.Tokens[6].RawTokenLength, "{NewLine ".Length);
            Assert.Equal(outputTemplate.Tokens[6].StartPosition, 55);
            Assert.Equal(outputTemplate.Tokens[6].TokenRenderType, TokenRenderTypes.AsProperty);
            Assert.Equal(outputTemplate.Tokens[6].TokenLength, 7);
            Assert.Equal(((PropertyOutputMessageToken) outputTemplate.Tokens[6]).Name, "NewLine");
        }
    }
}