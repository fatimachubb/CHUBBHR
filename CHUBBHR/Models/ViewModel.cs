using Aspose.Cells;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

// Modelo para el inicio de sesión
public class LoginViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string Password { get; set; }

    [Display(Name = "Remember me")]
    public bool RememberMe { get; set; }
}

// Modelo para la recuperación de contraseña
public class ForgotPasswordViewModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; }
}


