﻿namespace PersonBubble
{
    using GameGlobal;
    using GameObjects;
    using GameObjects.PersonDetail;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;
    using PluginInterface;
    using PluginInterface.BaseInterface;
    using System;
    using System.Drawing;
    using System.Xml;
    using System.Collections.Generic;

    public class PersonBubblePlugin : GameObject, IPersonBubble, IBasePlugin, IPluginXML, IPluginGraphics
    {
        private string author = "clip_on";
        private const string DataPath = @"GameComponents\PersonBubble\Data\";
        private string description = "人物气泡";
        private GraphicsDevice graphicsDevice;
        private const string Path = @"GameComponents\PersonBubble\";
        private PersonBubble personBubble = new PersonBubble();
        private string pluginName = "PersonBubblePlugin";
        private string version = "1.0.0";
        private const string XMLFilename = "PersonBubbleData.xml";

        public void AddPerson(object person, Microsoft.Xna.Framework.Point position, string branchName)
        {
            this.personBubble.AddPerson(person as Person, position, branchName);
        }

        public void AddPersonText(object person, Microsoft.Xna.Framework.Point position, string text)
        {
            this.personBubble.AddPersonText(person as Person, position, text);
        }

        public void AddPerson(object person, Microsoft.Xna.Framework.Point position, Enum kind, string fallback)
        {
            Person p = (Person)person;
            TextMessageKind k = (TextMessageKind)kind;
            List<string> msg = p.Scenario.GameCommonData.AllTextMessages.GetTextMessage(p.ID, k);
            if (msg.Count > 0)
            {
                this.AddPersonText(person, position, msg[GameObject.Random(msg.Count)]);
            }
            else
            {
                this.AddPerson(person, position, fallback);
            }
        }

        public void Dispose()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            if (this.personBubble.IsShowing)
            {
                this.personBubble.Draw(spriteBatch);
            }
        }

        public void Initialize()
        {
        }

        public void LoadDataFromXMLDocument(string filename)
        {
            Microsoft.Xna.Framework.Graphics.Color color;
            Font font;
            XmlDocument document = new XmlDocument();
            document.Load(filename);
            XmlNode nextSibling = document.FirstChild.NextSibling;
            XmlNode node = nextSibling.ChildNodes.Item(0);
            this.personBubble.BackgroundTexture = Texture2D.FromFile(this.graphicsDevice, @"GameComponents\PersonBubble\Data\" + node.Attributes.GetNamedItem("FileName").Value);
            this.personBubble.BackgroundSize.X = int.Parse(node.Attributes.GetNamedItem("Width").Value);
            this.personBubble.BackgroundSize.Y = int.Parse(node.Attributes.GetNamedItem("Height").Value);
            this.personBubble.PopoutOffset.X = int.Parse(node.Attributes.GetNamedItem("PopoutX").Value);
            this.personBubble.PopoutOffset.Y = int.Parse(node.Attributes.GetNamedItem("PopoutY").Value);
            node = nextSibling.ChildNodes.Item(1);
            this.personBubble.PortraitClient = StaticMethods.LoadRectangleFromXMLNode(node);
            node = nextSibling.ChildNodes.Item(2);
            this.personBubble.ClientPosition = StaticMethods.LoadRectangleFromXMLNode(node);
            this.personBubble.TextClientWidth = this.personBubble.ClientPosition.Width;
            this.personBubble.TextClientHeight = this.personBubble.ClientPosition.Height;
            this.personBubble.TextRowMargin = int.Parse(node.Attributes.GetNamedItem("RowMargin").Value);
            StaticMethods.LoadFontAndColorFromXMLNode(node, out font, out color);
            this.personBubble.TextBuilder.SetFreeTextBuilder(this.graphicsDevice, font);
            this.personBubble.DefaultTextColor = color;
            node = nextSibling.ChildNodes.Item(3);
            this.personBubble.PersonSpecialTextTimeLast = int.Parse(node.Attributes.GetNamedItem("TimeLast").Value);
            color = new Microsoft.Xna.Framework.Graphics.Color {
                PackedValue = uint.Parse(node.Attributes.GetNamedItem("Color").Value)
            };
            this.personBubble.PersonSpecialTextColor = color;
            this.personBubble.TextTree.LoadFromXmlFile(@"GameComponents\PersonBubble\Data\PersonBubbleTree.xml");
        }

        public void SetGraphicsDevice(GraphicsDevice device)
        {
            this.graphicsDevice = device;
            this.LoadDataFromXMLDocument(@"GameComponents\PersonBubble\PersonBubbleData.xml");
        }

        public void SetScreen(object screen)
        {
            this.personBubble.Initialize(screen as Screen);
        }

        public void Update(GameTime gameTime)
        {
            if (this.personBubble.IsShowing)
            {
                this.personBubble.Update(gameTime);
            }
        }

        public string Author
        {
            get
            {
                return this.author;
            }
        }

        public string Description
        {
            get
            {
                return this.description;
            }
        }

        public object Instance
        {
            get
            {
                return this;
            }
        }

        public bool IsShowing
        {
            get
            {
                return this.personBubble.IsShowing;
            }
            set
            {
                this.personBubble.IsShowing = value;
            }
        }

        public string PluginName
        {
            get
            {
                return this.pluginName;
            }
        }

        public string Version
        {
            get
            {
                return this.version;
            }
        }
    }
}

