namespace Exception_Interceptor.Models
{
    public class TableExample1
    {
        public string Name { get; set; }
        public string Description { get; set; }

        //public TableExample1(string description, string name)
        //{
        //    Description = description;
        //    Name = name;
        //}

        public override string ToString()
        {
            return $"Name={Name},Description={Description}";
        }
    }
}
