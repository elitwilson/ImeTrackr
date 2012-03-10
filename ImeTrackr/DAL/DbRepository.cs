using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using ImeTrackr.Models;

namespace ImeTrackr.DAL
{
    public class DbRepository
    {
        public void AutoBackupDB ()
        {
            string NewBackup = "ImeTrackrDbBAK" + DateTime.Today.ToString("MM-dd-yyyy") + ".sdf";
            string BackUpPath = @"C:\Users\McArlo\Documents\Visual Studio 2010\Projects\ImeTrackr\ImeTrackr\App_Data\" + NewBackup;

            var db = new ImeTrackrContext();
            db.Database.Connection.Close();
            if (!File.Exists(BackUpPath))
            {
                File.Copy(@"C:\Users\McArlo\Documents\Visual Studio 2010\Projects\ImeTrackr\ImeTrackr\App_Data\ImeTrackrDB.sdf",
                BackUpPath);
            }

            db.Database.Connection.Open();
        }

        public void BackupDB()
        {
            string NewBackup = "ImeTrackrDbBAK" + DateTime.Today.ToString("MM-dd-yyyy") + ".sdf";
            string BackUpPath = @"C:\Users\McArlo\Documents\Visual Studio 2010\Projects\ImeTrackr\ImeTrackr\App_Data\" + NewBackup;

            var db = new ImeTrackrContext();
            db.Database.Connection.Close();
            File.Delete(BackUpPath);
            File.Copy(@"C:\Users\McArlo\Documents\Visual Studio 2010\Projects\ImeTrackr\ImeTrackr\App_Data\ImeTrackrDB.sdf",
            BackUpPath);

            db.Database.Connection.Open();
        }

        public void RestoreDb()
        {
            
        }

        public IQueryable<Contact> GetContacts(Organization organization)
        {
            var contacts = new List<Contact>();

            

            return contacts.AsQueryable();
        }
    }
}