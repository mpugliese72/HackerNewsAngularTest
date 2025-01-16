namespace HackerNewsAngularTest.Server.Models
{
    public class News
    {
        public int id { get; set; }
        public bool? deleted { get; set; }
        public string? type { get; set; }
        public string? by { get; set; }
        public int? time { get; set; }
        public string? text { get; set; }
        public bool? dead { get; set; }
        public string? parent { get; set; }
        public int? poll { get; set; }
        public int[]? kids { get; set; }
        public string? url { get; set; }
        public int? score { get; set; }
        public string? title { get; set; } 
        public int[]? parts { get; set; }
        public int? descendants { get; set; }
    }
}
