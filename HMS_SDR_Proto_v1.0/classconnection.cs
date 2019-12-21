using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Odbc;
using System.Data;
using System.Windows.Forms;

namespace HMS_SDR_Proto_v1._0
{
    class classconnection
    {
        /// <summary>
        /// This class establishes connection to database
        /// </summary>

        OdbcConnection con;
        OdbcCommand cmd = new OdbcCommand();
        OdbcDataAdapter da = new OdbcDataAdapter();
        public static string USER_ID;

        // Establish database connection
        public classconnection()
        {
            con = new OdbcConnection("Driver={MySQL ODBC 3.51 Driver};Server=localhost;User=root;PWD=brylle14;DB=hms_sdr");
        }

        // Function for executing select queries
        public bool SelectRec(string strSQL, DataTable dt)
        {
            try
            {
                da = new OdbcDataAdapter(strSQL, con);
                da.Fill(dt);
                return true;
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        // Function for executing insert,update,delete queries
        public bool ModRec(string strSQL)
        {
            Boolean btnTest = new Boolean();

            try
            {
                con.Open();
                cmd = new OdbcCommand(strSQL, con);
                int rowAffected = cmd.ExecuteNonQuery();
                if (rowAffected > 0)
                {
                    btnTest = true;
                }
                con.Close();
            }
            catch (InvalidCastException ex)
            {
                MessageBox.Show(ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return btnTest;
        }

        //
        public void setCurrentUser(string userID)
        {
            USER_ID = userID;
        }
        public string getCurrentUser() 
        {
            return USER_ID;
        }
    }
}
