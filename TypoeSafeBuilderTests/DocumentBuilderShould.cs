using System;
using FluentAssertions;
using TypeSafeBuilder;
using Xunit;

namespace TypeSafeBuilderTests
{
    // The first two tests are commented because code does not compile
    // this is a feature. We want compile time errors when using
    // the builder in non conformat ways
    public class DocumentBuilderShould
    {
        //[Fact]
        //public void DoesNotCompileMissingMandatoryField()
        //{
        //    var document =
        //        new Document.DocumentBuilder()
        //            .SetMandatoryField1("mandatoryValue1")
        //            .Build();

        //    document.MandatoryField1.Should().Be("mandatoryValue1");
        //}

        //[Fact]
        //public void DoesNotCompileWrongOrderMandatoryFields()
        //{
        //    var document =
        //        new Document.DocumentBuilder()
        //            .SetMandatoryField2("mandatoryValue1")
        //            .SetMandatoryField1("mandatoryValue1")
        //            .Build();

        //    document.MandatoryField1.Should().Be("mandatoryValue1");
        //}

        [Fact]
        public void CreateDocumentWithMandatoryFields()
        {
            var document =
                new Document.DocumentBuilder()
                    .SetMandatoryField1("mandatoryValue1")
                    .SetMandatoryField2(0.1f)
                    .Build();

            document.MandatoryField1.Should().Be("mandatoryValue1");
            document.MandatoryField2.Should().Be(0.1f);
        }

        [Fact]
        public void CreateDocumentWithMandatoryFieldsAndOptionalField3()
        {
            var now = DateTime.Now;

            var document =
                new Document.DocumentBuilder()
                    .SetMandatoryField1("mandatoryValue1")
                    .SetMandatoryField2(0.1f)
                    .SetOptionalField3(now)
                    .Build();

            document.MandatoryField1.Should().Be("mandatoryValue1");
            document.MandatoryField2.Should().Be(0.1f);
            document.OptionalField3.Should().Be(now);
        }

        [Fact]
        public void CreateDocumentWithMandatoryFieldsAndOptionalFields3And4()
        {
            var now = DateTime.Now;

            var document =
                new Document.DocumentBuilder()
                    .SetMandatoryField1("mandatoryValue1")
                    .SetMandatoryField2(0.1f)
                    .SetOptionalField3(now)
                    .SetOptionalField4(1)
                    .Build();

            document.MandatoryField1.Should().Be("mandatoryValue1");
            document.MandatoryField2.Should().Be(0.1f);
            document.OptionalField3.Should().Be(now);
            document.OptionalField4.Should().Be(1);
        }
    }
}
