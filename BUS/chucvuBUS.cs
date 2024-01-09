using Dao;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bus
{
    public class chucvuBUS
    {
        private static chucvuBUS instance;
        public static chucvuBUS Instance
        {
            get
            {
                if (instance == null)
                    instance = new chucvuBUS();
                return instance;
            }
        }
        public List<chucvuDTO> loadds()
        {
            return chucvuDAO.Instance.loadds();
        }
    }
}
