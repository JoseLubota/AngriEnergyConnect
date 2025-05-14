using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AngriEnergyConnect.Model
{
    //---------------------------------------------------------------------------------------------//
    // Creates Class User
    //---------------------------------------------------------------------------------------------//
    public class User
    {
        //---------------------------------------------------------------------------------------------//
        // Allows class to connect to convert into tables for local database
        //---------------------------------------------------------------------------------------------//
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int userID {  get; set; }
         [Required]
        public string name { get; set; }
        [Required]
        [EmailAddress]
        public string email { get; set; }
        [Required]
        public string password { get; set; }
        [Required]
        public string surname { get; set; }
        [Required]
        public string accountType { get; set; }

        //Navigation Property
        [ValidateNever]
        public ICollection<Product> products { get; set; }

    }
}
//--------------------------------...END OF FILE...-------------------------------------------------------------//
