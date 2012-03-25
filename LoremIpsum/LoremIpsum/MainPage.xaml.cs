using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Tasks;

namespace LoremIpsum
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ApplicationBarIconButton_Click_About(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/About.xaml", UriKind.Relative));
        }

        private void ApplicationBarIconButton_Click_Email(object sender, EventArgs e)
        {
            EmailComposeTask emailTask = new EmailComposeTask();
            emailTask.Subject = "Lorem Ipsum";
            emailTask.Body = "Lorem ipsum dolor sit amet, enim vehicula vestibulum in" +
                             "nibh vehicula, placerat neque in leo ut eget curabitur," +
                             "vel eget pellentesque, integer eget nullam erat, earum " +
                             "pretium. Vel id augue donec nunc a, phasellus arcu non " +
                             "massa, consectetuer orci, ut eget. Ante erat, dis dolor" +
                             "tellus arcu, etiam enim ipsum, semper sed eleifend eges" +
                             "tas morbi, leo massa viverra praesent nulla lectus. Hac" +
                             "ipsam tellus ut enim, volutpat adipiscing nec massa auc" +
                             "tor mauris ac, in egestas in. Ipsum ornare ultricies. M" +
                             "orbi nulla morbi volutpat, etiam turpis, libero dui con" +
                             "sectetuer. Nulla non, aenean sit tellus, vitae convalli" +
                             "s elit, nullam semper, velit adipiscing elementum vehic" +
                             "ula. Non id lectus eu ut non, vel suspendisse eget null" +
                             "a pellentesque nemo, mauris urna, eu in turpis dis sapi" +
                             "en nec vestibulum, turpis facere sit suspendisse quidem" +
                             "neque nisl.\n\nEuismod nunc, duis in wisi nulla quam co" +
                             "nvallis. Orci eget ipsum ultricies pellentesque elit. V" +
                             "estibulum nascetur consectetuer cum, dolor urna lorem m" +
                             "i vivamus et, dui interdum suspendisse massa amet ut, n" +
                             "eque in, nunc lectus mus semper. Donec semper elit amet" +
                             "donec justo posuere, urna mauris, dolor suspendisse cum" +
                             "dolor, sit libero nunc nec dolor mauris leo, eu eleifen" +
                             "d ultrices orci libero lacus. Eget rhoncus elit etiam o" +
                             "dio commodo curabitur, cursus sed vehicula, ligula laor" +
                             "eet lacus arcu mattis felis, nunc a porttitor ipsum lac" +
                             "us.\n\nAliquam libero id eget et ut faucibus, nulla dic" +
                             "tum faucibus turpis suscipit. Phasellus vel pellentesqu" +
                             "e elit nunc, aliquam phasellus mattis molestie, tincidu" +
                             "nt lacus quam quia ac, aliquam mollis phasellus iaculis" +
                             "convallis vel accumsan. Mi urna nonummy tempus aliquam " +
                             "nulla, vel sed wisi. Massa mauris amet commodo, proin a" +
                             "nte semper nonummy massa donec quisque, pretium bibendu" +
                             "m sed pharetra, non blandit nonummy. Quam urna pellente" +
                             "sque consequat pellentesque eros tincidunt, pretium hym" +
                             "enaeos phasellus a neque, suscipit libero tincidunt ves" +
                             "tibulum auctor magna, quis aliquam tempus neque velit. " +
                             "Eget vestibulum laoreet euismod, class sapien varius, f" +
                             "ermentum luctus duis suscipit, urna mi sagittis in rhon" +
                             "cus et integer. Quam a, neque orci. Volutpat morbi ut, " +
                             "ut justo aliquam. Lorem justo. Ridiculus dolor elit tri" +
                             "stique, euismod non sit venenatis risus nibh malesuada." +
                             "Tempor at, sed eu tellus, interdum justo vestibulum mi," +
                             "est mollis suspendisse adipiscing cras.\n\nTellus et ne" +
                             "c leo ut ipsum, ante dui, consectetuer mi tellus, nibh " +
                             "ultricies dolor praesent. Tincidunt praesent in aliquam" +
                             ", ridiculus hendrerit optio quis, conubia senectus vest" +
                             "ibulum nullam est ac. Metus felis, dolore non sapien ur" +
                             "na donec, urna sodales. Habitasse tincidunt, montes ali" +
                             "quam a rhoncus. Nibh quis eu nec a, ac risus adipiscing" +
                             "ligula, donec aliquet laoreet ut odio, lorem sit, pelle" +
                             "ntesque purus ipsum id justo ut. Lectus integer, suscip" +
                             "it turpis vehicula odio dolor, lorem dolor id suspendis" +
                             "se, tellus ornare pede ornare posuere maecenas proin, e" +
                             "lit semper. Qui venenatis augue integer ipsum natoque a" +
                             "t, sit tristique malesuada quis augue faucibus imperdie" +
                             "t, est fames metus porttitor, vestibulum praesent amet";
            emailTask.Show();
        }
    }
}