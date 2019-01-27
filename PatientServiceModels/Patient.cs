using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using PatientServiceModels.Exceptions;
using PatientServiceModels.NewApproach;

namespace PatientServiceModels
{
    public enum Gender { M,F}

    public class Patient : IStudyFolderParent, IDocumentParent
    { 

        [Key]
        public int Id { get; private set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string SocialInsuranceNumber { get; set; }

        public int GDPRAcceptedId { get; set; }

        [Required]
        public bool StudyAccepted { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public virtual PatientAddress Address { get; set; }

        //public virtual ICollection<Document> DocumentIds { get; set; }

        //public virtual ICollection<StudyFolder> StudyFolders { get; set; }

        public virtual ICollection<PatientFolder> PatientFolders { get; set; }
        public virtual ICollection<PatientTopDocument> PatientDocuments { get; set; } 
        public TopLevelFolder ParentFolder { get; set; }

        //public StudyFolder Parent { get; set; }


        public Patient(string title, string socialInsuranceNumber,
            string firstname, string lastname, Gender gender, DateTime birthDate,
            string street, string zipCode, string town, Country country, int GDPRId, bool studyAccepted) 
        {
            if (socialInsuranceNumber == null) throw new ArgumentNullException(nameof(socialInsuranceNumber));

            if (!Enum.IsDefined(typeof(Gender), gender))
                throw new InvalidEnumArgumentException(nameof(gender), (int) gender, typeof(Gender));


            Title = title ?? throw new ArgumentNullException(nameof(title));

            Gender = gender;

            FirstName = firstname ?? throw new ArgumentNullException(nameof(firstname));

            LastName = lastname ?? throw new ArgumentNullException(nameof(lastname));

            GDPRAcceptedId = GDPRId;

            StudyAccepted = studyAccepted;
            
            BirthDate = BirthDateIsValid(birthDate.Date) ? birthDate.Date : throw new InvalidBirthDateException("Future birthdate!");


            SocialInsuranceNumber = SocialInsuranceNumberIsValid(socialInsuranceNumber)
                ? socialInsuranceNumber
                : throw new InvalidInsuranceNumberException("SocialSecurityNumber is not Valid!");
        
            Address = new PatientAddress(street, zipCode, town, country);

        }

        public Patient(string title, string socialInsuranceNumber,
            string firstname, string lastname, Gender gender, DateTime birthDate,
            string street, string zipCode, string town, Country country, int GDPRId, bool studyAccepted, TopLevelFolder folder)
        {
            if (socialInsuranceNumber == null) throw new ArgumentNullException(nameof(socialInsuranceNumber));

            if (!Enum.IsDefined(typeof(Gender), gender))
                throw new InvalidEnumArgumentException(nameof(gender), (int)gender, typeof(Gender));


            Title = title ?? throw new ArgumentNullException(nameof(title));

            Gender = gender;

            FirstName = firstname ?? throw new ArgumentNullException(nameof(firstname));

            LastName = lastname ?? throw new ArgumentNullException(nameof(lastname));

            GDPRAcceptedId = GDPRId;

            StudyAccepted = studyAccepted;

            BirthDate = BirthDateIsValid(birthDate.Date) ? birthDate.Date : throw new InvalidBirthDateException("Future birthdate!");

            ParentFolder = folder;

            SocialInsuranceNumber = SocialInsuranceNumberIsValid(socialInsuranceNumber)
                ? socialInsuranceNumber
                : throw new InvalidInsuranceNumberException("SocialSecurityNumber is not Valid!");

            Address = new PatientAddress(street, zipCode, town, country);

        }

        public Patient(string title, string socialInsuranceNumber,
            string firstname, string lastname, Gender gender, DateTime birthDate,
            string street, string zipCode, string town, Country country, bool studyAccepted, TopLevelFolder folder)
        {
            if (socialInsuranceNumber == null) throw new ArgumentNullException(nameof(socialInsuranceNumber));

            if (!Enum.IsDefined(typeof(Gender), gender))
                throw new InvalidEnumArgumentException(nameof(gender), (int)gender, typeof(Gender));


            Title = title ?? throw new ArgumentNullException(nameof(title));

            Gender = gender;

            FirstName = firstname ?? throw new ArgumentNullException(nameof(firstname));

            LastName = lastname ?? throw new ArgumentNullException(nameof(lastname));

            StudyAccepted = studyAccepted;

            BirthDate = BirthDateIsValid(birthDate.Date) ? birthDate.Date : throw new InvalidBirthDateException("Future birthdate!");

            ParentFolder = folder;

            SocialInsuranceNumber = SocialInsuranceNumberIsValid(socialInsuranceNumber)
                ? socialInsuranceNumber
                : throw new InvalidInsuranceNumberException("SocialSecurityNumber is not Valid!");

            Address = new PatientAddress(street, zipCode, town, country);

        }

        public Patient() { }


        private bool SocialInsuranceNumberIsValid(string numberToTest)
        {
            throw new NotImplementedException();
        }

        public bool OnlyContainsNumbers(string toTest)
        {
            return int.TryParse(toTest, out var i);
        }

        public bool BirthDateIsValid(DateTime timeToTest)
        {
            return timeToTest < DateTime.Today.Date;
        }

    }
}
