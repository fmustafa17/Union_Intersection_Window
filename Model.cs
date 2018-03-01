using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

// Farhana Mustafa

namespace HW1
{
    class Model : INotifyPropertyChanged
    {
        private IntegerSet setOne = new IntegerSet();
        private IntegerSet setTwo = new IntegerSet();

        private string _setOne;
        public string SetOne
        {
            get { return _setOne; }
            set
            {
                _setOne = value;
                OnPropertyChanged("setOne");
            }
        }

        private string _setTwo;
        public string SetTwo
        {
            get { return _setTwo; }
            set { _setTwo = value; }
        }

        private string _statusBoxText;
        public string StatusBoxText
        {
            get { return _statusBoxText; }
            set
            {
                _statusBoxText = value;
                OnPropertyChanged("StatusBoxText");
            }
        }

        private string _unionText;
        public string UnionText
        {
            get { return _unionText; }
            set
            {
                _unionText = value;
                OnPropertyChanged("UnionText");
            }
        }

        private string _intersectionText;
        public string IntersectionText
        {
            get { return _intersectionText; }
            set
            {
                _intersectionText = value;
                OnPropertyChanged("IntersectionText");
            }
        }

        public void Update()
        {
            Restart();

            IntegerSet unionSet = new IntegerSet();
            IntegerSet intersectionSet = new IntegerSet();

            if (Tokenizer(SetOne, setOne) && Tokenizer(SetTwo, setTwo))
            {
                unionSet = setOne.Union(setTwo);
                UnionText = unionSet.ToString();

                intersectionSet = setOne.Intersection(setTwo);
                IntersectionText = intersectionSet.ToString();
                StatusBoxText = "Sets Entered Correctly";
            }
            else
            {
                StatusBoxText = "Sets Entered Incorrectly";
            }
        }

        private Boolean Tokenizer(string str, IntegerSet set)
        {
            foreach (var num in str.Split(','))
            {
                try
                {
                    set.InsertElement(Int32.Parse(num));
                }
                catch (Exception e)
                {
                    StatusBoxText = e.Message;
                    return false;
                }
            }

            return true;
        }

        public void Restart()
        {
            setOne.Clear();
            setTwo.Clear();
        }

        #region Data Binding Stuff
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyname));
            }
        }
        #endregion
    }
}
