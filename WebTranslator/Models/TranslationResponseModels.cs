namespace WebTranslator.Models
{
    public class Translation
    {
        public string Text { get; set; }
        public string To { get; set; }
    }

    public class TranslationsContainer
    {
        public List<Translation> Translations { get; set; }
    }

    public class Root : List<TranslationsContainer> { }
}
