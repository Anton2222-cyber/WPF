using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

using WpfApp6.Model;

namespace WpfApp6.ViewModel
{
    class ApplicationViewModel : INotifyPropertyChanged
    {
        Person selectedPerson;

        public ObservableCollection<Person> Persons { set; get; }

        public Person SelectedPerson
        {
            get
            {
                return selectedPerson;
            }
            set
            {
                selectedPerson = value;
                OnPropertyChanged("SelectedPerson");

            }
        }

        public ApplicationViewModel()
        {
            Persons = new ObservableCollection<Person>
            {
                new Person{FirstName="Olia", LastName="Sidoruk", Age=20, Surname="Vasilivna",  Model_car="Audi A1", Number="AI7879OM"},
                new Person{FirstName="Sasha", LastName="Kovalchuk", Age=21, Surname="Ivanovych",  Model_car="BMW M3", Number="BH1116IT"},
                new Person{FirstName="Kostia", LastName="Tverdohlib", Age=19, Surname="Mykolaiovych",  Model_car="Bentley Mulsanne", Number="KA1112AE"},
                new Person{FirstName="Tolia", LastName="Ovechko", Age=22, Surname="Ivanovych",  Model_car="Aston Martin DBX", Number="KA2801IP"}
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string n="")
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(n));
            }
        }
    }
}
