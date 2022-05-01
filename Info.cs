namespace OpenTMS
{
    public class Info
    {
        [System.ComponentModel.DataAnnotations.Key]
        public string? Token { get; set; }
        public string? Type { get; set; }
        public string? Version { get; set; }

    }
}
