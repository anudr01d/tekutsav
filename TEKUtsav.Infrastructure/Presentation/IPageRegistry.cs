using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TEKUtsav.Infrastructure.Presentation
{
    public interface IPageRegistry<TPage>
    {
        void RegisterPage(TPage page, Type viewType, Type viewModelType);
        Page GetPage(TPage page, object navigationParams = null);
    }
}
