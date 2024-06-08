namespace netflixProjectBackendDotNet.Api.Models.Request.User;

public class UpdatePasswordRequest
{
    /// <summary>
    /// Current Password
    /// </summary>
    public string CurrentPassword { get; set; }
    /// <summary>
    /// New Password
    /// </summary>
    public string NewPassword { get; set; }
}
