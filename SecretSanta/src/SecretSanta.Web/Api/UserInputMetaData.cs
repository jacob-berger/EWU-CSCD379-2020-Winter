using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace SecretSanta.Web.Api
{
    [ModelMetadataType(typeof(UserInputMetaData))]
    public partial class UserInput { }

    public class UserInputMetaData
    {

        // Justification: Just metadata so being null shouldn't be an issue
#pragma warning disable CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        [Display(Name = "Santa Id")]
        public int SantaId { get; set; }
#pragma warning restore CS8618 // Non-nullable field is uninitialized. Consider declaring as nullable.
    }
}