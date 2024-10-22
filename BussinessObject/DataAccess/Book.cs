using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace BussinessObject.DataAccess;

public partial class Book
{
    public int BookId { get; set; }

    public string? Title { get; set; }

    public int? Type { get; set; }

    public int? PubId { get; set; }

    public double? Price { get; set; }

    public string? Advance { get; set; }

    public double? Royalty { get; set; }

    public double? YtlSales { get; set; }

    public string? Note { get; set; }

    public DateTime? PublishedDate { get; set; }

    [JsonIgnore]
    public virtual Publisher? Pub { get; set; }
}
