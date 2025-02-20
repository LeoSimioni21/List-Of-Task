using System.ComponentModel.DataAnnotations;
using List_of_Task.Validators;

namespace List_of_Task.Models;

public class Todo
{
    public int Id {get; set; }

    [Display(Name = "Título")]
    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "O campo {0} deve ter entre {2} e {1} caracteres!")]
    public String Title {get; set; } = string.Empty;

    public DateTime CreatedAt  { get; set; }

    [Display(Name = "Data de entrega")]
    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
    [FutureOsPresent]
    public DateOnly Daedline { get; set; }

    public DateOnly? FinisheAt  { get; set; }
}   