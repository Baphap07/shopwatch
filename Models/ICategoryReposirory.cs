using System;
using System.Collections.Generic;

namespace ShowWatch.Models
{
    public interface ICategoryReposirory
    {
        IEnumerable<Category> Gets();
    }
}
