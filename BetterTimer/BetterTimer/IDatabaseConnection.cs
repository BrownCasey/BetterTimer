using System;
using System.Collections.Generic;
using System.Text;

namespace BetterTimer
{
    interface IDatabaseConnection
    {
        SQLite.SQLiteConnection DbConnection();
    }
}
