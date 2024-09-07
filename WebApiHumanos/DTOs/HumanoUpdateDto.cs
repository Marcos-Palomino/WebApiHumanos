namespace WebApiHumanos.DTOs
{
    public class HumanoUpdateDto
    {
        public string Nombre { get; set; }
        public string Sexo { get; set; }
        public int? Edad { get; set; }
        public double? Altura { get; set; }
        public double? Peso { get; set; }
    }
}