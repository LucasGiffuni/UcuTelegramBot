namespace PII_E13.model
{

    public class Person
    {

        public int Id{get; set;}
        public string Name{get; set;}
        public string Role{get; set;}



        public Person(int id,string name, string role)
        {
            this.Id = id;
            this.Name = name;
            this.Role = role;

        }


    }

}