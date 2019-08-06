namespace DataAccess.ViewModels
{
    public class ParameterVM
    {
        public string Name { get; set; }
        public string Value { get; set; }


        public ParameterVM() { }

        public ParameterVM(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }

        public void Update(string name, string value)
        {
            this.Name = name;
            this.Value = value;
        }
    }
}