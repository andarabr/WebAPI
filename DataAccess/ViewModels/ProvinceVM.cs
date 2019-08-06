namespace DataAccess.ViewModels
{
    public class ProvinceVM
    {
        public string Name { get; set; }

        public ProvinceVM() { }

        public ProvinceVM(string name)
        {
            this.Name = name;
        }

        public void Update(string name)
        {
            this.Name = name;
        }
    }
}