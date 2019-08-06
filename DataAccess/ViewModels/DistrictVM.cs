namespace DataAccess.ViewModels
{
    public class DistrictVM
    {
        public string Name { get; set; }
        public int RegencyId { get; set; }

        public DistrictVM() { }

        public DistrictVM(string name, int regencyid)
        {
            this.Name = name;
            this.RegencyId = regencyid;
        }

        public void Update(string name, int regencyid)
        {
            this.Name = name;
            this.RegencyId = regencyid;
        }
    }
}