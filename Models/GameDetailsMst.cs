using System;
using System.Collections.Generic;

namespace PracticeDBfirstAPI.Models;

public partial class GameDetailsMst
{
    public int GameId { get; set; }

    public string? GameName { get; set; }

    public double? Price { get; set; }

    public int? ReleaseYear { get; set; }

    public virtual ICollection<GameCharaterMst> GameCharaterMsts { get; set; } = new List<GameCharaterMst>();
}
