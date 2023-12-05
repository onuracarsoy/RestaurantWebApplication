using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class ContactAbout
	{

		public int ContactAboutID { get; set; }

		public string Title { get; set; }

		public string Description { get; set; }

		public string Address { get; set; }

		public string GoogleAddress { get; set; }

		public string Phone { get; set; }

		public string Mail { get; set; }

		public string? SocialMedia1 { get; set; }

		public string? SocialMedia2 { get; set; }
	}
}
