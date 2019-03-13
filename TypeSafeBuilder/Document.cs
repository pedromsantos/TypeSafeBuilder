using System;

namespace TypeSafeBuilder
{
    public class Document
    {
        public string MandatoryField1 { get; private set; }
        public float MandatoryField2 { get; private set; }
        public DateTime OptionalField3 { get; private set; }
        public int OptionalField4 { get; private set; }

        public class DocumentBuilder
        {
            private readonly Document document;

            public DocumentBuilder()
            {
                document = new Document();
            }

            public MandatoryField2Builder SetMandatoryField1(string value)
            {
                document.MandatoryField1 = value;
                return new MandatoryField2Builder(document);
            }

            public class MandatoryField2Builder
            {
                private readonly Document document;

                public MandatoryField2Builder(Document document)
                {
                    this.document = document;
                }

                public OptionalField3Builder SetMandatoryField2(float value)
                {
                    document.MandatoryField2 = value;
                    return new OptionalField3Builder(document);
                }
            }

            public class OptionalField3Builder
            {
                private readonly Document document;

                public OptionalField3Builder(Document document)
                {
                    this.document = document;
                }

                public OptionalField3Builder SetOptionalField3(DateTime value)
                {
                    document.OptionalField3 = value;
                    return this;
                }

                public OptionalField3Builder SetOptionalField4(int value)
                {
                    document.OptionalField4 = value;
                    return this;
                }

                public Document Build()
                {
                    return document;
                }
            }
        }
    }
}
