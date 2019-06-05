using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EfCore30_IdsInValueObjects
{
    public class ReportDiagram
    {
        public ReportDiagramId Id { get; private set; }

        public string Url { get; private set; }

    }

    public class ReportDiagramId
    {
        public ReportDiagramId(string idString)
        {
            var splitted = idString.Split("~");
            Quarter = splitted[0];
            Name = splitted[1];
        }
        public ReportDiagramId(string quarter, string name)
        {
            Quarter = quarter;
            Name = name;
        }
        public string Quarter { get; private set; }
        public string Name { get; private set; }

        /// <inheritdoc />
        public override string ToString()
        {
            return Quarter + "~" + Name;
        }
    }

    public class Reports
    {
        public string Id { get; private set; }

        public string Text { get; private set; }

        public ReportDiagramId ReportDiagramId { get; private set; }
    }
}
