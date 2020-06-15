﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace AcademicPerformance.ClassFolder
{
    public class StudentModel : INotifyPropertyChanged
    {

        private int idUser;
        public int IdUser
        {
            get { return idUser; }
            set { idUser = value; OnPropertyChanged("IdUser"); }
        }
        private int idStudent;
        public int IdStudent
        {
            get { return idStudent; }
            set { idStudent = value; OnPropertyChanged("IdStudent"); }
        }
        private string lastNameStudent;
        public string LastNameStudent
        {
            get { return lastNameStudent; }
            set { lastNameStudent = value; OnPropertyChanged("LastNameStudent"); }
        }
        private string firstNameStudent;
        public string FirstNameStudent
        {
            get { return firstNameStudent; }
            set { firstNameStudent = value; OnPropertyChanged("FirstNameStudent"); }
        }
        private string middleNameStudent;
        public string MiddleNameStudent
        {
            get { return middleNameStudent; }
            set { middleNameStudent = value; OnPropertyChanged("MiddleNameStudent"); }
        }
        private DateTime dateOfBirthStudent;
        public DateTime DateOfBirthStudent
        {
            get { return dateOfBirthStudent; }
            set { dateOfBirthStudent = value; OnPropertyChanged("DateOfBirthStudent"); }
        }

        private string numberPhoneStudent;
        public string NumberPhoneStudent
        {
            get { return numberPhoneStudent; }
            set { numberPhoneStudent = value; OnPropertyChanged("NumberPhoneStudent"); }
        }



        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        }
    }


}