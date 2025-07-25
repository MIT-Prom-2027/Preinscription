// dans un nouveau fichier Models/ErrorViewModel.cs
namespace preinscription.Models
{
    public class ErrorViewModel
    {
        public string? RequestId { get; set; }
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
