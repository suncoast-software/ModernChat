using ModernChat.MVVM.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ModernChat.MVVM.ViewModel
{
   public class MainViewModel : ObservableObject
    {
        public ObservableCollection<MessageModel> Messages { get; set; }
        public ObservableCollection<ContactModel> Contacts { get; set; }
        public ICommand SendCommand { get; set; }

        private ContactModel _selectedContact;
        public ContactModel SelectedContact
        {
            get => _selectedContact;
            set => OnPropertyChanged(ref _selectedContact, value);
        }

        private string message;
        public string Message
        {
            get => message;
            set => OnPropertyChanged(ref message, value);
        }

        public MainViewModel()
        {
            SendCommand = new RelayCommand(Send);

            Messages = new();
            Contacts = new();

            for (int i = 0; i < 5; i++)
            {
                Contacts.Add(new ContactModel
                {
                    Username = $"Allison {i}",
                    ImageSource = "https://i.imgur.com/yMWvLXd.png",
                    Messages = Messages
                });
            }
            LoadMessages();
        }

        private void Send()
        {
            Messages.Add(new MessageModel
            {
                Message = Message,
                FirstMessage = false,
                
            });
            Message = "";
        }

        private void LoadMessages()
        {
            Messages.Add(new MessageModel
            {
                Username = "Allison",
                UsernameColor = "#000",
                ImageSource = "https://i.imgur.com/yMWvLXd.png",
                Message = $"hello",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });
   
            Messages.Add(new MessageModel
            {
                Username = "Timothy",
                UsernameColor = "#409aff",
                ImageSource = "https://imgur.com/gallery/wd37E",
                Message = "hello there",
                Time = DateTime.Now,
                IsNativeOrigin = false,
                FirstMessage = true
            });
        }
    }
}