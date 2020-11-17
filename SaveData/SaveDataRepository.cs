using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor.PackageManager;
using UnityEngine;

namespace JevLogin
{
    public sealed class SaveDataRepository
    {
        private readonly IData<SaveData> _data;

        private const string _folderName = "dataSave";
        private const string _fileName = "data.bat";
        private readonly string _path;

        private List<string> _listFileName;

        public SaveDataRepository()
        {
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                _data = new PlayerPrefsData();
            }
            else
            {
                //_data = new SerializableXMLData<SaveData>();
                //_data = new BinarySerializationData<SaveData>();
                //_data = new StreamData();
                _data = new JsonData<SaveData>();
                //_data = new XMLData();
                //_data = new PlayerPrefsData();
            }
            _path = Path.Combine(Application.dataPath, _folderName);
            _listFileName = new List<string>();
        }

        public void Save(PlayerBase player)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            var savePlayer = new SaveData
            {
                Position = player.transform.position,
                Name = "JEVLOGIN",
                IsEnabled = true
            };

            _data.Save(savePlayer, Path.Combine(_path, _fileName));
        }



        public void Save(List<object> listObjects)
        {
            if (!Directory.Exists(Path.Combine(_path)))
            {
                Directory.CreateDirectory(_path);
            }

            var saveAll = new List<SaveData>();

            foreach (var item in listObjects)
            {
                if (item is GoodBonus goodBonus)
                {
                    var position = goodBonus.transform.position;
                    var name = goodBonus.name;
                    var isEnabled = goodBonus.isActiveAndEnabled;
                    saveAll.Add(new SaveData { Position = position, Name = name, IsEnabled = isEnabled });
                }
                if (item is BadBonus badBonus)
                {
                    var position = badBonus.transform.position;
                    var name = badBonus.name;
                    var isEnabled = badBonus.isActiveAndEnabled;
                    saveAll.Add(new SaveData { Position = position, Name = name, IsEnabled = isEnabled });
                }
                if (item is PlayerBase player)
                {
                    var position = player.transform.position;
                    var name = player.name;
                    var isEnabled = player.isActiveAndEnabled;
                    saveAll.Add(new SaveData { Position = position, Name = name, IsEnabled = isEnabled });
                }
            }

            foreach (var save in saveAll)
            {
                var name = save.Name + _fileName;
                _listFileName.Add(name);
                _data.Save(save, Path.Combine(_path, name));
            }
        }

        public void Load(List<object> listObjects)
        {
            foreach (var item in listObjects)
            {
                if (item is PlayerBase player)
                {
                    foreach (var file in _listFileName)
                    {
                        var tempFileName = Path.Combine(_path, file);
                        if (!File.Exists(tempFileName))
                        {
                            Debug.Log($"File not found - {file}");
                            return;
                        }

                        var newPlayer = _data.Load(tempFileName);
                        player.transform.position = newPlayer.Position;
                        player.name = newPlayer.Name;
                        player.gameObject.SetActive(newPlayer.IsEnabled);

                        Debug.Log(newPlayer);
                    }
                }
            }
        }

        public void Load(PlayerBase player)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                Debug.Log($"File not found - {file}");
                return;
            }
            var newPlayer = _data.Load(file);
            player.transform.position = newPlayer.Position;
            player.name = newPlayer.Name;
            player.gameObject.SetActive(newPlayer.IsEnabled);

            Debug.Log(newPlayer);
        }


    }
}
