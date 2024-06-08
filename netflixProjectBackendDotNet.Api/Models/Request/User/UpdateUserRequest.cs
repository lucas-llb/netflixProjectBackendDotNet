using netflixProjectBackendDotNet.Domain.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace netflixProjectBackendDotNet.Api.Models.Request.User;

public class UpdateUserRequest
{
    /// <summary>
    /// First Name
    /// </summary>
    [Required]
    public string FirstName { get; set; }
    /// <summary>
    /// LastName
    /// </summary>
    [Required]
    public string LastName { get; set; }
    /// <summary>
    /// Phone
    /// </summary>
    [Required]
    public string Phone { get; set; }
    /// <summary>
    /// Birth
    /// </summary>
    [Required]
    public DateTime Birth { get; set; }
    /// <summary>
    /// Email
    /// </summary>
    [Required]
    public string Email { get; set; }

    public UserEntity ToUserEntity(int id) =>
        new UserEntity
        {
            Id = id,
            FirstName = FirstName,
            LastName = LastName,
            Phone = Phone,
            Birth = Birth,
            Email = Email
        };
}
