﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PhysicalTherapy.Models
{
    public class PostRoutineSurvey
    {
        public bool Completed { get; set; }

        public DateTime Date { get; set; }

        [Range(1, 10)]
        public int LevelOfDifficulty { get; set; }

        [Range(1, 10)]
        public int LevelOfPain { get; set; }

        [Range(1, 10)]
        public int LevelOfTiredness { get; set; }

        public string Note { get; set; }

        public int PostRoutineSurveyId { get; set; }
    }
}
