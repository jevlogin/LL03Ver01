﻿using System.Collections;
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
                    var isEnabled = goodBonus.IsInteractable;
                    var type = goodBonus.GetType().Name;

                    saveAll.Add(new SaveData { Position = position, Name = name, IsEnabled = isEnabled, TypeObject = type });
                }
                if (item is BadBonus badBonus)
                {
                    var position = badBonus.transform.position;
                    var name = badBonus.name;
                    var isEnabled = badBonus.IsInteractable;
                    var type = badBonus.GetType().Name;

                    saveAll.Add(new SaveData { Position = position, Name = name, IsEnabled = isEnabled, TypeObject = type });
                }
                if (item is PlayerBase player)
                {
                    var position = player.transform.position;
                    var name = player.name;
                    var isEnabled = player.isActiveAndEnabled;
                    var type = player.GetType().Name;

                    saveAll.Add(new SaveData { Position = position, Name = name, IsEnabled = isEnabled, TypeObject = type });
                }
            }

            var fullPath = Path.Combine(_path, _fileName);
            _data.SaveList(saveAll, fullPath);

        }

        public void Load(List<object> listObjects)
        {
            var file = Path.Combine(_path, _fileName);
            if (!File.Exists(file))
            {
                Debug.Log($"File not found - {file}");
                return;
            }

            var listSaveData = _data.LoadList(file);

            foreach (var item in listSaveData)
            {
                Debug.Log(item);
            }


            for (int i = 0; i < listSaveData.Count; i++)
            {
                SaveData item = listSaveData[i];
                if (listObjects[i] is PlayerBall playerBase && item.TypeObject.Equals(typeof(PlayerBall).Name))
                {
                    playerBase.transform.position = item.Position;
                    playerBase.name = item.Name;
                    playerBase.gameObject.SetActive(item.IsEnabled);
                }
                if (listObjects[i] is GoodBonus goodBonus && item.TypeObject.Equals(typeof(GoodBonus).Name))
                {
                    goodBonus.transform.position = item.Position;
                    goodBonus.name = item.Name;
                    goodBonus.IsInteractable = item.IsEnabled;
                }
                if (listObjects[i] is BadBonus badBonus && item.TypeObject.Equals(typeof(BadBonus).Name))
                {
                    badBonus.transform.position = item.Position;
                    badBonus.name = item.Name;
                    badBonus.IsInteractable = item.IsEnabled;
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
