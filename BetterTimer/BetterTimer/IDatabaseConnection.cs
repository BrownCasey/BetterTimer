using System;
using System.Collections.Generic;
using System.Text;

namespace BetterTimer
{
    public interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
