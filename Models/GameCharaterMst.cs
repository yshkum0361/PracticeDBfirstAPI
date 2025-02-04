using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace PracticeDBfirstAPI.Models;

public partial class GameCharaterMst
{
    public int GcId { get; set; }

    public string? Gcname { get; set; }

    public int? FkGameId { get; set; }

    public string Power { get; set; } = null!;


    [JsonIgnore]
    public virtual GameDetailsMst? FkGame { get; set; }
}
