using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore30_IdsInValueObjects
{
    public class ReportDiagram
    {
        public ReportDiagramId Id { get; set; }

        public string Url { get; set; }

    }

    public class ReportDiagramId
    {
        public string Quarter { get; set; }
        public string Name { get; set; }
    }

    public class Report
    {
        public string Id { get; set; }

        public string Text { get; set; }

        public ReportDiagramId ReportDiagramId { get; set; }
    }
}
