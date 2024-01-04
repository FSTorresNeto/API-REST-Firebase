using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Google.Cloud.Firestore;

namespace Firebase.Platform.Business.Entity.Models;

public class Trash
{

    [FirestoreProperty]
    [Column(TypeName = "varchar(50)")]
    public string Name { get; set; }

    [FirestoreProperty]
    [Column(TypeName = "varchar(50)")]
    public string Street { get; set; }

    [FirestoreProperty]
    [Column(TypeName = "varchar(50)")]
    public string Number { get; set; }

    public static Trash Create(string name, string street, string number)
    {
        return new Trash()
        {
            Name = name,
            Street = street,
            Number = number
        };
    }
}