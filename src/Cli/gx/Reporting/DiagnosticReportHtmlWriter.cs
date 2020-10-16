﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

using Glacie.Diagnostics;

using IO = System.IO;

namespace Glacie.Cli.Reporting
{
    internal ref struct DiagnosticReportHtmlWriter // TODO: struct
    {
        private readonly IO.StreamWriter _writer;
        private readonly IReadOnlyCollection<Diagnostic> _diagnostics;

        public DiagnosticReportHtmlWriter(IO.StreamWriter writer, IReadOnlyCollection<Diagnostic> diagnostics)
        {
            _writer = writer;
            _diagnostics = diagnostics;
        }

        public void Write()
        {
            _writer.WriteLine("<html>");
            _writer.WriteLine("<head>");
            _writer.WriteLine(@"
<link rel='stylesheet' href='https://cdnjs.cloudflare.com/ajax/libs/jquery.tablesorter/2.31.3/css/theme.blue.min.css'/>

<style>

body {
  font-family: ""Segoe UI"", ""Arial"";
  font-size: 9pt;
}

table {
  font-size: 9pt;
}

.gx-diagnostics-table {
  width: 100%;
  border-collapse: collapse;
}

.gx-diagnostics-table > thead {
  font-weight: bold;
}

table.gx-diagnostics-table,
table.gx-diagnostics-table th,
table.gx-diagnostics-table td {
  border: 1px solid black;
}

table.gx-diagnostics-table th,
table.gx-diagnostics-table td {
  padding: 4px;
}

table.gx-diagnostics-table > thead {
  background-color: #f2f2f2;
}

table.gx-diagnostics-table > thead > tr {
  text-align: center;
}

table.gx-diagnostics-table > tbody > tr {
  text-align: left;
}

table.gx-diagnostics-table > tbody > tr:nth-child(even) {
  background-color: #f2f2f2;
}

table.gx-diagnostics-table > tbody > tr:hover { background-color: #ddd; }

table.gx-diagnostics-table > tbody td {
  color: initial;
  background-color: initial;
}

</style>

<script type='text/javascript' src='https://cdnjs.cloudflare.com/ajax/libs/jquery/3.5.1/jquery.min.js'></script>
<script type='text/javascript' src='https://cdnjs.cloudflare.com/ajax/libs/jquery.tablesorter/2.31.3/js/jquery.tablesorter.min.js'></script>
<!--script type='text/javascript' src='https://cdnjs.cloudflare.com/ajax/libs/jquery.tablesorter/2.31.3/js/jquery.tablesorter.widgets.min.js'></script-->

");
            _writer.WriteLine("</head>");
            _writer.WriteLine("<body>");

            WriteDiagnosticsCollection(_diagnostics);

            _writer.WriteLine(@"
<script>
$(function() {
  $('table.gx-diagnostics-table').tablesorter({theme: 'blue'});
});
</script>
");

            _writer.WriteLine("<hr/>");
            _writer.WriteLine("<p>Generated by <a href=\"https://github.com/lixiss/glacie\">Glacie</a></p>");

            _writer.WriteLine("</body>");
            _writer.WriteLine("</html>");
        }

        private void WriteDiagnosticsCollection(IEnumerable<Diagnostic> diagnostics)
        {
            _writer.WriteLine("<table class='gx-diagnostics-table'>");

            _writer.WriteLine("<thead>");
            _writer.WriteLine("<tr>");
            _writer.WriteLine("<td>Severity</td>");
            _writer.WriteLine("<td>Code</td>");
            _writer.WriteLine("<td>Description</td>");
            _writer.WriteLine("<td>Location</td>");
            _writer.WriteLine("</tr>");
            _writer.WriteLine("</thead>");

            _writer.WriteLine("<tbody>");
            foreach (var diagnostic in _diagnostics)
            {
                WriteDiagnosticLine(diagnostic);
            }
            _writer.WriteLine("</tbody>");

            _writer.WriteLine("</table>");
        }

        private void WriteDiagnosticLine(Diagnostic diagnostic)
        {
            _writer.WriteLine("<tr class='severity-" + diagnostic.Severity.ToString().ToLowerInvariant() + "'>");

            // Severity
            _writer.WriteLine("<td class='severity'>");
            WriteString(diagnostic.Severity.ToString());
            _writer.WriteLine("</td>");

            // ID
            _writer.WriteLine("<td class='code'>");
            WriteString(diagnostic.Definition.Id);
            _writer.WriteLine("</td>");

            // Message
            _writer.WriteLine("<td class='description'>");
            WriteString(diagnostic.GetMessage());
            _writer.WriteLine("</td>");

            // Location
            _writer.WriteLine("<td class='location'>");
            WriteString(diagnostic.Location.ToString());
            _writer.WriteLine("</td>");

            _writer.WriteLine("</tr>");
        }

        private void WriteString(string? value)
        {
            WebUtility.HtmlEncode(value, _writer);
        }
    }
}