namespace backend.Models.Users;
using System.ComponentModel.DataAnnotations;

 public class LoginUser
    {
        public string Email { get; set; } = "";
        public string Password { get; set; } = "";
    }