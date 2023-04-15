using QuanLySanXuatJuKi.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLySanXuatJuKi.DAO
{
    public class LocationSetDAO
    {
        private static LocationSetDAO instance;

        public static LocationSetDAO Instance
        {
            get { if (instance == null) instance = new LocationSetDAO(); return LocationSetDAO.instance; }
            private set { LocationSetDAO.instance = value; }
        }

        public static int TableWidth = 290;
        public static int TableHeight = 240;

        private LocationSetDAO() { }

        public void SwitchTable(int id1, int id2)
        {
            DataProvider.Instance.ExecuteQuery("USP_SwitchTabel @idTable1 , @idTabel2", new object[]{id1, id2});
        }

        public List<LocationSet> LoadTableList()
        {
            List<LocationSet> tableList = new List<LocationSet>();

            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM LocationSet");

            foreach (DataRow item in data.Rows)
            {
                LocationSet table = new LocationSet(item);
                tableList.Add(table);
            }

            return tableList;
        }
    }
}
