using System.ComponentModel.DataAnnotations;

namespace Crud.ViewModel
{

    public enum TodoTag
    {
        Bug ,
        Test ,
        Task
    } 
    public class TodoVM
    {

        public int Id { get; set; }


        [Required(ErrorMessage = "darouri title")]
        [RegularExpression("[A-Z][A-Za-z0-9]{1,50}", ErrorMessage = "Title machi nichane")]
        public string Title { get; set; } 


        public string Description { get; set; }

        public bool IsFinished { get; set; }

        public List<TodoTag> SelectedTags { get; set; } = new List<TodoTag>();

        [Required(ErrorMessage ="darouri tkhtar user")]
        public string User { get; set; }

        [Required(ErrorMessage ="darouri dakhal datetime")]
        [DataType(DataType.DateTime)]
        public DateTime CreateAd { get; set; }



    }
}
