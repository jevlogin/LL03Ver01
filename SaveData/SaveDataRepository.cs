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
            Debug.Log(_path);
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
                    Debug.Log($"goodBonus - {goodBonus}");

                    var position = goodBonus.transform.position;
                    var name = goodBonus.name;
                    var isEnabled = goodBonus.IsInteractable;

                    //Debug.Log($"isEnabled = {isEnabled}");

                    var good = new SaveData { Position = position, Name = name, IsEnabled = isEnabled };

                    //Debug.Log($"good = {good.GetHashCode()}");

                    saveAll.Add(good);
                }
                if (item is BadBonus badBonus)
                {
                    //Debug.Log($"badBonus - {badBonus}");

                    var position = badBonus.transform.position;
                    var name = badBonus.name;
                    var isEnabled = badBonus.IsInteractable;

                    if (isEnabled)
                    {
                        saveAll.Add(new SaveData { Position = position, Name = name, IsEnabled = isEnabled });
                    }
                }
                if (item is PlayerBase player)
                {
                    //Debug.Log($"player - {player}");

                    var position = player.transform.position;
                    var name = player.name;
                    var isEnabled = player.isActiveAndEnabled;
                    saveAll.Add(new SaveData { Position = position, Name = name, IsEnabled = isEnabled });
                }
            }

            var name1 = _fileName;
            var fullPath = Path.Combine(_path, name1);

            var text = _data.JSONSerialize(saveAll, fullPath);
            Debug.Log(text);



            //foreach (var save in saveAll)
            //{
            //    var name = save.Name + _fileName;
            //    var fullPath = Path.Combine(_path, name);

            //    _listFileName.Add(fullPath);

            //    _data.Save(save, fullPath);
            //}
        }

        public void Load(List<object> listObjects)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                Debug.Log($"File not found - {file}");
                return;
            }

            var listSaveData = _data.Load(file);

            Debug.Log(listSaveData);

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
