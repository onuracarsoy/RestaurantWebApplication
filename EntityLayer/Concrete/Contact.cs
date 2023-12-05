﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
	public class Contact
	{
        public int ContactID { get; set; }

        public string SenderName { get; set; }

        public string SenderMail { get; set; }

        public string Message { get; set; }

        public DateTime Date { get; set; }


    }
}
