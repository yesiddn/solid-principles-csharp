using System.Collections;
using System.Text;

namespace SingleResponsability
{
  public class ExportHelper<T>
  {
    public void ExportToCSV(IEnumerable<T> items)
    {
      StringBuilder sb = new StringBuilder();
      string header = "";
      string[] dataRows = new string[items.Count()];
      foreach (var prop in typeof(T).GetProperties())
      {
        header += $"{prop.Name};";
        for (int i = 0; i < items.Count(); i++)
        {
          var propValue = prop.GetValue(items.ToArray()[i]);
          if (propValue == null)
          {
            dataRows[i] += ";";
            continue;
          }

          var propType = propValue.GetType();

          if (propType.GetInterface(nameof(IEnumerable)) != null && propType != typeof(string))
          {
            var propValueAsEnumerable = (propValue as IEnumerable)?.Cast<object>() ?? new List<object>();

            dataRows[i] += $"{String.Join("|", propValueAsEnumerable.Select(x => x.ToString()))};";
            continue;
          }

          dataRows[i] += $"{propValue};";
        }
      }
      sb.AppendLine(header.Trim(';'));
      foreach (var dataRow in dataRows)
      {
        sb.AppendLine(dataRow.Trim(';'));
      }
      System.IO.File.WriteAllText(System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, $"Export_{typeof(T).ToString()}.csv"), sb.ToString(), Encoding.Unicode);
    }
  }
}