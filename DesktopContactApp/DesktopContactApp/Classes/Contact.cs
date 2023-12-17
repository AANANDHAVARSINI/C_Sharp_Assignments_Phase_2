using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopContactApp.Classes
{
    /// <summary>
    /// Represents Contact.
    /// </summary>
    public class Contact
    {
        /// <summary>
        /// Contact Id.
        /// </summary>
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }

        /// <summary>
        /// Contact Name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Contact Email.
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        /// Contact Phone.
        /// </summary>
        public string Phone { get; set; }
        public override string ToString()
        {
            return base.ToString() ;
        }
    }
}
