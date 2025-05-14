using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace AngriEnergyConnect.Model
{
    //---------------------------------------------------------------------------------------------//
    // Creates Class Product
    //---------------------------------------------------------------------------------------------//
    public class Product
    {
        //---------------------------------------------------------------------------------------------//
        // Allows class to connect to convert into tables for local database
        //---------------------------------------------------------------------------------------------//
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int productID {  get; set; }
        public string productName { get; set; }
        public string category { get; set; }
        public DateOnly productionDate { get; set; }
        // Foreign Key
        [ValidateNever]
        public int userID { get; set; }

        //Navigation Property
        [ValidateNever]
        public User user { get; set; }

    }
}
//--------------------------------...END OF FILE...-------------------------------------------------------------//
