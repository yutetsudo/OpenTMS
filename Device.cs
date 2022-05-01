namespace OpenTMS
{
    public class Device
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string? Token { get; set; }
        public string? Type { get; set; }
        public string? Address { get; set; }
    }
}
