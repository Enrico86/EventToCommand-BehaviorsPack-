using EventToBehaviors.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace EventToBehaviors.ViewModel
{
    public class MainPageViewModel
    {
        public ObservableCollection <Person> PeopleList { get; set; }

        public MainPageViewModel()
        {
            PeopleList = new ObservableCollection<Person>
            {
                new Person
                {
                    Name = "Enrico",
                    Age=34,
                },
                new Person
                {
                    Name = "Anais",
                    Age=33,
                },
                new Person
                {
                    Name = "Arturo",
                    Age=65,
                },
                new Person
                {
                    Name = "Angelo",
                    Age=65,
                },
            };
        }
    }
}
