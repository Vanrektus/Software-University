using System.Collections.Generic;
using System.Text;

namespace DetailPrinter
{
    class Manager : Employee
    {
        //---------------------------Fields---------------------------
        private readonly IReadOnlyCollection<string> documents;

        //---------------------------Properties---------------------------
        public IReadOnlyCollection<string> Documents => this.documents;

        //---------------------------Constructors---------------------------
        public Manager(string name, ICollection<string> documents)
            : base(name)
        {
            this.documents = new List<string>(documents);
        }

        //---------------------------Methods---------------------------
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Documents: {string.Join(", ", this.Documents)}");

            return sb.ToString().TrimEnd();
        }
    }
}
