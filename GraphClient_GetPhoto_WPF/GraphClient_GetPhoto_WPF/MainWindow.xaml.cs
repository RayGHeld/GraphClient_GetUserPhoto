using Microsoft.Graph;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.CompilerServices;
using System.Windows.Threading;

namespace GraphClient_GetPhoto_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static GraphServiceClient graphClient = GraphClient.ServiceClient( AuthenticationProviders.InteractiveAuthentication.AuthenticationProvider );


        public MainWindow()
        {
            InitializeComponent();

            Get_Me(imagePhoto, userInfo);
        }

        static async void Get_Me(System.Windows.Controls.Image img, System.Windows.Controls.Label label)
        {
            User u = null;
            try
            {
                u = await graphClient.Me.Request().GetAsync();
                
                label.Content = $"{u.DisplayName}\n{u.JobTitle}";
            } catch ( Exception ex )
            {
                Console.WriteLine( $"Error getting user info: {ex.Message}" );
            }

            try
            {
                using ( Stream stream = await graphClient.Users[u.Id].Photo.Content.Request().GetAsync() )
                {

                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = stream;
                    bitmap.EndInit();

                    img.Source = bitmap;
                }
            }
            catch ( Exception ex )
            {
                Console.WriteLine( $"Error getting image: {ex.Message}" );
            }

        }

    }
}
