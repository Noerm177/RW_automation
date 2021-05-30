using System.Runtime.Serialization;


namespace RW_Auto.Contracts
{
    [DataContract]
    public class DriverParams
    {
        [DataMember]
        public string Source {get; set;}

        [DataMember]
        public string Driver {get; set;}

        [DataMember]
        public string Binaries {get; set;}
        /*  [DataMember]
        public ChromeOptions Optiones { get; set; } */
    }
}