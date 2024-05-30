using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;

        public static TableDAO Instance
        {
            get { if (instance == null) instance = new TableDAO(); return TableDAO.instance; }
            private set { TableDAO.instance = value; }
        }

        public static int TableWidth = 90;
        public static int TableHeight = 90;

        private TableDAO() { }
        public void TableBook(int id)
        {
            string query = string.Format("UPDATE dbo.TableFood SET status = N'{0}' where id = {1}","Có người", id) ;
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public void TableEmpty(int id)
        {
            string query = string.Format("UPDATE dbo.TableFood SET status = N'{0}' where id = {1}", "Trống", id);
            DataProvider.Instance.ExecuteNonQuery(query);
        }
        public List<Table> LoadTableList()
        {
            List<Table> tableList = new List<Table>();

            DataTable data = DataProvider.Instance.ExecuteQuery("USP_GetTableList");

            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);
                tableList.Add(table);
            }

            return tableList;
        }
    }
}
