using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Models
{
    
    public class TextNote : Note
    {
        private string _note;
        public TextNote() : base("new",1) { }
        public TextNote(string title, int status) : base(title, status)
        {
            var stringBuilder = new StringBuilder("<FlowDocument xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><Paragraph>Hello</Paragraph><Paragraph>start you note here</Paragraph><Paragraph>enjoy;)</Paragraph></FlowDocument>");
            _note = stringBuilder.ToString();
        }

        public int Id { get; set; }

        public string Note
        {
            get { return _note; }
            set { _note = value; }
        }
    }
}
