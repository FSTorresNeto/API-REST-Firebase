
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Google.Cloud.Firestore;

namespace Firebase.Platform.Auth.Entity.Models;

public class User
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long UserId { get; set; }

    [FirestoreProperty]
    [Column(TypeName = "varchar(50)")]
    public string Email { get; set; }

    [FirestoreProperty]
    [Column(TypeName = "varchar(50)")]
    public string Password { get; set; }

    [FirestoreProperty]
    [Column(TypeName = "varchar(50)")]
    public string Name { get; set; }

    [FirestoreProperty]
    [Column(TypeName = "varchar(50)")]
    public string PhoneNumber { get; set; }

    [FirestoreProperty]
    [Column(TypeName = "varchar(50)")]
    public string DepositsTotalValue { get; set; }



    public static User Create(string email, string name, string password, string phoneNumber, string depositsTotalValue)
    {
        return new User()
        {
            Email = email,
            Password = password,
            Name = name,
            PhoneNumber = phoneNumber,
            DepositsTotalValue = depositsTotalValue,
        };
    }
}