using System.Collections.Generic;

namespace Artillery.DataProcessor.ExportDto
{
    public class ShellExportDto
    {
        public double ShellWeight { get; set; }

        public string Caliber { get; set; }

        public List<ShellGunExportDto> Guns { get; set; }
    }
}
