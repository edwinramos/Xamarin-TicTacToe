using System;
using SQLite;
using Android.Widget;
using TicTacToeApp.Storage.Interfaces;
using System.IO;
using TicTacToeApp.Droid.Storage.Implementations;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLiteDroid))]
namespace TicTacToeApp.Droid.Storage.Implementations
{
    public class SQLiteDroid : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            SQLitePCL.Batteries.Init();
            var sqliteFilename = "TicTacToeDB";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentPath, sqliteFilename);
            //Crete the connection
            var conn = new SQLite.SQLiteConnection(path);
            //Return the database connection
            return conn;
        }
    }
}