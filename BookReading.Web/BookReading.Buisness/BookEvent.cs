using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace BookReading.Business
{
    public class BookEvent

    {
        [Key]
        
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; }
        [Required]
        [DataType(DataType.Time)]
        public DateTime StartTime { get; set; }
        [Required]
        public string Type { get; set; }
        [Range(0,4,ErrorMessage ="Please Enter between 0 and 4")]
        public int Duration { get; set; }
        public string Description { get; set; }
        public string OtherDetails { get; set; }
        public int TotalInvitedUser { get; set; }
        public string Author { get; set; }

        public string InvitedUSer { get; set; }

    }
}
