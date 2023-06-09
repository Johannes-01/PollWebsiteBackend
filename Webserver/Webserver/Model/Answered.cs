﻿using System.ComponentModel.DataAnnotations;

    namespace Webserver.Model
    {
    public class Answered
    {
        [Key, Required]
        public int AnsweredID { get; set;}
        
        [Required]
        public int SurveyID { get; set;}

        [Required]
        public int[] UserID { get; set;}
        }
    }