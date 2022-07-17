using Marvel.Models;

namespace Marvel.ViewModel
{
    public class HomeVM
    {
        public Banner Banner { get; set; }
        public Stylish Stylish { get; set; }
        public List<Service> Services { get; set; }
        public Callout Callout { get; set; }
        public List<Portfolio> Portfolio { get; set; }
        public CallToAct CallToAct { get; set; }


    }
}
