//#define DEBUG
using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_FamilyApp_2019_11_02_Core_SQL
{

    public class DailyLog
    {
        public int DailyLogId { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime LogDate { get; set; }

        public String Comments { get; set; }
        public bool UpOnTime { get; set; }
        public bool StayedUp { get; set; }
        public bool MadeGym { get; set; }
        public bool PrWthFam { get; set; }
        public bool PrWthZ { get; set; }
        public bool CrsPryPhoto { get; set; }
        public bool PhilPryPhoto { get; set; }
        public bool CrsDeskPhoto { get; set; }
        public int NbrSns { get; set; }
        public int? NbrGrps { get; set; }
        public bool GymCardio { get; set; }
        public bool GymWeights { get; set; }
        public bool GymSprints { get; set; }
        public bool GymChest { get; set; }
        public bool GymBack { get; set; }
        public bool GymLegs { get; set; }
        public bool GymBicep { get; set; }
        public bool GymTricep { get; set; }
        public bool GymShoulders { get; set; }
        public bool GymClass { get; set; }
        public bool GymDips { get; set; }
        public bool GymPullUps { get; set; }
        public bool GymPushUps { get; set; }

        public int? NmbrPrtnScps { get; set; }

        public bool SnkCln { get; set; }

        public bool WlkRndOffc { get; set; }

        public bool ScrptrOfThDy { get; set; }
        public bool ScrptrOfThDyChrst { get; set; }
        public bool ScrptrOfThDyPhlp { get; set; }
        public bool ScrptrOfThDyJms { get; set; }
        public bool ScrptrOfThDyJhn { get; set; }
        public bool ScrptrOfThDyHnnh { get; set; }
    }

    public class GymLog
    {
        [Key]
        public int GymLogId { get; set; }
        [Display(Name = "Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime GymLogDate { get; set; }

        public int? UserId { get; set; }
        public User User { get; set; }

        public int? WorkoutTypeId { get; set; }
        public WorkoutType WorkoutType { get; set; }
    }

    public class User
    {
        [Key]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class Exercise
    {
        public int ExerciseId { get; set; }
        public string ExerciseName { get; set; }

        public int? ExerciseCategoryId { get; set; }
        public ExerciseCategory ExerciseCategory { get; set; }
    }

    public class WorkoutType
    {
        public int WorkoutTypeId { get; set; }
        public string WorkoutTypeName { get; set; }
    }

    public class ExerciseCategory
    {
        public int ExerciseCategoryId { get; set; }
        public string ExerciseCategoryName { get; set; }
    }
}
