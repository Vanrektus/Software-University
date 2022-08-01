using System.ComponentModel.DataAnnotations;

namespace Artillery.DataProcessor.ImportDto
{
    public class CountryIdImportDto
    {
        [Key]
        public int Id { get; set; }
    }
}
