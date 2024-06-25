using System;
using System.IO;
using System.Text;
using System.Windows.Controls;

namespace ST10251131_PROG6221_POE_FINAL
{
    public class TextWindow : TextWriter
    {
        private Action<string> _outputAction;

        public TextWindow(Action<string> outputAction)
        {
            _outputAction = outputAction;
        }

        public override Encoding Encoding => Encoding.UTF8;

        public override void Write(char value)
        {
            base.Write(value);
            _outputAction(value.ToString());
        }

        public override void Write(string value)
        {
            base.Write(value);
            _outputAction(value);
        }
    }
}

