using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MySql.Data;
using WebAPI01.Models;
using System.Diagnostics;
using System.Collections;
using MySql.Data.MySqlClient;

namespace WebAPI01
{
    public class PersonPersistence
    {
        private MySql.Data.MySqlClient.MySqlConnection conn;
        #region CONSTRUCTOR : CREATE AND OPEN CONNECTION TO DATABASE
        public PersonPersistence()
        {
            string myConnectionString;
            myConnectionString = "server=127.0.0.1;uid=admin;pwd=Pa$$w0rd;database=phildb";
            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();
            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine("SQL Exception in Constructor in PersonPersistence");
                Console.WriteLine(ex);
                Console.WriteLine(ex.Data);
            }
        }
        #endregion
        #region GETALL RECORDS AND RETURN A LIST OF PEOPLE
        public List<Person> getPersons()
        {
            List<Person> personList = new List<Person>();
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
            string sqlString = "SELECT * from tbl_personnel";
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            try
            {
                mySqlReader = cmd.ExecuteReader();
                while (mySqlReader.Read())
                {
                    Person p = new Person();
                    p.ID = mySqlReader.GetInt32(0);
                    p.FirstName = mySqlReader.GetString(1);
                    p.LastName = mySqlReader.GetString(2);
                    p.PayRate = mySqlReader.GetFloat(3);
                    p.StartDate = mySqlReader.GetDateTime(4);
                    p.EndDate = mySqlReader.GetDateTime(5);
                    personList.Add(p);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("MySQL exception");
                Console.WriteLine(ex);
                Console.WriteLine(ex.Data);
            }
            return personList;
        }
        #endregion
        #region GET ONE PERSON
        public Person getPerson(long ID)
        {
            Person p = new Person();
            p.FirstName = "Phil";
            p.LastName = "Anderson";
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
            string sqlString = "SELECT * from tbl_personnel where ID = " + ID.ToString();
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            try
            {
                mySqlReader = cmd.ExecuteReader();
                if (mySqlReader.Read())
                {
                    p.ID = mySqlReader.GetInt32(0);
                    p.FirstName = mySqlReader.GetString(1);
                    p.LastName = mySqlReader.GetString(2);
                    p.PayRate = mySqlReader.GetFloat(3);
                    p.StartDate = mySqlReader.GetDateTime(4);
                    p.EndDate = mySqlReader.GetDateTime(5);
                }
                else
                {

                }

            }
            catch (Exception ex) {
                Trace.WriteLine("SQL Exception");
                Trace.WriteLine(ex);
                Trace.WriteLine(ex.Data);
            }
            finally
            {

            }

            return p;

        }
        #endregion
        #region INSERT ONE NEW PERSON AND RETURN LONG ID
        public long savePerson(Person personToSave)
        {
            string sqlString = "INSERT INTO tbl_personnel (FirstName, LastName, PayRate, StartDate, EndDate) VALUES ('" + personToSave.FirstName + "' , '" + personToSave.LastName + "' , '" + personToSave.PayRate + "', '" + personToSave.StartDate.ToString("yyyy-MM-dd HH:mm:ss") + "', '" + personToSave.EndDate.ToString("yyyy-MM-dd HH:mm:ss") + "')";
            MySql.Data.MySqlClient.MySqlCommand cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            cmd.ExecuteNonQuery(); // no result expected
            long id = cmd.LastInsertedId;
            return id;
        }
        #endregion
        #region UPDATE ONE RECORD : PASS IN ID AND PERSON AND RETURN BOOLEAN WHETHER SUCCESSFUL OR NOT
        public bool updatePerson(long id, Person p)
        {
            MySqlDataReader mySqlReader = null;
            string sqlString = "SELECT * FROM tbl_personnel where ID = " + id.ToString();
            var cmd = new MySqlCommand(sqlString, conn);
            try
            {
                mySqlReader = cmd.ExecuteReader();
                if (mySqlReader.Read())
                {
                    mySqlReader.Close();
                    p.FirstName += "bob";
                    sqlString = "UPDATE tbl_personnel SET FirstName='" + p.FirstName + "' where ID = " + id.ToString();
                    cmd = new MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                    return true;
                }
            }
            catch(Exception ex)
            {
                Trace.WriteLine("SQL Exception in PUT");
                Trace.WriteLine(ex);
                Trace.WriteLine(ex.Data);
            }
            return false;
        }
        #endregion
        #region DELETE ONE PERSON AND RETURN BOOLEAN TRUE OR FALSE IF RECORD EXISTED BEFORE DELETE
        public bool deletePerson(long ID)
        {
            bool recordDeleted = false;
            MySql.Data.MySqlClient.MySqlDataReader mySqlReader = null;
            string sqlString = "SELECT * from tbl_personnel where ID = " + ID.ToString();
            var cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
            try
            {
                mySqlReader = cmd.ExecuteReader();
                if (mySqlReader.Read())
                {
                    mySqlReader.Close();
                    sqlString = "DELETE FROM tbl_personnel where ID = " + ID.ToString();
                    cmd = new MySql.Data.MySqlClient.MySqlCommand(sqlString, conn);
                    cmd.ExecuteNonQuery();
                    recordDeleted = true;
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine("SQL Exception in Delete");
                Console.WriteLine(ex);
                Console.WriteLine(ex.Data);
            }
            return recordDeleted;
        }
        #endregion
    }

}