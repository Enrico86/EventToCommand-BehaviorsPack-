using EventToBehaviors.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

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

        public ICommand ButtonCommand { get; } = new Command(async () =>
               await App.Current.MainPage.DisplayAlert("ButtonCommand:", "Button Pressed", "OK"));
        //Definimos el comando ButtonCommand que se dispara cuando se haga click en el botón. En este caso solo es necesario hacer un
        //Binding desde el botón hacia este comando.

        public ICommand ItemTappedCommand { get; } = new Command(async (item) =>
        //En este caso vemos que el comando ejecuta una expresión lambda que recibe por parametro el item que se ha seleccionado en el ListView
        //Coseguimos hacer esto porqué en XAML habíamos definido la propiedad EventArgsPropertyPath como el Item del evento.
        {
            var person = item as Person;
            if (person != null)
            //Creamos una variable person que transforma en un objeto Person el parametro item. Es decir, el elemento seleccionado en el View va
            //a ser el parametro de nuestra expresión Lambda y cuando llega a este punto del código lo guardamos en una variable como un objeto
            //de tipo Person
            {
                await App.Current.MainPage.DisplayAlert("ItemTappedCommand", $"El elemento seleccionado es: {person.Name}", "OK");
                //Gracias a la variable que hemos creado (de tipo Person) podemos acceder a las propiedades de esa clase y en este ejemplo
                //sencillo visualizar el Name de la persona seleccionada en un DisplayAlert
            }
        }
        );

        public ICommand AppearingCommand { get; } = new Command(async () =>
        await App.Current.MainPage.DisplayAlert("AppearingCommand", "AppearingCommand","OK")
        );
        //Cuando se esté mostrando la ContentPage al usuario se disparará un DisplayAlert.
    }
}
