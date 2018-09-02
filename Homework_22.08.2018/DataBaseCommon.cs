﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Data.Linq.Mapping;
using System.Data.Linq;
using System.Windows.Controls;
using System.ComponentModel.DataAnnotations;

namespace Homework_22._08._2018
{
    internal static class DataBaseCommon
    {
        private static string connectionString = ConfigurationManager.AppSettings["cnStr"];
        private static DataContext DC = new DataContext(connectionString);
        private static Table<Subscribers> TS = DC.GetTable<Subscribers>();
        //private static String _Provider = ConfigurationManager.AppSettings["provider"];
        //private static DbProviderFactory DbPF = DbProviderFactories.GetFactory(_Provider);
        //private static DbConnection dbConnection = DbPF.CreateConnection();
        //private static DbCommand DbC = DbPF.CreateCommand();
        /*----------------------------------------------------------------------------------------------------------*/
        static DataBaseCommon()
        {
            //dbConnection.ConnectionString = connectionString;
            //try
            //{
            //    MessageBox.Show("Open");
            //    //dbConnection.Open();
            //   // dbConnection.ChangeDatabase("NameDatabase");
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show("Database does not responded.");
            //    MessageBox.Show(ex.Message);
            //    for (int i = 0; i < 10; ++i)
            //        Console.Beep();
            //}
            //finally
            //{
               
            //}
        }
        public static void AddData(Grid GridTypeArray, bool? _Sex, string _Date)
        {
            try
            {
                Subscribers Sub = new Subscribers {
                    LastName =  ((CSWPFAutoCompleteTextBox.UserControls.AutoCompleteTextBox)((StackPanel)GridTypeArray.Children[11]).Children[0]).Text,
                    FirstName = ((CSWPFAutoCompleteTextBox.UserControls.AutoCompleteTextBox)((StackPanel)GridTypeArray.Children[12]).Children[0]).Text,
                    SurName = ((CSWPFAutoCompleteTextBox.UserControls.AutoCompleteTextBox)((StackPanel)GridTypeArray.Children[13]).Children[0]).Text,
                    Sex = _Sex,
                    DateOfBirth = _Date,
                    Country = ((CSWPFAutoCompleteTextBox.UserControls.AutoCompleteTextBox)((StackPanel)GridTypeArray.Children[14]).Children[0]).Text,
                    City = ((CSWPFAutoCompleteTextBox.UserControls.AutoCompleteTextBox)((StackPanel)GridTypeArray.Children[15]).Children[0]).Text,
                    Address_ = ((CSWPFAutoCompleteTextBox.UserControls.AutoCompleteTextBox)((StackPanel)GridTypeArray.Children[16]).Children[0]).Text,
                    PhoneNumber = ((CSWPFAutoCompleteTextBox.UserControls.AutoCompleteTextBox)((StackPanel)GridTypeArray.Children[17]).Children[0]).Text
                };
                TS.InsertOnSubmit(Sub);
                DC.SubmitChanges();
            }
            catch(Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
            finally
            {
                for (int i = 11; i < 18; ++i)
                {
                    ((CSWPFAutoCompleteTextBox.UserControls.AutoCompleteTextBox)((StackPanel)GridTypeArray.Children[i]).Children[0]).Text = null;
                }
            }
        }
        public static List<DTablePB> ShowData( List<DTablePB> LDTPB)
        {
            IQueryable<Subscribers> Data = TS.Where(Search => Search.LastName.Contains("Kamal"));
            foreach (Subscribers _Data in Data)
            {
                LDTPB.Add(new DTablePB(_Data.LastName, _Data.FirstName, _Data.SurName, _Data.Sex, _Data.DateOfBirth, _Data.Country, _Data.City, _Data.Address_, _Data.PhoneNumber));
            }
            return LDTPB;
        }
    }

    [Table(Name = "Subscribers")]
    public class Subscribers
    {
       //[DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        [Column(Name = "ID_SUBSCRIBER", IsPrimaryKey = true, IsDbGenerated = true)]
        public int ID_SUBSCRIBER { set; get; }

        [Column(Name = "LastName")]
        public string LastName { get; set; }

        [Column(Name = "FirstName")]
        public string FirstName { get; set; }

        [Column (Name = "SurName")]
        public string SurName { get; set; }

        [Column(Name = "Sex")]
        public bool? Sex { get; set; }

        [Column(Name = "DateOfBirth")]
        public string DateOfBirth { get; set; }

        [Column(Name = "Country")]
        public string Country { get; set; }

        [Column(Name = "City")]
        public string City { get; set; }

        [Column(Name = "Address_")]
        public string Address_ { get; set; }

        [Column(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }
    }
}
