using System.ComponentModel.DataAnnotations;

    namespace Webserver.Model
    {
        public class Intanswer
        {
        [Key]
        public int IntanswerID { get; set; }

        public int Index { get; set; }

        public int Value { get; set; }
        }
    }
