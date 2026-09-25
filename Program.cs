using Newtonsoft.Json;

var tasks = new[]
{
    new WorkItem("Parse invoices", 3),
    new WorkItem("Publish summary", 2)
};

var report = new WorkReport(tasks.Select(x => x.Title).ToArray(), tasks.Sum(x => x.EstimatedHours));
Console.WriteLine(JsonConvert.SerializeObject(report));

internal sealed record WorkItem(string Title, int EstimatedHours);

internal sealed record WorkReport(IReadOnlyList<string> Tasks, int TotalEstimatedHours);
