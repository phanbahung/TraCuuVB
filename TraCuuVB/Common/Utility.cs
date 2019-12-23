using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace TraCuuVB
{
    public class SqlDataProvider
    {
        #region "Membres Prives"

        private string _connectionString;

        #endregion

        #region "Constructeurs"

        public SqlDataProvider()
        {
            try
            {
                _connectionString = ConfigurationManager.ConnectionStrings["NguoiPhuThuocConnectionString"].ConnectionString;
            }
            catch
            {
            }
        }

        #endregion

        #region "Proprietes"

        public string ConnectionString
        {
            get { return _connectionString; }
        }

        #endregion

        #region "Functions"

        public DataTable FillTable(string ProcName, params ObjectPara[] Para)
        {
            try
            {
                DataTable tb = new DataTable();
                SqlDataAdapter adap = new SqlDataAdapter(ProcName, _connectionString);
                adap.SelectCommand.CommandType = CommandType.StoredProcedure;
                if (Para != null)
                {
                    foreach (ObjectPara p in Para)
                    {
                        adap.SelectCommand.Parameters.Add(new SqlParameter(p.Name, p.Value));
                    }
                }
                adap.Fill(tb);
                return tb;
            }
            catch
            {
                return null;
            }
        }

        public object RunSQL(string ProcName, params ObjectPara[] Para)
        {
            try
            {
                SqlConnection _cnn = new SqlConnection(_connectionString);
                _cnn.Open();

                SqlCommand cmd = new SqlCommand(ProcName, _cnn);
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (ObjectPara p in Para)
                {
                    cmd.Parameters.Add(new SqlParameter(p.Name, p.Value));
                }
                int result = (Int32)cmd.ExecuteScalar();
                return result;
            }
            catch
            {
                return null;
            }
        }

        #endregion
    }

    public class ObjectPara
    {
        string _name;

        object _Value;
        public ObjectPara(string Pname, object PValue)
        {
            _name = Pname;
            _Value = PValue;
        }

        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public object Value
        {
            get { return _Value; }
            set { _Value = value; }
        }
    }

}