﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Cofoundry.Core.IO
{
    /// <summary>
    /// TextWriter implementation to write to the debug log.
    /// </summary>
    /// <see cref="http://stackoverflow.com/a/637151/486434"/>
    public class DebugTextWriter : System.IO.TextWriter
    {
        public override void Write(char[] buffer, int index, int count)
        {
            Write(new String(buffer, index, count));
        }

        public override void Write(string value)
        {
            System.Diagnostics.Debug.Write(value);
        }

        public override Encoding Encoding
        {
            get { return System.Text.Encoding.Default; }
        }
    }
}
