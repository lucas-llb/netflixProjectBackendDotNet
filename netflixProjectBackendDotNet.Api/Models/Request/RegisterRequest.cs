using netflixProjectBackendDotNet.Domain.Constants;
using netflixProjectBackendDotNet.Domain.Entities.User;
using System.ComponentModel.DataAnnotations;

namespace netflixProjectBackendDotNet.Api.Models.Request;

public class RegisterRequest
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public DateTime Birth { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Phone { get; set; }

    public UserEntity CreateUser()
    {
        return new UserEntity
        {
            FirstName = FirstName,
            LastName = LastName,
            Email = Email,
            Password = Password,
            Phone = Phone,
            Birth = Birth,
            Role = RoleEnum.User,
        };
    }
}
