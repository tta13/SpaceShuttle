using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Linq;

public class SaveSystemManager : Singleton<SaveSystemManager>
{
    private PlayerData _data;
    private ISaveLoader _saveloader;

    private string _filepath;


    protected override void Awake()
    {
        base.Awake();

        this._filepath = Application.persistentDataPath + "/player.data";
        Debug.Log(_filepath);

        if (_saveloader == null)
            _saveloader = gameObject.GetComponent<ISaveLoader>();

        Load();
    }

    public PlayerData GetPlayerData()
    {
        return _data;
    }

    private void Load()
    {
        if (File.Exists(_filepath))
        {
            _data = _saveloader.Load<PlayerData>(_filepath);
        }
        else
        {
            _data = new PlayerData();
        }
    }

    public void Save()
    {
        _saveloader.Save(_data, _filepath);
    }
}
