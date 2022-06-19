namespace FactoryMethod
{
    public static class RealWorld
    {
        public static void Execute()
        {
            List<Document> documents = new();
            documents.Add(new Resume());
            documents.Add(new Report());

            foreach (var document in documents)
            {
                Console.WriteLine("\n" + document.GetType().Name + "--");
                foreach (var page in document.Pages)
                {
                    Console.WriteLine(" " + page.GetType().Name);
                }
            }
        }

        abstract class Page { }

        class SkillsPage : Page { }
        class SummaryPage : Page { }
        class EducationPage : Page { }
        class ExperiencePage : Page { }
        class IntroductionPage : Page { }
        class ResultsPage : Page { }
        class ConclusionPage : Page { }
        class BibliographyPage : Page { }

        abstract class Document
        {
            public List<Page> Pages { get; protected set; }

            public Document()
            {
                Pages = new();
                CreatePages();
            }

            public abstract void CreatePages();
        }

        class Resume : Document
        {
            public override void CreatePages()
            {
                Pages.Add(new SkillsPage());
                Pages.Add(new EducationPage());
                Pages.Add(new ExperiencePage());
            }
        }
        class Report : Document
        {
            public override void CreatePages()
            {
                Pages.Add(new IntroductionPage());
                Pages.Add(new ResultsPage());
                Pages.Add(new ConclusionPage());
                Pages.Add(new SummaryPage());
                Pages.Add(new BibliographyPage());
            }
        }
    }
}
