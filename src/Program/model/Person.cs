namespace Ucu.Poo.model
{

    public class Person
    {

        public int Id{get; set;}
        public string Name{get; set;}
        public string SureName{get; set;}
        public string Role{get; set;}



        public Person(int id,string name, string sureName, string role)
        {
            this.Id = id;
            this.Name = name;
            this.SureName = sureName;
            this.Role = role;

        }


    }

}