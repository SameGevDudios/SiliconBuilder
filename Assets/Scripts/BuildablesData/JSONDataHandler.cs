using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JSONDataHandler : IBuildablesDataHandler
{
    private IBuildablesListing _listing;
    private SpawnBuildingList _spawnList;
    private string _path;

    public JSONDataHandler(IBuildablesListing listing, SpawnBuildingList spawnList)
    {
        _listing = listing;
        _spawnList = spawnList;
        _path = Path.Combine(Application.persistentDataPath, "Data.json");
        Debug.Log(Application.persistentDataPath);
    }
    public void SaveData()
    {
        List<Buildable> list = new();
        list.AddRange(_listing.GetCurrentBuildables());
        string json = JsonUtility.ToJson(new Wrapper<Buildable> { items = list });
        File.WriteAllText(_path, json);
        Debug.Log($"Saved data at: {_path}");
    }
    public void LoadData() 
    {
        if (File.Exists(_path))
        {
            string json = File.ReadAllText(_path);
            Wrapper<Buildable> wrapper = JsonUtility.FromJson<Wrapper<Buildable>>(json);
            _listing.SetList(wrapper.items);
        }
        else
        {
            // Load from default
            _listing.SetList(_spawnList.Buildings);
            SaveData();
        }
        Debug.Log($"Loaded data from: {_path}");
    }
    // Wrapper class for JSON serialization (to handle lists)
    [System.Serializable]
    private class Wrapper<T>
    {
        public List<T> items;
    }
}
