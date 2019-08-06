namespace DataAccess.ViewModels
{
    public class ApplicationVM
    {
        public string Name { get; set; }

        public ApplicationVM() { }

        public ApplicationVM(string name)
        {
            this.Name = name;
        }

        public void Update(string name)
        {
            this.Name = name;
        }
    }
}