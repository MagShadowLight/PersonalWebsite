namespace personal_website.Server.DTO
{
    public class UserDto
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string? DisplayName { get; set; }
        public string? Location { get; set; }
        public string? Website {  get; set; }
        public string? GithubUsername { get; set; }
        public string? Timezone { get; set; }
        public DateTime JoinedAt { get; set; }
    }
}
