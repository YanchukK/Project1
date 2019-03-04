using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace Registration2._0
{
    class FileService : IFileService
    {
        public List<User> GetAllUsers() // Десериализация
        {
            var users = new List<User>();

            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Document.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            foreach (XmlElement xnode in xRoot)
            {
                User user = new User();
                XmlNode attr = xnode.Attributes.GetNamedItem("username");
                if (attr != null)
                    user.Username = attr.Value;

                foreach (XmlNode childnode in xnode.ChildNodes)
                {
                    if (childnode.Name == "password")
                        user.Password = childnode.InnerText;

                    if (childnode.Name == "email")
                        user.Email = childnode.InnerText;
                }
                users.Add(user);
            }
            return users;
        }

        public void AddNewUser(User user)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Document.xml");
            XmlElement xRoot = xDoc.DocumentElement;
            // создаем новый элемент user
            XmlElement userElem = xDoc.CreateElement("user");
            // создаем атрибут username
            XmlAttribute nameAttr = xDoc.CreateAttribute("username");
            // создаем элементы password и email
            XmlElement companyElem = xDoc.CreateElement("password");
            XmlElement ageElem = xDoc.CreateElement("email");
            // создаем текстовые значения для элементов и атрибута
            XmlText nameText = xDoc.CreateTextNode(user.Username);
            XmlText companyText = xDoc.CreateTextNode(user.Password);
            XmlText ageText = xDoc.CreateTextNode(user.Email);

            //добавляем узлы
            nameAttr.AppendChild(nameText);
            companyElem.AppendChild(companyText);
            ageElem.AppendChild(ageText);
            userElem.Attributes.Append(nameAttr);
            userElem.AppendChild(companyElem);
            userElem.AppendChild(ageElem);
            xRoot.AppendChild(userElem);
            xDoc.Save("Document.xml");
        }

        public bool IsUsernameDontExist(string username)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Document.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            // выбор всех дочерних узлов
            XmlNodeList childnodes = xRoot.SelectNodes("user[@username='" + username + "']");
            if (childnodes.Count != 0)
            {
                return false;
            }
            else
            {
                return true;
            }                
        }

        public bool IsEmailDontExist(string email)
        {
            XmlDocument xDoc = new XmlDocument();
            xDoc.Load("Document.xml");
            XmlElement xRoot = xDoc.DocumentElement;

            // выбор всех дочерних узлов
            XmlNodeList childnodes = xRoot.SelectNodes("user[email='" + email + "']");
            if (childnodes.Count != 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
