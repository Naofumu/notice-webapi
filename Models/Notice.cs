using Newtonsoft.Json;

public class Notice
{  
    public int Id { get; set; }  
    public string? Username { get; set; }
    public User? User { get; set; }
    public int? Number { get; set; }  
    [JsonConverter(typeof(MyDateTimeConverter))]
    public DateTime? DateOfNotice { get; set; }  
    public string? FullName { get; set; }  
    public string? Gender { get; set; }  
    [JsonConverter(typeof(MyDateTimeConverter))]
    public DateTime? Birthdate { get; set; }  
    public string? Region { get; set; }  
    public string? Locality { get; set; }  
    public string? Street { get; set; }  
    public string? Dom { get; set; }  
    public string? Kv { get; set; }  
    public string? TemporaryAddress { get; set; }  
    public string? Resident { get; set; }  
    public string? Category { get; set; }  
    public string? SocialGroup { get; set; }  
    public string? Work { get; set; }  
    public string? Diagnosis { get; set; }  
    [JsonConverter(typeof(MyDateTimeConverter))]
    public DateTime? DiagnosisDate { get; set; }  
    public bool Reminfection { get; set; }  
    public string? Confirmation { get; set; }  
    public string? Causative { get; set; }  
    public string? TransmissionPath { get; set; }  
    public string? PlaceOfDetection { get; set; }  
    public string? Additional { get; set; }  
    public string? Circumstances { get; set; }  
    public string? PregnancyDuration { get; set; }  
    public string? Doctor { get; set; }  
    public string? Comment { get; set; }  
}