using System.ComponentModel.DataAnnotations;

namespace Microscope.Admin.ViewModels
{
    public class StorageContainer
    {
        private string _name;
        
        [Required]
        [RegularExpression(@"^\S*$", ErrorMessage = "No white space allowed")]
        public string Name
        {
            get { return _name; }
            set { _name = value.ToLower(); }
        }
    }
}
