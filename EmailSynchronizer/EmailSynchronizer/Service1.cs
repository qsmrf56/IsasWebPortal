using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace EmailSynchronizer
{
    public partial class Service1 : ServiceBase
    {

        System.Data.SqlClient.SqlConnection con;
        static Logger logger = new Logger();
        

        public bool connectDB(string connstr)
        {

            con = new System.Data.SqlClient.SqlConnection();
            con.ConnectionString = connstr;


           


            int i = 0;
            while (con.State == ConnectionState.Closed)
            {

                try
                {

                    con.Open();
                }
                catch (Exception e)
                {

                    logger.Log("connection to DB Failed. " + e.GetBaseException());
                    //return false;
                }

                i++;
            }
            
           string oString = "Select * from CountryConfigs;";
            SqlCommand cmd = new SqlCommand(oString,con);
            using (SqlDataReader oReader = cmd.ExecuteReader())
                {
                    while (oReader.Read())
                    {
                        string xx = oReader["countryName"].ToString();
                        logger.Log(xx);
                    }

                   
                }

            con.Close();
            
            return true;
        }


        public Service1()
        {

            logger.Log("EmailSynchronizer Service is now running");
                       
            InitializeComponent();


            try
            {
                //string connString = @"Data Source=(LocalDb)\v11.0; AttachDBFilename=C:\Users\Administrator\Documents\Visual Studio 2013\Projects\IsasWebPortal\IsasWebPortal\App_Data\IsasWebPortal.IsasWebPortal.Models.IsasWebPortalDataContext.mdf;Trusted_Connection=True; Integrated Security=SSPI";
                // string connString = "Data Source=(LocalDb)\v11.0;Integrated Security=SSPI;AttachDBFilename=|DataDirectory|\IsasWebPortal.IsasWebPortal.Models.IsasWebPortalDataContext.mdf providerName="System.Data.SqlClient"
                string connString = @"Data Source=(LocalDb)\v11.0; AttachDBFilename=C:\Users\qsmrf\Desktop\IsasWebPortal\IsasWebPortal\IsasWebPortal\App_Data\IsasWebPortal.IsasWebPortal.Models.IsasWebPortalDataContext.mdf;Trusted_Connection=True; Integrated Security=SSPI";

                logger.Log("Connecting to DB: " + connString);
                if (connectDB(connString))
                { logger.Log("Connection to DB successful"); }
                else
                {
                    logger.Log("connection to DB Failed.");
                }

            }
            catch (Exception e)
            {

                logger.Log("connection to DB Failed.");

            }


        

        }




        protected override void OnStart(string[] args)
        {

            
          
           


        }

        protected override void OnStop()
        {
        }
    }
}
