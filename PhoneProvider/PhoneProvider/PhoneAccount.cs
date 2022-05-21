using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhoneProvider { 
    class PhoneAccount
    {
        protected string name;
        protected static int nrGenerator = 1234;
        protected int codAbonat;
        protected string logFile;
        public string Name { get { return this.name; } }
        public int CodAbonat { get { return this.codAbonat; } }
        public PhoneAccount(string name)
        {
            this.name = name;
            this.codAbonat = nrGenerator;
            nrGenerator++;
            this.logFile = this.codAbonat + ".txt";

        }
        public virtual void Info(ref string info)
        {
            info += "Nume: " + this.name + " " + "Cod abonat: " + this.codAbonat+"\n";
            this.WriteToFile(info);
        }
        protected void WriteToFile(string mesaj)
        {
            StreamWriter s = new StreamWriter(this.logFile, true);
            s.WriteLine(mesaj);
            s.Close();
        }
    }
}