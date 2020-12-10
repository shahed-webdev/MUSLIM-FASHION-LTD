namespace MuslimFashion.ViewModel.Common
{
    public class ErrorViewModel
    {
        public ErrorViewModel(string message)
        {
            Message = message;
        }
        public ErrorViewModel(string message, string code)
        {
            Message = message;
            Code = code;
        }
        public string Code { get; set; }
        public string Message { get; set; }
    }
}