using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.IO;

namespace Grupp_5_Garage_v2
{
    public class CreateXMLDatabase
    {
        public string DatabaseFolderName;
        public string XmlSchemaName;
        public string XmlFileName;
        public string tabelName;
        public DataTable dt;
        public CreateXMLDatabase(string DatabaseFolderName, string XmlSchemaName, string XmlFileName, string tabelName)
        {
            this.DatabaseFolderName = DatabaseFolderName + "_Database";
            this.XmlSchemaName = XmlSchemaName + "_s.xml";
            this.XmlFileName = XmlFileName + ".xml";
            this.tabelName = tabelName;
            dt = new DataTable(tabelName);

        }

        public void CreateTabel()
        {
            // adding columns 
            if (dt.Columns.Count < 1)
            {
                dt.Columns.Add("RegNumber");
                dt.Columns.Add("Color");
                dt.Columns.Add("NumberOfWheels", typeof(int));
                dt.Columns.Add("PassengerCapacity", typeof(int));
                dt.Columns.Add("FuelType");
                dt.Columns.Add("Manufacturer");
                dt.Columns.Add("ModelOfYear");

                //dt.Constraints.Add("reg_pk", dt.Columns["RegNumber"], true);
            }

        }

        public void CreateDataBaseFolder()
        {
            if (!Directory.Exists(DatabaseFolderName)) Directory.CreateDirectory(DatabaseFolderName);
        }

        // Method checks if XML files Exists
        public bool CheckXmlFiles()
        {
            if (File.Exists(DatabaseFolderName + "/" + XmlSchemaName) && File.Exists(DatabaseFolderName + "/" + XmlFileName))
                return true;
            else return false;
        }

        // Method save data in xml file
        public void WriteXmlFiles()
        {
            CreateDataBaseFolder();
            CreateTabel();
            dt.WriteXmlSchema(DatabaseFolderName + "/" + XmlSchemaName);
            dt.WriteXml(DatabaseFolderName + "/" + XmlFileName);
        }

        // Method read data from xml file
        public void ReadXmlFiles()
        {

            if (CheckXmlFiles())
            {
                dt.ReadXmlSchema(DatabaseFolderName + "/" + XmlSchemaName);
                dt.ReadXml(DatabaseFolderName + "/" + XmlFileName);
            }
        }

        // Method adding new row to the tabel
        public void addRow(string regnr, string color, int numofwheels, int capacity, string fuel, string manfacture, string model)
        {

            dt.Rows.Add(regnr, color, numofwheels, capacity, fuel, manfacture, model);
            WriteXmlFiles();
        }

        public void PrintAllData()
        {

            for (int r = 0; r < dt.Rows.Count; r++)
            {
                for (int c = 0; c < dt.Columns.Count; c++)
                {
                    Console.Write(dt.Rows[r][c] + ((c < dt.Columns.Count - 1) ? " ; " : ""));
                }
                Console.WriteLine();
            }
        }

    }
}
