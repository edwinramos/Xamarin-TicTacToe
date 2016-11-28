﻿using TicTacToeApp.Models.Entities;
using TicTacToeApp.Storage.Interfaces;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace TicTacToeApp.Storage
{
    public interface IKeyObject
    {
        string Key { get; set; }
    }
    public class DatabaseManager
    {
        SQLiteConnection database;
        public DatabaseManager()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            database.CreateTable<Score>();
        }

        public void SaveValue<T>(T value) where T : IKeyObject, new()
        {
            var all = (from entry in database.Table<T>().AsEnumerable<T>()
                       where entry.Key == value.Key
                       select entry).ToList();
            if (all.Count == 0)
                database.Insert(value);
            else
                database.Update(value);
        }

        public void DeleteValue<T>(T value) where T : IKeyObject, new()
        {
            var all = (from entry in database.Table<T>().AsEnumerable<T>()
                       where entry.Key == value.Key
                       select entry).ToList();
            if (all.Count == 1)
                database.Delete(value);
            else
                throw new Exception("The database doesn't contain an entry with the specified key");
        }

        public List<TSource> GetAllItems<TSource>() where TSource : IKeyObject, new()
        {
            return database.Table<TSource>().AsEnumerable<TSource>().ToList();
        }

        public TSource GetItem<TSource>(string key) where TSource : IKeyObject, new()
        {
            var result = (from entry in database.Table<TSource>().AsEnumerable<TSource>()
                          where entry.Key == key
                          select entry).FirstOrDefault();
            return result;
        }
    }
}