using System;

public class NewsDto
{
	public string Category { get; set; }
	public double DateTime { get; set; }
	public string Headline { get; set; }
	public double Id { get; set; }
	public string Image { get; set; }
	public string Related { get; set; }
	public string Source { get; set; }
	public string Summary { get; set; }
	public string Url { get; set; }

	public NewsDto()
	{
        Category = string.Empty;
		DateTime = 0;
		Headline = string.Empty;
		Id = 0;
		Image = string.Empty;
		Related = string.Empty;
		Source = string.Empty;
		Summary = string.Empty;
		Url = string.Empty;
	}
}
