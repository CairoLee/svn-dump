// Distributed as part of TiledSharp, Copyright 2012 Marshall Ward
// Licensed under the Apache License, Version 2.0
// http://www.apache.org/licenses/LICENSE-2.0

using System;
using System.IO;
using System.Reflection;
using System.Xml.Linq;

namespace FreeWorld.Game.Tests.Tmx
{
    public class TmxDocument
    {
        public string TmxDirectory {get; private set;}

        // Subclass XDocument? Override XDocument.Load?
        protected XDocument ReadXml(string filepath)
        {
            XDocument xDoc;

            var asm = Assembly.GetEntryAssembly();
            var manifest = asm.GetManifestResourceNames();

            var fileResPath = filepath.Replace(
                    Path.DirectorySeparatorChar.ToString(), ".");
            var fileRes = Array.Find(manifest, s => s.EndsWith(fileResPath));

            // If there is a resource in the assembly, load the resource
            // Otherwise, assume filepath is an explicit path
            if (fileRes != null)
            {
                Stream xmlStream = asm.GetManifestResourceStream(fileRes);
                xDoc = XDocument.Load(xmlStream);
                TmxDirectory = "";
            }
            else
            {
                xDoc = XDocument.Load(filepath);
                TmxDirectory = Path.GetDirectoryName(filepath);
            }

            return xDoc;
        }
    }
}
