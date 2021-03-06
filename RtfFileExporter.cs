﻿#region

using System;
using System.Drawing;
using System.Windows.Forms;
using Tabster.Data;
using Tabster.Data.Processing;

#endregion

namespace RtfFile
{
    public class RtfFileExporter : ITablatureFileExporter
    {
        private RichTextBox _rtb;

        #region Implementation of ITablatureFileExporter

        public FileType FileType { get; private set; }

        public Version Version
        {
            get { return new Version("1.0"); }
        }

        public void Export(ITablatureFile file, string fileName, TablatureFileExportArguments args)
        {
            if (_rtb == null)
                _rtb = new RichTextBox {Font = args.Font, Text = file.Contents};

            _rtb.SaveFile(fileName);
            _rtb.SaveFile(fileName); //have to call method twice otherwise empty file is created
        }

        #endregion

        public RtfFileExporter()
        {
            FileType = new FileType("Rich Text Format File", ".rtf");
        }

        ~RtfFileExporter()
        {
            if (_rtb != null && !_rtb.IsDisposed)
                _rtb.Dispose();
        }
    }
}