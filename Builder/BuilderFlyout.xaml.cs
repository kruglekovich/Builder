using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Builder
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BuilderFlyout : ContentPage
    {
        public ListView ListView;

        public BuilderFlyout()
        {
            InitializeComponent();

            BindingContext = new BuilderFlyoutViewModel();
            ListView = MenuItemsListView;
        }

        class BuilderFlyoutViewModel : INotifyPropertyChanged
        {
            public ObservableCollection<BuilderFlyoutMenuItem> MenuItems { get; set; }

            public BuilderFlyoutViewModel()
            {
                MenuItems = new ObservableCollection<BuilderFlyoutMenuItem>(new[]
                {
                    new BuilderFlyoutMenuItem { Id = 0, Title = "Page 1" },
                    new BuilderFlyoutMenuItem { Id = 1, Title = "Page 2" },
                    new BuilderFlyoutMenuItem { Id = 2, Title = "Page 3" },
                    new BuilderFlyoutMenuItem { Id = 3, Title = "Page 4" },
                    new BuilderFlyoutMenuItem { Id = 4, Title = "Page 5" },
                });
            }

            #region INotifyPropertyChanged Implementation
            public event PropertyChangedEventHandler PropertyChanged;
            void OnPropertyChanged([CallerMemberName] string propertyName = "")
            {
                if (PropertyChanged == null)
                    return;

                PropertyChanged.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
            #endregion
        }
    }
}