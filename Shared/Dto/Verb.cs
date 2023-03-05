namespace Shared.Dto
{
    public class Verb : Base
    {
        public string PresentParticiple { get; set; }
        public string PastParticiple { get; set; }
        public Indicative Indicative { get; set; }
        public Subjunctive Subjunctive { get; set; }
    }

    public class Indicative
    {
        public Presenttense PresentTense { get; set; }
        public Pretérito Pretérito { get; set; }
        public Conditional Conditional { get; set; }
        public Future Future { get; set; }
    }

    public class Presenttense
    {
        public string Yo { get; set; }
        public string Tu { get; set; }
        public string ElEllaUsted { get; set; }
        public string Nosotros { get; set; }
        public string Vosotros { get; set; }
        public string EllosEllasUstedes { get; set; }
    }

    public class Pretérito
    {
        public string Yo { get; set; }
        public string Tu { get; set; }
        public string ElEllaUsted { get; set; }
        public string Nosotros { get; set; }
        public string Vosotros { get; set; }
        public string EllosEllasUstedes { get; set; }
    }

    public class Conditional
    {
        public string Yo { get; set; }
        public string Tu { get; set; }
        public string ElEllaUsted { get; set; }
        public string Nosotros { get; set; }
        public string Vosotros { get; set; }
        public string EllosEllasUstedes { get; set; }
    }

    public class Future
    {
        public string Yo { get; set; }
        public string Tu { get; set; }
        public string ElEllaUsted { get; set; }
        public string Nosotros { get; set; }
        public string Vosotros { get; set; }
        public string EllosEllasUstedes { get; set; }
    }

    public class Subjunctive
    {
        public Presenttense1 PresentTense { get; set; }
        public Imperfect Imperfect { get; set; }
        public Future1 Future { get; set; }
    }

    public class Presenttense1
    {
        public string Yo { get; set; }
        public string Tu { get; set; }
        public string ElEllaUsted { get; set; }
        public string Nosotros { get; set; }
        public string Vosotros { get; set; }
        public string EllosEllasUstedes { get; set; }
    }

    public class Imperfect
    {
        public string Yo { get; set; }
        public string Tu { get; set; }
        public string ElEllaUsted { get; set; }
        public string Nosotros { get; set; }
        public string Vosotros { get; set; }
        public string EllosEllasUstedes { get; set; }
    }

    public class Future1
    {
        public string Yo { get; set; }
        public string Tu { get; set; }
        public string ElEllaUsted { get; set; }
        public string Nosotros { get; set; }
        public string Vosotros { get; set; }
        public string EllosEllasUstedes { get; set; }
    }
}
