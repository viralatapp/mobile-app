namespace ViralatApp.Models
{
    public class Pet
    {
        public string Name { get; set; }
        public string Race { get; set; }
        public Sexo Sexo { get; set; }
        public string Image { get; set; }
        public bool IsAdult { get; set; }
    }

    public enum Sexo
    {
        Femenino = 0,
        Masculino = 1
    }
}
