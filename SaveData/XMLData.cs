﻿using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using UnityEngine;


namespace JevLogin
{
    public sealed class XMLData : IData<SaveData>
    {
        public SaveData Load(string path = "")
        {
            var result = new SaveData();
            if (!File.Exists(path))
            {
                return result;
            }
            using (var reader = new XmlTextReader(path))
            {
                while (reader.Read())
                {
                    var key = XmlNameAttributes.Name;
                    if (reader.IsStartElement(key))
                    {
                        result.Name = reader.GetAttribute(XmlNameAttributes.Value);
                    }

                    key = XmlNameAttributes.PositionX;
                    if (reader.IsStartElement(key))
                    {
                        result.Position.X = reader.GetAttribute(XmlNameAttributes.Value).TrySingle();
                    }
                    key = XmlNameAttributes.PositionY;
                    if (reader.IsStartElement(key))
                    {
                        result.Position.Y = reader.GetAttribute(XmlNameAttributes.Value).TrySingle();
                    }
                    key = XmlNameAttributes.PositionZ;
                    if (reader.IsStartElement(key))
                    {
                        result.Position.Z = reader.GetAttribute(XmlNameAttributes.Value).TrySingle();
                    }
                    key = XmlNameAttributes.IsEnable;
                    if (reader.IsStartElement(key))
                    {
                        result.IsEnabled = reader.GetAttribute(XmlNameAttributes.Value).TryBool();
                    }
                }
            }
            return result;
        }

        public void Save(SaveData data, string path = "")
        {
            var xmlDoc = new XmlDocument();

            XmlNode rootNode = xmlDoc.CreateElement(XmlNameAttributes.Player);
            xmlDoc.AppendChild(rootNode);

            var element = xmlDoc.CreateElement(XmlNameAttributes.Name);
            element.SetAttribute(XmlNameAttributes.Value, data.Name);
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement(XmlNameAttributes.PositionX);
            element.SetAttribute(XmlNameAttributes.Value, data.Position.X.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement(XmlNameAttributes.PositionY);
            element.SetAttribute(XmlNameAttributes.Value, data.Position.Y.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement(XmlNameAttributes.PositionZ);
            element.SetAttribute(XmlNameAttributes.Value, data.Position.Z.ToString());
            rootNode.AppendChild(element);

            element = xmlDoc.CreateElement(XmlNameAttributes.IsEnable);
            element.SetAttribute(XmlNameAttributes.Value, data.IsEnabled.ToString());
            rootNode.AppendChild(element);

            XmlNode userNode = xmlDoc.CreateElement("Info");
            var attribute = xmlDoc.CreateAttribute("Unity");
            attribute.Value = Application.unityVersion;
            userNode.Attributes.Append(attribute);
            userNode.InnerText = "System Language: " + Application.systemLanguage;
            rootNode.AppendChild(userNode);

            xmlDoc.Save(path);
        }

        public void SaveList(List<SaveData> saveAll, string path)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<SaveData>));

            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                xmlSerializer.Serialize(fileStream, saveAll);
            }
        }

        public List<SaveData> LoadList(string path = "")
        {
            var xmlSerializer = new XmlSerializer(typeof(List<SaveData>));

            using (var fileStream = new FileStream(path, FileMode.Open))
            {
                var newList = xmlSerializer.Deserialize(fileStream) as List<SaveData>;
                return newList;
            }
        }
    }
}
