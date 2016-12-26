using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    class TextNote : Note
    {
        private string _note;
        public TextNote(string title, int status) : base(title, status)
        {
            var stringBuilder = new StringBuilder("<FlowDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><Paragraph>Hello</Paragraph><Paragraph>start you note here</Paragraph><Paragraph>enjoy;)</Paragraph></FlowDocument>");
            _note = stringBuilder.ToString();
        }

        public string Note
        {
            get { return _note; }
            set { _note=value;}
        }
        


    }
}
