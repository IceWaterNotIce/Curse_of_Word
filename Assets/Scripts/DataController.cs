using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SQLite4Unity3d;
using System.Data;
using System.Linq;

public class EnglishWord
{
    [PrimaryKey, AutoIncrement]
    public int Id { get; set; }
    public string Word { get; set; }
    public string Meaning { get; set; }
    public string ChineseMeaning { get; set; }
}

public class DataController : MonoBehaviour
{
    public SQLiteConnection Connection;
    private string dbPath = Application.streamingAssetsPath + "/Dictonary.db";
    void Start()
    {
        GetWords();
    }

    public void InsertWord(string word, string meaning, string chineseMeaning)
    {
        Connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        //insert data
        Connection.Insert(new EnglishWord
        {
            Word = word,
            Meaning = meaning,
            ChineseMeaning = chineseMeaning
        });
        Connection.Close();
    }

    public string[] GetWords()
    {
        Connection = new SQLiteConnection(dbPath, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create);
        List<EnglishWord> tables = Connection.Table<EnglishWord>().ToList();
        List<string> words = new List<string>();
        foreach (var item in tables)
        {
            words.Add(item.Word);
        }
        Connection.Close();
        return words.ToArray();
    }
}
