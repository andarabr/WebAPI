namespace DataAccess.ViewModels
{
    public class VillageVM
    {
        public string Name { get; set; }
        public int DistrictId { get; set; }

        public VillageVM() { }

        public VillageVM(string name, int districtid)
        {
            this.Name = name;
            this.DistrictId = districtid;
        }

        public void Update(string name, int districtid)
        {
            this.Name = name;
            this.DistrictId = districtid;
        }
    }
}