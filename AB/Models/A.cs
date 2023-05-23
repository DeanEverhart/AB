using System.ComponentModel.DataAnnotations;

namespace AB.Models
{
    public class A
    {
        public int Id { get; set; }

        public string? One { get; set; }

        public string? Two { get; set; }

        public string? Three { get; set; }

        [Display(Name = "PDM_A")]
        public string PDM_A
        {
            get
            {
                return One + ", " + Two + ", " + Three;
            }
        }

        // _______________________________________

        public IEnumerable<B>? B { get; set; }

    }
}
