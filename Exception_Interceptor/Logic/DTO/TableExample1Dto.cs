namespace Exception_Interceptor.Logic.DTO
{
    public class TableExample1Dto
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public override string ToString()
        {
            return $"Name={Name},Description={Description}";
        }
    }
}
