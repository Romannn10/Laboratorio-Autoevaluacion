using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Data;
using System.Windows.Forms;

namespace pryMamondezAutoEvaluacion
{
    internal class clsLocalidades
    {
        string Cadena = "";
        OleDbConnection Conector;
        OleDbCommand Comando;
        OleDbDataAdapter Adaptador;
        DataTable Tabla;

        public  clsLocalidades()
        {
            Cadena = "provider=microsoft.jet.oledb.4.0;data source=CLIMA.mdb";
            Conector = new OleDbConnection(Cadena);
            Comando = new OleDbCommand();
            Comando.Connection = Conector;
            Comando.CommandType = CommandType.TableDirect;
            Comando.CommandText = "Localidades";
            Adaptador = new OleDbDataAdapter(Comando);
            Tabla = new DataTable();
            Adaptador.Fill(Tabla);
            DataColumn[] vector = new DataColumn[1];
            vector[0] = Tabla.Columns["localidad"];
            Tabla.PrimaryKey = vector;

        }
        public DataTable getAll()
        {
            return Tabla;
        }


    }

}
