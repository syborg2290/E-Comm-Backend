namespace backend.Models.Common;
using System.ComponentModel.DataAnnotations;

public class Tokens
{
	public string Token { get; set; }
	public string RefreshToken { get; set; }
}	