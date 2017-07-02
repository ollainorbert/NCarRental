using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NCarRental
{
    public class HomeViewModel : ObservableObject, IPageViewModel
    {
        public string Name
        {
            get
            {
                return "Home Page";
            }
        }
        
    }
}
