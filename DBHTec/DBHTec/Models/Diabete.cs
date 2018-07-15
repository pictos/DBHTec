using Newtonsoft.Json;

namespace DBHTec.Models
{
    public class Diabete
    {
        public Inputs Inputs                     { get; set; }
        public Globalparameters GlobalParameters { get; set; }
    }

    public class Inputs
    {
        [JsonProperty("input1")]
        public Input1[] Input1 { get; set; }
    }

    public class Input1
    {
        [JsonProperty("PatientID")]
        public string IdPaciente                 { get; set; }

        [JsonProperty("Pregnancies")]
        public string Gravidez                   { get; set; }

        [JsonProperty("PlasmaGlucose")]
        public string GlicosePlasma              { get; set; }

        [JsonProperty("DiastolicBloodPressure")]
        public string PressaoSanguineaDiastolica { get; set; }

        [JsonProperty("TricepsThickness")]
        public string EspessuraTriceps           { get; set; }

        [JsonProperty("SerumInsulin")]
        public string InsulinaSerica             { get; set; }

        [JsonProperty("BMI")]
        public string BMI                        { get; set; }

        [JsonProperty("DiabetesPedigree")]
        public string DiabetesPedigree           { get; set; }

        [JsonProperty("Age")]
        public string Idade                      { get; set; }
    }

    public class Globalparameters
    {
    }


}
