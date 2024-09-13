using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryMethodDesignPattern
{
    public class Report : Document
    {
        public Report() : base() {
        }

        public override void CreatePages() {
            this.Pages.Add(new IntroductionPage());
            this.Pages.Add(new ResultsPage());
            this.Pages.Add(new ConclusionPage());
            this.Pages.Add(new SummaryPage());
            this.Pages.Add(new BibliographyPage());
        }
    }
}
