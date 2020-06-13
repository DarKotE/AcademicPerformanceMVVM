﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AcademicPerformance.ClassFolder;
using AcademicPerformance.CommandsFolder;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace AcademicPerformance.ViewModelFolder

{
    public class VMStudentJournal : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private StudentJournalController studentJournalController;

        public VMStudentJournal()
        {
            studentJournalController = new StudentJournalController();
            LoadData();
            //saveCommand = new RelayCommand(Save);
        }
        

        private ObservableCollection<StudentJournalModel> filteredJournalList;

        public ObservableCollection<StudentJournalModel> FilteredJournalList
        {
            get { return filteredJournalList; }
            set { filteredJournalList = value; OnPropertyChanged("FilteredJournalList"); }

        }
        private ObservableCollection<StudentJournalModel> journalList;

        public ObservableCollection<StudentJournalModel> JournalList
        {
            get { return journalList; }
            set { journalList = value; OnPropertyChanged("JournalList"); }

        }

        private string searchText;
        public string SearchText
        {
            get { return searchText; }
            set { searchText = value; 
                OnPropertyChanged("SearchText");
                Filter();
            }

        }

        private void Filter()
        {
                JournalList = new ObservableCollection<StudentJournalModel>(studentJournalController.GetAll());
                FilteredJournalList = 
                    new ObservableCollection<StudentJournalModel>(
                        from item
                        in JournalList
                        where item.NameEvaluation.ToUpper().Contains(SearchText.ToUpper())
                          || item.FIOTeacher.ToUpper().Contains(SearchText.ToUpper())
                          || item.FIOStudent.ToUpper().Contains(SearchText.ToUpper())
                          || item.NameDiscipline.ToUpper().Contains(SearchText.ToUpper())
                          || item.NumberEvaluation.ToString().ToUpper().Contains(SearchText.ToUpper())
                          || item.IdJournal.ToString().ToUpper().Contains(SearchText.ToUpper())
                        select item);
        }


        private StudentJournalModel selectedRow;
        public StudentJournalModel SelectedRow
        {
            get { return selectedRow; }
            set { selectedRow = value; OnPropertyChanged("SelectedRow"); }

        }


        private void LoadData()
        {
            SearchText="";
            Filter();

        }
        
        private RelayCommand saveCommand;

        public RelayCommand SaveCommand
        {
            get { return saveCommand; }
        }

        private string message;

        public string Message
        {
            get { return message; }
            set { message = value; OnPropertyChanged(Message); }
        }


        public void Save(object param)
        {
            MessageBox.Show(Message);
        }

    }
}
