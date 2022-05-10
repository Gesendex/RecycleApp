using System.Text.Json.Serialization;

namespace RecycleApp.Models
{
    public partial class ClientDtoIn
    {
        [JsonIgnore]
        public string FullName => this.Name + " " + this.Surname + " " + this.Middlename;
    }
}
