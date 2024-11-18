
using Microsoft.AspNetCore.Components;

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
