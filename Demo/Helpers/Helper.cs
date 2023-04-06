using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Helpers
{
    public class Helper
    {
        private static EventContext _context;
        public static EventContext GetContext()
        {
            if (_context == null)
                _context = new EventContext();
            return _context;
        }
    }
}
