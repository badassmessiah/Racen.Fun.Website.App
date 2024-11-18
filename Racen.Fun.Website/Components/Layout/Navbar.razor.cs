
using Microsoft.AspNetCore.Components;
using Microsoft.JSInterop;

namespace Racen.Fun.Website.Components.Layout
{
	public partial class Navbar
	{
		private bool isNavbarCollapsed = false;
		

		public void ToggleNavbar()
		{
			isNavbarCollapsed = !isNavbarCollapsed;
		}

        

        
    }
}
