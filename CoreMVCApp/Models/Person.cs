
using System.ComponentModel.DataAnnotations;

namespace CoreMVCApp.Models
{
    //Demo
    public class Person
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter mobile")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please select a state")]
        public string State { get; set; }
    }
}

