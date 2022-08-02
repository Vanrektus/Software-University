using System.Collections.Generic;

namespace Theatre.DataProcessor.ExportDto
{
    public class TheatreExportDto
    {
        public string Name { get; set; }

        public sbyte Halls { get; set; }

        public decimal TotalIncome { get; set; }

        public ICollection<TicketExportDto> Tickets { get; set; }
    }
}
