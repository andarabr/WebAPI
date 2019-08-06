namespace DataAccess.ViewModels
{
    public class ReligionVM
    {
        public string Name { get; set; }

        public ReligionVM() { }

        public ReligionVM(string name)
        {
            this.Name = name;
        }

        public void Update(string name)
        {
            this.Name = name;
        }
    }
}