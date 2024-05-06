namespace repository_pattern.DTO
{
    public class Result<T>
    {
        public bool Succeeded { get; set; }

        public string Message { get; set; }

        public List<T> Data { get; set; }
    }
}
