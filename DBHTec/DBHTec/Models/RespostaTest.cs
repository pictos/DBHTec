using Newtonsoft.Json;

namespace DBHTec.Models
{


    public class RespostaTest
    {
        public Results Results { get; set; }
    }

    public class Results
    {
        [JsonProperty("output1")]
        public Output1[] Output1 { get; set; }
    }

    public class Output1
    {
        [JsonProperty("PatientID")]
        public string IdPaciente       { get; set; }

        [JsonProperty("Physician")]
        public string Medico           { get; set; }

        [JsonProperty("DiabetesPrediction")]
        public string PrevisaoDiabetes { get; set; }
        [JsonProperty("Probability")]
        public string Probabilidade    { get; set; }
    }

}

